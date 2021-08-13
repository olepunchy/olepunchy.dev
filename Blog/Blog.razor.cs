using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using olepunchy.Services;

namespace olepunchy.Blog {
    public partial class Blog : ComponentBase {

        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private PostService PostService { get; set; }
        
        private IEnumerable<PostModel> _posts;
        private PostModel SelectedPostModel { get; set; }

        protected override async Task OnInitializedAsync() {
            try {
                _posts = await PostService.LoadPostDataFromJson();
            } catch (HttpRequestException exception) {
                Console.WriteLine($"There was an exception loading data: {exception.Message}");
            }
        }

        private void SelectedPost(PostModel postModel) {
            SelectedPostModel = postModel;
            NavigationManager.NavigateTo($"/blog/{postModel.Slug}");
        }
    }
}