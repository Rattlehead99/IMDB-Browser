using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace IMDB_Browser.Models
{
    public class Movie
    {
        [Key]
        [Name("Tconst")]
        public string Id{ get; set; }
        public string? TitleType {get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public int? IsAdult { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public int? RunTimeMinutes { get; set; }
        public string? Genres { get; set; }

        public ICollection<Actor> Actors { get; set; } = new List<Actor>();

        public Rating Rating { get; set; }

        protected bool Equals(Movie other)
        {
            return Id == other.Id &&
                   TitleType == other.TitleType &&
                   PrimaryTitle == other.PrimaryTitle &&
                   OriginalTitle == other.OriginalTitle &&
                   IsAdult == other.IsAdult &&
                   StartYear == other.StartYear &&
                   EndYear == other.EndYear &&
                   RunTimeMinutes == other.RunTimeMinutes &&
                   Genres == other.Genres;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Movie)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(TitleType);
            hashCode.Add(PrimaryTitle);
            hashCode.Add(OriginalTitle);
            hashCode.Add(IsAdult);
            hashCode.Add(StartYear);
            hashCode.Add(EndYear);
            hashCode.Add(RunTimeMinutes);
            hashCode.Add(Genres);
            return hashCode.ToHashCode();
        }
    }
}
