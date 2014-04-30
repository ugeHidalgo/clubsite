<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carreras.aspx.cs" Inherits="ClubSite.theRush.Carreras" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Estos son los carreras en las que participarán o han participado miembros de nuestro club, 
        puedes pulsar sobre cada una de ellas para encontrar mas información de la carrera, 
        así como de los miembros que han participado.
    </p>
    <br />
    <br />

    <ext:Store ID="Store1" runat="server">
        <Model>
            <ext:Model ID="Model2" runat="server" IDProperty="Id">
                <Fields>
                    <ext:ModelField Name="Id" Type="Int" />
                    <ext:ModelField Name="ImageURL" />
                    <ext:ModelField Name="Name" />
                    <ext:ModelField Name="RaceDate" Type="Date"  />
                </Fields>
            </ext:Model>
        </Model>
        <Sorters>
            <ext:DataSorter Property="Nombre" Direction="ASC" />
        </Sorters>
    </ext:Store>

    <ext:Panel ID="Panel1"
        runat="server"
        Title=""
        Height="555"
        Width="850"
        Border="False"
        Layout="FitLayout">
        <TopBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:DisplayField ID="DisplayField1" runat="server" Text="Ordenar por:&nbsp;" />
                    <ext:Button ID="btnOrderName" runat="server" Text="Fecha">
                        <DirectEvents>
                            <Click OnEvent="btnOrderName_Click" />
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnOrderRace" runat="server" Text="Nombre">
                        <DirectEvents>
                            <Click OnEvent="btnOrderDate_Click" />
                        </DirectEvents>
                    </ext:Button>
                    <ext:DateField ID="dtfFromDate" runat="server" Text="Desde:" LabelAlign="Right" />
                    <ext:DateField ID="dtfToDate" runat="server" Text="Hasta :" LabelAlign="Right" />
                </Items>
            </ext:Toolbar>
        </TopBar>
        <Items>
            <ext:DataView
                ID="carreras"
                runat="server"
                DeferInitialRefresh="false"
                ItemSelector="div.sponsor"
                OverItemCls="sponsor-hover"
                MultiSelect="false"
                AutoScroll="true"
                Cls="sponsors-view"
                StoreID="Store1"
                TrackOver="true"
                EmptyText="No hay carreras disponibles">
                <Tpl ID="Tpl1" runat="server">
                    <Html>
                        <tpl for=".">
                                <a href="CarrerasDetalle.aspx?Id={Id}"><div class="sponsor">
                                    <div>                                        
                                        <img width="150" height="150" src="{ImageURL}" />  
                                    </div>       
                                    <div>(<strong>{RaceDate:date('d/n/Y')}</strong>) {Name}</div>                                                                  
                                </div></a>                                
                            </tpl>
                    </Html>
                </Tpl>
                <Plugins>
                    <ext:DataViewAnimated ID="DataViewAnimated1" runat="server" Duration="350" IDProperty="Id" />
                </Plugins>
            </ext:DataView>
        </Items>
    </ext:Panel>


</asp:Content>
