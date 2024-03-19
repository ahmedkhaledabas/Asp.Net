using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;

namespace ToDoList.Controllers
{
    public class ListItemController : Controller
    {
        ToDoListDbContext context = new ToDoListDbContext();
        public IActionResult Index(string name)
        {
            //CookieOptions cookieOptions = new CookieOptions();
            //cookieOptions.Expires = DateTimeOffset.Now.AddDays(1);
            //Response.Cookies.Append("name", name , cookieOptions);
            //ViewData["name"] = Request.Cookies["name"];
            ViewData["name"] = name;
            return View(context.listItems.ToList());
        }

        public IActionResult CreateNew()
        {
            return View();
        }

        public IActionResult CreateNewList()
        {
            return View();
        }


        public IActionResult SaveList(string title , string description , DateTime deadLine)
        {
            context.listItems.Add(new()
            {
                Title = title,
                Description = description,
                DeadLine = deadLine
            });
            context.SaveChanges();
            return View("Index", context.listItems.ToList());
        }

        public IActionResult Edit(int id)
        {
            var item = context.listItems.First(i=>i.Id == id);
            return View(item);
        }

        public IActionResult SaveEdit(int id , string title, string description, DateTime deadLine)
        {
            var item = context.listItems.First(i => i.Id == id);
            item.Title = title;
            item.Description = description;
            item.DeadLine = deadLine;
            context.SaveChanges();
            return View("Index", context.listItems.ToList());
        }

        public IActionResult Delete(int id)
        {
            var item = context.listItems.First(i => i.Id == id);
            context.listItems.Remove(item);
            context.SaveChanges();
            return View("Index", context.listItems.ToList());
        }

    }
}
