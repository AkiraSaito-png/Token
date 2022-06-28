using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sebsa.Controllers
{
    public class ValidationLoginController : Controller
    {
        // GET: ValidationLoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ValidationLoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ValidationLoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValidationLoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ValidationLoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ValidationLoginController/Edit/5
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

        // GET: ValidationLoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ValidationLoginController/Delete/5
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
    }
}
