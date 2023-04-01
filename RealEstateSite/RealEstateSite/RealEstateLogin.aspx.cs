﻿using System;
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

namespace RealEstateSite
{
    public partial class RealEstateLogin : System.Web.UI.Page
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        public static int PIN { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            loginmsg.Visible = false;
            if(!string.IsNullOrEmpty(usernametxt.Text) && !string.IsNullOrEmpty(passwordtxt.Text))
            {
                User user = new User();
                user.Username = usernametxt.Text;
                user.Password = passwordtxt.Text;
                int userCount = pxy.scalarLogin(user);
                if(userCount > 0)
                {
                    loginmsg.Visible = true;
                    loginmsg.Text = "Login Success";
                }
                else
                {
                    loginmsg.Visible = true;
                    loginmsg.Text = "User Does Not Exist";
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
            user.Password = AccountPasswordtxt.Text;
            user.Phone = AccountPhonetxt.Text;
            user.Q1 = Q1lbl.Text;
            user.Q2 = Q2lbl.Text;
            user.Q3 = Q3lbl.Text;
            user.A1 = A1txt.Text;
            user.A2 = A2txt.Text;
            user.A3 = A3txt.Text;
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
                    Pinmsg.Text = "match";
                }
                else
                {
                    Pinmsg.Text = "not match";
                }
            }
        }
    }
}