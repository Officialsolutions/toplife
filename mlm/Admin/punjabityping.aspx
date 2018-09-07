<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="punjabityping.aspx.cs" Inherits="Admin_punjabityping" %>

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
<table class="my-table" width="95%">
    <tr>
    	<td height="20px">
        	
        </td>
    </tr>
    <tr>
        <td class="my-table-header" align="center" style="font-size:20px">
           Member List     
        </td>
    </tr>
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

            <td align="center" width="150x" class="client_home_rw">Name</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox3" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox3_TextChanged"></asp:TextBox>
                </td>
            <td align="center" width="150x" class="client_home_rw">Mobile</td>
            <td align="center" width="150x">
                <asp:TextBox ID="TextBox5" CssClass="input_box_text_pwd" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox5_TextChanged"></asp:TextBox>
                </td>
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
            <tr>
                <td height="20px">
            <table align="center" width="750px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="ll" 
                    AutoPostBack="True" oncheckedchanged="RadioButton1_CheckedChanged" 
                    Text="ID Wise" Checked="True"/>
                    </td>
            <td align="center">
                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="ll" 
                    AutoPostBack="True" oncheckedchanged="RadioButton3_CheckedChanged" 
                    Text="Name Wise" />
            </td>
            <td align="center">
                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="ll" 
                    AutoPostBack="True" oncheckedchanged="RadioButton4_CheckedChanged" 
                    Text="Date Wise" />
            </td>
        </tr>
                </table>
                </td>
            </tr>
    <tr>
        <td class="my-table-td-center">
            	<form id="pnlContents" >
<asp:Panel id="pnlContents" runat = "server">
        <asp:GridView ID="GridView1" runat="server" CssClass="my-grid"
            CaptionAlign="Top" HorizontalAlign="Center" Width="900px" DataKeyNames="Id" 
            EnableModelValidation="True" onrowupdating="GridView1_RowUpdating" HeaderStyle-CssClass="gridhead">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" CssClass="gray">Click</asp:LinkButton>
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

