using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{
    class Stat
    {
        int ClientRequestGoogle = 0;
        int ClientRequestIWS = 0;
        double AverageDelayIWS = 0;
        int WSVelibRequest = 0;

        public Stat()
        {
            readFile();
        }

        public int ClientRequestGoogle1 {
            get => ClientRequestGoogle;
            set => ClientRequestGoogle = value; }
        public int ClientRequestIWS1 {
            get => ClientRequestIWS;
            set => ClientRequestIWS = value; }
        public double AverageDelayIWS1 {
            get => AverageDelayIWS;
            set => AverageDelayIWS = value; }
        public int WSVelibRequest1 {
            get => WSVelibRequest;
            set => WSVelibRequest = value; }

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
                AverageDelayIWS = (double)jObject.GetValue("AverageDelayIWS");
                WSVelibRequest = (int)jObject.GetValue("WSVelibRequest");

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
        public void AddAverageDelayIWS()
        {
            AverageDelayIWS++;
            writeFile();
        }
        public void AddWSVelibRequest()
        {
            WSVelibRequest++;
            writeFile();
        }
    }
}
