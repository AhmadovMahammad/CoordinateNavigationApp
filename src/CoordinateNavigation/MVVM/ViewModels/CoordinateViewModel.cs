using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoordinateNavigation.Services.Interfaces;
using System.Windows;

namespace CoordinateNavigation.MVVM.ViewModels
{
    public partial class CoordinateViewModel : ObservableObject
    {
        [ObservableProperty] private bool _isDmsCoordinate;
        [ObservableProperty] private BaseCoordinateViewModel _decimalCoordinate;
        [ObservableProperty] private BaseCoordinateViewModel _dmsCoordinate;

        public RelayCommand? ToggleCoordinateTypeCommand { get; private set; }
        public RelayCommand? ConvertCoordinateCommand { get; private set; }
        public RelayCommand? CopyCoordinateCommand { get; private set; }
        public RelayCommand? ViewInMapCommand { get; private set; }
        public RelayCommand? ClearFieldsCommand { get; private set; }

        public CoordinateViewModel(ICoordinateService coordinateService)
        {
            DecimalCoordinate = new DecimalCoordinateViewModel(coordinateService);
            DmsCoordinate = new DmsCoordinateViewModel(coordinateService);

            InitializeCommands();
        }

        public string Title => IsDmsCoordinate ? "DMS to DD Converter" : "DD to DMS Converter";

        private void InitializeCommands()
        {
            ToggleCoordinateTypeCommand = new RelayCommand(OnCoordinateTypeToggled);
            ConvertCoordinateCommand = new RelayCommand(OnConvertCoordinateClicked);
            CopyCoordinateCommand = new RelayCommand(OnCopyCoordinateClicked);
            ViewInMapCommand = new RelayCommand(OnViewInMapClicked);
            ClearFieldsCommand = new RelayCommand(OnClearFieldsClicked);
        }

        private void OnCoordinateTypeToggled()
        {
            IsDmsCoordinate = !IsDmsCoordinate;
            OnPropertyChanged(nameof(Title));
        }

        private void OnConvertCoordinateClicked()
        {
            if (IsDmsCoordinate) DecimalCoordinate.ConvertFromOpposite(DmsCoordinate.Latitude, DmsCoordinate.Longitude);
            else DmsCoordinate.ConvertFromOpposite(DecimalCoordinate.Latitude, DecimalCoordinate.Longitude);
        }

        private void OnCopyCoordinateClicked()
        {
            #region GUIDE
            //DMS Format:
            //    Latitude: N 37° 48' 25"
            //    Longitude: W 122° 25' 10"

            //DD Format:
            //    Latitude: N 37.80694°
            //    Longitude: W 122.41944°
            #endregion

            string composite = IsDmsCoordinate switch
            {
                true => DmsCoordinate.GetCoordinateComposite(),
                false => DecimalCoordinate.GetCoordinateComposite(),
            };

            try
            {
                if (!string.IsNullOrWhiteSpace(composite))
                {
                    Clipboard.SetText(composite);
                }
            }
            catch (Exception)
            {

            }
        }

        private void OnViewInMapClicked()
        {

        }

        private void OnClearFieldsClicked()
        {
            DecimalCoordinate.ClearFields();
            DmsCoordinate.ClearFields();
        }
    }
}
