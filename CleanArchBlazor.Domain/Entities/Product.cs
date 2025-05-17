using CleanArchBlazor.Domain.Validation;

namespace CleanArchBlazor.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set;  }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(id < 0, "Id is required");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Name is short");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
        DomainExceptionValidation.When(description.Length < 5, "Description is short");

        DomainExceptionValidation.When(price < 0, "Price is required");
        DomainExceptionValidation.When(stock < 0, "Stock is required");

        DomainExceptionValidation.When(image.Length > 250, "Image is long");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }
}
