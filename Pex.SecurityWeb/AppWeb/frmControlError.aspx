<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmControlError.aspx.vb" Inherits="frmControlError" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>.:. MÓDULO DE SEGURIDAD .:.</title>
    <link href="App_Themes/syllabusAzul/syllabus.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/syllabusAzul/syllabus_celdas.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/syllabusAzul/syllabus_grilla.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/syllabusAzul/syllabus_menu.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .stl_etiqueta {
            FONT-WEIGHT: bold;
            FONT-SIZE: 10px;
            font-family: Arial, Helvetica, sans-serif;
            COLOR: #00005a;
        }

        .auto-style1 {
            background-image: url('App_Themes/syllabusAzul/img/HeaderRepeater.jpg');
            background-repeat: repeat-x;
            height: 95px;
            width: 704px;
        }

        .auto-style2 {
            width: 112px;
        }

        .style5 {
            font-size: 11px;
        }

        .style6 {
            width: 157px;
            font-size: 11px;
        }

        .style7 {
            width: 157px;
            height: 20px;
            font-size: 11px;
        }

        .style8 {
            width: 380px;
        }

        .LogoSecundario {
            width: 800px;
            min-width: 400px;
            background-image: url(images/Imagenes/Imagenes_Institucional/LogoSecundario2.jpg);
            background-repeat: no-repeat;
            background-position: right;
            vertical-align: bottom;
            height: 94px;
            border-top: 1px double #144B72;
        }

        .Agrupador {
            border: 2px solid #003955;
            background-color: #FFFFFF;
            color: #000066;
            text-align: left;
            color: black;
            border: 2px solid;
            border-radius: 10px;
        }

        .usuario-bar {
            width: 254px;
        }

        .auto-style3 {
            width: 795px;
            min-width: 400px;
            background-image: url('images/Imagenes/Imagenes_Institucional/LogoSecundario2.jpg');
            background-repeat: no-repeat;
            background-position: right;
            vertical-align: bottom;
            height: 94px;
            border-top: 1px double #144B72;
        }

        .Linea {
            float: left;
            width: 100%;
            font-size: 5px;
            border-bottom: 1px solid #2763A5;
            line-height: normal;
            background-color: #003955;
            height: 2px;
        }

        .Linked {
            vertical-align: middle;
            height: 40px;
            align-content: center;
            color: black;
            align-items: center;
        }
    </style>
</head>
<body>    
    <form id="frmControlError" runat="server">
        <div id="contenedor">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="auto-style2" >
                        <img alt="" height="95" class="header_repeater" src="images/Imagenes/Imagenes_Institucional/logo.jpg"/ ></td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
            </table>
            <table class="tabla-contenedora" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
	                    <div id="tabs20"></div>		
	                    <div style="height:40px"></div>
	                </td>	   
                </tr>
                <tr>
                    <td align="center" >
                        <table class="Agrupador" width="700px">
                            <td align="center">
                                <div align="center">
                                    <br />
			                        <span><strong>No se puede encontrar la página web<br />
                                    <br />
                                    </strong></span>                                    
                                    <div class="Linea"></div>
                                    <div style="height:15px"></div>
		                            <asp:Image ID="Image1" runat="server" Height="96px" ImageUrl="~/images/Imagenes/Imagenes_Institucional/advertencia1.jpg" Width="102px" />
		                        </div>
                                <table>
                                    <tr>
                                        <td style="height:40px; text-align:center">
                                            <asp:Label ID="Label1" runat="server" Text="Se ha encontrado un Problema" Font-Size="14px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height:40px; text-align:center">
                                            <asp:Label ID="msjError" runat="server" Text="" Font-Size="11px" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height:40px; text-align:center">
                                            <asp:Label ID="Label3" runat="server" Text="Para seguir navegando, por favor, vuelva a la página de inicio" Font-Size="14px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
		                        <%--<div align="center"> 
                                    <asp:Label ID="Label1" runat="server" Text="Se ha encontrado un Problema" Font-Size="14px"></asp:Label>
                                    </div>                                 
                                <div align="center">                                        
                                    <asp:Label ID="lblMensaje" runat="server" Text="" Font-Size="14px"></asp:Label>
                                    </div>
                                <div align="center">       
                                    <asp:Label ID="Label2" runat="server" Text="Para seguir navegando, por favor, vuelva a la página de inicio" Font-Size="14px"></asp:Label>                     
                                </div>--%>
                                <%--<div style="height:20px"></div>--%>
                                <div style="height:40px" align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="lnkVolver" runat="server" Font-Size="16px" Font-Bold="true" CausesValidation="False" >Volver al Inicio</asp:LinkButton>     
                                </div>
                            </td>
                        </table>
                        <div style="height:20px"></div>
                    </td>
                </tr>
            </table>
            <img alt="" src="images/Imagenes/Imagenes_Institucional/borde-pie.gif" width="100%" />
            <div class="footer" id="footer" align="Center">            
                            <p>Vía Parque Rimac - Copyright (C) 2013 <br />
                             Av. Jorge Basadre 592, Torre azul Piso 7, San Isidro. Teléfono: 6121500<br />
                             Jr. Pérez de Tudela Nº 3085 Mirones Bajo, Cercado de Lima. Teléfono: 6129400 Correo: informes@viaparquerimac.com.pe</p>
            </div>
            <div align="center">
                 <img alt=""  src="images/Imagenes/Imagenes_Institucional/browsers.png" width="120px" />
            </div>
        </div>
    </form>
</body>
</html>
