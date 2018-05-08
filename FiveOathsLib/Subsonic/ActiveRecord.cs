


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace FiveOathsLib.Data
{
    
    
    /// <summary>
    /// A class which represents the players table in the fiveoaths_dev Database.
    /// </summary>
    public partial class player: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<player> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<player>(new FiveOathsLib.Data.fiveoaths_devDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<player> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(player item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                player item=new player();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<player> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        FiveOathsLib.Data.fiveoaths_devDB _db;
        public player(string connectionString, string providerName) {

            _db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                player.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<player>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public player(){
             _db=new FiveOathsLib.Data.fiveoaths_devDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public player(Expression<Func<player, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<player> GetRepo(string connectionString, string providerName){
            FiveOathsLib.Data.fiveoaths_devDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new FiveOathsLib.Data.fiveoaths_devDB();
            }else{
                db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            }
            IRepository<player> _repo;
            
            if(db.TestMode){
                player.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<player>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<player> GetRepo(){
            return GetRepo("","");
        }
        
        public static player SingleOrDefault(Expression<Func<player, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            player single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static player SingleOrDefault(Expression<Func<player, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            player single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<player, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<player, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<player> Find(Expression<Func<player, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<player> Find(Expression<Func<player, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<player> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<player> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<player> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<player> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<player> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<player> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id";
        }

        public object KeyValue()
        {
            return this.id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.realname.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(player)){
                player compare=(player)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id;
        }
        
        public string DescriptorValue()
        {
                            return this.realname.ToString();
                    }

        public string DescriptorColumn() {
            return "realname";
        }
        public static string GetKeyColumn()
        {
            return "id";
        }        
        public static string GetDescriptorColumn()
        {
            return "realname";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if(_id!=value){
                    _id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _realname;
        public string realname
        {
            get { return _realname; }
            set
            {
                if(_realname!=value){
                    _realname=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="realname");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _email;
        public string email
        {
            get { return _email; }
            set
            {
                if(_email!=value){
                    _email=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="email");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _username;
        public string username
        {
            get { return _username; }
            set
            {
                if(_username!=value){
                    _username=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="username");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _password;
        public string password
        {
            get { return _password; }
            set
            {
                if(_password!=value){
                    _password=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="password");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _medicaldetail;
        public string medicaldetail
        {
            get { return _medicaldetail; }
            set
            {
                if(_medicaldetail!=value){
                    _medicaldetail=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="medicaldetail");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _isadmin;
        public bool isadmin
        {
            get { return _isadmin; }
            set
            {
                if(_isadmin!=value){
                    _isadmin=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isadmin");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _emergencycontactname;
        public string emergencycontactname
        {
            get { return _emergencycontactname; }
            set
            {
                if(_emergencycontactname!=value){
                    _emergencycontactname=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="emergencycontactname");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _emergencycontactnumber;
        public string emergencycontactnumber
        {
            get { return _emergencycontactnumber; }
            set
            {
                if(_emergencycontactnumber!=value){
                    _emergencycontactnumber=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="emergencycontactnumber");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _carregistration;
        public string carregistration
        {
            get { return _carregistration; }
            set
            {
                if(_carregistration!=value){
                    _carregistration=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="carregistration");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<player, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the characters table in the fiveoaths_dev Database.
    /// </summary>
    public partial class character: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<character> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<character>(new FiveOathsLib.Data.fiveoaths_devDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<character> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(character item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                character item=new character();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<character> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        FiveOathsLib.Data.fiveoaths_devDB _db;
        public character(string connectionString, string providerName) {

            _db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                character.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<character>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public character(){
             _db=new FiveOathsLib.Data.fiveoaths_devDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public character(Expression<Func<character, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<character> GetRepo(string connectionString, string providerName){
            FiveOathsLib.Data.fiveoaths_devDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new FiveOathsLib.Data.fiveoaths_devDB();
            }else{
                db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            }
            IRepository<character> _repo;
            
            if(db.TestMode){
                character.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<character>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<character> GetRepo(){
            return GetRepo("","");
        }
        
        public static character SingleOrDefault(Expression<Func<character, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            character single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static character SingleOrDefault(Expression<Func<character, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            character single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<character, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<character, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<character> Find(Expression<Func<character, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<character> Find(Expression<Func<character, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<character> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<character> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<character> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<character> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<character> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<character> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id";
        }

        public object KeyValue()
        {
            return this.id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(character)){
                character compare=(character)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id;
        }
        
        public string DescriptorValue()
        {
                            return this.name.ToString();
                    }

        public string DescriptorColumn() {
            return "name";
        }
        public static string GetKeyColumn()
        {
            return "id";
        }        
        public static string GetDescriptorColumn()
        {
            return "name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if(_id!=value){
                    _id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _playerid;
        public int playerid
        {
            get { return _playerid; }
            set
            {
                if(_playerid!=value){
                    _playerid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="playerid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                if(_active!=value){
                    _active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _name;
        public string name
        {
            get { return _name; }
            set
            {
                if(_name!=value){
                    _name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _race;
        public string race
        {
            get { return _race; }
            set
            {
                if(_race!=value){
                    _race=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="race");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _body;
        public int body
        {
            get { return _body; }
            set
            {
                if(_body!=value){
                    _body=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="body");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _armour;
        public int armour
        {
            get { return _armour; }
            set
            {
                if(_armour!=value){
                    _armour=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="armour");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _mana;
        public int mana
        {
            get { return _mana; }
            set
            {
                if(_mana!=value){
                    _mana=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="mana");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _earthcrystals;
        public int earthcrystals
        {
            get { return _earthcrystals; }
            set
            {
                if(_earthcrystals!=value){
                    _earthcrystals=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="earthcrystals");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _aircrystals;
        public int aircrystals
        {
            get { return _aircrystals; }
            set
            {
                if(_aircrystals!=value){
                    _aircrystals=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="aircrystals");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _firecrystals;
        public int firecrystals
        {
            get { return _firecrystals; }
            set
            {
                if(_firecrystals!=value){
                    _firecrystals=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="firecrystals");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _watercrystals;
        public int watercrystals
        {
            get { return _watercrystals; }
            set
            {
                if(_watercrystals!=value){
                    _watercrystals=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="watercrystals");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _blendedcrystals;
        public int blendedcrystals
        {
            get { return _blendedcrystals; }
            set
            {
                if(_blendedcrystals!=value){
                    _blendedcrystals=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="blendedcrystals");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _voidcrystals;
        public int voidcrystals
        {
            get { return _voidcrystals; }
            set
            {
                if(_voidcrystals!=value){
                    _voidcrystals=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="voidcrystals");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _coins;
        public int coins
        {
            get { return _coins; }
            set
            {
                if(_coins!=value){
                    _coins=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="coins");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _nativerealm;
        public string nativerealm
        {
            get { return _nativerealm; }
            set
            {
                if(_nativerealm!=value){
                    _nativerealm=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="nativerealm");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<character, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the feats table in the fiveoaths_dev Database.
    /// </summary>
    public partial class feat: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<feat> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<feat>(new FiveOathsLib.Data.fiveoaths_devDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<feat> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(feat item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                feat item=new feat();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<feat> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        FiveOathsLib.Data.fiveoaths_devDB _db;
        public feat(string connectionString, string providerName) {

            _db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                feat.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<feat>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public feat(){
             _db=new FiveOathsLib.Data.fiveoaths_devDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public feat(Expression<Func<feat, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<feat> GetRepo(string connectionString, string providerName){
            FiveOathsLib.Data.fiveoaths_devDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new FiveOathsLib.Data.fiveoaths_devDB();
            }else{
                db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            }
            IRepository<feat> _repo;
            
            if(db.TestMode){
                feat.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<feat>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<feat> GetRepo(){
            return GetRepo("","");
        }
        
        public static feat SingleOrDefault(Expression<Func<feat, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            feat single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static feat SingleOrDefault(Expression<Func<feat, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            feat single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<feat, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<feat, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<feat> Find(Expression<Func<feat, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<feat> Find(Expression<Func<feat, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<feat> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<feat> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<feat> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<feat> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<feat> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<feat> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id";
        }

        public object KeyValue()
        {
            return this.id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(feat)){
                feat compare=(feat)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id;
        }
        
        public string DescriptorValue()
        {
                            return this.name.ToString();
                    }

        public string DescriptorColumn() {
            return "name";
        }
        public static string GetKeyColumn()
        {
            return "id";
        }        
        public static string GetDescriptorColumn()
        {
            return "name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if(_id!=value){
                    _id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _name;
        public string name
        {
            get { return _name; }
            set
            {
                if(_name!=value){
                    _name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _description;
        public string description
        {
            get { return _description; }
            set
            {
                if(_description!=value){
                    _description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _prerequisites;
        public string prerequisites
        {
            get { return _prerequisites; }
            set
            {
                if(_prerequisites!=value){
                    _prerequisites=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="prerequisites");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _maxtimes;
        public int maxtimes
        {
            get { return _maxtimes; }
            set
            {
                if(_maxtimes!=value){
                    _maxtimes=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="maxtimes");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _grantsmana;
        public int grantsmana
        {
            get { return _grantsmana; }
            set
            {
                if(_grantsmana!=value){
                    _grantsmana=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="grantsmana");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _grantsbody;
        public int grantsbody
        {
            get { return _grantsbody; }
            set
            {
                if(_grantsbody!=value){
                    _grantsbody=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="grantsbody");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _grantsarmour;
        public int grantsarmour
        {
            get { return _grantsarmour; }
            set
            {
                if(_grantsarmour!=value){
                    _grantsarmour=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="grantsarmour");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _prerequisiterace;
        public string prerequisiterace
        {
            get { return _prerequisiterace; }
            set
            {
                if(_prerequisiterace!=value){
                    _prerequisiterace=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="prerequisiterace");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<feat, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the playercharacters table in the fiveoaths_dev Database.
    /// </summary>
    public partial class playercharacter: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<playercharacter> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<playercharacter>(new FiveOathsLib.Data.fiveoaths_devDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<playercharacter> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(playercharacter item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                playercharacter item=new playercharacter();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<playercharacter> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        FiveOathsLib.Data.fiveoaths_devDB _db;
        public playercharacter(string connectionString, string providerName) {

            _db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                playercharacter.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<playercharacter>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public playercharacter(){
             _db=new FiveOathsLib.Data.fiveoaths_devDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public playercharacter(Expression<Func<playercharacter, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<playercharacter> GetRepo(string connectionString, string providerName){
            FiveOathsLib.Data.fiveoaths_devDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new FiveOathsLib.Data.fiveoaths_devDB();
            }else{
                db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            }
            IRepository<playercharacter> _repo;
            
            if(db.TestMode){
                playercharacter.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<playercharacter>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<playercharacter> GetRepo(){
            return GetRepo("","");
        }
        
        public static playercharacter SingleOrDefault(Expression<Func<playercharacter, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            playercharacter single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static playercharacter SingleOrDefault(Expression<Func<playercharacter, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            playercharacter single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<playercharacter, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<playercharacter, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<playercharacter> Find(Expression<Func<playercharacter, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<playercharacter> Find(Expression<Func<playercharacter, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<playercharacter> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<playercharacter> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<playercharacter> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<playercharacter> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<playercharacter> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<playercharacter> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id";
        }

        public object KeyValue()
        {
            return this.id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.playerid.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(playercharacter)){
                playercharacter compare=(playercharacter)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id;
        }
        
        public string DescriptorValue()
        {
                            return this.playerid.ToString();
                    }

        public string DescriptorColumn() {
            return "playerid";
        }
        public static string GetKeyColumn()
        {
            return "id";
        }        
        public static string GetDescriptorColumn()
        {
            return "playerid";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if(_id!=value){
                    _id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _playerid;
        public int playerid
        {
            get { return _playerid; }
            set
            {
                if(_playerid!=value){
                    _playerid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="playerid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _characterid;
        public int characterid
        {
            get { return _characterid; }
            set
            {
                if(_characterid!=value){
                    _characterid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="characterid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<playercharacter, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the characterfeats table in the fiveoaths_dev Database.
    /// </summary>
    public partial class characterfeat: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<characterfeat> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<characterfeat>(new FiveOathsLib.Data.fiveoaths_devDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<characterfeat> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(characterfeat item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                characterfeat item=new characterfeat();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<characterfeat> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        FiveOathsLib.Data.fiveoaths_devDB _db;
        public characterfeat(string connectionString, string providerName) {

            _db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                characterfeat.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<characterfeat>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public characterfeat(){
             _db=new FiveOathsLib.Data.fiveoaths_devDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public characterfeat(Expression<Func<characterfeat, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<characterfeat> GetRepo(string connectionString, string providerName){
            FiveOathsLib.Data.fiveoaths_devDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new FiveOathsLib.Data.fiveoaths_devDB();
            }else{
                db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            }
            IRepository<characterfeat> _repo;
            
            if(db.TestMode){
                characterfeat.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<characterfeat>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<characterfeat> GetRepo(){
            return GetRepo("","");
        }
        
        public static characterfeat SingleOrDefault(Expression<Func<characterfeat, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            characterfeat single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static characterfeat SingleOrDefault(Expression<Func<characterfeat, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            characterfeat single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<characterfeat, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<characterfeat, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<characterfeat> Find(Expression<Func<characterfeat, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<characterfeat> Find(Expression<Func<characterfeat, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<characterfeat> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<characterfeat> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<characterfeat> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<characterfeat> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<characterfeat> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<characterfeat> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id";
        }

        public object KeyValue()
        {
            return this.id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.characterid.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(characterfeat)){
                characterfeat compare=(characterfeat)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id;
        }
        
        public string DescriptorValue()
        {
                            return this.characterid.ToString();
                    }

        public string DescriptorColumn() {
            return "characterid";
        }
        public static string GetKeyColumn()
        {
            return "id";
        }        
        public static string GetDescriptorColumn()
        {
            return "characterid";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if(_id!=value){
                    _id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _characterid;
        public int characterid
        {
            get { return _characterid; }
            set
            {
                if(_characterid!=value){
                    _characterid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="characterid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _featid;
        public int featid
        {
            get { return _featid; }
            set
            {
                if(_featid!=value){
                    _featid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="featid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<characterfeat, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the lammies table in the fiveoaths_dev Database.
    /// </summary>
    public partial class lammy: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<lammy> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<lammy>(new FiveOathsLib.Data.fiveoaths_devDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<lammy> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(lammy item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                lammy item=new lammy();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<lammy> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        FiveOathsLib.Data.fiveoaths_devDB _db;
        public lammy(string connectionString, string providerName) {

            _db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                lammy.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<lammy>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public lammy(){
             _db=new FiveOathsLib.Data.fiveoaths_devDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public lammy(Expression<Func<lammy, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<lammy> GetRepo(string connectionString, string providerName){
            FiveOathsLib.Data.fiveoaths_devDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new FiveOathsLib.Data.fiveoaths_devDB();
            }else{
                db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            }
            IRepository<lammy> _repo;
            
            if(db.TestMode){
                lammy.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<lammy>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<lammy> GetRepo(){
            return GetRepo("","");
        }
        
        public static lammy SingleOrDefault(Expression<Func<lammy, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            lammy single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static lammy SingleOrDefault(Expression<Func<lammy, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            lammy single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<lammy, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<lammy, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<lammy> Find(Expression<Func<lammy, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<lammy> Find(Expression<Func<lammy, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<lammy> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<lammy> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<lammy> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<lammy> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<lammy> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<lammy> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id";
        }

        public object KeyValue()
        {
            return this.id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(lammy)){
                lammy compare=(lammy)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id;
        }
        
        public string DescriptorValue()
        {
                            return this.name.ToString();
                    }

        public string DescriptorColumn() {
            return "name";
        }
        public static string GetKeyColumn()
        {
            return "id";
        }        
        public static string GetDescriptorColumn()
        {
            return "name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if(_id!=value){
                    _id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _name;
        public string name
        {
            get { return _name; }
            set
            {
                if(_name!=value){
                    _name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _description;
        public string description
        {
            get { return _description; }
            set
            {
                if(_description!=value){
                    _description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _attunetime;
        public string attunetime
        {
            get { return _attunetime; }
            set
            {
                if(_attunetime!=value){
                    _attunetime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="attunetime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _type;
        public string type
        {
            get { return _type; }
            set
            {
                if(_type!=value){
                    _type=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="type");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _validuntil;
        public string validuntil
        {
            get { return _validuntil; }
            set
            {
                if(_validuntil!=value){
                    _validuntil=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="validuntil");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<lammy, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the characterlammies table in the fiveoaths_dev Database.
    /// </summary>
    public partial class characterlammy: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<characterlammy> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<characterlammy>(new FiveOathsLib.Data.fiveoaths_devDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<characterlammy> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(characterlammy item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                characterlammy item=new characterlammy();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<characterlammy> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        FiveOathsLib.Data.fiveoaths_devDB _db;
        public characterlammy(string connectionString, string providerName) {

            _db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                characterlammy.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<characterlammy>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public characterlammy(){
             _db=new FiveOathsLib.Data.fiveoaths_devDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public characterlammy(Expression<Func<characterlammy, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<characterlammy> GetRepo(string connectionString, string providerName){
            FiveOathsLib.Data.fiveoaths_devDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new FiveOathsLib.Data.fiveoaths_devDB();
            }else{
                db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            }
            IRepository<characterlammy> _repo;
            
            if(db.TestMode){
                characterlammy.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<characterlammy>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<characterlammy> GetRepo(){
            return GetRepo("","");
        }
        
        public static characterlammy SingleOrDefault(Expression<Func<characterlammy, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            characterlammy single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static characterlammy SingleOrDefault(Expression<Func<characterlammy, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            characterlammy single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<characterlammy, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<characterlammy, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<characterlammy> Find(Expression<Func<characterlammy, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<characterlammy> Find(Expression<Func<characterlammy, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<characterlammy> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<characterlammy> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<characterlammy> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<characterlammy> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<characterlammy> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<characterlammy> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id";
        }

        public object KeyValue()
        {
            return this.id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.characterid.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(characterlammy)){
                characterlammy compare=(characterlammy)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id;
        }
        
        public string DescriptorValue()
        {
                            return this.characterid.ToString();
                    }

        public string DescriptorColumn() {
            return "characterid";
        }
        public static string GetKeyColumn()
        {
            return "id";
        }        
        public static string GetDescriptorColumn()
        {
            return "characterid";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if(_id!=value){
                    _id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _characterid;
        public int characterid
        {
            get { return _characterid; }
            set
            {
                if(_characterid!=value){
                    _characterid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="characterid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _lammyid;
        public int lammyid
        {
            get { return _lammyid; }
            set
            {
                if(_lammyid!=value){
                    _lammyid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="lammyid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<characterlammy, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the logfile table in the fiveoaths_dev Database.
    /// </summary>
    public partial class logfile: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<logfile> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<logfile>(new FiveOathsLib.Data.fiveoaths_devDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<logfile> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(logfile item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                logfile item=new logfile();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<logfile> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        FiveOathsLib.Data.fiveoaths_devDB _db;
        public logfile(string connectionString, string providerName) {

            _db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                logfile.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<logfile>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public logfile(){
             _db=new FiveOathsLib.Data.fiveoaths_devDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public logfile(Expression<Func<logfile, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<logfile> GetRepo(string connectionString, string providerName){
            FiveOathsLib.Data.fiveoaths_devDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new FiveOathsLib.Data.fiveoaths_devDB();
            }else{
                db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            }
            IRepository<logfile> _repo;
            
            if(db.TestMode){
                logfile.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<logfile>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<logfile> GetRepo(){
            return GetRepo("","");
        }
        
        public static logfile SingleOrDefault(Expression<Func<logfile, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            logfile single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static logfile SingleOrDefault(Expression<Func<logfile, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            logfile single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<logfile, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<logfile, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<logfile> Find(Expression<Func<logfile, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<logfile> Find(Expression<Func<logfile, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<logfile> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<logfile> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<logfile> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<logfile> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<logfile> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<logfile> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id";
        }

        public object KeyValue()
        {
            return this.id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.action.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(logfile)){
                logfile compare=(logfile)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id;
        }
        
        public string DescriptorValue()
        {
                            return this.action.ToString();
                    }

        public string DescriptorColumn() {
            return "action";
        }
        public static string GetKeyColumn()
        {
            return "id";
        }        
        public static string GetDescriptorColumn()
        {
            return "action";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if(_id!=value){
                    _id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _logdate;
        public DateTime logdate
        {
            get { return _logdate; }
            set
            {
                if(_logdate!=value){
                    _logdate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="logdate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _sourcecharacter;
        public int? sourcecharacter
        {
            get { return _sourcecharacter; }
            set
            {
                if(_sourcecharacter!=value){
                    _sourcecharacter=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sourcecharacter");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _sourceplayer;
        public int? sourceplayer
        {
            get { return _sourceplayer; }
            set
            {
                if(_sourceplayer!=value){
                    _sourceplayer=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sourceplayer");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _destinationcharacter;
        public int? destinationcharacter
        {
            get { return _destinationcharacter; }
            set
            {
                if(_destinationcharacter!=value){
                    _destinationcharacter=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="destinationcharacter");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _destinationplayer;
        public int? destinationplayer
        {
            get { return _destinationplayer; }
            set
            {
                if(_destinationplayer!=value){
                    _destinationplayer=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="destinationplayer");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _action;
        public string action
        {
            get { return _action; }
            set
            {
                if(_action!=value){
                    _action=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="action");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<logfile, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the forgotpasswords table in the fiveoaths_dev Database.
    /// </summary>
    public partial class forgotpassword: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<forgotpassword> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<forgotpassword>(new FiveOathsLib.Data.fiveoaths_devDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<forgotpassword> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(forgotpassword item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                forgotpassword item=new forgotpassword();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<forgotpassword> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        FiveOathsLib.Data.fiveoaths_devDB _db;
        public forgotpassword(string connectionString, string providerName) {

            _db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                forgotpassword.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<forgotpassword>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public forgotpassword(){
             _db=new FiveOathsLib.Data.fiveoaths_devDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public forgotpassword(Expression<Func<forgotpassword, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<forgotpassword> GetRepo(string connectionString, string providerName){
            FiveOathsLib.Data.fiveoaths_devDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new FiveOathsLib.Data.fiveoaths_devDB();
            }else{
                db=new FiveOathsLib.Data.fiveoaths_devDB(connectionString, providerName);
            }
            IRepository<forgotpassword> _repo;
            
            if(db.TestMode){
                forgotpassword.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<forgotpassword>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<forgotpassword> GetRepo(){
            return GetRepo("","");
        }
        
        public static forgotpassword SingleOrDefault(Expression<Func<forgotpassword, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            forgotpassword single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static forgotpassword SingleOrDefault(Expression<Func<forgotpassword, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            forgotpassword single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<forgotpassword, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<forgotpassword, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<forgotpassword> Find(Expression<Func<forgotpassword, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<forgotpassword> Find(Expression<Func<forgotpassword, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<forgotpassword> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<forgotpassword> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<forgotpassword> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<forgotpassword> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<forgotpassword> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<forgotpassword> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id";
        }

        public object KeyValue()
        {
            return this.id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.email.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(forgotpassword)){
                forgotpassword compare=(forgotpassword)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id;
        }
        
        public string DescriptorValue()
        {
                            return this.email.ToString();
                    }

        public string DescriptorColumn() {
            return "email";
        }
        public static string GetKeyColumn()
        {
            return "id";
        }        
        public static string GetDescriptorColumn()
        {
            return "email";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if(_id!=value){
                    _id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _email;
        public string email
        {
            get { return _email; }
            set
            {
                if(_email!=value){
                    _email=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="email");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _tokenguid;
        public string tokenguid
        {
            get { return _tokenguid; }
            set
            {
                if(_tokenguid!=value){
                    _tokenguid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="tokenguid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _daterequested;
        public DateTime daterequested
        {
            get { return _daterequested; }
            set
            {
                if(_daterequested!=value){
                    _daterequested=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="daterequested");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<forgotpassword, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}
