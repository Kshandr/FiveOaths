using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveOathsLib.Data;

namespace FiveOathsLib
{
    public class Player
    {
        private int _playerid;
        private string _realname;
        private string _email;
        private string _username;
        private string _password;
        private bool _isadmin;
        private string _emergencycontactname;
        private string _emergencycontactnumber;
        private string _medicaldetail;
        private string _carregistration;

        #region Properties
        public int PlayerID
        {
            get { return _playerid; }
            set { _playerid = value; }
        }

        public string RealName
        {
            get { return _realname; }
            set { _realname = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string EmergencyContactName
        {
            get { return _emergencycontactname; }
            set { _emergencycontactname = value; }
        }

        public string EmergencyContactNumber
        {
            get { return _emergencycontactnumber; }
            set { _emergencycontactnumber = value; }
        }

        public bool IsAdmin
        {
            get { return _isadmin; }
            set { _isadmin = value; }
        }

        public string MedicalDetails
        {
            get { return _medicaldetail; }
            set { _medicaldetail = value; }
        }

        public string CarRegistration
        {
            get { return _carregistration; }
            set { _carregistration = value; }
        }
        #endregion

        #region Constructor
        public Player(string username, string password, string email, string realname, string emergencycontactname, string emergencycontactnumber,
                string medicaldetail, string carregistration)
        {
            player myPlayer = new player();
            myPlayer.username = username;
            myPlayer.password = password;
            myPlayer.email = email;
            myPlayer.realname = realname;
            myPlayer.emergencycontactname = emergencycontactname;
            myPlayer.emergencycontactnumber = emergencycontactnumber;
            myPlayer.medicaldetail = medicaldetail;
            myPlayer.carregistration = carregistration;

            myPlayer.Save();
        }

        public Player()
        {

        }

        #endregion

        #region Database Comms
        public static Player GetPlayerByID(int id)
        {
            player myPlayer = player.All().FirstOrDefault(x => x.id == id);

            return makePlayerFromDBPlayer(myPlayer);
        }

        public static Player GetPlayerByUsernameAndPassword(string username, string password)
        {
            player myPlayer = player.All().FirstOrDefault(x => x.username == username && x.password == password);

            if(myPlayer != null)
            {
                return makePlayerFromDBPlayer(myPlayer);
            }
            else
            {
                return null;
            }
        }

        public static List<Player> GetAllPlayers()
        {
            List<Player> myPlayers = new List<Player>();

            foreach(player myPlayer in player.All().ToList())
            {
                myPlayers.Add(makePlayerFromDBPlayer(myPlayer));
            }

            return myPlayers;
        }

        public void SaveToDB()
        {
            player myPlayer = player.All().FirstOrDefault(x => x.id == _playerid);

            myPlayer.SetIsNew(false); // Is this line actually required? Had it in as debug for creating new rows.
            myPlayer.id = this.PlayerID; // Don't think this line is needed either. Could cause db corruption.

            myPlayer.carregistration = this.CarRegistration;
            myPlayer.email = this.Email;
            myPlayer.emergencycontactname = this.EmergencyContactName;
            myPlayer.emergencycontactnumber = this.EmergencyContactNumber;
            myPlayer.medicaldetail = this.MedicalDetails;
            myPlayer.password = this.Password;
            myPlayer.realname = this.RealName;

            myPlayer.Save();
        }

        #endregion

        #region Conversion
        private static Player makePlayerFromDBPlayer(player inPlayer)
        {
            Player myPlayer = new Player();
            myPlayer.PlayerID = inPlayer.id;
            myPlayer.RealName = inPlayer.realname.Trim();
            myPlayer.Email    = inPlayer.email.Trim();
            myPlayer.Username = inPlayer.username.Trim();
            myPlayer.Password = inPlayer.password.Trim();
            myPlayer.IsAdmin = inPlayer.isadmin;
            myPlayer.CarRegistration        = inPlayer.carregistration.Trim();
            myPlayer.EmergencyContactName   = inPlayer.emergencycontactname.Trim();
            myPlayer.EmergencyContactNumber = inPlayer.emergencycontactnumber.Trim();
            myPlayer.MedicalDetails         = inPlayer.medicaldetail.Trim();

            return myPlayer;
        }

        #endregion
    }
}
