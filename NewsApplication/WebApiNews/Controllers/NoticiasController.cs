using Microsoft.AspNet.Identity;
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
    public class NoticiasController : ApiController
    {
        private WebApiNewsDbContext db = new WebApiNewsDbContext();

        // GET: api/Noticias
        //  public IQueryable<Noticias> Getnoticias()
        //    {
        //      return db.noticias;
        //  }

        public IQueryable<Noticias> Getnoticias(int page=0)
        {
            int page_size = db.Paginas.FirstOrDefault().pageSize;
            return db.noticias.OrderBy(x=>x.idNoticia).Where(X => X.eliminado == false && X.idEstado==1)
                .Skip(page*page_size)
                .Take(page_size);
        }

        [Route("~/api/noticias/getAllnoticias")]
         public IQueryable<Noticias> Getnoticias()
           {
             return db.noticias.Where(X => X.eliminado == false && X.idEstado == 1);
         }

        
        [Route("~/api/noticias/getnoticiasByUser")]
      
       

        public IQueryable<Noticias> GetnoticiasByUser()
        {
            var userId = RequestContext.Principal.Identity.GetUserId();
            return db.noticias.Where(X => X.eliminado == false && X.idEstado == 1 && X.autor==userId);
        }


        // GET: api/Noticias/5
        [ResponseType(typeof(Noticias))]
        public IHttpActionResult GetNoticias(int id)
        {
            Noticias noticias = db.noticias.Find(id);
            if (noticias == null)
            {
                return NotFound();
            }

            return Ok(noticias);
        }

        // PUT: api/Noticias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNoticias(int id, Noticias noticias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != noticias.idNoticia)
            {
                return BadRequest();
            }

            db.Entry(noticias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiasExists(id))
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

        // POST: api/Noticias
        [ResponseType(typeof(Noticias))]
     
        public IHttpActionResult PostNoticias(Noticias noticias)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            noticias.fecha_creacion = DateTime.Now;
            noticias.fecha_publicacion = DateTime.Now;

            db.noticias.Add(noticias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = noticias.idNoticia }, noticias);
        }

        // DELETE: api/Noticias/5
        [ResponseType(typeof(Noticias))]
        public IHttpActionResult DeleteNoticias(int id)
        {
            Noticias noticias = db.noticias.Find(id);
            if (noticias == null)
            {
                return NotFound();
            }

            noticias.eliminado = true; 
            db.SaveChanges();

            return Ok(noticias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoticiasExists(int id)
        {
            return db.noticias.Count(e => e.idNoticia == id) > 0;
        }
    }
}