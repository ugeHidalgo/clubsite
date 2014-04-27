<%@ Page Title="Registro de nuevo usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ClubSite.Account.Register" %>

<asp:Content runat="server" ID="HeadContent1" ContentPlaceHolderID="TitleContent">
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <style type="text/css">
        .auto-style3 {
            text-align: right;
            width: 155px;
        }
        .auto-style4 {
            width: 304px;
            text-align: left;
        }
    </style>

    <hgroup class="title">
        <h4 style="color: black;">Usa este formulario para crear un nuevo usuario.</h4>
    </hgroup>

    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="message-info">
                        La contraseña debe tener una longitud mínima de <%: Membership.MinRequiredPasswordLength %> caracteres.
                    </p>

                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <legend>Formulario de Petición de Registro</legend>
                        <ol>
                            <li>
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">Nombre de Usuario</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="Falta el nombre de usuario." />
                            </li>
                            <li>
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="Email">Dirección eMail</asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="Falta el mail" />
                            </li>
                            <li>
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="Falta el password." />
                            </li>
                            <li>
                                <asp:Label ID="Label4" runat="server" AssociatedControlID="ConfirmPassword">Confirma el password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ConfirmPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Falta la confirmación del password." />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="El password y su confirmación no coinciden." />
                            </li>
                        </ol>

                        <table style="width: 800px; margin: 5px auto 5px 5px; border: thin;">
                            <tr>
                                <td rowspan="4" class="auto-style1">
                                    <asp:Image ID="imgNImageURL" runat="server" Style="height: 120px; width: 100px; border: solid" />&nbsp;
                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Número de equipo"></asp:Label>
                                    <br />
                                    <asp:Button Text="Borrar" runat="server" ID="btnBorraNImage" OnClick="btnBorraNImage_Click" />
                                    <asp:Button Text="Subir" runat="server" ID="btnSubirNImage" OnClick="btnSubirNImage_Click" />
                                    <asp:FileUpload ID="FileUploadNumber" runat="server" /><br />
                                </td>
                                <td class="auto-style2">
                                    <asp:Label ID="Label5" runat="server" Text="Nombre :" Font-Bold="True"></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txbxName" runat="server" Width="117px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txbxName"
                                        CssClass="field-validation-error" ErrorMessage="Falta el nombre de usuario." />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label6" runat="server" Text="Apellidos :" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txbxSecondName" runat="server" Width="313px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label7" runat="server" Text="Blog Personal :" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txbxBlog" runat="server" Width="310px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label8" runat="server" Text="DNI :" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txbxDNI" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="4" class="auto-style1">
                                    <asp:Image ID="imgImageURL" runat="server" Style="height: 120px; width: 100px; border: solid" />&nbsp;
                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Imagen"></asp:Label>
                                    <br />
                                    <asp:Button ID="btnBorraImage" Text="Borrar" runat="server" OnClick="btnBorraImage_Click" />
                                    <asp:Button Text="Subir" runat="server" ID="btnSubirImage" OnClick="btnSubirImage_Click" />
                                    <asp:FileUpload ID="FileUploadImage" runat="server" /><br />
                                </td>
                                <td class="auto-style2">
                                    <asp:Label ID="Label11" runat="server" Text="Fecha Nacimiento :" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txbxBdate" runat="server" Width="87px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label14" runat="server" Text="Número Clubber :" Font-Bold="True"></asp:Label>
                                </td>
                                <td>                                    
                                    <asp:TextBox ID="txbxClubNumber" runat="server" Width="50px"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label12" runat="server" Text="Federado :" Font-Bold="True"></asp:Label>
                                </td>
                                <td>                                    
                                    <asp:CheckBox ID="chbxFederated" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;                          
                                </td>
                                <td>&nbsp;                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                        </table>


                        <table style="width: 800px; margin: 5px auto 5px 5px; border: thin;">
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="LaTlf" runat="server" Text="Tlf :" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txbxTlf" runat="server" Width="100px"></asp:TextBox>
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="LaMovil" runat="server" Text="Móvil :" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txbxMobile" runat="server" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="LaCalle" runat="server" Text="Calle :" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txbxStreet" runat="server" Width="310px"></asp:TextBox>
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="LaNumero" runat="server" Text="Número :" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txbxNumber" runat="server" Width="50px"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="LaPoblacion" runat="server" Text="Población :" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txbxCity" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="LaPais" runat="server" Text="País :" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txbxCountry" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="LaCPostal" runat="server" Text="C.Postal :" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txbxPostalCode" runat="server" Width="100px"></asp:TextBox>
                                </td>
                                <td class="auto-style3">&nbsp                
                                </td>
                                <td class="auto-style4">&nbsp           
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="Label13" runat="server" Text="Observaciones :" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:TextBox ID="txbxMemo" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                        <asp:Button ID="Button1" runat="server" CommandName="MoveNext" Text="Registrar" />
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
