using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult NuevoAdmin()
        {
            int rol = 0;
            using (controlEntities db = new controlEntities())
            {

                var admin = from ad in db.clientes
                            where ad.Id == LoginController.id
                            select ad.Rol_Fk;
                rol = Convert.ToInt32(admin.FirstOrDefault());

                if (rol == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("error");
                }

            }


        }

        [HttpPost]

        public ActionResult NuevoAdmin(string nombre, string apellido, string usuario, string pass, int rol)
        {
            try
            {

                using (controlEntities db = new controlEntities())
                {
                    clientes c = new clientes();
                    c.Nombre = nombre;
                    c.Apellido = apellido;
                    c.NombreDeUsuario = usuario;
                    c.Pass = pass;
                    c.Rol_Fk = rol;
                    db.clientes.Add(c);
                    db.SaveChanges();

                }
                return Redirect("/Home/IndexAdmin");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Clientes()
        {
            List<clientes> lista;
            using (controlEntities db = new controlEntities())
            {
                lista = (from c in db.clientes
                         select c).ToList();
            }
            return View(lista);
        }

        [HttpPost]
        public ActionResult Clientes(string filtro)
        {
            List<clientes> lista;
            using (controlEntities db = new controlEntities())
            {
                lista = (from c in db.clientes
                         where c.Nombre.Contains(filtro)
                         select c).ToList();
            }
            return View(lista);
            
        }

        public ActionResult deuda(int id)
        {
            //List<deudas> lista;
            //using (controlEntities db = new controlEntities())
            //{
            //    lista = (from deuda in db.deudas
            //             where deuda.Id == id
            //             select deuda).ToList();
            //}
            //return View(lista);

            return RedirectToAction("InformacionDeuda","Cliente",new {id = id });
        }

        public ActionResult error()
        {
            return View();
        }

        public ActionResult listaArticulos()
        {
            List<articulos> lista;
            using (controlEntities db = new controlEntities())
            {
                lista = (from ls in db.articulos
                         select ls).ToList();

            }
                return View(lista);
        }

        public ActionResult eliminar(int id)
        {
            using (controlEntities db = new controlEntities())
            {
                articulos ar = db.articulos.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
                db.articulos.Remove(ar);
                db.SaveChanges();
            }
                return RedirectToAction("listaArticulos");
        }

        public ActionResult agregarArticulo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult agregarArticulo(string art, string precio)
        {
            decimal d = Convert.ToDecimal(precio);


            using (controlEntities db = new controlEntities())
            {
                articulos ar = new articulos();
                ar.Articulo = art;
                ar.Precio = d;
                db.articulos.Add(ar);
                db.SaveChanges();
            }

            return RedirectToAction("listaArticulos");
        }
    }
}