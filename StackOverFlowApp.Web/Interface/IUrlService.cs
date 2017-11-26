namespace StackOverFlowApp.Web.Interface
{
    public interface IUrlService
    {
        string GetMainUrl();

        string GetUrlByQuestion(string questionid);
    }
}
