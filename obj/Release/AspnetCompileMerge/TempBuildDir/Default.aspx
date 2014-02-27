<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClubSite.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title><%: Page.Title %>#TheClub</title>
    <link href="~/Content/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <%--<asp:ScriptReference Name="MsAjaxBundle" />--%>
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="jquery.ui.combined" />
            </Scripts>
        </asp:ScriptManager>
        <script src="Scripts/jsSlider.js"></script>

        <header>
            <div id="HeaderMain" class="content-wrapper">
                <div class="float-left">
                    <table id="SiteLogo">
                        <tr>
                            <td>
                                <img src="../Images/Logos/theClubMini.jpg" alt="" style="height: 80px; width: 80px" />
                            </td>
                            <td>
                                <a id="A1" class="site-title" runat="server" href="~/Default.aspx">#heClub Site</a>
                            </td>
                        </tr>
                    </table>
                    <nav id="SiteMenu">
                        <asp:Menu ID="MenuPrincipal" runat="server" DataSourceID="SiteMapDataSource1" Orientation="Horizontal" StaticEnableDefaultPopOutImage="False">
                            <DynamicHoverStyle CssClass="menuItemL2:hover" />
                            <DynamicMenuItemStyle CssClass="menuItemL2" />
                            <DynamicSelectedStyle CssClass="menuItemL2:Active" />
                            <StaticHoverStyle CssClass="menuItemL1:hover" />
                            <StaticMenuItemStyle CssClass="menuItemL1" />
                            <StaticSelectedStyle CssClass="menuItemL1:Active" />
                        </asp:Menu>
                        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="False" />
                    </nav>
                </div>


                <div class="float-right">
                    <section id="login">
                        <asp:LoginView ID="LoginView1" runat="server" ViewStateMode="Disabled">
                            <AnonymousTemplate>
                                <ul>
                                    <li><a id="adminLink" runat="server" href="~/theAdminPages/DefaultAdmin.aspx">Admin</a></li>
                                    <li><a id="registerLink" runat="server" href="~/Account/Register">Registro</a></li>
                                    <li><a id="loginLink" runat="server" href="~/Account/Login">Login</a></li>
                                </ul>
                            </AnonymousTemplate>
                            <LoggedInTemplate>
                                <p>
                                    Registrado como usuario :<a id="A2" runat="server" class="username" href="~/Account/Manage" title="Administración de Cuenta">
                                        <asp:LoginName ID="LoginName1" runat="server" CssClass="username" />
                                    </a>
                                    <li><a id="adminLink" runat="server" href="~/theAdminPages/DefaultAdmin.aspx">Admin</a></li>
                                    <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" />
                                </p>
                            </LoggedInTemplate>
                        </asp:LoginView>
                    </section>

                    <section id="followUs" style="margin-right: 10px;">
                        <h4 style="text-align: right">Siguenos en...</h4>
                        <asp:ImageButton CssClass="FollowImage" ID="imgbtnBlog" runat="server" ImageUrl="~/Images/Logos/blogger.jpg" PostBackUrl="http://www.sharptheclub.com/" />
                        <asp:ImageButton CssClass="FollowImage" ID="imgbtnfacebook" runat="server" ImageUrl="~/Images/Logos/facebook.png" PostBackUrl="https://www.facebook.com/sharptheclubthepage" />
                        <asp:ImageButton CssClass="FollowImage" ID="imgbtnTwitter" runat="server" ImageUrl="~/Images/Logos/twitter.png" PostBackUrl="http://twitter.com/sharptheclub" />
                    </section>
                </div>
            </div>

            <div id="HeaderSlide">
                <img id="SlideImage" src="../Images/MainSlider/image0.jpg" alt="Alternate Text" />
            </div>
        </header>

        <div id="MainZone">
            <section id="CenterPanel">
                <div class="TableStyle1">
                    <img src="Images/Photos/ropa.jpg" alt="" class="TableElement1" style="width: 366px; height: 228px; top: 14px; left: 310px;" />
                    <img src="Images/Photos/josetebici.jpg" class="TableElement1" style="width: 300px; height: 500px; top: 134px; left: 63px; right: 763px;" />
                    <img src="Images/Photos/grupo.jpg" alt="" class="TableElement1" style="width: 600px; height: 400px; bottom: 0px; right: 0px;" />
                    <img src="Images/Photos/globos.jpg" alt="" class="TableElement2" style="width: 300px; height: 300px; bottom: 0px; left: 0px;" />
                    <img src="Images/Photos/carlosAlmeria.jpg" alt="" class="TableElement2" style="width: 180px; height: 230px; top: 3px; left: 0px;" />
                    <img src="Images/Photos/challenge.jpg" alt="" class="TableElement1" style="width: 300px; height: 250px; top: 0px; right: 0px;" />
                    <img src="Images/Photos/JoseteAlmeria.jpg" alt="" class="TableElement3" style="width: 180px; height: 230px; top: 96px; left: 116px;" />
                    <img src="Images/Photos/juanan%20bici.jpg" alt="" class="TableElement3" style="width: 250px; height: 200px; top: 402px; left: 517px;" />
                    <img src="Images/Photos/llano.jpg" alt="" class="TableElement2" style="width: 280px; height: 200px; top: 217px; left: 666px;" />
                    <img src="Images/Photos/carlosAgua.jpg" alt="" class="TableElement2" style="width: 180px; height: 200px; top: 579px; left: 382px;" />
                    <img src="Images/Photos/sabidavid.jpg" alt="" class="TableElement2" style="width: 200px; height: 180px; top: 262px; left: 386px;" />
                    <a href="https://www.facebook.com/sharptheclubthepage">
                        <img src="Images/PostIts/Post-it_Green.png" alt="" class="TableElement3" style="width: 240px; height: 240px; top: 259px; left: -47px;" />
                    </a>
                    <img src="Images/PostIts/Post-it_Yellow.png" alt="" class="TableElement3" style="width: 240px; height: 240px; top: 281px; left: 903px;" />
                </div>
            </section>

            <section id="BottonPanels">
                <a href="theRush/theRush.aspx">
                    <img class="BottonMenuImage" src="Images/Logos/theRush.PNG" alt="" /></a>
                <a href="theRush/Calendario.aspx">
                    <img class="BottonMenuImage" src="Images/Logos/calendario.png" alt="" /></a>
                <a href="theShop/theShop.aspx">
                    <img class="BottonMenuImage" src="Images/Logos/carrito-compra.jpg" alt="" /></a>
                <a href="theClub/Colab.aspx">
                    <img class="BottonMenuImage" src="Images/Sponsors/sponsorsBN.png" alt="" /></a>
            </section>
        </div>

        <footer>
            <ul id="follow">
                <li>
                    <asp:ImageButton CssClass="FollowImageFooter" ID="ImageButton4" runat="server" ImageUrl="~/Images/Logos/blogger.jpg" PostBackUrl="http://www.sharptheclub.com/" />
                </li>
                <li>
                    <asp:ImageButton CssClass="FollowImageFooter" ID="ImageButton5" runat="server" ImageUrl="~/Images/Logos/facebook.png" PostBackUrl="https://www.facebook.com/sharptheclubthepage" />
                </li>
                <li>
                    <asp:ImageButton CssClass="FollowImageFooter" ID="ImageButton6" runat="server" ImageUrl="~/Images/Logos/twitter.png" PostBackUrl="http://twitter.com/sharptheclub" />
                </li>
                <li>@Powered by #theClub <%: DateTime.Now.Year %></li>
            </ul>
            <table class="float-right">
                <tr>
                    <td style="width: auto">
                        <p class="miniClub">#heClub</p>
                    </td>
                    <td>
                        <img class="center" src="../Images/Logos/theClubMini40x40.jpg" alt="" style="height: 40px; width: 40px; align-items: center" />
                    </td>
                </tr>
            </table>
        </footer>
    </form>
</body>
</html>
