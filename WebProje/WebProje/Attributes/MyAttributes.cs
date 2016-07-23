using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Attributes
{
    public class AdminRoleControl : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // action çalışmadan önce yapılacak işlemler
            var ent = new FilmBilgileriEntities1();
            
            if (HttpContext.Current.Session["eposta"] == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Login");
            }
            else
            {
                string Eposta = HttpContext.Current.Session["eposta"].ToString();
                var uye_rol = ent.tblMember.FirstOrDefault(x => x.MemberEmail == Eposta).MemberGroupID;
                if (uye_rol != 1)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }

    }
}