<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Book-Detail.aspx.cs" Inherits="Admin_Book_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-12">
       <h3><asp:Label ID="lblname" runat="server" Text=""></asp:Label></h3> 
        <hr />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                  <asp:TemplateField HeaderText="SNO">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:BoundField DataField="date" HeaderText="Date" />

         
                <asp:TemplateField HeaderText="Start">
                   <ItemTemplate>
                       <asp:Label ID="lblstart" runat="server" Text='<%#Eval("rstart") %>'></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="End">
                   <ItemTemplate>
                          <asp:Label ID="lblend" runat="server" Text='<%#Eval("rend") %>'></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Recived">
                   <ItemTemplate>
                       <asp:HiddenField ID="hfid" Value='<%#Eval("billbook") %>' runat="server" />
                       <asp:Label ID="lblrecived" runat="server" Text=""></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pending">
                   <ItemTemplate>
                       <asp:Label ID="lblpending" runat="server" Text=""></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                   <ItemTemplate>
                       <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Payment">
                   <ItemTemplate>
                       <asp:Label ID="lbltpayment" runat="server" Text="0"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                   <ItemTemplate>
                       <asp:LinkButton ID="lbllist" runat="server" CommandArgument='<%#Eval("billbook") %>' OnClick="lbllist_Click">List</asp:LinkButton>
                       <asp:LinkButton ID="lnktrans" runat="server" CommandArgument='<%#Eval("billbook") %>' OnClick="lnktrans_Click">Transfer</asp:LinkButton>
                   </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <span style="position: relative;
    left: 440px;
    font-size: 14px;
    font-weight: bold;">Final Total=<%=Finaltotal %></span> 
          <span style="position: relative;
    font-size: 14px;
    font-weight: bold;">Recived Total=<%=recive %></span> 
    </div>
    
</asp:Content>

