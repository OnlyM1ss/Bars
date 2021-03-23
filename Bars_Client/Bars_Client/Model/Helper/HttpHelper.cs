using System;
using System.IO;
using System.Net;

namespace Bars_Client.Model
{
    public class HttpHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpWebRequest">web request</param>
        /// <param name="isPost">http Request is Post</param>
        private static void HeaderCreater(WebRequest httpWebRequest, bool isPost)
        {
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = isPost ? "POST" : "GET";
          
        }

        public static string StreamGetter(string url)
        {
            try
            {
                WebRequest httpWebRequest = WebRequest.Create(url);
                httpWebRequest.Proxy = null;
                HeaderCreater(httpWebRequest, false);
                try
                {
                    WebResponse httpResponse = httpWebRequest.GetResponse();

                    Stream stream = httpResponse.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    string outData = sr.ReadToEnd();
                    sr.Close();
                    return outData;
                }
                catch (WebException)
                {
                    //TODO Добавить оповещение об ошибке
                    return null;
                }
            }
            catch (System.UriFormatException)
            {
                //TODO неверный url push 
                throw;
            }
        }

        public static string StreamPoster(string url, string data)
        {
            string result;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HeaderCreater(httpWebRequest, true);
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    using (Stream dataEx = e.Response.GetResponseStream())
                    using (var reader = new StreamReader(dataEx))
                    {
                        string textEx = reader.ReadToEnd() + " - " + e.Message;
                        return textEx;
                    }
                }

                return e.Message;
            }

            return result;
        }
    }
}
