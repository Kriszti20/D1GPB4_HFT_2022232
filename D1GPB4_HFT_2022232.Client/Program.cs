using D1GPB4_HFT_2022232.Models;
using System;
using System.Threading;

namespace D1GPB4_HFT_2022232.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(8000);
			bool exit = false;
			while (!exit)
            {
				MainMenu(ref exit);
			}
            a
        }

		static void MainMenu(ref bool exit)
		{
			Console.WriteLine("1. Albums List, 2. Authors List, 3. Songs List, 4. Queries, 5. Post, 6. Put, 7. Delete");
			RestService restService = new RestService("http://localhost:40083");
			var albums = restService.Get<Album>("Album");
			var authors = restService.Get<Author>("Author");
			var songs = restService.Get<Song>("Song");

			int choice = int.Parse(Console.ReadLine());
			var q1 = restService.Get<Song>("stat/QueryOne");
			var q2 = restService.Get<Song>("stat/QueryTwo");
			var q3 = restService.Get<Song>("stat/QueryThree");
			var q4 = restService.Get<Album>("stat/QueryFour");
			var q5 = restService.Get<Album>("stat/QueryFive");

			switch (choice)
			{
				case 1:
					foreach (var album in albums)
					{
						Console.WriteLine("Album ID: " + album.Id);
						Console.WriteLine("Album Name: " + album.Name);
						Console.WriteLine("Release Year: " + album.ReleaseYear);
					}
					break;
				case 2:
					foreach (var author in authors)
					{
						Console.WriteLine("Author ID: " + author.Id);
						Console.WriteLine("Author Name: " + author.Name);
					}
					break;
				case 3:
					foreach (var song in songs)
					{
						Console.WriteLine("Song ID: " + song.Id);
						Console.WriteLine("Song Title: " + song.Title);
						Console.WriteLine("Song Genre: " + song.Genre);
					}
					break;
				#region QueryPrinting
				case 4:					
					Console.WriteLine("Query 1: ");
					foreach (var song in q1)
					{
						Console.WriteLine(song.Title);
					}
					Console.WriteLine();
					Console.WriteLine("Query 2: ");
					foreach (var song in q2)
					{
						Console.WriteLine(song.Title);
					}
					Console.WriteLine();
					Console.WriteLine("Query 3: ");
					foreach (var song in q3)
					{
						Console.WriteLine(song.Title);
					}
					Console.WriteLine();
					Console.WriteLine("Query 4: ");
					foreach (var album in q4)
					{
						Console.WriteLine(album.Name);
					}
					Console.WriteLine();
					Console.WriteLine("Query 5: ");
					foreach (var album in q5)
					{
						Console.WriteLine(album.Name);
					}					
					break;
				#endregion
				case 5:
                    Console.WriteLine("Post: 1. Author, 2. Album, 3. Song");
					int postChoice = int.Parse(Console.ReadLine());
                    switch (postChoice)
                    {
						case 1:
                            Console.Write("Author Name: ");
							string authorName = Console.ReadLine();
							restService.Post(new Author()
							{
								Name = authorName
							}, "Author");
							break;
						case 2:
							Console.Write("Album Name: ");
							string albumName = Console.ReadLine();
							restService.Post(new Album()
							{
								Name = albumName
							}, "Album");
							break;
						case 3:
							Console.Write("Song Title: ");
							string songTitle = Console.ReadLine();
							restService.Post(new Song()
							{
								Title = songTitle
							}, "Song");
							break;
						default:
                            break;
                    }                    
					break;
                case 6:
					Console.WriteLine("Put: 1. Author, 2. Album, 3. Song");
					int putChoice = int.Parse(Console.ReadLine());
					switch (putChoice)
					{
						case 1:
							Console.Write("Author Name: ");
							string authorName = Console.ReadLine();
                            Console.WriteLine("Author ID: ");
							int authorId = int.Parse(Console.ReadLine());
							restService.Put(new Author()
							{
								Id = authorId,
								Name = authorName
							}, "Author");
							break;
						case 2:
							Console.Write("Album Name: ");
							string albumName = Console.ReadLine();
                            Console.WriteLine("Album ID: ");
							int albumId = int.Parse(Console.ReadLine());
							restService.Put(new Album()
							{
								Id = albumId,
								Name = albumName
							}, "Album");
							break;
						case 3:
							Console.Write("Song Title: ");
							string songTitle = Console.ReadLine();
                            Console.WriteLine("Album ID: ");
							int songId = int.Parse(Console.ReadLine());
							restService.Put(new Song()
							{
								Id = songId,
								Title = songTitle
							}, "Song");
							break;
						default:
							break;
					}
                    break;
                case 7:
					Console.WriteLine("Delete: 1. Author, 2. Album, 3. Song");
					int deleteChoice = int.Parse(Console.ReadLine());
					switch (deleteChoice)
					{
						case 1:
							Console.Write("Author ID: ");
							int authorId = int.Parse(Console.ReadLine());
							restService.Delete(authorId, "Author");
							break;
						case 2:
							Console.Write("Album ID: ");
							int albumId = int.Parse(Console.ReadLine());
							restService.Delete(albumId, "Album");
							break;
						case 3:
							Console.Write("Song ID: ");
							int songId = int.Parse(Console.ReadLine());
							restService.Delete(songId, "Song");
							break;
						default:
							break;
					}
					break;
				case 0:
					exit = true;
					break;
                default:
					break;
			}
			
		}
	}
}
