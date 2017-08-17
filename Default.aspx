<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="background-color: #BD582C; color: #FFFFFF">
        <h1>TRUSTAnalytics</h1>
        <p>Recupere el Control de la Gestión de su Reputación...</p>
        <p>Trust Analytics es creada por alumnos de MBIT School.</p>
        <p><a href="http://www.mbitschool.com" class="btn btn-primary btn-lg">ver MBIT &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4" id="SeccionAdmin" runat="server" >
            <h2>Administración de usuarios</h2>
            <p>
                Servicio de gestión de usuarios.
            </p>
            <p>
                <a class="btn btn-default" href="./Admin/Admin.aspx">Ver &raquo;</a>
            </p>
        </div>
        <div class="col-md-4" id="SeccionTerritorios" runat="server">
            <h2>Gestión de Territorios</h2>
            <p>
                Para una correcta gestión de los Territorios y provincias en los Report de Prower BI, dispone de un servicio de consolidación de las localizaciones de sus contactos de Twitter.
            </p>
            <p>
                <a class="btn btn-default" href="./Territorios/Territorios.aspx">ver &raquo;</a>
            </p>
        </div>
        <div class="col-md-4" id="SeccionPowerBI" runat="server">
            <h2>Ver Informe</h2>
            <p>
                Puede aceder a los Reporting de Seguimiento de su Reputación en Twitter desde esta sección.
            </p>
            <p>
                <a class="btn btn-default" href="./PowerBI/PowerBI.aspx">ver &raquo;</a>
            </p>
        </div>
    </div>

     <div class="row">
         <div class="col-md-4" >
            <h2>Pensamiento Tradicional</h2>
            <p>
                <asp:Image ID="imgTradicional" runat="server" Height="201px" ImageUrl="~/Recursos/Tradicional.JPG" Width="318px" />
            </p>
           
        </div>
         <div class="col-md-4" >
            <h2>Actualidad</h2>
            <p>
                <asp:Image ID="imgActualidad" runat="server" Height="201px" Width="318px" ImageUrl="~/Recursos/Actualidad.JPG" />
            </p>
           
        </div>
         <div class="col-md-4" >
            <h2>Objetivo</h2>
            <p>
                <asp:Image ID="imgObjetivo" runat="server" Height="201px" ImageUrl="~/Recursos/Objetivo.JPG" Width="318px" />
            </p>
           
        </div>
     </div>
</asp:Content>
