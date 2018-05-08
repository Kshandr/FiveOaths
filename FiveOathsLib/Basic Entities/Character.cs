using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveOathsLib;
using FiveOathsLib.Data;

namespace FiveOathsLib
{
    public class Character
    {
        private int _id;
        private bool _active;
        private string _name;
        private string _race;
        private int _body;
        private int _armour;
        private int _mana;
        private int _earthcrystals;
        private int _watercrystals;
        private int _firecrystals;
        private int _aircrystals;
        private int _blendedcrystals;
        private int _voidcrystals;
        private int _coins;
        private string _nativerealm;

        // These internal properties are calculated rather than a direct analog of the db
        private FeatList _feats;
        private LammyList _lammies;

        #region Properties
        public int PlayerID
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool IsActive
        {
            get { return _active; }
            set { _active = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public int Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public int Mana
        {
            get { return _mana; }
            set { _mana = value; }
        }

        public int Armour
        {
            get { return _armour; }
            set { _armour = value; }
        }

        public int EarthCrystals
        {
            get { return _earthcrystals; }
            set { _earthcrystals = value; }
        }

        public int WaterCrystals
        {
            get { return _watercrystals; }
            set { _watercrystals = value; }
        }

        public int FireCrystals
        {
            get { return _firecrystals; }
            set { _firecrystals = value; }
        }

        public int AirCrystals
        {
            get { return _aircrystals; }
            set { _aircrystals = value; }
        }

        public int BlendedCrystals
        {
            get { return _blendedcrystals; }
            set { _blendedcrystals = value; }
        }

        public int VoidCrystals
        {
            get { return _voidcrystals; }
            set { _voidcrystals = value; }
        }

        public int Coins
        {
            get { return _coins; }
            set { _coins = value; }
        }

        public string NativeRealm
        {
            get { return _nativerealm; }
            set { _nativerealm = value; }
        }

        public LammyList Lammies
        {
            get { return _lammies; }
        }

        public FeatList Feats
        {
            get { return _feats; }
        }
        #endregion

        #region Constructor
        public Character()
        {
            _lammies = new LammyList();
            _feats = new FeatList();
        }
        #endregion

        #region Database Comms
        public static Character GetCharacterByID(int characterid)
        {
            character dbCharacter = character.All().FirstOrDefault(x => x.id == characterid);

            if (dbCharacter != null)
            {
                Character myCharacter = MakeCharacterFromDBCharacter(dbCharacter);

                myCharacter.Feats.SetFeatList(FeatList.RetrieveFeatsForCharacter(characterid));
                myCharacter.Lammies.SetLammyList(LammyList.RetrieveLammiesForCharacterID(characterid));

                return myCharacter;
            }
            else
            {
                return null;
            }
        }

        public static Character GetActiveCharacterByPlayerID(int playerid)
        {
            character dbCharacter = character.All().FirstOrDefault(x => x.playerid == playerid);

            if (dbCharacter != null)
            {
                return GetCharacterByID(dbCharacter.id);
            }
            else
            {
                return null;
            }
        }

        public static List<Character> GetAllCharactersBrief()
        {
            // IMPORTANT NOTE - to save from what could be a pretty hefty operation, this returns a list of all characters,
            // but without the recipes/lammies/feats sub-lists filled in. This "brief" list can be used for character list
            // reports, or character counts etc.

            List<Character> myCharacters = new List<Character>();

            foreach(character myCharacter in character.All().ToList())
            {
                myCharacters.Add(MakeCharacterFromDBCharacter(myCharacter));
            }

            return myCharacters;
        }
        #endregion

        #region Conversion
        private static Character MakeCharacterFromDBCharacter(character inCharacter)
        {
            Character myCharacter = new Character();

            myCharacter.AirCrystals = inCharacter.aircrystals;
            myCharacter.Armour = inCharacter.armour;
            myCharacter.BlendedCrystals = inCharacter.blendedcrystals;
            myCharacter.Body = inCharacter.body;
            myCharacter.Coins = inCharacter.coins;
            myCharacter.EarthCrystals = inCharacter.earthcrystals;
            myCharacter.FireCrystals = inCharacter.firecrystals;
            myCharacter.IsActive = inCharacter.active;
            myCharacter.Mana = inCharacter.mana;
            myCharacter.Name = inCharacter.name;
            myCharacter.NativeRealm = inCharacter.nativerealm;
            myCharacter.PlayerID = inCharacter.playerid;
            myCharacter.Race = inCharacter.race;
            myCharacter.VoidCrystals = inCharacter.voidcrystals;
            myCharacter.WaterCrystals = inCharacter.watercrystals;

            return myCharacter;
        }
        #endregion
    }
}
