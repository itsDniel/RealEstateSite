<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RealEstateLogin.aspx.cs" Inherits="RealEstateSite.RealEstateLogin" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Stylesheet/Login.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:Panel ID="AccountPanel" runat="server" CssClass="Modal" BorderStyle="Solid" Visible = "false">
            <asp:Label ID="accountlbl" runat="server" Text="Account Creation" Font-Size="X-Large"></asp:Label>
            <asp:Label ID="accountmsg" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="AccountUsernamelbl" runat="server" Text="Please enter your username"></asp:Label>
            <asp:TextBox ID="AccountUsernametxt" runat="server"></asp:TextBox>
            <asp:Label ID="AccountFullnamelbl" runat="server" Text="Please enter your full name"></asp:Label>
            <asp:TextBox ID="AccountFullnametxt" runat="server"></asp:TextBox>
            <asp:Label ID="AccountRole" runat="server" Text="Please choose your role"></asp:Label>
            <asp:DropDownList ID="AccountRoleddl" runat="server">
                <asp:ListItem>Buyer</asp:ListItem>
                <asp:ListItem>Seller</asp:ListItem>
                <asp:ListItem>Agent</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="AccountEmail" runat="server" Text="Please enter your email"></asp:Label>
            <asp:TextBox ID="AccountEmailtxt" runat="server"></asp:TextBox>
            <asp:Label ID="AccountPasswordlbl" runat="server" Text="Please enter your password"></asp:Label>
            <asp:TextBox ID="AccountPasswordtxt" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="AccountPhonelbl" runat="server" Text="Please enter your phone number"></asp:Label>
            <asp:TextBox ID="AccountPhonetxt" runat="server"></asp:TextBox>
            <asp:Label ID="Q1lbl" runat="server" Text="What was your first car?"></asp:Label>
            <asp:TextBox ID="A1txt" runat="server"></asp:TextBox>
            <asp:Label ID="Q2lbl" runat="server" Text="What was your dream job as a child"></asp:Label>
            <asp:TextBox ID="A2txt" runat="server"></asp:TextBox>
            <asp:Label ID="Q3lbl" runat="server" Text="What is the name of the company of your first job?"></asp:Label>
            <asp:TextBox ID="A3txt" runat="server"></asp:TextBox>
            <asp:Button ID="AccountSubmitBtn" runat="server" Text ="Submit" OnClick="AccountSubmitBtn_Click" />
            <asp:Button ID="AccountCloseBtn" runat="server" Text="Close" OnClick="AccountCloseBtn_Click" />
            <ajaxToolkit:ModalPopupExtender ID="AccountModal" runat="server" TargetControlID="accountbtn" PopupControlID="AccountPanel, LoginPanel" OkControlID="AccountCloseBtn" >
            </ajaxToolkit:ModalPopupExtender>
        </asp:Panel>
    
        <asp:Panel ID="LoginPanel" CssClass="login" runat="server" BorderStyle="Solid" Visible="true">
        <asp:Label ID="loginlbl" runat="server" Font-Size="X-Large" Text="Login"></asp:Label>
        <asp:Label ID="loginmsg" runat="server" ForeColor="Red"></asp:Label>
        <asp:RequiredFieldValidator ID="usernameValidator" runat="server" ControlToValidate="usernametxt" ErrorMessage="Username missing" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ControlToValidate="passwordtxt" ErrorMessage="Password missing" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:Label ID="usernamelbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="usernametxt" runat="server"></asp:TextBox>
        <asp:Label ID="passwordlbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="passwordtxt" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CheckBox ID="rememberMe" runat="server" Text="Forget me not"/>
        <asp:Button ID="loginbtn" runat="server" Text="Login" OnClick="loginbtn_Click" />
        <asp:Button ID="accountbtn" runat="server" Text="Create Account" OnClick="accountbtn_Click" CausesValidation="False" />
        <asp:Button ID="forgetpassbtn" runat="server" Text="Forget Password" CausesValidation="False" OnClick="forgetpassbtn_Click" />
        </asp:Panel>

        <asp:Panel ID="PasswordPanel" runat="server" CssClass="Modal" BorderStyle="Solid" Visible = "false">
            <asp:Label ID="PasswordRecoverylbl" runat="server" Text="Password Recovery" Font-Size="X-Large"></asp:Label>
            <asp:Label ID="Passwordmsg" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="PasswordEmaillbl" runat="server" Text="Please enter your Email"></asp:Label>
            <asp:TextBox ID="PasswordEmailtxt" runat="server"></asp:TextBox>
            <asp:Label ID="PasswordRole" runat="server" Text="Please choose your account type"></asp:Label>
            <asp:DropDownList ID="passwordroleddl" runat="server">
                <asp:ListItem>Buyer</asp:ListItem>
                <asp:ListItem>Seller</asp:ListItem>
                <asp:ListItem>Agent</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="PasswordSendbtn" runat="server" Text ="Send Email" OnClick="PasswordSendbtn_Click"/>
            <asp:Button ID="PasswordClosebtn" runat="server" Text="Close" OnClick="PasswordClosebtn_Click"/>
            <ajaxToolkit:ModalPopupExtender ID="PasswordModal" runat="server" TargetControlID="forgetpassbtn" PopupControlID="LoginPanel, PasswordPanel" OkControlID="PasswordClosebtn" >
            </ajaxToolkit:ModalPopupExtender>
        </asp:Panel>

        <asp:Panel ID="PINPanel" runat="server" CssClass="Modal" BorderStyle="Solid" Visible = "false">
            <asp:Label ID="Pinlbl" runat="server" Text="Please enter your PIN that was sent to the email you entered" Font-Size="X-Large"></asp:Label>
            <asp:Label ID="Pinmsg" runat="server" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="Pintxt" runat="server"></asp:TextBox>
            <asp:Button ID="PinSubmitbtn" runat="server" Text ="Submit" OnClick="PinSubmitbtn_Click"/>
            <asp:Button ID="PinBackbtn" runat="server" Text="Didn't receive the email?" OnClick="PinBackbtn_Click" />
            <ajaxToolkit:ModalPopupExtender ID="PinModal" runat="server" TargetControlID="PasswordSendbtn" PopupControlID="PINPanel, PasswordPanel" OkControlID="PinBackbtn" >
            </ajaxToolkit:ModalPopupExtender>
        </asp:Panel>

         <asp:Panel ID="SecurityQuestionPanel" runat="server" CssClass="Modal" BorderStyle="Solid" Visible = "false">
            <asp:Label ID="SQPmsg" runat="server" Text="Please Answer Your Security Question" Font-Size="X-Large"></asp:Label>
            <asp:Label ID="SQPQuestionlbl" runat="server" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="SQPAnswertxt" runat="server"></asp:TextBox>
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
