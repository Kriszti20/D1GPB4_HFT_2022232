﻿using D1GPB4_HFT_2022232.Endpoint.Services;
using D1GPB4_HFT_2022232.Logic;
using D1GPB4_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;

namespace Application
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        IAlbumLogic albumLogic;
        IHubContext<SignalRHub> hub;
        public AlbumController(IAlbumLogic albumLogic, IHubContext<SignalRHub> hub)
        {
            this.albumLogic = albumLogic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("AlbumCreated", value);
        }

        // PUT /album
        [HttpPut]
        public void Put([FromBody] Album value)
        {
            albumLogic.Update(value);
            hub.Clients.All.SendAsync("AlbumUpdated", value);
        }

        // DELETE /album/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var albumToDelete = albumLogic.Read(id);
            albumLogic.Delete(id);
            hub.Clients.All.SendAsync("AlbumDeleted", albumToDelete);
        }
    }
}
