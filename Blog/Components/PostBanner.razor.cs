using Microsoft.AspNetCore.Components;
using olepunchy.Blog.Model;

namespace olepunchy.Blog.Components {
    public partial class PostBanner : ComponentBase {
        [Parameter] public PostModel Post { get; set; }
        [Parameter] public EventCallback<PostModel> OnSelected { get; set; }
    }
}