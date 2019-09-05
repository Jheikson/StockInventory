using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Security;

namespace StockInventory.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.LoginError = TempData["errorMessage"] != null ? TempData["errorMessage"].ToString() : "";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ValidateLogin(string username, string password)
        {
            int result;
            string strConnect = System.Configuration.ConfigurationManager.
                ConnectionStrings["StockInventoryContext"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnect))
            using (SqlCommand cmd = new SqlCommand("[INVENTORY].[dbo].[spLogin]", conn))
            {
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = password;

                    try
                    {
                        conn.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        result = -1;
                    }

                    if (result == 1)
                    {
                        Session["login"] = username;
                        FormsAuthentication.SetAuthCookie(username, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        TempData["errorMessage"] = "Usuario o clave errados";
                        return RedirectToAction("Index", "Login");
                }

            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}