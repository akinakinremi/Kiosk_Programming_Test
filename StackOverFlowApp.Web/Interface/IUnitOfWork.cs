using System.Collections.Generic;
using StackOverFlowApp.Web.Models;

namespace StackOverFlowApp.Web.Interface
{
    public interface IUnitOfWork
    {
        IEnumerable<Item> GetTopQuestions();
    }
}