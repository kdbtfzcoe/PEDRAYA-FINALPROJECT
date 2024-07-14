using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace FINALPROJECT
{
    internal class Grades
    {
        public string Subject {  get; set; }
        public double GradeValue { get; set; }  

        static List<Grades> StudentGradesList = new List<Grades>();

        public static List <Grades> GetGrades() 
        {  
            return StudentGradesList; 
        }

        static List<double> StudentGrades = new List<double>();

        public static int ShowGrades(string studentNumber, string studentName)
        {
            Console.Write("Enter your current year: ");

            int year = Convert.ToInt32(Console.ReadLine());

            if (year <= 3) 
            {
                Console.Clear();
                InputGrades(year, studentNumber, studentName);
            }
            else { Console.WriteLine("Invalid year."); }
            return year;
            
        }

        public static void InputGrades(int year, string studentNumber, string studentName)
        {
            Console.WriteLine("Please provide your previous semester grades below:");
            switch (year)
            {

                case 1:

                    Grades calculus2 = new Grades { Subject = "CALCULUS 2", GradeValue = GetGrade("CALCULUS 2") };
                    StudentGradesList.Add(calculus2);

                    Grades physicsForEngineers = new Grades { Subject = "PHYSICS FOR ENGINEERS", GradeValue = GetGrade("PHYSICS FOR ENGINEERS") };
                    StudentGradesList.Add(physicsForEngineers);

                    Grades objectOrientedProgramming = new Grades { Subject = "OBJECT ORIENTED PROGRAMMING", GradeValue = GetGrade("OBJECT ORIENTED PROGRAMMING") };
                    StudentGradesList.Add(objectOrientedProgramming);

                    StudentGrades.Add(GetGrade("ENGINEERING DATA ANALYSIS"));
                    StudentGrades.Add(GetGrade("DISCRETE MATH"));
                    StudentGrades.Add(GetGrade("PURPOSIVE COMMUNICATION"));
                    StudentGrades.Add(GetGrade("PHYSICAL ACTIVITY TOWARDS HEALTH AND FITNESS 1"));
                    StudentGrades.Add(GetGrade("NATIONAL SERVICE TRAINING PROGRAM 2"));
                    StudentGrades.Add(GetGrade("COMPUTER HARDWARE FUNDAMENTALS"));

                    

                    break;

                case 2:

                    StudentGrades.Add(GetGrade("OPERATING SYSTEMS"));
                    StudentGrades.Add(GetGrade("READINGS IN PHILIPPINE HISTORY"));

                    Grades fundamentalsOfElectronicCircuits = new Grades { Subject = "FUNDAMENTALS OF ELECTRONIC CIRCUITS", GradeValue = GetGrade("FUNDAMENTALS OF ELECTRONIC CIRCUITS") };
                    StudentGradesList.Add(fundamentalsOfElectronicCircuits);

                    StudentGrades.Add(GetGrade("THE CONTEMPORARY WORLD"));
                    StudentGrades.Add(GetGrade("ADVANCED ENGINEERING MATHEMATICS FOR COMPUTER ENGINEERING"));
                    StudentGrades.Add(GetGrade("COMPUTER-AIDED DRAFTING"));
                    StudentGrades.Add(GetGrade("PANITIKANG FILIPINO"));
                    StudentGrades.Add(GetGrade("NUMERICAL METHODS"));
                    StudentGrades.Add(GetGrade("PHYSICAL ACTIVITY TOWARDS HEALTH AND FITNESS 4"));
                    break;

                case 3:
                    Grades feedbackAndControlSystem = new Grades { Subject = "FEEDBACK AND CONTROL SYSTEM", GradeValue = GetGrade("FEEDBACK AND CONTROL SYSTEM") };
                    StudentGradesList.Add(feedbackAndControlSystem);

                    StudentGrades.Add(GetGrade("COMPUTER NETWORKS AND SECURITY"));
                    StudentGrades.Add(GetGrade("FUNDAMENTALS OF ELECTRONIC CIRCUITS"));

                    Grades microprocessors = new Grades { Subject = "MICROPROCESSORS", GradeValue = GetGrade("MICROPROCESSORS") };
                    StudentGradesList.Add(microprocessors);

                    StudentGrades.Add(GetGrade("METHODS OF RESEARCH"));
                    StudentGrades.Add(GetGrade("TECHNOPRENEURSHIP 101"));
                    StudentGrades.Add(GetGrade("CPE ELECTIVE 2"));
                    StudentGrades.Add(GetGrade("CPE LAWS AND PROFESSIONAL PRACTICE"));
                    StudentGrades.Add(GetGrade("BASIC OCCUPATIONAL HEALTH AND SAFETY"));

                    break;

                default:

                    break;

            }

            CalculateGWA(StudentGradesList, StudentGrades, studentNumber, studentName);

        }
        static double GetGrade(string subject)
        {

           double grade;

           while (true)
           {
               Console.Write($"Enter grade for {subject}:");

                if (double.TryParse(Console.ReadLine(), out grade))
                {
                if (grade == 5.00 || grade == 3.00 ||
                    grade == 2.75 || grade == 2.50 || grade == 2.25 ||
                    grade == 2.00 || grade == 1.75 || grade == 1.50 ||
                    grade == 1.25 || grade == 1.00)
                {
                    break;
                }
                else
                {
                Console.WriteLine("Invalid number! Please enter a valid grade (ex. 2.00)");
                }

                }
                else
                { Console.WriteLine("Invalid!"); }
           }
           return grade;
        }

            static void CalculateGWA(List<Grades> grades, List<double> StudentGrades, string studentNumber, string studentName)
            {

                double studentGWA = StudentGrades.Average();

                Console.Clear();

                Console.WriteLine($"GWA: {studentGWA:F2}");

                if (studentGWA == 5.00)
                {
                    Console.WriteLine($"Student Number: {studentNumber}\n" +
                        $"Student Name: {studentName}\n" +
                        $"Remarks: You are not allowed to enroll. Reason: Failed GWA");
                }
                else { Console.WriteLine($"Student Number: {studentNumber}\n" +
                    $"Student Name: {studentName}\n" +
                    $"Remarks: You are allowed to enroll."); }

            Console.WriteLine("Press any key to proceed with the enrollment.");

            Console.ReadLine();

            Console.Clear();


            }

    }
}
