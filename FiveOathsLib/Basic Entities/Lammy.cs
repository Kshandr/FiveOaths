using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveOathsLib.Data;

namespace FiveOathsLib
{
    public class Lammy
    {
        private int _lammyid;
        private string _name;
        private string _description;
        private string _attunetime;
        private string _type;
        private string _validuntil;

        #region Properties
        public int LammyID
        {
            get { return _lammyid; }
            set { _lammyid = value; }
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

        public string AttuneTime
        {
            get { return _attunetime; }
            set { _attunetime = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string ValidUntil
        {
            get { return _validuntil; }
            set { _validuntil = value; }
        }
        #endregion

        #region Database Comms
        public static Lammy GetLammyByID(int id)
        {
            lammy myLammy = lammy.All().FirstOrDefault(x => x.id == id);

            return MakeLammyFromDBLammy(myLammy);
        }

        public List<Lammy> GetAllLammies()
        {
            List<Lammy> allLammies = new List<Lammy>();

            foreach(lammy myLammy in lammy.All())
            {
                allLammies.Add(MakeLammyFromDBLammy(myLammy));
            }

            return allLammies;
        }

        public void SaveToDB()
        {
            lammy myLammy = lammy.All().FirstOrDefault(x => x.id == _lammyid);

            myLammy.attunetime = _attunetime;
            myLammy.description = _description;
            myLammy.name = _name;
            myLammy.type = _type;
            myLammy.validuntil = _validuntil;

            myLammy.Save();
        }

        #endregion

        #region Conversion
        private static Lammy MakeLammyFromDBLammy(lammy inLammy)
        {
            Lammy myLammy = new Lammy();

            myLammy.LammyID = inLammy.id;
            myLammy.AttuneTime = inLammy.attunetime;
            myLammy.Description = inLammy.description;
            myLammy.Name = inLammy.name;
            myLammy.Type = inLammy.type;
            myLammy.ValidUntil = inLammy.validuntil;

            return myLammy;
        }
        #endregion

    }
}
