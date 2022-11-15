using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportverein_Verwaltung {
    internal class Spieler {

        public string Name { get; set; }

        public string Position { get; set; }

        public Team Team { get; set; }

        public Spieler(string name, string position, Team team) {
            Name = name;
            Position = position;
            Team = team;
        }

        public override string ToString() {
            return Name + "," + Position + "," + Team;
        }
    }
}
