<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="States.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="700" class="client-table">
<tr>
<td align="center" class="user-profile">Add New State</td>
</tr>
<tr>
<td align="center">State Name</td>
</tr>
<tr>
<td align="center">
<asp:TextBox ID="TextBox1" runat="server" CssClass="admin-input-bx"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill State Name" ValidationGroup="aa" Text="*" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td align="center">
    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="label-p"></asp:Label>
</td>
</tr>
<tr>
<td align="center">
    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="lb-buttion" 
        onclick="Button1_Click" ValidationGroup="aa" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="aa" />
</td>
</tr>
<tr>
<td align="center">
    <asp:GridView ID="GridView1" runat="server" CssClass="grid">
    </asp:GridView>
</td>
</tr>
</table>
</asp:Content>

