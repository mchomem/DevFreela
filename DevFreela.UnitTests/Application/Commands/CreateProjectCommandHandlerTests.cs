namespace DevFreela.UnitTests.Application.Commands;

public class CreateProjectCommandHandlerTests
{
    [Fact]
    public async Task InputDataIsOk_Executed_ReturnProjectId()
    {
        // Arrange
        var projectRepositoryMock = new Mock<IProjectRepository>();

        var createProjectCommand = new CreateProjectCommand
        {
            Title = "Título de teste",
            Description = "Descrição de teste",
            IdClient = 1,
            IdFreelancer = 2,
            TotalCost = 5000
        };

        var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMock.Object);

        // Act
        var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

        // Assert
        Assert.True(id >= 0);

        projectRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Project>()), Times.Once);
    }
}
