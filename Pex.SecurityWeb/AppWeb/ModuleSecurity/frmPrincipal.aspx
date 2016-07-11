<%@ Page Language="VB" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="false" CodeFile="frmPrincipal.aspx.vb" Inherits="frmPrincipal" title="Modulo de Seguridad"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <img alt="" src="../images/Imagenes/Imagenes_Institucional/borde-pie.gif" width="100%" />
    <table style="width: 100%" id="TABLE1" border="0" cellpadding="0" cellspacing="0">
        <tr>
            
            <td style="width:100%; height: 200px;" >
                &nbsp;</td>
        </tr>
     </table>
    &nbsp;<%--<asp:Timer id="Timer1" runat="server" Interval="5000"></asp:Timer>--%>
    </asp:Content>
<%--<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmPrincipal.aspx.vb" Inherits="frmPrincipal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
<script language="javascript" type="text/javascript">

</script>
<link href="StyleSheet.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../js/Funciones.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 372px; height: 208px" id="TABLE1" border="0" cellpadding="0" cellspacing="0">
             <tr>
                <td class=master colspan=3 style="height: 53px"><asp:Image  ID="Image2" CssClass=image3 ImageUrl="~/images/top-animacion.gif" runat="server" /><asp:Image ID="Image1" CssClass=image1  ImageUrl="~/images/top-logo.gif" runat="server" Height="58px"/><asp:Image ID="Image3"  ImageUrl="~/images/top-bg.gif" runat="server" /><asp:Image ID="Image4"  ImageUrl="~/images/bg-principal.gif" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 33%"><b>Usuario:</b></td>
                <td colspan="2">
                    <b>Comsa</b>
            </tr>
            <tr>
                <td colspan="2" style="height: 37px">
                             <asp:Menu id="Menu1" runat="server" Width="100%" BackColor="#E3EAEB"  Font-Names="Arial" StaticSubMenuIndent="10px" ForeColor="#666666" DynamicHorizontalOffset="2" Orientation="Horizontal">

<DynamicHoverStyle BackColor="#666666" ForeColor="White"></DynamicHoverStyle>

<DynamicMenuStyle BackColor="#E3EAEB"></DynamicMenuStyle>

<StaticSelectedStyle BackColor="#1C5E55"></StaticSelectedStyle>

<DynamicSelectedStyle BackColor="#1C5E55"></DynamicSelectedStyle>

<DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px"></DynamicMenuItemStyle>
<Items>
<asp:MenuItem NavigateUrl="~/SeleccionNom/frmNotificacion.aspx" Text="Selecci&#243;n y Nombramiento" Value="New Item">
    <asp:MenuItem Text="Convocatorias" Value="Convocatorias">
        <asp:MenuItem NavigateUrl="~/SeleccionNom/frmConvocatoria.aspx" Text="Registro de Convocatorias"
            Value="Registro de Convocatorias"></asp:MenuItem>
        <asp:MenuItem Text="Registro de Plazas Vacantes"
            Value="Registro de Plazas Vacantes"></asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Postulantes" Value="Postulantes">
        <asp:MenuItem NavigateUrl="~/SeleccionNom/frmNotificacion.aspx" Text="Registro de Notificaciones"
            Value="Registro de Notificaciones"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SeleccionNom/frmbuscapostulante.aspx" Text="Actualizacion de Postulantes"
            Value="Actualizacion de Postulantes"></asp:MenuItem>
        <asp:MenuItem Text="Variacion de Plaza"
            Value="Variacion de Plaza"></asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Notas" Value="Notas">
        <asp:MenuItem Text="Registros de Notas de Exam. Escrito" Value="Registros de Notas de Exam. Escrito">
        </asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Requisitos" Value="Requisitos">
        <asp:MenuItem NavigateUrl="~/SeleccionNom/frmRequisitos_SN.aspx" Text="Verificacion de Requisitos"
            Value="Verificacion de Requisitos"></asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Evalucion Curricular" Value="Evalucion Curricular">
        <asp:MenuItem Text="Calificacion del CV" Value="Calificacion del CV"></asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Entrevista Personal" Value="Entrevista Personal">
        <asp:MenuItem Text="Registro de la Entrevista Personal" Value="Registro de la Entrevista Personal" NavigateUrl="~/SeleccionNom/frmEntrevistaPersonal.aspx">
        </asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Cuadros de Merito" Value="Cuadro de Merito">
        <asp:MenuItem Text="Cuadro de Merito" Value="Cuadro de Merito"></asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Expedicion de Titulos" Value="Expedicion de Titulos">
        <asp:MenuItem Text="Registro de la Votacion Nominal " Value="Registro de la Votacion Nominal ">
        </asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Tachas" Value="Tachas">
        <asp:MenuItem Text="Registro de Tachas" Value="Registro de Tachas"></asp:MenuItem>
    </asp:MenuItem>
