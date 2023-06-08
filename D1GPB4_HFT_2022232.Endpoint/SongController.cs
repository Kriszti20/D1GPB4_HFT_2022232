using System;
using System.Collections.Generic;

namespace Application
{
    [Route("/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        ISongLogic songLogic;
        IHubContext<SignalRHub> hub;
        public SongController(ISongLogic songLogic, IHubContext<SignalRHub> hub)
        {
            this.songLogic = songLogic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("SongCreated", value);
        }

        // PUT /song
        [HttpPut]
        public void Put([FromBody] Song value)
        {
            songLogic.Update(value);
            hub.Clients.All.SendAsync("SongUpdated", value);
        }

        // DELETE /song/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var songToDelete = songLogic.Read(id);
            songLogic.Delete(id);
            hub.Clients.All.SendAsync("SongDeleted", songToDelete);
        }
    }
}

