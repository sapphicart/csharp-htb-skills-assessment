// See https://aka.ms/new-console-template for more information
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Assessment;

class Program 
{
    static void Main(string[] args)
    {
        Assessment.Words assessmentWords = new Words();
        List<string> words = assessmentWords.GetWordList().ToList();

        async Task Main(string url)
        {
            try
            {
                foreach(string word in words)
                {
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync($"http://{url}/{words}/flag.txt");
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine($"File found at:{words}");
                        break;
                    }
                    else 
                    {
                        continue;
                    }
                }
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("Exception Caught!");
                Console.WriteLine($"Message: {e.Message}");
            }
        }

        Task newUrl = Main("10.129.205.211");
    } 
}
