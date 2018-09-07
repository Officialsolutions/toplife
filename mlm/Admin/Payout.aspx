<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Payout.aspx.cs" Inherits="Admin_Default2" %>
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
<table align="center" class="my-table" id="pin-gen" width="900px">

<tr>
<td align="left">
Date
</td>
<td align="center">
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                Enabled="True" TargetControlID="TextBox4">
                            </cc1:CalendarExtender>
</td>
<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ErrorMessage="PL Enter Date" ControlToValidate="TextBox4" 
                ValidationGroup="aa">*</asp:RequiredFieldValidator>
</td>
<td align="left">
ID
</td>
<td align="center">
    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" 
        ontextchanged="TextBox1_TextChanged"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
</td>
<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="PL User Id" ControlToValidate="TextBox1" 
                ValidationGroup="aa">*</asp:RequiredFieldValidator>
</td>
<td width="100" align="left">
Reward No.
</td>
<td align="center">
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</td>
<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="PL Amount" ControlToValidate="TextBox2" 
                ValidationGroup="aa">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" 
                ErrorMessage="PL enter Only Numbric Value" ValidationExpression="^\d+$" 
                ValidationGroup="aa">*</asp:RegularExpressionValidator>
</td>
<td align="left">
Cheque
</td>
<td align="center">
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="11" align="center">
    <asp:Button ID="Button1" runat="server" Text="Save" CssClass="lb-buttion" width="40%" onclick="Button1_Click" ValidationGroup="aa" />
    <br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td colspan="11" align="center">
<a href="payout2.aspx">Click Here for Reward Detail</a>
</td>
</tr>
<tr>
<td colspan="11" align="center">
            <table align="center" width="750px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="ll" 
                    AutoPostBack="True" oncheckedchanged="RadioButton1_CheckedChanged" 
                    Text="ID Wise" Checked="True"/>
                    </td>
            <td align="center">
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="ll" 
                    AutoPostBack="True" oncheckedchanged="RadioButton2_CheckedChanged" 
                    Text="IBO Wise" />
            </td>
            <td align="center">
                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="ll" 
                    AutoPostBack="True" oncheckedchanged="RadioButton3_CheckedChanged" 
                    Text="Name Wise" />
            </td>
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
        <asp:GridView ID="GridView1" runat="server" CssClass="grid"  BorderColor="#fc6701" 
            CaptionAlign="Top" HorizontalAlign="Center" Width="790px" DataKeyNames="ID" 
            EnableModelValidation="True" onrowupdating="GridView1_RowUpdating" HeaderStyle-CssClass="gridhead">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Click</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle
                BorderStyle="Dotted" BorderWidth="1px" />
        </asp:GridView>
</asp:Panel>
 <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-d" OnClientClick = "return PrintPanel();" />
</form>
        </td>
    </tr>
  </table>
</asp:Content>

