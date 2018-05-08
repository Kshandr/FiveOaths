


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace FiveOathsLib.Data {
	
        /// <summary>
        /// Table: players
        /// Primary Key: id
        /// </summary>

        public class playersTable: DatabaseTable {
            
            public playersTable(IDataProvider provider):base("players",provider){
                ClassName = "player";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("realname", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("username", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("password", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("medicaldetail", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("isadmin", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("emergencycontactname", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("emergencycontactnumber", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("carregistration", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });
                    
                
                
            }

            public IColumn id{
                get{
                    return this.GetColumn("id");
                }
            }
				
   			public static string idColumn{
			      get{
        			return "id";
      			}
		    }
            
            public IColumn realname{
                get{
                    return this.GetColumn("realname");
                }
            }
				
   			public static string realnameColumn{
			      get{
        			return "realname";
      			}
		    }
            
            public IColumn email{
                get{
                    return this.GetColumn("email");
                }
            }
				
   			public static string emailColumn{
			      get{
        			return "email";
      			}
		    }
            
            public IColumn username{
                get{
                    return this.GetColumn("username");
                }
            }
				
   			public static string usernameColumn{
			      get{
        			return "username";
      			}
		    }
            
            public IColumn password{
                get{
                    return this.GetColumn("password");
                }
            }
				
   			public static string passwordColumn{
			      get{
        			return "password";
      			}
		    }
            
            public IColumn medicaldetail{
                get{
                    return this.GetColumn("medicaldetail");
                }
            }
				
   			public static string medicaldetailColumn{
			      get{
        			return "medicaldetail";
      			}
		    }
            
            public IColumn isadmin{
                get{
                    return this.GetColumn("isadmin");
                }
            }
				
   			public static string isadminColumn{
			      get{
        			return "isadmin";
      			}
		    }
            
            public IColumn emergencycontactname{
                get{
                    return this.GetColumn("emergencycontactname");
                }
            }
				
   			public static string emergencycontactnameColumn{
			      get{
        			return "emergencycontactname";
      			}
		    }
            
            public IColumn emergencycontactnumber{
                get{
                    return this.GetColumn("emergencycontactnumber");
                }
            }
				
   			public static string emergencycontactnumberColumn{
			      get{
        			return "emergencycontactnumber";
      			}
		    }
            
            public IColumn carregistration{
                get{
                    return this.GetColumn("carregistration");
                }
            }
				
   			public static string carregistrationColumn{
			      get{
        			return "carregistration";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: characters
        /// Primary Key: id
        /// </summary>

        public class charactersTable: DatabaseTable {
            
            public charactersTable(IDataProvider provider):base("characters",provider){
                ClassName = "character";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("playerid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("race", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("body", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("armour", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("mana", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("earthcrystals", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("aircrystals", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("firecrystals", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("watercrystals", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("blendedcrystals", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("voidcrystals", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("coins", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("nativerealm", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }

            public IColumn id{
                get{
                    return this.GetColumn("id");
                }
            }
				
   			public static string idColumn{
			      get{
        			return "id";
      			}
		    }
            
            public IColumn playerid{
                get{
                    return this.GetColumn("playerid");
                }
            }
				
   			public static string playeridColumn{
			      get{
        			return "playerid";
      			}
		    }
            
            public IColumn active{
                get{
                    return this.GetColumn("active");
                }
            }
				
   			public static string activeColumn{
			      get{
        			return "active";
      			}
		    }
            
            public IColumn name{
                get{
                    return this.GetColumn("name");
                }
            }
				
   			public static string nameColumn{
			      get{
        			return "name";
      			}
		    }
            
            public IColumn race{
                get{
                    return this.GetColumn("race");
                }
            }
				
   			public static string raceColumn{
			      get{
        			return "race";
      			}
		    }
            
            public IColumn body{
                get{
                    return this.GetColumn("body");
                }
            }
				
   			public static string bodyColumn{
			      get{
        			return "body";
      			}
		    }
            
            public IColumn armour{
                get{
                    return this.GetColumn("armour");
                }
            }
				
   			public static string armourColumn{
			      get{
        			return "armour";
      			}
		    }
            
            public IColumn mana{
                get{
                    return this.GetColumn("mana");
                }
            }
				
   			public static string manaColumn{
			      get{
        			return "mana";
      			}
		    }
            
            public IColumn earthcrystals{
                get{
                    return this.GetColumn("earthcrystals");
                }
            }
				
   			public static string earthcrystalsColumn{
			      get{
        			return "earthcrystals";
      			}
		    }
            
            public IColumn aircrystals{
                get{
                    return this.GetColumn("aircrystals");
                }
            }
				
   			public static string aircrystalsColumn{
			      get{
        			return "aircrystals";
      			}
		    }
            
            public IColumn firecrystals{
                get{
                    return this.GetColumn("firecrystals");
                }
            }
				
   			public static string firecrystalsColumn{
			      get{
        			return "firecrystals";
      			}
		    }
            
            public IColumn watercrystals{
                get{
                    return this.GetColumn("watercrystals");
                }
            }
				
   			public static string watercrystalsColumn{
			      get{
        			return "watercrystals";
      			}
		    }
            
            public IColumn blendedcrystals{
                get{
                    return this.GetColumn("blendedcrystals");
                }
            }
				
   			public static string blendedcrystalsColumn{
			      get{
        			return "blendedcrystals";
      			}
		    }
            
            public IColumn voidcrystals{
                get{
                    return this.GetColumn("voidcrystals");
                }
            }
				
   			public static string voidcrystalsColumn{
			      get{
        			return "voidcrystals";
      			}
		    }
            
            public IColumn coins{
                get{
                    return this.GetColumn("coins");
                }
            }
				
   			public static string coinsColumn{
			      get{
        			return "coins";
      			}
		    }
            
            public IColumn nativerealm{
                get{
                    return this.GetColumn("nativerealm");
                }
            }
				
   			public static string nativerealmColumn{
			      get{
        			return "nativerealm";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: feats
        /// Primary Key: id
        /// </summary>

        public class featsTable: DatabaseTable {
            
            public featsTable(IDataProvider provider):base("feats",provider){
                ClassName = "feat";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("prerequisites", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("maxtimes", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("grantsmana", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("grantsbody", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("grantsarmour", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("prerequisiterace", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });
                    
                
                
            }

            public IColumn id{
                get{
                    return this.GetColumn("id");
                }
            }
				
   			public static string idColumn{
			      get{
        			return "id";
      			}
		    }
            
            public IColumn name{
                get{
                    return this.GetColumn("name");
                }
            }
				
   			public static string nameColumn{
			      get{
        			return "name";
      			}
		    }
            
            public IColumn description{
                get{
                    return this.GetColumn("description");
                }
            }
				
   			public static string descriptionColumn{
			      get{
        			return "description";
      			}
		    }
            
            public IColumn prerequisites{
                get{
                    return this.GetColumn("prerequisites");
                }
            }
				
   			public static string prerequisitesColumn{
			      get{
        			return "prerequisites";
      			}
		    }
            
            public IColumn maxtimes{
                get{
                    return this.GetColumn("maxtimes");
                }
            }
				
   			public static string maxtimesColumn{
			      get{
        			return "maxtimes";
      			}
		    }
            
            public IColumn grantsmana{
                get{
                    return this.GetColumn("grantsmana");
                }
            }
				
   			public static string grantsmanaColumn{
			      get{
        			return "grantsmana";
      			}
		    }
            
            public IColumn grantsbody{
                get{
                    return this.GetColumn("grantsbody");
                }
            }
				
   			public static string grantsbodyColumn{
			      get{
        			return "grantsbody";
      			}
		    }
            
            public IColumn grantsarmour{
                get{
                    return this.GetColumn("grantsarmour");
                }
            }
				
   			public static string grantsarmourColumn{
			      get{
        			return "grantsarmour";
      			}
		    }
            
            public IColumn prerequisiterace{
                get{
                    return this.GetColumn("prerequisiterace");
                }
            }
				
   			public static string prerequisiteraceColumn{
			      get{
        			return "prerequisiterace";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: playercharacters
        /// Primary Key: id
        /// </summary>

        public class playercharactersTable: DatabaseTable {
            
            public playercharactersTable(IDataProvider provider):base("playercharacters",provider){
                ClassName = "playercharacter";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("playerid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("characterid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn id{
                get{
                    return this.GetColumn("id");
                }
            }
				
   			public static string idColumn{
			      get{
        			return "id";
      			}
		    }
            
            public IColumn playerid{
                get{
                    return this.GetColumn("playerid");
                }
            }
				
   			public static string playeridColumn{
			      get{
        			return "playerid";
      			}
		    }
            
            public IColumn characterid{
                get{
                    return this.GetColumn("characterid");
                }
            }
				
   			public static string characteridColumn{
			      get{
        			return "characterid";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: characterfeats
        /// Primary Key: id
        /// </summary>

        public class characterfeatsTable: DatabaseTable {
            
            public characterfeatsTable(IDataProvider provider):base("characterfeats",provider){
                ClassName = "characterfeat";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("characterid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("featid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn id{
                get{
                    return this.GetColumn("id");
                }
            }
				
   			public static string idColumn{
			      get{
        			return "id";
      			}
		    }
            
            public IColumn characterid{
                get{
                    return this.GetColumn("characterid");
                }
            }
				
   			public static string characteridColumn{
			      get{
        			return "characterid";
      			}
		    }
            
            public IColumn featid{
                get{
                    return this.GetColumn("featid");
                }
            }
				
   			public static string featidColumn{
			      get{
        			return "featid";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: lammies
        /// Primary Key: id
        /// </summary>

        public class lammiesTable: DatabaseTable {
            
            public lammiesTable(IDataProvider provider):base("lammies",provider){
                ClassName = "lammy";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("attunetime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("type", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("validuntil", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }

            public IColumn id{
                get{
                    return this.GetColumn("id");
                }
            }
				
   			public static string idColumn{
			      get{
        			return "id";
      			}
		    }
            
            public IColumn name{
                get{
                    return this.GetColumn("name");
                }
            }
				
   			public static string nameColumn{
			      get{
        			return "name";
      			}
		    }
            
            public IColumn description{
                get{
                    return this.GetColumn("description");
                }
            }
				
   			public static string descriptionColumn{
			      get{
        			return "description";
      			}
		    }
            
            public IColumn attunetime{
                get{
                    return this.GetColumn("attunetime");
                }
            }
				
   			public static string attunetimeColumn{
			      get{
        			return "attunetime";
      			}
		    }
            
            public IColumn type{
                get{
                    return this.GetColumn("type");
                }
            }
				
   			public static string typeColumn{
			      get{
        			return "type";
      			}
		    }
            
            public IColumn validuntil{
                get{
                    return this.GetColumn("validuntil");
                }
            }
				
   			public static string validuntilColumn{
			      get{
        			return "validuntil";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: characterlammies
        /// Primary Key: id
        /// </summary>

        public class characterlammiesTable: DatabaseTable {
            
            public characterlammiesTable(IDataProvider provider):base("characterlammies",provider){
                ClassName = "characterlammy";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("characterid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("lammyid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn id{
                get{
                    return this.GetColumn("id");
                }
            }
				
   			public static string idColumn{
			      get{
        			return "id";
      			}
		    }
            
            public IColumn characterid{
                get{
                    return this.GetColumn("characterid");
                }
            }
				
   			public static string characteridColumn{
			      get{
        			return "characterid";
      			}
		    }
            
            public IColumn lammyid{
                get{
                    return this.GetColumn("lammyid");
                }
            }
				
   			public static string lammyidColumn{
			      get{
        			return "lammyid";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: logfile
        /// Primary Key: id
        /// </summary>

        public class logfileTable: DatabaseTable {
            
            public logfileTable(IDataProvider provider):base("logfile",provider){
                ClassName = "logfile";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("logdate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("sourcecharacter", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("sourceplayer", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("destinationcharacter", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("destinationplayer", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("action", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });
                    
                
                
            }

            public IColumn id{
                get{
                    return this.GetColumn("id");
                }
            }
				
   			public static string idColumn{
			      get{
        			return "id";
      			}
		    }
            
            public IColumn logdate{
                get{
                    return this.GetColumn("logdate");
                }
            }
				
   			public static string logdateColumn{
			      get{
        			return "logdate";
      			}
		    }
            
            public IColumn sourcecharacter{
                get{
                    return this.GetColumn("sourcecharacter");
                }
            }
				
   			public static string sourcecharacterColumn{
			      get{
        			return "sourcecharacter";
      			}
		    }
            
            public IColumn sourceplayer{
                get{
                    return this.GetColumn("sourceplayer");
                }
            }
				
   			public static string sourceplayerColumn{
			      get{
        			return "sourceplayer";
      			}
		    }
            
            public IColumn destinationcharacter{
                get{
                    return this.GetColumn("destinationcharacter");
                }
            }
				
   			public static string destinationcharacterColumn{
			      get{
        			return "destinationcharacter";
      			}
		    }
            
            public IColumn destinationplayer{
                get{
                    return this.GetColumn("destinationplayer");
                }
            }
				
   			public static string destinationplayerColumn{
			      get{
        			return "destinationplayer";
      			}
		    }
            
            public IColumn action{
                get{
                    return this.GetColumn("action");
                }
            }
				
   			public static string actionColumn{
			      get{
        			return "action";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: forgotpasswords
        /// Primary Key: id
        /// </summary>

        public class forgotpasswordsTable: DatabaseTable {
            
            public forgotpasswordsTable(IDataProvider provider):base("forgotpasswords",provider){
                ClassName = "forgotpassword";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("tokenguid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("daterequested", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn id{
                get{
                    return this.GetColumn("id");
                }
            }
				
   			public static string idColumn{
			      get{
        			return "id";
      			}
		    }
            
            public IColumn email{
                get{
                    return this.GetColumn("email");
                }
            }
				
   			public static string emailColumn{
			      get{
        			return "email";
      			}
		    }
            
            public IColumn tokenguid{
                get{
                    return this.GetColumn("tokenguid");
                }
            }
				
   			public static string tokenguidColumn{
			      get{
        			return "tokenguid";
      			}
		    }
            
            public IColumn daterequested{
                get{
                    return this.GetColumn("daterequested");
                }
            }
				
   			public static string daterequestedColumn{
			      get{
        			return "daterequested";
      			}
		    }
            
                    
        }
        
}