using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using StudentCatalogFresh.Abstract;
using StudentCatalogFresh.Repository;
using StudentCatalogFresh.ViewModels;

namespace StudentCatalogFresh.Models
{
    public class StudentsController : Controller
    {
        private IStudentRepository _studentRepository = new StudentRepository();
        private readonly ICompetencyHeaderRepository _competencyHeaderRepository;

        public StudentsController(IStudentRepository studentRepository, ICompetencyHeaderRepository competencyHeaderRepository)
        {
            _studentRepository = studentRepository;
            _competencyHeaderRepository = competencyHeaderRepository;
        }

        // GET: Students
/*
        public ActionResult Index()
        {
            IEnumerable<Student> students = _studentRepository.GetAll();

            return View(students);
        }
*/

        public ActionResult Index()
        {
            StudentIndexViewModel viewModel = new StudentIndexViewModel
            {
                Students = _studentRepository.All.ToList(),
                CompetencyHeaders = _competencyHeaderRepository.AllIncluding(comp => comp.Competencies).ToList()
            };

            return View(viewModel);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~");

                student.SaveImage(image, path, "/UserUploads/");
                _studentRepository.InsertOrUpdate(student);
                _studentRepository.Save();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student student = _studentRepository.Find(id);

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~");
                student.SaveImage(image, path, "/UserUploads/");
                _studentRepository.InsertOrUpdate(student);
                _studentRepository.Save();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _studentRepository.Delete(id);
            _studentRepository.Save();

            return RedirectToAction("Index");
        }
    }
}