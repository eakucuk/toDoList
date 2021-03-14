using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList2.Models;

namespace ToDoList2.ViewModels
{
    public class Jobs
    {
        public List<DoList> doList { get; set; }
        public DoList toDoJobs { get; set; }
    }
}