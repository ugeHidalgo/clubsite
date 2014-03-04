<%@ Page Title="Pruebas" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Races.aspx.cs" Inherits="ClubSite.AdminPages.Races" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">


    <table class="auto-style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Id :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxID" runat="server" Width="117px" ReadOnly="true" BorderStyle="None" Font-Bold="True"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Fecha :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxDate" runat="server" Width="117px" ReadOnly="true" BorderStyle="None" Font-Bold="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Prueba :" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="5">
                <asp:TextBox ID="txbxName" runat="server" Width="565px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Tipo :" Font-Bold="True"></asp:Label>
            </td>            
            <td colspan="5">
                <asp:TextBox ID="txbxRaceTypeID" runat="server" BorderStyle="None" Font-Bold="true" Width="20px" style="text-align: right"></asp:TextBox>
                <asp:DropDownList ID="ddlRaceTypes" SelectMethod="ddlRaceTypes_GetData" runat="server" Width="350px"
                    DataTextField="Name" DataValueField="RaceTypeID" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlRaceTypes_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>


    <table class="auto-style1">
        <tr>
            <td colspan="2" class="auto-style3" style="text-align: center">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" Width="150px"
                    OnClientClick="javascript:if(!confirm('Crear un nueva carrera.¿Continuamos?'))return false"
                    OnClick="btnNuevo_Click" />&nbsp;             
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="150px"
                    OnClientClick="javascript:if(!confirm('Vas a grabar los datos de la carrera en pantalla.¿Continuamos?'))return false"
                    OnClick="btnGrabar_Click" />&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Deshacer" Width="90px"
                    OnClientClick="javascript:if(!confirm('Sin cancelas ahora se perderan los datos que hayas cambiado.¿Cancelamos?'))return false"
                    OnClick="btnCancelar_Click" />&nbsp;
                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" Width="150px"
                    OnClientClick="javascript:if(!confirm('¿Borramos la carrera actualmente en pantalla?'))return false"
                    OnClick="btnBorrar_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style3" style="text-align: center">
                <asp:DropDownList ID="ddlRaces" runat="server" AutoPostBack="true" DataTextField="Name" DataValueField="Id"
                    SelectMethod="ddlRaces_GetData" Width="300px" OnSelectedIndexChanged="ddlRaces_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="width: 950px; margin: auto;">
                    <asp:GridView ID="gvRaces" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
                        AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="gvRaces_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="RaceDate" HeaderText="RaceDate" SortExpression="RaceDate" />
                            <asp:BoundField DataField="RaceTypeId" HeaderText="RaceTypeId" SortExpression="RaceTypeId" />
                            <asp:BoundField DataField="Address_City" HeaderText="Address_City" SortExpression="Address_City" />
                            <asp:BoundField DataField="Address_Country" HeaderText="Address_Country" SortExpression="Address_Country" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ClubSiteConn %>" SelectCommand="SELECT [Id], [Name], [RaceDate], [RaceTypeId], [Address_City], [Address_Country] FROM [Races] ORDER BY [RaceDate] DESC, [Name]"></asp:SqlDataSource>
                    <br style="color: #333333" />

                </div>
            </td>
        </tr>
    </table>

</asp:Content>
