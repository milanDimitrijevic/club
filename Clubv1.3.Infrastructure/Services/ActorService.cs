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
    public class ActorService : IActorService
    {
        private readonly IActorService _actorService;
        private readonly ClubDbContext _dbContext;

        public ActorService(ClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActorService(IActorService actorService)
        {
            _actorService = actorService;
        }

        Actor IActorService.AddActorToMovie(Guid movieId, string name, string lastName)
        {
            throw new NotImplementedException();
        }

        void IService.DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        void IService.GetAll()
        {
            throw new NotImplementedException();
        }

        void IService.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        void IService.UpdateById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
