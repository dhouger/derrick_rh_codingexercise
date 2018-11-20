using derrickcodingexercise.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace derrickcodingexercise.Controllers
{
    public class CodingExerciseController : Controller
    {
        // GET: CodingExercise/Square
        public ActionResult Square()
        {
            return View();
		}

		// GET: CodingExercise/Square
		public ActionResult Gender()
		{
			return View();
		}

		public string GetData()
		{
			var poll = new Poll();

			try
			{
				string file = Server.MapPath("~/App_Data/SimpleData.xml");
				DataSet ds = new DataSet();
				ds.ReadXml(file);

				int tempMale = 0;
				int tempFemale = 0;

				Int32.TryParse((string)ds.Tables[0].Rows[0][0], out tempMale);
				Int32.TryParse((string)ds.Tables[0].Rows[0][1], out tempFemale);

				poll.Male = tempMale;
				poll.Female = tempFemale;
			}
			catch (Exception)
			{

			}

			return JsonConvert.SerializeObject(poll); 
		}

		// Checking to make sure each request only allows increments of 1
		public string SaveData(int male, int female)
		{
			var poll = new Poll();

			poll.Male = male;
			poll.Female = female;

			XmlSerializer xs = new XmlSerializer(typeof(Poll));
			TextWriter tw = new StreamWriter(Server.MapPath("~/App_Data/SimpleData.xml"));
			xs.Serialize(tw, poll);
			tw.Flush();
			tw.Close();

			return GetData();
		}

		// GET: CodingExercise/Details/5
		public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CodingExercise/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CodingExercise/Create
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

        // GET: CodingExercise/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CodingExercise/Edit/5
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

        // GET: CodingExercise/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CodingExercise/Delete/5
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
