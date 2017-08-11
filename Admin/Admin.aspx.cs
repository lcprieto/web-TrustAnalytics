using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtUsuario_TextChanged(object sender, EventArgs e)
    {
        String Cadena;
        Cadena = "UPDATE AspNetUsers SET UserName = '" + txtUsuario.Text + "' ";
        Cadena = Cadena + " WHERE (UserName = '" + ListaUsuarios.SelectedRow.Cells[1].Text + "')";
        SQL_DetalleUsuario.UpdateCommand = Cadena;
        SQL_DetalleUsuario.Update();
        ListaUsuarios.SelectedRow.Cells[1].Text = txtUsuario.Text;
    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        String Cadena;
        Cadena = "UPDATE AspNetUsers SET Email = '" + txtEmail.Text + "' ";
        Cadena = Cadena + "WHERE (UserName = '" + ListaUsuarios.SelectedRow.Cells[1].Text + "')";
        SQL_DetalleUsuario.UpdateCommand = Cadena;
        SQL_DetalleUsuario.Update();
        ListaUsuarios.SelectedRow.Cells[2].Text = txtEmail.Text;
    }



    protected void ListaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        SQL_DetalleUsuario.SelectParameters[0].DefaultValue = ListaUsuarios.SelectedRow.Cells[1].Text;
        SQLRolesNoAsignados.SelectParameters[0].DefaultValue = ListaUsuarios.SelectedRow.Cells[1].Text;
        SQLRolesAsignados.SelectParameters[0].DefaultValue = ListaUsuarios.SelectedRow.Cells[1].Text;
        SQLIDUsuario.SelectParameters[0].DefaultValue = ListaUsuarios.SelectedRow.Cells[1].Text;
        txtUsuario.Text = ListaUsuarios.SelectedRow.Cells[1].Text;
        txtEmail.Text = ListaUsuarios.SelectedRow.Cells[2].Text;
    }

   
    protected void btnMas_Click(object sender, EventArgs e)
    {
        
        String Rol;
        String strUserID;
        String Cadena;

        DataView Visor = (DataView) SQLIDUsuario.Select(DataSourceSelectArguments.Empty);

        if (Visor.Count > 0)
        {
            strUserID = Visor[0].Row[0].ToString();
        }
        else { return; }

        foreach (int Indice in ListaRoles.GetSelectedIndices())
        {
            try
            {
                Rol = ListaRoles.Items[Indice].Value;
                Cadena = "INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('" + strUserID + "','" + Rol + "')";
                SQLRolesNoAsignados.InsertCommand = Cadena;
                SQLRolesNoAsignados.Insert();
                ListaRolesAsignados.Items.Insert(0, ListaRoles.Items[Indice].Text);
            }
            catch (Exception ex)
            {
            }


        }
        
        SQLRolesAsignados.DataBind();
        SQLRolesNoAsignados.DataBind();
    }

    protected void btnMenos_Click(object sender, EventArgs e)
    {
        String Rol;
        String strUserID;
        String Cadena;

        DataView Visor = (DataView)SQLIDUsuario.Select(DataSourceSelectArguments.Empty);


        if (Visor.Count > 0)
        {
            strUserID = Visor[0].Row[0].ToString();
        }
        else { return; }

        foreach (int Indice in ListaRolesAsignados.GetSelectedIndices())
        {
            try
            {
                Rol = ListaRolesAsignados.Items[Indice].Value;
                Cadena = "DELETE FROM AspNetUserRoles WHERE (UserId = '" + strUserID + "' AND RoleId = '" + Rol + "')";
                SQLRolesAsignados.DeleteCommand = Cadena;
                SQLRolesAsignados.Delete();
                ListaRoles.Items.Insert(0, ListaRolesAsignados.Items[Indice].Text);
            }
            catch (Exception ex)
            {
            }


        }

        SQLRolesAsignados.DataBind();
        SQLRolesNoAsignados.DataBind();
    }

    protected void btnEliminarUsuario_Click(object sender, EventArgs e)
    {
        String Cadena;
        String strUserID;
        DataView Visor = (DataView)SQLIDUsuario.Select(DataSourceSelectArguments.Empty);

        if (Visor.Count > 0) strUserID = Visor[0].Row[0].ToString();
        else return;


        Cadena = "DELETE FROM AspNetUserRoles WHERE (UserId = '" + strUserID + "')";
        SQL_Usuarios.DeleteCommand = Cadena;
        SQL_Usuarios.Delete();

        Cadena = "DELETE FROM AspNetUsers WHERE (Id = '" + strUserID + "')";
        SQL_Usuarios.DeleteCommand = Cadena;
        SQL_Usuarios.Delete();

        SQL_Usuarios.DeleteCommand = "";
        SQL_Usuarios.DataBind();
    }
}