<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="checkreward.aspx.cs" Inherits="Client_checkreward" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  This Month Active Pair  <%=thismonthinst %>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="PID" HeaderText="UID" />
                  <asp:BoundField DataField="ActiveLeft" HeaderText="ActiveLeft" />
            <asp:BoundField DataField="Active" HeaderText="ActiveId" />
       
        </Columns>
    </asp:GridView>
</asp:Content>

