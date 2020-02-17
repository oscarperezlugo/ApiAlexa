using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApiAlexa.Models;

namespace ApiAlexa.Controllers
{
    public class AlmacenesController : ApiController
    {
        private REMEXEntities12 db = new REMEXEntities12();

        // GET: api/Almacenes
        public IQueryable<Almacene> GetAlmacenes()
        {
            return db.Almacenes;
        }

        // GET: api/Almacenes/5
        [ResponseType(typeof(Almacene))]
        public async Task<IHttpActionResult> GetAlmacene(short id)
        {
            Almacene almacene = await db.Almacenes.FindAsync(id);
            if (almacene == null)
            {
                return NotFound();
            }

            return Ok(almacene);
        }

        // PUT: api/Almacenes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlmacene(short id, Almacene almacene)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != almacene.CodigoEmpresa)
            {
                return BadRequest();
            }

            db.Entry(almacene).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmaceneExists(id))
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

        // POST: api/Almacenes
        [ResponseType(typeof(Almacene))]
        public async Task<IHttpActionResult> PostAlmacene(Almacene almacene)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Almacenes.Add(almacene);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlmaceneExists(almacene.CodigoEmpresa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = almacene.CodigoEmpresa }, almacene);
        }

        // DELETE: api/Almacenes/5
        [ResponseType(typeof(Almacene))]
        public async Task<IHttpActionResult> DeleteAlmacene(short id)
        {
            Almacene almacene = await db.Almacenes.FindAsync(id);
            if (almacene == null)
            {
                return NotFound();
            }

            db.Almacenes.Remove(almacene);
            await db.SaveChangesAsync();

            return Ok(almacene);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlmaceneExists(short id)
        {
            return db.Almacenes.Count(e => e.CodigoEmpresa == id) > 0;
        }
    }
}