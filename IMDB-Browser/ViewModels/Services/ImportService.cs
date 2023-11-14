using IMDB_Browser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static IMDB_Browser.Helpers.DataPath;

namespace IMDB_Browser.ViewModels.Services
{
    public class ImportService
    {
        private ImdbDbContext _dbContext;


        public ImportService(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertRecords()
        {
            using RecordLoader _ratingRecordLoader = new RecordLoader(TestRatingPath);
            using RecordLoader _movieRecordLoader = new RecordLoader(TestMoviePath) ;
            using RecordLoader _actorRecordLoader = new RecordLoader(TestActorPath);
            var ratingRecords = _ratingRecordLoader
                .LoadRecords<Rating>()
                .ToList();
            var movieRecords = _movieRecordLoader
                .LoadRecords<Movie>()
                .ToList();
            var actorRecords = _actorRecordLoader
                .LoadRecords<Actor>()
                .ToList();

            _dbContext.Movies.BulkInsert(movieRecords);
            _dbContext.Actors.BulkInsert(actorRecords);
            _dbContext.Ratings.BulkInsert(ratingRecords);

            
        }

        //
    }
}
