<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Installment.aspx.cs" Inherits="Admin_Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
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
                            <table width="95%">
        <tr>
          <td>Receipt No.</td>
          <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                  ControlToValidate="TextBox4" ErrorMessage="Please Enter SR" 
                  ValidationGroup="aa">*</asp:RequiredFieldValidator>
          </td>
          <td>ID</td>
          <td><asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" 
                  ontextchanged="TextBox1_TextChanged"></asp:TextBox><asp:Label ID="Label2" runat="server" Font-Bold="True" 
                  Font-Size="Large" ForeColor="#FF0066"></asp:Label>  
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                  ControlToValidate="TextBox1" ErrorMessage="Please Enter ID" 
                  ValidationGroup="aa">*</asp:RequiredFieldValidator>
          </td>
          <td>DATE</td>
          <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>  
                            <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TextBox2">
                            </cc1:CalendarExtender>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  ControlToValidate="TextBox2" ErrorMessage="Please Enter DATE" 
                  ValidationGroup="aa">*</asp:RequiredFieldValidator>
          </td>
          <td><asp:Label ID="Label1" runat="server" Font-Bold="True" 
                  Font-Size="Large" ForeColor="#FF0066"></asp:Label>  
</td>
          <td><asp:Button ID="Button1" runat="server" Text="SUBMIT" onclick="Button1_Click" ValidationGroup="aa"/>      
</td>
        </tr>
    <tr>
    	<td height="20px" colspan="6">
            <table align="center" width="750px" border="0" cellpadding="0" cellspacing="0">
            <tr>
            <td align="center" width="115px" class="client_home_rw">Id No.</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox5" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox5_TextChanged"></asp:TextBox>
                </td>
            <td align="center" width="150x" class="client_home_rw">Name</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox6" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox6_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td align="center" width="150x">
                R-NO.
                </td>
                <td>                <asp:TextBox ID="TextBox9" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox9_TextChanged"></asp:TextBox>
</td>
            <td align="center" width="150x">
                INS-NO.
                </td>
                <td>                <asp:TextBox ID="TextBox3" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox3_TextChanged"></asp:TextBox>
</td>
            </tr>
            <tr>
            <td align="center" width="150x" class="client_home_rw">From Date</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox7" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox7_TextChanged"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" 
                                Enabled="True" TargetControlID="TextBox7">
                            </cc1:CalendarExtender>
                </td>
            <td align="center" width="150x" class="client_home_rw">To Date</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox8" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox8_TextChanged"></asp:TextBox>
                            <cc1:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TextBox8">
                            </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
            <td align="center" width="115px" class="client_home_rw">From Rec No.</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox10" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox5_TextChanged"></asp:TextBox>
                </td>
            <td align="center" width="150x" class="client_home_rw">To Rec No.</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox11" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox6_TextChanged"></asp:TextBox>
                </td>
            </tr>
            </table>
        </td>
    </tr>
        <tr>
        <td colspan="6" align="center">
<form id="pnlContents" >
<asp:Panel id="pnlContents" runat = "server">
	 <asp:GridView ID="GridView1" runat="server" Width="100%">
    </asp:GridView>
</asp:Panel>
 <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-d" OnClientClick = "return PrintPanel();" />
</form>
        </td>
        </tr>
      </table></asp:Content>

