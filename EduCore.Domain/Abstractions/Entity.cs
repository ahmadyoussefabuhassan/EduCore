namespace EduCore.Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public Guid Id { get; protected set; }
        protected Entity(Guid Id)
            => this.Id = Id;
        private Entity() : this(Guid.Empty) { }
        public IReadOnlyList<IDomainEvent> GetDomainEvents() => _events.ToList();
        public void ClearDomainEvents() => _events.Clear();
        protected void RaiseDomainEvent(IDomainEvent domainEvent) => _events.Add(domainEvent);
        public override bool Equals(object? obj)
        {
            if (obj is not Entity other)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetType() != other.GetType())
                return false;
            return Id == other.Id;
        }
        public override int GetHashCode()
        {
            if(this.Id != default)
                return Id.GetHashCode() ^ 31;
            return base.GetHashCode();

        }
        public static bool operator ==(Entity? left, Entity? right)
        {
            if (left is null && right is null)
                return true;
            if (left is null || right is null)
                return false;
            return left.Equals(right);
        }
        public static bool operator !=(Entity? left, Entity? right)
            => !(left == right);
    }
}
