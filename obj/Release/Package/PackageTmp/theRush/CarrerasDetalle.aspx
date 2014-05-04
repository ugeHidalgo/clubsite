<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarrerasDetalle.aspx.cs" Inherits="ClubSite.theRush.CarrerasDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript"
        src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDS7Syd76e3allIrLsYVfIcJ43kZ0NnHiI&sensor=false">
    </script>

    <script type="text/javascript">
        var map;

        function initializeMap(StrLatitud, StrLongitud, Nombre) {
            var Latitud = parseFloat(StrLatitud);
            var Longitud = parseFloat(StrLongitud);
            var mapOptions = {
                zoom: 13,
                center: new google.maps.LatLng(Latitud, Longitud)
            };
            map = new google.maps.Map(document.getElementById('MainContent_map_canvas-body'),
                mapOptions);

            var marker = new google.maps.Marker({
                position: new google.maps.LatLng(Latitud, Longitud),
                map: map,
                title: Nombre
            });

            //Zoom over marker when click over it.
            google.maps.event.addListener(marker, 'click', function () {
                map.setZoom(18);
                map.setCenter(marker.getPosition());
            });

        }
    </script>

    <ext:Store ID="StoreGPClubbersEnComp" runat="server">
        <Model>
            <ext:Model ID="Model2" runat="server" IDProperty="UserName">
                <Fields>
                    <ext:ModelField Name="UserName" />
                    <ext:ModelField Name="ImageURL" />
                    <ext:ModelField Name="NImageURL" />
                    <ext:ModelField Name="BlogURL" />
                    <ext:ModelField Name="SecondName" />
                    <ext:ModelField Name="FirstName" />
                    <ext:ModelField Name="Number" />
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>

    <ext:Panel ID="PaDatosPrincipales" runat="server" Border="false" Width="750" Cls="background-color:transparent;">
        <Items>
            <ext:Container ID="ContDatosPrinc" runat="server" Layout="HBoxLayout" Padding="5">
                <Items>
                    <ext:FormPanel
                        ID="FPDatosPrinc"
                        runat="server"
                        Width="350"
                        Height="250"
                        Frame="true"
                        Title=""
                        Margins="0 0 0 0"
                        Border="false"
                        PaddingSummary="0px 0px 0px 0px"
                        LabelWidth="50">
                        <Defaults>
                            <ext:Parameter Name="anchor" Value="100%" Mode="Value" />
                            <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                            <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                        </Defaults>
                        <Items>
                            <ext:Container ID="Container11" runat="server" Layout="VBoxLayout" Padding="5">
                                <Items>
                                    <ext:TextField ID="txbxID" runat="server" FieldLabel="Código :" LabelAlign="Top" Width="50" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                                    <ext:TextField ID="txbxDate" runat="server" FieldLabel="Fecha :" LabelAlign="Top" Width="100" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container10" runat="server" Layout="HBoxLayout" Padding="5">
                                <Items>
                                    <ext:TextField ID="txbxRaceType" runat="server" FieldLabel="Tipo de Competición :" LabelAlign="Top" Padding="5" Width="250px" ReadOnly="true" Cls="ReadOnly" />
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
                        Height="250"
                        Frame="true"
                        Title=""
                        Margins="0 0 0 0"
                        Border="false"
                        PaddingSummary="0px 0px 0px 0px">
                        <Defaults>
                            <ext:Parameter Name="anchor" Value="100%" Mode="Value" />
                            <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                            <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                        </Defaults>
                        <Items>
                            <ext:Image ID="imgImage" runat="server" Height="240" Width="320" AlternateText="Imagen 2 Sponsor" Border="true" />
                        </Items>
                    </ext:FormPanel>
                </Items>
            </ext:Container>
            <ext:Container ID="ContName" runat="server" Layout="FormLayout" Padding="5">
                <Items>
                    <ext:TextField ID="txbxName" runat="server" FieldLabel="Nombre Competición :" LabelAlign="Top" Width="720" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                    <ext:TextArea ID="txbxMemo" runat="server" FieldLabel="Descripción :" LabelAlign="Top" Width="720" Height="100" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                </Items>
            </ext:Container>
            <ext:Container ID="Address1" runat="server" Layout="HBoxLayout" Padding="5">
                <Items>
                    <ext:TextField ID="txbxStreet" runat="server" FieldLabel="Calle :" LabelAlign="Top" Width="600" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                    <ext:TextField ID="txbxNumber" runat="server" FieldLabel="Nº :" LabelAlign="Top" Width="100" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                </Items>
            </ext:Container>
            <ext:Container ID="Address2" runat="server" Layout="HBoxLayout" Padding="5">
                <Items>
                    <ext:TextField ID="txbxCity" runat="server" FieldLabel="Población :" LabelAlign="Top" Width="300" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                    <ext:TextField ID="txbxPostalCode" runat="server" FieldLabel="C.Postal :" LabelAlign="Top" Width="90" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                    <ext:TextField ID="txbxCountry" runat="server" FieldLabel="País :" LabelAlign="Top" Width="300" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                </Items>
            </ext:Container>
            <ext:Container ID="LatLong" runat="server" Layout="HBoxLayout" Padding="5">
                <Items>
                    <ext:TextField ID="txbxLongitud" runat="server" FieldLabel="Longitud :" LabelAlign="Right" Width="200"
                        PaddingSpec="0 0 0 5" ReadOnly="true" Cls="ReadOnly" />
                    <ext:TextField ID="txbxLatitud" runat="server" FieldLabel="Latitud :" LabelAlign="Right" Width="200"
                        PaddingSpec="0 0 0 5" ReadOnly="true" Cls="ReadOnly" />
                </Items>
            </ext:Container>
            <ext:Container ID="Map" runat="server" Layout="HBoxLayout" Padding="5">
                <Items>
                    <ext:Panel runat="server" ID="map_canvas" Width="730" Height="300" Padding="5">
                    </ext:Panel>
                </Items>
            </ext:Container>
            <ext:Container ID="ClubbersInRace" runat="server" Layout="FormLayout" Padding="5">
                <Items>
                    <ext:Panel ID="Panel1"
                        runat="server"
                        Title="Clubbers Participantes"
                        Height="555"
                        Width="750"
                        Border="False"
                        Layout="FitLayout">
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>                                    
                                    <ext:DisplayField ID="DisplayField1" runat="server" Text="Ordenar por:&nbsp;" />
                                    <ext:Button ID="btnOrderUsername" runat="server" Text="User Name">
                                        <DirectEvents>
                                            <Click OnEvent="btnOrderUsername_Click" />
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnOrderSecond" runat="server" Text="Apellidos">
                                        <DirectEvents>
                                            <Click OnEvent="btnOrderSecond_Click" />
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnOrderNumber" runat="server" Text="Número">
                                        <DirectEvents>
                                            <Click OnEvent="btnOrderNumber_Click" />
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>
                            <ext:DataView
                                ID="miembros"
                                runat="server"
                                DeferInitialRefresh="false"
                                ItemSelector="div.clubber"
                                OverItemCls="clubber-hover"
                                MultiSelect="false"
                                AutoScroll="true"
                                Cls="clubbers-view"
                                StoreID="StoreGPClubbersEnComp"
                                TrackOver="true"
                                EmptyText="( No hay clubbers activos que vayan a tomar parte en esta competición )">
                                <Tpl ID="Tpl1" runat="server">
                                    <Html>
                                        <tpl for=".">
                                            <a href="{BlogURL}" target="_blank"><div class="clubber">
                                                <div>
                                                    <img width="80" height="80" src="{ImageURL}" /> 
                                                    <img width="80" height="80" src="{NImageURL}" />  
                                                </div>                                    
                                            <div>(<strong>{UserName}</strong>) {SecondName}, {FirstName}</div> 
                                            </div></a>                                
                                        </tpl>
                                    </Html>
                                </Tpl>
                                <Plugins>
                                    <ext:DataViewAnimated ID="DataViewAnimated1" runat="server" Duration="550" IDProperty="UserName" />
                                </Plugins>
                            </ext:DataView>
                        </Items>
                    </ext:Panel>



                    <%--<ext:GridPanel ID="GPClubbersEnComp"
                        runat="server"
                        Title="Clubbers en la competición"
                        Border="false"
                        Cls="background-color:transparent;"
                        Frame="true"
                         Width="730"
                        Height="350">
                        <Store>
                            <ext:Store ID="StoreGPClubbersEnComp" runat="server" PageSize="10">
                                <Model>
                                    <ext:Model ID="Model4" runat="server" IDProperty="UserName">
                                        <Fields>
                                            <ext:ModelField Name="Number" />
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
                                <ext:Column ID="Column1" runat="server" DataIndex="Number" Text="Nº Clubber" Width="80" />
                                <ext:Column ID="Column2" runat="server" DataIndex="UserName" Text="Usuario" Width="100" />
                                <ext:Column ID="Column3" runat="server" DataIndex="SecondName" Text="Apellidos" Width="150" />
                                <ext:Column ID="Column4" runat="server" DataIndex="FirstName" Text="Nombre" Width="100" />
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
                                    <Select OnEvent="GPRaces_CellClick" />
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
                    </ext:GridPanel>--%>
                </Items>
            </ext:Container>
        </Items>
        <Listeners>
            <AfterRender Handler="initializeMap(#{txbxLatitud}.getValue(),#{txbxLongitud}.getValue(),#{txbxName}.getValue())" />
        </Listeners>
    </ext:Panel>



    <%-- <ext:TabPanel ID="TabPanel1"
        Title="Competiciones"
        runat="server"
        Width="750"
        Height="650"
        DeferredRender="false">
        <Items>
            <ext:Panel
                ID="PaParticipantes"
                runat="server"
                Title="Participantes"
                Frame="true"
                Width="700"
                ButtonAlign="Center">
                <Items>
                </Items>
            </ext:Panel>
        </Items>
    </ext:TabPanel>--%>


    <%--<asp:SqlDataSource ID="SqlDSGPRaces" runat="server" ConnectionString="<%$ ConnectionStrings:ClubSiteConn %>"
        SelectCommand="SELECT Races.Id, Races.Name, Races.RaceDate, Races.RaceTypeId, Races.Address_City, 
                                       Races.Address_Country, RaceTypes.Name AS Expr1
                                       FROM Races INNER JOIN RaceTypes ON RaceTypes.RaceTypeID = Races.RaceTypeId 
                                       ORDER BY Races.RaceDate DESC, Races.Name"></asp:SqlDataSource>--%>
</asp:Content>
