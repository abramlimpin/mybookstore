using MyBookstoreMVC.App_Code;
using MyBookstoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookstoreMVC.Controllers
{
    public class TitlesController : Controller
    {
        // GET: Titles
        public ActionResult Index()
        {
            return View();
        }

        // GET: Titles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public List<Publisher> GetPublishers()
        {
            List<Publisher> list = new List<Publisher>();
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT pubID, pubName
                    FROM publishers
                    ORDER BY pubName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        while (data.Read())
                        {
                            Publisher publisher = new Publisher();
                            publisher.PubID = Convert.ToInt32(data["pubID"].ToString());
                            publisher.Name = data["pubName"].ToString();
                            list.Add(publisher);

                        }
                    }
                }
            }
            return list;
        }

        // GET: Titles/Create
        public ActionResult Create()
        {
            ViewBag.publishers = 
            return View();
        }

        // POST: Titles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Titles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Titles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Titles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Titles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
