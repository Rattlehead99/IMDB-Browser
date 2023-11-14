using IMDB_Browser.Helpers;
using IMDB_Browser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static IMDB_Browser.Helpers.DataPath;

namespace IMDB_Browser.Tests.TestData
{
    public class RatingTest
    {
        string testRatingPath = DataPath.TestRatingPath;

        private RecordLoader _ratingRecordLoader;
        private RecordLoader _movieRecordLoader;
        private RecordLoader _actorRecordLoader;

        [SetUp]
        public void Setup()
        {
            _ratingRecordLoader = new RecordLoader(TestRatingPath);
            _movieRecordLoader = new RecordLoader(TestMoviePath);
            _actorRecordLoader = new RecordLoader(TestActorPath);
        }

        [TearDown]
        public void TearDown()
        {
            _ratingRecordLoader.Dispose(); 
            _movieRecordLoader.Dispose(); 
            _actorRecordLoader.Dispose();
        }


        [Test]
        public void GetRecords_ContainsSpecificPerson_WhenAllRecordsAreRetrieved()
        {
            //Arrange
            Rating rating = SampleData.SampleRating;

            //Act
            IEnumerable<Rating> records = _ratingRecordLoader.LoadRecords<Rating>();

            //Assert
            Assert.That(records.Contains(rating));
        }

        [Test]
        public void GetRecords_HasCorrectRecordCount_WhenAllRecordsAreRetrieved()
        {
            //Arrange
            Rating rating = SampleData.SampleRating;

            //Act
            IEnumerable<Rating> records = _ratingRecordLoader.LoadRecords<Rating>();

            //Assert
            Assert.That(records.Count() == 1366672);
        }

        [Test]
        public void LoadRecords_ToInsertASingleRating()
        {
            var ratingRecord = _ratingRecordLoader
                .LoadRecords<Rating>()
                .FirstOrDefault(rating => rating.MovieId == "tt0094602");

            var movieRecord = _movieRecordLoader
                .LoadRecords<Movie>()
                .FirstOrDefault(movie => movie.Id == "tt0094602");

            var actorRecord = _actorRecordLoader
                .LoadRecords<Actor>()
                .FirstOrDefault(actor => actor.Id== "nm0000219");

            var dbBuilder = new DbContextOptionsBuilder<ImdbDbContext>();

            dbBuilder.UseSqlite("Data source=Rating.db");

            ImdbDbContext dbContext = new ImdbDbContext(dbBuilder.Options);

            movieRecord.Actors.Add(actorRecord);

            ratingRecord.Movie = movieRecord;
            ratingRecord.MovieId = movieRecord.Id;

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            dbContext.Ratings.Add(ratingRecord);
            dbContext.SaveChanges();

            Assert.True(dbContext.Ratings.Contains(ratingRecord));
        }

    }
}
