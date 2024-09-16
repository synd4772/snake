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
                    foreach (string line in this.currentLines)
                    {
                        outputFile.WriteLine(line.Trim());
                    }
                }
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
                    outputFile.WriteLine(username);
                    outputFile.WriteLine(score);
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
