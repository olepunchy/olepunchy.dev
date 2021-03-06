// using System;
using System.Collections.Generic;
// using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using olepunchy.Blog.Model;

namespace olepunchy.Blog {
    public class PostService {

        public IEnumerable<PostModel> Posts { get; private set; }

        public PostService() {
            Task.Run(LoadPostDataFromJson);
        }

        public async Task<IEnumerable<PostModel>> LoadPostDataFromJson() {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            Posts = await client.GetFromJsonAsync<IEnumerable<PostModel>>("https://olepunchy.dev/data/blog-data.json");

            if (Posts != null) {
                foreach (var post in Posts) {
                    post.Tags = string.Join<string>(",", post.Keywords);
                }
            }

            return Posts;
        }

        public PostModel LoadPostFromSlug(string slug) {
            return Posts.FirstOrDefault(s => s.Slug == slug);
        }

        public PostModel LoadPostWithId(int id) {
            var p = Posts.FirstOrDefault(x => x.Id == id);

            return p;
        }
    }
}
