using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportverein_Verwaltung {
    internal class Trainer {
        public string Name { get; set; }

        public Team Team { get; set; }

        public Trainer(string name, Team team) {
            Name = name;
            Team = team;
        }

        public override string ToString() {
            return $"{Name},{Team}";
        }
    }
}
