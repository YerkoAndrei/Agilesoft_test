// Por Yerko Orellana Abello para prueba en Agilesoft

using Agilesoft_test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Agilesoft_test.Models.Task;

namespace Agilesoft_test.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        // Context BD MySQL
        private agilesoft_testContext context;
        public TaskController(agilesoft_testContext _context)
        {
            context = _context;
        }

        // TODAS LAS TAREAS
        // GET api/task/all
        [HttpGet("all")]
        public IEnumerable<Task> Get()
        {
            return context.Task;
        }

        // TAREAS POR USUARIO
        // GET api/task/user/id
        [HttpGet("user/{id}")]
        public IEnumerable<Task> Get(int id)
        {
            return context.Task.Where(t => t.IdUser == id);
        }

        // REGISTRAR NUEVA TAREA
        // POST api/task/register
        [HttpPost("register")]
        public ActionResult<Task> Post(Task task)
        {
            context.Task.Add(task);
            context.SaveChanges();;
            return task;
        }

        // MODIFICAR ESTADO DE TAREA
        // PUT api/task/id/bool
        [HttpPut("{id}/{status}")]
        public Task Put(int id, bool status)
        {
            Task task = context.Task.Find(id);
            task.Completed = status;

            context.Task.Update(task);
            context.SaveChanges();
            return task;
        }
    }
}
