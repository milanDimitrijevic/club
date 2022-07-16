using clubv1._3.Database;
using Clubv1._3.Domain.Entities;
using Clubv1._3.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubv1._3.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly ClubDbContext _dbContext;
        private readonly IMovieService _movieService;

        public MovieService(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public MovieService(ClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Movie AddToTotalCds(Guid movieId, int amount)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
