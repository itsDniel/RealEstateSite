using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RealEstateClassLibary
{
    public class RestfulWebRequest
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        WebRequest request;
        WebResponse response;

        private String ReadData(WebResponse response)
        {
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return data;
        }

        public List<House> GetHouseWR(String url)
        {   // Read the data from the Web Response, which requires working with streams.
            request = WebRequest.Create(url);
            String data = ReadData(request.GetResponse());
            return js.Deserialize<List<House>>(data);
        }
        public List<Room> GetRoomWR(String url)
        {   // Read the data from the Web Response, which requires working with streams.
            request = WebRequest.Create(url);
            String data = ReadData(request.GetResponse());
            return js.Deserialize<List<Room>>(data);
        }

        public String PostWebRequest(String url, String jsonObj)
        {
            request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = jsonObj.Length;
            request.ContentType = "application/json";

            // Write the JSON data to the Web Request
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(jsonObj);
            writer.Flush();
            writer.Close();

            // Read the data from the Web Response, which requires working with streams.
            response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return data;
        }
    }
}
