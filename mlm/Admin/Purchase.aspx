<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="Admin_Purchase" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h3>Purchase</h3>
    <hr />

    <div class="col-md-8">

        <div class="col-md-12">
            <div class="form-group col-md-4">

                <asp:TextBox ID="txtregno" AutoPostBack="true" OnTextChanged="txtregno_TextChanged" runat="server" class="form-control" placeholder="Enter Id"></asp:TextBox>
                <asp:Label ID="lblname" runat="server" Text=""></asp:Label>

            </div>
            <div class="form-group col-md-4">

                <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Search Product Name"></asp:TextBox>

                <ajaxToolkit:AutoCompleteExtender ServiceMethod="SearchCustomers"
                    MinimumPrefixLength="2"
                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                    TargetControlID="txtname"
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                </ajaxToolkit:AutoCompleteExtender>
            </div>
            <div class="form-group col-md-4">

                <asp:TextBox ID="txtqty" placeholder="Quantity" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please fill out this" ControlToValidate="txtqty" ValidationGroup="g"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^\d+$" ControlToValidate="txtqty" ValidationGroup="g" ErrorMessage="enter Numeric value only"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Button CssClass="btn-success btn" ID="btnsubmit" runat="server"
                    Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="g" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="g" DisplayMode="List" />
            </div>
        </div>
        <div class="col-md-12">
            <asp:GridView ID="GridView1" CssClass="table table-bordered" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="30" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
                    <asp:BoundField DataField="serial" HeaderText="Serial No." ItemStyle-Width="150" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" ItemStyle-Width="150" />
                    <asp:BoundField DataField="price" HeaderText="Price/Pic." ItemStyle-Width="150" />
                    <asp:BoundField DataField="bv" HeaderText="BV" ItemStyle-Width="150" />
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="total" runat="server" Text='<%#Eval("total") %>'></asp:Label>
                            <asp:HiddenField ID="hfid" Value='<%#Eval("pid") %>' runat="server" />
                            <asp:HiddenField ID="qty" Value='<%#Eval("quantity") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BVTotal">
                        <ItemTemplate>
                            <asp:Label ID="bvtotal" runat="server" Text='<%#Eval("BVTotal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="Button1" Visible="false" runat="server" OnClick="Button1_Click" Text="Create Invoice" CssClass="btn btn-danger" />
        </div>
    </div>
    <div class="col-md-4">
        Total MRP :
        <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;
        Total BV  
        <asp:Label ID="lblbvtotal" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

