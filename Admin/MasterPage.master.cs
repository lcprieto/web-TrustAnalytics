using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using TrustAnalytics;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var manager = new UserManager();
            ApplicationUser User = manager.FindById(Context.User.Identity.GetUserId());
            if (User == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                bool Valido = manager.IsInRole(User.Id, "TA-ADMIN");
                if (!Valido) Response.Redirect("~/Default.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
