using CleanArchBlazor.Domain.Entities;
using CleanArchBlazor.Domain.Validation;
using FluentAssertions;

namespace CleanArchBlazor.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category");

        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category With Not Valid State")]
    public void CreateCategory_NegativeIdValue_DomainException()
    {
        Action action = () => new Category(-1, "Category");

        action.Should().Throw<DomainExceptionValidation>();
    }
}
