namespace Anshan.Framework.Domain
{
    public abstract class Entity<TKey> : TrackEntity
    {
        public TKey Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            var otherEntity = obj as Entity<TKey>;
            return this.Id.Equals(otherEntity.Id);
        }

        public void SetId(TKey id)
        {
            this.Id = id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}