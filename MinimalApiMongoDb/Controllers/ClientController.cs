using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalApiMongoDb.Domains;
using MinimalApiMongoDb.Services;
using MongoDB.Driver;

namespace MinimalApiMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMongoCollection<Client> _client;

        public ClientController(MongoDbService mongoDbService)
        {
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            try
            {
                var clients = await _client.Find(FilterDefinition<Client>.Empty).ToListAsync();
                return Ok(clients);
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Client client)
        {
            try
            {
                _client.InsertOneAsync(client);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
               
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>>GetById(string id)
        {
            try
            {
                var client = await _client.Find(x => x.Id == id).FirstOrDefaultAsync();

                return client is not null ? Ok(client) : BadRequest();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message) ;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq(x => x.Id, id);

                if (filter != null)
                {
                    await _client.DeleteOneAsync(filter);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Client c)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq(x => x.Id, c.Id);

                if (filter != null)
                {
                    await _client.ReplaceOneAsync(filter, c);
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
