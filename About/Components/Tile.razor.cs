using Microsoft.AspNetCore.Components;

namespace olepunchy.About.Components
{
    public partial class Tile : ComponentBase {
        [Parameter] public string Image { get; set; }
        [Parameter] public string Tooltip { get; set; }
        [Parameter] public string Url { get; set; }
    }
}