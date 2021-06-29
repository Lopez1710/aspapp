using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Log()
        {
            return View();
        }

        public static int id = 0;
        [HttpPost]
        public ActionResult Log(string user, string pass)
        {
            using (controlEntities db = new controlEntities())
            {
                var lg = from log in db.clientes
                         where log.NombreDeUsuario == user
                         && log.Pass == pass
                         select log.Id;
                id = lg.FirstOrDefault();
                if (lg.Count() > 0)
                {
                    clientes c = db.clientes.Find(id);
                    int Rol = c.Rol_Fk.Value;

                    if (Rol == 2)
                    {
                        return Redirect("/Home/IndexCliente");
                    }
                    else
                    {
                        return Redirect("/Home/IndexAdmin");
                    }

                }
                else
                {
                    return View();
                }
            }
        }

        public ActionResult salir()
        {
            LoginController.id = 0;
            return RedirectToAction("Log");
        }

        
        
    }
}