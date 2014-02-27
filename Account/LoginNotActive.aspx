<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginNotActive.aspx.cs" Inherits="ClubSite.Account.LoginNotActive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-family:'Arial Black', Gadget, sans-serif; font-size:large;" >
        <p>
            Tu usuario está ya dado de alta en la base de datos, sin embargo todavía no ha sido activado, con lo que no podras acceder como usuario registrado.

        </p>        
        <p>
            Si deseas acelerar el proceso ponte en contacto con el administrador a través de la página de <asp:HyperLink ID="HyperLink1"   runat="server" NavigateUrl="~/Contact.aspx">contacto</asp:HyperLink> 
            
            Gracias.            
        </p>
    </div>
</asp:Content>