</asp:MenuItem>
<asp:MenuItem Text="Procesos Disciplinarios" Value="New Item">
    <asp:MenuItem NavigateUrl="~/ProcDiscip/Denuncia/frmRegistroDenuncia.aspx" Text="Denuncias"
        Value="Denuncias">
        <asp:MenuItem Text="Registro de Denuncias" Value="Registro de Denuncias"></asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Pedidos de Destitucion" Value="Pedidos de Destitucion">
        <asp:MenuItem NavigateUrl="~/ProcDiscip/PedidosDestitucion/frmRegistroPedidosDestitucion.aspx"
            Text="Registro de Pedidos de Destitucion " Value="Registro de Pedidos de Destitucion ">
        </asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Gestion de Expedientes" Value="Gestion de Expedientes">
        <asp:MenuItem NavigateUrl="~/ProcDiscip/PedidosDestitucion/frmRegistroPedidosDestitucion.aspx"
            Text="Procesos Disciplinarios" Value="Procesos Disciplinarios"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/ProcDiscip/InvestigacionPreliminar/frmInvestigacionPreliminar.aspx"
            Text="Investigacion Preliminar" Value="Investigacion Preliminar"></asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Cuaderno de Cargo" Value="Cuaderno de Cargo">
        <asp:MenuItem NavigateUrl="~/ProcDiscip/Notificaciones/frmCuadernoCargo.aspx" Text="Registro de Cuarderno de Cargos"
            Value="Registro de Cuarderno de Cargos"></asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem NavigateUrl="~/ProcDiscip/Notificaciones/frmNotificacion.aspx" Text="Registro Notificaci&#243;n"
        Value="Registro Notificaci&#243;n"></asp:MenuItem>
    <asp:MenuItem Text="Consulta Plazos" Value="Consulta Plazos"></asp:MenuItem>
    <asp:MenuItem Text="Uso de la Palabra" Value="Uso de la Palabra"></asp:MenuItem>
    <asp:MenuItem Text="Recomendacion/Inpugnaci&#243;n " Value="Recomendacion/Inpugnaci&#243;n ">
    </asp:MenuItem>
</asp:MenuItem>
<asp:MenuItem Text="Evaluaci&#243;n y Ratificaci&#243;n " Value="New Item">
    <asp:MenuItem Text="Cronograma de Actividades" Value="Cronograma de Actividades">
        <asp:MenuItem Text="Registro de Cronograma de Actividades" Value="Registro de Cronograma de Actividades" NavigateUrl="~/EvaRat/frmConsultaConvoRati.aspx">
        </asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Informacion de Proceso" Value="Informacion de Proceso">
        <asp:MenuItem Text="Calidad de Desiciones" Value="Calidad de Desiciones" NavigateUrl="~/EvaRat/frmConsultaMagiConvo.aspx?sOpcionMenu=Calidad"></asp:MenuItem>
        <asp:MenuItem Text="Registro de Declaracion Jurada de Sanciones" Value="Registro de Declaracion Jurada de Sanciones" NavigateUrl="~/EvaRat/frmConsultaMagiConvo.aspx?sOpcionMenu=DJSanciones">
        </asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Calificacion de Parametros" Value="Calificacion de Parametros">
        <asp:MenuItem Text="Calificacion de Parametros" Value="Calificacion de Parametros" NavigateUrl="~/EvaRat/frmConsultaMagiConvo.aspx?sOpcionMenu=Calificacion"></asp:MenuItem>
        <asp:MenuItem Text="Evaluaci&#243;n de Variables de Evaluaci&#243;n " Value="Evaluaci&#243;n de Variables de Evaluaci&#243;n " NavigateUrl="~/EvaRat/frmConsultaEvolVar.aspx">
        </asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Gestion de Expedientes" Value="Gestion de Expedientes">
        <asp:MenuItem Text="Registro de Expedientes" Value="Registro de Expedientes" NavigateUrl="~/EvaRat/frmConsultaExpediente.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Registro de Documentos" Value="Registro de Documentos" NavigateUrl="~/EvaRat/frmConsultaDocumento.aspx"></asp:MenuItem>
    </asp:MenuItem>
</asp:MenuItem>
<asp:MenuItem Text="Magistrado" Value="New Item">
    <asp:MenuItem Text="Hoja de Vida" Value="Hoja de Vida" NavigateUrl="~/SECGEN/RJF/frmMagistradoBusqueda.aspx"></asp:MenuItem>
