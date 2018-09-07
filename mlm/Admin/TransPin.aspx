<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="TransPin.aspx.cs" Inherits="Client_Default2" %>

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
		<td height="10px" colspan="7">
		</td>
	</tr>
    <tr>
        <td colspan="7" class="my-table-header" align="center" style="font-size:20px">
          Transfer Pins    
        </td>
    </tr>
	<tr>
		<td height="10px" colspan="7">
		</td>
	</tr>
        <tr>
            <td align="center">Pin Type</td>
            <td align="center">
                <asp:DropDownList ID="DropDownList1" CssClass="my-textbox" runat="server" Width="100px">
                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                </asp:DropDownList>
            </td>
		<td align="center">User Id :</td>
        <td align="center"><asp:TextBox ID="txtUserId" runat="server" CssClass="my-textbox" 
                AutoPostBack="True" ontextchanged="txtUserId_TextChanged"></asp:TextBox><asp:Label ID="Label4" runat="server"></asp:Label></td>
		<td align="center">No Of Pins : </td>
        <td align="center"><asp:TextBox ID="txtpins" runat="server" CssClass="my-textbox"></asp:TextBox></td>
		 <td align="center">
            <asp:Button ID="buttonClick" runat="server" width="200%" OnClick="buttonClick_Click" Text="Send" CssClass="lb-buttion" ></asp:Button>
         </td>

    </tr>
        <tr>
            <td colspan="7" align="center"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
     <tr>
       
    </tr>
</table>
    <br />
	<form id="pnlContents" >
<asp:Panel id="pnlContents" runat = "server">
    <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="my-grid">
    </asp:GridView>
</asp:Panel>
 <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-d" OnClientClick = "return PrintPanel();" />
</form>
    <br />
 <table  align="center" class="my-table" id="pin-gen" width="900px">
    <tr>
    <td>Total Pins : <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
    <td width="300px">       </td>
    <td>Total Used Pins : <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
    </tr>
    </table>

</asp:Content>

