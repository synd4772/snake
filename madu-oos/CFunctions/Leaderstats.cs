using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos.CFunctions
{
    public class Leaderstats
    {
        UsersManagment um;
        public List<Dictionary<string, int>> currentUsers;
        

        public Leaderstats(UsersManagment um)
        {
            this.um = um;
            this.currentUsers = um.GetAllUsers();

        }

        public List<Dictionary<string, int>> SortBestPlayers(int? limit)
        {
            List<Dictionary<string, int>> bestPlayers = new List<Dictionary<string, int>>();
            int index = -1;
            foreach (var user in currentUsers)
            {
                index++;
                if (index == 0)
                {
                    bestPlayers.Add(user);
                }
                else
                {
                    bool status = true;
                    int index2 = -1;
                    foreach (var bestPlayer in bestPlayers)
                    {
                        index2++;
                        if (bestPlayer.Values.ElementAt(0) < user.Values.ElementAt(0))
                        {
                            bestPlayers.Insert(index2, user);
                            status = false;
                            break;
                        }
                    }
                    if (status)
                    {
                        bestPlayers.Add(user);
                    }
                    
                }
            }
            if (limit != null)
            {
                return (bestPlayers.Count > limit) ? bestPlayers.GetRange(0, (int) limit) : bestPlayers;
            }
            return bestPlayers;
        }

        public void ShowBestUsers()
        {
            int limit = 5;
            Console.WriteLine($"Top {limit} of best players:");
            foreach (var user in this.SortBestPlayers(limit)) 
            {
                Console.WriteLine($"{user.Keys.ElementAt(0)} - {user.Values.ElementAt(0)}");
            }
        }
   }
}
