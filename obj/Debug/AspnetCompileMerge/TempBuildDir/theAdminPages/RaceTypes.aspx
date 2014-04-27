<%@ Page Title="Tipos de Pruebas" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="RaceTypes.aspx.cs" Inherits="ClubSite.AdminPages.RaceTypes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <ext:Panel
        ID="Panel1"
        runat="server"
        Title="Tipos de Carrera"
        Frame="true"
        PaddingSummary="5px 5px 0"
        Width="700"
        ButtonAlign="Center">
        <Items>
            <ext:Container ID="Container5" runat="server" Layout="FormLayout" Padding="5">
                <Items>
                    <ext:TextField ID="txbxId" runat="server" FieldLabel="Código :" LabelAlign="Top" Width="50" Padding="5" ReadOnly="true" Cls="ReadOnly" />
                </Items>
            </ext:Container>
            <ext:Container ID="Container1" runat="server" Layout="HBoxLayout" Padding="5">
                <Items>
                    <%--<ext:TextField ID="txbxSportID" runat="server" FieldLabel="" LabelAlign="Top" Width="50" Padding="5" ReadOnly="true" />--%>
                    <ext:ComboBox ID="cbxDeportes" runat="server" FieldLabel="Tipo de Carrera :" LabelAlign="Top" Padding="5"
                        DisplayField="Name" ValueField="SportID" Width="200px" AllowBlank="true" EmptyText="Escoja deporte">
                        <Store>
                            <ext:Store ID="Store2" runat="server" OnReadData="Store2_ReadData">                                
                                <Model>
                                    <ext:Model ID="Model2" runat="server" IDProperty="RaceTypeID">
                                        <Fields>
                                            <ext:ModelField Name="SportID" />
                                            <ext:ModelField Name="Name" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
                    <ext:TextField ID="txbxName" runat="server" FieldLabel="Nombre :" LabelAlign="Top" Width="300" Padding="5" />
                    <ext:TextField ID="txbxPuntos" runat="server" FieldLabel="Puntos :" LabelAlign="Top" Width="50" Padding="5" />
                </Items>
            </ext:Container>
            <ext:Container ID="Container6" runat="server" Layout="FormLayout" ColumnWidth=".5" Padding="5">
                <Items>
                    <ext:TextArea ID="txbxMemo" runat="server" FieldLabel="Descripción :" LabelAlign="Top" Width="650" Height="100" Padding="5" />
                </Items>
            </ext:Container>

            <ext:Container ID="Container4" runat="server" Layout="FormLayout">
                <Items>
                    <ext:GridPanel ID="GridPanel1"
                        runat="server"
                        Title="Listado de Deportes"
                        Frame="true"
                        Height="350">
                        <Store>
                            <ext:Store ID="Store1" runat="server" DataSourceID="SqlDataSource2" PageSize="10">
                                <Model>
                                    <ext:Model ID="Model1" runat="server" IDProperty="RaceTypeID">
                                        <Fields>
                                            <ext:ModelField Name="RaceTypeID" />
                                            <ext:ModelField Name="SportID" />
                                            <ext:ModelField Name="Expr1" />
                                            <ext:ModelField Name="Points" />
                                            <ext:ModelField Name="Name" />
                                            <ext:ModelField Name="Memo" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column ID="Column1" runat="server" DataIndex="RaceTypeID" Text="Código" Width="50" />
                                <%--<ext:Column ID="Column2" runat="server" DataIndex="SportID" Text="Nombre" Width="150" />--%>
                                <ext:Column ID="Column6" runat="server" DataIndex="Expr1" Text="Deporte" Width="100" />
                                <ext:Column ID="Column3" runat="server" DataIndex="Name" Text="Nombre" Width="200" />
                                <ext:Column ID="Column4" runat="server" DataIndex="Points" Text="Puntos" Width="50" />
                                <ext:Column ID="Column5" runat="server" DataIndex="Memo" Text="Descripción" Width="300" />
                            </Columns>
                        </ColumnModel>
                        <View>
                            <ext:GridView ID="GridView2" runat="server" StripeRows="true">
                                <GetRowClass Handler="return 'x-grid-row-expanded';" />
                            </ext:GridView>
                        </View>
                        <SelectionModel>
                            <ext:CellSelectionModel ID="CellSelectionModel1" runat="server">
                                <DirectEvents>
                                    <Select OnEvent="GridPanel1_Cell_Click" />
                                </DirectEvents>
                            </ext:CellSelectionModel>
                        </SelectionModel>
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolbar1" runat="server">
                                <Items>
                                    <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                    <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                    <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
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
                                    <ext:ProgressBarPager ID="ProgressBarPager1" runat="server" />
                                </Plugins>
                            </ext:PagingToolbar>
                        </BottomBar>
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="Button4" runat="server" Text="Imprimir" Icon="Printer" Handler="this.up('grid').print();" />
                                    <ext:Button ID="Button5" runat="server" Text="Imprimir Página" Icon="Printer" Handler="this.up('grid').print({currentPageOnly : true});" />
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                    </ext:GridPanel>
                </Items>
            </ext:Container>
        </Items>
        <Buttons>
            <ext:Button ID="Button1" runat="server" Text="Nuevo" Width="150">
                <Listeners>
                    <Click Handler="App.direct.AskNew();" />
                </Listeners>
            </ext:Button>
            <ext:Button ID="Button2" runat="server" Text="Grabar" Width="150px">
                <Listeners>
                    <Click Handler="App.direct.AskSave();" />
                </Listeners>
            </ext:Button>
            <ext:Button ID="Button3" runat="server" Text="Deshacer" Width="150px">
                <Listeners>
                    <Click Handler="App.direct.AskCancel();" />
                </Listeners>
            </ext:Button>
            <ext:Button ID="btnBorrar" runat="server" Text="Borrar" Width="150px">
                <Listeners>
                    <Click Handler="App.direct.AskDel();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Panel>

    <asp:SqlDataSource
        ID="SqlDataSource2"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:ClubSiteConn %>"
        SelectCommand="SELECT RaceTypes.RaceTypeID, RaceTypes.Name, RaceTypes.Points, RaceTypes.Memo, RaceTypes.SportID, Sports.Name AS Expr1 
                       FROM RaceTypes INNER JOIN Sports ON RaceTypes.SportID = Sports.SportID 
                       ORDER BY RaceTypes.Name" />
</asp:Content>
