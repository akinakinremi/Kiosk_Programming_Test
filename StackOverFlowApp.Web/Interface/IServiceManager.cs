using System.Collections.Generic;
using StackOverFlowApp.Web.Models;

namespace StackOverFlowApp.Web.Interface
{
    public interface IServiceManager
    {
        Item GetQuestionById(string questionId);
        IEnumerable<Item> GetTopQuestions();
    }
}
