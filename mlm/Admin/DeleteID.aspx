<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteID.aspx.cs" Inherits="Client_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table align="center" class="my-table" id="pin-gen" width="900px">
 <tr>
		<td height="10px" colspan="7">
		</td>
	</tr>
    <tr>
        <td colspan="7" class="my-table-header" align="center" style="font-size:20px">
          Delete ID    
        </td>
    </tr>
	<tr>
		<td height="10px" colspan="7">
		</td>
	</tr>
        <tr>
		<td align="center">User Id :</td>
        <td align="center"><asp:TextBox ID="txtUserId" runat="server" CssClass="my-textbox" 
                AutoPostBack="True" ontextchanged="txtUserId_TextChanged"></asp:TextBox><asp:Label ID="Label4" runat="server"></asp:Label></td>
		<td align="center">Password : </td>
        <td align="center"><asp:TextBox ID="txtpins" runat="server" CssClass="my-textbox"></asp:TextBox></td>
		 <td align="center">
            <asp:Button ID="buttonClick" runat="server" width="200%" OnClick="buttonClick_Click" Text="Delete" CssClass="lb-buttion" ></asp:Button>
         </td>

    </tr>
        <tr>
            <td colspan="7" align="center"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
     <tr>
       
    </tr>
</table>
</asp:Content>

