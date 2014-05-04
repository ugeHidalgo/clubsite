namespace ClubSite.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ClubSite.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<ClubSite.Model.ClubSiteContext>
    {        

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        protected override void Seed(ClubSite.Model.ClubSiteContext context)
        {
            //Truncate data
            context.Database.ExecuteSqlCommand(@"delete from dbo.Races;
                                                 dbcc checkident ('dbo.Races',Reseed,0);");
            context.Database.ExecuteSqlCommand(@"delete from dbo.RaceTypes;
                                                 dbcc checkident ('dbo.RaceTypes',Reseed,0);");
            context.Database.ExecuteSqlCommand(@"delete from dbo.Sports;
                                                 dbcc checkident ('dbo.Sports',Reseed,0);");
            context.Database.ExecuteSqlCommand(@"delete from dbo.Members");
            context.Database.ExecuteSqlCommand(@"delete from dbo.Materials;
                                                 dbcc checkident ('dbo.Materials',Reseed,0);");
            context.Database.ExecuteSqlCommand(@"delete from dbo.MaterialTypes;
                                                 dbcc checkident ('dbo.MaterialTypes',Reseed,0);");
            context.Database.ExecuteSqlCommand(@"delete from dbo.Sponsors;
                                                 dbcc checkident ('dbo.Sponsors',Reseed,0);");
            context.Database.ExecuteSqlCommand(@"delete from dbo.RaceAgeGroups;
                                                 dbcc checkident ('dbo.RaceAgeGroups',Reseed,0);");

            //Seed Tables
            GetSports().ForEach(sp => context.Sports.Add(sp));
            GetRaceTypes().ForEach(rt => context.RaceTypes.Add(rt));
            List<Race> aRaces = GetRaces(); 
            aRaces.ForEach(r => context.Races.Add(r));
            GetMembers(aRaces).ForEach(m => context.Members.Add(m));
            GetMaterialTypes().ForEach(mt => context.MaterialTypes.Add(mt));
            GetMaterials().ForEach(m => context.Materials.Add(m));
            GetSponsors().ForEach(sp => context.Sponsors.Add(sp));
            GetRaceAgeGroups().ForEach(ag => context.RaceAgeGroups.Add(ag));                                     

            //Save Data into BD
            context.SaveChanges();
        }

        private static List<Sport> GetSports()
        {
            var aListOfSports = new List<Sport> {
                new Sport {SportID=1,Name="Triatlón",Memo="Todo tipo de triatlones, cross y carretera, y cualquier distancia"},
                new Sport {SportID=2,Name="Duatlón",Memo="Todo tipo de duatlones, carretera, cross, etc..."},
                new Sport {SportID=3,Name="Running",Memo="Todo tipo de carreras a pie"},
                new Sport {SportID=4,Name="Ciclismo",Memo="Todo tipo de carreras con bicicleta."},
                new Sport {SportID=5,Name="Natación",Memo="Todo tipo de pruebas de natación"} };
            return aListOfSports;
        }

        private static List<RaceType> GetRaceTypes()
        {
            var aListOfRaceTypes = new List<RaceType> {
                new RaceType { RaceTypeID=1,  Name="Super Sprint", Points=80, SportID=1, Memo="Triatlones distancia Super Sprint: (375/10/2,5)" },
                new RaceType { RaceTypeID=2,  Name="Sprint", Points=100, SportID=1,Memo="Triatlones distancia Sprint: (750/20/5)" },
                new RaceType { RaceTypeID=3,  Name="Olímpico", Points=125, SportID=1, Memo ="Triatlones distancia Super Sprint: (1500/20/10)"},
                new RaceType { RaceTypeID=4,  Name="Media Distancia", Points=250, SportID=1, Memo="Triatlones media distancia o medio Ironman: (1,9/90/21)"},
                new RaceType { RaceTypeID=5,  Name="Larga Distancia", Points=500, SportID=1, Memo="Triatlones larga distancia o Ironman: (3,8/180/42)" },
                new RaceType { RaceTypeID=6,  Name="Ultra Distancia", Points=1000, SportID=1, Memo="Triatlones ultra distancia o Ultraman" },

                new RaceType { RaceTypeID=7,  Name="Super Sprint", Points=50, SportID=2, Memo="Duatlones distancia Super Sprint" },
                new RaceType { RaceTypeID=8,  Name="Sprint", Points=80, SportID=2, Memo="Duatlones distancia Sprint " },
                new RaceType { RaceTypeID=9,  Name="Olímpico", Points=100, SportID=2, Memo="Duatlones distancia Olímpica" },

                new RaceType { RaceTypeID=10,  Name="Menor de 9km", Points=40, SportID=3, Memo="Carreras a pie menores de 9 kilómetros" },
                new RaceType { RaceTypeID=11,  Name="Entre 9 y 11km", Points=50, SportID=3, Memo="Carreras a pié entre 9 y 11 kilómetros" },
                new RaceType { RaceTypeID=12,  Name="Entre 12 y 21 km", Points=80, SportID=3, Memo="Carreras a pié entre 22 y 29 kilómetros" },
                new RaceType { RaceTypeID=13,  Name="Entre 22 y 29km", Points=100, SportID=3, Memo="Carreras a pié entre 22 y 29 kilómetros" },
                new RaceType { RaceTypeID=14,  Name="Entre 30 y 43km", Points=125, SportID=3, Memo="Carreras a pié entre 30 y 43 kilómetros" },
                new RaceType { RaceTypeID=15,  Name="Mayor de 43km", Points=150, SportID=3, Memo="Carreras a pié mayores de 43 kilómetros" },

                new RaceType { RaceTypeID=16,  Name="MTB menor de 40km", Points=80, SportID=4, Memo="Pruebas de bicicleta de Montaña menores de 40 kilómetros" },
                new RaceType { RaceTypeID=17,  Name="MTB entre 40 y 80km", Points=100, SportID=4, Memo="Pruebas de bicicleta de Montaña entre 40 y 80 kilómetros" },
                new RaceType { RaceTypeID=18,  Name="MTB mayor de 80km", Points=125, SportID=4, Memo="Pruebas de bicicleta de Montaña mayores de 80 kilómetros" },
                new RaceType { RaceTypeID=19,  Name="Crta menor de 100km", Points=100, SportID=4, Memo="Pruebas de bicicleta de carretera menores de 100 kilómetros" },
                new RaceType { RaceTypeID=20,  Name="Crta entre 100 y 200km", Points=125, SportID=4, Memo="Pruebas de bicicleta de carretera entre 100 y 200 kilómetros" },

                new RaceType { RaceTypeID=21,  Name="Menos de 2km", Points=25, SportID=5, Memo="Pruebas de natación menores de 2 kilómetros" },
                new RaceType { RaceTypeID=22,  Name="Entre 2 y 4km", Points=50, SportID=5, Memo="Pruebas de natación entre 2 y 4 kilómetros" },
                new RaceType { RaceTypeID=23,  Name="Mas de 4km", Points=80, SportID=5, Memo="Pruebas de natación mayores de 4 kilómetros" }                                
                 };
            return aListOfRaceTypes;
        }

        private static List<Race> GetRaces()
        {      
            Address anAdress = new Address();
            var aListOfRaces2 = new List<Race> {
                new Race { Id=1, Name="Media Maratón de Almería", Address=anAdress, RaceDate=Convert.ToDateTime("2014/02/14 00:00:00"), RaceTypeID=12,
                           Latitud=36.831271, Longitud=-2.459564, PartMasc=4356, PartFem=1120, ImageURL="../Images/Races/Media Almeria.png" },
                new Race { Id=2, Name="Triatlón de Elche Arenales", Address=anAdress, RaceDate=Convert.ToDateTime("2014/04/20 00:00:00"), RaceTypeID=4,
                           Latitud=38.246404, Longitud=-0.516572,PartMasc=1120, PartFem=245, ImageURL="../Images/Races/elchetriatlon.jpg"},
                new Race { Id=3, Name="Triatlón Cross Tarifa XChallenge", Address=anAdress, RaceDate=Convert.ToDateTime("2014/06/01 00:00:00"), RaceTypeID=3,
                           Latitud=36.007034, Longitud=-5.608006,PartMasc=175, PartFem=22, ImageURL="../Images/Races/XchallengeTarifa.jpg"  },
                new Race { Id=4, Name="Ironman Lanzarote", Address=anAdress, RaceDate=Convert.ToDateTime("2014/05/24 00:00:00"), RaceTypeID=5, 
                           Latitud=28.959188, Longitud=-13.552322,PartMasc=2145, PartFem=489, ImageURL="../Images/Races/lanzarote1.jpg" } };
            return aListOfRaces2;
        }


        private static List<Member> GetMembers(List<Race> aListOfRaces)
        {
            Address anAdress = new Address();            
            var aListOfMembers = new List<Member> {
                new Member {UserName="adminuser",State=true,Federated=true,Visible=false,RegDate=DateTime.Now,FirstName="adminuser",SecondName="Administrador", Address=anAdress,
                            ImageURL="../Images/Clubbers/logoHistoria.jpg", NImageURL ="../Images/Clubbers/believe2.jpg", BlogURL="http://www.sharptheclub.net", Number=null },

                new Member {UserName="dlirio",State=true,Federated=true,Visible=true,RegDate=DateTime.Now,FirstName="David",SecondName="Lirio Domingo", Address=anAdress ,
                            ImageURL="../Images/Clubbers/dlirio.jpg", NImageURL ="../Images/Clubbers/dlirio23.jpg", BlogURL="http://davidlirio.blogspot.com.es/", Number="23",
                            Races=new List<Race>{aListOfRaces[0], aListOfRaces[1]} },

                new Member {UserName="lofer",State=true,Federated=true,Visible=true,RegDate=DateTime.Now,FirstName="Jesus",SecondName="López Fernández", Address=anAdress,
                            ImageURL="../Images/Clubbers/lofer.jpg", NImageURL ="../Images/Clubbers/LoFer21.jpg", BlogURL="http://trilofer.blogspot.com.es/", Number="21",
                            Races=new List<Race>{aListOfRaces[3]} },

                new Member {UserName="mmar",State=true,Federated=true,Visible=true,RegDate=DateTime.Now,FirstName="Maria del Mar",SecondName="Moral López", Address=anAdress,
                            ImageURL="../Images/Clubbers/mdm.jpg", NImageURL ="../Images/Clubbers/Mmar69.jpg", BlogURL="https://www.facebook.com/mar.morallopez", Number="69",
                            Races=new List<Race>{aListOfRaces[2]} },

                new Member {UserName="ugeHidalgo",State=true,Federated=true,Visible=true,RegDate=DateTime.Now,FirstName="Eugenio",SecondName="Hidalgo Hernández", Address=anAdress,
                            ImageURL="../Images/Clubbers/eugenio.jpg", NImageURL ="../Images/Clubbers/eugenio14.jpg", BlogURL="http://ugeblog.blogspot.com.es/",Number="14",
                            Races=new List<Race>{aListOfRaces[2]} },

                new Member {UserName="juanan",State=true,Federated=true,Visible=true,RegDate=DateTime.Now,FirstName="Juan Antonio",SecondName="Vicaria", Address=anAdress,
                            ImageURL="../Images/Clubbers/javicaria.jpg", NImageURL ="../Images/Clubbers/Javiaria7.jpg", BlogURL="http://runxfun.blogspot.com.es/",Number="07",
                            Races=new List<Race>{aListOfRaces[0]} },

                new Member {UserName="josete",State=true,Federated=true,Visible=true,RegDate=DateTime.Now,FirstName="Jose Miguel",SecondName="López", Address=anAdress,
                            ImageURL="../Images/Clubbers/josete.jpg", NImageURL ="../Images/Clubbers/Josete00.jpg", BlogURL="http://226kms.blogspot.com.es/", Number="00",
                            Races=new List<Race>{aListOfRaces[0], aListOfRaces[1]} },

                new Member {UserName="jero",State=true,Federated=true,Visible=true,RegDate=DateTime.Now,FirstName="Jerónimo",SecondName="Jeronimo", Address=anAdress,
                            ImageURL="../Images/Clubbers/jero.jpg", NImageURL ="../Images/Clubbers/Jero9.jpg", BlogURL="http://latabernadelmonaguillo.blogspot.com.es/",Number="09",
                            Races=new List<Race>{aListOfRaces[0], aListOfRaces[1]} }
            };
            return aListOfMembers;
        }


        private static List<Sponsor> GetSponsors()
        {
            Address adHSR = new Address("C/ de Humans sapiens", "23", "Granada", "España", "18007");
            Address adBP = new Address("C/ de Repuestos Andrés", "3", "Granada", "España", "18006");
            Address adOM = new Address("C/ de Opticas Manzano Andrés", "18", "Granada", "España", "18006");
            Address adDNS = new Address("C/ de DNS", "18", "Granada", "España", "18010");
            Address adJC = new Address("C/ de Juan Manuel Casares", "18", "Granada", "España", "18012");
            var aListOfSponsors = new List<Sponsor> {
                new Sponsor { SponsorId = 1, Nombre = "Humans Sapiens Runner", ContactPerson="Juan Sánchez", Activo=true, AportInicial=500, AportRecibida=350, RegDate=DateTime.Now,
                              LogoURL="../Images/Sponsors/human sapiens.png", WebURL="http://sapiensrunner.es/", Latitud=37.159807, Longitud=-3.605489,
                              EMail="humanssapiens@gmail.com", Tlf="958 555 555", Address=adHSR},
                new Sponsor { SponsorId = 2, Nombre = "Bike Point, Repuestos Andrés", ContactPerson="Andrés", Activo=true, AportInicial=600, AportRecibida=600, RegDate=DateTime.Now,
                              LogoURL="../Images/Sponsors/bike point.jpg", WebURL="http://www.motosandres.com/", Latitud=37.166717, Longitud=-3.603458,
                              EMail="repuestosAndres@gmail.com", Tlf="958 555 666", Address=adBP},
                new Sponsor { SponsorId = 3, Nombre = "Ópticas Manzano", ContactPerson="Sr Manzano", Activo=true, AportInicial=300, AportRecibida=300, RegDate=DateTime.Now,
                              LogoURL="../Images/Sponsors/Manzano.jpg", WebURL="http://www.opticasmanzano.es/", Latitud=37.193245, Longitud=-3.623343,
                              EMail="manzano@gmail.com", Tlf="958 555 777", Address=adOM},
                new Sponsor { SponsorId = 3, Nombre = "Dauro Sport Nutrición", ContactPerson="Tomás Fernández", Activo=true, AportInicial=300, AportRecibida=300, RegDate=DateTime.Now,
                              LogoURL="../Images/Sponsors/DSN.jpg", WebURL="http://www.dsnstore.com/", Latitud=37.173585, Longitud=-3.609438,
                              EMail="dns@gmail.com", Tlf="958 555 888", Address=adDNS},
                new Sponsor { SponsorId = 3, Nombre = "Fisioterapia Juan Manuel Casares", ContactPerson="Juan Manuel Casares", Activo=true, AportInicial=300, AportRecibida=300, RegDate=DateTime.Now,
                              LogoURL="../Images/Sponsors/juanmanuelCasares.jpg", WebURL="https://www.facebook.com/fisioterapiajuanmanuel.casares" , Latitud=37.204064, Longitud=-3.619083,
                              EMail="jcasares@gmail.com", Tlf="958 555 999", Address=adJC}
            };
            return aListOfSponsors;
        }

        private static List<MaterialType> GetMaterialTypes()
        {
            var aListOfMatTypes = new List<MaterialType> {
                new MaterialType { MatTypeID=1, Name="Ropa Running", Memo="Ropa para correr: Mallas, camisetas, pantalones cortos, etc."},
                new MaterialType { MatTypeID=2, Name="Ropa Bike", Memo= "Ropa de bicicleta: Mallots,culottes, manguitos, etc."},
                new MaterialType { MatTypeID=3, Name="Ropa natación", Memo= "Ropa de natación: Bañadores, gorros, etc."},
                new MaterialType { MatTypeID=4, Name="Otros Ropa", Memo="Otro tipo de ropa: Buffs, Polos, chandals, etc.."},
                new MaterialType { MatTypeID=5, Name="Ropa de competición", Memo="Ropa de competición; Monos, Dos piezas, etc.."}                
            };
            return aListOfMatTypes;
        }

        private static List<Material> GetMaterials()
        {
            var aListOfMat = new List<Material> {
                new Material { MatID=1, MatName="TriTraje", Active=true, Cost=(decimal)56.3,Price=(decimal)86.9,  MatTypeId =5, Memo="Mono de competición." },
                new Material { MatID=2, MatName="Culotte", Active=true, Cost=(decimal)36.8,Price=(decimal)56.7, MatTypeId=2, Memo="Culotte corto de bicicleta." },
                new Material { MatID=3, MatName="Mallot corto", Active=true, Cost=(decimal)34.1,Price=(decimal)46.2, MatTypeId=2, Memo="Mallot corto de bicicleta." },
                new Material { MatID=4, MatName="Mallot Largo", Active=true, Cost=(decimal)52.7,Price=(decimal)66.9, MatTypeId=2, Memo="mallot largo de bicicleta" },
                new Material { MatID=5, MatName="Mallas cortas", Active=true, Cost=(decimal)23.3,Price=(decimal)24.7, MatTypeId=1, Memo="Mallas cortas para correr" },
            };
            return aListOfMat;
        }

        private static List<RaceAgeGroup> GetRaceAgeGroups()
        {
            var aListOfraceAgeGroup = new List<RaceAgeGroup> {
                new RaceAgeGroup {  Id=1, Name="40-44 Masc.", Part=123, RaceID=3 },
                new RaceAgeGroup {  Id=2, Name="40-44 Fem.", Part=3, RaceID=3},
                new RaceAgeGroup {  Id=3, Name="35-39 Masc.", Part=137, RaceID=3},
                new RaceAgeGroup {  Id=4, Name="35-39 Masc.", Part=347, RaceID=4},
                new RaceAgeGroup {  Id=5, Name="30-34 Masc.", Part=474, RaceID=2},
                new RaceAgeGroup {  Id=6, Name="25-29 Masc.", Part=214, RaceID=2},
                new RaceAgeGroup {  Id=7, Name="30-34 Masc.", Part=734, RaceID=1},
                new RaceAgeGroup {  Id=8, Name="25-29 Masc.", Part=412, RaceID=1},
            };
            return aListOfraceAgeGroup;
        }
    }
}
