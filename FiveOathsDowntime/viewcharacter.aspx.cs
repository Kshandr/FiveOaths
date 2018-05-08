using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FiveOathsLib;

namespace FiveOathsDowntime
{
    public partial class viewcharacter : System.Web.UI.Page
    {
        const int TABLE_COLUMN_WIDTH = 2;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedinuser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Player loggedInPlayer = Player.GetPlayerByID(Convert.ToInt32(Session["loggedinuser"]));

                Character myCharacter = Character.GetActiveCharacterByPlayerID(loggedInPlayer.PlayerID);

                lblName.Text = myCharacter.Name;
                lblRace.Text = myCharacter.Race;
                lblNativeRealm.Text = myCharacter.NativeRealm;

                lblBody.Text = (myCharacter.Body + myCharacter.Feats.CalculateBodyFromFeats()).ToString();
                lblMana.Text = (myCharacter.Mana + myCharacter.Feats.CalculateManaFromFeats()).ToString();
                lblArmour.Text = (myCharacter.Armour + myCharacter.Feats.CalculateArmourFromFeats()).ToString();

                lblCoins.Text = myCharacter.Coins.ToString();
                lblFire.Text = myCharacter.FireCrystals.ToString();
                lblWater.Text = myCharacter.WaterCrystals.ToString();
                lblEarth.Text = myCharacter.EarthCrystals.ToString();
                lblAir.Text = myCharacter.AirCrystals.ToString();
                lblBlended.Text = myCharacter.BlendedCrystals.ToString();
                lblVoid.Text = myCharacter.VoidCrystals.ToString();

                int pos = 0;
                string outstr = "<table><tr>";

                foreach (Feat myFeat in myCharacter.Feats.List)
                {
                    pos++;
                    outstr = outstr + "<td width=\"" + ((int)(100/TABLE_COLUMN_WIDTH)).ToString() + "%\">* " + myFeat.Name + "</td>";

                    if ((pos % TABLE_COLUMN_WIDTH) == 0)
                    {
                        outstr = outstr + "</tr><tr>";
                    }
                }

                outstr = outstr + "</tr></table>";
                lblFeatTable.Text = outstr;

                pos = 0;
                outstr = "<table><tr>";

                foreach(Lammy myLammy in myCharacter.Lammies.List)
                {
                    pos++;
                    outstr = outstr + "<td width=\"" + ((int)(100/TABLE_COLUMN_WIDTH)).ToString() + "%\">" + myLammy.Name + "</td>";

                    if((pos % TABLE_COLUMN_WIDTH) ==0)
                    {
                        outstr = outstr + "</tr><tr>";
                    }
                }

                outstr = outstr + "</tr></table>";
                lblLammyTable.Text = outstr;
            }
        }

        protected void cmdBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("switchboard.aspx");
        }
    }
}