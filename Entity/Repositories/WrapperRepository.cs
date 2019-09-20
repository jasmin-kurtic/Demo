using Entity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Repositories
{
    public class WrapperRepository : IWrapperRepository
    {
        private readonly RepositoryContext _repoContext;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private IUserRepository _userRepository;

        public WrapperRepository(RepositoryContext repoContext)
        {
            _repoContext = repoContext;
        }

        public IOrderRepository Order
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_repoContext);
                }

                return _orderRepository;
            }
        }

        public IOrderItemRepository OrderItem
        {
            get
            {
                if (_orderItemRepository == null)
                {
                    _orderItemRepository = new OrderItemRepository(_repoContext);
                }

                return _orderItemRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_repoContext);
                }

                return _userRepository;
            }
        }

        public int SaveChanges()
        {
            return _repoContext.SaveChanges();
        }
    }
}
