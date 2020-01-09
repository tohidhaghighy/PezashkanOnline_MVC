using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace UrumiumWithIdentity.Controllers
{
    public partial class SendMessageController : Controller
    {
        public SendMessageController()
        {

        }

        public string SendMessage()
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAgS7y_HA:APA91bFgf5xhAk6LqpZaC_QWz3PLjDgROTb6jy2lru39ZxZI1tLW1fG-G6REA0zY9E62DKbL76lMPZMIXPSLrSRPxhiaIR8aRLUsVSvKcoWXYS6L37kqar0ejfSPrfhyzIk6SdKA8pjA"));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender: id={0}", "554838457456"));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                to = "e8EHtMwqsZY:APA91bFUktufXdsDLdXXXXXX..........XXXXXXXXXXXXXX",
                priority = "high",
                content_available = true,
                notification = new
                {
                    body = "Test",
                    title = "Test",
                    badge = 1
                },
            };

            string postbody = JsonConvert.SerializeObject(payload).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                //result.Response = sResponseFromServer;
                            }
                    }
                }
            }
            return "";
        }
    }
}