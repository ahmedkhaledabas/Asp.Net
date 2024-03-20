using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ListItemController : Controller
    {
        ToDoListDbContext context = new ToDoListDbContext();
        public IActionResult Index()
        {
            
            return View(context.listItems.ToList());
        }

        public IActionResult SaveName(string name)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(1);
            Response.Cookies.Append("name", name, cookieOptions);
            TempData["name"] = Request.Cookies["name"];
            return RedirectToAction("Index");
        }

        public IActionResult CreateNew()
        {
            return View();
        }

        public IActionResult CreateNewList()
        {
            return View();
        }


        public IActionResult SaveList(ListItem listItem)
        {
            context.listItems.Add(new()
            {
                Title = listItem.Title,
                Description = listItem.Description,
                DeadLine = listItem.DeadLine
            });
            context.SaveChanges();
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = context.listItems.First(i => i.Id == id);
            context.listItems.Remove(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
