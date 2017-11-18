using System;
using System.Collections.Generic;
using StackOverFlowApp.Web.Interface;
using StackOverFlowApp.Web.Models;

namespace StackOverFlowApp.Web.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServiceDirector _context;
        public UnitOfWork(ServiceDirector context)
        {
            _context = context;
        }
        public IEnumerable<Item> GetTopQuestions()
        {
            _context.Construct();
            return _context.GetQuestions();
        }
    }
}