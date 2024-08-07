﻿namespace Application.Features.Departments.Queries.GetById
{
    public class GetByIdDepartmentResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
