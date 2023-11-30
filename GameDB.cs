using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameDB2
{
    public class GameContext : DbContext
    {
        public string connectionString = @"Data Source=DESKTOP-OF66R01\SQLEXPRESS;Initial Catalog=GamesDB;Integrated Security=True";
        public DbSet<Game> Games { set; get; }
        public DbSet<Creator> Creators { set; get; }
        public DbSet<Style> Styles { set; get; }
        public GameContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public void showAllFromDB()
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };

                    foreach (var item in query)
                    {
                        Console.WriteLine($"Game name: {item.GameName}, Creator: {item.Creator}, Style: {item.Style}, \nRelease date: {item.ReleaseDate}, Is multiplayer: {item.IsMultiplayer}, Sold copies: {item.SoldCopies}\n");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void insertDataToDB()
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    Creator creator1 = new Creator(1, "SuperStudio");
                    Creator creator2 = new Creator(2, "UltraStudio");

                    db.Creators.Add(creator1);
                    db.Creators.Add(creator2);

                    Style style1 = new Style(1, "ActionRPG");
                    Style style2 = new Style(2, "OpenWorld");

                    db.Styles.Add(style1);
                    db.Styles.Add(style2);

                    db.SaveChanges();

                    Game game1 = new Game(1, "MarioBattles", db.Creators.Where(x => x.Name == "SuperStudio").First().Id,
                                            db.Styles.Where(x => x.Name == "ActionRPG").First().Id, DateTime.UtcNow, false, 40000);
                    Game game2 = new Game(2, "TetrisWars", db.Creators.Where(x => x.Name == "UltraStudio").First().Id,
                                            db.Styles.Where(x => x.Name == "OpenWorld").First().Id, DateTime.UtcNow, true, 100000);
                    Game game3 = new Game(3, "BedWard", db.Creators.Where(x => x.Name == "SuperStudio").First().Id,
                                            db.Styles.Where(x => x.Name == "ActionRPG").First().Id, DateTime.UtcNow, true, 20000);
                    Game game4 = new Game(4, "SkyWars", db.Creators.Where(x => x.Name == "UltraStudio").First().Id,
                                            db.Styles.Where(x => x.Name == "ActionRPG").First().Id, DateTime.UtcNow, true, 500);

                    db.Games.Add(game1);
                    db.Games.Add(game2);
                    db.Games.Add(game3);
                    db.Games.Add(game4);

                    db.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void showGameByName(string name)
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                where game.Name.Contains(name)
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };

                    foreach (var item in query)
                    {
                        Console.WriteLine($"Game name: {item.GameName}, Creator: {item.Creator}, Style: {item.Style}, \nRelease date: {item.ReleaseDate}, Is multiplayer: {item.IsMultiplayer}, Sold copies: {item.SoldCopies}\n");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void showGameByCreator(string creatorName)
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                where creator.Name.Contains(creatorName)
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };

                    foreach (var item in query)
                    {
                        Console.WriteLine($"Game name: {item.GameName}, Creator: {item.Creator}, Style: {item.Style}, \nRelease date: {item.ReleaseDate}, Is multiplayer: {item.IsMultiplayer}, Sold copies: {item.SoldCopies}\n");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void showGameByCreatorAndName(string creatorName, string name)
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                where creator.Name.Contains(creatorName)
                                where game.Name.Contains(name)
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };

                    foreach (var item in query)
                    {
                        Console.WriteLine($"Game name: {item.GameName}, Creator: {item.Creator}, Style: {item.Style}, \nRelease date: {item.ReleaseDate}, Is multiplayer: {item.IsMultiplayer}, Sold copies: {item.SoldCopies}\n");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void showGameByStyle(string styleName)
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                where style.Name.ToLower() == styleName.ToLower()
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };

                    foreach (var item in query)
                    {
                        Console.WriteLine($"Game name: {item.GameName}, Creator: {item.Creator}, Style: {item.Style}, \nRelease date: {item.ReleaseDate}, Is multiplayer: {item.IsMultiplayer}, Sold copies: {item.SoldCopies}\n");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void showGameByYear(int year)
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                where game.ReleaseDate.Year == year
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };

                    foreach (var item in query)
                    {
                        Console.WriteLine($"Game name: {item.GameName}, Creator: {item.Creator}, Style: {item.Style}, \nRelease date: {item.ReleaseDate}, Is multiplayer: {item.IsMultiplayer}, Sold copies: {item.SoldCopies}\n");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void showSinglePlayerGames()
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                where game.IsMultiplayer = false
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };

                    foreach (var item in query)
                    {
                        Console.WriteLine($"Game name: {item.GameName}, Creator: {item.Creator}, Style: {item.Style}, \nRelease date: {item.ReleaseDate}, Is multiplayer: {item.IsMultiplayer}, Sold copies: {item.SoldCopies}\n");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void showMultiPlayerGames()
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                where game.IsMultiplayer = true
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };

                    foreach (var item in query)
                    {
                        Console.WriteLine($"Game name: {item.GameName}, Creator: {item.Creator}, Style: {item.Style}, \nRelease date: {item.ReleaseDate}, Is multiplayer: {item.IsMultiplayer}, Sold copies: {item.SoldCopies}\n");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void showMaxSellingsGame()
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                orderby game.SoldCopies
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };

                    Console.WriteLine($"Game name: {query.Last().GameName}, Creator: {query.Last().Creator}, Style: {query.Last().Style}, \nRelease date: {query.Last().ReleaseDate}, Is multiplayer: {query.Last().IsMultiplayer}, Sold copies: {query.Last().SoldCopies}\n");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void showMinSellingsGame()
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                orderby game.SoldCopies descending
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };

                    Console.WriteLine($"Game name: {query.Last().GameName}, Creator: {query.Last().Creator}, Style: {query.Last().Style}, \nRelease date: {query.Last().ReleaseDate}, Is multiplayer: {query.Last().IsMultiplayer}, Sold copies: {query.Last().SoldCopies}\n");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void showTop3MaxSellingsGame()
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                orderby game.SoldCopies descending
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };
                    int amount;
                    if (query.Count() >= 3)
                    {
                        amount = 3;
                    }
                    else
                    {
                        amount = query.Count();
                    }
                    for (int i = 0; i < amount; i++)
                    {
                        Console.WriteLine($"Game name: {query.ElementAt(i).GameName}, Creator: {query.ElementAt(i).Creator}, Style: {query.ElementAt(i).Style}, \nRelease date: {query.ElementAt(i).ReleaseDate}, Is multiplayer: {query.ElementAt(i).IsMultiplayer}, Sold copies: {query.ElementAt(i).SoldCopies}\n");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void showTop3MinSellingsGame()
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    var games = db.Games.ToList();
                    var creators = db.Creators.ToList();
                    var styles = db.Styles.ToList();

                    var query = from game in games
                                join creator in creators on game.CreatorId equals creator.Id
                                join style in styles on game.StyleId equals style.Id
                                orderby game.SoldCopies
                                select new
                                {
                                    GameName = game.Name,
                                    Creator = creator.Name,
                                    Style = style.Name,
                                    ReleaseDate = game.ReleaseDate,
                                    IsMultiplayer = game.IsMultiplayer,
                                    SoldCopies = game.SoldCopies
                                };
                    int amount;
                    if (query.Count() >= 3)
                    {
                        amount = 3;
                    }
                    else
                    {
                        amount = query.Count();
                    }
                    for (int i = 0; i < amount; i++)
                    {
                        Console.WriteLine($"Game name: {query.ElementAt(i).GameName}, Creator: {query.ElementAt(i).Creator}, Style: {query.ElementAt(i).Style}, \nRelease date: {query.ElementAt(i).ReleaseDate}, Is multiplayer: {query.ElementAt(i).IsMultiplayer}, Sold copies: {query.ElementAt(i).SoldCopies}\n");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void addGame(Game newGame)
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    if (db.Games.ToList().
                        Find(x => x.Id == newGame.Id || (x.Name == newGame.Name && x.CreatorId == newGame.CreatorId)) != null)
                    {
                        Console.WriteLine("This game is already exists!");
                        return;
                    }

                    db.Games.Add(newGame);
                    db.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void changeGame(int GameId, Game newGame)
        {
            try
            {
                using (GameContext db = new GameContext())
                {
                    if (db.Games.ToList().
                        Find(x => x.Id == GameId && x.Id == newGame.Id) == null)
                    {
                        Console.WriteLine("Wrong input!");
                        return;
                    }

                    db.Games.Remove(db.Games.ToList().Find(x => x.Id == GameId));
                    db.Games.Add(newGame);
                    db.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void deleteGame(string gameName, string creatorName)
        {
            try
            {
                int answ;
                Console.WriteLine($"\nAre you sure want to delete game {gameName} from {creatorName}?\n1 - Yes");
                answ = Convert.ToInt32(Console.ReadLine().ToString());
                if (answ != 1) { return; }
                using (GameContext db = new GameContext())
                {

                    db.Games.Remove(db.Games.ToList().Find(x => x.CreatorId == db.Creators.ToList().Find(y => y.Name == creatorName).Id && x.Name == gameName)); ;
                    db.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
