<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MensajeGeneralError.ascx.cs"
    Inherits="Syllabus_PL.UserControls.WebUserControl1" %>
<table cellspacing="0" cellpadding="0" class="cf ve">
    <tbody>
        <tr>
            <td class="vj" ></td>
            <td class="vi" />
            <td class="vk" />
        </tr>
        <tr>
            <td class="vi" />
            <td class="vh">
                
                <asp:ValidationSummary ID="vsFiltros" runat="server" ShowSummary="true" DisplayMode="SingleParagraph"
                   ForeColor="White" HeaderText="<%$ Resources:SyllabusResources, mjeErrorGeneral %>" />
                <asp:Label ID="lblCstmMessage" ForeColor="White" runat="server" class="mjeErrorResumen"></asp:Label>
            </td>
            <td class="vi" />
        </tr>
        <tr>
            <td class="vf" />
            <td class="vi" />
            <td class="vg" />
        </tr>
    </tbody>
</table>
