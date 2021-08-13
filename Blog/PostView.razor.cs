using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using olepunchy.Services;

namespace olepunchy.Blog {
    public partial class PostView : ComponentBase {
       [Inject] private PostService PostService { get; set; }
       [Parameter] public string Slug { get; set; }
       private PostModel PostModel { get; set; } = new();
       private MarkupString Body { get; set; }

       protected override async Task OnInitializedAsync() {
           await LoadPost();
       }

       private async Task LoadPost() {
           PostModel = PostService.LoadPostFromSlug(Slug);
           Body = (MarkupString)MarkdownToHtml(PostModel.Markdown);
           await Task.CompletedTask;
       }
       
       private string MarkdownToHtml(string markdown) {
           var pipeline = new Markdig.MarkdownPipelineBuilder().Build();
        
           return Markdig.Markdown.ToHtml(markdown, pipeline);
       }
    }
}