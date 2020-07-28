using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BrowserStackTool
{
    namespace RestApi
    {
        class ChangeSessionStatus
        {
            static void Main(string[] args)
            {
                string reqString = "{\"status\":\"completed\", \"reason\":\"\"}";

                byte[] requestData = Encoding.UTF8.GetBytes(reqString);
                Uri myUri = new Uri(string.Format("https://www.browserstack.com/automate/sessions/<session-id>.json"));
                WebRequest myWebRequest = HttpWebRequest.Create(myUri);
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
                myWebRequest.ContentType = "application/json";
                myWebRequest.Method = "PUT";
                myWebRequest.ContentLength = requestData.Length;
                using (Stream st = myWebRequest.GetRequestStream()) st.Write(requestData, 0, requestData.Length);

                NetworkCredential myNetworkCredential = new NetworkCredential("nitikeshshinde1", "uc3UYQeFncE1xcsSxnjq");
                CredentialCache myCredentialCache = new CredentialCache();
                myCredentialCache.Add(myUri, "Basic", myNetworkCredential);
                myHttpWebRequest.PreAuthenticate = true;
                myHttpWebRequest.Credentials = myCredentialCache;
                myWebRequest.GetResponse().Close();
            }
        }
    }
}
