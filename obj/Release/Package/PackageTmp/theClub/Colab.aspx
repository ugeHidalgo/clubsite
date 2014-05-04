<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Colab.aspx.cs" Inherits="ClubSite.theClub.Colab" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Estos son los colaboradores de nuestro club, sobre la imagen de cada uno puedes encontrar un enlace a su blog personal donde podrás encontrar ´información sobre cada uno de ellos.
    </p>
    <br />
    <br />

    <ext:Store ID="Store1" runat="server">
        <Model>
            <ext:Model ID="Model2" runat="server" IDProperty="Nombre">
                <Fields>
                    <ext:ModelField Name="SponsorId" />
                    <ext:ModelField Name="LogoURL" />
                    <ext:ModelField Name="Nombre" />
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>

    <ext:Panel ID="Panel1"
        runat="server"
        Title=""
        Height="555"
        Width="850"
        Border="False"
        Layout="FitLayout">
        <Items>
            <ext:DataView
                ID="colaboradores"
                runat="server"
                DeferInitialRefresh="false"
                ItemSelector="div.sponsor"
                OverItemCls="sponsor-hover"
                MultiSelect="false"
                AutoScroll="true"
                Cls="sponsors-view"
                StoreID="Store1"
                TrackOver="true"
                EmptyText="No hay imágenes disponibles">
                <Tpl ID="Tpl1" runat="server">
                    <Html>
                        <tpl for=".">
                                <a href="ColabDetail.aspx?SponsorId={SponsorId}"><div class="sponsor">
                                    <div>                                        
                                        <img width="200" height="200" src="{LogoURL}" />  
                                    </div>                                    
                                    <div><strong>{Nombre}</strong></div> 
                                </div></a>                                
                            </tpl>
                    </Html>
                </Tpl>
                <Plugins>
                    <ext:DataViewAnimated ID="DataViewAnimated1" runat="server" Duration="550" IDProperty="SponsorId" />
                </Plugins>
            </ext:DataView>
        </Items>
    </ext:Panel>




</asp:Content>
