<%@ Page Language="VB" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="false" CodeFile="frmBuscarGrupos.aspx.vb" Inherits="SECGEN_TD_frmBuscarGrupos" title="BuscarGrupos" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script language="javascript" src="../js/popCalendar.js" type="text/javascript"></script>
    <style type="text/css">
        .BotonCuerpo{
            -webkit-border-radius: 11;
            -moz-border-radius: 11;
            border-radius: 3px;
            font-family: Arial;
            color: #ffffff;
            font-size: 11px;
            background: #3498db;
            border: solid #003d63 2px;
            text-decoration: none;
            padding: 3px 20px 3px 20px;
            vertical-align:middle;
        }
            .BotonCuerpo:hover {
                background: #74c9cc;
                text-decoration: none;
            }
    </style>  
    <center>
        <img alt="" src="../images/Imagenes/Imagenes_Institucional/borde-pie.gif" width="100%" />        
            <center>
                <div style="height:10px"></div>
                <asp:Label ID="Label16" runat="server" CssClass="Title" Height="20px" Font-Size="14px"
                     Text="B&uacutesqueda de Grupos"></asp:Label>
                
                
                <table>
                    <tr align="center">
                        <td align="center" style="width: 799px">
                            <table id="TABLE1" class="Agrupacion" language="javascript">
                                <tr>
                                    <td>
                                    <div style="height:10px;"></div></td>
                                </tr>   
                                <tr>                                    
                                    <td align="center" style="width: 100px;">
                                        <asp:Label ID="Label17" runat="server" CssClass="text01-caja01" Text="Grupo :"
                                            Width="62px"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                                    <asp:TextBox ID="txtTrabajadorBus" runat="server" Tag="MyTag" CssClass="texto8pt" Width="98%"
                                                        BackColor="White" ReadOnly="False"></asp:TextBox>
                                    </td>
                                    <td style="width: 108px;" class="auto-style4" align="center">
                                                    <asp:ImageButton ID="btnBuscarTrabajadorBus" runat="server" 
                                                        ImageUrl="~/images/Imagenes/Imagenes_botones/btnLupa.gif" 
                                                        CausesValidation="False" Width="16px">
                                                    </asp:ImageButton>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td align="left" style="width: 100px">
                                    </td>
                                    <td style="width: 166px">
                                    </td>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 108px" class="auto-style4">
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td align="center" colspan="4">
                                <div style="height:10px"></div>
                                        &nbsp;<asp:Button ID="btnNuevoServicio" runat="server" Text="Nuevo" CssClass="BotonCuerpo" />
                                        &nbsp;<asp:Button ID="btnCorreo" runat="server" Text="Correo" Visible="False" CssClass="BotonCuerpo" />
                                        
                                    <div style="height:10px"></div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 799px; height: 10px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 799px; height: 10px;">
                            <asp:Label ID="LblCountReg" runat="server" Width="312px" CssClass="text01-caja01"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 799px">
                            <div id="div2" style="overflow: auto; height: 300px">
                                <asp:GridView ID="gvwDocsReferenciados" runat="server" AutoGenerateColumns="False"
                                    BorderStyle="None" BorderWidth="1px" Width="776px" 
                                    Height="153px" AllowPaging="True">
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <FooterStyle BackColor="#E6E6EF" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Seleccionar">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="caja04-head" ForeColor="White" Width="40px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSeleccionar" runat="server" CommandName="Seleccionar" ImageUrl="~/images/icono_flecha.gif"
                                                    ToolTip="Seleccionar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="OrganizationalUnitId" HeaderText="ID" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="caja04-head" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        <asp:BoundField HeaderText="Nombre" DataField="Name">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="caja04-head" ForeColor="White" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Description" HeaderText="Descripci&oacuten" HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Center" />
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
                    <%--<tr>
                        <td align="center" valign="top" style="width: 799px">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" />
                        </td>
                    </tr>--%>
                </table>
    </center>
   </center>
   <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="width: 5px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <%--<td>
                <img width="100%" alt="" src="../images/Imagenes/Imagenes_Institucional/borde-pie.gif" />
            </td>--%>
        </tr>
    </table>        
</asp:Content>
