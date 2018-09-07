<%@ Page Language="C#" MasterPageFile="~/admin1/MasterPage.master" AutoEventWireup="true" CodeFile="PwdChg.aspx.cs" Inherits="Client_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0 border="0" class="client_table">
	<tr>
		<td height="20px">
			
		</td>
	</tr>
    <tr>
        <td align="center" class="client_home_hd" style="font-size:20px">
           Change Password    
        </td>
    </tr>
    <tr>
        <td height="20px" class="tablecontent">
        </td>
    </tr>
    <tr>
        <td align="center">
        <table width="500" border="0" cellpadding="0" cellspacing="0" id="changepwd">
        <tr class="tablenormal">
          <td height="40" align="center" class="client_home_rw"> Old Password</td>
          <td height="40" align="left">
                    <asp:TextBox  ID="TextBox1" CssClass="input_box_text_pwd" runat="server" 
                    TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="Enter Old Password" 
                    ValidationGroup="aa">*</asp:RequiredFieldValidator></td>
          </tr>
		
		<tr>
			<td height="20px">

			</td>
		</tr>
		
		  
        <tr class="tablenormal">
          <td height="40" align="center" class="client_home_rw">
            New Password&nbsp;</td>
          <td height="40" class="style1">
            <asp:TextBox CssClass="input_box_text_pwd" ID="TextBox2" runat="server" 
                    TextMode="Password"></asp:TextBox>            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" ErrorMessage="Enter New Password" 
                    ValidationGroup="aa">*</asp:RequiredFieldValidator></td>
          </tr>
		  
		  
		<tr>
			<td height="20px">

			</td>
		</tr>
		  
        <tr class="tablenormal">
          <td height="40" align="center" class="client_home_rw">
            Confirm Password&nbsp;</td>
          <td height="40" class="style1">
            <asp:TextBox CssClass="input_box_text_pwd" ID="TextBox3" runat="server" 
                    TextMode="Password"></asp:TextBox>            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox3" ErrorMessage="Enter Confirm Password" 
                    ValidationGroup="aa">*</asp:RequiredFieldValidator></td>
          </tr>
        <tr class="tablenormal">
          <td height="40" class="style3">
              <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
          <td height="40" class="style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TextBox3" ControlToValidate="TextBox2" 
                    ErrorMessage="Password not matched" ValidationGroup="aa">*</asp:CompareValidator>
            &nbsp;</td>
          </tr>
        <tr class="tablenormal">
          <td height="40" class="style4">&nbsp;</td>
          <td height="40" class="style1">
              <asp:Button CssClass="lb-buttion" 
                  ID="Button1" runat="server" 
                    Text="Change Password" onclick="Button1_Click" 
                  ValidationGroup="aa" />      
          </td>
          </tr>
        <tr class="tablenormal">
          <td height="40" colspan="2" class="client_home_rw">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="aa" />          </td>
          </tr>
      </table>
    </tr>
  </table>
</asp:Content>

