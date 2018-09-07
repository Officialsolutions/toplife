<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
.text-box
{
border:3px solid #c74090;
}
.text-box1	
{
border:3px solid #fba91c;
}
.admin-btn
{
background:#37f329;
font-weight:900;
}
</style>



<div class="container">
            <div class="row" style="padding:50px 0px;">
                <div class="col-sm-4 col-xs-3 col-sm-offset-4" style="border:4px solid #fba91c; background:#fba91c;">
                    <div role="tabpanel" class="login-regiter-tabs">

                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane active" id="login">
                                <form>
		   <h4 class="text-center" style="color:#37c1f0; weight:600;">Admin Login</h4>
								<img src="img/logo4.png" style="padding-bottom:20px; background: #fff; padding: 20px 32px;">                                
                                    <div class="form-group">
									<h4 style="color:#c74090;text-align: left;padding-bottom: 0px;">Enter Username</h4>
									 <asp:TextBox ID="TextBox1" runat="server" CssClass="login_input form-control text-box">
                                        </asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill ID" 
                                            Text="*" ValidationGroup="aa" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
											
											
											
                                        
                                    </div>
                                    <div class="form-group">
<h4 style="color:#fff;text-align: left;padding-bottom: 0px;">Enter Password</h4>
<asp:TextBox ID="TextBox2" runat="server" CssClass="login_input form-control text-box1" TextMode="Password"></asp:TextBox>
                                       <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator2" runat="server" 
                                            ErrorMessage="Please Fill Password" Text="*" ValidationGroup="aa" 
                                            ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                                    </div>                                  
                                    <div class="pull-left">

                                          <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#CC0066"></asp:Label>

                                    </div>
                                    <div class="pull-left"  style="padding-bottom:20px;">
									
									 <asp:Button ID="Button1" runat="server" Text="LogIn" font-weight="900" CssClass="lb-buttion btn btn-theme-dark admin-btn"  
                                            onclick="Button1_Click" ValidationGroup="aa" />
                        			    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="aa" />
											
											
									
                                        
                                    </div>
                                    <div class="clearfix"></div>
                                </form>
                            </div><!--login tab end-->
                            </div>

                    </div>
                </div>
            </div>
        </div>
</asp:Content>

