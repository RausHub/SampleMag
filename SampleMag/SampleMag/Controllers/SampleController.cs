using System.Web.Mvc;
using SampleMag.Service;
using Newtonsoft.Json;

namespace SampleMag.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample/Details/5
        public ActionResult Details(int id)
        {
            //hier data effectief gaan ophalen
            var sample = SampleService.GetSample(id);
            if (sample == null)
            {
                return null;
            }
            var temp = JsonConvert.SerializeObject(sample, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Json(sample, JsonRequestBehavior.AllowGet);
        }

        // GET: Sample/Samples
        public ActionResult Samples()
        {
            var samples = SampleService.GetAll();
            if (samples == null)
            {
                return null;
            }
            return Json(samples, JsonRequestBehavior.AllowGet);
        }

        // GET: Sample/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Sample/Create
        [HttpPost]
        public ActionResult Create(Sample s)
        {
            try
            {
                SampleService.Create(s);
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }

        //// GET: Sample/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Sample/Edit/5
        [HttpPost]
        public ActionResult Edit(Sample s)
        {
            try
            {
                SampleService.Update(s);
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }

        // GET: Sample/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Sample/Delete/5
        [HttpPost]
        public ActionResult Delete(Sample s)
        {
            try
            {
                SampleService.Delete(s);
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }
    }
}
