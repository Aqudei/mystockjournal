using Caliburn.Micro;

namespace StockJournal.ViewModels
{
    sealed class ShellViewModel : Conductor<object>.Collection.OneActive
    {
        private readonly IWindowManager _windowManager;

        public ShellViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;

            ActivateItem(IoC.Get<StockListViewModel>());
        }

        public void OpenSettings()
        {
            _windowManager.ShowDialog(IoC.Get<SettingsViewModel>());
        }
    }
}
