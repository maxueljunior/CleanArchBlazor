using CleanArchBlazor.Domain.Validation;

namespace CleanArchBlazor.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; private set; }
    public ICollection<Product> Products { get; set; }

    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Id is required");
        Id = id;
        ValidateDomain(name);
    }

    public Category(string name)
    {
        ValidateDomain(name);
    }

    public void Update(string name)
    {
        ValidateDomain(name);
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Name is short");

        Name = name;
    }
}
