<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Leader.aspx.cs" Inherits="Admin_Leader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h3>Leader</h3>
    <hr />
    <div class="col-md-8">
        <div class="form-group">
            <label>Name</label>
            <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Enter Name"></asp:TextBox>
    </div>
        <div class="form-group">
            <label>Father Name</label>
            <asp:TextBox ID="txtfname" runat="server" class="form-control" placeholder="Enter Father Name"></asp:TextBox>
    </div>
        <div class="form-group">
            <label>Address</label>
            <asp:TextBox ID="txtadd" runat="server" class="form-control" placeholder="Enter Address"></asp:TextBox>
    </div>
        <div class="form-group">
            <label>Phone1</label>
            <asp:TextBox ID="txtp1" runat="server" class="form-control" placeholder="Enter Phone1"></asp:TextBox>
    </div>
        <div class="form-group">
            <label>Phone2</label>
            <asp:TextBox ID="txtp2" runat="server" class="form-control" placeholder="Enter Phone2"></asp:TextBox>
    </div>
         <div class="form-group">
            <label>Leader Id</label>
            <asp:TextBox ID="txtleader" runat="server" class="form-control" placeholder="Enter Leaader Id"></asp:TextBox>
    </div>
         

          <div class="form-group">
                   <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click" />
        </div>   

    </div>
    <div class="col-md-4">

          <img alt="" src="../uploadimage/<%=img %>" width="80px"/>
    </div>
</asp:Content>

