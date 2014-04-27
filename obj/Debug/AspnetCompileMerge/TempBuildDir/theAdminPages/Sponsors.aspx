<%@ Page Title="Patrocinadores / Colaboradores" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Sponsors.aspx.cs" Inherits="ClubSite.AdminPages.Sponsors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <script type="text/javascript"
        src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDS7Syd76e3allIrLsYVfIcJ43kZ0NnHiI&sensor=false">
    </script>

    <script type="text/javascript">
        var map;
        var marker;
        function initializeMap(StrLatitud,StrLongitud,Nombre) {            
            var Latitud = parseFloat(StrLatitud);
            var Longitud = parseFloat(StrLongitud);            
            var mapOptions = {
                zoom: 13,
                center: new google.maps.LatLng(Latitud, Longitud)
            };
            map = new google.maps.Map(document.getElementById('cpMainContent_map_canvas-body'),
                mapOptions);

            marker = new google.maps.Marker({
                position: new google.maps.LatLng(Latitud, Longitud),
                map: map,
                title: Nombre
            });


            // Set the position for the marker.
            function setMarkerPosition(location) {
                //Set new position for marker
                marker.setPosition(location);
                
                //Puts new position data into form
                document.getElementsByName("cpMainContent_txbxLatitud")[0].value = location.lat().toFixed(6);
                document.getElementsByName("cpMainContent_txbxLongitud")[0].value = location.lng().toFixed(6);
            }

            //Zoom over marker when click over it.
            google.maps.event.addListener(marker, 'click', function () {
                map.setZoom(18);
                map.setCenter(marker.getPosition());                
            });

            //Set new position for marker when click over map
            google.maps.event.addListener(map, 'click', function(event) {
                setMarkerPosition(event.latLng);
            });

        }
    </script>

    <ext:TabPanel ID="TabPanel1"
        Title="Patrocinadores/Colaboradores"
        runat="server"
        Width="750"
        Height="735">

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
                    <ext:Container ID="Container12" runat="server" Layout="ColumnLayout" Padding="5">
                        <Items>                            
                            <ext:TextField ID="txbxLongitud" runat="server" FieldLabel="Longitud :" LabelAlign="Right" Width="200" 
                                 PaddingSpec="0 0 0 5" ReadOnly="true" Cls="ReadOnly" />
                            <ext:TextField ID="txbxLatitud" runat="server" FieldLabel="Latitud :" LabelAlign="Right"  Width="200" 
                                PaddingSpec="0 0 0 5" ReadOnly="true" Cls="ReadOnly" />                            
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container13" runat="server" Layout="FormLayout" ColumnWidth=".5" Padding="5">
                        <Items>
                            <ext:Panel runat="server" ID="map_canvas" Layout="FitLayout" Height="500">
                            </ext:Panel>
                        </Items>
                    </ext:Container>
                </Items>
                <Listeners>
                    <Show Handler="initializeMap(#{txbxLatitud}.getValue(),#{txbxLongitud}.getValue(),#{txbxNombre}.getValue())" />
                </Listeners>
            </ext:Panel>
        </Items>

    </ext:TabPanel>

    <asp:SqlDataSource ID="SqlDSGPSponsors" runat="server" ConnectionString="<%$ ConnectionStrings:ClubSiteConn %>"
        SelectCommand="SELECT * FROM Sponsors ORDER BY Sponsors.Nombre"></asp:SqlDataSource>
</asp:Content>
