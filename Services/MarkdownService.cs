using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using olepunchy.Models;

namespace olepunchy.Services {

    public class MarkdownService {

        public List<Post> Posts { get; set; } = new();


        // NOTE: Read all of the markdown files
        public void ReadMarkdownFiles() {

            foreach (string file in Directory.EnumerateFiles("Blog/Markdown", "*.md")) {

                Post post = GetPostFromFile(file);

                Posts.Add(post);
            }
        }

        // TODO: Simple debug function that prints the posts
        public void DebugPrintAvailablePosts() {
            foreach (var post in Posts) {
                Console.WriteLine($"Created: {post.Created}, Title: {post.Title}, Content: {post.Markdown}");
            }
        }

        private Post GetPostFromFile(string file) {

            string contents = File.ReadAllText(file);

            Post post = new Post();
            post.Markdown = contents;
            post.Html = ConvertMarkDownToHtml(post.Markdown);

            post.Created = File.GetCreationTime(file);
            post.Title = GetTitleFromFile(file);

            return post;
        }

        private string ConvertMarkDownToHtml(string markdown) {
            var pipeline = new Markdig.MarkdownPipelineBuilder().Build();

            return Markdig.Markdown.ToHtml(markdown, pipeline);

        }

        private string GetTitleFromFile(string file) {
            var title = File.ReadLines(file).First();
            title = title.Substring(1);
            title = title.TrimStart();

            return title;
        }
    }
}
