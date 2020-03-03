using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //W sytuacji kiedy parametr 1 nie został przekazany, powinniśmy zgłosić błąd ArgumentNullException
            if (args.Length > 0) {

                foreach (var a in args)
                {
                    //W sytuacji kiedy przekazany parametr nie jest poprawnym adresem URL, powinniśmy zgłosić ArgumentException()
                    if (await IsValidURL(a))
                    {
                        Console.WriteLine(a);
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }

                var emails = await GetEmails(args[1]);
                //var emails = await GetEmails("https://www.pja.edu.pl/");

                foreach (var email in emails)
                {
                    Console.WriteLine(email);
                }

            }
            else
            {
                throw new ArgumentNullException();
            }
            
        }

        static async Task<bool> IsValidURL(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }

        static async Task<IList<string>> GetEmails(string url)
        {
            var httpClient = new HttpClient();
            var listOfEmails = new List<string>();
            HttpResponseMessage response = null;

            //W sytuacji kiedy podczas pobierania wystąpił błąd - wyświetlamy informację "Błąd w czasie pobierania strony".
            try
            {
                response = await httpClient.GetAsync(url);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nBłąd w czasie pobierania strony");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            //Powinniśmy w poprawny sposób zwalniać zasoby (wykorzystanie metody Dispose()) związane z wykorzystaniem klasy HttpClient
            string responseBody = await response.Content.ReadAsStringAsync();
            response.Dispose();

            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",  RegexOptions.IgnoreCase);
            //find items that matches with our pattern
            MatchCollection emailMatches = emailRegex.Matches(responseBody);

            if (emailMatches.Count == 0)
            {
                Console.WriteLine("Nie znaleziono adresów email");
            }

            foreach (var emailMatche in emailMatches)
            {
                if (!listOfEmails.Contains(emailMatche.ToString()))
                {
                    listOfEmails.Add(emailMatche.ToString());
                }
            }
                
            return listOfEmails;
        }
    }
}
