<%@ Page Title="Patrocinadores / Colaboradores" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Sponsors.aspx.cs" Inherits="ClubSite.AdminPages.Sponsors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 280px;
        }

        .auto-style2 {
            text-align: right;
            }

        .auto-style3 {
            text-align: right;
        }

        .auto-style4 {
            width: 304px;
            text-align: left;
        }

        .auto-style5 {
            width: 206px;
        }

        .auto-style6 {
            text-align: right;
            }

        .auto-style7 {
            width: 186px;
        }
        .auto-style8 {
            text-align: right;
            width: 253px;
        }
    </style>
    &nbsp;<asp:DropDownList ID="ddlSponsors" runat="server" AutoPostBack="true" DataTextField="Nombre" DataValueField="SponsorID" 
                     SelectMethod="ddlSponsors_GetData" Width="300px" OnSelectedIndexChanged="ddlSponsors_SelectedIndexChanged">
                </asp:DropDownList>
    <table style="width: 800px; margin: 5px auto 5px 5px; border: thin;">
        <tr>
            <td rowspan="5" class="auto-style1">
                <asp:Image ID="imgLogoURL" runat="server" Style="height: 120px; width: 100px; border: solid" AlternateText="Logo Sponsor" />                
                <br />
                <asp:Button Text="Borrar" runat="server" ID="btnBorraLogo" OnClick="btnBorraLogo_Click" />
                <asp:Button Text="Subir" runat="server" ID="btnSubeLogo" OnClick="btnSubeLogo_Click" />
                <asp:FileUpload ID="FileUploadLogo" runat="server" /><br />
            </td>
            <td class="auto-style8">
                <asp:Label ID="Label1" runat="server" Text="Id :" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txbxId" runat="server" Width="50px" ReadOnly="true" BorderStyle="None" Font-Bold="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label2" runat="server" Text="Nombre :" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txbxNombre" runat="server" Width="300px"></asp:TextBox>
                <br />                
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label3" runat="server" Text="Contacto :" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txbxContacto" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label4" runat="server" Text="Fecha Alta :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxRegDate" runat="server" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </td>
            <td class="auto-style6">
                <asp:Label ID="Label9" runat="server" Text="Activo :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:CheckBox ID="chbcActivo" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2">
                <asp:Label ID="Label5" runat="server" Text="Aport. Pactada :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txbxAportInicial" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="2" class="auto-style1">
                <asp:Image ID="imgImageURL" runat="server" Style="height: 120px; width: 100px; border: solid" AlternateText="Imagen" />&nbsp;                
                <br />
                <asp:Button ID="btnBorraImage" Text="Borrar" runat="server" OnClick="btnBorraImage_Click" />
                <asp:Button Text="Subir" runat="server" ID="btnSubirImage" OnClick="btnSubirImage_Click" />
                <asp:FileUpload ID="FileUploadImage" runat="server" /><br />
            </td>
            <td class="auto-style2" colspan="2">
                <asp:Label ID="Label10" runat="server" Text="Aport. Recibida :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txbxAportRecibida" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td class="auto-style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">

                <asp:Label ID="Label6" runat="server" Text="Condiciones Pactadas :" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txbxCondOfertadas" runat="server" Height="100px" TextMode="MultiLine" Width="522px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
    </table>

    <table style="width: 800px; margin: 5px auto 5px 5px; border: thin;">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label11" runat="server" Text="Web Site :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxBlogURL" runat="server" Width="310px"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="LaMovil" runat="server" Text="Móvil :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxMobile" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaEMail" runat="server" Text="e-mail :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxEMail" runat="server" Width="310px"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="LaTlf" runat="server" Text="Tlf :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxTlf" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaCalle" runat="server" Text="Calle :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxStreet" runat="server" Width="310px"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="LaNumero" runat="server" Text="Número :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxNumber" runat="server" Width="50px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaPoblacion" runat="server" Text="Población :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxCity" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="LaPais" runat="server" Text="País :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxCountry" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaCPostal" runat="server" Text="C.Postal :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxPostalCode" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="auto-style3">&nbsp                
            </td>
            <td class="auto-style4">&nbsp           
            </td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label8" runat="server" Text="Observaciones :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4" colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txbxMemo" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>


        <tr>
            <td colspan="4" style="text-align: center">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" Width="150px"
                    OnClientClick="javascript:if(!confirm('Crear un nuevo sponsor.¿Continuamos?'))return false"
                    OnClick="btnNuevo_Click" />&nbsp;             
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="150px"
                    OnClientClick="javascript:if(!confirm('Vas a grabar los datos del sponsor en pantalla.¿Continuamos?'))return false"
                    OnClick="btnGrabar_Click" />&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Deshacer" Width="90px"
                    OnClientClick="javascript:if(!confirm('Sin cancelas ahora se perderan los datos que hayas cambiado.¿Cancelamos?'))return false"
                    OnClick="btnCancelar_Click" />&nbsp;
                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" Width="150px"
                    OnClientClick="javascript:if(!confirm('¿Borramos el sponsor actualmente en pantalla?'))return false"
                    OnClick="btnBorrar_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td colspan="4">
                <div style="width: 950px; margin: auto;">
                    <asp:GridView ID="gvSponsors" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="SponsorId" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="gvSponsors_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Selec." />
                            <asp:BoundField DataField="SponsorId" HeaderText="Id" SortExpression="SponsorId" InsertVisible="False" ReadOnly="True">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />
                            <asp:BoundField DataField="RegDate" HeaderText="Fecha de Alta" SortExpression="RegDate">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AportInicial" HeaderText="Aportacion" SortExpression="AportInicial">
                                <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AportRecibida" HeaderText="Recibido" SortExpression="AportRecibida">
                                <ItemStyle Width="80px" />
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
                    <br style="color: #333333" />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:ClubSiteConn %>"
                        SelectCommand="SELECT [SponsorId], [Nombre], [RegDate], [AportInicial], [AportRecibida], [Activo] FROM [Sponsors] ORDER BY [Nombre]"></asp:SqlDataSource>
                </div>
            </td>
        </tr>

    </table>


</asp:Content>
