using System;

namespace Entity.Repositories.Interfaces
{
    public interface IWrapperRepository
    {
        IOrderRepository Order { get; }
        IOrderItemRepository OrderItem { get; }
        IUserRepository User { get; }
        int SaveChanges();
    }
}
