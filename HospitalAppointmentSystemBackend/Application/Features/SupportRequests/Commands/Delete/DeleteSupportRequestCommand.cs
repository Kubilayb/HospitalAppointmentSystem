﻿using Application.Features.SupportRequests.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.SupportRequests.Commands.Delete
{
    public class DeleteSupportRequestCommand : IRequest<DeleteSupportRequestResponse>
    {
        public int Id { get; set; }

        public class DeleteSupportRequestCommandHandler : IRequestHandler<DeleteSupportRequestCommand, DeleteSupportRequestResponse>
        {
            public readonly ISupportRequestRepository _supportRequestRepository;
            private readonly IMapper _mapper;
            public DeleteSupportRequestCommandHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper)
            {
                _supportRequestRepository = supportRequestRepository;
                _mapper = mapper;
            }

            public async Task<DeleteSupportRequestResponse> Handle(DeleteSupportRequestCommand request, CancellationToken cancellationToken)
            {
                SupportRequest? supportRequest = await _supportRequestRepository.GetAsync(i => i.Id == request.Id);

                if (supportRequest == null)
                {
                    throw new NotFoundException(SupportRequestsMessages.SupportRequestNotExists);
                }

                await _supportRequestRepository.DeleteAsync(supportRequest);
                DeleteSupportRequestResponse response = _mapper.Map<DeleteSupportRequestResponse>(supportRequest);
                return response;
            }
        }
    }
}
