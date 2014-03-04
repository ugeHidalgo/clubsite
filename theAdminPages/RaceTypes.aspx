<%@ Page Title="Tipos de Pruebas" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="RaceTypes.aspx.cs" Inherits="ClubSite.AdminPages.RaceTypes" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
     <table class="auto-style1">
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label5" runat="server" Text="Id :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxId" runat="server" BorderStyle="None" Font-Bold="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Deporte :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxSportID" runat="server" BorderStyle="None" Font-Bold="true" Width="20px" style="text-align: right"></asp:TextBox>
                <asp:DropDownList ID="ddlDeportes" SelectMethod="ddlDeportes_GetData" runat="server" Width="150px"
                    DataTextField="Name" DataValueField="SportID" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlDeportes_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Nombre :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxName" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Puntos partic. :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxPuntos" runat="server" Width="80px" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label4" runat="server" Text="Observaciones :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxMemo" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style3" style="text-align: center">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" Width="150px"
                    OnClientClick="javascript:if(!confirm('Crear un nuevo tipo de carrera.¿Continuamos?'))return false"
                    OnClick="btnNuevo_Click" />&nbsp;             
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="150px"
                    OnClientClick="javascript:if(!confirm('Vas a grabar los datos del tipo de carrera en pantalla.¿Continuamos?'))return false"
                    OnClick="btnGrabar_Click" />&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Deshacer" Width="90px"
                    OnClientClick="javascript:if(!confirm('Sin cancelas ahora se perderan los datos que hayas cambiado.¿Cancelamos?'))return false"
                    OnClick="btnCancelar_Click" />&nbsp;
                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" Width="150px"
                    OnClientClick="javascript:if(!confirm('¿Borramos el tipo de carrera actualmente en pantalla?'))return false"
                    OnClick="btnBorrar_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="width: 950px; margin: auto;">                    
                    <asp:GridView ID="gvRaceTypes" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RaceTypeID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="gvRaceTypes_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Selec." />
                            <asp:BoundField DataField="RaceTypeID" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="RaceTypeID">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Expr1" HeaderText="Deporte" SortExpression="Expr1">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Tipo de Carrera" SortExpression="Name">
                                <ItemStyle Width="250px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Points" HeaderText="Pts" SortExpression="Points">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Memo" HeaderText="Memo" SortExpression="Memo">
                                <ItemStyle Width="450px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SportID" HeaderText="SportID" SortExpression="SportID" Visible="False" />
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
                    <br style="color: #333333" />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:ClubSiteConn %>"
                        SelectCommand="SELECT RaceTypes.RaceTypeID, RaceTypes.Name, RaceTypes.Points, RaceTypes.Memo, RaceTypes.SportID, Sports.Name AS Expr1 FROM RaceTypes INNER JOIN Sports ON RaceTypes.SportID = Sports.SportID ORDER BY RaceTypes.Name"></asp:SqlDataSource>
                </div>
            </td>
        </tr>
    </table>

</asp:Content>
