namespace ReservationSystem.Domain.Entity.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}

