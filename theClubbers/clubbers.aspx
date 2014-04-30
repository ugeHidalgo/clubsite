<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="clubbers.aspx.cs" Inherits="ClubSite.theClubbers.clubbers" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Estos son los miembros de nuestro club, sobre la imagen de cada uno puedes encontrar un enlace a su blog personal donde podrás encontrar información sobre cada uno de ellos.
    </p>
    <br />
    <br />
    <%--<div style="margin: auto; width: 80%;">
        <asp:ListView ID="ListView1" runat="server" DataSourceID="LinqDataSource1" GroupItemCount="3">

            <EmptyDataTemplate>
                <table id="Table1" runat="server" style="">
                    <tr>
                        <td>No hay datos de Clubbers en la base. Debes de dar de alta algun miembro para verlo en esta zona.<br />
                            Usa la zona de Registro para ello.</td>
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
                            <a href='<%# Eval("BlogURL") %>' style="color: white">
                                <asp:Image ID="Image1" ImageUrl='<%# Eval("NImageURL") %>' runat="server" Width="100px" Height="120px" ForeColor="white" />
                            </a>
                            <a href='<%# Eval("BlogURL") %>' style="color: white">
                                <asp:Image ID="Image2" ImageUrl='<%# Eval("ImageURL") %>' runat="server" Width="100px" Height="120px" ForeColor="white" />
                            </a>
                        </div>
                        <div style="text-align: center">
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("UserName") %>' CssClass="theClubLetter" />
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

        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="ClubSite.Model.ClubSiteContext" EntityTypeName="" OrderBy="UserName desc" Select="new (UserName, ImageURL, NImageURL, BlogURL, State, Visible)" TableName="Members" Where="State==True && Visible==True">
    </asp:LinqDataSource>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server">
    </asp:EntityDataSource>

    </div>--%>

    <ext:Store ID="Store1" runat="server">
        <Model>
            <ext:Model ID="Model2" runat="server" IDProperty="name">
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

    <ext:Panel ID="Panel1"
        runat="server"
        Title=""
        Height="555"
        Width="850"
        Border ="False"
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
                StoreID="Store1"
                TrackOver="true"
                EmptyText="No hay imágenes disponibles">
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

</asp:Content>
