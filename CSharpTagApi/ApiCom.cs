using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace CSharpTagApi
{
    class ApiCom
    {
        
        public void doRequestNearYou(string uri)
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create(uri);
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            List<TagCloserToYou> linesAround = JsonConvert.DeserializeObject<List<TagCloserToYou>>(responseFromServer);                       
            Dictionary<string, List<string>> ListWithOutDuplicatesNames = new Dictionary<string, List<string>>();

            foreach (TagCloserToYou item in linesAround)
            {
                if (!ListWithOutDuplicatesNames.ContainsKey(item.name))
                {
                    ListWithOutDuplicatesNames.Add(item.name, item.lines);
                }
                else
                {
                    ListWithOutDuplicatesNames[item.name].Concat(item.lines);
                }
            }
            foreach (TagCloserToYou item in linesAround)
            {
                if (!ListWithOutDuplicatesNames.ContainsKey(item.name))
                {
                    ListWithOutDuplicatesNames.Add(item.name, item.lines);
                }
                else
                {
                    foreach (var line in item.lines)
                    {
                        if (!ListWithOutDuplicatesNames[item.name].Contains(line))
                        {
                            ListWithOutDuplicatesNames[item.name].Add(line);
                        }
                    }
                    
                }
            }

            List<string> vs = new List<string>();
            vs.Add("lo");
            vs.Add("li");
            List<string> vs2 = new List<string>();
            vs2.Add("lo");
            vs2.Add("li");

            vs.Concat(vs2);
            foreach (var item in vs)
            {
                Console.WriteLine(item+"\n");
            }
            
                
           

            foreach (var item in ListWithOutDuplicatesNames)
            {
                string s = "name :" + item.Key + "\n \nLignes disponibles : \n";
                foreach (string line in item.Value)
                {
                    s += line+ "\n";
                }
                Console.WriteLine(s);
            }

            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        public void doRequestLignes(string uri)
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create(uri);
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            List<LigneTransport> dataLignes = JsonConvert.DeserializeObject<List<LigneTransport>>(responseFromServer);
            foreach (var item in dataLignes)
            {
                string s = String.Format("name :{0} \n \nMode de transport :{1} ", item.longName, item.longName);

                Console.WriteLine();
            }

            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
        }
        public void doRequestDetails(string uri)
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create(uri);
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
           
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }

}
