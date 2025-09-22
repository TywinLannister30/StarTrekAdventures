using StarTrekAdventures.Models;

namespace StarTrekAdventures.Tests.Models;

public class CareerPathTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void GetName_MajorIsNullOrEmpty_ReturnsName(string major)
    {
        // Arrange
        var careerPath = new CareerPath
        {
            Name = "Name",
            Major = major
        };

        // Act
        var name = careerPath.GetName();

        // Assert
        Assert.Equal(careerPath.Name, name);
    }

    [Fact]
    public void GetName_MajorHasValue_ReturnsCorrectName()
    {
        // Arrange
        var careerPath = new CareerPath
        {
            Name = "Name",
            Major = "Major"
        };

        // Act
        var name = careerPath.GetName();

        // Assert
        Assert.Equal("Name - Major", name);
    }
}
