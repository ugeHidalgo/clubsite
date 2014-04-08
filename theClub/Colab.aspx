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
   <%-- <div style="margin: auto; width: 80%;">
        <asp:ListView ID="ListView1" runat="server" DataSourceID="LinqDataSource1" GroupItemCount="3">

            <EmptyDataTemplate>
                <table id="Table1" runat="server" style="">
                    <tr>
                        <td>No hay datos de Sponsors dados de alta en la base.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>

                <td id="Td1" runat="server" />
            </EmptyItemTemplate>

            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>

            <ItemTemplate>
                <td id="Td2" runat="server" style="border: groove; border-color: black;">
                    <div style="border: thick; border-color: black; display: block; background-color: white; padding: 5px;">
                        <div>
                            <a href='ColabDetail.aspx?SponsorId=<%# Eval("SponsorId") %>' style="color: white">
                                <asp:Image ID="Image2" ImageUrl='<%# Eval("LogoURL") %>' runat="server" Width="300px" Height="220px" ForeColor="white" />
                            </a>
                        </div>
                        <div style="text-align: center">
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Nombre") %>'/>
                        </div>
                    </div>
                </td>
            </ItemTemplate>

            <LayoutTemplate>
                <table id="Table2" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td3" runat="server">
                            <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="Tr2" runat="server">
                        <td id="Td4" runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="False" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="False" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>



        </asp:ListView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="ClubSite.Model.ClubSiteContext" EntityTypeName="" OrderBy="Nombre" Select="new (SponsorId, Nombre, LogoURL, WebURL, Activo)" TableName="Sponsors" Where="Activo == true">            
        </asp:LinqDataSource>
    </div>--%>

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
        Title="Colaboradores registrados"
        Height="555"
        Width="850"
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
