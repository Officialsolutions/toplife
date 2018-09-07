<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="serial-search.aspx.cs" Inherits="Admin_serial_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
    
    <div class="col-md-12">
        <div class="col-md-4">
            Search Serial No.
            <asp:TextBox ID="txtsearch" runat="server" placeholder="Search Serial No." CssClass="form-control" OnTextChanged="txtsearch_TextChanged" AutoPostBack="true"></asp:TextBox>
        </div>
        <asp:GridView ID="gvdata" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" >
        <Columns>
      <asp:TemplateField HeaderText="Sr.No" >
                <ItemTemplate>
                 <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                
              </asp:TemplateField>
            <asp:BoundField DataField="regno" HeaderText="Id" />
            <asp:BoundField DataField="mname" HeaderText="Name" />
            <asp:BoundField DataField="name" HeaderText="Product Name" />
           <asp:BoundField DataField="serial" HeaderText="serial" />
              <asp:TemplateField HeaderText="Image" >
                <ItemTemplate>
                  <img src='../uploadimage/<%#Eval("image") %>' width="80" />
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Date" >
                <ItemTemplate>
                   
                    <asp:Label ID="lbldate" runat="server" Text='<%#Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %>'></asp:Label>
                </ItemTemplate>
                
              </asp:TemplateField>
        </Columns>
    </asp:GridView>


    </div>
</asp:Content>

