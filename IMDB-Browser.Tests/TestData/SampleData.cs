using IMDB_Browser.Models;

namespace IMDB_Browser.Tests.TestData;

public class SampleData
{
    public static Actor SampleActor => new()
    {
        Id = "nm0000004",
        PrimaryName = "John Belushi",
        BirthYear = 1949,
        DeathYear = 1982,
        PrimaryProfession = "actor,soundtrack,writer",
        KnownForTitles = "tt0078723,tt0072562,tt0080455,tt0077975"
    };

    public static Movie SampleMovie => new()
    {
        Id = "tt0133093",
        TitleType = "movie",
        PrimaryTitle = "The Matrix",
        OriginalTitle = "The Matrix",
        IsAdult = 0,
        StartYear = 1999,
        RunTimeMinutes = 136,
        Genres = "Action,Sci-Fi"
    };

    public static Rating SampleRating => new()
    {
        MovieId = "tt0000005",
        AverageRating = 6.2,
        NumVotes = 2687
    };
}