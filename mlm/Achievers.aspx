<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Achievers.aspx.cs" Inherits="Achievers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container">
    <h3>Achiever</h3>
    <hr />
    <asp:ListView ID="lvalbum" runat="server">
        <ItemTemplate>
            <div class="col-sm-6 col-md-3">
                <div class="thumbnail">
                    <a href="achiever-gallery.aspx?id=<%#Eval("id") %>">
                        <img src="../uploadimage/<%# Eval("image") %>" alt="...">
                        <div class="caption">
                            <h3><%#Eval("name") %></h3>
                        </div>
                    </a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
            </div>
</asp:Content>

