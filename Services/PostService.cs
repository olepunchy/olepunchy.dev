using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using olepunchy.Models;

namespace olepunchy.Services {
    public class PostService {

        public IEnumerable<Post> Posts { get; private set; }

        private HttpClient HttpClient { get; set; } = new();

        public PostService() {
            Task.Run(LoadPostDataFromJson);
        }
        
        // public static async Task<PostService> CreateAsync() {
        //     PostService postService= new PostService();
        //     await postService.LoadPostDataFromJson();
        //     return postService;
        // }

        private async Task LoadPostDataFromJson() {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);
            
                
            // Posts = await HttpClient.GetFromJsonAsync<IEnumerable<Post>>("https://localhost:5001/data/blog-data.json");
            Posts = await client.GetFromJsonAsync<IEnumerable<Post>>("https://localhost:5001/data/blog-data.json");

            if (Posts != null) {
                foreach (var post in Posts) {
                    GetHtmlFromFile(post);
                    GetCreatedDate(post);
                }
            }
        }
        
         private void GetHtmlFromFile(Post post) {
             string markdown = File.ReadAllText(post.File);

             post.Html = MarkdownToHtml(markdown);
         }

         private void GetCreatedDate(Post post) {
             post.Created = File.GetCreationTime(post.File);
         }
         
        private string MarkdownToHtml(string markdown) {
            var pipeline = new Markdig.MarkdownPipelineBuilder().Build();
        
            return Markdig.Markdown.ToHtml(markdown, pipeline);
        }
    }
}
