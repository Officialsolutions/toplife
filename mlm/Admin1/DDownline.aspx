<%@ Page Title="" Language="C#" MasterPageFile="~/Admin1/MasterPage.master" AutoEventWireup="true" CodeFile="DDownline.aspx.cs" Inherits="Client_Default2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
            <table width="750px" align="center">
            <tr>                <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>

            <td align="center" width="150x" class="client_home_rw">From Date</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox1" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox1_TextChanged"></asp:TextBox>
                            <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TextBox1">
                            </cc1:CalendarExtender>
                </td>
            <td align="center" width="150x" class="client_home_rw">To Date</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox2" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox2_TextChanged"></asp:TextBox>
                            <cc1:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TextBox2">
                            </cc1:CalendarExtender>
                </td>
            <td align="center" width="150x">
                &nbsp;</td>
            </tr>
            </table>
<table cellpadding="0" cellspacing="0">
	<tr>
		<td height="20px">
            <table align="center" width="750px" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="ll" 
                            AutoPostBack="True" oncheckedchanged="RadioButton1_CheckedChanged" 
                            Text="All" Checked="True"/>
                            </td>
                    <td align="center">
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="ll" 
                            AutoPostBack="True" oncheckedchanged="RadioButton2_CheckedChanged" 
                            Text="Left" />
                    </td>
                    <td align="center">
                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="ll" 
                            AutoPostBack="True" oncheckedchanged="RadioButton3_CheckedChanged" 
                            Text="Right" />
                    </td>
                </tr>
                </table>
		</td>
	</tr>
</table>
	<form id="pnlContents" >
<asp:Panel id="pnlContents" runat = "server">
	 <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="grid" HeaderStyle-CssClass="gridhead">
    </asp:GridView>
</asp:Panel>
 <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-d" OnClientClick = "return PrintPanel();" />
</form>
</asp:Content>

