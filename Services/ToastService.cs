using System;
using System.Timers;
using olepunchy.Enums;

namespace olepunchy.Services {
    public class ToastService : IDisposable {
        public event Action<string, ToastEnum> OnShow;
        public event Action OnHide;

        private Timer _countDown;
        
        public void ShowToast(string message, ToastEnum level) {
            OnShow?.Invoke(message, level);
            StartCountDown();
            Console.WriteLine("Showing Toast!");
        }

        private void StartCountDown() {
            SetCountDown();

            if (_countDown.Enabled) {
                _countDown.Stop();
                _countDown.Start();
            } else {
                _countDown.Start();
            }
        }

        private void SetCountDown() {
            if (_countDown == null) {
                _countDown = new Timer(5000);
                _countDown.Elapsed += HideToast;
                _countDown.AutoReset = false;
            }
        }

        private void HideToast(object sender, ElapsedEventArgs eventArgs) {
            OnHide?.Invoke();
        }

        public void Dispose() {
            _countDown?.Dispose();
        }
    }
}