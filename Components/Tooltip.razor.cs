using Microsoft.AspNetCore.Components;

namespace olepunchy.Components {
    public partial class Tooltip : ComponentBase {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Text { get; set; }
    }
}