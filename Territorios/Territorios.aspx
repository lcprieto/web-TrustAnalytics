<%@ Page Title="" Language="C#" MasterPageFile="~/Territorios/Territoriost.master" AutoEventWireup="true" CodeFile="Territorios.aspx.cs" Inherits="Territorios_Territorios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoTerritorios" Runat="Server">
    <table class="nav-justified">
        <tr>
            <td style="width: 168px; vertical-align: top;">
                <asp:Button ID="btnProvinciasv2" runat="server" Text="Localizacione" CssClass="form-control" OnClick="btnProvinciasv2_Click" Enabled="False" />
                <asp:Button ID="btnUbicaciones" runat="server" Text="Ubicaciones" CssClass="form-control" OnClick="btnUbicaciones_Click" />
                <asp:Button ID="btnLocalizaciones" runat="server" Text="Pendiente Twitter" CssClass="form-control" OnClick="btnLocalizaciones_Click" />
                <asp:Button ID="btnTerritorios" runat="server" Text="Territorios" CssClass="form-control" OnClick="btnTerritorios_Click" />
                <asp:Button ID="btnPaises" runat="server" Text="Paises" CssClass="form-control" OnClick="btnPaises_Click"  />
                <asp:Button ID="btnProvincias" runat="server" Text="Localizaciones OLD" CssClass="form-control" OnClick="btnProvincias_Click" Visible="False" />
                <p></p>
            </td>
            <td style="width: 29px">
                <p></p>
            </td>
            <td>
                <asp:MultiView ID="MultiPantalla" runat="server" ActiveViewIndex="4">
                    <asp:View ID="viewLocalizacionesTwitter" runat="server">
                        <h1>Gestión de Pendientes de Twitter.</h1>
            
                         <table class="nav-justified">
                             <tr>
                                 <td style="width: 282px">Localizaciones de Twitter no registradas...</td>
                                 <td style="width: 29px">&nbsp;</td>
                                 <td>Localizaciones de Twitter Ya registradas</td>
                             </tr>
                             <tr>
                                 <td style="width: 282px">
                                     <asp:ListBox ID="ListaLocalizacionesNuevas" runat="server" Height="350px" Width="320px" DataSourceID="SQLocalizaciones" DataTextField="localizacion" DataValueField="localizacion" SelectionMode="Multiple"  >

                                     </asp:ListBox>
                                     
                                 </td>
                                 <td style="width: 29px">
                                     <asp:Button ID="btnMasLocalizaciones" runat="server" Text=">" OnClick="btnMasLocalizaciones_Click" />

                                     <br />

                                     <asp:Button ID="btnMenosLocalizaciones" runat="server" Text="<" OnClick="btnMenosLocalizaciones_Click" Height="27px" />
                                 </td>
                                 <td><asp:ListBox ID="ListaLocalizacionesRegistradas" runat="server" Height="350px" Width="320px" DataSourceID="SQLLocalizacionesRegistradas" DataTextField="Localizacion" DataValueField="Localizacion" SelectionMode="Multiple">

                                     </asp:ListBox>
                                     
                                 </td>
                             </tr>
                        </table>
            
                         <p>
                             &nbsp;</p>
                    </asp:View>
                    <asp:View ID="viewTerritorios" runat="server">
                        <h1>Gestión de Territorios.</h1>
                        <table class="nav-justified">
                            <tr>
                                <td style="width: 338px">Territorios disponibles</td>
                                <td style="width: 145px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 338px"><asp:ListBox ID="ListaTerritorios" runat="server" Height="350px" Width="320px" DataSourceID="SQLTerritorios" DataTextField="Territorio" DataValueField="Territorio" SelectionMode="Multiple"></asp:ListBox>
                                    
                                </td>
                                <td style="width: 145px; vertical-align: top;">
                                    <asp:Button ID="btnEliminarTerritorios" runat="server" Text="Eliminar Territorio" CssClass="form-control" OnClick="btnEliminarTerritorios_Click" />
                                    <asp:Button ID="btnNuevoTerritorio" runat="server" Text="Nuevo Territorio" CssClass="form-control" OnClick="btnNuevoTerritorio_Click" />
                                </td>
                                <td style="width: 50px">
                                </td>
                                <td style="vertical-align: top">
                                    <div id="SeccionNuevoTerritorio" runat="server" visible="False" >
                                        <p style="vertical-align: top">Nuevo territorio a incluir...</p>
                                        <asp:TextBox ID="txtNuevoTerritorio" runat="server" Width="481px" CssClass="form-control"></asp:TextBox>
                                        <asp:Button ID="btnAnadirTerritorio" runat="server" Text="Añadir Territorio" CssClass="form-control" OnClick="btnAnadirTerritorio_Click"  />
                                    </div>
                                    </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="viewPaises" runat="server">
                        <h1>Gestión de Paises.</h1>
                        <table class="nav-justified">
                            <tr>
                                <td style="width: 338px">Paises disponibles</td>
                                <td style="width: 145px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 338px"><asp:ListBox ID="ListaPaises" runat="server" Height="350px" Width="320px" DataSourceID="SQLPaises" DataTextField="Pais" DataValueField="Pais" SelectionMode="Multiple"></asp:ListBox>
                                    
                                </td>
                                <td style="width: 145px; vertical-align: top;">
                                    <asp:Button ID="btnEliminarPais" runat="server" Text="Eliminar País" CssClass="form-control" OnClick="btnEliminarPais_Click" />
                                    <asp:Button ID="btnNuevoPaís" runat="server" Text="Nuevo País" CssClass="form-control" OnClick="btnNuevoPaís_Click" />
                                </td>
                                <td style="width: 50px">
                                </td>
                                <td style="vertical-align: top">
                                    <div id="SeccionNuevoPais" runat="server" visible="False" >
                                        <p style="vertical-align: top">Nuevo territorio a incluir...</p>
                                        <asp:TextBox ID="txtNuevoPais" runat="server" Width="481px" CssClass="form-control"></asp:TextBox>
                                        <asp:Button ID="btnAnadirPais" runat="server" Text="Añadir País" CssClass="form-control" OnClick="btnAnadirPais_Click" />
                                    </div>
                                    </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="viewProvincias" runat="server">
                        <h1>Gestión de Localizaciones.</h1>
                        <asp:Button ID="btnLocalizacionSimple" runat="server" Text="Simple" CssClass="form-control" Enabled="False" OnClick="btnLocalizacionSimple_Click"  />
                        <asp:Button ID="btnLocalizacionMultiple" runat="server" Text="Múltiple" CssClass="form-control" OnClick="btnLocalizacionMultiple_Click"  />
                        <asp:MultiView ID="MultiLocalizacion" runat="server" ActiveViewIndex="0">
                            <asp:View ID="viewLocalizacionSimple" runat="server">
                                <table class="nav-justified">
                                    <tr>
                                        <td style="width: 423px">Localizaciones disponibles</td>
                                        <td style="width: 46px">&nbsp;</td>
                                        <td style="width: 195px">&nbsp;</td>
                                        <td style="width: 195px">&nbsp;</td>
                                        <td>Provincias Disponibles</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 423px">
                                            <asp:ListBox ID="ListaTerritoriosProvincia" runat="server" DataSourceID="SQLLocalizacionesRegistradas" DataTextField="Localizacion" DataValueField="Localizacion" Height="601px" Width="450px" onClick ="AnalizaClickLocalizaciones" OnSelectedIndexChanged="ListaTerritoriosProvincia_SelectedIndexChanged" AutoPostBack="True"  ></asp:ListBox>
                                        </td>
                                        <td style="width: 40px">
                                            &nbsp;</td>
                                        <td style="width: 195px">
                                            <asp:Button ID="btnAsignarProvincia" runat="server" CssClass="form-control" OnClick="btnAsignarProvincia_Click" Text="Asignar Provincia" />
                                        </td>
                                       <td style="width: 40px">
                                            &nbsp;</td>
                                        <td>
                                            <div id="SeccionProvincia" runat="server" style="width: 607px" visible="True">
                                        
                                                <asp:ListBox ID="ListaProvinciadelTerritorio" runat="server" Height="601px" Width="450px" DataSourceID="SQLProvincias" DataTextField="Provincia" DataValueField="Provincia" CssClass="col-xs-offset-0"></asp:ListBox>
                                        
                                            </div>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="viewLocalizacionMultimple" runat="server">
                                <table class="nav-justified">
                                    <tr>
                                        <td style="width: 423px">Provincias disponibles</td>
                                        <td style="width: 46px">&nbsp;</td>
                                        <td style="width: 195px">&nbsp;</td>
                                        <td style="width: 195px">&nbsp;</td>
                                        <td>Localizaciones Disponibles</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 423px">
                                            <asp:ListBox ID="ListaMultipleProvincias" runat="server" DataSourceID="SQLProvincias" DataTextField="Provincia" DataValueField="Provincia" Height="601px" Width="450px"   AutoPostBack="True" OnSelectedIndexChanged="ListaMultipleProvincias_SelectedIndexChanged"  ></asp:ListBox>
                                        </td>
                                        <td style="width: 40px">
                                            &nbsp;</td>
                                        <td style="width: 195px">
                                            <asp:Button ID="btnAsignarProvinciaMultiple" runat="server" CssClass="form-control" text="Asignar Provincia" OnClick="btnAsignarProvinciaMultiple_Click" />
                                        </td>
                                       <td style="width: 40px">
                                            &nbsp;</td>
                                        <td>
                                            <div id="Div1" runat="server" style="width: 607px" visible="True">
                                        
                                                <asp:ListBox ID="ListaMultipleLocalizaciones" runat="server" Height="601px" Width="450px" DataSourceID="SQLLocalizacionesRegistradas" DataTextField="Localizacion" DataValueField="Localizacion" CssClass="col-xs-offset-0" SelectionMode="Multiple"></asp:ListBox>
                                        
                                            </div>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>


                    </asp:View>
                    <asp:View ID="viewLocalizacionesV2" runat="server">
                        <h1>Gestión de Localizaciones</h1>
                        <table class="nav-justified">
                            <tr>
                                <td style="width: 376px">Estructura Disponible</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>Localizaciones no asignadas</td>
                            </tr>
                            <tr>
                                <td style="width: 376px">
                                    <div style="border: thin solid #C0C0C0; overflow:auto; width:350px; height:580px;">
                                    <asp:TreeView ID="ArbolLocalizaciones" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="ArbolLocalizaciones_SelectedNodeChanged" ShowCheckBoxes="All" ShowExpandCollapse="True" ShowLines="True" CssClass="form-control" NodeWrap="True" Target="_self">
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                        <ParentNodeStyle Font-Bold="False" />
                                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
                                    </asp:TreeView>
                                        </div>
                                </td>
                                <td style="width: 50px">
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnAsignarLocalizacionTree" runat="server" CssClass="form-control" OnClick="btnAsignarLocalizacionTree_Click" Text="Asignar" Width="141px" />
                                    <asp:Button ID="btnEliminarLocalizacionTree" runat="server" CssClass="form-control" OnClick="btnEliminarLocalizacionTree_Click" Text="Quitar" Width="141px" />
                                </td>
                                <td style="width: 50px">&nbsp;</td>
                                <td>
                                    <asp:ListBox ID="ListaTreeLocalizaciones" runat="server" Height="601px" Width="450px" DataSourceID="SQLocalizaciones" DataTextField="Localizacion" DataValueField="Localizacion" CssClass="col-xs-offset-0" SelectionMode="Multiple" OnSelectedIndexChanged="ListaTreeLocalizaciones_SelectedIndexChanged"></asp:ListBox>

                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="viewUbicaciones" runat="server">
                        <h1>Gestión de Ubicaciones.</h1>
                 
                            <table>
                                <tr>
                                        <td>
                                            <asp:Button ID="btnEditarProvincia" runat="server" Text="ver Provicnias" CssClass="form-control" Width="190px" Enabled="False" OnClick="btnEditarProvincia_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNuevaProvincia" runat="server" Text="Crear Provincia" CssClass="form-control" Width="190px" OnClick="btnNuevaProvincia_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnEliminarProvincia" runat="server" Text="Eliminar Provincia" CssClass="form-control" Width="190px" Enable ="False"  Enabled="False" OnClick="btnEliminarProvincia_Click1" />
                                        </td>
                                    </tr>
                             </table>
                            <asp:MultiView ID="MultiProvincia" runat="server" ActiveViewIndex="0">
                                
                                    
                                
                                <asp:View ID="viewEditarProvincia" runat="server">
                                    <table class="nav-justified">
                                        <tr>
                                            <td style="width: 527px">Ubicaciones Disponibles</td>
                                            <td style="width: 28px">&nbsp;</td>
                                            <td style="width: 156px">País</td>
                                            <td style="width: 113px">Territorio</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 527px">
                                                <asp:GridView ID="GVProvincias" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SQLProvincias" ForeColor="#333333" GridLines="None" PageIndex="1" Width="532px" OnSelectedIndexChanged="GVProvincias_SelectedIndexChanged">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:CommandField ShowSelectButton="True" />
                                                        <asp:BoundField DataField="Provincia" HeaderText="Provincia" SortExpression="Provincia">
                                                        <ItemStyle Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Pais" HeaderText="Pais" SortExpression="Pais" HtmlEncode="False" HtmlEncodeFormatString="False">
                                                        <ItemStyle Width="100px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Territorio" HeaderText="Territorio" SortExpression="Territorio">
                                                        <ItemStyle Width="100px" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#EFF3FB" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                </asp:GridView>
                                            </td>
                                            <td style="width: 28px">&nbsp;</td>
                                            <td style="width: 156px">
                                                <asp:ListBox ID="ListaEditarProvinciaPais" runat="server" DataSourceID="SQLPaises" DataTextField="Pais" DataValueField="Pais" Height="200px" Width="150px"></asp:ListBox>
                                            </td>
                                            <td style="width: 113px">
                                                <asp:ListBox ID="ListaEditarProvinciaTerritorio" runat="server" DataSourceID="SQLTerritorios" DataTextField="Territorio" DataValueField="Territorio" Height="200px" Width="150px"></asp:ListBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 527px">
                                    
                                            </td>
                                            <td style="width: 28px">&nbsp;</td>
                                            <td style="width: 156px">
                                                <asp:Button ID="btnActualizarUbicacion" runat="server" Text="Actualizar" Width="138px" CssClass="form-control" Enabled="False" OnClick="btnActualizarUbicacion_Click" />
                                            </td>
                                            <td style="width: 113px">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="viewCrearProvincia" runat="server">
                                    <table class="nav-justified">
                                        <tr>
                                            <td style="width: 527px; vertical-align: top;">Ubicaciones</td>
                                            <td style="width: 28px">&nbsp;</td>
                                            <td style="width: 156px">País</td>
                                            <td style="width: 113px">Territorio</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 527px; vertical-align: top;">
                                                Nombre de la Provincia:<br />
                                                <asp:TextBox ID="txtNuevaProvincia" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtNuevaProvincia_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="width: 28px">&nbsp;</td>
                                            <td style="width: 156px">
                                                <asp:ListBox ID="ListaNuevaProvinciaPais" runat="server" DataSourceID="SQLPaises" DataTextField="Pais" DataValueField="Pais" Height="200px" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ListaNuevaProvinciaPais_SelectedIndexChanged"></asp:ListBox>
                                            </td>
                                            <td style="width: 113px">
                                                <asp:ListBox ID="ListaNuevaProvinciaTerritorio" runat="server" DataSourceID="SQLTerritorios" DataTextField="Territorio" DataValueField="Territorio" Height="200px" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ListaNuevaProvinciaTerritorio_SelectedIndexChanged"></asp:ListBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 527px; vertical-align: top;">
                                    
                                            </td>
                                            <td style="width: 28px">&nbsp;</td>
                                            <td style="width: 156px">
                                                <asp:Button ID="btnAltanuevaProvincia" runat="server" Text="Crear" Width="138px" CssClass="form-control" Enabled="False" OnClick="btnAltanuevaProvincia_Click" />
                                            </td>
                                            <td style="width: 113px">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>&nbsp;
                        
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
<asp:SqlDataSource ID="SQLocalizaciones" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="select distinct(localizacion) from usuarios where localizacion not in (select localizacion from localizacion) ORDER BY Localizacion"></asp:SqlDataSource>     
<asp:SqlDataSource ID="SQLLocalizacionesRegistradas" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Localizacion], [Provincia] FROM [Localizacion] ORDER BY [Localizacion] ASC"></asp:SqlDataSource>
<asp:SqlDataSource ID="SQLTerritorios" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Territorio] FROM [Territorio] ORDER BY Territorio ASC"></asp:SqlDataSource>
<asp:SqlDataSource ID="SQLPaises" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Pais] FROM [Pais] ORDER BY Pais ASC"></asp:SqlDataSource>
<asp:SqlDataSource ID="SQLProvincias" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Provincia]" OnSelecting="SQLProvincias_Selecting"></asp:SqlDataSource>
</asp:Content>
