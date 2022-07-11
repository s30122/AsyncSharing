using System;
using System.Net;

namespace EAP_Mode
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var webClient = new WebClient();
            
            webClient.DownloadStringCompleted += OnWebClientOnDownloadStringCompleted;
            webClient.DownloadStringAsync(new Uri("http://www.google.com"));
            
            Console.ReadLine();
            Console.WriteLine("end");
        }

        private static void OnWebClientOnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs eventArgs)
        {
            var result = eventArgs.Result;
            Console.WriteLine("get result");
            // Console.WriteLine(result);
        }
    }
}