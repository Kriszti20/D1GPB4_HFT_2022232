using D1GPB4_HFT_2022232.Logic;
using D1GPB4_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Application
{
    [Route("/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        ISongLogic songLogic;
        public SongController(ISongLogic songLogic)
        {
            this.songLogic = songLogic;
        }
        // GET: /song
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return songLogic.ReadAll();
        }

        // GET /song/id
        [HttpGet("{id}")]
        public Song Get(int id)
        {
            return songLogic.Read(id);
        }
        // POST /song
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            songLogic.Create(value);
        }

        // PUT /song
        [HttpPut]
        public void Put([FromBody] Song value)
        {
            songLogic.Update(value);
        }

        // DELETE /song/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            songLogic.Delete(id);

        }
    }
}

