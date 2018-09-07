<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" 

CodeFile="PayOut2.aspx.cs" Inherits="Admin_Default2" %>
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
<table align="center" class="my-table" id="pin-gen" width="900px">
    <tr>
    	<td height="20px">
            <table align="center" width="750px" border="0" cellpadding="0" cellspacing="0">
            <tr>
            <td align="center" width="115px" class="client_home_rw">Id No.</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox4" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox4_TextChanged"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                Enabled="True" TargetControlID="TextBox1">
                            </cc1:CalendarExtender>
                </td>

            <td align="center" width="150x">
                &nbsp;</td>
            <td align="center" width="150x" class="client_home_rw">Name</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox3" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox3_TextChanged"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                Enabled="True" TargetControlID="TextBox1">
                            </cc1:CalendarExtender>
                </td>

            <td align="center" width="150x">
                &nbsp;</td>
            </tr>
            <tr>
                <td height="10px">
                </td>
            </tr>
            </table>
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
        </td>
    </tr>
</table>
<br />
<table align="center" class="my-table" id="pin-gen" width="900px">
    
    <tr>
        <td align="center">
<form id="pnlContents" >
<asp:Panel id="pnlContents" runat = "server">
        <asp:GridView ID="GridView1" runat="server" Width="800px" CssClass="my-grid" ></asp:GridView>
</asp:Panel>
 <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-d" OnClientClick = "return PrintPanel();" />
</form>
        </td>
    </tr>
  </table>
</asp:Content>

