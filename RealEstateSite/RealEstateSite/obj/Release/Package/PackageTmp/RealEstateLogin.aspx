<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RealEstateLogin.aspx.cs" Inherits="RealEstateSite.RealEstateLogin" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Stylesheet/Main.css" rel="stylesheet" />
    <link href="Stylesheet/Login.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous"/>
</head>
<body style="background-color:#D5B4B4;">
    <h1 id="welcomeMsg">Find your sweet home</h1>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:Panel ID="AccountPanel" runat="server" CssClass="myModal bg-light bg-opacity-75" BorderStyle="Solid" Visible = "false">
            <asp:Label ID="accountlbl" runat="server" Text="Account Creation" Font-Size="X-Large" CssClass="text-center"></asp:Label><br />
            <asp:Label ID="accountmsg" runat="server" ForeColor="Red"></asp:Label><br />

            Username <asp:TextBox ID="AccountUsernametxt" runat="server"></asp:TextBox><br />
            Full name <asp:TextBox ID="AccountFullnametxt" runat="server"></asp:TextBox><br />
            
            Role 
            <asp:DropDownList ID="AccountRoleddl" runat="server">
                <asp:ListItem>Buyer</asp:ListItem>
                <asp:ListItem>Seller</asp:ListItem>
                <asp:ListItem>Agent</asp:ListItem>
            </asp:DropDownList><br />

            Email <asp:TextBox ID="AccountEmailtxt" runat="server"></asp:TextBox><br />
            Password <asp:TextBox ID="AccountPasswordtxt" runat="server" TextMode="Password"></asp:TextBox><br />
            Phone number <asp:TextBox ID="AccountPhonetxt" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="Q1lbl" runat="server" Text="What was your first car?"></asp:Label><br />
            <asp:TextBox ID="A1txt" runat="server"></asp:TextBox><br />
            
            <asp:Label ID="Q2lbl" runat="server" Text="What was your dream job as a child"></asp:Label><br />
            <asp:TextBox ID="A2txt" runat="server"></asp:TextBox><br />

            <asp:Label ID="Q3lbl" runat="server" Text="What is the name of the company of your first job?"></asp:Label><br />
            <asp:TextBox ID="A3txt" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="AccountSubmitBtn" runat="server" Text ="Submit" OnClick="AccountSubmitBtn_Click" />
            <asp:Button ID="AccountCloseBtn" runat="server" Text="Close" OnClick="AccountCloseBtn_Click" />

            <ajaxToolkit:ModalPopupExtender ID="AccountModal" runat="server" TargetControlID="accountbtn" PopupControlID="AccountPanel, LoginPanel" OkControlID="AccountCloseBtn" >
            </ajaxToolkit:ModalPopupExtender>
        </asp:Panel>
    
        <asp:Panel ID="LoginPanel" CssClass="myModal bg-light bg-opacity-75" runat="server" BorderStyle="Solid" Visible="true">
            <asp:Label ID="loginmsg" runat="server" ForeColor="Red"></asp:Label><br />
            <asp:RequiredFieldValidator ID="usernameValidator" runat="server" ControlToValidate="usernametxt" ErrorMessage="Username missing" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ControlToValidate="passwordtxt" ErrorMessage="Password missing" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="usernamelbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="usernametxt" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="passwordlbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="passwordtxt" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />
            <asp:CheckBox ID="rememberMe" runat="server" Text="Remember Me"/>
            <br /><br />
            <asp:Button ID="loginbtn" runat="server" Text="Login" OnClick="loginbtn_Click" />
            <br />
            <asp:Button ID="accountbtn" runat="server" Text="Create Account" OnClick="accountbtn_Click" CausesValidation="False" CssClass="btn btn-link"/>
            <asp:Button ID="forgetpassbtn" runat="server" Text="Forget Password" CausesValidation="False" OnClick="forgetpassbtn_Click" CssClass="btn btn-link"/>
        </asp:Panel>

        <asp:Panel ID="PasswordPanel" runat="server" CssClass="myModal bg-light bg-opacity-75" BorderStyle="Solid" Visible = "false">
            <asp:Label ID="PasswordRecoverylbl" runat="server" Text="Password Recovery" Font-Size="X-Large"></asp:Label><br />
            <asp:Label ID="Passwordmsg" runat="server" ForeColor="Red"></asp:Label><br />
            Email <asp:TextBox ID="PasswordEmailtxt" runat="server"></asp:TextBox><br />
            Account Type
            <asp:DropDownList ID="passwordroleddl" runat="server">
                <asp:ListItem>Buyer</asp:ListItem>
                <asp:ListItem>Seller</asp:ListItem>
                <asp:ListItem>Agent</asp:ListItem>
            </asp:DropDownList><br /><br />
            <asp:Button ID="PasswordSendbtn" runat="server" Text ="Send Email" OnClick="PasswordSendbtn_Click"/>
            <asp:Button ID="PasswordClosebtn" runat="server" Text="Close" OnClick="PasswordClosebtn_Click"/>
            <ajaxToolkit:ModalPopupExtender ID="PasswordModal" runat="server" TargetControlID="forgetpassbtn" PopupControlID="LoginPanel, PasswordPanel" OkControlID="PasswordClosebtn" >
            </ajaxToolkit:ModalPopupExtender>
        </asp:Panel>

        <asp:Panel ID="PINPanel" runat="server" CssClass="myModal bg-light bg-opacity-75" BorderStyle="Solid" Visible = "false">
            <asp:Label ID="Pinlbl" runat="server" Text="Please enter your PIN that was sent to the email you entered" Font-Size="X-Large"></asp:Label><br />
            <asp:Label ID="Pinmsg" runat="server" ForeColor="Red"></asp:Label><br />
            <asp:TextBox ID="Pintxt" runat="server" TextMode="Number"></asp:TextBox><br /><br />
            <asp:Button ID="PinSubmitbtn" runat="server" Text ="Submit" OnClick="PinSubmitbtn_Click"/>
            <asp:Button ID="PinBackbtn" runat="server" Text="Didn't receive the email?" OnClick="PinBackbtn_Click" />
            <ajaxToolkit:ModalPopupExtender ID="PinModal" runat="server" TargetControlID="PasswordSendbtn" PopupControlID="PINPanel, PasswordPanel" OkControlID="PinBackbtn" >
            </ajaxToolkit:ModalPopupExtender>
        </asp:Panel>

         <asp:Panel ID="SecurityQuestionPanel" runat="server" CssClass="myModal bg-light bg-opacity-75" BorderStyle="Solid" Visible = "false">
            <asp:Label ID="SQPmsg" runat="server" Text="Please Answer Your Security Question" Font-Size="X-Large"></asp:Label><br />
            <asp:Label ID="SQPQuestionlbl" runat="server" ForeColor="Red"></asp:Label><br />
            <asp:TextBox ID="SQPAnswertxt" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="SQPSubmitbtn" runat="server" Text ="Submit" OnClick="SQPSubmitbtn_Click"/>
            <asp:Button ID="SQPChangePassbtn" runat="server" Text="Change Password" Visible ="false" OnClick="SQPChangePassbtn_Click" />
            <asp:Button ID="SQPBackbtn" runat="server" Text="Back" OnClick="SQPBackbtn_Click"/>
            <ajaxToolkit:ModalPopupExtender ID="SQLModal" runat="server" TargetControlID="PinSubmitbtn" PopupControlID="PINPanel, SecurityQuestionPanel" OkControlID="SQPBackbtn, SQPChangePassbtn" >
            </ajaxToolkit:ModalPopupExtender>
        </asp:Panel>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
    </form>
    </body>
</html>