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
using WebApiNews.Repositorio;

namespace WebApiNews.Controllers
{
    public class UsuariosController : ApiController
    {
        private WebApiNewsDbContext db = new WebApiNewsDbContext();

        // GET: api/Usuarios
        public IQueryable<Usuarios> Getusuarios()
        {
            return db.usuarios.Where(X => X.eliminado == false);
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult GetUsuarios(int id)
        {
            Usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            
            return Ok(usuarios);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarios(int id, Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.idUsuario)
            {
                return BadRequest();
            }
           


            db.Entry(usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult PostUsuarios(Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            usuarios.fecha_creacion = DateTime.Now;
            string clave = usuarios.contraseña;
            var claveEncriptada = Encriptar.GetSha256(clave);
            usuarios.contraseña = claveEncriptada;
            db.usuarios.Add(usuarios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuarios.idUsuario }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult DeleteUsuarios(int id)
        {
           
            Usuarios usuarios = db.usuarios.Where(X => X.idUsuario == id).FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound();
            }
            usuarios.eliminado = true;
            db.SaveChanges();

            return Ok(usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuariosExists(int id)
        {
            return db.usuarios.Count(e => e.idUsuario == id) > 0;
        }
    }
}