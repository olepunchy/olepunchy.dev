using Microsoft.AspNetCore.Components;
using olepunchy.Blog.Model;

namespace olepunchy.Blog.Components {
    public partial class PostFooter: ComponentBase {
       [Parameter] public PostModel Post { get; set; } 
    }
}