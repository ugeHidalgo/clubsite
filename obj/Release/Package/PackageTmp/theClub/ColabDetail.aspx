<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ColabDetail.aspx.cs" Inherits="ClubSite.theClub.ColabDetail" %>

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

    <ext:Panel ID="panelColab" runat="server" Cls="background-color:transparent;" Border="false">
        <Items>
            <ext:Container ID="Container1" runat="server" Height="100" Layout="HBoxLayout" Cls="transparent;">
                <LayoutConfig>
                    <ext:HBoxLayoutConfig Align="Middle" Pack="Center" />
                </LayoutConfig>
                <Items>
                    <ext:Label ID="laSponsorName" runat="server" Cls="h1_transparent" />
                </Items>
            </ext:Container>
            <ext:Container ID="Container2" runat="server" Layout="FormLayout" ColumnWidth=".5" Padding="5">
                <Items>
                    <ext:Panel ID="pnlPackCenter" runat="server" Layout="HBoxLayout" BodyPadding="5" Border="false">
                        <Defaults>
                            <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
                        </Defaults>
                        <LayoutConfig>
                            <ext:HBoxLayoutConfig Align="Middle" Pack="Center" />
                        </LayoutConfig>
                        <Items>
                            <ext:FormPanel
                                ID="FormLogoPanel"
                                runat="server"
                                Width="350"
                                Margins="0 12 0 0"
                                Frame="true"
                                PaddingSpec="0px 0px 0px 0px"
                                Cls="transparent"
                                LabelWidth="50">
                                <Defaults>
                                    <ext:Parameter Name="anchor" Value="100%" Mode="Value" />
                                    <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                                    <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                                </Defaults>
                                <Items>
                                    <ext:Image ID="imgLogo" runat="server" Height="180" Width="210" AlternateText="Logo Sponsor" Padding="5" Border="true" />
                                </Items>
                            </ext:FormPanel>
                            <ext:FormPanel
                                ID="FormImgPanel"
                                runat="server"
                                Width="350"
                                Frame="true"
                                Margins="0 0 0 12"
                                PaddingSpec="0px 0px 0px 0px"
                                Cls="transparent"
                                LabelWidth="50">
                                <Defaults>
                                    <ext:Parameter Name="anchor" Value="100%" Mode="Value" />
                                    <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                                    <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                                </Defaults>
                                <Items>
                                    <ext:Image ID="imgImage" runat="server" Height="180" Width="200" AlternateText="Imagen 2 Sponsor" Padding="5" Border="true" />
                                </Items>
                            </ext:FormPanel>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Container>
            <ext:Container ID="Container3" runat="server" Layout="HBoxLayout" Padding="5" Height="40">
                <LayoutConfig>
                    <ext:HBoxLayoutConfig Align="Middle" Pack="Center" />
                </LayoutConfig>
                <Items>
                    <ext:Label ID="Label7" runat="server" Text="Sitio Web :" />
                    <ext:HyperLink ID="hlWebSite" Target="_blank" runat="server" />
                </Items>
            </ext:Container>
            <ext:Container ID="Container4" runat="server" Layout="HBoxLayout" Padding="5" Height="40">
                <LayoutConfig>
                    <ext:HBoxLayoutConfig Align="Middle" Pack="Center" />
                </LayoutConfig>
                <Items>
                    <ext:Label ID="laMail" runat="server" Icon="Email" IconAlign="Left" />
                </Items>
            </ext:Container>
            <ext:Container ID="Container6" runat="server" Layout="HBoxLayout" Padding="5" Height="40">
                <LayoutConfig>
                    <ext:HBoxLayoutConfig Align="Middle" Pack="Center" />
                </LayoutConfig>
                <Items>
                    <ext:Label ID="laTlf" runat="server" Icon="Telephone" IconAlign="Left" />
                </Items>
            </ext:Container>
            <ext:Container ID="Container7" runat="server" Layout="HBoxLayout" Padding="5" Height="40">
                <LayoutConfig>
                    <ext:HBoxLayoutConfig Align="Middle" Pack="Center" />
                </LayoutConfig>
                <Items>
                    <ext:Label ID="Label1" runat="server" Text="Dirección :" />
                    <ext:Label ID="laCalle" runat="server" />
                    <ext:Label ID="Label6" runat="server" Text="," />
                    <ext:Label ID="laNumero" runat="server" />
                </Items>
            </ext:Container>
            <ext:Container ID="Container8" runat="server" Layout="HBoxLayout" Padding="5" Height="40">
                <LayoutConfig>
                    <ext:HBoxLayoutConfig Align="Middle" Pack="Center" />
                </LayoutConfig>
                <Items>
                    <ext:Label ID="laCiudad" runat="server" />
                    <ext:Label ID="Label4" runat="server" Text="(" />
                    <ext:Label ID="laCPostal" runat="server" />
                    <ext:Label ID="Label5" runat="server" Text=")" />
                    <ext:Label ID="laProvincia" runat="server" />
                </Items>
            </ext:Container>
            <ext:Container ID="Container9" runat="server" Layout="FormLayout" Padding="5">
                <Items>
                    <ext:Label ID="Label2" runat="server" Text="Descripción" Icon="Information" IconAlign="Left" />
                    <ext:TextArea ID="txbxMemo" runat="server" FieldLabel="" LabelAlign="Top" Height="100" ReadOnly="true" />
                </Items>
            </ext:Container>
            <ext:Container ID="Container10" runat="server" Layout="FormLayout" Padding="5">
                <Items>
                    <ext:Label ID="laCondiciones" runat="server" Text="Condiciones Ofertadas (Solo visible si eres miembro registrado)" Icon="Information" IconAlign="Left" />
                    <ext:TextArea ID="txbxCondiciones" runat="server" Height="200" ReadOnly="true" />
                </Items>
            </ext:Container>
            <ext:Container ID="Container11" runat="server" Layout="FormLayout" Padding="5">
                <Items>
                    <ext:Label ID="Label3" runat="server" Text="Localización" Icon="Map" IconAlign="Left" />
                    <ext:Panel runat="server" ID="map_canvas" Layout="FitLayout" Height="500" />
                </Items>
            </ext:Container>
            <ext:Container ID="Container12" runat="server" Layout="ColumnLayout" Padding="5">
                <Items>
                    <ext:TextField ID="txbxLongitud" runat="server" FieldLabel="Longitud :" LabelAlign="Right" Width="200"
                        PaddingSpec="0 0 0 5" ReadOnly="true" />
                    <ext:TextField ID="txbxLatitud" runat="server" FieldLabel="Latitud :" LabelAlign="Right" Width="200"
                        PaddingSpec="0 0 0 5" ReadOnly="true" />
                </Items>
            </ext:Container>

        </Items>
        <Listeners>
            <AfterRender Handler="initializeMap(#{txbxLatitud}.getValue(),#{txbxLongitud}.getValue(),#{laSponsorName}.getText())" />
        </Listeners>
    </ext:Panel>
</asp:Content>
