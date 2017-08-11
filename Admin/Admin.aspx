<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoAdmin" Runat="Server">
    <p>
    Usuarios Registrados en el Servicio:</p>
<p>
    <table class="nav-justified">
        <tr>
            <td style="width: 343px" rowspan="2">
    <asp:GridView ID="ListaUsuarios" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SQL_Usuarios" ForeColor="#333333" GridLines="None" Height="195px" Width="359px" AllowPaging="True" OnSelectedIndexChanged="ListaUsuarios_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
            </td>
            <td style="width: 30px">
                            &nbsp;</td>
            <td>Usuario:<br />
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtUsuario_TextChanged" />
                            <br />
                            eMail:<br />
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtEmail_TextChanged" />
                            <br />
                            Gestión de Roles del Usuario:<br __designer:mapid="1b6" />
                <table class="auto-style2" style="width: 36%" __designer:mapid="1b7">
                    <tr __designer:mapid="1b8">
                        <td style="padding: 0px; margin: 0px;" __designer:mapid="1b9">
                            Roles no asignados al usuario<asp:ListBox ID="ListaRoles" runat="server" DataTextField="Name" DataValueField="id" Height="151px" SelectionMode="Multiple" Width="238px" DataSourceID="SQLRolesNoAsignados"></asp:ListBox>
                            <asp:SqlDataSource ID="SQLRolesNoAsignados" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT id, Name from AspNetRoles WHERE Id NOT IN (select aspnetroles.id FROM AspNetRoles join AspNetUserRoles on AspNetRoles.Id = AspNetUserRoles.RoleId JOIN AspNetUsers ON AspNetUsers.Id=AspNetUserRoles.UserId WHERE AspNetUsers.UserName = @Usuario)">
                                <SelectParameters>
                                    <asp:Parameter Name="Usuario" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                        <td style="padding: 0px; margin: 0px;" __designer:mapid="1bb">
                            <br __designer:mapid="1bd" />

                            <asp:Button ID="btnMas" runat="server" Text="&gt;" Width="31px" style="height: 26px" OnClick="btnMas_Click" />
                            <br __designer:mapid="1bd" />
                            <asp:Button ID="btnMenos" runat="server" Text="&lt;" Width="31px" style="height: 26px" OnClick="btnMenos_Click" />

                        </td>
                        <td style="padding: 0px; margin: 0px" __designer:mapid="1bf">Roles asignados al usuario<asp:ListBox ID="ListaRolesAsignados" runat="server" DataTextField="Name" DataValueField="id" Height="151px" SelectionMode="Multiple" Width="238px" DataSourceID="SQLRolesAsignados"></asp:ListBox>
                            <asp:SqlDataSource ID="SQLRolesAsignados" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="select aspnetroles.Name, aspnetroles.id FROM AspNetRoles join AspNetUserRoles on AspNetRoles.Id = AspNetUserRoles.RoleId JOIN AspNetUsers ON AspNetUsers.Id=AspNetUserRoles.UserId WHERE AspNetUsers.UserName = @Usuario">
                                <SelectParameters>
                                    <asp:Parameter Name="Usuario" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 30px">&nbsp;</td>
            <td>
                            <asp:Button ID="btnEliminarUsuario" runat="server" Text="Eliminar Usuario" Width="130px" OnClick="btnEliminarUsuario_Click" />
                            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SQL_Usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [UserName], [Email] FROM [AspNetUsers]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SQL_DetalleUsuario" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [UserName], [Email] FROM [AspNetUsers] WHERE ([UserName] = @UserName)">
        <SelectParameters>
            <asp:Parameter Name="UserName" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SQLIDUsuario" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id FROM AspNetUsers WHERE (UserName = @Usuario)">
        <SelectParameters>
            <asp:Parameter Name="Usuario" />
        </SelectParameters>
    </asp:SqlDataSource>
</p>
</asp:Content>
