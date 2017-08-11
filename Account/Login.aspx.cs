using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using TrustAnalytics;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = new UserManager();
                ApplicationUser user = manager.Find(UserName.Text, Password.Text);
                if (user != null)
                {
                    if (manager.IsInRole(user.Id, "MRW"))
                    {
                        IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        
                    }
                    else
                    {
                        FailureText.Text = "El usuario NO dispone de permisos suficientes... Por favor, Contacte con su administrador...";
                        ErrorMessage.Visible = true;
                    }
                    
                }
                else
                {
                    FailureText.Text = "Nombre de usuario o contraseña no válidos.";
                    ErrorMessage.Visible = true;
                }
            }
        }
}