using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_api.Models;
using todo_api.Data;
using Microsoft.EntityFrameworkCore;

namespace todo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ApiContext _context;
        public TodoItemController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost("/create")]
        public JsonResult Create([FromBody] TodoItem item)
        {
            var itemInDb = _context.TodoItems.Find(item.Id);

            if (itemInDb != null)
            {
                return new JsonResult(BadRequest("Item already exists."));
            }


            item.CreatedAt = DateTime.Now;
            item.UpdatedAt = DateTime.Now;
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            return new JsonResult(new
            {
                data = item,
            });

        }
        [HttpPost("/edit")]
        public JsonResult Edit([FromBody] TodoItem item)
        {
            var itemInDb = _context.TodoItems.Find(item.Id);

            if (itemInDb == null)
            {
                return new JsonResult(BadRequest("Item doesn't exist."));
            }
            itemInDb.UpdatedAt = DateTime.Now;
            itemInDb.Completed = !item.Completed;
            _context.TodoItems.Update(itemInDb);
            _context.SaveChanges();
            return new JsonResult(new
            {
                data = itemInDb,
            });

        }
        [HttpGet("/get")]   
        public JsonResult Get(int id) 
        {
            var result = _context.TodoItems.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(new
            {
                data = result,
            });
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.TodoItems.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.TodoItems.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());

        }

        [HttpGet("/getAll")]
        public JsonResult GetAll(int perPage=-1, int page=-1)
        {
            int totalItems = _context.TodoItems.Count();
            int totalPages = (int)Math.Ceiling((decimal)totalItems / perPage);
            if (perPage ==-1 && page==-1)
            {
                var allItems = _context.TodoItems.ToList();
                return new JsonResult(new
                {
                    TodoItems = allItems,
                });
            }
                var result = _context.TodoItems
                    .Skip((page - 1) * perPage)
                    .Take(perPage)
                    .ToList();

                return new JsonResult(new
                {
                    TotalPages = totalPages,
                    TodoItems = result
                });

        }
    }
}
