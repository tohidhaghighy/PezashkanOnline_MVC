using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace UrumiumWithIdentity.Models
{
    public class SendPayment
    {
        private string GatewaySend = "https://pay.ir/payment/send";
        private string GatewayResult = "https://pay.ir/payment/verify";
        //
        private string Api = "4f6adef9e186a777c1b11ed02393c789";
        private string LocalDoctor = "http://localhost:52029/Visit/ReturnVisitPayment";
        private string LocalJudge = "http://localhost:52029/JVTime/ReturnVisitPayment";
        private string RedirectDoctor = "https://bermuda-darman.ir/Visit/ReturnVisitPayment";
        private string RedirectJudge = "https://bermuda-darman.ir/JVTime/ReturnVisitPayment";

        public string paydoctor(String Amount, int visitid, string illnessid, int doctorid, string date)
        {
            string result = "";
            String post_string = "";
            //RedirectDoctor += ("illnessid=" + illnessid + "&doctorid="+doctorid+"&visitid="+visitid+"&date="+date+"&");
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", Api);
            post_values.Add("amount", Amount);
            post_values.Add("redirect", RedirectDoctor);
            post_values.Add("mobile", "");
            post_values.Add("description", "رزرو وقت پزشک از برمودا درمان");
            post_values.Add("factorNumber", illnessid+","+doctorid+","+visitid+","+date);

            foreach (KeyValuePair<string, string> post_value in post_values)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(GatewaySend);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                result = responseStream.ReadToEnd();
                responseStream.Close();
            }
            return result;
        }

        public string payjudge(String Amount, string illnessid)
        {
            string result = "";
            String post_string = "";
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", Api);
            post_values.Add("amount", Amount);
            post_values.Add("redirect", RedirectJudge);
            post_values.Add("mobile", ""); 
            post_values.Add("description", "رزرو وقت پزشک از برمودا درمان");
            post_values.Add("factorNumber", illnessid);

            foreach (KeyValuePair<string, string> post_value in post_values)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(GatewaySend);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                result = responseStream.ReadToEnd();
                responseStream.Close();
            }
            return result;
        }

        public string paydoctortest(String Amount, int visitid, string illnessid, int doctorid, string date)
        {
            string result = "";
            String post_string = "";
            //RedirectDoctor += ("illnessid=" + illnessid + "&doctorid="+doctorid+"&visitid="+visitid+"&date="+date+"&");
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", "test");
            post_values.Add("amount", Amount);
            post_values.Add("redirect", LocalDoctor);
            post_values.Add("mobile", "");
            post_values.Add("description", "رزرو وقت پزشک از برمودا درمان");
            post_values.Add("factorNumber", illnessid + "," + doctorid + "," + visitid + "," + date);

            foreach (KeyValuePair<string, string> post_value in post_values)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(GatewaySend);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                result = responseStream.ReadToEnd();
                responseStream.Close();
            }
            return result;
        }

        public string payjudgetest(String Amount, string illnessid)
        {
            string result = "";
            String post_string = "";
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", "test");
            post_values.Add("amount", Amount);
            post_values.Add("redirect", LocalJudge);
            post_values.Add("mobile", "");
            post_values.Add("description", "رزرو وقت پزشک از برمودا درمان");
            post_values.Add("factorNumber", illnessid);

            foreach (KeyValuePair<string, string> post_value in post_values)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(GatewaySend);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                result = responseStream.ReadToEnd();
                responseStream.Close();
            }
            return result;
        }

        public string verify(String TransID)
        {
            string result = "";
            String post_string = "";
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", Api);
            post_values.Add("transId", TransID);

            foreach (KeyValuePair<string, string> post_value in post_values)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(GatewayResult);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                result = responseStream.ReadToEnd();
                responseStream.Close();
            }
            return result;
        }

        public string verifytest(String TransID)
        {
            string result = "";
            String post_string = "";
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", "test");
            post_values.Add("transId", TransID);

            foreach (KeyValuePair<string, string> post_value in post_values)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(GatewayResult);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                result = responseStream.ReadToEnd();
                responseStream.Close();
            }
            return result;
        }
    }

    public class JsonParameters
    {
        public int status { get; set; }
        public string transId { get; set; }
        public string factorNumber { get; set; }
        public string description { get; set; }
        public string mobile { get; set; }
        public double amount { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public JsonParameters()
        {

        }
    }
}