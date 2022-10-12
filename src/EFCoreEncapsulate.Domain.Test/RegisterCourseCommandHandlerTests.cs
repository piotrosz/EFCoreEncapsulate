using AutoFixture;
using FluentAssertions;
using Moq;
using Xunit;

namespace EFCoreEncapsulate.Domain.Test;

public class RegisterCourseCommandHandlerTests
{
    private readonly IFixture _fixture = new Fixture();
    
    [Fact]
    public async Task WhenCourseAlreadyExists_ThenError()
    {
        var courseName = _fixture.Create<string>();
        var courseRepository = new Mock<ICourseRepository>();
        courseRepository
            .Setup(x => x.CourseExists(courseName))
            .ReturnsAsync(true);
        
        var handler = new RegisterCourseCommandHandler(courseRepository.Object);

        var result = await handler.HandleAsync(new RegisterCourseCommand(courseName));

        result.IsFailure.Should().BeTrue();
    }
}