<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmLogin.aspx.vb" Inherits="Login_frmLogin" %>
<%--<%@ Register tagname="Mensaje" tagprefix="mjeInfo" %>--%>
<%--<%@ Register Src="~/UserControls/MensajeInformacion.ascx" TagName="Mensaje" TagPrefix="mjeInfo" %>--%>
<%--<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>--%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>.:. MÓDULO DE SEGURIDAD .:.</title>
    <link href="App_Themes/syllabusAzul/syllabus.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/syllabusAzul/syllabus_celdas.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/syllabusAzul/syllabus_grilla.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/syllabusAzul/syllabus_menu.css" rel="stylesheet" type="text/css" />
    <style type="text/css">

    
.stl_etiqueta
{
	FONT-WEIGHT: bold; 
	FONT-SIZE: 10px; 
	font-family: Arial, Helvetica, sans-serif;
	COLOR: #00005a;
}

        .auto-style1 
        {
            background-image: url('App_Themes/syllabusAzul/img/HeaderRepeater.jpg');
            background-repeat: repeat-x;
            height: 95px;
            width: 704px;
        }
        .auto-style2 
        {
            width: 112px;
        }
        .style5
        {
            font-size: 11px;
        }
        .style6
        {
            width: 157px;
            font-size: 11px;
        }
        .style7
        {
            width: 157px;
            height: 20px;
            font-size: 11px;
        }
        .style8
        {
            width: 380px;
        }
        .LogoSecundario
        {
	        width:800px;
	        min-width:400px;
	        background-image:url(images/Imagenes/Imagenes_Institucional/LogoSecundario2.jpg);
	        background-repeat:no-repeat;
	        background-position:right;
	        vertical-align: bottom;
	        height: 94px;
	        border-top:1px double #144B72;
        }
        .Agrupador
        { 
            border: 2px solid #666666;
            background-color: #FFFFFF; color: #000066; text-align:left;
            color:black;   
            border: 2px solid;
            border-radius: 10px;
            box-shadow: 2px 2px 20px 2px #999;
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
    </style>
</head>
<body>    
    <%--<script runat="server">
        
    </script>
    <script type="text/javascript" language="javascript">
        function showAlert() {
            alert("Hello this is an Alert")            
        }
     </script>--%>
    <form id="frmLogin" runat="server">
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
	                    <div id="tabs20">		    
	                    </div>		
	                    <br />
                        <br />
                        <br />
	                </td>	
                    <%--<td align="center" style="height: 10px;" >&nbsp;</td>--%>    
                </tr>
                <tr>
                    <td align="center" style="width: auto">
                        <table class="Agrupador" width="500px">
                            <td>
                                <div align="center">
                                    <br />
			                        <span><strong>Bienvenido al Módulo de Seguridad</strong></span>
                                    <br />
                                    <br />
		                        </div>
		                        <div  align="center"> 
                                    <table border="0" width="250px">
                                        <tr>
                                            <td class="style5">
                                                Usuario&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
                                            </td>
                                            <td class="style6">
                                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="stl_texbox" ToolTip="Usuario" Text=""
                                                    Width="170px" MaxLength="16"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Password&nbsp; :</td>
                                            <td class="style7">
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="stl_texbox" ToolTip="Password" Text="clave" 
                                                    TextMode="Password" Width="170px" MaxLength="20"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td ></td>
                                            <td align="center">
                                                <asp:ImageButton ID="btnIngresar" runat="server" 
                                                    ImageUrl="~/images/imagenes_login/btn_aceptar.gif"/><%--OnClientClick=showAlert()--%>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>                                    
                                </div>
                            </td>
                        </table>
                        <br />
                            <%--<mjeInfo:Mensaje ID="mjeInformacion" runat="server" />--%>
                        <br />
                    </td>
                </tr>
            </table>
            <img alt="" src="images/Imagenes/Imagenes_Institucional/borde-pie.gif" width="100%" />
            <div class="footer" id="footer" align="Center">            
                <%--<p>Av. Billinghurts 562 Tacna. Teléfono: 052 - 421144 Email: informes@dcperu.com<br />
                Copyright ©2011 - Data Consulting E.I.R.L.</p>--%>
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
