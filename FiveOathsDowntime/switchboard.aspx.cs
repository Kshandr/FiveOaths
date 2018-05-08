using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FiveOathsLib;

namespace FiveOathsDowntime
{
    public partial class switchboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["loggedinuser"]==null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Player loggedInPlayer = Player.GetPlayerByID(Convert.ToInt32(Session["loggedinuser"]));
                lblRealname.Text = loggedInPlayer.RealName;

                if(loggedInPlayer.IsAdmin)
                {
                    pnlAdminPanel.Visible = true;
                }

                Character myCharacter = Character.GetActiveCharacterByPlayerID(loggedInPlayer.PlayerID);
                if(myCharacter==null)
                {
                    cmdViewCharacter.Enabled = false;
                }
            }
        }

        protected void cmdLogout_Click(object sender, EventArgs e)
        {
            Session["loggedinuser"] = null;
            Response.Redirect("login.aspx");
        }

        protected void cmdViewCharacter_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewcharacter.aspx");
        }
    }
}