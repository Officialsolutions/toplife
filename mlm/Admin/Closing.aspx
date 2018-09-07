<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Closing.aspx.cs" Inherits="Admin_Default2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table class="my-table" width="95%">
    <tr>
        <td class="my-table-td-center">
        <asp:GridView ID="GridView1" runat="server" CssClass="my-grid"
            CaptionAlign="Top" HorizontalAlign="Center" Width="900px">
        </asp:GridView>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Post" CssClass="lb-buttion" onclick="Button1_Click"/>
    </td>
    </tr>
  </table>
</asp:Content>

