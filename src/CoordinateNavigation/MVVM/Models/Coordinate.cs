using CoordinateNavigation.Constants.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoordinateNavigation.MVVM.Models
{
    public class Coordinate(bool fromLatitude) : INotifyPropertyChanged
    {
        // Fields
        private double _degrees;
        private double? _minutes;
        private double? _seconds;
        private int _sign;
        private EarthDirection _earthDirection;

        public double Degrees
        {
            get => _degrees;
            set
            {
                double clampedValue = Math.Max(Math.Min(value, MaxDegree), MinDegree);

                if (_degrees != clampedValue)
                {
                    _degrees = clampedValue;

                    if (_degrees == MaxDegree)
                    {
                        _minutes = 0;
                        _seconds = 0;

                        OnPropertyChanged(nameof(Minutes));
                        OnPropertyChanged(nameof(Seconds));
                    }

                    OnPropertyChanged();
                }
            }
        }

        public double Minutes
        {
            get => _minutes ?? 0;
            set
            {
                double clampedValue = Math.Max(Math.Min(value, 60), 0);

                if (_minutes != clampedValue)
                {
                    if (Degrees < MaxDegree)
                    {
                        _minutes = clampedValue;

                        if (value >= 60)
                        {
                            _minutes = 0;
                            Degrees = Math.Min(Degrees + 1, MaxDegree);
                        }

                        OnPropertyChanged();
                    }
                }
            }
        }

        public double Seconds
        {
            get => _seconds ?? 0;
            set
            {
                double clampedValue = Math.Max(Math.Min(value, 60), 0);

                if (_seconds != clampedValue)
                {
                    if (Degrees < MaxDegree)
                    {
                        _seconds = clampedValue;

                        if (value >= 60)
                        {
                            _seconds = 0;
                            Minutes = Math.Min(Minutes + 1, 59);
                        }

                        OnPropertyChanged();
                    }
                }
            }
        }

        public EarthDirection EarthDirection
        {
            get => _earthDirection;
            set
            {
                _earthDirection = value;
                OnPropertyChanged();
            }
        }

        public bool FromLatitude { get; } = fromLatitude;
        public bool FromDms { get; set; }
        public int Sign
        {
            get
            {
                return FromDms switch
                {
                    true => EarthDirection switch
                    {
                        EarthDirection.North or EarthDirection.South => 1,
                        EarthDirection.East or EarthDirection.West => -1,
                        _ => 1
                    },
                    false => Degrees >= 0 ? 1 : -1,
                };
            }
        }

        // Calculated Properties
        private double MaxDegree => FromLatitude ? 90 : 180;
        private double MinDegree => FromDms ? 0 : (FromLatitude ? -90 : -180);

        // Events
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
