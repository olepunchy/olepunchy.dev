using Microsoft.AspNetCore.Components;

namespace olepunchy.Blog {
    public partial class PostBanner : ComponentBase {
        
        
        [Parameter] public PostModel PostModel { get; set; }
        [Parameter] public EventCallback<PostModel> OnSelected { get; set; }
    }
}