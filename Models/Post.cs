using System;
using System.Collections.Generic;

namespace olepunchy.Models {

    public class Post {
        public int Id { get; set; }
        public string File { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string Html { get; set; }
        public List<string> Tags { get; set; }
    // "id": 1,
    // "file": "md/001.md",
    // "image": "img/blazor.svg",
    // "title": "Getting Started with Blazor on Linux",
    // "slug": "getting_started_with_blazor_on_linux",
    // "author": "Jeremy Novak",
    // "created": ""
        // public string Image { get; set; }
        // public DateTime Created { get; set; }
        // public string Markdown { get; set; }
        // public string Html { get; set; }
        // public string Title { get; set; }
        // public List<string> Tags { get; set; } = new();
        // public string Slug { get; set; }
    }
}
