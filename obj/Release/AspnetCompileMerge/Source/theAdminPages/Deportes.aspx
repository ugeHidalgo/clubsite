<%@ Page Title="Deportes" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Deportes.aspx.cs" Inherits="ClubSite.theAdminPages.Deportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">


    <table class="auto-style1">
        <tr>
            <td style="text-align:right">
                <asp:Label ID="Label5" runat="server" Text="Id :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxId" runat="server" BorderStyle="None" Font-Bold="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Nombre :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxName" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
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
                    OnClientClick="javascript:if(!confirm('Crear un nuevo deporte.¿Continuamos?'))return false" 
                    OnClick="btnNuevo_Click" />&nbsp;             
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="150px" 
                    OnClientClick="javascript:if(!confirm('Vas a grabar los datos del deporte.¿Continuamos?'))return false" 
                    OnClick="btnGrabar_Click" />&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Deshacer" Width="90px" 
                    OnClientClick="javascript:if(!confirm('Sin cancelas ahora se perderan los datos que hayas cambiado.¿Cancelamos?'))return false"
                    OnClick="btnCancelar_Click" />&nbsp;
                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" Width="150px" 
                    OnClientClick="javascript:if(!confirm('¿Borramos el deporte seleccionado? Se borrarán las carreras y pruebas asociadas al deporte.'))return false"
                    OnClick="btnBorrar_Click" />
            </td>            
        </tr>
        <tr>
            <td colspan="2">
                    <div style="width: 850px; margin: auto;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Name" ForeColor="#333333" 
                         GridLines="None"  AllowPaging="True" AllowSorting="True" ItemType="ClubSite.Model.Sport" SelectMethod="GridView1_GetData" 
                         OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ButtonType="Button"  SelectText="Selec."/>
                            <asp:BoundField DataField="SportID" HeaderText="Id" ReadOnly="True" SortExpression="SportID" ItemStyle-Width="80px">
                                <ItemStyle Width="80px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" ItemStyle-Width="170px" ReadOnly="True">
                                <ItemStyle Width="170px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Memo" HeaderText="Descripción" SortExpression="Memo" ItemStyle-Width="400px" ReadOnly="True">
                                <ItemStyle Width="500px"></ItemStyle>
                            </asp:BoundField>
                        </Columns>                        
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"/>
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView> 
        
                </div>
            </td>
        </tr>
    </table>



</asp:Content>
