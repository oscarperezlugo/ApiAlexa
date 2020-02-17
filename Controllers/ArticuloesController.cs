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
    public class ArticuloesController : ApiController
    {
        private REMEXEntities9 db = new REMEXEntities9();

        // GET: api/Articuloes
        public IQueryable<Articulo> GetArticulos()
        {
            return db.Articulos;
        }

        // GET: api/Articuloes/5
        [ResponseType(typeof(Articulo))]
        public IHttpActionResult GetArticulo(short id)
        {
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(articulo);
        }

        // PUT: api/Articuloes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticulo(short id, Articulo articulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articulo.CodigoEmpresa)
            {
                return BadRequest();
            }

            db.Entry(articulo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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

        // POST: api/Articuloes
        [ResponseType(typeof(Articulo))]
        public IHttpActionResult PostArticulo(Articulo articulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Articulos.Add(articulo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ArticuloExists(articulo.CodigoEmpresa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = articulo.CodigoEmpresa }, articulo);
        }

        // DELETE: api/Articuloes/5
        [ResponseType(typeof(Articulo))]
        public IHttpActionResult DeleteArticulo(short id)
        {
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return NotFound();
            }

            db.Articulos.Remove(articulo);
            db.SaveChanges();

            return Ok(articulo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticuloExists(short id)
        {
            return db.Articulos.Count(e => e.CodigoEmpresa == id) > 0;
        }
    }
}