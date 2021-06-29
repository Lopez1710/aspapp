using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult IndexAdmin()
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
                    return Redirect("/Admin/error");
                }

            }
        }

        public ActionResult IndexCliente()
        {
            return View();
        }

    }
}