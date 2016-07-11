<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PopIntervaloFechas.aspx.vb"
    Inherits="PopUpBuscarUsuarios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="_self" />
    <title>INTERVALO DE FECHAS</title>
    <link href="../App_Themes/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #txtNombre {
            width: 482px;
            margin-left: 0px;
        }

        .auto-style2 {
            width: 77px;
        }

        .auto-style5 {
            width: 163px;
            height: 34px;
        }

        .auto-style7 {
            width: 330px;
            height: 231px;
        }

        .auto-style8 {
            width: 587px;
        }

        .auto-style9 {
            width: 163px;
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
    </style>
</head>
<body>
    <form id="PopUpBuscarUsuarios" runat="server">
        <div>
            <table style="width: 655px">
                <tr>
                    <td align="center" class="auto-style5">
                        <table class="Agrupacion">
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="lblCabeza" runat="server" CssClass="text01-caja01" Text="Rol :"
                                        Width="69px" Height="16px"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style8">
                                    <asp:TextBox ID="txtRol" runat="server" Width="535px" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <table style="width: 655px">

                            <tr>
                                <td colspan="2" align="center">
                                    <table>
                                        <tr>
                                            <td class="MenuDisplay">
                                                <%--<asp:ImageButton ID="btnGrabar" runat="server" ImageUrl="~/images/b-grabar-off.gif" Width="100px" Height="24px" />
                                                <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/images/b-cancelar-off.gif" />--%>
                                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="BotonMenu" OnClick="btnGrabar_Click" OnClientClick="if ( !confirm('\u00BFDesea guardar el registro actual?')) return false;"  />                    
                                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="BotonMenu" OnClientClick="if ( !confirm('\u00BFConfirma que desea cancelar la operaci\u00f3n actual?\nPerder\u00e1 las modificaciones realizadas')) return false;"  />
                                            </td>
                                        </tr>

                                    </table>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="auto-style7">
                                    <br />
                                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio:"></asp:Label>

                                    <asp:Calendar ID="calFechaInicio" runat="server" DayNameFormat="Shortest" EnableTheming="True" Height="16px" SelectionMode="Day" Style="margin-right: 0px" ToolTip="Fecha de Inicio" Width="234px" FirstDayOfWeek="Monday">
                                        <NextPrevStyle Wrap="True" />
                                        <SelectedDayStyle BackColor="DarkBlue"
                                            ForeColor="White"></SelectedDayStyle>
                                    </asp:Calendar>
                                    <br />
                                    <asp:Label ID="lblHoraInicio" runat="server" Text="Hora Inicio:"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="cboHoraInicio" runat="server" Height="17px" Width="143px"></asp:DropDownList>
                                </td>
                                <td align="center" class="auto-style7">
                                    <br />
                                    <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Fin:"></asp:Label>
                                    <asp:Calendar ID="calFechaFin" runat="server" DayNameFormat="Shortest" EnableTheming="True" Height="16px" SelectionMode="Day" Style="margin-right: 0px" ToolTip="Fecha de Fin" Width="241px" FirstDayOfWeek="Monday">
                                        <NextPrevStyle Wrap="True" />
                                        <SelectedDayStyle BackColor="DarkBlue"
                                            ForeColor="White"></SelectedDayStyle>
                                    </asp:Calendar>
                                    <br />
                                    <asp:Label ID="lblHoraFin" runat="server" Text="Hora Fin:"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="cboHoraFin" runat="server" Height="16px" Width="148px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" class="auto-style6">
                                    <br />
                                    <asp:Label ID="Label17" runat="server" Text="Observaciones:"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Width="384px"></asp:TextBox>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td>
                        <table style="width: 655px">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" Text="Listado de Intervalos:" CssClass="text01-caja01"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnGrabarIntervalos" runat="server" Text="Grabar Intervalos" CssClass="BotonCuerpo" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" class="auto-style1">
                        <asp:GridView ID="gvwLista" runat="server"
                            AutoGenerateColumns="False" GridLines="Horizontal" Width="98%"
                            AllowPaging="True">
                            <FooterStyle BackColor="#E6E6EF" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#E6E6EF" CssClass="GridRow" ForeColor="#333333" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E6E6EF" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#E6E6EF" ForeColor="Black" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="#284775" Font-Bold="True" ForeColor="White" Wrap="True" />
                            <AlternatingRowStyle BackColor="#F2F2F7" CssClass="GridAltRow" />
                            <Columns>
                                <%--<asp:TemplateField HeaderText="Seleccionar">
                                     <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle CssClass="caja04-head" ForeColor="White" Width="40px" />
                                     <ItemTemplate>
                                     <asp:ImageButton ID="btnSeleccionar" runat="server" CommandName="Seleccionar" ImageUrl="~/images/icono_flecha.gif"
                                                    ToolTip="Seleccionar" />
                                     </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Seleccionar">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="caja04-head" ForeColor="White" Width="40px" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkEsActivo" runat="server" Checked='<%# Eval("Enabled")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Correlative" HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="caja04-head" ForeColor="White" HorizontalAlign="Center" Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StartDateStr" HeaderText="Fecha Inicio">
                                    <HeaderStyle CssClass="caja04-head" ForeColor="White" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StartTime" HeaderText="Hora Inicio" Visible="False">
                                    <HeaderStyle CssClass="caja04-head" ForeColor="White" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EndDateStr" HeaderText="Fecha Fin">
                                    <HeaderStyle CssClass="caja04-head" ForeColor="White" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EndTime" HeaderText="Hora Fin" Visible="False">
                                    <HeaderStyle CssClass="caja04-head" ForeColor="White" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        &nbsp;
                    </td>
                </tr>
                <%--<asp:TemplateField HeaderText="Seleccionar">
                                     <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle CssClass="caja04-head" ForeColor="White" Width="40px" />
                                     <ItemTemplate>
                                     <asp:ImageButton ID="btnSeleccionar" runat="server" CommandName="Seleccionar" ImageUrl="~/images/icono_flecha.gif"
                                                    ToolTip="Seleccionar" />
                                     </ItemTemplate>
                                </asp:TemplateField>--%>
            </table>
        </div>
    </form>
</body>
</html>
