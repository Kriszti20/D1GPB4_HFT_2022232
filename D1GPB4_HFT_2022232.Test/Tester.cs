using D1GPB4_HFT_2022232.Logic;
using D1GPB4_HFT_2022232.Models;
using D1GPB4_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace D1GPB4_HFT_2022232.Test
{
	[TestFixture]
	public class Tester
	{
		SongLogic songLogic;
		AlbumLogic albumLogic;
		AuthorLogic authorLogic;
		public Tester()
		{
			var MockSongRepo = new Mock<ISongRepository>();
			songLogic = new SongLogic(MockSongRepo.Object);
			var MockAlbumRepo = new Mock<IAlbumRepository>();
			albumLogic = new AlbumLogic(MockAlbumRepo.Object);
			
			Author dualipa = new Author()
			{
				Name = "Dua Lipa"
			};
			Author seanpaul = new Author()
			{
				Name = "Sean Paul"
			};
			Author ladygaga = new Author()
			{
				Name = "Lady Gaga"
			};
			Author avicii = new Author()
			{
				Name = "Avicii"
			};
			Author bieber = new Author()
			{
				Name = "Justin Bieber"
			};
			var songs = new List<Song>()
			{				
				new Song()
				{
					Title = "Break My Heart",
					Author = dualipa,
					Genre = "Pop"
				},
				new Song()
				{
					Title = "We'll Be Burnin",
					Author = seanpaul,
					Genre = "Dancehall"
				},
				new Song()
				{
					Title = "What Do You Mean",
					Author = bieber,
					Genre = "Pop"
				},
				new Song()
				{
					Title = "Waiting For Love",
					Author = avicii,
					Genre = "EDM"
				},
				new Song()
				{
					Title = "Sunset Jesus",
					Author = avicii,
					Genre = "EDM"
				},
				new Song()
				{
					Title = "Love Again",
					Author = dualipa,
					Genre = "Pop"
				},
				new Song()
				{
					Title = "Bad Romance",
					Author = ladygaga,
					Genre = "Pop"
				}
			};

			var albums = new List<Album>()
			{
				new Album()
				{
					Name = "Stories",
					Author = avicii,

				},
				new Album()
				{
					Name = "True",
					Author = avicii,
					ReleaseYear = 2015
				},
				new Album()
				{
					Name = "Dua Lipa",
					Author = dualipa,
					ReleaseYear = 2015
				},
				new Album()
				{
					Name = "The Trinity",
					Author = seanpaul,
					ReleaseYear = 2006
				}
				
			};

			MockSongRepo.Setup((t) => t.ReadAll()).Returns(songs.AsQueryable());
			MockAlbumRepo.Setup((t) => t.ReadAll()).Returns(albums.AsQueryable());
			

		}
		[Test]
		public void CreateSongTest()
		{
			Assert.That(() => songLogic.Create(new Song()
			{
				Title = null,
				Genre = "Pop"
			}), Throws.Exception);
		}
		[Test]
		public void CreateAlbumTest()
		{
			Assert.That(() => albumLogic.Create(new Album()
			{
				Name = null,				
			}), Throws.Exception);
		}
		[Test]
		public void CreateAuthorTest()
		{
			Assert.That(() => authorLogic.Create(new Author()
			{
				Name = null,
			}), Throws.Exception);
		}
		[Test]
		public void DeleteSongTest()
		{
			Assert.That(() => songLogic.Delete(30), Throws.Nothing);
		}

		[Test]
		public void AviciiSongTest()
		{
			var result = songLogic.ListAviciiSongs().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("Wake Me Up"));
		}
		[Test]
		public void FemaleSongsTest()
		{
			var result = songLogic.FemaleSongs().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("IDGAF"));
		}
		[Test]
		public void SeanPaulDanceHallTest()
		{
			var result = songLogic.SeanPaulDanceHallArray().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("Temperature"));
		}
		[Test]
		public void MalePopSongTest()
		{
			var result = songLogic.MalePopSongs().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("What Do You Mean"));
		}
		[Test]
		public void AlbumsFrom2015Test()
		{
			var result = albumLogic.AlbumsFrom2015();
			Assert.That(result, Is.EqualTo(2));
		}
		[Test]
		public void HowManyDuaLipaSongsTest()
		{
			var result = songLogic.HowManyDuaLipaSongs();
			Assert.That(result, Is.EqualTo(2));
		}
		[Test]
		public void MGKAlbumsFrom2020Test()
		{
			var result = albumLogic.MGKAlbumsFrom2020();
			Assert.That(result, Is.EqualTo(0));
		}
		[Test]
		public void PunkRockSongsTest()
		{
			var result = songLogic.PunkRockSongs().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("Bloody Valentine"));
		}
	} 
}
