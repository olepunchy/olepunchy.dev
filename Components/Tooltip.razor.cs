using System.Dynamic;
using Microsoft.AspNetCore.Components;
using olepunchy.Enums;

namespace olepunchy.Components {
    public partial class Tooltip : ComponentBase {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Text { get; set; }
        [Parameter] public TooltipEnum Type { get; set; }

        public string TooltipClass { get; set; }

        protected override void OnInitialized() {
            switch (Type) {
                case TooltipEnum.Top:
                    TooltipClass = "top";
                    break;
                
                case TooltipEnum.Bottom:
                    TooltipClass = "bottom";
                    break;
                
                case TooltipEnum.Left:
                    TooltipClass = "left";
                    break;
                
                case TooltipEnum.Right:
                    TooltipClass = "right";
                    break;
                
                default:
                    TooltipClass = "top";
                    break;
            }
        }
    }
}