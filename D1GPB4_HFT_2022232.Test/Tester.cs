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
			var MockAuthorRepo = new Mock<IAuthorRepository>();
			authorLogic = new AuthorLogic(MockAuthorRepo.Object);

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
			Author edsheraan = new Author()
			{
				Name = "Ed Sheraan"
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
					Genre = "Rock"
				},
				new Song()
				{
					Title = "Shape of You",
					Author = edsheraan,
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
					ReleaseYear = 1994,
					Id = 1
				},
				new Album()
				{
					Name = "True",
					Author = avicii,
					ReleaseYear = 2015,
					Id = 2
				},
				new Album()
				{
					Name = "Dua Lipa",
					Author = dualipa,
					ReleaseYear = 2015,
					Id = 3
				},
				new Album()
				{
					Name = "The Trinity",
					Author = seanpaul,
					ReleaseYear = 2006,
					Id = 4
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
		public void DeleteAlbumTest()
		{
			Assert.That(() => albumLogic.Delete(56), Throws.Nothing);
		}
		[Test]
		public void DeleteAuthorTest()
		{
			Assert.That(() => authorLogic.Delete(97), Throws.Nothing);
		}
		[Test]
		public void EdSheraanTest()
		{
			var result = songLogic.EdSheeranSongs().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("Shape of You"));
		}
		[Test]
		public void RockSongsTest()
		{
			var result = songLogic.RockSongs().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("We'll Be Burnin"));
		}
		[Test]
		public void AlbumsBefore1999Test()
		{
			var result = albumLogic.AlbumsBefore1999().ToArray();
			Assert.That(result[0].Name, Is.EqualTo("Stories"));
		}
		[Test]
		public void StudioAlbumsTest()
		{
			var result = albumLogic.StudioAlbums().ToArray();
			Assert.That(result, Is.Empty);
		}
		[Test]
		public void AlbumId2Test()
		{
			var result = songLogic.AlbumId2Songs().ToArray();
			Assert.That(result, Is.Empty);
		}
	} 
}
