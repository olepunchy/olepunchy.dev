using Microsoft.AspNetCore.Components;
using olepunchy.Blog.Model;
using olepunchy.Blog.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace olepunchy.Blog.Posts {

    public partial class BlazorOnLinux : ComponentBase {

        [Parameter] public PostModel Post { get; set; }

        [Inject] private IJSRuntime JsRuntime { get; set; }

        protected override void OnInitialized() {
            Post = new PostModel() {
                Author = "Jeremy Novak",
                Created = "08-21-21",
                Title = "Getting Started with Blazor on Linux",
                Tags = "dotnet, linux, blazor",
                Url = "/blog/blazor_on_linux",
                Slug = "blazor_on_linux",
                Image = "img/blazor.svg"
            };
        }

        protected override async Task OnAfterRenderAsync(bool firstRender) {
            await JsRuntime.InvokeVoidAsync("highlightSnippet");
        }

    }

}
