using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myapi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization.Attributes;

namespace myapi.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        MongoClient _client;
        IMongoDatabase _db;
        IMongoCollection<Profile> _collection;

        public ProfileController()
        {
            _client = new MongoClient("mongodb://172.17.0.2:27017/profiles-db");
            _db = _client.GetDatabase("Profiles");
            _collection = _db.GetCollection<Profile>("profiles");
        }

        [HttpGet]
        public async Task<IEnumerable<Profile>> Get() => await _collection.Find(FilterDefinition<Profile>.Empty).ToListAsync();

        [HttpGet("{id}")]
        public async Task<Profile> Get(string id) => await _collection.Find(p => p.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();

        [HttpPost]
        public async Task Post([FromBody]Profile profile) => await _collection.InsertOneAsync(profile);

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody]Profile profile) => await _collection.ReplaceOneAsync(p => p.Id == ObjectId.Parse(id), profile);

        [HttpDelete("{id}")]
        public async Task Delete(string id) => await _collection.DeleteOneAsync(p => p.Id == ObjectId.Parse(id));
    }
}
