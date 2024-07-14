using System.Transactions;

namespace FINALPROJECT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PUP COMPUTER ENGINEERING DEPARTMENT ENROLLMENT | 1ST SEMESTER");

            int minAttempts = 0;
            int maxAttempts = 3;

            while (minAttempts < maxAttempts) 
            {

                Console.Write("Enter student number: ");
                string userInputStr = Console.ReadLine();

                if (Account.Login(userInputStr, out string studentName))
                {

                    Enrollment enrollment = new Enrollment();

                    enrollment.EligibleToEnroll(userInputStr, studentName);
                    break;

                }
                else
                {
                    Console.WriteLine("Invalid student number. Please try again. Maximum of 3 tries.");
                }

                minAttempts++;
            }

        }
    }
}
