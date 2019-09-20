using Entity.Models;
using Entity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static Entity.Repositories.BaseRepository;

namespace Entity.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
