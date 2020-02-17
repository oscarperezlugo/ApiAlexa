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
    public class LineasParteTrabajoesController : ApiController
    {
        private REMEXEntities10 db = new REMEXEntities10();

        // GET: api/LineasParteTrabajoes
        public IQueryable<LineasParteTrabajo> GetLineasParteTrabajoes()
        {
            return db.LineasParteTrabajoes;
        }

        // GET: api/LineasParteTrabajoes/5
        [ResponseType(typeof(LineasParteTrabajo))]
        public IHttpActionResult GetLineasParteTrabajo(short id)
        {
            LineasParteTrabajo lineasParteTrabajo = db.LineasParteTrabajoes.Find(id);
            if (lineasParteTrabajo == null)
            {
                return NotFound();
            }

            return Ok(lineasParteTrabajo);
        }

        // PUT: api/LineasParteTrabajoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLineasParteTrabajo(short id, LineasParteTrabajo lineasParteTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineasParteTrabajo.CodigoEmpresa)
            {
                return BadRequest();
            }

            db.Entry(lineasParteTrabajo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineasParteTrabajoExists(id))
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

        // POST: api/LineasParteTrabajoes
        [ResponseType(typeof(LineasParteTrabajo))]
        public IHttpActionResult PostLineasParteTrabajo(LineasParteTrabajo lineasParteTrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LineasParteTrabajoes.Add(lineasParteTrabajo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LineasParteTrabajoExists(lineasParteTrabajo.CodigoEmpresa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lineasParteTrabajo.CodigoEmpresa }, lineasParteTrabajo);
        }

        // DELETE: api/LineasParteTrabajoes/5
        [ResponseType(typeof(LineasParteTrabajo))]
        public IHttpActionResult DeleteLineasParteTrabajo(short id)
        {
            LineasParteTrabajo lineasParteTrabajo = db.LineasParteTrabajoes.Find(id);
            if (lineasParteTrabajo == null)
            {
                return NotFound();
            }

            db.LineasParteTrabajoes.Remove(lineasParteTrabajo);
            db.SaveChanges();

            return Ok(lineasParteTrabajo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineasParteTrabajoExists(short id)
        {
            return db.LineasParteTrabajoes.Count(e => e.CodigoEmpresa == id) > 0;
        }
    }
}