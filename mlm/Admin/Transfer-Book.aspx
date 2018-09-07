<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Transfer-Book.aspx.cs" Inherits="Admin_Transfer_Book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h3>Tranfer Bill Book</h3>
    <hr />
        <div class="col-md-12">
            <div class="form-group col-md-4">
                <label>Name</label>
                <asp:TextBox ID="txtname" AutoPostBack="true" OnTextChanged="txtname_TextChanged" runat="server" class="form-control" placeholder="Enter Name"></asp:TextBox>
                <strong>
                    <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
                </strong>
            </div>
           <div class="form-group col-md-4">
          <asp:DropDownList ID="ddlmonth" runat="server" CssClass="form-control">
            <asp:ListItem>Select Month</asp:ListItem>
               <asp:ListItem Value="01">Jan</asp:ListItem>
                <asp:ListItem Value="02">Feb</asp:ListItem>
                <asp:ListItem Value="03">Mar</asp:ListItem>
                <asp:ListItem Value="04">Apr</asp:ListItem>
                <asp:ListItem Value="05">May</asp:ListItem>
                <asp:ListItem Value="06">Jun</asp:ListItem>
                <asp:ListItem Value="07">Jul</asp:ListItem>
                <asp:ListItem Value="08">Aug</asp:ListItem>
                <asp:ListItem Value="09">Sep</asp:ListItem>
                <asp:ListItem Value="10">Oct</asp:ListItem>
                <asp:ListItem Value="11">Nov</asp:ListItem>
                <asp:ListItem Value="12">Dec</asp:ListItem>
        </asp:DropDownList>
    </div>
             <div class="col-md-4">
          <asp:DropDownList ID="yearfilter" runat="server" CssClass="form-control">
              <asp:ListItem>Select Year</asp:ListItem>
                   <asp:ListItem>2017</asp:ListItem>
                   <asp:ListItem>2018</asp:ListItem>
                   <asp:ListItem>2019</asp:ListItem>
                   <asp:ListItem>2020</asp:ListItem>
               </asp:DropDownList>
    </div>
         
          <div class="form-group">
                   <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click" />
        </div>   

    </div>
</asp:Content>

