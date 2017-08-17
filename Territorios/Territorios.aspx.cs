using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Territorios_Territorios : System.Web.UI.Page
{
    protected TreeNode NodoSeleccionadoArbol;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (ArbolLocalizaciones.Nodes.Count > 0)
            {
                NodoSeleccionadoArbol = ArbolLocalizaciones.SelectedNode;
                
            }
            
        }
        else
        {
            CargarArbolLocalizaciones();
            
        }
    }


    protected void btnProvinciasv2_Click(object sender, EventArgs e)
    {
        btnProvinciasv2.Enabled = false;
        btnLocalizaciones.Enabled = true;
        btnTerritorios.Enabled = true;
        btnProvincias.Enabled = true;
        btnPaises.Enabled = true;
        btnUbicaciones.Enabled = true;
        MultiPantalla.SetActiveView(viewLocalizacionesV2);

        
    }

    protected void btnTerritorios_Click(object sender, EventArgs e)
    {
        btnProvinciasv2.Enabled = true;
        btnLocalizaciones.Enabled = true;
        btnTerritorios.Enabled = false;
        btnProvincias.Enabled = true;
        btnPaises.Enabled = true;
        btnUbicaciones.Enabled = true;
        MultiPantalla.SetActiveView(viewTerritorios);
    }

    protected void btnLocalizaciones_Click(object sender, EventArgs e)
    {
        btnProvinciasv2.Enabled = true;
        btnLocalizaciones.Enabled = false;
        btnTerritorios.Enabled = true;
        btnProvincias.Enabled = true;
        btnPaises.Enabled = true;
        btnUbicaciones.Enabled = true;
        MultiPantalla.SetActiveView(viewLocalizacionesTwitter);
    }

    protected void btnPaises_Click(object sender, EventArgs e)
    {
        btnProvinciasv2.Enabled = true;
        btnLocalizaciones.Enabled = true;
        btnTerritorios.Enabled = true;
        btnProvincias.Enabled = true;
        btnPaises.Enabled = false;
        btnUbicaciones.Enabled = true;
        MultiPantalla.SetActiveView(viewPaises);
    }

    protected void btnProvincias_Click(object sender, EventArgs e)
    {
        btnProvinciasv2.Enabled = true;
        btnLocalizaciones.Enabled = true;
        btnTerritorios.Enabled = true;
        btnProvincias.Enabled = false;
        btnPaises.Enabled = true;
        btnUbicaciones.Enabled = true;
        MultiPantalla.SetActiveView(viewProvincias);
    }

    protected void btnUbicaciones_Click(object sender, EventArgs e)
    {
        btnProvinciasv2.Enabled = true;
        btnLocalizaciones.Enabled = true;
        btnTerritorios.Enabled = true;
        btnProvincias.Enabled = true;
        btnPaises.Enabled = true;
        btnUbicaciones.Enabled = false;
        MultiPantalla.SetActiveView(viewUbicaciones);


    }

    protected void btnMasLocalizaciones_Click(object sender, EventArgs e)
    {
        String strLocalizacion;
        String Cadena;

        foreach (int Indice in ListaLocalizacionesNuevas.GetSelectedIndices())
        {
            try
            {
                strLocalizacion = ListaLocalizacionesNuevas.Items[Indice].Value;
                Cadena = "INSERT INTO Localizacion (Localizacion, Provincia) VALUES ('" + strLocalizacion + "','N/A')";
                SQLocalizaciones.InsertCommand = Cadena;
                SQLocalizaciones.Insert();
                ListaLocalizacionesRegistradas.Items.Insert(0, ListaLocalizacionesNuevas.Items[Indice].Text);
            }
            catch (Exception ex)
            {
            }


        }

        SQLocalizaciones.DataBind();
        SQLLocalizacionesRegistradas.DataBind();
    }

    protected void btnMenosLocalizaciones_Click(object sender, EventArgs e)
    {
        String strLocalizacion;
        String Cadena;

        foreach (int Indice in ListaLocalizacionesRegistradas.GetSelectedIndices())
        {
            try
            {
                strLocalizacion = ListaLocalizacionesRegistradas.Items[Indice].Value;
                Cadena = "DELETE FROM localizacion WHERE (Localizacion = '" + strLocalizacion + "')";
                SQLLocalizacionesRegistradas.DeleteCommand = Cadena;
                SQLLocalizacionesRegistradas.Delete();
                
            }
            catch (Exception ex)
            {
            }


        }
        ListaLocalizacionesNuevas.DataBind();
        ListaTreeLocalizaciones.DataBind();
        SQLocalizaciones.DataBind();
        SQLLocalizacionesRegistradas.DataBind();
    }

    protected void btnNuevoTerritorio_Click(object sender, EventArgs e)
    {
        SeccionNuevoTerritorio.Visible = true;
    }

    protected void btnEliminarTerritorios_Click(object sender, EventArgs e)
    {
        SeccionNuevoTerritorio.Visible = false;
        txtNuevoTerritorio.Text = "";
        String strTerritorio;
        String Cadena;

        
        foreach (int Indice in ListaTerritorios.GetSelectedIndices())
        {
            try
            {
                strTerritorio = ListaTerritorios.Items[Indice].Value;
                                
                DataView Visor = (DataView)SQLProvincias.Select(DataSourceSelectArguments.Empty);
                Visor.Sort = "Territorio ASC";

                String strProvincia;
                foreach(DataRowView  Registro in Visor.FindRows(strTerritorio))
                {
                    strProvincia = Registro["Provincia"].ToString();
                    Cadena = "DELETE FROM Localizacion WHERE (Provicnia = '" + strProvincia + "')";
                    SQLLocalizacionesRegistradas.DeleteCommand = Cadena;
                    SQLLocalizacionesRegistradas.Delete();

                }

                Cadena = "DELETE FROM Provincia WHERE (Territorio = '" + strTerritorio + "')";
                SQLProvincias.DeleteCommand = Cadena;
                SQLProvincias.Delete();

                Cadena = "DELETE FROM Territorio WHERE (Territorio= '" + strTerritorio + "')";
                SQLTerritorios.DeleteCommand = Cadena;
                SQLTerritorios.Delete();

            }
            catch (Exception ex)
            {
            }


        }

        SQLTerritorios.DataBind();
        SQLLocalizacionesRegistradas.DataBind();
        SQLocalizaciones.DataBind();
        SQLProvincias.DataBind();


    }

    protected void btnAnadirTerritorio_Click(object sender, EventArgs e)
    {
        SeccionNuevoTerritorio.Visible = false;

        String strTerritorio = txtNuevoTerritorio.Text;
        txtNuevoTerritorio.Text = "";
        String Cadena;

        Cadena = "INSERT INTO Territorio (Territorio) VALUES ('" + strTerritorio + "')";
        SQLTerritorios.InsertCommand = Cadena;
        SQLTerritorios.Insert();

        ListaTerritorios.Items.Insert(0, strTerritorio);

        SQLTerritorios.DataBind();
        
    }



    protected void btnnuevaProvincia_Click(object sender, EventArgs e)
    {
        SeccionProvincia.Visible = true;
    }

    protected void btnEliminarProvincia_Click(object sender, EventArgs e)
    {
        SeccionProvincia.Visible = false;
    }

    protected void AnalizaClickLocalizaciones()
    {
        string strLocalizacion = ListaTerritoriosProvincia.SelectedItem.Text;
        DataView Visor = (DataView)SQLLocalizacionesRegistradas.Select(DataSourceSelectArguments.Empty);
        Visor.Sort = "Localizacion ASC";
        int index = Visor.Find(strLocalizacion);
        int index2 = Visor.Find(strLocalizacion);
        SeccionProvincia.Visible = true;
        if (index > -1)
        {

            String strProvincia = Visor[index]["Provincia"].ToString();
            index2 = ListaProvinciadelTerritorio.Items.IndexOf(ListaProvinciadelTerritorio.Items.FindByText(strProvincia));
            if (index2 > -1)
            {
                ListaProvinciadelTerritorio.Items.RemoveAt(index2);
                ListaProvinciadelTerritorio.Items.Insert(0, strProvincia);
                ListaProvinciadelTerritorio.SelectedIndex = 0;
            }
            else
            {
                ListaProvinciadelTerritorio.SelectedIndex = -1;
            }



        }
        else
        {
            ListaProvinciadelTerritorio.SelectedIndex = -1;
        }
    }

    protected void ListaTerritoriosProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {

        AnalizaClickLocalizaciones();
       
    }


    protected void btnEliminarLocalizacion_Click(object sender, EventArgs e)
    {

    }

    protected void btnAsignarProvincia_Click(object sender, EventArgs e)
    {
        String Cadena;
        String strProvincia = ListaProvinciadelTerritorio.SelectedItem.ToString();
        String strLocalizacion = ListaTerritoriosProvincia.SelectedItem.ToString();

        Cadena = "UPDATE Localizacion SET Provincia = '" + strProvincia + "' ";
        Cadena = Cadena + "WHERE (Localizacion = '" + strLocalizacion + "')";
        SQLLocalizacionesRegistradas.UpdateCommand = Cadena;
        SQLLocalizacionesRegistradas.Update();

        ListaProvinciadelTerritorio.SelectedIndex = -1;
        ListaTerritoriosProvincia.SelectedIndex = -1;

    }

    protected void btnEliminarPais_Click(object sender, EventArgs e)
    {
        SeccionNuevoPais.Visible = false;
        txtNuevoPais.Text = "";
        String strPais;
        String Cadena;

        DataView Visor = (DataView)SQLPaises.Select(DataSourceSelectArguments.Empty);
        foreach (int Indice in ListaPaises.GetSelectedIndices())
        {
            try
            {
                strPais = ListaPaises.Items[Indice].Value;
                Cadena = "DELETE FROM Pais WHERE (Pais= '" + strPais + "')";
                SQLPaises.DeleteCommand = Cadena;
                SQLPaises.Delete();

               
                Cadena = "DELETE FROM Provincia WHERE (Pais = '" + strPais + "')";
                SQLProvincias.DeleteCommand = Cadena;
                SQLProvincias.Delete();
                

            }
            catch (Exception ex)
            {
            }


        }

        SQLPaises.DataBind();
        SQLProvincias.DataBind();
    }

    protected void btnAnadirPais_Click(object sender, EventArgs e)
    {
        SeccionNuevoPais.Visible = false;

        String strPais = txtNuevoPais.Text;
        txtNuevoPais.Text = "";
        String Cadena;

        DataView Visor = (DataView)SQLPaises.Select(DataSourceSelectArguments.Empty);
        Cadena = "INSERT INTO Pais (Pais) VALUES ('" + strPais + "')";
        SQLPaises.InsertCommand = Cadena;
        SQLPaises.Insert();

        ListaPaises.Items.Insert(0, strPais);

        SQLPaises.DataBind();
    }



    protected void btnNuevoPaís_Click(object sender, EventArgs e)
    {
        SeccionNuevoPais.Visible = true;
    }

    protected void btnAsignarProvinciaMultiple_Click(object sender, EventArgs e)
    {
        
        String Cadena;
        String strProvincia = ListaMultipleProvincias.SelectedItem.ToString();
        String strLocalizacion;
        DataView Visor = (DataView)SQLLocalizacionesRegistradas.Select(DataSourceSelectArguments.Empty);

        foreach (int Indice in ListaMultipleLocalizaciones.GetSelectedIndices())
        {
            try
            {
                strLocalizacion = ListaMultipleLocalizaciones.Items[Indice].Value;
                Cadena = "UPDATE Localizacion SET Localizacion = '" + strLocalizacion + "', ";
                Cadena = Cadena + "Provincia = '" + strProvincia + "' ";
                Cadena = Cadena + " WHERE (Localizacion = '" + strLocalizacion + "')";
                SQLLocalizacionesRegistradas.UpdateCommand = Cadena;
                SQLLocalizacionesRegistradas.Update();
                
            }
            catch (Exception ex)
            {
            }


        }

        SQLLocalizacionesRegistradas.DataBind();
        SQLProvincias.DataBind();
    }

    protected void btnLocalizacionSimple_Click(object sender, EventArgs e)
    {
        btnLocalizacionSimple.Enabled = false;
        btnLocalizacionMultiple.Enabled = true;
        MultiLocalizacion.SetActiveView(viewLocalizacionSimple);
    }

    protected void btnLocalizacionMultiple_Click(object sender, EventArgs e)
    {
        btnLocalizacionSimple.Enabled = true;
        btnLocalizacionMultiple.Enabled = false;
        MultiLocalizacion.SetActiveView(viewLocalizacionMultimple);
    }

    protected void ListaMultipleProvincias_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListaMultipleLocalizaciones.SelectedIndex= -1;
        String strProvincia = ListaMultipleProvincias.SelectedItem.Text;
        String strLocalizacion;
        DataView Visor = (DataView)SQLLocalizacionesRegistradas.Select(DataSourceSelectArguments.Empty);
        Visor.Sort = "Provincia ASC";
        int Index;

        foreach (DataRowView Fila in Visor.FindRows(strProvincia))
        {
            strLocalizacion = Fila["Localizacion"].ToString();
            Index = ListaMultipleLocalizaciones.Items.IndexOf(ListaMultipleLocalizaciones.Items.FindByText(strLocalizacion));
            if (Index > -1)
            {
                ListaMultipleLocalizaciones.Items.RemoveAt(Index);
                ListaMultipleLocalizaciones.Items.Insert(0, strLocalizacion);
                ListaMultipleLocalizaciones.Items[0].Selected = true;
            }
        }


        
        
    }

    protected void CargarArbolLocalizaciones()
    {
        
        ArbolLocalizaciones.Nodes.Clear();

        TreeNode Raiz = new TreeNode("TrustAnalytics.");
        Raiz.NavigateUrl = "";
        Raiz.Value = "Raiz";
        ArbolLocalizaciones.Nodes.Add(Raiz);

        DataView Visor = (DataView)SQLProvincias.Select(DataSourceSelectArguments.Empty);
        Visor.Sort = "Provincia ASC";
        DataView VisorLocalizacion = (DataView)SQLLocalizacionesRegistradas.Select(DataSourceSelectArguments.Empty);
        int Elementos;
        foreach (DataRowView Fila in Visor)
        {
            TreeNode Nodo = new TreeNode(Fila["Provincia"].ToString());
            Nodo.Value = "Provincia";
            Nodo.SelectAction = TreeNodeSelectAction.SelectExpand;
            //Nodo.NavigateUrl = "";
            Raiz.ChildNodes.Add(Nodo);
           
            VisorLocalizacion.Sort = "Provincia ASC";

            Elementos = 0;

            foreach (DataRowView Localizacion in VisorLocalizacion.FindRows(Fila["Provincia"].ToString()))
            {
                Elementos += 1;
                TreeNode NuevoNodo = new TreeNode(Localizacion["Localizacion"].ToString());
                NuevoNodo.Value = "Localizacion";
                Nodo.SelectAction = TreeNodeSelectAction.SelectExpand;
                Nodo.ChildNodes.Add(NuevoNodo);
            }
            if (Elementos == 0)
            {
                TreeNode NuevoNodo = new TreeNode("<Vacio>");
                NuevoNodo.Value = "Vacio";
                Nodo.SelectAction = TreeNodeSelectAction.SelectExpand;
                Nodo.ChildNodes.Add(NuevoNodo);
            }
            Nodo.CollapseAll();
        }

        


    }

    protected void ArbolLocalizaciones_SelectedNodeChanged(object sender, EventArgs e)
    {
        ArbolLocalizaciones.SelectedNode.CollapseAll();
        NodoSeleccionadoArbol.Selected = true;
        NodoSeleccionadoArbol.ExpandAll();
    }

    protected void ListaTreeLocalizaciones_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnEliminarLocalizacionTree_Click(object sender, EventArgs e)
    {
        String strLocalizacion;
        String Cadena;
        DataView Visor = (DataView)SQLLocalizacionesRegistradas.Select(DataSourceSelectArguments.Empty);
        foreach (TreeNode Nodo in ArbolLocalizaciones.CheckedNodes)
        {

            try
            {
                strLocalizacion = Nodo.Text;
                Cadena = "DELETE FROM localizacion WHERE (Localizacion = '" + strLocalizacion + "')";
                SQLLocalizacionesRegistradas.DeleteCommand = Cadena;
                SQLLocalizacionesRegistradas.Delete();

            }
            catch (Exception ex)
            {
            }
            
            
        }

        ListaTreeLocalizaciones.DataBind();
        SQLocalizaciones.DataBind();
        SQLLocalizacionesRegistradas.DataBind();
        CargarArbolLocalizaciones();

    }

    protected void btnAsignarLocalizacionTree_Click(object sender, EventArgs e)
    {

        if (ArbolLocalizaciones.SelectedNode != null)
        {
            if (ArbolLocalizaciones.SelectedNode.Value == "Provincia")
            {
                String Cadena;
                String strProvincia = ArbolLocalizaciones.SelectedNode.Text;
                String strLocalizacion;

                foreach (int Indice in ListaTreeLocalizaciones.GetSelectedIndices())
                {
                    try
                    {
                        strLocalizacion = ListaTreeLocalizaciones.Items[Indice].Value;
                        Cadena = "INSERT INTO Localizacion (Localizacion, Provincia) VALUES ('" + strLocalizacion + "','" + strProvincia + "')";                      
                        SQLLocalizacionesRegistradas.InsertCommand = Cadena;
                        SQLLocalizacionesRegistradas.Insert();
                        TreeNode NodoArbol = new TreeNode(strLocalizacion);
                        NodoArbol.Value = "Localizacion";
                        ArbolLocalizaciones.SelectedNode.ChildNodes.Add(NodoArbol);

                    }
                    catch (Exception ex)
                    {
                    }


                }

                SQLLocalizacionesRegistradas.DataBind();
                SQLProvincias.DataBind();
            }
            else
            {

            }
        }

        ListaTreeLocalizaciones.DataBind();
    }

    protected void SQLProvincias_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }

    protected void btnNuevaProvincia_Click(object sender, EventArgs e)
    {
        btnEditarProvincia.Enabled = true;
        btnNuevaProvincia.Enabled = false;
        btnEliminarProvincia.Enabled = false;
        MultiProvincia.SetActiveView(viewCrearProvincia);
    }



    protected void btnEditarProvincia_Click(object sender, EventArgs e)
    {
        btnEditarProvincia.Enabled = false;
        btnNuevaProvincia.Enabled = true;
        MultiProvincia.SetActiveView(viewEditarProvincia);
    }

    protected void btnAltanuevaProvincia_Click(object sender, EventArgs e)
    {
        if (txtNuevaProvincia.Text.Length > 0)
        {
            String Cadena;
            String strProvincia = txtNuevaProvincia.Text;
            txtNuevaProvincia.Text = "";

            try
            {
                Cadena = "INSERT INTO Provincia (Provincia, Pais, Territorio)";
                Cadena = Cadena + "VALUES (";
                Cadena = Cadena + "'" + strProvincia + "',";
                Cadena = Cadena + "'" + ListaNuevaProvinciaPais.SelectedItem.Text + "',";
                Cadena = Cadena + "'" + ListaNuevaProvinciaTerritorio.SelectedItem.Text + "')";

                SQLProvincias.InsertCommand = Cadena;
                SQLProvincias.Insert();


            }
            catch (Exception ex)
            {
            }

            SQLProvincias.DataBind();
            GVProvincias.DataBind();
            ArbolLocalizaciones.DataBind();

            btnNuevaProvincia.Enabled = true;
            btnEditarProvincia.Enabled = false;
            btnAltanuevaProvincia.Enabled = false;
            MultiProvincia.SetActiveView(viewEditarProvincia);
        }
        else
        {
            ControlaBotonCrearProvincia();
        }


    }

    protected void ControlaBotonCrearProvincia()
    {
        if ((ListaNuevaProvinciaPais.SelectedItem != null) && 
            (ListaNuevaProvinciaTerritorio.SelectedItem != null) &&
            (txtNuevaProvincia.Text.Length > 0))
        {
            btnAltanuevaProvincia.Enabled = true;
        }
        else
        {
            btnAltanuevaProvincia.Enabled = false;
        }
    }

    protected void ListaNuevaProvinciaPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        ControlaBotonCrearProvincia();
    }

    protected void ListaNuevaProvinciaTerritorio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ControlaBotonCrearProvincia();
    }

    protected void txtNuevaProvincia_TextChanged(object sender, EventArgs e)
    {
        ControlaBotonCrearProvincia();
    }

    protected void GVProvincias_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnActualizarUbicacion.Enabled = true;
        btnEliminarProvincia.Enabled = true;

        String strProvincia = GVProvincias.SelectedRow.Cells[1].Text;
        String strPais = GVProvincias.SelectedRow.Cells[2].Text;
        String strTerritorio = GVProvincias.SelectedRow.Cells[3].Text;

        int IndexPais = ListaEditarProvinciaPais.Items.IndexOf(ListaEditarProvinciaPais.Items.FindByText(strPais));
        int IndexTerritorio = ListaEditarProvinciaTerritorio.Items.IndexOf(ListaEditarProvinciaTerritorio.Items.FindByText(strTerritorio));

        ListaEditarProvinciaPais.SelectedIndex = IndexPais;
        ListaEditarProvinciaTerritorio.SelectedIndex = IndexTerritorio;


    }

    protected void btnActualizarUbicacion_Click(object sender, EventArgs e)
    {
        String strProvincia = GVProvincias.SelectedRow.Cells[1].Text;
        String strPais = ListaEditarProvinciaPais.SelectedItem.Text;
        String strTerritorio = ListaEditarProvinciaTerritorio.SelectedItem.Text;
                
        String Cadena;

        try
        {
            Cadena = "UPDATE Provincia SET ";
            Cadena = Cadena + "Pais = '" + strPais + "', ";
            Cadena = Cadena + "Territorio = '" + strTerritorio + "' ";
            Cadena = Cadena + " WHERE (Provincia = '" + strProvincia + "')";

            SQLProvincias.UpdateCommand = Cadena;
            SQLProvincias.Update();

        }
        catch (Exception ex)
        {
        }

        SQLProvincias.DataBind();
        GVProvincias.SelectedRow.Cells[2].Text = strPais;
        GVProvincias.SelectedRow.Cells[3].Text = strTerritorio;
    }

    protected void btnEliminarProvincia_Click1(object sender, EventArgs e)
    {
        String strProvincia;
        String Cadena;
        strProvincia = GVProvincias.SelectedRow.Cells[1].Text;
        
        try
        {
            Cadena = "DELETE FROM Provincia WHERE (Provincia = '" + strProvincia + "')";
            SQLProvincias.DeleteCommand = Cadena;
            SQLProvincias.Delete();

            Cadena = "DELETE FROM Localizacion WHERE (Provincia = '" + strProvincia + "')";
            SQLLocalizacionesRegistradas.DeleteCommand = Cadena;
            SQLLocalizacionesRegistradas.Delete();

        }
        catch (Exception ex)
        {
        }

        SQLProvincias.DataBind();
        SQLLocalizacionesRegistradas.DataBind();
        GVProvincias.DataBind();

    }
}