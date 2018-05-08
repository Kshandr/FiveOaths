using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FiveOathsLib;
using FiveOathsLib.Utils;
using FiveOathsLib.Logging;

namespace FiveOathsDowntime
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        private static Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPassword myFP = ForgotPassword.GetByEmail(txtInputEmail.Text);

            if(myFP!=null)
            {
                if((DateTime.Now - myFP.DateRequested).Hours>0)
                {
                    // This forgotpassword link is outdated and should be deleted. Reset to null so it's treated
                    // as a new record.
                    myFP.Delete();
                    myFP = null;
                }
            }

            if(myFP==null)
            {
                Player myPlayer = Player.GetAllPlayers().FirstOrDefault(x => x.Email == txtInputEmail.Text);

                if (myPlayer != null)
                {
                    cmdForgotPassword.Text = "Please Wait...";
                    cmdForgotPassword.Enabled = false;

                    myFP = new ForgotPassword(txtInputEmail.Text);
                    //Generate a new password here
                    string newPassword = makeRandomString(10);
                    myPlayer.Password = newPassword;
                    myPlayer.SaveToDB();

                    Email.SendMail("Five Oaths LRP", txtInputEmail.Text, "Your password has been reset", "We have reset your password to " + newPassword + 
                        " please login with this password");

                    Log.Write(myPlayer.PlayerID, "Reset password");

                    lblErrorMessage.Text = "An email has been sent to you with your new password";
                    lblErrorMessage.Visible = true;
                    cmdForgotPassword.Visible = false;
                }
                else
                {
                    lblErrorMessage.Text = "No account exists with that email address";
                    lblErrorMessage.Visible = true;
                }
            }
            else
            {
                lblErrorMessage.Text = "An existing forgot password link exists for this email. Please wait and try again";
                lblErrorMessage.Visible = true;
            }
        }

        private static string makeRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected void cmdBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}