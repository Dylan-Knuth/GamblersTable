using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Player
    {
        public string name { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int balance { get; set; }

        public Player(string plName)
        {
            string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"../../player.txt");

            string[] playerData = File.ReadAllLines(path);

            foreach (String s in playerData)
            {
                string[] tokens = s.Split(',');
                name = Convert.ToString(tokens[0]);
                wins = Convert.ToInt32(tokens[1]);
                losses = Convert.ToInt32(tokens[2]);
                balance = Convert.ToInt32(tokens[3]);

                if (plName != name)
                {
                    name = plName;
                    wins = 0;
                    losses = 0;
                    balance = 50;
                    var playerInfo = $"{plName},{wins},{losses},{balance}";
                    File.WriteAllText(path, playerInfo);

                }
                else
                    Console.WriteLine("\nWelcome Back!!!!");
            }

        }
    }
}