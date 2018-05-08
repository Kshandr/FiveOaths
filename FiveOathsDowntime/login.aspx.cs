using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FiveOathsLib;
using FiveOathsLib.Logging;

namespace FiveOathsDowntime
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            Player myPlayer = Player.GetPlayerByUsernameAndPassword(txtUsername.Text, txtPassword.Text);

            if(myPlayer!=null)
            {
                Log.Write(myPlayer.PlayerID, "Successful Login");
                Session["loggedinuser"] = myPlayer.PlayerID;
                Response.Redirect("switchboard.aspx");
            }
            else
            {
                Log.Write(-1, "Failed login - " + txtUsername.Text + "/" + txtPassword.Text);
                lblErrorMsg.Text = "Invalid username or password";
                lblErrorMsg.Visible = true;
            }
        }

        protected void cmdForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgotpassword.aspx");
        }
    }
}