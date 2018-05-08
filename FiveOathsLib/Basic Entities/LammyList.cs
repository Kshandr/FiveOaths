using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveOathsLib.Data;

namespace FiveOathsLib
{
    public class LammyList
    {
        private List<Lammy> _lammies;
        private int _parentcharacterid;

        #region Properties
        public List<Lammy> List
        {
            get { return _lammies; }
        }

        public int ParentCharacterID
        {
            get { return _parentcharacterid; }
            set { _parentcharacterid = value; }
        }
        #endregion

        #region Constructor
        public LammyList()
        {
            _lammies = new List<Lammy>();
            _parentcharacterid = -1;
        }
        #endregion

        #region Database Comms
        public static LammyList RetrieveLammiesForCharacterID(int characterid)
        {
            LammyList myLammyList = new LammyList();

            myLammyList.ParentCharacterID = characterid;

            foreach(characterlammy lammyLink in characterlammy.All().Where(x=>x.characterid == characterid))
            {
                myLammyList.List.Add(Lammy.GetLammyByID(lammyLink.lammyid));
            }

            return myLammyList;
        }
        #endregion

        public void SetLammyList(LammyList myList)
        {
            _lammies = myList.List;
        }
    }
}
