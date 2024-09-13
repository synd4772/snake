using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos
{
    public class UsersManagment
    {

        public string[] currentLines { get; private set; }
        public string path { get; private set; }

        public UsersManagment(string path) {
            this.path = path;
            this.Update();
        }
        public void UpdateFile()
        {

        }
        public void UpdateList()
        {
            StreamReader sr = new StreamReader(this.path);
            this.currentLines = sr.ReadToEnd().Split("/n");
            sr.Close();
        }
        public bool HasUser(string username)
        {
            this.Update();
            foreach (string line in this.currentLines)
            {
                if (line == username)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddUser(string username, int score)
        {
            using(StreamWriter)

        }
    }
}