</asp:MenuItem>
<asp:MenuItem Text="Secretaria General" Value="New Item">
    <asp:MenuItem Text="Secretaria General" Value="Secretaria General">
        <asp:MenuItem Text="Registro de Seci&#243;n" Value="Registro de Seci&#243;n"></asp:MenuItem>
        <asp:MenuItem Text="Registro de Libros" Value="Registro de Libros"></asp:MenuItem>
        <asp:MenuItem Text="Generar Formato" Value="Generar Formato"></asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Registro de Jueces y Fiscales" Value="Registro de Jueces y Fiscales">
        <asp:MenuItem Text="Control de Cambios" Value="Control de Cambios"></asp:MenuItem>
        <asp:MenuItem Text="Magistrado" Value="Magistrado" NavigateUrl="~/ProcDiscip/Mantenimientos/frmMagistrado.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Registro de Denuncias Ciudadanas" Value="Registro de Denuncias Ciudadanas">
        </asp:MenuItem>
        <asp:MenuItem Text="Registro de Medidas Disciplinarias" Value="Registro de Medidas Disciplinarias" NavigateUrl="~/SECGEN/RJF/frmMedida_Disciplinarias.aspx">
        </asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Tramite Documentario" Value="Tramite Documentario">
        <asp:MenuItem Text="Registrar Documento" Value="Registrar Documento"></asp:MenuItem>
        <asp:MenuItem Text="Derivar Documento" Value="Derivar Documento"></asp:MenuItem>
        <asp:MenuItem Text="Recepcionar Documento" Value="Recepcionar Documento"></asp:MenuItem>
    </asp:MenuItem>
</asp:MenuItem>
    <asp:MenuItem Text="Modulo Gerencial" Value="Nuevo elemento">
        <asp:MenuItem Text="Acuerdos del Gabinete de Asesores" Value="Acuerdos del Gabinete de Asesores">
        </asp:MenuItem>
        <asp:MenuItem Text="Consulta Consolidada de Procesos" Value="Consulta Consolidada de Procesos">
        </asp:MenuItem>
        <asp:MenuItem Text="Consulta Consolidada de Ratificacion" Value="Consulta Consolidada de Ratificacion">
        </asp:MenuItem>
        <asp:MenuItem Text="Consulta Consolidada de Nombramientos" Value="Consulta Consolidada de Nombramientos">
        </asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Reportes" Value="Nuevo elemento">
        <asp:MenuItem Text="Generardor de Reportes" Value="Generardor de Reportes" NavigateUrl="~/SeleccionNom/Reportes/rptPostulantesAptos.rpt"></asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Mantenimientos" Value="Nuevo elemento">
        <asp:MenuItem Text="Mantenimientos Generales del Sistema" Value="Mantenimientos Generales del Sistema">
            <asp:MenuItem NavigateUrl="~/Administracion/Mantenimientos/frmugeografica.aspx" Text="Ubicaci&#243;n Geografica "
                Value="Ubicaci&#243;n Geografica "></asp:MenuItem>
            <asp:MenuItem Text="Direcci&#243;n Procesal  " Value="Direcci&#243;n Procesal  "></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Administracion/frmDominio.aspx" Text="Parametros" Value="Parametros">
            </asp:MenuItem>
            <asp:MenuItem Text="Registros Denunciantes" Value="Registros Denunciantes"></asp:MenuItem>
        </asp:MenuItem>
    </asp:MenuItem>
    <asp:MenuItem Text="Interfases" Value="Interfases">
        <asp:MenuItem Text="Poder Judicial" Value="Poder Judicial"></asp:MenuItem>
        <asp:MenuItem Text="Ministerio Publico " Value="Ministerio Publico "></asp:MenuItem>
        <asp:MenuItem Text="Banco de la Nacion" Value="Banco de la Nacion"></asp:MenuItem>
    </asp:MenuItem>
</Items>

<StaticHoverStyle BackColor="#666666" ForeColor="White"></StaticHoverStyle>
                <DynamicItemTemplate>
                    <%# Eval("Text") %>
                </DynamicItemTemplate>
</asp:Menu>        
                                
                                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 21px">
                    <img src="images/imagenes_inicio/fondo-inicio.gif" style="width: 1040px; height: 368px" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <img src="images/imagenes_inicio/borde-pie.gif" /><br />
                    <img src="images/imagenes_login/login-pie.gif" /></td>
            </tr>
        </table>
    
    </div>
        <br />
        <br />
    </form>
</body>
</html>--%>