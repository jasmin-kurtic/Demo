namespace Entity.Repositories.Interfaces
{
    public interface IWrapperRepository
    {
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
