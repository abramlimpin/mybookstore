using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;
using MyBookstoreMVC.App_Code;
using MyBookstoreMVC.Models;

namespace MyBookstoreMVC.Controllers
{
    public class AuthorsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Author> list = new List<Author>();

            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT authorID, authorLN, authorFN, authorPhone,
                    authorAddress, authorCity, authorState, authorZip
                    FROM authors";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                var author = new Author();
                                author.ID = int.Parse(row["authorID"].ToString());
                                author.LastName = row["authorLN"].ToString();
                                author.FirstName = row["authorFN"].ToString();
                                author.Phone = row["authorPhone"].ToString();
                                author.Address = row["authorAddress"].ToString();
                                author.City = row["authorCity"].ToString();
                                author.State = row["authorState"].ToString();
                                author.Zip = row["authorZip"].ToString();
                                list.Add(author);
                            }
                        }
                    }
                }
            }
            return View(list);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Helper.GetCon()))
                {
                    con.Open();
                    string query = @"INSERT INTO Authors VALUES
                        (@authorLN, @authorFN, @authorPhone,
                        @authorAddress, @authorCity, @authorState,
                        @authorZip)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@authorLN", author.LastName);
                        cmd.Parameters.AddWithValue("@authorFN", author.FirstName);
                        cmd.Parameters.AddWithValue("@authorPhone", author.Phone);
                        cmd.Parameters.AddWithValue("@authorAddress", author.Address);
                        cmd.Parameters.AddWithValue("@authorCity", author.City);
                        cmd.Parameters.AddWithValue("@authorState", author.State);
                        cmd.Parameters.AddWithValue("@authorZip", author.Zip);
                        cmd.ExecuteNonQuery();
                    }
                        return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Authors");
            }
            
            Author author = new Author();

            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT authorID, authorLN, authorFN,
                    authorPhone, authorAddress, authorCity,
                    authorState, authorZip
                    FROM authors 
                    WHERE authorID=@authorID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@authorID", id);
                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        if (data.HasRows)
                        {
                            while (data.Read())
                            {
                                author.LastName = data["authorLN"].ToString();
                                author.FirstName = data["authorFN"].ToString();
                                author.Phone = data["authorPhone"].ToString();
                                author.Address = data["authorAddress"].ToString();
                                author.City = data["authorCity"].ToString();
                                author.State = data["authorState"].ToString();
                                author.Zip = data["authorZip"].ToString();
                            }
                            return View(author);
                        }
                        else
                            return RedirectToAction("Index");
                    }
                }
            }
        }

        // POST: Authors/Edit/5
        [HttpPost]
        public ActionResult Edit(Author author)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Helper.GetCon()))
                {
                    con.Open();
                    string query = @"UPDATE Authors SET
                        authorLN=@authorLN, authorFN=@authorFN, authorPhone=@authorPhone,
                        authorAddress=@authorAddress, authorCity=@authorCity, authorCity=@authorState,
                        authorZip=@authorZip)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@authorLN", author.LastName);
                        cmd.Parameters.AddWithValue("@authorFN", author.FirstName);
                        cmd.Parameters.AddWithValue("@authorPhone", author.Phone);
                        cmd.Parameters.AddWithValue("@authorAddress", author.Address);
                        cmd.Parameters.AddWithValue("@authorCity", author.City);
                        cmd.Parameters.AddWithValue("@authorState", author.State);
                        cmd.Parameters.AddWithValue("@authorZip", author.Zip);
                        cmd.Parameters.AddWithValue("@authorID", author.ID);
                        cmd.ExecuteNonQuery();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"DELETE FROM Authors WHERE authorID=@authorID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@authorID", id);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
            }
        }

        // POST: Authors/Delete/5
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
