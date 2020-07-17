using System;

namespace WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction
{
    public abstract class BaseEntity
    {
        private DateTime _createdAt;

        public BaseEntity()
        {
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public string Id { get; set; }
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = (value == null || value == DateTime.MinValue) ? DateTime.Now : value;
        }
        public DateTime UpdatedAt { get; set; }
    }
}
