using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Assessment;

class Program 
{
    static async Task Main(string[] args)
    {
        Assessment.Words assessmentWords = new Words();
        List<string> words = assessmentWords.GetWordList().ToList();

        try
        {
            foreach(string word in words)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync($"http://{args[0]}/{word}/flag.txt");
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine($"File found at: http://{args[0]}/{word}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Error {(int)response.StatusCode} at: http://{args[0]}/{word}");
                }
            }
        }
        catch(HttpRequestException e)
        {
            Console.WriteLine("Exception Caught!");
            Console.WriteLine($"Message: {e.Message}");
        }
    } 
}