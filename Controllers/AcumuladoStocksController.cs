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
    public class AcumuladoStocksController : ApiController
    {
        private REMEXEntities11 db = new REMEXEntities11();

        // GET: api/AcumuladoStocks
        public IQueryable<AcumuladoStock> GetAcumuladoStocks()
        {
            return db.AcumuladoStocks;
        }

        // GET: api/AcumuladoStocks/5
        [ResponseType(typeof(AcumuladoStock))]
        public IHttpActionResult GetAcumuladoStock(short id)
        {
            AcumuladoStock acumuladoStock = db.AcumuladoStocks.Find(id);
            if (acumuladoStock == null)
            {
                return NotFound();
            }

            return Ok(acumuladoStock);
        }

        // PUT: api/AcumuladoStocks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAcumuladoStock(short id, AcumuladoStock acumuladoStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acumuladoStock.CodigoEmpresa)
            {
                return BadRequest();
            }

            db.Entry(acumuladoStock).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcumuladoStockExists(id))
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

        // POST: api/AcumuladoStocks
        [ResponseType(typeof(AcumuladoStock))]
        public IHttpActionResult PostAcumuladoStock(AcumuladoStock acumuladoStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AcumuladoStocks.Add(acumuladoStock);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AcumuladoStockExists(acumuladoStock.CodigoEmpresa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = acumuladoStock.CodigoEmpresa }, acumuladoStock);
        }

        // DELETE: api/AcumuladoStocks/5
        [ResponseType(typeof(AcumuladoStock))]
        public IHttpActionResult DeleteAcumuladoStock(short id)
        {
            AcumuladoStock acumuladoStock = db.AcumuladoStocks.Find(id);
            if (acumuladoStock == null)
            {
                return NotFound();
            }

            db.AcumuladoStocks.Remove(acumuladoStock);
            db.SaveChanges();

            return Ok(acumuladoStock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AcumuladoStockExists(short id)
        {
            return db.AcumuladoStocks.Count(e => e.CodigoEmpresa == id) > 0;
        }
    }
}