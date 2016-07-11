<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucTab.ascx.vb" Inherits="SECGEN_RJF_wucTab" %>
<TABLE cellSpacing="0" cellPadding="0" border="0" height="20" id="TabDesactivado" runat="server">
	<TR>
		<TD nowrap><IMG src="../images/tab1.jpg"></TD>
		<TD nowrap background="../images/tab2.jpg" class="textotab">&nbsp;<asp:hyperlink id="HlnkPagina" runat="server"></asp:hyperlink>&nbsp;</TD>
		<TD nowrap><IMG src="../images/tab3.jpg"></TD>
	</TR>
</TABLE>
<TABLE cellSpacing="0" cellPadding="0" border="0" height="20" id="TabActivado" runat="server">
	<TR>
		<TD nowrap><IMG src="../images/tab4.jpg"></TD>
		<TD nowrap background="../images/tab5.jpg" class="textotabactivo">&nbsp;&nbsp;<asp:Label id="LblTexto" runat="server"></asp:Label>&nbsp;&nbsp;</TD>
		<TD nowrap><IMG src="../images/tab6.jpg"></TD>
	</TR>
</TABLE>
