using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveOathsLib.Data;

namespace FiveOathsLib
{
    public class Feat
    {
        private int _id;
        private string _name;   
        private string _description;
        private string _prerequisites;
        private int _maxtimes;
        private int _grantsbody;
        private int _grantsmana;
        private int _grantsarmour;
        private string _prerequisiterace;

        #region Properties
        public int FeatID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string PreRequisites
        {
            get { return _prerequisites; }
            set { _prerequisites = value; }
        }

        public int MaxTimes
        {
            get { return _maxtimes; }
            set { _maxtimes = value; }
        }

        public int GrantsBody
        {
            get { return _grantsbody; }
            set { _grantsbody = value; }
        }

        public int GrantsMana
        {
            get { return _grantsmana; }
            set { _grantsmana = value; }
        }

        public int GrantsArmour
        {
            get { return _grantsarmour; }
            set { _grantsarmour = value; }
        }

        public string PrerequisiteRace
        {
            get { return _prerequisiterace; }
            set { _prerequisiterace = value; }
        }
        #endregion

        #region Database Comms
        public static Feat GetFeatByID(int id)
        {
            feat myFeat = feat.All().FirstOrDefault(x => x.id == id);

            return MakeFeatFromDBFeat(myFeat);
        }

        public static List<Feat> GetAllFeats()
        {
            List<Feat> allFeats = new List<Feat>();

            foreach(feat myFeat in feat.All().ToList())
            {
                allFeats.Add(MakeFeatFromDBFeat(myFeat));
            }

            return allFeats;
        }

        public void SaveToDB()
        {
            feat myFeat = feat.All().FirstOrDefault(x => x.id == _id);

            myFeat.description = _description;
            myFeat.grantsarmour = _grantsarmour;
            myFeat.grantsbody = _grantsbody;
            myFeat.grantsmana = _grantsmana;
            myFeat.maxtimes = _maxtimes;
            myFeat.name = _name;
            myFeat.prerequisiterace = _prerequisiterace;
            myFeat.prerequisites = _prerequisites;

            myFeat.Save();
        }
        #endregion

        #region Conversion
        private static Feat MakeFeatFromDBFeat(feat inFeat)
        {
            Feat myFeat = new Feat();

            myFeat.Description = inFeat.description;
            myFeat.FeatID = inFeat.id;
            myFeat.GrantsArmour = inFeat.grantsarmour;
            myFeat.GrantsBody = inFeat.grantsbody;
            myFeat.GrantsMana = inFeat.grantsmana;
            myFeat.MaxTimes = inFeat.maxtimes;
            myFeat.Name = inFeat.name;
            myFeat.PrerequisiteRace = inFeat.prerequisiterace;
            myFeat.PreRequisites = inFeat.prerequisites;

            return myFeat;
        }
        #endregion
    }
}
