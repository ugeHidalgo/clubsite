<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ColabDetail.aspx.cs" Inherits="ClubSite.theClub.ColabDetail" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <table class="auto-style1">
        <tr>
            <td rowspan="5">
                <asp:Image ID="imgLogoURL" runat="server" Width="250px" Height="250px" />
            </td>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="laSponsorName" runat="server" Width="500px" Font-Bold="True"></asp:Label>
            </td>
            <td rowspan="5">
                <asp:Image ID="imgImageURL" runat="server" Width="250px" Height="250px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:HyperLink ID="hlWebSite" runat="server"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="laCalle" runat="server" Text=""></asp:Label>, 
                <asp:Label ID="laNumero" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="laCPostal" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="laCiudad" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="laProvincia" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="laTlf" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="laMail" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="laCondiciones" runat="server" Text="Condiciones ofertadas a Clubbers :"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txbxCondiciones" runat="server" TextMode="MultiLine" Width="847px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label2" runat="server" Text="Ubicación"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <div style="width: 847px; height: 500px;">
                    <cc:GMap ID="GMap1" runat="server" />
                </div>
            </td>
        </tr>
    </table>

    <ext:Panel ID="panel0" runat="server">
        <LayoutConfig>
            <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
        </LayoutConfig>
        <Items>
            <ext:Image ID="Image1" runat="server" ImageUrl="../Images/fondos/corcho2.jpg" />
            <ext:Container ID="Container1"
                runat="server"
                StyleSpec="background:transparent;"
                Margins="0 0 10 0">
                <LayoutConfig>
                    <ext:TableLayoutConfig Columns="3" />
                </LayoutConfig>
                <Defaults>
                    <ext:Parameter Name="Width" Value="200" Mode="Raw" />
                    <ext:Parameter Name="Height" Value="200" Mode="Raw" />
                    <ext:Parameter Name="BodyPadding" Value="10" Mode="Raw" />
                    <ext:Parameter Name="AutoScroll" Value="true" Mode="Raw" />
                    <ext:Parameter Name="Margin" Value="10" Mode="Raw" />
                    <ext:Parameter Name="Frame" Value="true" Mode="Raw" />
                </Defaults>
                <Items>
                    <ext:Panel ID="Panel1" runat="server">
                        <Items>
                            <ext:TextField ID="textBox1" runat="server" Text="Hola" />
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel2" runat="server" />
                    <ext:Panel ID="Panel3" runat="server" />
                    <ext:Panel ID="Panel4" runat="server" />
                    <ext:Panel ID="Panel5" runat="server" ColSpan="3" Frame="true"
                        />
                </Items>
            </ext:Container>
        </Items>
    </ext:Panel>


</asp:Content>
