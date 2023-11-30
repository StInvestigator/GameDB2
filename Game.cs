using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDB2
{
    public class Game
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int CreatorId { set; get; }
        public int StyleId { set; get; }
        public DateTime ReleaseDate { set; get; }
        public bool IsMultiplayer { set; get; }
        public int SoldCopies { set; get; }

        public Game()
        {

        }
        public Game(int id, string name, int creatorId, int styleId, DateTime releaseDate, bool isMultiplayer, int soldCopies)
        {
            Id = id;
            Name = name;
            CreatorId = creatorId;
            StyleId = styleId;
            ReleaseDate = releaseDate;
            IsMultiplayer = isMultiplayer;
            SoldCopies = soldCopies;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Creator Id: {CreatorId}, Style Id: {StyleId}, Release Date: {ReleaseDate}, Is multiplayer: {IsMultiplayer}, Sold copies: {SoldCopies}");
        }
    }
}
