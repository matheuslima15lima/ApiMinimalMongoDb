using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalApiMongoDb.Domains;
using MinimalApiMongoDb.Services;
using MongoDB.Driver;

namespace MinimalApiMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _user;

        public UserController(MongoDbService mongoDbService)
        {
            _user = mongoDbService.GetDatabase.GetCollection<User>("user");
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            try
            {
                var users = await _user.Find(FilterDefinition<User>.Empty).ToListAsync();
                return Ok(users);   
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            try
            {
                _user.InsertOne(user);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
               
            }
        }


        [HttpGet("{id}")]
        public async Task <ActionResult<User>>GetById(string id)
        {
            try
            {
                var user = await _user.Find(x => x.Id == id).FirstOrDefaultAsync();

                return user is not null ? Ok(user) : NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(User u)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(x => x.Id, u.Id);

                if (filter != null)
                {
                    await _user.ReplaceOneAsync(filter, u);
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
                var filter = Builders<User>.Filter.Eq(x => x.Id, id);

                if (filter != null)
                {
                    await _user.DeleteOneAsync(filter);
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
