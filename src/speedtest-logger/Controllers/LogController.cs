using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using speedtest_logger.Models;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace speedtest_logger.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public string Index()
        {
            return "Please post valid values";
        }

        [HttpPost()]
        public string Index(TestResultModel res)
        {
            bool validData = validatePost(ref res);
            if (validData)
            {
                speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
                repo.create(res.databaseObject);
            }   

            return "ok";// Don't reveal if validation was a success
        }

        private bool validatePost(ref TestResultModel res)
        {
            StringBuilder hashCheck = new StringBuilder();
            hashCheck.Append(res.ping);
            hashCheck.Append("-");
            hashCheck.Append(res.upload);
            hashCheck.Append("-");
            hashCheck.Append(res.download);
            hashCheck.Append("-");
            hashCheck.Append(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.postPassword"].ConnectionString);
            bool validation= false;
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, hashCheck.ToString());
                if (hash == res.hash) validation = true;
            }
            return validation;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        // GET: Log/Details/5


        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Log/Create
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

        // GET: Log/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Log/Edit/5
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

        // GET: Log/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Log/Delete/5
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
