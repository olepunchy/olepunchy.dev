using System;
using Microsoft.AspNetCore.Components;
using olepunchy.Enums;
using olepunchy.Services;

namespace olepunchy.Components {
    public class ToastBase: ComponentBase, IDisposable {

        [Inject] ToastService ToastService { get; set; }
        protected string Heading { get; set; }
        protected string Message { get; set; }
        protected bool IsVisible { get; set; }
        protected string BackgroundCssClass { get; set; }
        protected string IconCssClass { get; set; }

        protected override void OnInitialized() {
            ToastService.OnShow += ShowToast;
            ToastService.OnHide += HideToast;
        }

        private void ShowToast(string message, ToastEnum level) {
           BuildToastSettings(message, level);
           IsVisible = true;
           StateHasChanged();
        }

        private void HideToast() {
            IsVisible = false;
            StateHasChanged();
        }

        private void BuildToastSettings(string message, ToastEnum level) {
            switch (level) {
               case ToastEnum.Info:
                   BackgroundCssClass = "bg-info";
                   IconCssClass = "info";
                   Heading = "Info";
                   break;
               
               case ToastEnum.Success:
                   BackgroundCssClass = "bg-success";
                   IconCssClass = "check";
                   Heading = "Success";
                   break;
               
               case ToastEnum.Warning:
                   BackgroundCssClass = "bg-warning";
                   IconCssClass = "exclamation";
                   Heading = "Warning";
                   break;
               
               case ToastEnum.Error:
                   BackgroundCssClass = "bg-danger";
                   IconCssClass = "times";
                   Heading = "Error";
                   break;
            }

            Message = message;
        }

        public void Dispose() {
            ToastService.OnShow -= ShowToast;
        }
    }
}