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
            List<State> newStates;
            DPGConfigParse.StateConfigParser state = new DPGConfigParse.StateConfigParser();
            newStates = state.parseStates();
            foreach (State s in newStates) {
                Console.WriteLine(s.ToString());
            }

            //moisture_farmers.printPopulation();
        }
        /*
         * Function sets up all pops for a given state by using that state's population_config file.
         * 
         * @param filePath A string that points to that state's population_config file.
         * 
         * 
         */
        #region
        public static void setupPops(string filePath)
        {
            ArrayList pops = new ArrayList();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("pop_type"))
                        {
                            string[] popLines = line.Split(new char[] { ' ' });
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("File could not be read");
            }
        }
        #endregion
    }
    internal class Population
    {

        int populationSize;
        int populationMoney;
        int populationHappiness;
        int populationPercentageNeedsMet;
        int populationPercentageWantsMet;
        int populationPercentageEmployed;
        double populationProducedGoods;

        internal Population()
        {
            populationPercentageNeedsMet = 100;
            populationPercentageEmployed = 100;
            populationPercentageWantsMet = 100;
        }

        internal Population(string inputEntry)
        {

        }

        internal void printPopulation()
        {
            Console.WriteLine(populationSize);
            Console.WriteLine(populationMoney);
            Console.WriteLine(populationHappiness);
            Console.WriteLine(populationProducedGoods);
            Console.WriteLine(populationPercentageEmployed);
            Console.WriteLine(populationPercentageNeedsMet);
            Console.WriteLine(populationPercentageWantsMet);
        }
    }
    internal class Occupation
    {

    }
    internal class Culture
    {

    }
    internal class Province
    {

    }
    internal class State
    {
        public int id;
        public string name;
        public int region;
        public string capital;
        public int[] counties;

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

