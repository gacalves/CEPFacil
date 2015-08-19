using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace CEP_Fácil
{
    public class JsonHelper
    {
        public static async void GetJsonString(string url, ICalbackInterface callback)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                WebResponse response = await request.GetResponseAsync();

                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    callback.GetJsonStringCallback(reader.ReadToEnd());
                }
            }
            catch (WebException)
            {
                callback.GetJsonStringCallback("{}");
            }
            
        }

        public static T GetObjectFromJsonString<T>(string json) where T:new()
        {
            
            using (MemoryStream mstream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(mstream);
            }
        }

        public interface ICalbackInterface 
        {
                 void GetJsonStringCallback(string response);
        }
    }
}
