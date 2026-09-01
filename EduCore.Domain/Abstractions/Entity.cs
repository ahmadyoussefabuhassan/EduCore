namespace EduCore.Domain.Abstractions
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        protected Entity(Guid Id)
            => this.Id = Id;
    }
}
