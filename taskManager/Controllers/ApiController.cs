using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using taskManager.Models;

namespace taskManager.Controllers
{
    public class ApiController : Controller
    {
        private DataContext DbContext;

        public ApiController(DataContext db)
        {
            this.DbContext = db;
        }


        [HttpGet]
        public IActionResult Test()
        {
            var list = new List<string>();
            return Json(list);
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = DbContext.Tasks.Where(t => t.Id < 90).OrderBy.ToList();
            return Json(tasks);
        }

        [HttpGet]

        public IActionResult ClearTasks()
        {
            //removeList (getAll)
            DbContext.Tasks.RemoveRange(DbContext.tasks.ToList());
            DbContext.SaveChanges();
            return Content("Tasks removed");
        }

        [HttpGet]

        public IActionResult RemoveTask(int id)
        {
            var task = DbContext.Tasks.Find(id);
        }

        [HttpPost]
        public IActionResult SaveTask([FromBody] Task theTask)
        {

            // sanitize the user input before storing in DB 
            // sanitiza user input MVC C#

            System.Console.WriteLine("Saving an object: " + theTask.Title);
            
            //save object into db
            DbContext.Tasks.Add(theTask);
            DbContext.SaveChanges();
            //adding a comment

            return Json(theTask);
        }

    }
}