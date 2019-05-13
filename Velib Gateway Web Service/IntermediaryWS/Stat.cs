using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{
    [DataContract]
    public class Stat
    {
        int ClientRequestGoogle = 0;
        int ClientRequestIWS = 0;
        TimeSpan AverageDelayIWS = new TimeSpan();
        int counterAverageDelayIWS = 0;
        int WSVelibRequest = 0;

        public Stat()
        {
            readFile();
        }

        [DataMember]
        public int ClientRequestGoogle1 {
            get => ClientRequestGoogle;
            set => ClientRequestGoogle = value; }

        [DataMember]
        public int ClientRequestIWS1 {
            get => ClientRequestIWS;
            set => ClientRequestIWS = value; }

        [DataMember]
        public TimeSpan AverageDelayIWS1 {
            get => AverageDelayIWS;
            set => AverageDelayIWS = value; }

        [DataMember]
        public int WSVelibRequest1 {
            get => WSVelibRequest;
            set => WSVelibRequest = value; }
        [DataMember]
        public int CounterAverageDelayIWS { get => counterAverageDelayIWS; set => counterAverageDelayIWS = value; }

        public void readFile()
        {
            string docPath =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            
            if (File.Exists(Path.Combine(docPath, "VELIB_Project.json"))){

                StreamReader inputFile = new StreamReader(Path.Combine(docPath, "VELIB_Project.json"));

                JObject jObject = new JObject();
                jObject = JObject.Parse(inputFile.ReadToEnd());
                ClientRequestGoogle = (int)jObject.GetValue("ClientRequestGoogle");
                ClientRequestIWS = (int)jObject.GetValue("ClientRequestIWS");
                AverageDelayIWS = (TimeSpan)jObject.GetValue("AverageDelayIWS");
                WSVelibRequest = (int)jObject.GetValue("WSVelibRequest");
                counterAverageDelayIWS = (int)jObject.GetValue("counterAverageDelayIWS");

                inputFile.Close();

            }       
        }
        public void writeFile()
        {
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "VELIB_Project.json"));

            JObject jObject = new JObject();
            jObject.Add("ClientRequestGoogle", ClientRequestGoogle);
            jObject.Add("ClientRequestIWS", ClientRequestIWS);
            jObject.Add("AverageDelayIWS", AverageDelayIWS);
            jObject.Add("WSVelibRequest", WSVelibRequest);
            jObject.Add("counterAverageDelayIWS", counterAverageDelayIWS);

            outputFile.WriteAsync(jObject.ToString());

            outputFile.Close();
        }

        public void AddClientRequestGoogle() {
            ClientRequestGoogle++;
            writeFile();
        }
        public void AddClientRequestIWS()
        {
            ClientRequestIWS++;
            writeFile();
        }
        public void AddAverageDelayIWS(TimeSpan timer)
        {
            counterAverageDelayIWS++;
            AverageDelayIWS = AverageDelayIWS + timer;
            writeFile();
        }
        public void AddWSVelibRequest()
        {
            WSVelibRequest++;
            writeFile();
        }
    }
}
