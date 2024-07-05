using System.Threading.Tasks;
using Moq;
using Xunit;
using Application.Repositories;
using Domain.Entities;
using System.Threading;
using System.Linq.Expressions;
using System;

namespace Application.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task GetUserById_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var user = new User
            {
                Id = userId,
                FirstName = "Komutan",
                LastName = "Logar"
            };
            _mockUserRepository.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), null)).ReturnsAsync(user);

            // Act
            var result = await _mockUserRepository.Object.GetAsync(u => u.Id == userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal("Komutan", result.FirstName);
            Assert.Equal("Logar", result.LastName);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 1;
            _mockUserRepository.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), null)).ReturnsAsync((User)null);

            // Act
            var result = await _mockUserRepository.Object.GetAsync(u => u.Id == userId);

            // Assert
            Assert.Null(result);
        }
    }
}
