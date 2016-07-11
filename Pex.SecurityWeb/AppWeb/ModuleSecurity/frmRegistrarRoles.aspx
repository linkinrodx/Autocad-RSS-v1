<%@ Page Language="VB" MasterPageFile="~/Master/MasterPage.Master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="frmRegistrarRoles.aspx.vb" Inherits="SECGEN_TD_frmRegistrarRoles"
    Title="REGISTRAR ATENCION DE SERVICIOS HD" %>

<%@ Register Src="../UserControls/wucTab.ascx" TagName="wucTab" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/MensajeExito.ascx" TagName="Mensaje" TagPrefix="mjeExito" %>
<%@ Register Src="~/UserControls/MensajeInformacion.ascx" TagName="Mensaje" TagPrefix="mjeInfo" %>
<%--<%@ Register tagname="Mensaje" tagprefix="mjeExito" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="../js/Funciones.js" type="text/javascript"></script>
    <style type="text/css">
        .BotonCuerpo{
            -webkit-border-radius: 11;
            -moz-border-radius: 11;
            border-radius: 3px;
            font-family: Arial;
            color: #ffffff;
            font-size: 11px;
            background: #3498db;
            border: solid #0e4b6e 2px;
            text-decoration: none;
            padding: 3px 20px 3px 20px;
            vertical-align:middle;
        }
            .BotonCuerpo:hover {
                background: #74c9cc;
                text-decoration: none;
            }

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
        <%--<tbody>
            <tr>
                <td align="left" style="height: 23px; width: 803px;">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                </td>
                <td align="left" style="height: 23px">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CausesValidation="False" />
                </td>
            </tr>
        </tbody>--%>
        <%--<tr>
            <td style="height: 10px;" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 10px;" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 10px;" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 10px;" colspan="2">
                &nbsp;</td>
        </tr>--%>
    </table>
    <center>
        <div style="height:10px"></div>
        <table>            
            <asp:Label ID="Label1" runat="server" CssClass="Title" Height="20px" Font-Size="14px"
            Text="REGISTRAR ROLES"></asp:Label>
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
                <td style="width: 98px" align="center">
                    <table class="Agrupacion">
                        <tbody>
                            <tr>
                                <td colspan="6">
                                    <table style="width: 826px; height: 524px; margin-right: 0px;">
                                        <tbody>
                                            <tr>
                                                <td align="left" colspan="1" style="width: 136px; height: 29px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label19" runat="server" CssClass="text01-caja01" Width="90px" 
                                                        Text="Nombre : " Height="16px"></asp:Label></td>
                                                <td style="height: 40px; width: 450px;" colspan="2">
                                                    <asp:TextBox ID="txtNombreRol" runat="server" CssClass="texto8pt" Width="400px" BackColor="White"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="rfvAdministrado4" runat="server" ControlToValidate="txtNombreRol"
                                                        ErrorMessage="Ingrese el codigo generado para la atencion." SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                <td align="left" style="height: 29px">
                                                    <asp:Label ID="Label24" runat="server" CssClass="text01-caja01" Width="58px" 
                                                        Text="Estado : "></asp:Label>
                                                    <asp:CheckBox ID="chkEnabled" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="1" style="height: 35px; width: 136px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label14" runat="server" CssClass="text01-caja01" Width="88px" 
                                                        Text="Grupos :"></asp:Label>
                                                                </td>
                                                <td colspan="3" style="height: 35px">
                                                    
                                                    <asp:DropDownList ID="cboGrupos" runat="server" CssClass="texto8pt" 
                                                        Width="191px">
                                                    </asp:DropDownList>
                                                    
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="1" style="height: 72px; width: 136px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label9" runat="server" CssClass="text01-caja01" Width="89px" 
                                                        Text="Descripci&oacuten : "></asp:Label></td>
                                                <td colspan="3" style="height: 80px">                                                    
                                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="texto8pt" Width="400px" MaxLength="150" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2" style="height: 77px; width: 1471px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:RadioButton ID="rbtGranted" runat="server" Text="Asignado" GROUPNAME=GRUPO1 Checked="True" />
                                                    &nbsp;
                                                    <asp:RadioButton ID="rbtNoGranted" runat="server" Text="No Asignado" GROUPNAME=GRUPO1 />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Visible="True" CssClass="BotonCuerpo" />
                                                </td>
                                                <td align="center" colspan="2" >
                                                <asp:Button ID="btnGrabarPoliticas" runat="server" Text="Grabar Politicas" CssClass="BotonCuerpo"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="4" style="height: 214px">
                                                <div id="div2" style="overflow: auto; height: 295px" align="center">
                                                    <asp:GridView ID="gvwDocsReferenciados" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" Height="153px" Width="776px">
                                                        <PagerSettings Mode="NumericFirstLast" />
                                                        <FooterStyle BackColor="#E6E6EF" Font-Bold="True" ForeColor="White" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Seleccionar">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle CssClass="caja04-head" ForeColor="White" Width="40px" />
                                                                <ItemTemplate>
                                                                   <asp:CheckBox ID="chkEsActivo" runat="server" OnCheckedChanged="chkEnabled_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("Selected")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:BoundField DataField="PoliticId" HeaderText="ID" HtmlEncode="False">
                                                                <ItemStyle HorizontalAlign="center" />
                                                                <HeaderStyle CssClass="caja04-head" ForeColor="White" HorizontalAlign="Center" Width="40"/>
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="Politic" HeaderText="Pol&iacuteticas" HtmlEncode="False">
                                                                <ItemStyle HorizontalAlign="left" />
                                                                <HeaderStyle CssClass="caja04-head" ForeColor="White" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                        </Columns>

                                                        <RowStyle BackColor="#E6E6EF" CssClass="GridRow" ForeColor="#333333" />
                                                        <EditRowStyle BackColor="#999999" />
                                                        <SelectedRowStyle BackColor="#E6E6EF" Font-Bold="True" ForeColor="#333333" />
                                                        <PagerStyle BackColor="#E6E6EF" ForeColor="Black" HorizontalAlign="Right" />
                                                        <HeaderStyle BackColor="#284775" Font-Bold="True" ForeColor="White" Wrap="True" />
                                                        <AlternatingRowStyle BackColor="#F2F2F7" CssClass="GridAltRow" />
                                                    </asp:GridView>
                                                    <asp:Label ID="LblPagina" runat="server" CssClass="text01-caja01" Height="20px" Width="791px" Visible="False"></asp:Label></div>
                        
                                                </td>
                                            </tr>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4" style="height: 7px">
                                                    &nbsp;</td>
                                            </tr>
                                            <%--<tr>
                                                <td align="left" colspan="4" style="height: 43px">
                                                <input id="hdnCodigoADM" type=hidden name="hdnCodigoADM" runat=server style="width: 50px" /><input id="hdnCodigoUO" type=hidden name="hdnCodigoUO" runat=server style="width: 50px" />&nbsp;
                                                    <asp:HiddenField
                                                                        ID="hdnRespuesta" runat="server" EnableViewState="False" />
                                                    <input id="hdnDescripcionJerarquia" type="hidden" name="hdnDescripcionJerarquia" runat=server style="width: 50px" /></td>
                                            </tr>--%>
                                        </tbody>
                                    </table>
                                    <%--&nbsp;&nbsp;
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" />--%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
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

