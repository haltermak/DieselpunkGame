using System;
using System.IO;
using DieselpunkGame;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace DPGConfigParse
{
    /*
     * This class forms the basis for parsing config files for the game. To use, create an instance in the setup class.
     */
    public class ConfigParser
    {
        protected const string stateConfigFilePath = @"configs/states_config.txt";
        protected const string stateLogFilePath = @"logs/states_log.txt";
        protected static readonly string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        protected System.IO.StreamReader configReader;
        protected System.IO.StreamWriter configWriter; //This should be removed once a JSON format is finalized for all objects needing parsing
        protected System.IO.StreamWriter logWriter;
        public ConfigParser()
        {
            
        }

    }

    public class StateConfigParser : ConfigParser
    {
        /*internal int tempMakeJson()
        {
            int[] c = { 0, 1, 2, 3, 4 };
            State kallentor = new State(1, 1, "Kallentor", "Selin", c);
            int[] d = { 5, 6, 7, 8, 9 };
            State najento = new State(2, 1, "Najento", "Ashen", d);
            State[] states = { kallentor, najento };
            string writeToFile = JsonConvert.SerializeObject(states, Formatting.Indented);
            try
            {
                configReader.Close();
                configWriter = new StreamWriter(Path.Combine(projectFolder, stateConfigFilePath));
                configWriter.Write(writeToFile);
                configWriter.Close();
                configReader = new StreamReader(Path.Combine(projectFolder, stateConfigFilePath));
            }
            catch
            {
                Console.WriteLine("Done goofed buddy");
            }
            return 0;
        }*/ //This function only makes a short json file for two states. It shouldn't be needed again unless you're an idiot and delete the file.
        internal StateConfigParser() : base()
        {
            try
            {
                logWriter = new StreamWriter(Path.Combine(projectFolder, stateLogFilePath));
                configReader = new StreamReader(Path.Combine(projectFolder, stateConfigFilePath));
            } catch {
                Console.Write("Something messed up while opening the files.");
            }

        } 

        internal List<State> parseStates(){
            List<State> states = JsonConvert.DeserializeObject<List<State>>(configReader.ReadToEnd());
            return states;
        }

        ~StateConfigParser() {
            configReader.Close();
            //configWriter.Close();
            logWriter.Close();
        }
    }
}