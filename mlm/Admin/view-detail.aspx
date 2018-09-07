<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="view-detail.aspx.cs" Inherits="Admin_view_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <h3>View Call List</h3>
    <hr />
   
    <asp:GridView ID="gvdata" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" >
        <Columns>
<%--            <asp:BoundField DataField="month" HeaderText="Month" />--%>
   
            <asp:BoundField DataField="name" HeaderText="Name" />
            <asp:BoundField DataField="father" HeaderText="Father Name" />
          
            <asp:BoundField DataField="mobile" HeaderText="Mobile" />
              <asp:TemplateField HeaderText="Status" >
                <ItemTemplate>
                   
                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>' CssClass="a"></asp:Label>
                </ItemTemplate>
                
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("id") %>' OnClick="LinkButton1_Click" runat="server">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </asp:GridView>
</asp:Content>

