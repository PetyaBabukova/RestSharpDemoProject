using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;

namespace RestSharpDemoProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestClient client = new RestClient("https://api.github.com"); //Host

            //Get single issue
            /*RestRequest request = new RestRequest("/repos/petyababukova/postman/issues/41", Method.Get); //Path

            var response = client.Execute(request);

            //Console.WriteLine("STATUS CODE: " + response.StatusCode);
            //Console.WriteLine("RESPONSE: " + response.Content);
            
            var issue = JsonSerializer.Deserialize<Issue>(response.Content);
            Console.WriteLine("Issue name: " + issue.title);
            Console.WriteLine("Issue number: " + issue.number);*/




            //Get labels
            /*RestRequest requestAllIssuesLabels = new RestRequest("/repos/petyababukova/postman/issues/41/labels", Method.Get); //Path
            var responseLabels = client.Execute(requestAllIssuesLabels);

            var labels = JsonSerializer.Deserialize<List<Labels>>(responseLabels.Content);

            foreach (var label in labels)
            {
                Console.WriteLine("Label name: " + label.name);
                Console.WriteLine("Label ID: " + label.id);
                Console.WriteLine();
            }*/




            //Get All issues
            /*RestRequest requestAllIssues = new RestRequest("/repos/petyababukova/postman/issues", Method.Get); //Path

            var responseAll = client.Execute(requestAllIssues);

            var issuesAll = JsonSerializer.Deserialize<List<Issue>>(responseAll.Content);


            foreach (var issueAll in issuesAll)
            {
                Console.WriteLine("Issue name: " + issueAll.title);
                Console.WriteLine("Issue number: " + issueAll.number);
            }*/





            //Get All issues with segment
            /* RestRequest requestAllIssues = new RestRequest("/repos/{user}/{repoName}/issues", Method.Get); //Path
             requestAllIssues.AddUrlSegment("user", "petyababukova"); //segment
             requestAllIssues.AddUrlSegment("repoName", "postman"); //segment

             var responseAll = client.Execute(requestAllIssues);

             var issuesAll = JsonSerializer.Deserialize<List<Issue>>(responseAll.Content);


             foreach (var issueAll in issuesAll)
             {
                 Console.WriteLine("Issue name: " + issueAll.title);
                 Console.WriteLine("Issue number: " + issueAll.number);
                 Console.WriteLine();
             }*/


            //Create new issue
            RestRequest request = new RestRequest("/repos/{user}/{repoName}/issues", Method.Post); //Path
            request.AddUrlSegment("user", "petyababukova"); //segment
            request.AddUrlSegment("repoName", "postman"); //segment

            client.Authenticator = new HttpBasicAuthenticator("petyababukova", "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"); //This is the better way but we can also add Header and put in it Autorization instead of this.

            var issueBody = new
            {
                title = "Test from RestSharp " + DateTime.Now.Ticks,
                body = "Some description on my body issue",
                labels = new string[] {"bug", "My label", "critical" }
            };

            request.AddBody(issueBody);

            var response = client.Execute(request);


            var issue = JsonSerializer.Deserialize<Issue>(response.Content);

            Console.WriteLine("STATUS CODE: " + response.StatusCode);
            Console.WriteLine("Issue name: " + issue.title);
            Console.WriteLine("Issue number: " + issue.number);
            Console.WriteLine();
        }
    }
}