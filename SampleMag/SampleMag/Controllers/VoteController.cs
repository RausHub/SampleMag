using Newtonsoft.Json;
using SampleMag.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMag.Controllers
{
    public class VoteController : Controller
    {
        // GET: Vote
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Vote/Details/5
        public ActionResult Details(int id)
        {
            var vote = UserService.GetUser(id);
            if (vote == null)
            {
                return null;
            }
            var temp = JsonConvert.SerializeObject(vote, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Json(vote, JsonRequestBehavior.AllowGet);
        }

        // GET: vote/votes
        public ActionResult Votes()
        {
            var votes = UserService.GetAll();
            if (votes == null)
            {
                return null;
            }
            return Json(votes, JsonRequestBehavior.AllowGet);
        }

        // GET: Vote/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Vote/Create
        [HttpPost]
        public ActionResult Create(Vote vote)
        {
            try
            {
                VoteService.Create(vote);
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }

        // GET: Vote/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Vote/Edit/5
        [HttpPost]
        public ActionResult Edit(Vote v)
        {
            try
            {
                VoteService.Update(v);
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }

        // GET: Vote/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Vote/Delete/5
        [HttpPost]
        public ActionResult Delete(Vote v)
        {
            try
            {
                VoteService.Delete(v);
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }
    }
}
