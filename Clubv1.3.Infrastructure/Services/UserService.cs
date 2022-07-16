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
    public class UserService : IUserService
    {
        private readonly IUserService _userService;
        private readonly ClubDbContext _clubDbContext;

        public UserService(ClubDbContext clubDbContext)
        {
            _clubDbContext = clubDbContext;
        }

        public UserService(IUserService userService)
        {
            _userService = userService;
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

        public Renting RentedMovies()
        {
            throw new NotImplementedException();
        }

        public Renting RentedSeries()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
