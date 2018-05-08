using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveOathsLib.Data;

namespace FiveOathsLib
{
    public class ForgotPassword
    {
        int _forgotpasswordid;
        string _email;
        string _guid;
        DateTime _daterequested;

        #region Properties
        public int ForgotPasswordID
        {
            get { return _forgotpasswordid; }
            set { _forgotpasswordid = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Token
        {
            get { return _guid; }
            set { _guid = value; }
        }

        public DateTime DateRequested
        {
            get { return _daterequested;}
            set { _daterequested = value; }
        }
        #endregion

        #region Constructor
        public ForgotPassword(string email)
        {
            _email = email;
            _guid = new Guid().ToString();
            _daterequested = DateTime.Now;

            this.SaveToDB();
        }

        private ForgotPassword()
        {

        }
        #endregion

        #region Database Comms
        public void SaveToDB()
        {
            forgotpassword myFP = new forgotpassword();
            myFP.email = _email;
            myFP.tokenguid = _guid;
            myFP.daterequested = _daterequested;
            myFP.Save();
            _forgotpasswordid = myFP.id;
        }

        public static ForgotPassword GetByEmail(string email)
        {
            forgotpassword myFP = forgotpassword.All().FirstOrDefault(x => x.email == email);

            if(myFP!=null)
            { 
                return makeForgotPasswordFromDBForgotPassword(myFP);
            }
            else
            {
                return null;
            }
        }

        public void Delete()
        {
            forgotpassword myFP = forgotpassword.All().FirstOrDefault(x => x.id == _forgotpasswordid);
            myFP.Delete();
        }
        #endregion

        #region Conversion
        private static ForgotPassword makeForgotPasswordFromDBForgotPassword(forgotpassword inFP)
        {
            ForgotPassword outFP = new ForgotPassword();

            outFP.Email = inFP.email;
            outFP.Token = inFP.tokenguid;
            outFP.ForgotPasswordID = inFP.id;

            return outFP;
        }
        #endregion
    }
}
