using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using IMDB_Browser.Models;

namespace IMDB_Browser.ViewModels
{
    public class MovieListViewModel : BaseViewModel
    {
        public MovieViewModel MovieViewModel { get; set; } = new MovieViewModel()
        {
            PrimaryTitle = "Pesho",
            OriginalTitle = "Gosho",
            IsAdult = 1,
            StartYear = 2008,
            EndYear = 2008,
            RunTimeMinutes = 100,
            Genres = "Action",
            //Image = new BitmapImage(new Uri("http://www.impawards.com/tv/posters/boys_ver41.jpg"))
        };
        public MovieListViewModel()
        {
            Movies = new ObservableCollection<MovieViewModel>()
            {
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
                MovieViewModel,
            };
        }

        public ObservableCollection<MovieViewModel> Movies { get; set; }
    }
}