<%@ Page Title="" Language="C#" MasterPageFile="~/Admin1/MasterPage.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Admin1_Settings" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
</asp:Content>

