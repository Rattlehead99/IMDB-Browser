using IMDB_Browser.Helpers;
using IMDB_Browser.Models;
using IMDB_Browser.Tests.TestData;
using Microsoft.EntityFrameworkCore;
using static IMDB_Browser.Helpers.DataPath;

namespace IMDB_Browser.Tests
{
    public class ActorTests
    {
        private RecordLoader _recordLoader;

        [SetUp]
        public void Setup()
        {
            _recordLoader = new RecordLoader(TestActorPath);
        }

        [TearDown]
        public void TearDown() { _recordLoader.Dispose(); }


        [Test]
        public void GetRecords_ContainsSpecificPerson_WhenAllRecordsAreRetrieved()
        {
            //Arrange
            Actor actor = SampleData.SampleActor;

            //Act
            IEnumerable<Actor> records = _recordLoader.LoadRecords<Actor>();

            //Assert
            Assert.That(records.Contains(actor));
        }

        [Test]
        public void GetRecords_HasCorrectRecordCount_WhenAllRecordsAreRetrieved()
        {
            //Arrange
            //Actor actor = SampleData.SampleActor;

            //Act
            IEnumerable<Actor> records = _recordLoader.LoadRecords<Actor>();

            //Assert
            Assert.That(records.Count() == 12988781);
            //nm0000219 -> Steven Seagal
            //tt0094602 -> Steven Seagal Movie and rating
        }

        [Test]
        public void LoadRecords_ToInsertASingleActor()
        {
           // List<Actor> actors = new List<Actor>();

            Actor? actorRecord = _recordLoader
                .LoadRecords<Actor>()
                .FirstOrDefault(actor => actor.Id == "nm0000219");

            var dbBuilder = new DbContextOptionsBuilder<ImdbDbContext>();

            dbBuilder.UseSqlite("Data source=Actor.db");

            ImdbDbContext dbContext = new ImdbDbContext(dbBuilder.Options);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            dbContext.Actors.Add(actorRecord);
            dbContext.SaveChanges();

            Assert.True(dbContext.Actors.Contains(actorRecord));
        }

    }
}