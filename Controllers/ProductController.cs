using Microsoft.AspNetCore.Mvc;

namespace ProductManagementAPI;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[ApiController]

public class ProductController : Controller
{
    List<Product> _Products = new List<Product>();
    /*
    public IActionResult Index()
    {
        return View();
    }
    */

    public ProductController()
    {
        for (int i = 1; i <= 9; i++)
        {
            _Products.Add(new Product()
            {
                productId = i,
                name = "student",
                description = "blablabla",
                price = 100 + i,
                stockQuantity = i,
                createdDate = DateTime.Now
            });
        }
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return _Products;
    }

    [HttpPost]
    public Product Post([FromBody] Product product)
    {
        try
        {

            if (ModelState.IsValid & product is not null)
                _Products.Add(product);
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }
        return product;
    }

    [HttpDelete("{id}")]
    public int Delete(int id)
    {

        var productToRemove = _Products.SingleOrDefault(s => s.productId == id);
        if (productToRemove.productId != null)
        {
            _Products.Remove(productToRemove);

            return _Products.Count();
        }
        return 9;

    }
}
