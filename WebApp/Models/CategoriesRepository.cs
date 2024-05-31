namespace WebApp.Models
{
    public static class CategoriesRepository
    {
        // data that seeds in memory storage
        private static List<Category> _categories = new List<Category>()
        {
            new Category { CategoryId = 1, Name = "Can", Description = "Can" },
            new Category { CategoryId = 2, Name = "Snack", Description = "Snack" },
            new Category { CategoryId = 3, Name = "Toy", Description = "Toy" }
        };

        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId); // LINQ

            // return a copy, instead of the real data from the database
            if (category != null) 
            { 
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,                    
                };
            }

            return null;
        }

        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;

            var categoryToUpdate = GetCategoryById(categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }

    }
}