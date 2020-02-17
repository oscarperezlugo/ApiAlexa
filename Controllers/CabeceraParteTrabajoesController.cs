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
using ApiAlexa.Models;

namespace ApiAlexa.Controllers
{
    public class CabeceraParteTrabajoesController : ApiController
    {
        private REMEXEntities8 db = new REMEXEntities8();

        // GET: api/CabeceraParteTrabajoes
        public IQueryable<CabeceraParteTrabajo> GetCabeceraParteTrabajoes()
        {
            return db.CabeceraParteTrabajoes;
        }

        // GET: api/CabeceraParteTrabajoes/5
        [ResponseType(typeof(CabeceraParteTrabajo))]
        public IHttpActionResult GetCabeceraParteTrabajo(short id)
        {
            CabeceraParteTrabajo cabeceraParteTrabajo = db.CabeceraParteTrabajoes.Find(id);
            if (cabeceraParteTrabajo == null)
            {
                return NotFound();
            }

            return Ok(cabeceraParteTrabajo);
        }

        // PUT: api/CabeceraParteTrabajoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCabeceraParteTrabajo(short id, CabeceraParteTrabajo cabeceraParteTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cabeceraParteTrabajo.CodigoEmpresa)
            {
                return BadRequest();
            }

            db.Entry(cabeceraParteTrabajo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabeceraParteTrabajoExists(id))
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

        // POST: api/CabeceraParteTrabajoes
        [ResponseType(typeof(CabeceraParteTrabajo))]
        public IHttpActionResult PostCabeceraParteTrabajo(CabeceraParteTrabajo cabeceraParteTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CabeceraParteTrabajoes.Add(cabeceraParteTrabajo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CabeceraParteTrabajoExists(cabeceraParteTrabajo.CodigoEmpresa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cabeceraParteTrabajo.CodigoEmpresa }, cabeceraParteTrabajo);
        }

        // DELETE: api/CabeceraParteTrabajoes/5
        [ResponseType(typeof(CabeceraParteTrabajo))]
        public IHttpActionResult DeleteCabeceraParteTrabajo(short id)
        {
            CabeceraParteTrabajo cabeceraParteTrabajo = db.CabeceraParteTrabajoes.Find(id);
            if (cabeceraParteTrabajo == null)
            {
                return NotFound();
            }

            db.CabeceraParteTrabajoes.Remove(cabeceraParteTrabajo);
            db.SaveChanges();

            return Ok(cabeceraParteTrabajo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CabeceraParteTrabajoExists(short id)
        {
            return db.CabeceraParteTrabajoes.Count(e => e.CodigoEmpresa == id) > 0;
        }
    }
}