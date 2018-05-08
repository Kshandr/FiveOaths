using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveOathsLib.Data;

namespace FiveOathsLib
{
    public class FeatList
    {
        private List<Feat> _feats;
        private int _parentcharacterid;

        #region Properties
        public List<Feat> List
        {
            get { return _feats; }
        }

        public int ParentCharacterID
        {
            get { return _parentcharacterid; }
            set { _parentcharacterid = value; }
        }
        #endregion

        #region Constructor
        public FeatList()
        {
            _feats = new List<Feat>();
            _parentcharacterid = -1;
        }
        #endregion

        #region Database Comms
        public static FeatList RetrieveFeatsForCharacter(int characterid)
        {
            FeatList myFeats = new FeatList();

            myFeats.ParentCharacterID = characterid;

            foreach(characterfeat myCharacterFeat in characterfeat.All().Where(x=>x.characterid == characterid))
            {
                myFeats.List.Add(Feat.GetFeatByID(myCharacterFeat.featid));
            }

            return myFeats;
        }

        #endregion

        public int CalculateBodyFromFeats()
        {
            int b = 0;

            foreach(Feat myFeat in _feats)
            {
                b = b + myFeat.GrantsBody;
            }

            return b;
        }

        public int CalculateArmourFromFeats()
        {
            int a = 0;

            foreach(Feat myFeat in _feats)
            {
                a = a + myFeat.GrantsArmour;
            }

            return a;
        }

        public int CalculateManaFromFeats()
        {
            int m = 0;

            foreach(Feat myFeat in _feats)
            {
                m = m + myFeat.GrantsMana;
            }

            return m;
        }

        public void SetFeatList(FeatList myList)
        {
            _feats = myList.List;
        }

        public void Add(Feat myFeat)
        {
            if (_parentcharacterid == -1)
            {
                throw new Exception("No Parent Character ID set");
            }
            else
            {
                _feats.Add(myFeat);

                characterfeat myLink = new characterfeat();
                myLink.featid = myFeat.FeatID;
                myLink.characterid = _parentcharacterid;
                myLink.Save();
            }
        }
    }
}
