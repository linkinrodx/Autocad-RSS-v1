<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MensajeGeneral.ascx.cs" Inherits="Syllabus_PL.UserControls.MensajeGeneral" %>
<div id="divMjeExito" class="bb8" runat="server" style="height:25px; display: none" >
    <table cellspacing="0" cellpadding="0" class="bcf bve">
        <tbody>
            <tr>
                <td class="bvj" />
                <td class="bvi" />
                <td class="bvk" />
            </tr>
            <tr>
                <td class="bvi" />
                <td class="bvh">
                    <asp:Label ID="lblMjeExito" runat="server" Text="" CssClass="mjeExito"></asp:Label>
                </td>
                <td class="bvi" />
            </tr>
            <tr>
                <td class="bvf" />
                <td class="bvi" />
                <td class="bvg" />
            </tr>
        </tbody>
    </table>
</div>
<div id="divMjeInfo" class="ib8" runat="server" style="height: 25px; display: none">
    <table cellspacing="0" cellpadding="0" class="icf ive">
        <tbody>
            <tr>
                <td class="ivj">
                </td>
                <td class="ivi" />
                <td class="ivk" />
            </tr>
            <tr>
                <td class="ivi" />
                <td class="ivh">
                    <asp:Label ID="lblMjeInformacion" runat="server" Text="" CssClass="mjeInfo"></asp:Label>
                </td>
                <td class="ivi" />
            </tr>
            <tr>
                <td class="ivf" />
                <td class="ivi" />
                <td class="ivg" />
            </tr>
        </tbody>
    </table>
</div>
<div id="divMjeError" class="b8" runat="server" style="display: none">
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
                <asp:Label ID="lblCstmMessage" ForeColor="White" runat="server" class="mjeErrorResumen" ></asp:Label>
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
</div> 
