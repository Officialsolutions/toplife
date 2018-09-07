<%@ Page Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="PwdChg.aspx.cs" Inherits="Client_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table cellpadding="0" cellspacing="0" border="0" class="client_table" width="500px" id="clienttable">
                	<tr>
                    	<td class="commont_title" colspan="2">
                        	Change Password
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	Previous Password
                        </td>
                        <td>
                        	 <asp:TextBox CssClass="input-admin" ID="TextBox1" runat="server" 
                    TextMode="Password"></asp:TextBox>   
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	New Password
                        </td>
                        <td>
                        <asp:TextBox CssClass="input-admin" ID="TextBox2" runat="server" 
                    TextMode="Password"></asp:TextBox>            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" ErrorMessage="Enter New Password" 
                    ValidationGroup="aa">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	Confirm Password
                        </td>
                        <td>
                        	 <asp:TextBox CssClass="input-admin" ID="TextBox3" runat="server" 
                    TextMode="Password"></asp:TextBox>            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox3" ErrorMessage="Enter Confirm Password" 
                    ValidationGroup="aa">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        </td>
                    	<td align="left">
                        	 <asp:Button CssClass="lb-buttion" ID="Button1" runat="server" 
                    Text="SUBMIT" onclick="Button1_Click" 
                  ValidationGroup="aa" />      
                        </td>
                    </tr>
                    <tr>
                    	<td colspan="2">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	  <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TextBox3" ControlToValidate="TextBox2" 
                    ErrorMessage="Password not matched" ValidationGroup="aa">*</asp:CompareValidator>
                        
                        	<asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="aa" />     
                        </td>
                    </tr>
                </table>


</asp:Content>

