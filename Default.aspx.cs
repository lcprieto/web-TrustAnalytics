using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using TrustAnalytics;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserManager manager = new UserManager();
        ApplicationUser User = manager.FindById(Context.User.Identity.GetUserId());

        if (User != null)
        {
            if (manager.IsInRole(User.Id, "TA-ADMIN")) SeccionAdmin.Visible = true;
            else SeccionAdmin.Visible = false;

            if (manager.IsInRole(User.Id, "TA-TERRITORIOS")) SeccionTerritorios.Visible = true;
            else SeccionTerritorios.Visible = false;

            if (manager.IsInRole(User.Id, "TA-POWERBI")) SeccionPowerBI.Visible = true;
            else SeccionPowerBI.Visible = false;

        }
        else
        {
            SeccionAdmin.Visible = false;
            SeccionTerritorios.Visible = false;
            SeccionPowerBI.Visible = false;
        }
        
    }
}