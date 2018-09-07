<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Leader-Punj.aspx.cs" Inherits="Client_Leader_Punj" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        @font-face
    {
        font-family:myfont;
        src:url(chatrik.ttf);   
    }
    </style>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
    <div>
    
    <asp:GridView ID="gvdata" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowDataBound="gvdata_RowDataBound"  >
        <Columns>
            <asp:TemplateField HeaderText="SNo">
                <ItemTemplate>
                     <%#Container.DataItemIndex+1 %>
                      <asp:HiddenField ID="mid" runat="server" Value='<%#Eval("memberid") %>' /> 
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:BoundField DataField="month" HeaderText="Month" />--%>
            <asp:BoundField DataField="memberid" HeaderText="Id" />
          
            <asp:TemplateField HeaderText="Name">
                 <ItemTemplate>
                                           <asp:Label ID="lblpname" runat="server" Text='<%#Eval("pname") %>' style="font-family:myfont"></asp:Label> <asp:Label ID="Label3" runat="server" Text='<%#Eval("rel") %>'></asp:Label> <asp:Label ID="Label4" runat="server" Text='<%#Eval("pfather") %>' style="font-family:myfont"></asp:Label>

                 </ItemTemplate>

             </asp:TemplateField>
         
          
            <asp:BoundField DataField="mobile" HeaderText="Mobile" />
            <asp:BoundField DataField="mobile2" HeaderText="Mobile2" />
            <asp:TemplateField HeaderText="Address">
                  <ItemTemplate>
                                            <asp:Label ID="lblaname" runat="server" Text='<%#Eval("paddress") %>' style="font-family:myfont"></asp:Label>

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
             <asp:TemplateField HeaderText="Ins">
                <ItemTemplate>
                    <asp:Label ID="lblins" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pre">
                <ItemTemplate>
                    <asp:Label ID="lblpre" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cur">
                <ItemTemplate>
                    <asp:Label ID="lblcur" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
           
        </Columns>
    </asp:GridView>
              <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
             <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
             <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="width: 19px;"><%=pres %></td>
            <td style="    width: 121px;"><%=curnt %></td>
        </tr>
       
    </table>
    </div>
    </form>
</body>
</html>
