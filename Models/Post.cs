using System;
using System.Collections.Generic;

namespace olepunchy.Models {

    public class Post {

        public DateTime Created { get; set; }
        public string Markdown { get; set; }
        public string Html { get; set; }
        public string Title { get; set; }
        public List<string> Tags { get; set; } = new();
        public string Slug { get; set; }
    }
}
