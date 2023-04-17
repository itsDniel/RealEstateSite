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

        private String ReadData(WebResponse response)
        {   // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return data;
        }

        private String GetResponse(String url)
        {
            request = WebRequest.Create(url);
            return ReadData(request.GetResponse());
        }

        private String WriteData(String inputData)
        {
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(inputData);
            writer.Flush();
            writer.Close();

            return ReadData(request.GetResponse());
        }

        public List<House> GetHouseWR(String url) { return js.Deserialize<List<House>>(GetResponse(url)); }
       
        public List<Room> GetRoomWR(String url) { return js.Deserialize<List<Room>>(GetResponse(url)); }

        //public HouseSize GetHouseSizeInfo(String url) { return js.Deserialize<HouseSize>(GetResponse(url)); }

        private String PostOrPut(String method, String url, String jsonObj)
        {   //this method can be used for adding houses and adding rooms
            request = WebRequest.Create(url);
            request.Method = method; // "POST";
            request.ContentLength = jsonObj.Length;
            request.ContentType = "application/json";

            // Write the JSON data to the Web Request
            //StreamWriter writer = new StreamWriter(request.GetRequestStream());
            //writer.Write(jsonObj);
            //writer.Flush();
            //writer.Close();

            //return ReadData(request.GetResponse());
            return WriteData(jsonObj);
        }

        public String PostWebRequest(String method, String url, String jsonObj)
        { return PostOrPut(method, url, jsonObj); }

        public String PutWebRequest(String method, String url, String jsonObj) 
        { return PostOrPut(method, url, jsonObj); }

        public String DeleteWebRequest(String url)
        {
            request = WebRequest.Create(url);
            request.Method = "DELETE";
            return ReadData(request.GetResponse()); //boolean in string
        }
    }
}
