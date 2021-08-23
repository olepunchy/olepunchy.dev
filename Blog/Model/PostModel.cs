using System;
using System.Collections.Generic;

namespace olepunchy.Blog.Model {
    public class PostModel {
        public int Id { get; set; } 
        public string Url { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Tags { get; set; }
        public List<string> Keywords { get; set; }
        public string Author { get; set;  }
        public DateTime Created { get; set; }
    }
}
