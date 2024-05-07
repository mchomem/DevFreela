namespace DevFreela.Core.Exceptions
{
    public class ProjectAlreadyStartException : Exception
    {
        public ProjectAlreadyStartException(): base("Project is already in Started status")
        {
            
        }
    }
}
