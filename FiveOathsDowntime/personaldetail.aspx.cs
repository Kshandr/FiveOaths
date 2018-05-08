using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FiveOathsLib;
using FiveOathsLib.Utils;

namespace FiveOathsDowntime
{
    public partial class personaldetail : System.Web.UI.Page
    {
        bool isEdit;
        Player loggedInPlayer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedinuser"] == null)
            {
                // We won't go straight to login.aspx. Instead we'll assume that we're not logged in and we're
                // actually in registration.
                isEdit = false;
                lblModeMessage.Text = "Register New User";
                lblUsername.Visible = false;
            }
            else
            {
                isEdit = true;
                loggedInPlayer = Player.GetPlayerByID(Convert.ToInt32(Session["loggedinuser"]));
                lblModeMessage.Text = "Updating User Details";

                if (!this.IsPostBack)
                { 
                    
                    txtUsername.Text = loggedInPlayer.Username;
                    txtUsername.Visible = false;
                    lblUsername.Text = loggedInPlayer.Username;
                    lblUsername.Visible = true;
                    txtPassword.Text = "";
                    txtRetypePassword.Text = "";
                    txtRealname.Text = loggedInPlayer.RealName;
                    txtEmail.Text = loggedInPlayer.Email;
                    txtCarRegistration.Text = loggedInPlayer.CarRegistration;
                    txtEmergencyContactName.Text = loggedInPlayer.EmergencyContactName;
                    txtEmergencyContactNumber.Text = loggedInPlayer.EmergencyContactNumber;
                    txtMedicalDetails.Text = loggedInPlayer.MedicalDetails;
                }
            }
        }

        protected void cmdSubmitChanges_Click(object sender, EventArgs e)
        {
            string errMsg = validateUserform();

            if (errMsg == "")
            {
                if (isEdit)
                {
                    loggedInPlayer.Password = txtPassword.Text;
                    loggedInPlayer.RealName = txtRealname.Text;
                    loggedInPlayer.Email = txtEmail.Text;
                    loggedInPlayer.CarRegistration = txtCarRegistration.Text;
                    loggedInPlayer.EmergencyContactName = txtEmergencyContactName.Text;
                    loggedInPlayer.EmergencyContactNumber = txtEmergencyContactNumber.Text;
                    loggedInPlayer.MedicalDetails = txtMedicalDetails.Text;
                    loggedInPlayer.SaveToDB();

                    Response.Redirect("switchboard.aspx");
                }
                else
                {
                    Player myPlayer = new Player(txtUsername.Text,
                                                    txtPassword.Text,
                                                    txtEmail.Text,
                                                    txtRealname.Text,
                                                    txtEmergencyContactName.Text,
                                                    txtEmergencyContactNumber.Text,
                                                    txtMedicalDetails.Text,
                                                    txtCarRegistration.Text);

                    cmdSubmitChanges.Text = "Please Wait...";
                    cmdSubmitChanges.Enabled = false;

                    Email.SendMail("Five Oaths LRP", txtEmail.Text, "Five Oaths Registration", "Congratulations! You have registered your account with name " +
                        txtUsername.Text + " at our web site at INSERT THIS WHEN THERE'S A PERSISTENT WEB ADDRESS.");

                    // TODO - It would probably be more user-friendly to have a message here.
                    Response.Redirect("login.aspx");
                }
            }
            else
            {
                lblErrorMessage.Text = errMsg;
                lblErrorMessage.Visible = true;
            }
        }

        private string validateUserform()
        {
            string errMsg = "";

            if (txtUsername.Text.Length == 0 ||
                    txtPassword.Text.Length == 0 ||
                    txtRetypePassword.Text.Length == 0 ||
                    txtEmail.Text.Length == 0)
            {
                errMsg = "Please fill in all the required fields!";
            }
            else if(txtPassword.Text != txtRetypePassword.Text)
            {
                errMsg = "Passwords do not match!";
            }

            return errMsg;
        }

        protected void cmdBack_Click(object sender, EventArgs e)
        {
            if(isEdit)
            {
                Response.Redirect("switchboard.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}