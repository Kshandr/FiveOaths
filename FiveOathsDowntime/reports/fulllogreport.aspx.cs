using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FiveOathsLib.Logging;
using FiveOathsLib;

namespace FiveOathsDowntime.reports
{
    public partial class fulllogreport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedinuser"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            else
            {
                Player loggedInPlayer = Player.GetPlayerByID(Convert.ToInt32(Session["loggedinuser"]));

                if (!loggedInPlayer.IsAdmin)
                {
                    Response.Redirect("../switchboard.aspx");
                }
                else
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ClearHeaders();
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ContentType = "text/csv";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=LogFileReport.csv");
                    HttpContext.Current.Response.AddHeader("Pragma", "public");

                    string outstr = "";

                    outstr = "Date, ID, Action\r\n";

                    foreach (string s in Log.ReturnLogReport())
                    {
                        outstr = outstr + s + "\r\n";
                    }

                    HttpContext.Current.Response.Write(outstr);

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
        }
    }
}