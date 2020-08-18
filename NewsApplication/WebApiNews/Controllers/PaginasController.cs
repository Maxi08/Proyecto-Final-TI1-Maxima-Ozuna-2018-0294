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
using WebApiNews.Models;

namespace WebApiNews.Controllers
{
    public class PaginasController : ApiController
    {
        private WebApiNewsDbContext db = new WebApiNewsDbContext();

        // GET: api/Paginas
        public IQueryable<Pagina> GetPaginas()
        {
            return db.Paginas;
        }

        // GET: api/Paginas/5
        [ResponseType(typeof(Pagina))]
        public IHttpActionResult GetPagina(int id)
        {
            Pagina pagina = db.Paginas.Find(id);
            if (pagina == null)
            {
                return NotFound();
            }

            return Ok(pagina);
        }

        // PUT: api/Paginas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPagina(int id, Pagina pagina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pagina.idPage)
            {
                return BadRequest();
            }

            db.Entry(pagina).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaginaExists(id))
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

        // POST: api/Paginas
        [ResponseType(typeof(Pagina))]
        public IHttpActionResult PostPagina(Pagina pagina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paginas.Add(pagina);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pagina.idPage }, pagina);
        }

        // DELETE: api/Paginas/5
        [ResponseType(typeof(Pagina))]
        public IHttpActionResult DeletePagina(int id)
        {
            Pagina pagina = db.Paginas.Find(id);
            if (pagina == null)
            {
                return NotFound();
            }

            db.Paginas.Remove(pagina);
            db.SaveChanges();

            return Ok(pagina);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaginaExists(int id)
        {
            return db.Paginas.Count(e => e.idPage == id) > 0;
        }
    }
}