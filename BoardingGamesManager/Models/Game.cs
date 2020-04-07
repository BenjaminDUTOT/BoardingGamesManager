using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardingGamesManager.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MinDuration { get; set; }
        public int OurDuration { get; set; }
        public int MaxDuration { get; set; }
        public int MinAge { get; set; }
        public int MinPlayer { get; set; }
        public int BestNumberPlayer { get; set; }
        public int Maxplayer { get; set; }
        public string Editeur { get; set; }
        public List<Lien> Liens { get; set; }
        public List<MotClef> MotClef { get; set; }
        public List<Proprietaire> Proprietaires { get; set; }

    }
}
