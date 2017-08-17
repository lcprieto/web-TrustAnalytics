<%@ Page Title="Acerca de..." Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    
    <h3>Sistema de control Reputacional en Redes Sociales.</h3>
    <img src="Recursos/Actualidad.JPG" style="width: 940px; height: 585px" />
    <p>TRUST ANALYTICS es un proyecto nacido en la Escuala de Negocio MBIT School como proyecto final de Master Executive Data Science.</p>
    <p>Se ha desarrollado una serie de scripts basados en Python, que son capaces de leer los Tweets de un criterio de negocio específico y analuizar el sentimiento de dicho texto mejorando los resultados del API estandar de otros proveedores de servicios API de Análisis Sintáctico.</p>

</asp:Content>
