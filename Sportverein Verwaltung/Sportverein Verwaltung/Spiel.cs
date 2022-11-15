using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportverein_Verwaltung {
    internal class Spiel {

        public DateTime DatumUhrzeit { get; set; }

        public string Ort { get; set; }

        public List<Team> Teams { get; set; }

        public Spiel(DateTime datumuhrzeit, string ort, List<Team> teams) { 
            DatumUhrzeit = datumuhrzeit;
            Ort = ort;
            Teams = teams;
        }

        public override string ToString() {
            string spiele = $"{DatumUhrzeit},{Ort},";
            foreach (var team in Teams) {
                spiele += team.ToString();
            }
            return spiele;
        }
    }
}
