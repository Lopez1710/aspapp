using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClienteController : Controller
    {

        // GET: Cliente
        public ActionResult Informacion()
        {
            int id = LoginController.id;
            List<clientes> lista;
            using (controlEntities db = new controlEntities())
            {
                lista = (from datos in db.clientes
                         where datos.Id == id
                         select datos).ToList();
            }
            return View(lista);
            
        }

       public ActionResult InformacionCompras(int id)
        {
            List<Compras> lista;
            using (controlEntities db = new controlEntities())
            {
                lista = (from compras in db.Compras
                         where compras.Id == id/*LoginController.id*/
                         select compras).ToList();
            }
                return View(lista);
        }
        
        public ActionResult InformacionDeuda(int id)
        {
            List<deuda> lista;
            using (controlEntities db = new controlEntities())
            {
                lista = (from deuda in db.deuda
                         where deuda.Cliente_Id_Fk == id/*LoginController.id*/
                         select deuda).ToList();
                var Rol = from rol in db.clientes
                          where rol.Id == LoginController.id
                          select rol.Rol_Fk;

                ViewBag.idc = Rol.FirstOrDefault().Value;

                
            }
            
            return View(lista);
        }

        public ActionResult NuevaCompra()
        {
            List<articulos> lista;
            using (controlEntities db = new controlEntities())
            {
                lista = (from a in db.articulos
                        select a).ToList();
            }
                return View(lista);
        }

        public ActionResult NuevoCredito()
        {
            List<articulos> lista;
            using (controlEntities db = new controlEntities())
            {
                lista = (from a in db.articulos
                         select a).ToList();
                
            }

         
            return View(lista);
        }
        
        [HttpPost]
        public ActionResult NuevoCredito(string articulo, string cantidad)
        {
            try
            {
                using (controlEntities db = new controlEntities())
                {
                    deuda d = new deuda();
                    d.Cliente_Id_Fk = LoginController.id;
                    d.Articulo_id_Fk = Convert.ToInt32(articulo) ;
                    d.Cantidad = Convert.ToInt32(cantidad);
                    d.fecha = DateTime.Today;

                    db.deuda.Add(d);
                    db.SaveChanges();

                    return Redirect("/Home/IndexCliente");
                }
            }
            catch
            {
                return View();
            }

            
        }

        public ActionResult eliminar(int id)
        {
            using (controlEntities db = new controlEntities())
            {
                deuda item = db.deuda.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                db.deuda.Remove(item);
                db.SaveChanges();
            }
                return RedirectToAction("InformacionDeuda", new {LoginController.id});
        }
    }
}