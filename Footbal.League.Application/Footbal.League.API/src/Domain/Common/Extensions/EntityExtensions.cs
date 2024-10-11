namespace  Domain.Common.Extensions
{
    #region Usings
    using Domain.Common.Models;
    #endregion
    internal static class EntityExtensions
    {
        public static TEntity SetId<TEntity, TId>(this TEntity entity, TId id)
            where TEntity : Entity<TId>
            where TId : struct
            => (entity.SetId<TId>(id) as TEntity)!;

        private static Entity<T> SetId<T>(this Entity<T> entity, T id)
            where T : struct
        {
            entity
                .GetType()
                .BaseType!
                .GetProperty(nameof(Entity<T>.Id))!
                .DeclaringType!
                .GetProperty(nameof(Entity<T>.Id))!
                .GetSetMethod(true)!
                .Invoke(entity, new object[] { id });

            return entity;
        }
    }
}
