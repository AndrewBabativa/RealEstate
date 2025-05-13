using Moq;
using AutoMapper;
using NUnit.Framework;
using RealEstate.Application.UseCases;
using RealEstate.Application.DTOs.Property;  // Asumimos que estos DTOs existen ahora
using RealEstate.Core.Contracts;
using RealEstate.Core.Entities;
using RealEstate.Application.DTOs.Owner;
using RealEstate.Application.UseCases.Property;

[TestFixture]
public class CreatePropertyHandlerTests
{
    private Mock<IMapper> _mapperMock;
    private Mock<IPropertyRepository> _propertyRepoMock;
    private Mock<IOwnerRepository> _ownerRepoMock;
    private CreatePropertyHandler _handler;

    [SetUp]
    public void Setup()
    {
        _propertyRepoMock = new Mock<IPropertyRepository>();
        _ownerRepoMock = new Mock<IOwnerRepository>();
        _mapperMock = new Mock<IMapper>();

        _handler = new CreatePropertyHandler(
            _propertyRepoMock.Object,
            _ownerRepoMock.Object,
            _mapperMock.Object
        );
    }

    [Test]
    public async Task Handle_ShouldCreateProperty_WhenRequestIsValid()
    {
        // Arrange
        var request = new CreatePropertyDto
        {
            Name = "Casa Linda",
            Address = "Calle 123",
            CodeInternal = "INT-2025-001",
            Price = 200000,
            Year = 2020,
            OwnerId = 1
        };

        var owner = new OwnerEntity { OwnerId = 1 };
        var property = new PropertyEntity
        {
            PropertyId = 1,
            Name = request.Name,
            Address = request.Address,
            Price = request.Price,
            Year = request.Year,
            CodeInternal = request.CodeInternal,
            OwnerId = request.OwnerId
        };

        var propertyResponse = new PropertyDto
        {
            PropertyId = 1,
            Name = request.Name,
            Address = request.Address,
            Price = request.Price,
            Year = request.Year,
            CodeInternal = request.CodeInternal,
            OwnerId = request.OwnerId
        };

        _ownerRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(owner);

        _mapperMock.Setup(m => m.Map<PropertyEntity>(request)).Returns(property);
        _mapperMock.Setup(m => m.Map<PropertyDto>(It.IsAny<PropertyEntity>())).Returns(propertyResponse);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.AreEqual("Casa Linda", result.Name);
        Assert.AreEqual("Calle 123", result.Address);
        _propertyRepoMock.Verify(x => x.AddAsync(It.IsAny<PropertyEntity>()), Times.Once);
    }

    [Test]
    public void Handle_ShouldThrow_WhenOwnerDoesNotExist()
    {
        // Arrange
        var request = new CreatePropertyDto
        {
            Name = "Casa",
            Address = "Calle 1",
            Price = 100000,
            Year = 2020,
            OwnerId = 999
        };

        _ownerRepoMock.Setup(x => x.GetByIdAsync(999)).ReturnsAsync((OwnerEntity)null);

        // Act & Assert
        var ex = Assert.ThrowsAsync<KeyNotFoundException>(() =>
            _handler.Handle(request, CancellationToken.None));

        Assert.That(ex.Message, Does.Contain("Owner with ID 999 not found"));
    }
}
