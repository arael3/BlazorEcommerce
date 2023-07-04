namespace BlazorEcommerce.Server.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly DataContext _context;

    public CategoryService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<Category>> GetCategoryAsync(int CategoryId)
    {
        var response = new ServiceResponse<Category>();
        var Category = await _context.Categories.FindAsync(CategoryId);
        if (Category is null)
        {
            response.Success = false;
            response.Message = "Category not found.";
        }
        else
        {
            response.Data = Category;
        }

        return response;
    }

    public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        var response = new ServiceResponse<List<Category>>()
        {
            Data = categories
        };

        return response;
    }
}
