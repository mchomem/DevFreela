namespace DevFreela.UnitTests.Application.Queries;

public class GetAllProjectsQueryHandlerTest
{
    [Fact]
    // Nome de método deve obedecer o padrão Given When Then
    public async Task ThreeProjectsExists_Executed_ReturnThreeProjectViewModels()
    {
        // Arrange (representando dados na base de dados)
        var projects = new List<Project>
        {
            new Project("Nome do Teste 1", "Descrição do teste 1", 1, 2, 10000),
            new Project("Nome do Teste 2", "Descrição do teste 2", 1, 2, 10000),
            new Project("Nome do Teste 3", "Descrição do teste 3", 1, 2, 10000),
        };

        var projectRepositoryMock = new Mock<IProjectRepository>();
        projectRepositoryMock.Setup(x => x.GetAllAsync().Result).Returns(projects);

        var getAllProjectsQuery = new GetAllProjectQuery("");
        var getAllProjectsQueryHandler = new GetAllProjectQueryHandler(projectRepositoryMock.Object);

        // Act
        var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

        // Assert
        Assert.NotNull(projectViewModelList);
        Assert.NotEmpty(projectViewModelList);
        Assert.Equal(projects.Count, projectViewModelList.Count);

        // Validar se o  método GetAllAsync foi chamado pelo menos uma vez.
        projectRepositoryMock.Verify(x => x.GetAllAsync().Result, Times.Once);
    }
}
