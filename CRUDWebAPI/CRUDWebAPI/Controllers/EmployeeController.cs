using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRUDWebAPI.Models;

namespace CRUDWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: api/Employee
        public IQueryable<PersonalDetail> GetPersonalDetails()
        {
            return db.PersonalDetails;
        }

        // GET: api/Employee/5
        [ResponseType(typeof(PersonalDetail))]
        public IHttpActionResult GetPersonalDetail(decimal id)
        {
            PersonalDetail personalDetail = db.PersonalDetails.Find(id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            return Ok(personalDetail);
        }

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonalDetail(decimal id, PersonalDetail personalDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalDetail.Employee_ID)
            {
                return BadRequest();
            }

            db.Entry(personalDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employee
        [ResponseType(typeof(PersonalDetail))]
        public IHttpActionResult PostPersonalDetail(PersonalDetail personalDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonalDetails.Add(personalDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personalDetail.Employee_ID }, personalDetail);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(PersonalDetail))]
        public IHttpActionResult DeletePersonalDetail(decimal id)
        {
            PersonalDetail personalDetail = db.PersonalDetails.Find(id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            db.PersonalDetails.Remove(personalDetail);
            db.SaveChanges();

            return Ok(personalDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonalDetailExists(decimal id)
        {
            return db.PersonalDetails.Count(e => e.Employee_ID == id) > 0;
        }
    }
}