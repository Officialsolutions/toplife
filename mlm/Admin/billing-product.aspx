<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="billing-product.aspx.cs" Inherits="Admin_billing_product" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Sale Product</h2>

    <asp:Label ID="txtregno" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
    <hr />
    <div class="col-md-10">

        <div class="col-md-12">
            <div class="form-group col-md-3">
                Date
                <asp:TextBox ID="txtdate" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please fill out this" ControlToValidate="txtdate" ValidationGroup="g1" ForeColor="Red"></asp:RequiredFieldValidator>
                <ajaxToolkit:CalendarExtender ID="txtdate_CalendarExtender" runat="server" BehaviorID="txtdate_CalendarExtender" TargetControlID="txtdate" Format="dd/MM/yyyy" />
                <hr />

            </div>
            <div class="form-group col-md-3">
                Product
                <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Search Product Name"></asp:TextBox>

                <ajaxToolkit:AutoCompleteExtender ID="txtname_AutoCompleteExtender" runat="server" ServiceMethod="SearchCustomers" BehaviorID="txtname_AutoCompleteExtender" MinimumPrefixLength="2"
                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtname" FirstRowSelected="false">
                </ajaxToolkit:AutoCompleteExtender>
            </div>
            <div class="form-group col-md-3">
                Quantity
                <asp:TextBox ID="txtqty" placeholder="Quantity" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please fill out this" ForeColor="Red" ControlToValidate="txtqty" ValidationGroup="g"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^\d+$" ControlToValidate="txtqty" ValidationGroup="g" ErrorMessage="enter Numeric value only"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group col-md-3">
                Serial No.
         <asp:TextBox ID="txtserial" runat="server" class="form-control" OnTextChanged="txtserial_TextChanged" AutoPostBack="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please fill out this" ControlToValidate="txtserial" ValidationGroup="g" ForeColor="Red"></asp:RequiredFieldValidator>
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
                    <asp:TemplateField HeaderText="Serial No.">
                        <ItemTemplate>
                            <asp:Label ID="lblserial" runat="server" Text='<%#Eval("serial") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
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
            <asp:Button ID="Button1" Visible="false" runat="server" OnClick="Button1_Click" Text="Create Invoice" CssClass="btn btn-danger" ValidationGroup="g1" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="g1" DisplayMode="BulletList" />
        </div>
    </div>
    <div class="col-md-2">
        MRP :
        <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;
         BV : 
        <asp:Label ID="lblbvtotal" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

