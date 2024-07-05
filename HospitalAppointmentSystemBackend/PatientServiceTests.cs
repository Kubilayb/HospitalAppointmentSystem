using Application.Features.Patients.Queries.GetById;
using Moq;
using Xunit;

namespace Application.Tests
{
    public class PatientServiceTests
    {
        private readonly Mock<IPatientRepository> _mockPatientRepository;
        private readonly GetByIdPatientQueryHandler _handler;

        public PatientServiceTests()
        {
            _mockPatientRepository = new Mock<IPatientRepository>();
            _handler = new GetByIdPatientQueryHandler(_mockPatientRepository.Object);
        }

        [Fact]
        public async Task GetPatientById_ShouldReturnPatient_WhenPatientExists()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var patient = new Patient { Id = patientId, Name = "John Doe" };

            _mockPatientRepository.Setup(repo => repo.GetByIdAsync(patientId)).ReturnsAsync(patient);

            var query = new GetByIdPatientQuery { Id = patientId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(patientId, result.Id);
            Assert.Equal("John Doe", result.Name);
        }

        [Fact]
        public async Task GetPatientById_ShouldReturnNull_WhenPatientDoesNotExist()
        {
            // Arrange
            var patientId = Guid.NewGuid();

            _mockPatientRepository.Setup(repo => repo.GetByIdAsync(patientId)).ReturnsAsync((Patient)null);

            var query = new GetByIdPatientQuery { Id = patientId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
    }
}
