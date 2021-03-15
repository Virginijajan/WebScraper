using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppWebScraper
{
    class Program
    {
        static async Task Main(string[] args)

        {
            //var httpClient = new HttpClient();

            //var httpResponse = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            //if (httpResponse.IsSuccessStatusCode) {

            // var contentString = await httpResponse.Content.ReadAsStringAsync();

            // var posts = JsonConvert.DeserializeObject<List<Post>>(contentString);

            //var filtredPosts = posts.Where(p => p.Id <= 40);

            // foreach (var post in filtredPosts)
            //  {
            // System.Console.WriteLine($"post: {post.Id} {post.Title}");
            // }

            // posts.Where(p=>p.Id<=40).ToList().ForEach(post => System.Console.WriteLine($"post: {post.Id} {post.Title}"));


            //PAVYZDZIAI
            //var users= JsonConvert.DeserializeObject<List<Post>>(contentString)
            //Filtravimas. Jei nerasta grazina 0 arba null
            ///var SamathaUser = users.Where(u => u.Username == "Samantha").Select(u => u.Id).FirstOrdefault();
            //  }



            // Scrapingas pvz.

            ScrapingBrowser browser = new ScrapingBrowser();



            WebPage homePage = browser.NavigateToPage(new Uri("https://www.cvonline.lt/darbo-skelbimai/visi"));

            var html = homePage.Html;

            var nodes = html.CssSelect(".offer_primary_info h2 a");

            var professionNames = nodes.Where(n => n.InnerText.Contains("VADOVAS")).Select(n => n.InnerText);
            foreach(var profession in professionNames)
            {
                System.Console.WriteLine($"Profesija: {profession}");
            }

        }
    }
}
