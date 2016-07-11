<%@ Page Language="VB" MasterPageFile="~/Master/MasterPage.Master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="frmRegistrarUsuarios.aspx.vb" Inherits="SECGEN_TD_frmRegistroUsuarios"
    Title="REGISTRAR USUARIOS" %>

<%@ Register Src="../UserControls/wucTab.ascx" TagName="wucTab" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/MensajeExito.ascx" TagName="Mensaje" TagPrefix="mjeExito" %>
<%@ Register Src="~/UserControls/MensajeInformacion.ascx" TagName="Mensaje" TagPrefix="mjeInfo" %>
<%--<%@ Register tagname="Mensaje" tagprefix="mjeExito" %>--%>
<script runat="server">

    Protected Sub menuTabs_MenuItemClick(sender As Object, e As MenuEventArgs)
        multiTabs.ActiveViewIndex = Int32.Parse(menuTabs.SelectedValue)
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="../js/Funciones.js" type="text/javascript"></script>
    <style type="text/css">
        .BotonCuerpo {
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
            vertical-align: middle;
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
    </table>
    <center>
        <div style="height: 10px"></div>
        <table>            
            <asp:Label ID="Label2" runat="server" CssClass="Title" Height="20px" Font-Size="14px"
            Text="REGISTRAR USUARIO"></asp:Label>
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
                                    <table style="width: 826px">
                                        <tbody>
                                            <tr>
                                                <td align="left" colspan="1" style="width: 104px; height: 25px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label23" runat="server" CssClass="text01-caja01" Width="75px" 
                                                        Text="Nombre : "></asp:Label></td>
                                                <td style="height: 25px; width: 450px;">
                                                    <asp:TextBox ID="txtNombreRol" runat="server" Tag="MyTag" CssClass="texto8pt" Width="400px"
                                                        BackColor="White" ReadOnly="False"></asp:TextBox>
                                                </td>
                                                <td align="left" style="height: 25px;">
                                                    <asp:Label ID="Label24" runat="server" CssClass="text01-caja01" Width="63px" 
                                                        Text="Estado : "></asp:Label><asp:CheckBox ID="chkEnabled" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="1" style="height: 57px; width: 83px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label20" runat="server" CssClass="text01-caja01" Width="75px" Text="Trabajador : "></asp:Label>
                                                </td>
                                                <td colspan="2" style="height: 57px">                                                    
                                                    <asp:DropDownList ID="cboReference" runat="server" CssClass="texto8pt" Width="400px" Height="30px"></asp:DropDownList> 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="1" style="height: 57px; width: 83px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label9" runat="server" CssClass="text01-caja01" Width="75px" Text="Grupo : "></asp:Label></td>
                                                <td colspan="2" style="height: 57px">                                                    
                                                    <asp:DropDownList ID="cboGrupos" runat="server" CssClass="texto8pt" Width="400px" Height="30px"></asp:DropDownList>                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="1" style="height: 57px; width: 83px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label21" runat="server" CssClass="text01-caja01" Width="75px" Text="Contrase&ntildea : "></asp:Label></td>
                                                <td colspan="2" style="height: 57px">                                                    
                                                    <asp:TextBox ID="txtPassword" runat="server" Width="400px" BackColor="White" Type="Password" Text=""></asp:TextBox>                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="1" style="height: 57px; width: 83px;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label22" runat="server" CssClass="text01-caja01" Width="75px" Text="Confirmar : "></asp:Label>
                                                </td>
                                                <td colspan="2" style="height: 57px">                                                    
                                                    <asp:TextBox ID="txtPassword2" runat="server" Width="400px" BackColor="White" Type="Password" Text=""></asp:TextBox>
                                                </td>                                                
                                            </tr>                                            
                                            <tr>                                                    
                                                <asp:Menu id="menuTabs" CssClass="menuTabs" StaticMenuItemStyle-CssClass="tab" StaticSelectedStyle-CssClass="selectedTab" Orientation="Horizontal"
                                                    OnMenuItemClick="menuTabs_MenuItemClick" Runat="server">
                                                    <Items>
                                                        <asp:MenuItem Text="Roles" Value="0" Selected="true" />
                                                        <asp:MenuItem Text="Politicas" Value="1"/>            
                                                    </Items>
                                                </asp:Menu>    
                                                <div class="tabBody" style="align-content:center" align="center">
                                                    <asp:MultiView id="multiTabs" ActiveViewIndex="0" Runat="server">        
                                                        <asp:View ID="TabRoles" runat="server" >
                                                            <table>
                                                                <tr >
                                                                    <td >
                                                                        <asp:Button ID="btnAsignarRoles"  CausesValidation="True" runat="server" Text="Asignar Roles" CssClass="BotonCuerpo"/>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div id="div3" style="overflow: auto; height: 295px">
                                                            <asp:GridView ID="gvwDocsReferenciados" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" Width="776px" Height="153px" AllowPaging="True">
                                                                <PagerSettings Mode="NumericFirstLast" />
                                                                <FooterStyle BackColor="#E6E6EF" Font-Bold="True" ForeColor="White" />
                                                                <Columns>                                        
                                                                    <asp:TemplateField HeaderText="Seleccionar"> 
                                                                         <ItemStyle HorizontalAlign="Center" />
                                                                         <HeaderStyle CssClass="caja04-head" ForeColor="White" HorizontalAlign="Center" Width="40px"/>
                                                                         <ItemTemplate>
                                                                            <asp:CheckBox ID="chkEsActivo" runat="server" Checked='<%# Eval("Selected")%>' />
                                                                         </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="PrincipalId" HeaderText="ID" HtmlEncode="False">
                                                                         <ItemStyle HorizontalAlign="center" />
                                                                         <HeaderStyle CssClass="caja04-head" ForeColor="White" HorizontalAlign="Center" Width="40"/>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="PrincipalName" HeaderText="Rol" HtmlEncode="False">
                                                                         <ItemStyle HorizontalAlign="center" />
                                                                         <HeaderStyle CssClass="caja04-head" ForeColor="White" HorizontalAlign="Center"/>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Intervalo de Fechas">
                                                                         <ItemStyle HorizontalAlign="Center" />
                                                                         <HeaderStyle CssClass="caja04-head" ForeColor="White" Width="40px" HorizontalAlign="Center"/>
                                                                         <ItemTemplate>
                                                                            <asp:ImageButton ID="btnSeleccionar" runat="server" CommandName="Seleccionar" ImageUrl="~/images/icono_flecha.gif" ToolTip="Seleccionar" />
                                                                         </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                 <RowStyle BackColor="#E6E6EF" CssClass="GridRow" ForeColor="#333333" />
                                                                 <EditRowStyle BackColor="#999999" />
                                                                 <SelectedRowStyle BackColor="#E6E6EF" Font-Bold="True" ForeColor="#333333" />
                                                                 <PagerStyle BackColor="#E6E6EF" ForeColor="Black" HorizontalAlign="Right" />
                                                                 <HeaderStyle BackColor="#284775" Font-Bold="True" ForeColor="White" Wrap="True" />
                                                                 <AlternatingRowStyle BackColor="#F2F2F7" CssClass="GridAltRow" />
                                                            </asp:GridView>
                                                            <asp:Label ID="LblPagina" runat="server" CssClass="text01-caja01" Height="20px" Width="791px" Visible="False"></asp:Label>
                                                            </div>
                                                        </asp:View>
                                                        <asp:View ID="TabPoliticas" runat="server">
                                                            <div id="div4" style="overflow: auto; height: 295px">
                                                                <table>
                                                                    <tr>
                                                                        <td align="left" colspan="2" style="width: 600px;">                         
                                                                             <%--<asp:Label ID="Label25" runat="server" CssClass="text01-caja01" Text="Asignado : " Width="75px"></asp:Label>--%>
                                                                             <asp:RadioButton ID="rbtAsignado" runat="server" Text="Asignado" GROUPNAME="GRUPO1" />&nbsp;
                                                                             <%--<asp:Label ID="Label26" runat="server" CssClass="text01-caja01" Text="No Asignado :"  Width="75px"></asp:Label>--%>
                                                                             <asp:RadioButton ID="rbtNoAsignado" runat="server" Text="No Asignado" GROUPNAME="GRUPO1" />
                                                                             &nbsp;&nbsp;&nbsp;&nbsp;
                                                                             <asp:Button ID="btnBuscarPoliticas" runat="server" Text="Buscar" Visible="True" CssClass="BotonCuerpo" /><BR>
                                                                        </td>
                                                                        <td align="center" colspan="2">
                                                                             <asp:Button ID="btnGrabarPoliticas"  CausesValidation="True" runat="server" Text="Grabar Politicas" CssClass="BotonCuerpo"/>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <asp:GridView ID="gvwDocsReferenciados2" runat="server" AutoGenerateColumns="False"
                                                                     BorderStyle="None" BorderWidth="1px" Width="776px" 
                                                                     Height="153px" AllowPaging="True">
                                                                     <PagerSettings Mode="NumericFirstLast" />
                                                                     <FooterStyle BackColor="#E6E6EF" Font-Bold="True" ForeColor="White" />
                                                                     <Columns>
                                                                         <asp:TemplateField HeaderText="Seleccionar">
                                                                             <ItemStyle HorizontalAlign="Center" />
                                                                             <HeaderStyle CssClass="caja04-head" ForeColor="White" Width="40"/>
                                                                             <ItemTemplate>
                                                                                 <asp:CheckBox ID="chkEsActivo" runat="server" OnCheckedChanged="chkEnabled_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("Selected")%>' />
                                                                             </ItemTemplate>
                                                                         </asp:TemplateField>
                                                                         <asp:BoundField DataField="PoliticId" HeaderText="ID" HtmlEncode="False">
                                                                              <ItemStyle HorizontalAlign="center" />
                                                                              <HeaderStyle CssClass="caja04-head" ForeColor="White" HorizontalAlign="Center" Width="40"/>
                                                                         </asp:BoundField>
                                                                         <asp:BoundField DataField="PoliticName" HeaderText="Politicas" HtmlEncode="False">
                                                                              <ItemStyle HorizontalAlign="left" />
                                                                              <HeaderStyle CssClass="caja04-head" ForeColor="White" HorizontalAlign="Center" />
                                                                         </asp:BoundField>
                                                                         <asp:TemplateField HeaderText="Fecha de Disponibilidad">
                                                                              <ItemStyle HorizontalAlign="Center" />
                                                                              <HeaderStyle CssClass="caja04-head" ForeColor="White" Width="40px" />
                                                                              <ItemTemplate>
                                                                                  <asp:ImageButton ID="btnSeleccionar" runat="server" CommandName="Seleccionar" ImageUrl="~/images/icono_flecha.gif" ToolTip="Seleccionar" />
                                                                              </ItemTemplate>
                                                                         </asp:TemplateField>
                                                                    </Columns>
                                                                     <RowStyle BackColor="#E6E6EF" CssClass="GridRow" ForeColor="#333333" />
                                                                     <EditRowStyle BackColor="#999999" />
                                                                     <SelectedRowStyle BackColor="#E6E6EF" Font-Bold="True" ForeColor="#333333" />
                                                                     <PagerStyle BackColor="#E6E6EF" ForeColor="Black" HorizontalAlign="Right" />
                                                                     <HeaderStyle BackColor="#284775" Font-Bold="True" ForeColor="White" Wrap="True" />
                                                                     <AlternatingRowStyle BackColor="#F2F2F7" CssClass="GridAltRow" />
                                                                </asp:GridView>
                                                                <asp:Label ID="Label1" runat="server" CssClass="text01-caja01" Height="20px" Width="791px" Visible="False"></asp:Label>
                                                            </div>
                                                            <%--<td align="center" colspan="3" style="height: 7px"></td>
                                                            <td align="left" colspan="3" style="height: 43px">
                                                            <tr>
                                                                <td align="left" colspan="3" style="height: 43px"></td>
                                                            </tr>--%>
                                                        </asp:View>
                                                    </asp:MultiView>    
                                                </div>                                            
                                            </tr>
                                            <%--<tr>
                                                <td align="left" colspan="3">&nbsp;</td>
                                            </tr>--%>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>

