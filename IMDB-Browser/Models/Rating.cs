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
    public class Rating
    {
        [Key]
        [Ignore]
        public int Id { get; set; }

        public double AverageRating { get; set; }
        public int NumVotes { get; set; }

        
        [Name("Tconst")]
        public string MovieId { get; set; }

        protected bool Equals(Rating other)
        {
            return Id == other.Id &&
                   AverageRating.Equals(other.AverageRating) &&
                   NumVotes == other.NumVotes &&
                   MovieId == other.MovieId;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rating)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, AverageRating, NumVotes, MovieId);
        }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }

       
    }
}
