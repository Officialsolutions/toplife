<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Setting.aspx.cs" Inherits="Admin_Setting" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        table#ctl00_ContentPlaceHolder1_rdochk tr td {
    display: inline;
    float: left;
    padding: 10px;
    border: none;
}
        table#ctl00_ContentPlaceHolder1_rdochk tr {
    display: inline;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h4>Settings</h4>
    <p>Here We Can Update The Joining Date and Update Login id</p>
    <hr />
    <div class="col-md-12">
        <div class="form-group col-md-12">
            <label>Login Serial</label>
            <asp:TextBox ID="txtserial" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label>Select Date Setting</label>
            <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                <asp:ListItem>Automatic</asp:ListItem>
                <asp:ListItem>Manual</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-6">
            <label>Date Manually</label>
            <asp:TextBox ID="txtdate" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>

            <cc1:CalendarExtender runat="server" TargetControlID="txtdate" Format="dd/MM/yyyy" ID="txtdate_CalendarExtender"></cc1:CalendarExtender>
        </div>
        <div class="form-group col-md-12">
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" CssClass="btn btn-default" />
        </div>
    </div>
    <div class="col-md-12">
         <div class="form-group col-md-6">
            <label>From Date</label>
            <asp:TextBox ID="txtfrom" CssClass="form-control" runat="server"></asp:TextBox>

            <cc1:CalendarExtender runat="server" TargetControlID="txtfrom" Format="yyyy-MM-dd" ID="CalendarExtender1"></cc1:CalendarExtender>
        </div>
         <div class="form-group col-md-6">
            <label>To Date</label>
            <asp:TextBox ID="txtto"  CssClass="form-control" runat="server"></asp:TextBox>

            <cc1:CalendarExtender runat="server" TargetControlID="txtto" Format="yyyy-MM-dd" ID="CalendarExtender2"></cc1:CalendarExtender>
        </div>
         <div class="form-group col-md-12">
            <asp:Button ID="btndate" runat="server" Text="Submit Date" OnClick="btndate_Click" CssClass="btn btn-default" />
        </div>
    </div>
    <div class="well col-md-12 clearfix">
       <div class="col-md-8">
           <h4>Montly Leads</h4>
           <div class="form-group col-md-12">
            <label>Session</label>
            <asp:TextBox ID="txtsession" Visible="false" CssClass="form-control" Text="2018-2019" Enabled="false" runat="server"></asp:TextBox>
               <asp:DropDownList ID="ddlsession" OnSelectedIndexChanged="ddlsession_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                   <asp:ListItem>2017</asp:ListItem>
                   <asp:ListItem>2018</asp:ListItem>
                   <asp:ListItem>2019</asp:ListItem>
                   <asp:ListItem>2020</asp:ListItem>
               </asp:DropDownList>

            <cc1:CalendarExtender runat="server" TargetControlID="txtfrom" Format="yyyy-MM-dd" ID="CalendarExtender5"></cc1:CalendarExtender>
        </div>
         <div class="form-group col-md-6">
            <label>From Date</label>
            <asp:TextBox ID="txtlfrom" CssClass="form-control" runat="server"></asp:TextBox>

            <cc1:CalendarExtender runat="server" TargetControlID="txtlfrom" Format="yyyy-MM-dd" ID="CalendarExtender3"></cc1:CalendarExtender>
        </div>
         <div class="form-group col-md-6">
            <label>To Date</label>
            <asp:TextBox ID="txtlto"  CssClass="form-control" runat="server"></asp:TextBox>

            <cc1:CalendarExtender runat="server" TargetControlID="txtlto" Format="yyyy-MM-dd" ID="CalendarExtender4"></cc1:CalendarExtender>
        </div>
         <div class="form-group col-md-12">
            <asp:Button ID="btnleads" runat="server" Text="Submit Date" OnClick="btnleads_Click" CssClass="btn btn-default" />
             <asp:Button ID="btnupdate" runat="server" Visible="false" Text="Update Date" OnClick="btnupdate_Click" CssClass="btn btn-default" />
        </div>
    </div>
        <div class="col-md-4">
            <h4>Month List</h4>
            
            <asp:RadioButtonList ID="rdochk" runat="server">
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
            </asp:RadioButtonList>
        </div>
        </div>
    <div class="col-md-12">
        <h4>Montly List</h4>
        <asp:GridView ID="gvdata" runat="server" CssClass="table  table-bordered" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Month" HeaderText="Month" />
                <asp:BoundField DataField="Fromdate" HeaderText="From" />
                <asp:BoundField DataField="ToDate" HeaderText="To" />
                <asp:BoundField DataField="Session" HeaderText="Session" />
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit" OnClick="lnkedit_Click" runat="server" CommandArgument='<%#Eval("id") %>'>Edit</asp:LinkButton>
                        <asp:LinkButton ID="lnkdelete" OnClick="lnkdelete_Click" runat="server" CommandArgument='<%#Eval("id") %>'>Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
