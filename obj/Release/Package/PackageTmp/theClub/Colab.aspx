<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Colab.aspx.cs" Inherits="ClubSite.theClub.Colab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Estos son los colaboradores de nuestro club, sobre la imagen de cada uno puedes encontrar un enlace a su blog personal donde podrás encontrar información sobre cada uno de ellos.
    </p>
    <br />
    <br />
    <div style="margin: auto; width: 80%;">
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
                            <a href='<%# Eval("WebURL") %>' style="color: white">
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
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="ClubSite.Model.ClubSiteContext" EntityTypeName="" OrderBy="Nombre" Select="new (Nombre, LogoURL, WebURL, Activo)" TableName="Sponsors" Where="Activo == true">            
        </asp:LinqDataSource>
    </div>
</asp:Content>
