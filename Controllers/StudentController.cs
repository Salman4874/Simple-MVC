using Microsoft.AspNetCore.Mvc;
using SchoolPortal.Date;
using SchoolPortal.Models;

namespace SchoolPortal.Controllers
{
    public class StudentController : Controller
    {
        public readonly ApplicationDbContext _St;
        
        public StudentController(ApplicationDbContext St)
        {
            _St = St;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> objStudentData = _St.Student_Data;
            return View(objStudentData);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Student obj)
        {
            if (obj.firstName == obj.lastName)
            {
                ModelState.AddModelError("lastName", "First name and last name can not be exactly same");
            }
            if (ModelState.IsValid)
            {
                _St.Student_Data.Add(obj);
                _St.SaveChanges();
                TempData["Success"] = "Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id ==0)
            {
                return NotFound();
            }
            var studentFromDB = _St.Student_Data.Find(id);
            if (studentFromDB == null)
            {
                return NotFound();
            }
            return View(studentFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (obj.firstName == obj.lastName)
            {
                ModelState.AddModelError("lastName", "First name and last name can not be exactly same");
            }
            if (ModelState.IsValid)
            {
                _St.Student_Data.Update(obj);
                _St.SaveChanges();
                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var StudentFromDB = _St.Student_Data.Find(id);
            if (StudentFromDB == null)
            {
                return NotFound();
            }
            return View(StudentFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _St.Student_Data.Find(id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            _St.Student_Data.Remove(obj);
            _St.SaveChanges();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("Index");
            return View(obj);


        }
    }
}
