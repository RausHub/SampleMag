using Newtonsoft.Json;
using SampleMag.Service;
using System.Web.Mvc;

namespace SampleMag.Controllers
{
    public class UserController : Controller
    {
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            //hier data effectief gaan ophalen
            var user = UserService.GetUser(id);
            if (user == null)
            {
                return null;
            }
            var temp = JsonConvert.SerializeObject(user, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        // GET: User/Users
        public ActionResult Users()
        {
            var users = UserService.GetAll();
            if (users == null)
            {
                return null;
            }
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        // GET: User/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User u)
        {
            try
            {
                UserService.Create(u);
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }

        // GET: User/Edit/5
        ////public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User u)
        {
            try
            {
                UserService.Update(u);
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }

        // GET: User/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(User u)
        {
            try
            {
                UserService.Delete(u);
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }
    }
}
