using D1GPB4_HFT_2022232.Logic;
using D1GPB4_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Application
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        IAlbumLogic albumLogic;
        public AlbumController(IAlbumLogic albumLogic)
        {
            this.albumLogic = albumLogic;
        }
        // GET: /album
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return albumLogic.ReadAll();
        }

        // GET /album/id
        [HttpGet("{id}")]
        public Album Get(int id)
        {
            return albumLogic.Read(id);
        }
        // POST /album
        [HttpPost]
        public void Post([FromBody] Album value)
        {
            albumLogic.Create(value);
        }

        // PUT /album
        [HttpPut]
        public void Put([FromBody] Album value)
        {
            albumLogic.Update(value);
        }

        // DELETE /album/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            albumLogic.Delete(id);
        }
    }
}
