using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using RealEstateClassLibary;
using RealEstateSoap;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace RealEstateSite
{
    public partial class RealEstateLogin : System.Web.UI.Page
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        public static int PIN { get; set; }
        public static string email { get; set; }
        public static string role { get; set; }
        public static string question { get; set; }
        public static string answer { get; set; }
        private Byte[] key = { 53, 215, 97, 18, 244, 76, 131, 212, 63, 99, 12, 20, 132, 190, 45, 220  };

        private Byte[] vector = { 162, 50, 228, 9, 73, 184, 37, 99, 215, 138, 102, 120, 125, 152, 220, 180 };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.Cookies["LoginUser"] != null && Request.Cookies["LoginPassword"] != null)
                {
                    if (Request.QueryString["logout"] == "true")
                    {
                        usernametxt.Text = Request.Cookies["LoginUser"].Value.ToString();
                        passwordtxt.Text = Request.Cookies["LoginPassword"].Value.ToString();
                    }
                    else
                    {
                        usernametxt.Text = Request.Cookies["LoginUser"].Value.ToString();
                        passwordtxt.Text = Request.Cookies["LoginPassword"].Value.ToString();
                        loginbtn_Click(sender, e);
                    }
                }
            }
        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            loginmsg.Visible = false;
            if(!string.IsNullOrEmpty(usernametxt.Text) && !string.IsNullOrEmpty(passwordtxt.Text))
            {
                User user = new User();
                user.Username = usernametxt.Text;
                string Password = passwordtxt.Text;
                Byte[] textBytes;
                string encryptedPass;
                UTF8Encoding encoder = new UTF8Encoding();
                textBytes = encoder.GetBytes(Password);
                RijndaelManaged rmEncryption = new RijndaelManaged();
                MemoryStream stream = new MemoryStream();
                CryptoStream encryptionStream = new CryptoStream(stream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);
                encryptionStream.Write(textBytes, 0, textBytes.Length);
                encryptionStream.FlushFinalBlock();
                stream.Position = 0;
                Byte[] encryptedBytes = new Byte[stream.Length];
                stream.Read(encryptedBytes, 0, encryptedBytes.Length);
                encryptionStream.Close();
                stream.Close();
                encryptedPass = Convert.ToBase64String(encryptedBytes);
                user.Password = encryptedPass;
                int userCount = pxy.scalarLogin(user);
                if(userCount > 0)
                {
                    if (rememberMe.Checked)
                    {
                        loginmsg.Visible = true;
                        loginmsg.Text = "Login Success";
                        HttpCookie username = new HttpCookie("Username");
                        HttpCookie loginuser = new HttpCookie("LoginUser");
                        HttpCookie loginPass = new HttpCookie("LoginPassword");
                        loginuser.Value = usernametxt.Text;
                        loginuser.Expires = DateTime.MaxValue;
                        loginPass.Value = passwordtxt.Text;
                        loginPass.Expires = DateTime.MaxValue;
                        username.Value = usernametxt.Text;
                        Response.Cookies.Add(username);
                        Response.Cookies.Add(loginuser);
                        Response.Cookies.Add(loginPass);
                        string role = pxy.getRole(usernametxt.Text);
                        string buyer = "Buyer";
                        if (role.Equals(buyer))
                        {
                            Response.Redirect("Search.aspx");
                        }
                        else
                        {
                            Response.Redirect("House.aspx");
                        }
                    }
                    else
                    {
                        loginmsg.Visible = true;
                        loginmsg.Text = "Login Success";
                        HttpCookie username = new HttpCookie("Username");
                        username.Value = usernametxt.Text;
                        Response.Cookies.Add(username);
                        string role = pxy.getRole(usernametxt.Text);
                        string buyer = "Buyer";
                        if (role.Equals(buyer))
                        {
                            Response.Redirect("Search.aspx");
                        }
                        else
                        {
                            Response.Redirect("House.aspx");
                        }
                    }
                }
                else
                {
                    loginmsg.Visible = true;
                    loginmsg.Text = "The Login Credential is wrong";
                }
            }
            else
            {
                loginmsg.Visible = true;
                loginmsg.Text = "You must enter your credential!";
            }
        }


        protected void accountbtn_Click(object sender, EventArgs e)
        {
            LoginPanel.Visible = false;
            AccountPanel.Visible = true;
        }

        protected void AccountCloseBtn_Click(object sender, EventArgs e)
        {
            LoginPanel.Visible = true;
            AccountPanel.Visible = false;
        }

        protected void AccountSubmitBtn_Click(object sender, EventArgs e)
        {
            EmailAddressAttribute em = new EmailAddressAttribute();
            User user = new User();
            user.Username = AccountUsernametxt.Text;
            user.Role = AccountRoleddl.Text;
            user.FullName = AccountFullnametxt.Text;
            user.Email = AccountEmailtxt.Text;
            user.Phone = AccountPhonetxt.Text;
            user.Q1 = Q1lbl.Text;
            user.Q2 = Q2lbl.Text;
            user.Q3 = Q3lbl.Text;
            user.A1 = A1txt.Text;
            user.A2 = A2txt.Text;
            user.A3 = A3txt.Text;
            string Password = AccountPasswordtxt.Text;
            Byte[] textBytes;
            string encryptedPass;
            UTF8Encoding encoder = new UTF8Encoding();
            textBytes = encoder.GetBytes(Password);
            RijndaelManaged rmEncryption = new RijndaelManaged();
            MemoryStream stream = new MemoryStream();
            CryptoStream encryptionStream = new CryptoStream(stream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);
            encryptionStream.Write(textBytes, 0, textBytes.Length);
            encryptionStream.FlushFinalBlock();
            stream.Position = 0;
            Byte[] encryptedBytes = new Byte[stream.Length];
            stream.Read(encryptedBytes, 0, encryptedBytes.Length);
            encryptionStream.Close();
            stream.Close();
            encryptedPass = Convert.ToBase64String(encryptedBytes);
            user.Password = encryptedPass;
            foreach (Control control in AccountPanel.Controls)
            {
                if (control is TextBox)
                {
                    TextBox tb = control as TextBox;
                    if (string.IsNullOrEmpty(tb.Text))
                    {
                        accountmsg.Text = "You must enter all informmation!";
                    }
                    else
                    {
                        if (!em.IsValid(AccountEmailtxt.Text))
                        {
                            accountmsg.Text = "You must enter a valid email address!";
                        }
                        else
                        {
                            int usernameCount = pxy.scalarUsername(user);
                            if(usernameCount > 0)
                            {
                                accountmsg.Text = "Username already exist!";
                            }
                            else
                            {
                                int emailCount = pxy.scalarEmail(user);
                                if (emailCount > 0)
                                {
                                    accountmsg.Text = "A " + AccountRoleddl.Text + " account with this email already exists";
                                }
                                else
                                {
                                    pxy.accountUpdate(user);
                                    AccountPanel.Visible = false;
                                    LoginPanel.Visible = true;
                                }
                            }
                        }
                    }
                }
                
            }
        }

        protected void forgetpassbtn_Click(object sender, EventArgs e)
        {
            LoginPanel.Visible = false;
            PasswordPanel.Visible = true;
        }

        protected void PasswordClosebtn_Click(object sender, EventArgs e)
        {
            PasswordPanel.Visible = false;
            LoginPanel.Visible = true;
        }

        protected void PasswordSendbtn_Click(object sender, EventArgs e)
        {
            EmailAddressAttribute em = new EmailAddressAttribute();
            if (!string.IsNullOrEmpty(PasswordEmailtxt.Text))
            {
                if (!em.IsValid(PasswordEmailtxt.Text))
                {
                    Passwordmsg.Text = "You must enter a valid email address";
                }
                else
                {
                    User user = new User();
                    user.Email = PasswordEmailtxt.Text;
                    user.Role = passwordroleddl.Text;
                    PIN = TwoFactorPinGenerator.RNG();
                    string to = PasswordEmailtxt.Text;
                    string from = "huydoan2306@gmail.com";
                    MailMessage message = new MailMessage(from, to);
                    string mailBody = "Here is your PIN number that you requested" + "<br>" + PIN;
                    message.Subject = "BlueFin PIN Code";
                    message.Body = mailBody;
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("huydoan2306@gmail.com", "qhmw coal qjpb hqqk");
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicCredential1;
                    int emailCount = pxy.scalarEmail(user);
                    if (emailCount == 0)
                    {
                        Passwordmsg.Text = "There's no account associated with this email";
                    }
                    else
                    {
                        
                        client.Send(message);
                        PasswordPanel.Visible = false;
                        PINPanel.Visible = true;
                        email = PasswordEmailtxt.Text;
                        role = passwordroleddl.Text;
                    }
                }
            }
            else
            {
                Passwordmsg.Text = "You must enter your email";
            }
        }

        protected void PinBackbtn_Click(object sender, EventArgs e)
        {
            PINPanel.Visible = false;
            PasswordPanel.Visible = true;
        }

        protected void PinSubmitbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Pintxt.Text))
            {
                Pinmsg.Text = "Please enter the PIN number in your email";
            }
            else
            {
                
                int input = int.Parse(Pintxt.Text);
                if(input == PIN)
                {
                    PINPanel.Visible = false;
                    SecurityQuestionPanel.Visible = true;
                    DataSet ds = new DataSet();
                    int questionNum = TwoFactorPinGenerator.questionGenerator();
                    string QuestionNum = "Q" + questionNum;
                    string AnswerNum = "A" + questionNum;
                    ds = pxy.getQuestion(email, role);
                    question = ds.Tables[0].Rows[0][QuestionNum].ToString();
                    answer = ds.Tables[0].Rows[0][AnswerNum].ToString().ToUpper();
                    SQPQuestionlbl.Text = question;

                }
                else
                {
                    Pinmsg.Text = "Incorrect PIN";
                }
            }
        }

        protected void SQPSubmitbtn_Click(object sender, EventArgs e)
        {
            string InputAnswer = SQPAnswertxt.Text.ToUpper();
            if (string.IsNullOrEmpty(SQPAnswertxt.Text)){
                SQPmsg.Text = "You Must Answer The Security Question To Proceed!";
            }
            else
            {
                if(InputAnswer != answer)
                {
                    SQPmsg.Text = "Incorrect Answer";
                }
                else
                {
                    SQPmsg.Text = "Please enter a new password for your account";
                    SQPQuestionlbl.Visible = false;
                    SQPAnswertxt.Text = string.Empty;
                    SQPSubmitbtn.Visible = false;
                    SQPChangePassbtn.Visible = true;
                    SQPAnswertxt.TextMode = TextBoxMode.Password;
                }
            }
        }

        protected void SQPBackbtn_Click(object sender, EventArgs e)
        {
            SecurityQuestionPanel.Visible = false;
            PasswordPanel.Visible = true;
        }

        protected void SQPChangePassbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SQPAnswertxt.Text))
            {
                SQPmsg.Text = "You must enter a new password";
            }
            else
            {
                string password = SQPAnswertxt.Text;
                pxy.updatePassword(email, role, password);
            }

        }
    }
}