<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="inventory-stock.aspx.cs" Inherits="Admin_inventory_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h3>Insert Stock</h3>
    <hr />
    <div class="col-md-8">
        <div class="form-group">
            <label>Product Name</label>
            <asp:TextBox ID="txtname" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Stock</label>
            <asp:TextBox ID="txtqty" runat="server" class="form-control" placeholder="Code"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click"/>
        </div>

    </div>
</asp:Content>

