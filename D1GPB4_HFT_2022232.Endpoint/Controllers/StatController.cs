using D1GPB4_HFT_2022232.Logic;
using D1GPB4_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace D1GPB4_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
		IAlbumLogic albumLogic;
		ISongLogic songLogic;
		public StatController(IAlbumLogic albumLogic, ISongLogic songLogic)
		{
			this.albumLogic = albumLogic;
			this.songLogic = songLogic;
		}


		[HttpGet]
		public IEnumerable<Song> QueryOne()
		{
			return songLogic.AlbumId2Songs();
		}

		[HttpGet]
		public IEnumerable<Song> QueryTwo()
		{
			return songLogic.EdSheeranSongs();
		}

		[HttpGet]
		public IEnumerable<Song> QueryThree()
		{
			return songLogic.RockSongs();
		}

		[HttpGet]
		public IEnumerable<Album> QueryFour()
		{
			return albumLogic.AlbumsBefore1999();
		}

		[HttpGet]
		public IEnumerable<Album> QueryFive()
		{
			return albumLogic.StudioAlbums();
		}

	}
}
