﻿using CleanArchBlazor.Domain.Entities;

namespace CleanArchBlazor.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetByIdAsync(int id);
    Task<Category> CreateAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task<Category> RemoveAsync(Category category);
}
