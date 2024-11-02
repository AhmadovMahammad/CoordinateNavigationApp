using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoordinateNavigation.Events;
using CoordinateNavigation.MVVM.Models;
using CoordinateNavigation.Services.Interfaces;
using System.Windows;
using CoordinateNavigation.Constants.Enums;

namespace CoordinateNavigation.MVVM.ViewModels
{
    public partial class CoordinateViewModel : ObservableObject
    {
        private readonly IEventAggregator _eventAggregator;

        [ObservableProperty] private bool _isDmsCoordinate;
        [ObservableProperty] private bool _isActiveAutoConversion = true;
        [ObservableProperty] private BaseCoordinateViewModel _decimalCoordinate;
        [ObservableProperty] private BaseCoordinateViewModel _dmsCoordinate;

        public RelayCommand? ToggleCoordinateTypeCommand { get; private set; }
        public RelayCommand? ConvertCoordinateCommand { get; private set; }
        public RelayCommand? CopyCoordinateCommand { get; private set; }
        public RelayCommand? ViewInMapCommand { get; private set; }
        public RelayCommand? ClearFieldsCommand { get; private set; }
        public RelayCommand? ToggleAutoConversionCommand { get; private set; }

        public CoordinateViewModel(IEventAggregator eventAggregator, ICoordinateService coordinateService)
        {
            _eventAggregator = eventAggregator;

            DecimalCoordinate = new DecimalCoordinateViewModel(eventAggregator, coordinateService);
            DmsCoordinate = new DmsCoordinateViewModel(eventAggregator, coordinateService);

            _eventAggregator.Subscribe<CoordinateChangedEvent>(OnCoordinateChanged);
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
            ToggleAutoConversionCommand = new RelayCommand(OnToggleAutoConversionClicked);
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

        private void OnToggleAutoConversionClicked()
        {
            IsActiveAutoConversion = !IsActiveAutoConversion;

            if (IsActiveAutoConversion) _eventAggregator.Subscribe<CoordinateChangedEvent>(OnCoordinateChanged);
            else _eventAggregator.Unsubscribe<CoordinateChangedEvent>(OnCoordinateChanged);
        }

        // event actions
        private void OnCoordinateChanged(CoordinateChangedEvent coordinateChangedEvent)
        {
            Coordinate coordinate = coordinateChangedEvent.Coordinate;
            if (IsDmsCoordinate != (coordinate.CordFormat == CoordinateFormat.DMS)) return;

            OnConvertCoordinateClicked();
        }
    }
}
