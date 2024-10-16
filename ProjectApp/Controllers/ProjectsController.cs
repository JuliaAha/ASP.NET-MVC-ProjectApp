using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Core.Interfaces.Interfaces;
using ProjectApp.Core;
using ProjectApp.Models.Projects;

namespace ProjectApp.Controllers
{
    public class ProjectsController : Controller
    {
        private IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: ProjectsController
        public ActionResult Index()
        {
            List<Project> projects = _projectService.GetAllByUserName("julg@kth.se");
            List<ProjectVm> projectVms = new List<ProjectVm>();
            foreach (var project in projects)
            {
                projectVms.Add(ProjectVm.FromProject(project));
            }

            return View(projectVms);
        }

        // GET: ProjectsController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Project project = _projectService.GetById(id, "julg@kth.se"); //current user
                if (project == null) return BadRequest(); //HTTP 400

                ProjectDetailsVm detailsVm = ProjectDetailsVm.FromProject(project);
                return View(detailsVm);
            }
            catch (DataException ex)
            {
                return BadRequest();
            }
        }

        // GET: ProjectsController/Create anropas när användaren vill se formulären
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProjectVm createProjectVm) //skickas tillbaka till servern via denna metod
        {
            try
            {
                if (ModelState.IsValid) //ett objekt som tagit emot data från klienten via jquery
                {
                    string title = createProjectVm.Title;
                    string userName = "julg@kth.se"; //dummy user

                    _projectService.Add(userName, title);
                    return RedirectToAction("Index");
                }

                return View(createProjectVm);
            }
            catch (DataException ex) //TODO: should probably be more specific
            {
                return View(createProjectVm);
            }
        }
        /*

        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }*/
    }
}
