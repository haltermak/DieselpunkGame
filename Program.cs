using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
namespace DieselpunkGame
{
    class MainClass
    {
        static string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        internal static string popFile = Path.Combine(projectFolder, @"configs/population_config.txt");
        public static void Main(string[] args)
        {
            GameMaster gameMaster = new GameMaster();
            gameMaster.setup();

            string kallentorPath = Path.Combine(projectFolder, @"configs/counties/Kallentor.txt");
            StreamWriter countyWriter = new StreamWriter(kallentorPath);
            County selin = new County();
            string writeToFile = Newtonsoft.Json.JsonConvert.SerializeObject(selin, Newtonsoft.Json.Formatting.Indented);
            countyWriter.Write(writeToFile);
            countyWriter.Dispose();

            string popTypePath = Path.Combine(projectFolder, @"configs/pop_types.txt");
            StreamWriter popTypeWriter = new StreamWriter(popTypePath);
            popNeedWant grain = new popNeedWant(true, "grain", 1);
            popNeedWant vegetables = new popNeedWant(false, "vegetables", 1);
            popType aristocrat = new popType("aristocrat", 0);
            popType artisan = new popType("artisan", 1);
            aristocrat.needsWants.Add(grain);
            aristocrat.needsWants.Add(vegetables);
            artisan.needsWants.Add(grain);
            artisan.needsWants.Add(vegetables);

            gameMaster.allPopTypes = new Dictionary<string, popType>();
            gameMaster.allPopTypes.Add(aristocrat.name, aristocrat);
            gameMaster.allPopTypes.Add(artisan.name, artisan);

            writeToFile = Newtonsoft.Json.JsonConvert.SerializeObject(gameMaster.allPopTypes, Newtonsoft.Json.Formatting.Indented);
            popTypeWriter.Write(writeToFile);
            popTypeWriter.Dispose();
        }
    }

    internal class GameMaster
    {
        internal List<State> allStates;
        //List<Region> allRegions;
        //List<Nation> allNations;
        internal Dictionary<string, Culture> allCultures;
        internal Dictionary<string, popType> allPopTypes;

        protected void initializeStates()
        {
            DPGConfigParse.StateConfigParser stateConfigParser = new DPGConfigParse.StateConfigParser();
            allStates = stateConfigParser.parseStates();
            stateConfigParser = null;
        }

        internal void setup()
        {
            initializeStates();
        }

    }

    internal class Region
    {

    }

    internal class Nation
    {

    }
    internal class Population
    {
        [Newtonsoft.Json.JsonProperty]
            int populationSize { get; set; }
        [Newtonsoft.Json.JsonProperty]
            int populationMoney { get; set; }
        int populationHappiness;
        [Newtonsoft.Json.JsonProperty]
            int populationPercentageNeedsMet { get; set; }
        [Newtonsoft.Json.JsonProperty]
            int populationPercentageWantsMet { get; set; }
        [Newtonsoft.Json.JsonProperty]
            int populationPercentageEmployed { get; set; }
        [Newtonsoft.Json.JsonProperty]
            int popType;


        internal Population()
        {
            populationPercentageNeedsMet = 100;
            populationPercentageEmployed = 100;
            populationPercentageWantsMet = 100;
            populationSize = 100;
            populationMoney = 0;
            populationHappiness = (populationPercentageNeedsMet-100) + (populationPercentageWantsMet/2) + (populationPercentageEmployed-75);
        }

        internal Population(string inputEntry)
        {

        }

        internal void printPopulation()
        {
            Console.WriteLine(populationSize);
            Console.WriteLine(populationMoney);
            Console.WriteLine(populationHappiness);
            Console.WriteLine(populationPercentageEmployed);
            Console.WriteLine(populationPercentageNeedsMet);
            Console.WriteLine(populationPercentageWantsMet);
        }

        public override string ToString()
        {
            string output = "";
            output += populationSize;
            output += " ";
            output += populationMoney;
            return output;
        }
    }

    internal class popNeedWant {
        [Newtonsoft.Json.JsonProperty]
        bool isNeed { get; set; }
        [Newtonsoft.Json.JsonProperty]
        string goodType { get; set; }
        [Newtonsoft.Json.JsonProperty]
        int amountToRequest { get; set; }

        internal popNeedWant(bool need, string type, int amount) {
            isNeed = need;
            goodType = type;
            amountToRequest = amount;
        }

        internal popNeedWant() {
            
        }
    }

    internal class popType {
        [Newtonsoft.Json.JsonProperty]
            internal string name { get; set; }
        [Newtonsoft.Json.JsonProperty]
            int code { get; set; }
        [Newtonsoft.Json.JsonProperty]
            internal List<popNeedWant> needsWants { get; set; }

        internal popType(){
            needsWants = new List<popNeedWant>();
        }

        internal popType(string n, int c){
            name = n;
            code = c;
            needsWants = new List<popNeedWant>();
        }

    }

    internal class Occupation
    {

    }
    internal class Culture
    {
        [Newtonsoft.Json.JsonProperty]
            string name { get; set; }
        [Newtonsoft.Json.JsonProperty]
            int prestige { get; set; }

        internal Culture()
        {

        }

        internal Culture(string n, int p)
        {
            name = n;
            prestige = p;
        }
    }
    internal class County
    {
        [Newtonsoft.Json.JsonProperty]
            int id { get; set; }
        [Newtonsoft.Json.JsonProperty]
            public string name {get; set;}
        [Newtonsoft.Json.JsonProperty]
            int[] infrastructure { get; set; }
        [Newtonsoft.Json.JsonProperty]
            int terrainCode { get; set; }
        [Newtonsoft.Json.JsonProperty]
            int size { get; set; }
        [Newtonsoft.Json.JsonProperty]
            bool coastal { get; set; }
        [Newtonsoft.Json.JsonProperty]
            int[] deposits { get; set; }

        public List<Population> pops;

        internal County(){
            id = 0;
            name = "Selin";
            pops = new List<Population>();
            pops.Add(new Population());
            pops.Add(new Population());
        }

        public override string ToString(){
            string output = "";
            output += name;
            output += " ";
            output += pops[0].ToString();
            return output;
        }

    }
    internal class State
    {
        [Newtonsoft.Json.JsonProperty]
            internal int id { get; set; }
        [Newtonsoft.Json.JsonProperty]
            internal string name { get; set; }
        [Newtonsoft.Json.JsonProperty]
            internal int region { get; set; } //should eventually be a region reference
        [Newtonsoft.Json.JsonProperty]
            internal string capital { get; set; } //should reference a County
        [Newtonsoft.Json.JsonProperty]
            internal int[] counties { get; set; }

        internal State(int idI, int regionI, string nameS, string capitalS, int[] countiesA)
        {
            id = idI;
            region = regionI;
            name = nameS;
            capital = capitalS;
            counties = countiesA;
        }

        internal State() {
            
        }

        public override string ToString()
        {
            string output = id.ToString();
            output = output + region.ToString();
            output = output + name;
            output = output + capital;
            return output;
        }
    }

    internal class Good {
        
    }

}
/*
 *             try {
                using (StreamReader sr = new StreamReader(pop_config)) {
                    string line;
                    while ((line = sr.ReadLine()) != null) {
                        Console.WriteLine(line);
                    }
                }
            } catch {
                Console.WriteLine("File could not be read");
            }

*/

