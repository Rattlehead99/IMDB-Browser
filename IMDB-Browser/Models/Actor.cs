using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;

namespace IMDB_Browser.Models;

public class Actor
{
    [Key]
    [Name("Nconst")]
    public string Id { get; set; }
    public string PrimaryName { get; set; }
    public int? BirthYear { get; set; } // Nullable to handle unknown birth years
    public int? DeathYear { get; set; } // Nullable to handle unknown death years or if the person is still alive
    public string? PrimaryProfession { get; set; }
    public string? KnownForTitles { get; set; } // Assuming this is a delimited string containing IDs of known titles

    public ICollection<Movie> Movies { get; set; }

    protected bool Equals(Actor other)
    {
        return Id == other.Id &&
               PrimaryName == other.PrimaryName &&
               BirthYear == other.BirthYear &&
               DeathYear == other.DeathYear &&
               PrimaryProfession == other.PrimaryProfession &&
               KnownForTitles == other.KnownForTitles;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Actor)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, PrimaryName, BirthYear, DeathYear, PrimaryProfession, KnownForTitles);
    }
}