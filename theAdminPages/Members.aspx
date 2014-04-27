<%@ Page Title="Miembros" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="ClubSite.AdminPages.Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 304px;
        }

        .auto-style2 {
            width: 155px;
            text-align: right;
        }

        .auto-style3 {
            width: 180px;
            text-align: right;
        }

        .auto-style4 {
            text-align: left;
        }

        .auto-style5 {
            text-align: right;
            width: 150px;
        }

        .auto-style6 {
            width: 200px;
        }

        .auto-style7 {
            text-align: left;
            width: 180px;
        }

        .auto-style8 {
            text-align: left;
            width: 300px;
        }
    </style>

    <table style="width: 800px; margin: 5px auto 5px 5px; border: thin;">
        <tr>
            <td rowspan="4" class="auto-style1">
                <asp:Image ID="imgNImageURL" runat="server" Style="height: 120px; width: 100px; border: solid" AlternateText="Nº de equipo" />&nbsp;                
                <br />
                <asp:Button Text="Borrar" runat="server" ID="btnBorraNImage" OnClick="btnBorraNImage_Click" />
                <asp:Button Text="Subir" runat="server" ID="btnSubirNImage" OnClick="btnSubirNImage_Click" />
                <asp:FileUpload ID="FileUploadNumber" runat="server" /><br />
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txbxUserName" runat="server" Width="117px" ReadOnly="true" BorderStyle="None" Font-Bold="True" />
            </td>
            <td>
                <asp:DropDownList ID="ddlMembers" runat="server" AutoPostBack="true" DataTextField="UserName" DataValueField="UserName"
                    SelectMethod="ddlMembers_GetData" Width="313px" OnSelectedIndexChanged="ddlMembers_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="Nombre :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxFirstName" runat="server" Width="117px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label3" runat="server" Text="Apellidos :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxSecondName" runat="server" Width="313px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label4" runat="server" Text="DNI :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxDNI" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td rowspan="5" class="auto-style1">
                <asp:Image ID="imgImageURL" runat="server" Style="height: 120px; width: 100px; border: solid" AlternateText="Imagen" />&nbsp;                
                <br />
                <asp:Button ID="btnBorraImage" Text="Borrar" runat="server" OnClick="btnBorraImage_Click" />
                <asp:Button Text="Subir" runat="server" ID="btnSubirImage" OnClick="btnSubirImage_Click" />
                <asp:FileUpload ID="FileUploadImage" runat="server" /><br />
            </td>
            <td class="auto-style2">
                <asp:Label ID="Label5" runat="server" Text="Fecha Nacimiento :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxBdate" runat="server" Width="87px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label6" runat="server" Text="Usuario Activo :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chBxActiveUser" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label12" runat="server" Text="Número Clubber :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxClubberNumber" runat="server" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label7" runat="server" Text="Federado :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chbxFederated" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label9" runat="server" Text="Visible en la Web :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chbxVisible" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
    </table>

    <table style="width: 800px; margin: 5px auto 5px 5px; border: thin;">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label11" runat="server" Text="Blog/Web :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4" colspan="4">
                <asp:TextBox ID="txbxBlogURL" runat="server" Width="310px"></asp:TextBox>
            </td>
            <td class="auto-style6" colspan="2">

                <asp:Label ID="Label10" runat="server" Text="Carreras :" Font-Bold="True"></asp:Label>

            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaEMail" runat="server" Text="e-mail :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4" colspan="4">
                <asp:TextBox ID="txbxEMail" runat="server" Width="310px"></asp:TextBox>
            </td>
            <td class="auto-style4" colspan="2">
                <asp:DropDownList ID="ddlRaces" runat="server" Width="300px" SelectMethod="dllRaces_GetData"
                    DataTextField="aRace" DataValueField="Id" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style4" colspan="3"></td>
            <td colspan="2">&nbsp;</td>
            <td class="auto-style6">
                <asp:Button ID="btnAddRace" runat="server" Text="+"
                    OnClientClick="javascript:if(!confirm('¿Añadimos la carrera seleccionada a la lista de carreras del clubber?'))return false"
                    OnClick="btnAddRace_Click" />
                <asp:Button ID="btnDelrace" runat="server" Text="-"
                    OnClientClick="javascript:if(!confirm('¿Quitamos la carrera seleccionada de la lista?'))return false"
                    OnClick="btnDelrace_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaCalle" runat="server" Text="Calle :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:TextBox ID="txbxStreet" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:Label ID="LaNumero" runat="server" Text="Nº :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txbxNumber" runat="server" Width="50px"></asp:TextBox>
            </td>
            <td colspan="2">&nbsp                           
            </td>
            <td rowspan="6" class="auto-style6">
                <asp:ListBox ID="ListBox1" runat="server" Width="300px" Height="200px"></asp:ListBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaPoblacion" runat="server" Text="Población :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:TextBox ID="txbxCity" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:Label ID="LaCPostal" runat="server" Text="C.Post. :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txbxPostalCode" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td colspan="2">&nbsp;</td>
        </tr>

        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaPais" runat="server" Text="País :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4" colspan="3">
                <asp:TextBox ID="txbxCountry" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td colspan="2">&nbsp;</td>
        </tr>


        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaMovil" runat="server" Text="Móvil :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:TextBox ID="txbxMobile" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:Label ID="LaTlf" runat="server" Text="Tlf :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txbxTlf" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td colspan="2">&nbsp;</td>
        </tr>

        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style4" colspan="5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label8" runat="server" Text="Observ. :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4" colspan="5">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:TextBox ID="txbxMemo" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="text-align: center">
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="150px"
                    OnClientClick="javascript:if(!confirm('Vas a grabar los datos del ususario.¿Continuamos?'))return false"
                    OnClick="btnGrabar_Click" />&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Deshacer" Width="90px"
                    OnClientClick="javascript:if(!confirm('Sin cancelas ahora se perderan los datos que hayas cambiado.¿Cancelamos?'))return false"
                    OnClick="btnCancelar_Click" />&nbsp;
                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" Width="150px"
                    OnClientClick="javascript:if(!confirm('¿Borramos el usuario seleccionado?'))return false"
                    OnClick="btnBorrar_Click" />&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="7">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Label ID="Label1" runat="server" Text="Clubbers :" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <div style="width: 850px; margin: auto;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        DataKeyNames="UserName" ForeColor="#333333" GridLines="None"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" AllowSorting="True"
                        ItemType="ClubSite.Model.Member" SelectMethod="GridView1_GetData">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Selec." />
                            <asp:CheckBoxField DataField="State" HeaderText="Act" SortExpression="State">
                                <ItemStyle Width="25px" />
                            </asp:CheckBoxField>
                            <asp:CheckBoxField DataField="Federated" HeaderText="Fed" SortExpression="Federated" ItemStyle-Width="150px">
                                <ItemStyle Width="25px" />
                            </asp:CheckBoxField>
                            <asp:BoundField DataField="UserName" HeaderText="Usuario" ReadOnly="True" SortExpression="UserName" ItemStyle-Width="80px">
                                <ItemStyle Width="80px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="FirstName" HeaderText="Nombre" SortExpression="FirstName" ItemStyle-Width="170px">
                                <ItemStyle Width="170px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SecondName" HeaderText="Apellidos" SortExpression="SecondName" ItemStyle-Width="400px">
                                <ItemStyle Width="370px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="RegDate" HeaderText="Fecha Reg." SortExpression="RegDate" ItemStyle-Width="50px">
                                <ItemStyle Width="180px"></ItemStyle>
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
                </div>
            </td>

        </tr>

    </table>

</asp:Content>
