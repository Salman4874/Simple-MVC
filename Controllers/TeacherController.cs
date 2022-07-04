using Microsoft.AspNetCore.Mvc;
using SchoolPortal.Date;
using SchoolPortal.Models;

namespace SchoolPortal.Controllers
{
    public class TeacherController : Controller
    {
        public readonly ApplicationDbContext _Te;

        public TeacherController(ApplicationDbContext Te)
        {
            _Te = Te;
        }
        public IActionResult Index()
        {
            IEnumerable<Teacher> objTeacherData = _Te.Teacher_Data;
            return View(objTeacherData);
        }

        public IActionResult Add()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Teacher obj)
        {
            if (obj.firstName==obj.lastName)
            if (obj.firstName==obj.lastName)
            {
                ModelState.AddModelError("lastname", "First name and last name can not be exact same");
            }
            if (ModelState.IsValid)
            {
                _Te.Teacher_Data.Add(obj);
                _Te.SaveChanges();
                TempData["Success"] = "Created Successfully";
                return RedirectToAction("Index");

            }
            return View(obj);
            
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var teacherFromDB = _Te.Teacher_Data.Find(id);
            if (teacherFromDB == null)
            {
                return NotFound();
            }
            return View(teacherFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher obj)
        {
            if (obj.firstName == obj.lastName)
                if (obj.firstName == obj.lastName)
                {
                    ModelState.AddModelError("lastname", "First name and last name can not be exact same");
                }
            if (ModelState.IsValid)
            {
                _Te.Teacher_Data.Update(obj);
                _Te.SaveChanges();
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
            var teacherFromDB = _Te.Teacher_Data.Find(id);
            if (teacherFromDB == null)
            {
                return NotFound();
            }
            return View(teacherFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _Te.Teacher_Data.Find(id);
            if(id==null || id == 0)
            {
                return NotFound();
            }
                _Te.Teacher_Data.Remove(obj);
                _Te.SaveChanges();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("Index");
            return View(obj);
           

        }

    }
}
