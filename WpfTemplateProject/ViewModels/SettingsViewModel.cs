using Caliburn.Micro;

namespace StockJournal.ViewModels
{
    sealed class SettingsViewModel : Screen
    {
        private double _sccpChargePercentage;
        private double _brokersChargePercentage;
        private double _vatPercentage;
        private double _salesTaxPercentage;

        public double SccpChargePercentage
        {
            get => _sccpChargePercentage;
            set => Set(ref _sccpChargePercentage, value);
        }

        public double BrokersChargePercentage
        {
            get => _brokersChargePercentage;
            set => Set(ref _brokersChargePercentage, value);
        }

        public void Save()
        {
            Properties.Settings.Default.BrokersChargePercentage = BrokersChargePercentage;
            Properties.Settings.Default.SccpChargePercentage = SccpChargePercentage;
            Properties.Settings.Default.Save();
        }

        protected override void OnViewReady(object view)
        {
            SccpChargePercentage = Properties.Settings.Default.SccpChargePercentage;
            BrokersChargePercentage = Properties.Settings.Default.BrokersChargePercentage;

            SalesTaxPercentage = Properties.Settings.Default.SalesTaxPercentage;
            VatPercentage = Properties.Settings.Default.VatPercentage;
        }

        public double VatPercentage
        {
            get => _vatPercentage;
            set => Set(ref _vatPercentage, value);
        }

        public double SalesTaxPercentage
        {
            get => _salesTaxPercentage;
            set => Set(ref _salesTaxPercentage, value);
        }

        public void Close()
        {
            TryClose();
        }
    }
}
