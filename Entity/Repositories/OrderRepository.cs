using Entity.Models;
using Entity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static Entity.Repositories.BaseRepository;

namespace Entity.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
