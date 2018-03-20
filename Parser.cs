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
        protected const string tagMarker = "*";
        protected const string dataStart = "<";
        protected const string dataEnd = ">";
        protected const string refStart = "[";
        protected const string refEnd = "]";
        protected const string numStart = "%";
        public ConfigParser() {
            
        }
        protected int lineType(string[] input){
            int output = 0;
            if (input[0].EndsWith("*") && input[0].StartsWith("*"))
            {
                return 0;
            }
            else if (input[0])
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

        internal State[] parseStates(){
            State[] output = new State[stateCount];
            System.IO.StreamWriter log = new System.IO.StreamWriter(System.IO.Path.Combine(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, @"logs/stateParser.txt"),false);
            try {
                configReader = new System.IO.StreamReader(filePath);
                while (!configReader.EndOfStream) {
                    /*
                     * Split the string by whitespace.
                     * 2. If first string contains a tag then
                     *      1. Check if what's coming is a single item or an array
                     *      2. If it's a single object, put the label with the item into the map
                     *      3. If it's an array, enter a new loop to deal with that based on the tag.
                     *          -At the end of the array, it should step out of the loop.
                     * 3. If the string is just an opening or closing bracket, step up or down the object heirarchy.
                     * 4. Once state is finished, move to next state.
                     */
                    string line = configReader.ReadLine();
                    string[] splitLine = line.Split(new char[] {' '});

                }
            } catch {
                Console.WriteLine("State reading File borked");
                log.WriteLine("Parsing failed here: ");
                return output;
            }
            log.Close();
            return output;
        }
    }
}
