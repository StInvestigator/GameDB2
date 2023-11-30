using GameDB2;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using static GameDB2.GameDB;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //insertDataToDB();
            showAllFromDB();
        }

        static void showAllFromDB()
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
        static void insertDataToDB()
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
                                            db.Styles.Where(x => x.Name == "ActionRPG").First().Id, DateTime.UtcNow,false,40000);
                    Game game2 = new Game(2, "TetrisWars", db.Creators.Where(x => x.Name == "UltraStudio").First().Id, 
                                            db.Styles.Where(x => x.Name == "OpenWorld").First().Id, DateTime.UtcNow,true,100000);

                    db.Games.Add(game1);
                    db.Games.Add(game2);

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
