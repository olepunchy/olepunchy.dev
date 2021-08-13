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
        public DateTime Created { get; set; }
    }
}
