using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace olepunchy.Blog {
    public class PostService {

        public IEnumerable<PostModel> Posts { get; private set; }

        // private HttpClient HttpClient { get; set; } = new();

        public PostService() {
            Task.Run(LoadPostDataFromJson);
        }

        // public async Task LoadPostDataFromJson() {
        public async Task<IEnumerable<PostModel>> LoadPostDataFromJson() {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);
            
                
            // Posts = await HttpClient.GetFromJsonAsync<IEnumerable<Post>>("https://localhost:5001/data/blog-data.json");
            Posts = await client.GetFromJsonAsync<IEnumerable<PostModel>>("https://localhost:5001/data/blog-data.json");
            // Posts = await client.GetFromJsonAsync<IEnumerable<PostModel>>("https://reata.olepunchy.io/json/blog-data.json");

            if (Posts != null) {
                foreach (var post in Posts) {
                    // GetHtmlFromFile(post);
                    post.Tags = string.Join<string>(",", post.Keywords);
                    GetMarkdownFromFile(post);
                    GetCreatedDate(post);
                }
            }

            return Posts;
        }

        public PostModel LoadPostFromSlug(string slug) {
            return Posts.FirstOrDefault(s => s.Slug == slug);
        }

        private void GetMarkdownFromFile(PostModel post) {
            post.Markdown = File.ReadAllText(post.File);
        }

         private void GetCreatedDate(PostModel post) {
             post.Created = File.GetCreationTime(post.File);
         }
    }
}
