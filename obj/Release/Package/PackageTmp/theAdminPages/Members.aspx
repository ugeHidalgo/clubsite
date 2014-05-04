<%@ Page Title="Miembros" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="ClubSite.AdminPages.Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <ext:TabPanel ID="TabPanel1"
        Title="Clubbers"
        runat="server"
        Width="750">

        <Items>
            <ext:Panel
                ID="PaDatosPrincipales"
                runat="server"
                Title="Datos Principales"
                Frame="true"
                Width="750"
                ButtonAlign="Center">
                <Items>
                    <ext:Container ID="Container1" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxUserName" runat="server" FieldLabel="User Name :" LabelAlign="Top" Padding="5" Flex="3" />
                            <ext:TextField ID="txbxRegDate" runat="server" FieldLabel="Fecha Registro:" LabelAlign="Top" Padding="5" Flex="2" ReadOnly="true" Cls="ReadOnly" />
                            <ext:TextField ID="txbxClubberNumber" runat="server" FieldLabel="Nº Clubber :" LabelAlign="Top" Padding="5" Flex="2" />
                            <ext:TextField ID="txbxDNI" runat="server" FieldLabel="DNI :" LabelAlign="Top" Padding="5" Flex="3" />
                        </Items>
                        <LayoutConfig>
                            <ext:HBoxLayoutConfig Align="Middle" Pack="Start" />
                        </LayoutConfig>
                    </ext:Container>
                    <ext:Container ID="Container2" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxFirstName" runat="server" FieldLabel="Nombre :" LabelAlign="Top" Padding="5" Flex="3" />
                            <ext:TextField ID="txbxSecondName" runat="server" FieldLabel="Apellidos :" LabelAlign="Top" Padding="5" Flex="5" />
                            <ext:DateField ID="txbxBdate" runat="server" FieldLabel="Fecha Nac :" LabelAlign="Top" Padding="5" Flex="2" />
                        </Items>
                        <LayoutConfig>
                            <ext:HBoxLayoutConfig Align="Middle" Pack="Start" />
                        </LayoutConfig>
                    </ext:Container>
                    <ext:Container ID="ContFotos" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:FormPanel
                                ID="FormImgPanel"
                                runat="server"
                                Width="160"
                                Margins="0 12 0 0"
                                Frame="true">
                                <Defaults>
                                    <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                                    <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                                </Defaults>
                                <Items>
                                    <ext:Image ID="imgImage" runat="server" Height="150" Width="150" AlternateText="(Foto Clubber)" Padding="5" Border="true"  />
                                    <ext:FileUploadField
                                        ID="FileUploadImage"
                                        runat="server"
                                        EmptyText="Seleccione una imagen..."
                                        ButtonText=""
                                        Icon="ImageAdd" />
                                </Items>
                                <Listeners>
                                    <ValidityChange Handler="#{btnCargarLogo}.setDisabled(!valid);" />
                                </Listeners>
                                <Buttons>
                                    <ext:Button ID="btnCargarLogo" runat="server" Text="Cargar" Disabled="true">
                                        <DirectEvents>
                                            <Click
                                                OnEvent="UploadImgClick"
                                                Before="if (!#{FormImgPanel}.getForm().isValid()) { return false; } 
                                Ext.Msg.wait('Subiendo la imagen...', 'Subiendo');"
                                                Failure="Ext.Msg.show({ 
                                title   : 'Error', 
                                msg     : 'Error durante la subida de la imagen', 
                                minWidth: 200, 
                                modal   : true, 
                                icon    : Ext.Msg.ERROR, 
                                buttons : Ext.Msg.OK 
                            });">
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnBorrarImg" runat="server" Text="Borrar">
                                        <Listeners>
                                            <Click Handler="App.direct.BorrarImgClick();" />
                                        </Listeners>
                                    </ext:Button>
                                </Buttons>
                            </ext:FormPanel>
                            <ext:FormPanel
                                ID="FormNImgPanel"
                                runat="server"
                                Width="180"
                                Frame="true"
                                Margins="0 12 0 12">
                                <Defaults>
                                    <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                                    <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                                </Defaults>
                                <Items>
                                    <ext:Image ID="imgNImage" runat="server" Height="150" Width="150" AlternateText="(Imagen Nº Clubber)" Padding="5" Border="true" />
                                    <ext:FileUploadField
                                        ID="FileUploadNumber"
                                        runat="server"
                                        EmptyText="Seleccione una imagen..."
                                        ButtonText=""
                                        Icon="ImageAdd" />
                                </Items>
                                <Listeners>
                                    <ValidityChange Handler="#{btnCargarNImg}.setDisabled(!valid);" />
                                </Listeners>
                                <Buttons>
                                    <ext:Button ID="btnCargarNImg" runat="server" Text="Cargar" Disabled="true">
                                        <DirectEvents>
                                            <Click
                                                OnEvent="UploadNImgClick"
                                                Before="if (!#{FormNImgPanel}.getForm().isValid()) { return false; } 
                                Ext.Msg.wait('Subiendo la imagen...', 'Subiendo');"
                                                Failure="Ext.Msg.show({ 
                                title   : 'Error', 
                                msg     : 'Error during uploading', 
                                minWidth: 200, 
                                modal   : true, 
                                icon    : Ext.Msg.ERROR, 
                                buttons : Ext.Msg.OK 
                            });">
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnBorrarNImg" runat="server" Text="Borrar">
                                        <Listeners>
                                            <Click Handler="App.direct.BorrarNImgClick();" />
                                        </Listeners>
                                    </ext:Button>
                                </Buttons>
                            </ext:FormPanel>
                            <ext:FormPanel
                                ID="FormPanel1"
                                runat="server"
                                Width="160"
                                Margins="0 0 0 12"
                                Border="False"
                                Frame="true">
                                <Defaults>
                                    <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                                    <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                                </Defaults>
                                <Items>
                                    <ext:Checkbox ID="chBxActiveUser" runat="server" FieldLabel="Activado :" LabelAlign="Right" Padding="5" />
                                    <ext:Checkbox ID="chbxVisible" runat="server" FieldLabel="Visible :" LabelAlign="Right" Padding="5" />
                                    <ext:Checkbox ID="chbxFederated" runat="server" FieldLabel="Federado :" LabelAlign="Right" Padding="5" />
                                </Items>
                                <LayoutConfig>
                                    <ext:VBoxLayoutConfig Align="Left" Pack="Center" />
                                </LayoutConfig>
                            </ext:FormPanel>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="ConListado" runat="server" Layout="FormLayout">
                        <Items>
                            <ext:GridPanel ID="GPClubbers"
                                runat="server"
                                Title="Listado de Clubbers"
                                Frame="true"
                                Height="350">
                                <Store>
                                    <ext:Store ID="StoreGPClubbers" runat="server" DataSourceID="SqlDSGPClubbers" PageSize="10">
                                        <Model>
                                            <ext:Model ID="Model1" runat="server" IDProperty="UserName">
                                                <Fields>
                                                    <ext:ModelField Name="Number" />
                                                    <ext:ModelField Name="State" Type="Boolean" />
                                                    <ext:ModelField Name="Federated" Type="Boolean" />
                                                    <ext:ModelField Name="UserName" />
                                                    <ext:ModelField Name="FirstName" />
                                                    <ext:ModelField Name="SecondName" />
                                                    <ext:ModelField Name="RegDate" Type="Date" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:Column ID="Column1" runat="server" DataIndex="Number" Text="Nº" Width="30" />
                                        <ext:CheckColumn ID="Column2" runat="server" DataIndex="State" Text="Act" Width="30" />
                                        <ext:CheckColumn ID="Column3" runat="server" DataIndex="Federated" Text="Fed" Width="30" />
                                        <ext:Column ID="Column4" runat="server" DataIndex="UserName" Text="User Name" Width="100" />
                                        <ext:Column ID="Column5" runat="server" DataIndex="FirstName" Text="Nombre" Width="100" />
                                        <ext:Column ID="Column6" runat="server" DataIndex="SecondName" Text="Apellidos" Width="200" />
                                        <ext:DateColumn ID="Column7" runat="server" DataIndex="RegDate" Text="Alta" Width="70" Format="dd/MM/yyyy" />
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:GridView ID="GVClubbers" runat="server" StripeRows="true">
                                        <GetRowClass Handler="return 'x-grid-row-expanded';" />
                                    </ext:GridView>
                                </View>
                                <SelectionModel>
                                    <ext:CellSelectionModel ID="CellSelectionModel1" runat="server">
                                        <DirectEvents>
                                            <Select OnEvent="GVClubbers_Click" />
                                        </DirectEvents>
                                    </ext:CellSelectionModel>
                                </SelectionModel>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server">
                                        <Items>
                                            <ext:Label ID="Label13" runat="server" Text="Reg/Página :" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="5" />
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="40" />
                                                </Items>
                                                <SelectedItems>
                                                    <ext:ListItem Value="10" />
                                                </SelectedItems>
                                                <Listeners>
                                                    <Select Handler="#{GPClubbers}.store.pageSize = parseInt(this.getValue(), 10); #{GPClubbers}.store.reload();" />
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
                    <ext:Button ID="btnNew" runat="server" Text="Nuevo" Width="150">
                        <Listeners>
                            <Click Handler="App.direct.AskNew();" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="btnSave" runat="server" Text="Grabar" Width="150px">
                        <Listeners>
                            <Click Handler="App.direct.AskSave();" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="btnCancel" runat="server" Text="Deshacer" Width="150px">
                        <Listeners>
                            <Click Handler="App.direct.AskCancel();" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="btnDel" runat="server" Text="Borrar" Width="150px">
                        <Listeners>
                            <Click Handler="App.direct.AskDel();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Panel>
            <ext:Panel
                ID="PaOtrosDatos"
                runat="server"
                Title="Otros Datos"
                Frame="true"
                Width="700"
                ButtonAlign="Center">
                <Items>
                    <ext:Container ID="ContWebMail" runat="server" Layout="VBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxBlogURL" runat="server" FieldLabel="Web :" Width="400" LabelAlign="Top" Padding="5" />
                            <ext:TextField ID="txbxEMail" runat="server" FieldLabel="Mail :" Width="400" LabelAlign="Top" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="ContTlf" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxMobile" runat="server" FieldLabel="Nº de Móvil :" Width="100" LabelAlign="Top" Padding="5" />
                            <ext:TextField ID="txbxTlf" runat="server" FieldLabel="Nº de Tlf :" Width="100" LabelAlign="Top" Padding="5" />
                        </Items>
                        <LayoutConfig>
                            <ext:HBoxLayoutConfig Align="Middle" Pack="Start" />
                        </LayoutConfig>
                    </ext:Container>
                    <ext:Container ID="ConAddress1" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxStreet" runat="server" FieldLabel="Calle :" LabelAlign="Top" Width="600" Padding="5" />
                            <ext:TextField ID="txbxNumber" runat="server" FieldLabel="Nº :" LabelAlign="Top" Width="100" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="ContAddress2" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextField ID="txbxCity" runat="server" FieldLabel="Población :" LabelAlign="Top" Width="300" Padding="5" />
                            <ext:TextField ID="txbxPostalCode" runat="server" FieldLabel="C.Postal :" LabelAlign="Top" Width="90" Padding="5" />
                            <ext:TextField ID="txbxCountry" runat="server" FieldLabel="País :" LabelAlign="Top" Width="300" Padding="5" />
                        </Items>
                    </ext:Container>
                    <ext:Container ID="ContMemo" runat="server" Layout="HBoxLayout" Padding="5">
                        <Items>
                            <ext:TextArea ID="txbxMemo" runat="server" FieldLabel="Observaciones :" LabelAlign="Top" Width="710" Height="200" Padding="5" />
                        </Items>
                    </ext:Container>
                </Items>
            </ext:Panel>
            <ext:Panel
                ID="PaCompeticiones"
                runat="server"
                Title="Competiciones"
                Frame="true"
                Width="700"
                ButtonAlign="Center">
                <Items>
                    <ext:Container ID="ContSelectorRaces" runat="server" Layout="FormLayout" Padding="5">
                        <Items>
                            <ext:ComboBox ID="cbRaces" runat="server" FieldLabel="Competiciones :" LabelAlign="Top" Padding="5"
                                DisplayField="Name" ValueField="Id" Width="690px" AllowBlank="true" EmptyText="Escoja una competición para añadir (Puede usar las fechas para acotar)...">
                                <Store>
                                    <ext:Store ID="StoreCbRaces" runat="server" OnReadData="StoreCbRaces_ReadData">
                                        <Model>
                                            <ext:Model ID="Model3" runat="server" IDProperty="Id">
                                                <Fields>
                                                    <ext:ModelField Name="Id" Type="Int" />
                                                    <ext:ModelField Name="Name" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                            </ext:ComboBox>
                            <ext:Toolbar ID="Toolbar2" runat="server" Width="700px">
                                <Items>
                                    <ext:Button ID="btnAddClubber" runat="server" Text="Añadir" Width="150" Icon="Add">
                                        <Listeners>
                                            <Click Handler="App.direct.AskAddRace();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="btnDelClubber" runat="server" Text="Quitar" Width="150px" Icon="Delete">
                                        <Listeners>
                                            <Click Handler="App.direct.AskDelRace();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="btnDelAllClubber" runat="server" Text="Borrar entre fechas :" Width="150px" Icon="GroupDelete">
                                        <Listeners>
                                            <Click Handler="App.direct.AskDelAllRaces();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:DateField ID="dtfFromDate" runat="server" Type="Date" LabelAlign="Right" Text="Desde:" Width="100">
                                        <Listeners>
                                            <Change Handler="App.direct.ChangedADate();" />
                                        </Listeners>
                                    </ext:DateField>
                                    <ext:DateField ID="dtfToDate" runat="server" Type="Date" LabelAlign="Right" Text="Hasta:" Width="100">
                                        <Listeners>
                                            <Change Handler="App.direct.ChangedADate();" />
                                        </Listeners>
                                    </ext:DateField>
                                </Items>
                            </ext:Toolbar>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="ContRacesForClubber" runat="server" Layout="FormLayout">
                        <Items>
                            <ext:GridPanel ID="GPRacesForClubber"
                                runat="server"
                                Frame="true"
                                Height="350">
                                <Store>
                                    <ext:Store ID="StoreGPRacesForClubber" runat="server" OnReadData="StoreGPRacesForClubber_ReadData" PageSize="10">
                                        <Model>
                                            <ext:Model ID="Model4" runat="server" IDProperty="UserName">
                                                <Fields>
                                                    <ext:ModelField Name="Id" Type="Int" />
                                                    <ext:ModelField Name="RDate" Type="Date" />
                                                    <ext:ModelField Name="SportName" />
                                                    <ext:ModelField Name="RaceTypeName" />
                                                    <ext:ModelField Name="Name" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel2" runat="server">
                                    <Columns>
                                        <ext:DateColumn ID="DateColumn10" runat="server" DataIndex="RDate" Text="Fecha" Width="70" Format="dd/MM/yyyy" />
                                        <ext:Column ID="Column10" runat="server" DataIndex="SportName" Text="Deporte" Width="150" />
                                        <ext:Column ID="Column11" runat="server" DataIndex="RaceTypeName" Text="Tipo" Width="150" />
                                        <ext:Column ID="Column12" runat="server" DataIndex="Name" Text="Nombre" Width="300" />
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:GridView ID="GridView2" runat="server" StripeRows="true">
                                        <GetRowClass Handler="return 'x-grid-row-expanded';" />
                                    </ext:GridView>
                                </View>
                                <SelectionModel>
                                    <ext:CellSelectionModel ID="CellSelectionModel2" runat="server">
                                        <DirectEvents>
                                            <Select OnEvent="GPRacesForClubber_Click" />
                                        </DirectEvents>
                                    </ext:CellSelectionModel>
                                </SelectionModel>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar2" runat="server">
                                        <Items>
                                            <ext:Label ID="Label2" runat="server" Text="Reg/Página :" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox3" runat="server" Width="80">
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
                                            <ext:ProgressBarPager ID="ProgressBarPager2" runat="server" />
                                        </Plugins>
                                    </ext:PagingToolbar>
                                </BottomBar>
                            </ext:GridPanel>
                        </Items>
                    </ext:Container>
                </Items>
            </ext:Panel>
        </Items>
    </ext:TabPanel>

    <asp:SqlDataSource ID="SqlDSGPClubbers" runat="server" ConnectionString="<%$ ConnectionStrings:ClubSiteConn %>"
        SelectCommand="SELECT * FROM Members ORDER BY Members.UserName"></asp:SqlDataSource>

</asp:Content>
