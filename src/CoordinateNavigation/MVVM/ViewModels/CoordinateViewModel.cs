using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoordinateNavigation.MVVM.ViewModels
{
    public partial class CoordinateViewModel : ObservableObject
    {

        [ObservableProperty] private bool _isDmsCoordinate;

        public RelayCommand? ToggleCoordinateTypeCommand { get; private set; }
        public RelayCommand? CopyCoordinateCommand { get; private set; }
        public RelayCommand? ViewInMapCommand { get; private set; }
        public RelayCommand? ClearCommand { get; private set; }
        public RelayCommand? SaveCommand { get; private set; }

        public CoordinateViewModel()
        {
            InitializeCommands();
        }

        public string Title => IsDmsCoordinate ? "DMS to DD Converter" : "DD to DMS Converter";

        private void InitializeCommands()
        {
            ToggleCoordinateTypeCommand = new RelayCommand(OnCoordinateTypeToggled);
        }

        private void OnCoordinateTypeToggled()
        {
            IsDmsCoordinate = !IsDmsCoordinate;
            OnPropertyChanged(nameof(Title));
        }
    }
}
