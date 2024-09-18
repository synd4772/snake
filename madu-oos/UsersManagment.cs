using madu_oos.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos
{
    public class UsersManagment
    {

        public List<string> currentLines { get; private set; }
        public string path { get; private set; }

        public UsersManagment(string path) {
            using(StreamWriter f = new StreamWriter(path, true)) { }
            this.path = path;
            this.currentLines = new List<string> { };
            this.UpdateList();
        }
        public void UpdateFile()
        {
            using(StreamWriter outputFile = new StreamWriter(this.path))
            {
                int index = -1;
                foreach (string line in this.currentLines)
                {
                    index++;
                    if (index == this.currentLines.Count - 1)
                    {
                        outputFile.Write(line.Trim());
                    }
                    else
                    {
                        outputFile.Write($"{line.Trim()}\n");
                    }
                }
            }
        }
        public List<Dictionary<string, int>> GetAllUsers()
        {
            this.UpdateFile();
            this.UpdateList();
            List<Dictionary<string, int>> users = new List<Dictionary<string, int>>();
            if (this.currentLines.Count > 1)
            {
                for (int i = 0; i <= this.currentLines.Count; i = i + 2)
                {
                    if (this.currentLines.Count <= i) { break; }
                    users.Add(new Dictionary<string, int>() { { this.currentLines[i], int.Parse(this.currentLines[i + 1]) } });
                }
            }

            return users;
        }

        public void UpdateList()
        {
            StreamReader sr = new StreamReader(this.path);
            this.currentLines = sr.ReadToEnd().Split("\n").ToList();
            sr.Close();
        }
        public int HasUser(string username)
        {
            for (int i = 0; i < currentLines.Count; i++)
            {
                if (this.currentLines[i].Trim() == username.Trim())
                {    
                    return i;
                }
            }
            return -1;
        }

        public void AddUser(string username, int score)
        {
            if (this.HasUser(username) == -1)
            {
                using(StreamWriter outputFile = new StreamWriter(this.path, true))
                {
                    
                    string sym = (this.currentLines.Count != 1) ? "\n" : "";
                    outputFile.Write($"{sym}{username}\n{score}");
                }
                this.UpdateList();
            }
        }

        public void UpdateUser(string username, int score)
        {
            int userIndex = this.HasUser(username);
            //Console.WriteLine($"{userIndex} UPDATE USER");

            if (userIndex != -1)
            {
                this.currentLines[userIndex + 1] = score.ToString();
                this.UpdateFile();
            }
        }
    }
}
