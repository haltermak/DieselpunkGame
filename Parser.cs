using System;
using System.IO;
using DieselpunkGame;
using Newtonsoft.Json;
namespace DPGConfigParse
{
    /*
     * This class forms the basis for parsing config files for the game. To use, create an instance in the setup class.
     */
    public class ConfigParser
    {
        protected static string stateConfigFilePath;
        protected static string stateLogFilePath;
        protected static string projectFolder;
        protected System.IO.StreamReader configReader;
        protected System.IO.StreamWriter configWriter; //This should be removed once a JSON format is finalized for all objects needing parsing
        protected System.IO.StreamWriter logWriter;
        public ConfigParser()
        {
            projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            stateConfigFilePath = @"configs/states_config.txt";
            stateLogFilePath = @"logs/states_log.txt";
        }

    }

    public class StateConfigParser : ConfigParser
    {
        internal int tempMakeJson() {
            int[] c = { 0, 1, 2, 3, 4 };
            State kallentor = new State(1,1,"Kallentor", "Selin", c);
            string writeToFile = JsonConvert.SerializeObject(kallentor, Formatting.Indented);
            try {
                configWriter = new StreamWriter(Path.Combine(projectFolder,stateConfigFilePath));
                configWriter.Write(writeToFile);
                configWriter.Close();
            } catch {
                Console.WriteLine("Done goofed buddy");
            }
            return 0;
        }
        int stateCount;
        public StateConfigParser() : base()
        {
            
        }
    }
}