<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Leader-Punjabi.aspx.cs" Inherits="Client_Leader_Punjabi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
         <style>
    @font-face
    {
        font-family:myfont;
        src:url(chatrik.ttf);   
    }
    .a {
            font-family:myfont;
        }
         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <h3>View Leader</h3>
    <hr />
   <asp:RadioButtonList ID="ddlview" OnSelectedIndexChanged="ddlview_SelectedIndexChanged" AutoPostBack="true" runat="server">
                    <asp:ListItem Selected="True">English</asp:ListItem>
                    <asp:ListItem>Punjabi</asp:ListItem>
                </asp:RadioButtonList>

    <asp:GridView ID="gvdata" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowEditing="gvdata_RowEditing" OnRowCancelingEdit="gvdata_RowCancelingEdit" OnRowUpdating="gvdata_RowUpdating" OnRowDataBound="gvdata_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="SNo">
                <ItemTemplate>
                     <%#Container.DataItemIndex+1 %> 
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:BoundField DataField="month" HeaderText="Month" />--%>
            <asp:BoundField DataField="memberid" HeaderText="Id" />
          
            <asp:TemplateField HeaderText="Name">
                 <ItemTemplate>
                     <asp:Panel ID="pneng" runat="server">
                      <asp:Label ID="lblname" runat="server" Text='<%#Eval("Name") %>'></asp:Label> <asp:Label ID="lbltype" runat="server" Text='<%#Eval("rel") %>'></asp:Label> <asp:Label ID="Label1" runat="server" Text='<%#Eval("father") %>'></asp:Label>
                      </asp:Panel>
                      <asp:Panel ID="pnp" runat="server" Visible="false">
                      <asp:Label ID="lblpname" runat="server" Text='<%#Eval("pname") %>' style="font-family:myfont"></asp:Label> <asp:Label ID="Label3" runat="server" Text='<%#Eval("rel") %>'></asp:Label> <asp:Label ID="Label4" runat="server" Text='<%#Eval("pfather") %>' style="font-family:myfont"></asp:Label>
                      </asp:Panel>
                 </ItemTemplate>

             </asp:TemplateField>
            <asp:BoundField DataField="father" HeaderText="Father Name" />
          
            <asp:BoundField DataField="mobile" HeaderText="Mobile" />
            <asp:BoundField DataField="mobile2" HeaderText="Mobile2" />
            <asp:TemplateField HeaderText="Address">
                  <ItemTemplate>
                      <asp:Panel ID="pnea" runat="server">
                      <asp:Label ID="lblename" runat="server" Text='<%#Eval("Address") %>'></asp:Label> 
                      </asp:Panel>
                      <asp:Panel ID="pnpa" runat="server" Visible="false">
                      <asp:Label ID="lblaname" runat="server" Text='<%#Eval("paddress") %>' style="font-family:myfont"></asp:Label>
                      </asp:Panel>
                   </ItemTemplate>
              </asp:TemplateField >
              <asp:TemplateField HeaderText="Status" >
                <ItemTemplate>
                   
                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>' CssClass="a"></asp:Label>
                </ItemTemplate>
                  <EditItemTemplate>
                       <asp:HiddenField ID="hfid" runat="server" Value='<%#Eval("id") %>' />
                      <asp:TextBox ID="txtst" runat="server" CssClass="a"
                          Text='<%# Eval("status")%>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                 
                    <asp:LinkButton ID="lnkdelete" Visible="false" CommandArgument='<%#Eval("id") %>' OnClick="lnkdelete_Click" runat="server">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </asp:GridView>
   
</asp:Content>

