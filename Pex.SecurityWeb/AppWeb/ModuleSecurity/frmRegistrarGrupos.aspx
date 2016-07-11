<%@ Page Language="VB" MasterPageFile="~/Master/MasterPage.Master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="frmRegistrarGrupos.aspx.vb" Inherits="SECGEN_TD_frmRegistrarGrupo"
    Title="REGISTRAR ATENCION DE SERVICIOS HD" %>

<%@ Register Src="../UserControls/wucTab.ascx" TagName="wucTab" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/MensajeExito.ascx" TagName="Mensaje" TagPrefix="mjeExito" %>
<%@ Register Src="~/UserControls/MensajeInformacion.ascx" TagName="Mensaje" TagPrefix="mjeInfo" %>
<%--<%@ Register tagname="Mensaje" tagprefix="mjeExito" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="../js/Funciones.js" type="text/javascript"></script>
    <style type="text/css">
        .MenuDisplay {
            -webkit-border-radius: 11;
            -moz-border-radius: 11;
            border-radius: 11px;
            font-family: Arial;
            color: #ffffff;
            font-size: 15px;
            background: #3498db;
            border: solid #003d63 2px;
            text-decoration: none;
        }
        .BotonMenu {
            -webkit-border-radius: 11;
            -moz-border-radius: 11;
            border-radius: 11px;
            font-family: Tahoma;
            color: #ffffff;
            font-size: 12px;
            background: #3498db;
            border: solid #3498db 2px;
            padding: 3px 25px 3px 25px;
            text-decoration: none;
        }
        .BotonMenu:hover {
            background: #74c9cc;
            text-decoration: none;
            border: solid #74c9cc 2px;
        }
    </style>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="height: 10px" colspan="2">
                <img alt="" src="../images/Imagenes/Imagenes_Institucional/borde-pie.gif" width="100%" />
            </td>
        </tr>
        <%--<tr>
            <td style="height: 10px;" colspan="2">&nbsp;</td>
        </tr>--%>
        <%--<tr>
            <td style="height: 10px;" colspan="2">
                <mjeInfo:Mensaje ID="mjeInformacion" runat="server" />
            </td>
        </tr>--%>
        <%--<tr>
            <td style="height: 10px;" colspan="2">
                <mjeExito:Mensaje ID="mjeExito" runat="server" />
            </td>
        </tr>--%>
        <%--<tr>
            <td style="height: 10px;" colspan="2">&nbsp;</td>
        </tr>--%>

        <tbody align="center">

            <tr>

                <%--<td style="height: 23px">
                </td>--%>
            </tr>
        </tbody>
    </table>

    <center>  
        <div style="height:10px"></div>
        
        <table>            
            <asp:Label ID="lbTitulo" runat="server" CssClass="Title" Height="20px" Font-Size="14px"
            Text="REGISTRAR GRUPO"></asp:Label>
            <td  class="MenuDisplay">                    
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="BotonMenu"/>
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="BotonMenu" OnClick="btnGrabar_Click" OnClientClick="if ( !confirm('\u00BFDesea guardar el registro actual?')) return false;"  />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="BotonMenu" OnClick="btnCancelar_Click" OnClientClick="if ( !confirm('\u00BFConfirma que desea cancelar la operaci\u00f3n actual?\nPerder\u00e1 las modificaciones realizadas')) return false;"  />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CausesValidation="False" CssClass="BotonMenu"/>                    
            </td>            
        </table>      
        <div style="height:10px"></div>
        <table>
            <tr>
                <td>
                    <table class="Agrupacion">
                        <tbody>
                            <tr>
                                <td>
                                    <table style="width: 620px">
                                        <tbody>
                                            <tr>
                                                <td align="rigth">                                                    
                                                    &nbsp;&nbsp;                                                    
                                                    <asp:Label ID="Label19" runat="server" CssClass="text01-caja01" Width="91px" 
                                                        Text="Nombre : " Height="16px"></asp:Label></td>
                                                <td style="height: 40px" align="center">
                                                    <asp:TextBox ID="txtNombreGrupo" runat="server" CssClass="texto8pt" Width="400px" BackColor="White"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="rfvAdministrado4" runat="server" ControlToValidate="txtNombreGrupo"
                                                        ErrorMessage="Ingrese el codigo generado para la atencion." SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="center" >                                                   
                                                    <asp:Label ID="Label9" runat="server" CssClass="text01-caja01" Width="96px" 
                                                        Text="Descripci&oacuten : " Height="16px"></asp:Label></td>
                                                <td colspan="2" style="height: 80px" align="center">
                                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="texto8pt" Width="400px" MaxLength="100" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                            </tr>
                                            <%--<tr>
                                                <td align="left" colspan="3">
                                                </td>
                                            </tr>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="height: 7px">
                                                    &nbsp;</td>
                                            </tr>--%>
                                            <%--<tr>
                                                <td align="left" colspan="3" style="height: 43px">
                                                <input id="hdnCodigoADM" type=hidden name="hdnCodigoADM" runat=server style="width: 50px" /><input id="hdnCodigoUO" type=hidden name="hdnCodigoUO" runat=server style="width: 50px" />&nbsp;
                                                    <asp:HiddenField
                                                                        ID="hdnRespuesta" runat="server" EnableViewState="False" />
                                                    <input id="hdnDescripcionJerarquia" type="hidden" name="hdnDescripcionJerarquia" runat=server style="width: 50px" /></td>
                                            </tr>--%>
                                        </tbody>
                                    </table>
                                    <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" />--%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
        <div style="height:20px"></div>
    </center>
    <%--<table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="width: 5px">&nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <img alt="" src="../images/Imagenes/Imagenes_Institucional/borde-pie.gif" width="100%" />
            </td>
        </tr>
    </table>--%>
</asp:Content>

