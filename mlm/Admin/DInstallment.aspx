<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="DInstallment.aspx.cs" Inherits="Admin_Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <table width="95%">
        <tr>
          <td>Receipt No.</td>
          <td colspan="3" align="center"><asp:TextBox ID="TextBox3" runat="server" AutoPostBack="True" ontextchanged="TextBox3_TextChanged">  </asp:TextBox><asp:Label ID="Label1" runat="server" Font-Bold="True" 
                  Font-Size="Large" ForeColor="#FF0066"></asp:Label>  

                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                  ControlToValidate="TextBox3" ErrorMessage="Please Enter SR" 
                  ValidationGroup="bb">*</asp:RequiredFieldValidator>
          </td>
          <td><asp:Button ID="Button2" runat="server" Text="Delete" onclick="Button2_Click" ValidationGroup="bb"/>      
</td>
          </tr>
      </table></asp:Content>

