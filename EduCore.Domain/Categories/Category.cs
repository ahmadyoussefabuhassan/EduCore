using EduCore.Domain.Abstractions;
using EduCore.Domain.Categories.Events;
using EduCore.Domain.Courses;

namespace EduCore.Domain.Categories
{
    public sealed class Category : Entity
    {
        private Category() : base(Guid.Empty)
        {
        }
        private Category(Guid Id, CategoryName name) : base(Id)
        {
            Name = name;
        }
        public CategoryName Name { get; private set; }
        public ICollection<Course> Courses { get; private set; } = new List<Course>();
        public static Category Create(CategoryName name)
        {
            var category = new Category(Guid.NewGuid(), name);
            category.RaiseDomainEvent(new CategoryUpdatedDomainEvent(category.Id, category.Name));
            return category;
        }
        public void UpdateCategoryName(CategoryName name)
        {
            Name = name;
            RaiseDomainEvent(new CategoryUpdatedDomainEvent(Id, Name));
        }
    }
}
