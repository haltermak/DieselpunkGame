using System;
using DieselpunkGame;
namespace DPGConfigParse
{
    /*
     * This class forms the basis for parsing config files for the game. To use, create an instance in the setup class.
     */
    public class ConfigParser {
        protected string filePath;
        protected System.IO.StreamReader configReader;
        public ConfigParser() {
            
        }
    }

    public class StateConfigParser: ConfigParser {
        int stateCount;
        public StateConfigParser(string filePathIn) : base() {
            filePath = filePathIn;
            stateCount = 0;
            try
            {
                configReader = new System.IO.StreamReader(filePath);
                while (!configReader.EndOfStream){
                    var line = configReader.ReadLine();
                    if (line.Contains("*state*")){
                        stateCount++;
                    }
                }
                configReader.Dispose();
            } catch {
                Console.WriteLine("File unable to be opened: " + filePath);
            }
        }

        public State[] parseStates(){
            State[] output = new State[stateCount];
            try {
                configReader = new System.IO.StreamReader(filePath);
                while (!configReader.EndOfStream) {
                    /*
                     * Split the string by whitespace.
                     * 2. If first string contains a tag then
                     *      1. Check if what's coming is a single item or an array
                     *      2. If it's a single object, put the label with the item into the map
                     *      3. I
                }
            }
        }
    }
}
