using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace IMDB_Browser.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        private string _primaryTitle;
        private string _originalTitle;
        private int? _isAdult;
        private int? _startYear;
        private int? _endYear;
        private int? _runTimeMinutes;
        private string? _genres;
        private string? _titleType;
        private BitmapImage _imageSource;

        public MovieViewModel()
        {
            PrimaryTitle = "Pesho";
            OriginalTitle = "Gosho";
            IsAdult = 1;
            StartYear = 2008;
            EndYear = 2008;
            RunTimeMinutes = 100;
            Genres = "Action";
            _imageSource = new BitmapImage(new Uri("https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8Gxv8gSFCU0XGDykEGv7zR1n2ua.jpg"));
        }

        public ImageSource Image => _imageSource;

        public string? TitleType
        {
            get => _titleType;
            set => SetField(ref _titleType, value);
        }

        public string PrimaryTitle
        {
            get => _primaryTitle;
            set => SetField(ref _primaryTitle, value);
        }

        public string OriginalTitle
        {
            get => _originalTitle;
            set => SetField(ref _originalTitle, value);
        }

        public int? IsAdult
        {
            get => _isAdult;
            set => SetField(ref _isAdult, value);
        }

        public int? StartYear
        {
            get => _startYear;
            set => SetField(ref _startYear, value);
        }

        public int? EndYear
        {
            get => _endYear;
            set => SetField(ref _endYear, value);
        }

        public int? RunTimeMinutes
        {
            get => _runTimeMinutes;
            set => SetField(ref _runTimeMinutes, value);
        }

        public string? Genres
        {
            get => _genres;
            set => SetField(ref _genres, value);
        }
    }
}
