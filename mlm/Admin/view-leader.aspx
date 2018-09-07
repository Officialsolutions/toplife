<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="view-leader.aspx.cs" Inherits="Admin_view_leader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>View Leader</h3>
    <hr />
    <asp:Button ID="btnsubmit" OnClick="btnsubmit_Click" runat="server" Text="Add Leader" CssClass="btn btn-default" />
    <asp:GridView ID="gvdata" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="Name" />
            <asp:BoundField DataField="fathername" HeaderText="Father Name" />
            <asp:BoundField DataField="address" HeaderText="Address" />
            <asp:BoundField DataField="Phone1" HeaderText="Phone1" />
            <asp:BoundField DataField="Phone2" HeaderText="Phone2" />
            <asp:BoundField DataField="leaderid" HeaderText="Leader Id" />
           
            <asp:TemplateField HeaderText="Action" >
                <ItemTemplate>
                    <asp:LinkButton ID="lnkedit" OnClick="lnkedit_Click" CommandArgument='<%#Eval("id") %>' runat="server">Edit</asp:LinkButton>
                    <asp:LinkButton ID="lnkdel" OnClick="lnkdel_Click" CommandArgument='<%#Eval("id") %>' runat="server">Delete</asp:LinkButton>
               
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

