<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Admin_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Product Detail</h3>
    <hr />
    <div class="col-md-8">
        <div class="form-group">
            <label>Product Name</label>
            <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Enter Product Name"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Product code</label>
            <asp:TextBox ID="txtcode" runat="server" CssClass="form-control"  placeholder="Code"></asp:TextBox>
        </div>
         <div class="form-group">
            <label>Serial No.</label>
            <asp:TextBox ID="txtserial" runat="server" CssClass="form-control"  placeholder="Serial No."></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Price</label>
            <asp:TextBox ID="txtmrp" runat="server" CssClass="form-control" placeholder="Price"></asp:TextBox>
        </div>
         <div class="form-group">
            <label>BV</label>
            <asp:TextBox ID="txtbv" runat="server" CssClass="form-control" placeholder="BV"></asp:TextBox>
        </div>
       
        <div class="form-group">
            <label>Upload Image</label>
            <asp:FileUpload ID="sliderimage" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click" />
        </div>

    </div>
    <div class="col-md-4">

        <img alt="" src="../uploadimage/<%=img %>" style="width:80px" />
    </div>
</asp:Content>

