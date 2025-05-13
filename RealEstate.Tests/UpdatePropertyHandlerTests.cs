using Moq;
using AutoMapper;
using NUnit.Framework;
using RealEstate.Application.DTOs.Property; 
using RealEstate.Core.Contracts;
using RealEstate.Core.Entities;
using RealEstate.Application.UseCases.Property;

namespace RealEstate.Tests.UseCases
{
    [TestFixture]
    public class UpdatePropertyHandlerTests
    {
        private Mock<IPropertyRepository> _propertyRepoMock;
        private Mock<IMapper> _mapperMock;
        private UpdatePropertyHandler _handler;

        [SetUp]
        public void Setup()
        {
            _propertyRepoMock = new Mock<IPropertyRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new UpdatePropertyHandler(_propertyRepoMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task Handle_ShouldUpdateProperty_WhenPropertyExists()
        {
            // Arrange
            var request = new UpdatePropertyDto  
            {
                PropertyId = 1,
                Name = "Casa Actualizada",
                Address = "Nueva Dirección",
                Year = 2021
            };

            var existingProperty = new PropertyEntity
            {
                PropertyId = 1,
                Name = "Antigua Casa",
                Address = "Vieja Dirección",
                Year = 2010
            };

            var updatedResponse = new PropertyDto  
            {
                PropertyId = 1,
                Name = "Casa Actualizada",
                Address = "Nueva Dirección",
                Year = 2021
            };

            _propertyRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingProperty);
            _mapperMock.Setup(m => m.Map<PropertyDto>(It.IsAny<PropertyEntity>())).Returns(updatedResponse);

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.AreEqual("Casa Actualizada", result.Name);
            Assert.AreEqual("Nueva Dirección", result.Address);
            Assert.AreEqual(2021, result.Year);
            _propertyRepoMock.Verify(r => r.UpdateAsync(existingProperty), Times.Once);
        }

        [Test]
        public void Handle_ShouldThrow_WhenPropertyDoesNotExist()
        {
            var request = new UpdatePropertyDto { PropertyId = 99 };  
            _propertyRepoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((PropertyEntity)null);

            var ex = Assert.ThrowsAsync<ArgumentException>(() =>
                _handler.Handle(request, CancellationToken.None));

            Assert.That(ex.Message, Does.Contain("Property with ID 99 not found"));
        }
    }
}
