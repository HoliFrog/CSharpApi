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
            List<LigneTransport> dataLignes = JsonConvert.DeserializeObject<List<LigneTransport>>(responseFromServer);
            Dictionary<string, List<String>> ListWithOutDuplicates = new Dictionary<string, List<String>>();
            foreach (var item in dataLignes)
            {
                if (!ListWithOutDuplicates.ContainsKey(item.id))
                {
                    //ListWithOutDuplicates.Add(item.id, item);
                }
            }
            
            foreach (var item in dataLignes)
            {
                Console.WriteLine(item.longName);
            }
            List<TagCloserToYou> data = JsonConvert.DeserializeObject<List<TagCloserToYou>>(responseFromServer);
            foreach (TagCloserToYou item in data)
            {
                string s = "name :" + item.name + "\n \nLignes disponibles : \n";
                foreach (string line in item.lines)
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

                Console.WriteLine(s);
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
