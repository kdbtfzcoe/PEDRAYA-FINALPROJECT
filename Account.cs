using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROJECT
{
    internal static class Account
    {
        private static Dictionary<string, string> Students = new Dictionary<string, string>();

        static Account()
        {
            DummyStudents();
        }
        private static void DummyStudents()
        {
            Students.Add("2024-00001-BN-0", "Sky Ruiz");
            Students.Add("2024-00002-BN-0", "Soleia Astrid");
            Students.Add("2024-00003-BN-0", "Angelu Marquez");
            Students.Add("2024-00004-BN-0", "Iphejaenia Magallanes");
            Students.Add("2024-00005-BN-0", "David Gludo");
            Students.Add("2024-00006-BN-0", "Shiebella Manguiat");
            Students.Add("2024-00007-BN-0", "Erica Dofitas");
            Students.Add("2024-00008-BN-0", "John Marx Bantog");
            Students.Add("2024-00009-BN-0", "Nicholas Lacambra");
            Students.Add("2024-000010-BN-0", "Julianna Carino");
        }

        public static bool Login(string userNum, out string studentName)
        {

            studentName = null;

            if (Students.ContainsKey(userNum))
            {
                studentName = Students[userNum];
                return true;
            }

            return false;
        }
    }
}