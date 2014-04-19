<%@ Page Title="Patrocinadores / Colaboradores" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Sponsors.aspx.cs" Inherits="ClubSite.AdminPages.Sponsors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <ext:TabPanel ID="TabPanel1"
        Title="Patrocinadores/Colaboradores"
        runat="server"
        Width="750"
        Height="735"
        DeferredRender="false">
        <Items>
            <ext:Panel
                ID="PaDatosPrincipales"
                runat="server"
                Title="Datos Principales"
                Frame="true"
                PaddingSummary="5px 5px 0"
                Width="700"
                ButtonAlign="Center">
                <Items>
                    <ext:Container ID="Container1" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxId" runat="server" FieldLabel="Código :" LabelAlign="Top" Width="50" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                            <ext:TextField ID="txbxRegDate" runat="server" FieldLabel="Fecha :" LabelAlign="Top" Width="100" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                            <ext:Checkbox ID="chbcActivo" runat="server" FieldLabel="Activo :" LabelAlign="Top" Width="100" Padding="5" />
                            <ext:TextField ID="txbxNombre" runat="server" FieldLabel="Nombre :" LabelAlign="Top" Width="438" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container2" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:FormPanel
                                ID="FormLogoPanel"
                                runat="server"
                                Width="350"
                                Margins="0 12 0 0"
                                Frame="true"
                                Title="Logotipo Sponsor"
                                PaddingSummary="0px 0px 0px 0px"
                                LabelWidth="50">
                                <Defaults>
                                    <ext:Parameter Name="anchor" Value="95%" Mode="Value" />
                                    <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                                    <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                                </Defaults>
                                <Items>
                                    <ext:Image ID="imgLogo" runat="server" Height="140" Width="210" AlternateText="Logo Sponsor" Padding="5" Border="true" />
                                    <ext:FileUploadField
                                        ID="FileULogo"
                                        runat="server"
                                        EmptyText="Seleccione una imagen..."
                                        FieldLabel="URL logo :"
                                        ButtonText=""
                                        Icon="ImageAdd" />
                                </Items>
                                <Listeners>
                                    <ValidityChange Handler="#{btnCargarLogo}.setDisabled(!valid);" />
                                </Listeners>
                                <Buttons>
                                    <ext:Button ID="btnCargarLogo" runat="server" Text="Cargar" Disabled="true">
                                        <DirectEvents>
                                            <Click
                                                OnEvent="UploadLogoClick"
                                                Before="if (!#{FormLogoPanel}.getForm().isValid()) { return false; } 
                                Ext.Msg.wait('Subiendo la imagen...', 'Subiendo');"
                                                Failure="Ext.Msg.show({ 
                                title   : 'Error', 
                                msg     : 'Error durante la subida de la imagen', 
                                minWidth: 200, 
                                modal   : true, 
                                icon    : Ext.Msg.ERROR, 
                                buttons : Ext.Msg.OK 
                            });">
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnBorrarLogo" runat="server" Text="Borrar">                                        
                                        <Listeners>
                                            <Click Handler="App.direct.BorrarLogoClick();" />
                                        </Listeners>
                                    </ext:Button>
                                </Buttons>
                            </ext:FormPanel>
                            <ext:FormPanel
                                ID="FormImgPanel"
                                runat="server"
                                Width="350"
                                Frame="true"
                                Title="Imagen Sponsor"
                                Margins="0 0 0 12"
                                PaddingSummary="0px 0px 0px 0px"
                                LabelWidth="50">
                                <Defaults>
                                    <ext:Parameter Name="anchor" Value="95%" Mode="Value" />
                                    <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                                    <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                                </Defaults>
                                <Items>
                                    <ext:Image ID="imgImage" runat="server" Height="140" Width="200" AlternateText="Imagen 2 Sponsor" Padding="5" Border="true" />
                                    <ext:FileUploadField
                                        ID="FileUImg"
                                        runat="server"
                                        EmptyText="Seleccione una imagen..."
                                        FieldLabel="URL Imagen :"
                                        ButtonText=""
                                        Icon="ImageAdd" />
                                </Items>
                                <Listeners>
                                    <ValidityChange Handler="#{btnCargarImg}.setDisabled(!valid);" />
                                </Listeners>
                                <Buttons>
                                    <ext:Button ID="btnCargarImg" runat="server" Text="Cargar" Disabled="true">
                                        <DirectEvents>
                                            <Click
                                                OnEvent="UploadImgClick"
                                                Before="if (!#{FormImgPanel}.getForm().isValid()) { return false; } 
                                Ext.Msg.wait('Uploading your photo...', 'Uploading');"
                                                Failure="Ext.Msg.show({ 
                                title   : 'Error', 
                                msg     : 'Error during uploading', 
                                minWidth: 200, 
                                modal   : true, 
                                icon    : Ext.Msg.ERROR, 
                                buttons : Ext.Msg.OK 
                            });">
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnBorrarImg" runat="server" Text="Borrar">
                                        <DirectEvents>
                                            <Click OnEvent="BorrarImgClick" />
                                        </DirectEvents>
                                    </ext:Button>
                                </Buttons>
                            </ext:FormPanel>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container3" runat="server" Layout="FormLayout">
                        <Items>
                            <ext:GridPanel ID="GPSponsors"
                                runat="server"
                                Title="Listado de Colaboradores/Sponsors"
                                Frame="true"
                                Height="340">
                                <Store>
                                    <ext:Store ID="StoreGPSponsors" runat="server" DataSourceID="SqlDSGPSponsors" PageSize="10">
                                        <Model>
                                            <ext:Model ID="Model1" runat="server" IDProperty="SponsorId">
                                                <Fields>
                                                    <ext:ModelField Name="SponsorId" />
                                                    <ext:ModelField Name="Activo" Type="Boolean" />
                                                    <ext:ModelField Name="RegDate" Type="Date" />
                                                    <ext:ModelField Name="Nombre" />
                                                    <ext:ModelField Name="AportInicial" />
                                                    <ext:ModelField Name="AportRecibida" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:Column ID="Column1" runat="server" DataIndex="SponsorId" Text="Cód" Width="30" />
                                        <ext:CheckColumn ID="Column2" runat="server" DataIndex="Activo" Text="Activo" Width="50" />
                                        <ext:DateColumn ID="Column3" runat="server" DataIndex="RegDate" Text="Alta" Width="70" Format="dd/MM/yyyy" />
                                        <ext:Column ID="Column4" runat="server" DataIndex="Nombre" Text="Nombre" Width="300" />
                                        <ext:Column ID="Column5" runat="server" DataIndex="AportInicial" Text="Ap. Pac." Width="100">
                                            <Renderer Format="EuroMoney" />
                                        </ext:Column>
                                        <ext:Column ID="Column6" runat="server" DataIndex="AportRecibida" Text="Ap Rec." Width="100">
                                            <Renderer Format="EuroMoney" />
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:GridView ID="GVSponsors1" runat="server" StripeRows="true">
                                        <GetRowClass Handler="return 'x-grid-row-expanded';" />
                                    </ext:GridView>
                                </View>
                                <SelectionModel>
                                    <ext:CellSelectionModel ID="CellSelectionModel1" runat="server">
                                        <DirectEvents>
                                            <Select OnEvent="GPSponsors_CellClick" />
                                        </DirectEvents>
                                    </ext:CellSelectionModel>
                                </SelectionModel>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server">
                                        <Items>
                                            <ext:Label ID="Label7" runat="server" Text="Reg/Página :" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="1" />
                                                    <ext:ListItem Text="2" />
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="20" />
                                                </Items>
                                                <SelectedItems>
                                                    <ext:ListItem Value="10" />
                                                </SelectedItems>
                                                <Listeners>
                                                    <Select Handler="#{GridPanel1}.store.pageSize = parseInt(this.getValue(), 10); #{GridPanel1}.store.reload();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                        <Plugins>
                                            <ext:ProgressBarPager ID="ProgressBarPager1" runat="server" />
                                        </Plugins>
                                    </ext:PagingToolbar>
                                </BottomBar>
                                <TopBar>
                                    <ext:Toolbar ID="Toolbar1" runat="server">
                                        <Items>
                                            <ext:Button ID="Button4" runat="server" Text="Imprimir" Icon="Printer" Handler="this.up('grid').print();" />
                                            <ext:Button ID="Button5" runat="server" Text="Imprimir Página" Icon="Printer" Handler="this.up('grid').print({currentPageOnly : true});" />
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                            </ext:GridPanel>
                        </Items>
                    </ext:Container>
                </Items>
                <Buttons>
                    <ext:Button ID="btnNuevo" runat="server" Text="Nuevo" Width="150">
                        <Listeners>
                            <Click Handler="App.direct.AskNew();" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="btnGrabar" runat="server" Text="Grabar" Width="150px">
                        <Listeners>
                            <Click Handler="App.direct.AskSave();" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="btnCancel" runat="server" Text="Deshacer" Width="150px">
                        <Listeners>
                            <Click Handler="App.direct.AskCancel();" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="btnBorrar" runat="server" Text="Borrar" Width="150px">
                        <Listeners>
                            <Click Handler="App.direct.AskDel();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Panel>

            <ext:Panel
                ID="PaOtrosDatos"
                runat="server"
                Title="Otros Datos"
                Frame="true"
                PaddingSummary="5px 5px 0"
                Width="700"
                ButtonAlign="Center">
                <Items>
                    <ext:Container ID="Container5" runat="server" Layout="FormLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxContacto" runat="server" FieldLabel="Persona de Contacto :" LabelAlign="Top" Width="410" Padding="5" />
                            <ext:TextField ID="txbxBlogURL" runat="server" FieldLabel="Web Site :" LabelAlign="Top" Width="410" Padding="5" />
                            <ext:TextField ID="txbxEMail" runat="server" FieldLabel="Correo Electrónico :" LabelAlign="Top" Width="410" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container6" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxTlf" runat="server" FieldLabel="Tlf Fijo :" LabelAlign="Top" Width="200" Padding="5" />
                            <ext:TextField ID="txbxMobile" runat="server" FieldLabel="Móvil :" LabelAlign="Top" Width="200" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container7" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxStreet" runat="server" FieldLabel="Calle :" LabelAlign="Top" Width="600" Padding="5" />
                            <ext:TextField ID="txbxNumber" runat="server" FieldLabel="Nº :" LabelAlign="Top" Width="100" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container8" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxCity" runat="server" FieldLabel="Población :" LabelAlign="Top" Width="300" Padding="5" />
                            <ext:TextField ID="txbxPostalCode" runat="server" FieldLabel="C.Postal :" LabelAlign="Top" Width="90" Padding="5" />
                            <ext:TextField ID="txbxCountry" runat="server" FieldLabel="País :" LabelAlign="Top" Width="300" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container9" runat="server" Layout="FormLayout" ColumnWidth=".5" Padding="5">
                        <Items>
                            <ext:TextArea ID="txbxMemo" runat="server" FieldLabel="Descripción :" LabelAlign="Top" Width="710" Height="100" Padding="5" />
                        </Items>
                    </ext:Container>
                </Items>

            </ext:Panel>

            <ext:Panel
                ID="PaCondiciones"
                runat="server"
                Title="Condiciones"
                Frame="true"
                PaddingSummary="5px 5px 0"
                Width="700"
                ButtonAlign="Center">
                <Items>
                    <ext:Container ID="Container10" runat="server" Layout="FormLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxAportInicial" runat="server" FieldLabel="Aportación Pactada :" LabelAlign="Top" Width="200" Padding="5" />
                            <ext:TextField ID="txbxAportRecibida" runat="server" FieldLabel="Aportación Recibida :" LabelAlign="Top" Width="200" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container11" runat="server" Layout="FormLayout" ColumnWidth=".5" Padding="5">
                        <Items>
                            <ext:TextArea ID="txbxCondOfertadas" runat="server" FieldLabel="Condiciones ofertadas :" LabelAlign="Top" Width="710" Height="300" Padding="5" />
                        </Items>
                    </ext:Container>
                </Items>

            </ext:Panel>

            <ext:Panel
                ID="PaLocGeo"
                runat="server"
                Title="Localización Geográfica"
                Frame="true"
                PaddingSummary="5px 5px 0"
                Width="700"
                ButtonAlign="Center">
                <Items>
                    <ext:Container ID="Container12" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxLongitud" runat="server" FieldLabel="Longitud :" LabelAlign="Top" Width="100" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                            <ext:TextField ID="txbxLatitud" runat="server" FieldLabel="Latitud :" LabelAlign="Top" Width="100" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container13" runat="server" Layout="FormLayout" ColumnWidth=".5" Padding="5">
                        <Items>
                            <ext:TextArea ID="TextArea1" runat="server" FieldLabel="Mapa de google para coger coordenadas :" LabelAlign="Top" Width="710" Height="100" Padding="5" />
                        </Items>
                    </ext:Container>
                </Items>

            </ext:Panel>
        </Items>
    </ext:TabPanel>

    <asp:SqlDataSource ID="SqlDSGPSponsors" runat="server" ConnectionString="<%$ ConnectionStrings:ClubSiteConn %>"
        SelectCommand="SELECT * FROM Sponsors ORDER BY Sponsors.Nombre"></asp:SqlDataSource>

    <%--<asp:SqlDataSource ID="SqlDSGPRaces" runat="server" ConnectionString="<%$ ConnectionStrings:ClubSiteConn %>"
        SelectCommand="SELECT Races.Id, Races.Name, Races.RaceDate, Races.RaceTypeId, Races.Address_City, 
                                       Races.Address_Country, RaceTypes.Name AS Expr1
                                       FROM Races INNER JOIN RaceTypes ON RaceTypes.RaceTypeID = Races.RaceTypeId 
                                       ORDER BY Races.RaceDate DESC, Races.Name"></asp:SqlDataSource>--%>




    <%--    <style type="text/css">
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
                <asp:Image ID="imgLogoURL1" runat="server" Style="height: 120px; width: 100px; border: solid" AlternateText="Logo Sponsor" />
                <br />
                <asp:Button Text="Borrar" runat="server" ID="btnBorraLogo" OnClick="btnBorraLogo_Click" />
                <asp:Button Text="Subir" runat="server" ID="btnSubeLogo" OnClick="btnSubeLogo_Click" />
                <asp:FileUpload ID="FileUploadLogo" runat="server" /><br />
            </td>
            <td class="auto-style8">
                <asp:Label ID="Label1" runat="server" Text="Id :" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txbxId1" runat="server" Width="50px" ReadOnly="true" BorderStyle="None" Font-Bold="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label2" runat="server" Text="Nombre :" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txbxNombre1" runat="server" Width="300px"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label3" runat="server" Text="Contacto :" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txbxContacto1" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label4" runat="server" Text="Fecha Alta :" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbxRegDate1" runat="server" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </td>
            <td class="auto-style6">
                <asp:Label ID="Label9" runat="server" Text="Activo :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:CheckBox ID="chbcActivo1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2">
                <asp:Label ID="Label5" runat="server" Text="Aport. Pactada :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txbxAportInicial1" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="2" class="auto-style1">
                <asp:Image ID="imgImageURL1" runat="server" Style="height: 120px; width: 100px; border: solid" AlternateText="Imagen" />&nbsp;                
                <br />
                <asp:Button ID="btnBorraImage" Text="Borrar" runat="server" OnClick="btnBorraImage_Click" />
                <asp:Button Text="Subir" runat="server" ID="btnSubirImage" OnClick="btnSubirImage_Click" />
                <asp:FileUpload ID="FileUploadImage" runat="server" /><br />
            </td>
            <td class="auto-style2" colspan="2">
                <asp:Label ID="Label10" runat="server" Text="Aport. Recibida :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txbxAportRecibida1" runat="server" Width="80px"></asp:TextBox>
            </td>
            <td class="auto-style6">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">

                <asp:Label ID="Label6" runat="server" Text="Condiciones Pactadas :" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txbxCondOfertadas1" runat="server" Height="100px" TextMode="MultiLine" Width="522px"></asp:TextBox>

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
                <asp:TextBox ID="txbxBlogURL1" runat="server" Width="310px"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="LaMovil" runat="server" Text="Móvil :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxMobile1" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaEMail" runat="server" Text="e-mail :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxEMail1" runat="server" Width="310px"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="LaTlf" runat="server" Text="Tlf :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxTlf1" runat="server" Width="100px"></asp:TextBox>
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
                <asp:TextBox ID="txbxStreet1" runat="server" Width="310px"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="LaNumero" runat="server" Text="Número :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxNumber1" runat="server" Width="50px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaPoblacion" runat="server" Text="Población :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxCity1" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="LaPais" runat="server" Text="País :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxCountry1" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style3">
                <asp:Label ID="LaCPostal" runat="server" Text="C.Postal :" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txbxPostalCode1" runat="server" Width="100px"></asp:TextBox>
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
                <asp:TextBox ID="txbxMemo1" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
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

    </table>--%>
</asp:Content>
