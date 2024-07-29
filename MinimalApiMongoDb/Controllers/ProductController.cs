using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalApiMongoDb.Domains;
using MinimalApiMongoDb.Services;
using MongoDB.Driver;

namespace MinimalApiMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _product;

        public ProductController(MongoDbService mongoDbService)
        {
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(products);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            try
            {
                // Product product1 = new Product()
                //{
                //    Price = product.Price,
                //    Id = product.Id,
                //    Name = product.Name,
                // };
                _product.InsertOne(product);
                return StatusCode(200);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<Product>> GetById(string id)
        {
            try
            {
                var product = await _product.Find(x => x.Id == id).FirstOrDefaultAsync();
                //var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
                //return Ok(filter);

                return product is not null? Ok(product) : NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> Update(Product p)
        {
            try
            {   
                //buscar por id (filtro)
                var filter = Builders<Product>.Filter.Eq(x=> x.Id, p.Id);

                if(filter != null)
                {
                //substituindo o objeto buscado pelo novo objeto
                await _product.ReplaceOneAsync(filter, p);

                return Ok();

                }

                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
          
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(x=>x.Id,id);

                if(filter != null)
                {
                    await _product.DeleteOneAsync(filter);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
