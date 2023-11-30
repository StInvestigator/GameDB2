using GameDB2;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameContext db = new GameContext();

            db.insertDataToDB();

            //db.showGameByCreatorAndName("Super","Mario");
            //db.showGameByStyle("OpenWorld");
            //db.showGameByYear(2023);

            //db.showTop3MinSellingsGame();


            //db.changeGame(1, new Game(1, "NewName", 1, 1, DateTime.Now, false, 50001));
            db.deleteGame("MarioBattles", "SuperStudio");

            db.showAllFromDB();
        }
    }
}
