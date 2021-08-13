using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using olepunchy.Models;

namespace olepunchy.Services {
    public class PostService {

        public IEnumerable<Post> Posts { get; private set; }

        private HttpClient HttpClient { get; set; }

        private PostService() {
            LoadPostDataFromJson();
        }
        
        private async Task LoadPostDataFromJson() {
          Posts = await HttpClient.GetFromJsonAsync<IEnumerable<Post>>("https://localhost:5001/data/blog-data.json");
        }
        
         private void GetHtmlFromFile(Post post) {
             string markdown = File.ReadAllText(post.File);

             post.Html = MarkdownToHtml(markdown);
         }
         
        private string MarkdownToHtml(string markdown) {
            var pipeline = new Markdig.MarkdownPipelineBuilder().Build();
        
            return Markdig.Markdown.ToHtml(markdown, pipeline);
        
        }
    }
}



// using System;
// using System.IO;
// using System.Collections.Generic;
// using System.Linq;
// using olepunchy.Models;
// using System.Text.RegularExpressions;
//
// namespace olepunchy.Services {
//
//     public class PostService {
//
//         private const string POST_PATH = "Markdown";
//         private const string POST_EXT = "*.md";
//
//         public List<Post> Posts { get; set; } = new();
//
//         public PostService() {
//             LoadPosts();
//             SortPosts();
//         }
//
//         private void LoadPosts() {
//
//             foreach (string file in Directory.EnumerateFiles(POST_PATH, POST_EXT)) {
//
//                 Post post = GetPostFromFile(file);
//
//                 Posts.Add(post);
//             }
//         }
//
//         private void SortPosts() {
//             // Sorts posts so most recent are at the top.
//             Posts = new List<Post>(Posts.OrderByDescending(p => p.Created.Millisecond));
//         }
//
//         private Post GetPostFromFile(string file) {
//
//             string contents = File.ReadAllText(file);
//
//             Post post = new Post();
//             post.Image = GetImageFromFile(file);
//             post.Markdown = contents;
//             post.Html = MarkdownToHtml(post.Markdown);
//
//             post.Created = File.GetCreationTime(file);
//             post.Title = GetTitleFromFile(file);
//             post.Slug = GetSlugFromTitle(post.Title);
//
//             return post;
//         }
//
//         private string GetImageFromFile(string file) {
//             string image = File.ReadLines(file).ElementAtOrDefault(1);
//             image = RemoveSpecialCharacters(image);
//
//             return image;
//         }
//
//         private string MarkdownToHtml(string markdown) {
//             var pipeline = new Markdig.MarkdownPipelineBuilder().Build();
//
//             return Markdig.Markdown.ToHtml(markdown, pipeline);
//
//         }
//
//         private string GetTitleFromFile(string file) {
//             var title = File.ReadLines(file).First();
//             title = title.Substring(1);
//             title = title.TrimStart();
//
//             return title;
//         }
//
//         private string GetSlugFromTitle(string title) {
//             var slug = title.Replace(" ", "_");
//             slug = RemoveSpecialCharacters(slug);
//             slug = slug.ToLower();
//
//             return slug;
//         }
//
//         private string RemoveSpecialCharacters(string aString) {
//             // Limit the string to alphanumeric characters and underscore
//             return Regex.Replace(aString, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
//         }
//
//         private void DebugPrintAvailablePosts() {
//             foreach (var post in Posts) {
//                 Console.WriteLine($"Created: {post.Created.ToString()}, Title: {post.Title}, Markdown: {post.Markdown}, HTML: {post.Html}");
//             }
//         }
//     }
// }
