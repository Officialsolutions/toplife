<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Receipt.aspx.cs" Inherits="Admin_Receipt" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Receipt Book</h3>
    <hr />

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-md-8">
        <div class="form-group">
            <label>Session</label>
            <asp:DropDownList ID="ddlsession" runat="server" CssClass="form-control">
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
                <asp:ListItem>2020</asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="form-group">
            <label>Date</label>
            <asp:TextBox ID="txtdate" runat="server" class="form-control" placeholder="Date"></asp:TextBox>
            <ajaxToolkit:CalendarExtender runat="server" Format="dd/MM/yyyy" BehaviorID="txtdate_CalendarExtender" TargetControlID="txtdate" ID="txtdate_CalendarExtender"></ajaxToolkit:CalendarExtender>
        </div>
        <div class="form-group">
            <label>Id</label>
            <asp:TextBox ID="txtname" AutoPostBack="true" OnTextChanged="txtname_TextChanged" runat="server" class="form-control" placeholder="Enter Id"></asp:TextBox>
            <b>
                <asp:Label ID="lblname" runat="server" Text=""></asp:Label></b>
        </div>
        <div class="form-group">
            <label>Book Start Serial</label>
            <asp:TextBox ID="txtstart" runat="server" class="form-control" placeholder="Starting eg:01"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Book End Serial</label>
            <asp:TextBox ID="txtend" runat="server" class="form-control" placeholder="Starting eg:01"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click" />
        </div>

    </div>
    <div class="col-md-4">
        <asp:RadioButtonList ID="rdochk" runat="server">
            <asp:ListItem Value="01" Selected="True">Jan</asp:ListItem>
            <asp:ListItem Value="02">Feb</asp:ListItem>
            <asp:ListItem Value="03">Mar</asp:ListItem>
            <asp:ListItem Value="04">Apr</asp:ListItem>
            <asp:ListItem Value="05">May</asp:ListItem>
            <asp:ListItem Value="06">Jun</asp:ListItem>
            <asp:ListItem Value="07">Jul</asp:ListItem>
            <asp:ListItem Value="08">Aug</asp:ListItem>
            <asp:ListItem Value="09">Sep</asp:ListItem>
            <asp:ListItem Value="10">Oct</asp:ListItem>
            <asp:ListItem Value="11">Nov</asp:ListItem>
            <asp:ListItem Value="12">Dec</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div class="col-md-12">
        <h3>Book Owner
        </h3>

        <hr />

        <div class="col-md-3">
            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="form-control">
                <asp:ListItem>Select Month</asp:ListItem>
                <asp:ListItem Value="01">Jan</asp:ListItem>
                <asp:ListItem Value="02">Feb</asp:ListItem>
                <asp:ListItem Value="03">Mar</asp:ListItem>
                <asp:ListItem Value="04">Apr</asp:ListItem>
                <asp:ListItem Value="05">May</asp:ListItem>
                <asp:ListItem Value="06">Jun</asp:ListItem>
                <asp:ListItem Value="07">Jul</asp:ListItem>
                <asp:ListItem Value="08">Aug</asp:ListItem>
                <asp:ListItem Value="09">Sep</asp:ListItem>
                <asp:ListItem Value="10">Oct</asp:ListItem>
                <asp:ListItem Value="11">Nov</asp:ListItem>
                <asp:ListItem Value="12">Dec</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:DropDownList ID="yearfilter" runat="server" CssClass="form-control">
                <asp:ListItem>Select Year</asp:ListItem>
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
                <asp:ListItem>2020</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnfilter" OnClick="btnfilter_Click" runat="server" Text="submit" CssClass="btn btn-default" />
        </div>
        <div class="col-lg-4">
            <asp:TextBox ID="txtrecp" runat="server" CssClass="form-control" placeholder="Search Receipt No. Here" OnTextChanged="txtrecp_TextChanged" AutoPostBack="true"></asp:TextBox>

        </div>
        <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="SNO">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:TemplateField HeaderText="action">
                        <ItemTemplate>
                            <%--                    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CommandArgument='<%#Eval("id") %>' runat="server">Edit</asp:LinkButton>--%>
                            <asp:LinkButton ID="lnkcheck" OnClick="lnkcheck_Click" CommandArgument='<%#Eval("adminid") %>' runat="server">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="SNO">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Assigned To/Reg No.">
                        <ItemTemplate>
                          <%# Eval("adminname") %>/  <%# Eval("adminid") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Used For/Reg No.">
                        <ItemTemplate>
                            <%# Eval("NAME") %>/  <%# Eval("Id") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("DATE_ENTRY")).ToString("dd/MM/yyyy") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>  

    </div>
</asp:Content>

