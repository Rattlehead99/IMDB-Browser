using CsvHelper.Configuration;
using IMDB_Browser.Helpers;
using IMDB_Browser.Models;
using IMDB_Browser.Tests.TestData;
using IMDB_Browser.ViewModels.Services;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static IMDB_Browser.Helpers.DataPath;
namespace IMDB_Browser.Tests
{
    public class MovieTests
    {
        private RecordLoader _recordLoader;

        [SetUp]
        public void Setup()
        {
            _recordLoader = new RecordLoader(TestMoviePath);
        }

        [TearDown]
        public void TearDown() { _recordLoader.Dispose();}

        [Test]
        public void GetRecords_ContainsSpecificMovie_WhenAllRecordsAreRetrieved()
        {
            Movie movie = SampleData.SampleMovie;

            IEnumerable<Movie> records = _recordLoader.LoadRecords<Movie>();

            Assert.That(records.Contains(movie));
        }

        [Test]
        public void GetRecords_HasCorrectMovieCount_WhenAllRecordsAreRetrieved()
        {
            //Arrange
            //Movie actor = SampleData.SampleMovie;

            //Act
            IEnumerable<Movie> records = _recordLoader.LoadRecords<Movie>();

            //Assert
            Assert.That(records.Count() == 10293183);
        }

        [Test]
        public void ImportingRecords_ShouldMatchTheirRelationship()
        {
            List<Movie> movies = new List<Movie>();
            List<Actor> actors = new List<Actor>();
            List<Rating> ratings = new List<Rating>();

            var recordLoading = _recordLoader
                .LoadRecords<Movie>();

            Movie? movie = recordLoading
                .FirstOrDefault();
            var dbBuilder = new DbContextOptionsBuilder<ImdbDbContext>();

            dbBuilder.UseSqlite("Data source=Gosho.db");
            
            ImdbDbContext dbContext = new ImdbDbContext(dbBuilder.Options);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
            //dbContext.Movies.ToList();

            Assert.True(dbContext.Movies.Contains(movie));
        }

        [Test]
        public void ImportData()
        {
            var dbBuilder = new DbContextOptionsBuilder<ImdbDbContext>();

            dbBuilder.UseSqlite("Data source=Gosho.db");

            ImdbDbContext dbContext = new ImdbDbContext(dbBuilder.Options);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            ImportService importService = new ImportService(dbContext);

            importService.InsertRecords();
        }
    }
}
