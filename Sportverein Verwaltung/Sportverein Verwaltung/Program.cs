using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sportverein_Verwaltung {
    internal class Program {
        static void Main(string[] args) {
            DatenEingebenUndSchreiben();
        }

        private static void DatenEingebenUndSchreiben() {
            DatenEinlesen(out List<Team> teams, out List<Spieler> spieler, out List<Trainer> trainer, out List<Spiel> spiele);
            DatenSchreiben(teams, spieler, trainer, spiele);
        }

        private static void DatenSchreiben(List<Team> teams, List<Spieler> spieler, List<Trainer> trainer, List<Spiel> spiele) {
            string contentToWrite = "";
            contentToWrite += "Teamname,\n";
            foreach(var team in teams) {
                contentToWrite += team.ToString();
                contentToWrite += "\n";
            }
            contentToWrite += "\n";


            contentToWrite += "Spielername,Position,Team,\n";
            foreach(var Spieler in spieler) {
                contentToWrite += Spieler.ToString();
                contentToWrite += "\n";
            }

            contentToWrite += "\n";

            contentToWrite += "TrainerName,Team,\n";
            foreach (var Trainer in trainer) {
                contentToWrite += Trainer.ToString();
                contentToWrite += "\n";
            }

            contentToWrite += "\n";

            contentToWrite += "DatumUhrzeit,Ort,Team1,Team2";
            foreach (var spiel in spiele) {
                contentToWrite += spiel.ToString();
                contentToWrite += "\n";
            }
            File.WriteAllText("SportvereinVerwaltung.csv", contentToWrite);

        }

        private static void DatenEinlesen(out List<Team> teams, out List<Spieler> spieler, out List<Trainer> trainer, out List<Spiel> spiele) {
            teams = new List<Team>();
            TeamsEingeben(ref teams);
            spieler = new List<Spieler>();
            SpielerEingeben(ref spieler, teams);
            trainer = new List<Trainer>();
            TrainerEingeben(ref trainer, teams);
            spiele = new List<Spiel>();
            SpieleEingeben(ref spiele, teams);
        }

        private static void TrainerEingeben(ref List<Trainer> trainer, List<Team> teams) {
            bool erfolgreich = false;
            int anzahlTrainer = 0;
            while (!erfolgreich) {
                Console.Write("Wie viele Trainer wollen Sie anlegen: ");
                erfolgreich = int.TryParse(Console.ReadLine(), out anzahlTrainer);
            }
            for (int i = 0; i < anzahlTrainer; i++) {
                Console.Write("Name des Trainers: ");
                string name = Console.ReadLine();
                Console.Write("Name des Teams: ");
                string teamName = Console.ReadLine();
                Team team = GetTeamByName(teamName, teams);
                trainer.Add(new Trainer(name, team));
            }
        }

        private static void SpielerEingeben(ref List<Spieler> spieler, List<Team> teams) {
            bool erfolgreich = false;
            int anzahlSpieler = 0;
            while (!erfolgreich) {
                Console.Write("Wie viele Spieler wollen Sie anlegen: ");
                erfolgreich = int.TryParse(Console.ReadLine(), out anzahlSpieler);
            }
            for (int i = 0; i < anzahlSpieler; i++) {
                Console.Write("Name des Spielers: ");
                string name = Console.ReadLine();
                Console.Write("Position: ");
                string position = Console.ReadLine();
                Console.Write("Name des Teams: ");
                string teamName = Console.ReadLine();
                Team team = GetTeamByName(teamName, teams);
                spieler.Add(new Spieler(name,position, team));
            }
        }

        private static void TeamsEingeben(ref List<Team> teams) {
            bool erfolgreich = false;
            int anzahlTeams = 0;
            while (!erfolgreich) {
                Console.Write("Wie viele Teams wollen Sie anlegen: ");
                erfolgreich = int.TryParse(Console.ReadLine(), out anzahlTeams);
            }
            for (int i = 0; i < anzahlTeams; i++) {
                Console.Write("Name des Teams: ");
                string name = Console.ReadLine();
                teams.Add(new Team(name));
            }
        }

        private static void SpieleEingeben(ref List<Spiel> spiele, List<Team> teams) {
            bool erfolgreich = false;
            int anzahlSpiele = 0;
            while (!erfolgreich) {
                Console.Write("Wie viele Spiele wollen Sie anlegen: ");
                erfolgreich = int.TryParse(Console.ReadLine(), out anzahlSpiele);
            }
            for (int i = 0; i < anzahlSpiele; i++) {
                Console.Write("Ort des Spiels: ");
                string ort = Console.ReadLine();
                Console.Write("Datum des Spiels(JJJJ/MM/DD HH:MM.SS): ");
                string datum = Console.ReadLine();
                DateTime datumKonvertiert = DateTime.Parse(datum);
                Console.Write("Team 1: ");
                string team1 = Console.ReadLine();
                Team Team1 = GetTeamByName(team1, teams);
                Console.Write("Team 2: ");
                string team2 = Console.ReadLine();
                Team Team2 = GetTeamByName(team2, teams);
                Team[] teamArray = { Team1, Team2 };
                List<Team> teamList = new List<Team>(teamArray );
                spiele.Add(new Spiel(datumKonvertiert, ort, teamList));
            }
        }

        private static Team GetTeamByName(string name, List<Team> teams) {
            foreach (Team team in teams) {
                if (team.Name == name) {
                    return team;
                }
            }
            return null;
        }
    }
}
