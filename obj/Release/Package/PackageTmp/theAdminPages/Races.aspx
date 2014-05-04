<%@ Page Title="Pruebas" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Races.aspx.cs" Inherits="ClubSite.AdminPages.Races" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <script type="text/javascript"
        src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDS7Syd76e3allIrLsYVfIcJ43kZ0NnHiI&sensor=false">
    </script>

    <script type="text/javascript">
        var map;
        var marker;

        function initializeMap(StrLatitud, StrLongitud, Nombre) {
            //alert('Long:' + StrLongitud + ' Lat:' + StrLatitud + ' Nombre:' + Nombre);
            if ((StrLatitud == '') || isNaN(StrLatitud))
                StrLatitud = '37.176595';
            if ((StrLongitud == '') || isNaN(StrLongitud))
                StrLongitud = '-3.598537';
            var Latitud = parseFloat(StrLatitud);
            var Longitud = parseFloat(StrLongitud);
            //alert('Long:'+Longitud+' Lat:'+Latitud+' Nombre:'+Nombre);
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

            //Zoom over marker when click over it.
            google.maps.event.addListener(marker, 'click', function () {
                map.setZoom(18);
                map.setCenter(marker.getPosition());
            });

            //Set new position for marker when click over map
            google.maps.event.addListener(map, 'click', function (event) {
                setMarkerPosition(event.latLng);
            });

        }

        function clearMapPosition() {
            document.getElementsByName("cpMainContent_txbxLatitud")[0].value = 0;
            document.getElementsByName("cpMainContent_txbxLongitud")[0].value = 0
            initializeMap(0, 0, 'Anywhere');
        }


        // Set the position for the marker.
        function setMarkerPosition(location) {
            //Set new position for marker
            marker.setPosition(location);

            //Puts new position data into form
            document.getElementsByName("cpMainContent_txbxLatitud")[0].value = location.lat().toFixed(6);
            document.getElementsByName("cpMainContent_txbxLongitud")[0].value = location.lng().toFixed(6);
        }
    </script>

    <ext:TabPanel ID="TabPanel1"
        Title="Competiciones"
        runat="server"
        Width="750"
        Height="700"
        DeferredRender="false">
        <Items>
            <ext:Panel
                ID="PaDatosPrincipales"
                runat="server"
                Title="Datos Principales"
                Frame="true"
                Width="70"
                ButtonAlign="Center">
                <Items>
                    <ext:Container ID="ContDatosPrinc" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:FormPanel
                                ID="FPDatosPrinc"
                                runat="server"
                                Width="350"
                                Height="206"
                                Frame="true"
                                Title=""
                                Margins="0 0 0 12"
                                Border="false">
                                <Defaults>
                                    <ext:Parameter Name="anchor" Value="100%" Mode="Value" />
                                    <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                                    <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                                </Defaults>
                                <Items>
                                    <ext:Container ID="Container11" runat="server" Layout="VBoxLayout" Padding="5">
                                        <Items>
                                            <ext:TextField ID="txbxID" runat="server" FieldLabel="Código :" LabelAlign="Top" Width="50" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                                            <ext:TextField ID="txbxDate" runat="server" FieldLabel="Fecha :" LabelAlign="Top" Width="100" Padding="5" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container10" runat="server" Layout="HBoxLayout" Padding="5">
                                        <Items>
                                            <ext:ComboBox ID="cbRaceTypes" runat="server" FieldLabel="Tipo de Competición :" LabelAlign="Top" Padding="5"
                                                DisplayField="Name" ValueField="RaceTypeID" Width="250px" AllowBlank="true" EmptyText="Escoja tipo de carrera">
                                                <Store>
                                                    <ext:Store ID="Store1" runat="server">
                                                        <Model>
                                                            <ext:Model ID="Model5" runat="server" IDProperty="RaceTypeID">
                                                                <Fields>
                                                                    <ext:ModelField Name="RaceTypeID" />
                                                                    <ext:ModelField Name="Name" />
                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                                <DirectEvents>
                                                    <Select OnEvent="cbRaceTypesChangeValue">
                                                    </Select>
                                                </DirectEvents>
                                            </ext:ComboBox>
                                            <ext:TextField ID="txbxPoints" runat="server" FieldLabel="Puntos :" LabelAlign="Top" Width="48" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:FormPanel>
                            <ext:Component ID="Component1" runat="server" Flex="1" />
                            <ext:FormPanel
                                ID="FormImgPanel"
                                runat="server"
                                Width="350"
                                Frame="true"
                                Title=""
                                Margins="0 0 0 12"
                                Border="false">
                                <Defaults>
                                    <ext:Parameter Name="anchor" Value="100%" Mode="Value" />
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
                    <ext:Container ID="ContName" runat="server" Layout="FormLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxName" runat="server" FieldLabel="Nombre Competición :" LabelAlign="Top" Width="720" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="ContListado" runat="server" Layout="FormLayout">
                        <Items>
                            <ext:GridPanel ID="GPRaces"
                                runat="server"
                                Title="Listado de Competiciones"
                                Frame="true"
                                Height="320">
                                <Store>
                                    <ext:Store ID="StoreGPRaces" runat="server" DataSourceID="SqlDSGPRaces" PageSize="10">
                                        <Model>
                                            <ext:Model ID="Model1" runat="server" IDProperty="Id">
                                                <Fields>
                                                    <ext:ModelField Name="Id" />
                                                    <ext:ModelField Name="RaceDate" Type="Date" />
                                                    <ext:ModelField Name="Name" />
                                                    <ext:ModelField Name="Expr1" />
                                                    <ext:ModelField Name="Address_City" />
                                                    <ext:ModelField Name="Address_Country" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:Column ID="Column1" runat="server" DataIndex="Id" Text="Cód" Width="30" />
                                        <ext:DateColumn ID="Column2" runat="server" DataIndex="RaceDate" Text="Fecha" Width="70" Format="dd/MM/yyyy" />
                                        <ext:Column ID="Column3" runat="server" DataIndex="Name" Text="Nombre" Width="200" />
                                        <ext:Column ID="Column4" runat="server" DataIndex="Expr1" Text="Tipo Carrera" Width="150" />
                                        <ext:Column ID="Column5" runat="server" DataIndex="Address_City" Text="Ciudad" Width="150" />
                                        <ext:Column ID="Column6" runat="server" DataIndex="Address_Country" Text="País" Width="150" />
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:GridView ID="GridView2" runat="server" StripeRows="true">
                                        <GetRowClass Handler="return 'x-grid-row-expanded';" />
                                    </ext:GridView>
                                </View>
                                <SelectionModel>
                                    <ext:CellSelectionModel ID="CellSelectionModel1" runat="server">
                                        <DirectEvents>
                                            <Select OnEvent="GPRaces_Cell_Click" />
                                        </DirectEvents>
                                    </ext:CellSelectionModel>
                                </SelectionModel>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server">
                                        <Items>
                                            <ext:Label ID="Label8" runat="server" Text="Reg/Página :" />
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
                    <ext:Button ID="btnCancelar" runat="server" Text="Deshacer" Width="150px">
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
                ID="PaUbicacion"
                runat="server"
                Title="Otros Datos"
                Frame="true"
                Width="700"
                ButtonAlign="Center">
                <Items>
                    <ext:Container ID="Container5" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxStreet" runat="server" FieldLabel="Calle :" LabelAlign="Top" Width="600" Padding="5" />
                            <ext:TextField ID="txbxNumber" runat="server" FieldLabel="Nº :" LabelAlign="Top" Width="100" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container6" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxCity" runat="server" FieldLabel="Población :" LabelAlign="Top" Width="300" Padding="5" />
                            <ext:TextField ID="txbxPostalCode" runat="server" FieldLabel="C.Postal :" LabelAlign="Top" Width="90" Padding="5" />
                            <ext:TextField ID="txbxCountry" runat="server" FieldLabel="País :" LabelAlign="Top" Width="300" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container12" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:Button ID="btnClearRacePosition" runat="server" Text="Borrar posición" OnClientClick="clearMapPosition()" />
                            <ext:TextField ID="txbxLongitud" runat="server" FieldLabel="Longitud :" LabelAlign="Right" Width="200"
                                PaddingSpec="0 0 0 5" ReadOnly="true" Cls="ReadOnly" />
                            <ext:TextField ID="txbxLatitud" runat="server" FieldLabel="Latitud :" LabelAlign="Right" Width="200"
                                PaddingSpec="0 0 0 5" ReadOnly="true" Cls="ReadOnly" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container13" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:Panel runat="server" ID="map_canvas" Width="720" Height="300" Padding="5">
                            </ext:Panel>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container7" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextArea ID="txbxMemo" runat="server" FieldLabel="Descripción :" LabelAlign="Top" Width="710" Height="100" Padding="5" />
                        </Items>
                    </ext:Container>
                </Items>
                <Listeners>
                    <Show Handler="initializeMap(#{txbxLatitud}.getValue(),#{txbxLongitud}.getValue(),#{txbxName}.getValue())" />
                </Listeners>
            </ext:Panel>

            <ext:Panel
                ID="PaParticipantes"
                runat="server"
                Title="Participantes"
                Frame="true"
                Width="700"
                ButtonAlign="Center">
                <Items>
                    <ext:Container ID="ContSelectorClubber" runat="server" Layout="FormLayout" Padding="5">
                        <Items>
                            <ext:ComboBox ID="cbClubbers" runat="server" FieldLabel="Clubbers :" LabelAlign="Top" Padding="5"
                                DisplayField="Name" ValueField="UserName" Width="550px" AllowBlank="true" EmptyText="Escoja un clubber para añadir a la competición...">
                                <Store>
                                    <ext:Store ID="StoreCbClubbers" runat="server" OnReadData="StoreCbClubbers_ReadData">
                                        <Model>
                                            <ext:Model ID="Model3" runat="server" IDProperty="RaceTypeID">
                                                <Fields>
                                                    <ext:ModelField Name="UserName" />
                                                    <ext:ModelField Name="Name" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                            </ext:ComboBox>
                            <ext:Toolbar ID="Toolbar2" runat="server" Width="560px">
                                <Items>
                                    <ext:Button ID="btnAddClubber" runat="server" Text="Añadir" Width="150" Icon="Add">
                                        <Listeners>
                                            <Click Handler="App.direct.AskAddClubber();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="btnDelClubber" runat="server" Text="Quitar" Width="150px" Icon="Delete">
                                        <Listeners>
                                            <Click Handler="App.direct.AskDelClubber();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="btnDelAllClubber" runat="server" Text="Borrar Todos" Width="150px" Icon="GroupDelete">
                                        <Listeners>
                                            <Click Handler="App.direct.AskDelAllClubbers();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Items>
                    </ext:Container>

                    <ext:Container ID="ContClubbersInRace" runat="server" Layout="FormLayout">
                        <Items>
                            <ext:GridPanel ID="GPClubbersEnComp"
                                runat="server"
                                Frame="true"
                                Height="250">
                                <Store>
                                    <ext:Store ID="StoreGPClubbersEnComp" runat="server" OnReadData="StoreGPClubbersEnComp_ReadData" PageSize="10">
                                        <Model>
                                            <ext:Model ID="Model4" runat="server" IDProperty="UserName">
                                                <Fields>
                                                    <ext:ModelField Name="UserName" />
                                                    <ext:ModelField Name="SecondName" />
                                                    <ext:ModelField Name="FirstName" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel2" runat="server">
                                    <Columns>
                                        <ext:Column ID="Column9" runat="server" DataIndex="UserName" Text="Usuario" Width="150" />
                                        <ext:Column ID="Column10" runat="server" DataIndex="SecondName" Text="Apellidos" Width="150" />
                                        <ext:Column ID="Column11" runat="server" DataIndex="FirstName" Text="Nombre" Width="150" />
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:GridView ID="GridView1" runat="server" StripeRows="true">
                                        <GetRowClass Handler="return 'x-grid-row-expanded';" />
                                    </ext:GridView>
                                </View>
                                <SelectionModel>
                                    <ext:CellSelectionModel ID="CellSelectionModel2" runat="server">
                                        <DirectEvents>
                                            <Select OnEvent="GPRaces_Cell_Click" />
                                        </DirectEvents>
                                    </ext:CellSelectionModel>
                                </SelectionModel>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar2" runat="server">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="Reg/Página :" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox3" runat="server" Width="80">
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
                                            <ext:ProgressBarPager ID="ProgressBarPager2" runat="server" />
                                        </Plugins>
                                    </ext:PagingToolbar>
                                </BottomBar>
                            </ext:GridPanel>
                        </Items>
                    </ext:Container>

                    <ext:Container ID="ContCantCompetidores" runat="server" Layout="HBoxLayout">
                        <Items>
                            <ext:FormPanel
                                ID="FPPartGeneral"
                                runat="server"
                                Width="350"
                                Height="282"
                                Frame="true"
                                Title=""
                                Flex="25"
                                Margins="5 5 0 0"
                                Border="false">
                                <Defaults>
                                    <ext:Parameter Name="anchor" Value="100%" Mode="Value" />
                                    <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                                    <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                                </Defaults>
                                <Items>
                                    <ext:Container ID="Container2" runat="server" Layout="VBoxLayout">
                                        <Items>
                                            <ext:NumberField ID="txbxPartGenMasc" runat="server" FieldLabel="Participantes General Masc :" LabelAlign="Right" Width="160" Padding="5" MinValue="0" MaxValue="99999" AllowDecimals="false">
                                                <Listeners>
                                                    <Change Handler="App.direct.CalcTotalPart();" />
                                                </Listeners>
                                            </ext:NumberField>
                                            <ext:NumberField ID="txbxPartGenFem" runat="server" FieldLabel="Participantes General Fem. :" LabelAlign="Right" Width="160" Padding="5" MinValue="0" MaxValue="99999" AllowDecimals="false">
                                                <Listeners>
                                                    <Change Handler="App.direct.CalcTotalPart();" />
                                                </Listeners>
                                            </ext:NumberField>
                                            <ext:TextField ID="txbxPartGenTot" runat="server" FieldLabel="Participantes Totales :" LabelAlign="Right" Width="160" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:FormPanel>
                            <ext:FormPanel
                                ID="FPGruposEdad"
                                runat="server"
                                Width="350"
                                Frame="true"
                                Title=""
                                Flex="75"
                                Margins="5 0 0 5"
                                Border="false">
                                <Defaults>
                                    <ext:Parameter Name="anchor" Value="100%" Mode="Value" />
                                    <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                                    <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                                </Defaults>
                                <Items>
                                    <ext:Container ID="Container1" runat="server" Layout="HBoxLayout" Padding="5">
                                        <Items>
                                            <ext:TextField ID="txbxGEName" runat="server" FieldLabel="Nombre G.E. :" LabelAlign="Right" Width="410" Padding="5" />
                                            <ext:Toolbar ID="Toolbar3" runat="server">
                                                <Items>
                                                    <ext:Button ID="Button1" runat="server" Width="25" Icon="Add">
                                                        <Listeners>
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button ID="Button2" runat="server" Width="25" Icon="Delete">
                                                        <Listeners>
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button ID="Button3" runat="server" Width="25" Icon="GroupDelete">
                                                        <Listeners>
                                                        </Listeners>
                                                    </ext:Button>
                                                </Items>
                                            </ext:Toolbar>
                                        </Items>
                                    </ext:Container>
                                    <ext:GridPanel ID="GridPanel1"
                                        runat="server"
                                        Frame="true"
                                        Height="230">
                                        <Store>
                                            <ext:Store ID="Store2" runat="server" OnReadData="StoreGPClubbersEnComp_ReadData" PageSize="10">
                                                <Model>
                                                    <ext:Model ID="Model2" runat="server" IDProperty="UserName">
                                                        <Fields>
                                                            <ext:ModelField Name="UserName" />
                                                            <ext:ModelField Name="SecondName" />
                                                            <ext:ModelField Name="FirstName" />
                                                        </Fields>
                                                    </ext:Model>
                                                </Model>
                                            </ext:Store>
                                        </Store>
                                        <ColumnModel ID="ColumnModel3" runat="server">
                                            <Columns>
                                                <ext:Column ID="Column12" runat="server" DataIndex="First" Text="Id" Width="50" />
                                                <ext:Column ID="Column7" runat="server" DataIndex="Part." Text="Part." Width="50" />
                                                <ext:Column ID="Column8" runat="server" DataIndex="Grupo de Edad" Text="Grupo de Edad" Width="250" />
                                            </Columns>
                                        </ColumnModel>
                                        <View>
                                            <ext:GridView ID="GridView3" runat="server" StripeRows="true">
                                                <GetRowClass Handler="return 'x-grid-row-expanded';" />
                                            </ext:GridView>
                                        </View>
                                        <SelectionModel>
                                            <ext:CellSelectionModel ID="CellSelectionModel3" runat="server">
                                                <DirectEvents>
                                                    <Select OnEvent="GPRaces_Cell_Click" />
                                                </DirectEvents>
                                            </ext:CellSelectionModel>
                                        </SelectionModel>
                                        <BottomBar>
                                            <ext:PagingToolbar ID="PagingToolbar3" runat="server">
                                                <Items>
                                                    <ext:Label ID="Label2" runat="server" />
                                                    <ext:ToolbarSpacer ID="ToolbarSpacer3" runat="server" Width="10" />
                                                    <ext:ComboBox ID="ComboBox2" runat="server" Width="40">
                                                        <Items>
                                                            <ext:ListItem Text="1" />
                                                            <ext:ListItem Text="5" />
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
                                                    <ext:ProgressBarPager ID="ProgressBarPager3" runat="server" />
                                                </Plugins>
                                            </ext:PagingToolbar>
                                        </BottomBar>
                                    </ext:GridPanel>
                                </Items>
                            </ext:FormPanel>
                        </Items>
                    </ext:Container>
                </Items>
                <Listeners>
                    <Show Handler="App.direct.CalcTotalPart();" />
                </Listeners>
            </ext:Panel>
        </Items>
    </ext:TabPanel>


    <asp:SqlDataSource ID="SqlDSGPRaces" runat="server" ConnectionString="<%$ ConnectionStrings:ClubSiteConn %>"
        SelectCommand="SELECT Races.Id, Races.Name, Races.RaceDate, Races.RaceTypeId, Races.Address_City, 
                                       Races.Address_Country, RaceTypes.Name AS Expr1
                                       FROM Races INNER JOIN RaceTypes ON RaceTypes.RaceTypeID = Races.RaceTypeId 
                                       ORDER BY Races.RaceDate DESC, Races.Name"></asp:SqlDataSource>


</asp:Content>
