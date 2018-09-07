<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="view-gallery.aspx.cs" Inherits="Admin_view_gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>View Gallery</h3>
    <hr />
    <asp:Button ID="btnsubmit" OnClick="btnsubmit_Click" runat="server" Text="Add Gallery" CssClass="btn btn-default" />
    <asp:GridView ID="gvdata" runat="server" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="Name" />
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <img src="../uploadimage/<%#Eval("image") %>" width="80" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" >
                <ItemTemplate>
                    <asp:LinkButton ID="lnkedit" OnClick="lnkedit_Click" CommandArgument='<%#Eval("id") %>' runat="server">Edit</asp:LinkButton>
                    <asp:LinkButton ID="lnkdel" OnClick="lnkdel_Click" CommandArgument='<%#Eval("id") %>' runat="server">Delete</asp:LinkButton>
                   <%-- <asp:LinkButton ID="lnkadd" OnClick="lnkadd_Click" CommandArgument='<%#Eval("id") %>' runat="server">Add Photo</asp:LinkButton>--%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

