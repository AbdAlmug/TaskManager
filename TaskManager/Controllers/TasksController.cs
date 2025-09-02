using Microsoft.AspNetCore.Mvc;
using TaskManager.DataAccess.Repository.IRepository;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TasksController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public TasksController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        // GET: Tasks
        public IActionResult Index()
        {
            List<Tasks> objTasksList = _unitOfWork.Tasks.GetAll().ToList();
            return View(objTasksList);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create(Tasks obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tasks.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Task created successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Tasks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Tasks? tasksFromDb = _unitOfWork.Tasks.Get(u => u.TaskId == id);

            if (tasksFromDb == null)
            {
                return NotFound();
            }
            return View(tasksFromDb);
        }
        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(Tasks obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tasks.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Task updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        // GET: Tasks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Tasks? tasksFromDb = _unitOfWork.Tasks.Get(u => u.TaskId == id);

            if (tasksFromDb == null)
            {
                return NotFound();
            }

            return View(tasksFromDb);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Tasks? obj = _unitOfWork.Tasks.Get(u => u.TaskId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Tasks.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Task deleted successfully!";
            return RedirectToAction("Index");
        }

    }
}
