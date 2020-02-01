using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;
using System.Diagnostics;

namespace PetGrooming.Controllers
{
    
    public class SpeciesController : Controller
    {
        private PetGroomingContext db = new PetGroomingContext();
        
        // GET: Species
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]

       
        public ActionResult Add(string SpeciesName)
        {

            Debug.WriteLine("grabbing the species: "+ SpeciesName);
            string query = "insert into species (SpeciesName) values (@SpeciesName)";
            SqlParameter sqlparam = new SqlParameter("@SpeciesName", SpeciesName);
            db.Database.ExecuteSqlCommand(query, sqlparam);
            return RedirectToAction("List");
        }

        //TODO: Each line should be a separate method in this class
        // List
        public ActionResult List()
        {
            //How could we modify this to include a search bar?
            var species = db.Species.SqlQuery("Select * from Species").ToList();
            return View(species);
        }
        // Show
        public ActionResult Show(int id)
        {
            string query = "select * from species where speciesid = @id";
            SqlParameter sqlparam = new SqlParameter("@id",id);
            Species selectedspecies = db.Species.SqlQuery(query,sqlparam).FirstOrDefault();
            return View(selectedspecies);
        }
        // Add
        // [HttpPost] Add
        // Update
        public ActionResult Update(int id)
        {
           Species selectedspecies = db.Species.SqlQuery("select * from species where speciesid = @id", new SqlParameter("@id", id)).FirstOrDefault();
            
            return View(selectedspecies);
        }
        // [HttpPost] Update
        [HttpPost]
        public ActionResult Update(int id,string SpeciesName)
        {
            string query = "Update Species set speciesname = @SpeciesName where SpeciesId = @SpeciesId";
            SqlParameter[] sqlparams = new SqlParameter[2]; 

            sqlparams[0] = new SqlParameter("@SpeciesName", SpeciesName);
            sqlparams[1] = new SqlParameter("@SpeciesId", id);

            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }
        // (optional) delete
        public ActionResult Delete(int id)
        {
            string query = "delete from Species where speciesid = @SpeciesID";

            SqlParameter[] sqlparams = new SqlParameter[1];

            sqlparams[0] = new SqlParameter("@SpeciesID", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }
        // [HttpPost] Delete
    }
}