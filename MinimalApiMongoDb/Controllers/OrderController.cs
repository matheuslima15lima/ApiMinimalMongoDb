using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalApiMongoDb.Domains;
using MinimalApiMongoDb.Services;
using MinimalApiMongoDb.ViewsModels;
using MongoDB.Driver;

namespace MinimalApiMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order>? _order;
        private readonly IMongoCollection<Client>? _client;
        private readonly IMongoCollection<Product> _product;
        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create(OrderViewModel orderViewModel)
        {
            try
            {
                Order order = new Order();

              
                order.Date = orderViewModel.Date;
                order.Status= orderViewModel.Status;
                order.ProductId = orderViewModel.ProductId;
                order.ClientId = orderViewModel.ClientId;

                var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();

                if (client == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                order.Clients = client;
                await _order!.InsertOneAsync(order);
                return StatusCode(201, order);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var orders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();
                return Ok(orders);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<Order>> GetById(string id)
        {
            try
            {

                //Order order = new Order();

                //order.Id = orderViewModel.Id;
                //order.Date = orderViewModel.Date;
                //order.Status = orderViewModel.Status;
                //order.ProductId = orderViewModel.ProductId;
                //order.ClientId = orderViewModel.ClientId;


                var orders = await _order.Find(x => x.Id == id).FirstOrDefaultAsync();

                return orders is not null ? Ok(orders) : NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult> Update (OrderViewModel orderViewModel)
        {
            try
            {

                Order order = new Order();

                order.Id = orderViewModel.Id;
                order.Date = orderViewModel.Date;
                order.Status = orderViewModel.Status;
                order.ProductId = orderViewModel.ProductId;
                order.ClientId = orderViewModel.ClientId;

                var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();

                if (client == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                order.Clients = client;
                var filter = Builders<Order>.Filter.Eq(x => x.Id, order.Id);

                if (filter != null)
                {
                    await _order.ReplaceOneAsync(filter, order);
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
        public async Task<ActionResult> Delete (string id)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
                if (filter != null)
                {
                    await _order.DeleteOneAsync(filter);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e )
            {

                return BadRequest(e.Message);
            }
        }
        
    }
}
