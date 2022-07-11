using System;
using System.IO;
using System.Net;

namespace APM_Mode
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var webRequest = WebRequest.Create("http://www.google.com");
            webRequest.BeginGetResponse(MyCallBack,webRequest);
            Console.ReadLine();
            Console.WriteLine("end");
        }

        static void MyCallBack(IAsyncResult asyncResult)
        {
            var request = asyncResult.AsyncState as WebRequest;
            var response = request.EndGetResponse(asyncResult);
            var receiveStream = response.GetResponseStream();
            var reader = new StreamReader(receiveStream);
            var result = reader.ReadToEnd();
            Console.WriteLine("get result");
            // Console.WriteLine(result);
        }
    }
}