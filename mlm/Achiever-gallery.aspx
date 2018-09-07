<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Achiever-gallery.aspx.cs" Inherits="Achiever_gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    <h3><%=name %></h3>
    <hr />
    <asp:ListView ID="lvgallery" runat="server">
        <ItemTemplate>
            
                <div class="col-xs-12 col-md-3" >
                    
                        <a href='uploadimage/<%#Eval("image") %>' data-lightbox="image-1" data-title='<%#Eval("Name") %>' class="thumbnail" style=" height:200px; overflow:hidden"><img src='uploadimage/<%#Eval("image") %>' alt=''/></a>
                            <div class="clearfix"></div>
                
                        <div class="clearfix"></div>
                </div>
            
        </ItemTemplate>
    </asp:ListView>
        </div>
</asp:Content>

