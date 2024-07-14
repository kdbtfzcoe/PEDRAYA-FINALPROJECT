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
    internal class Enrollment
    {
        private List<string> enrolledSubjects = new List<string>();

        public void EligibleToEnroll(string studentNumber, string studentName)
        {
            List<Grades> studentGrades = Grades.GetGrades();
            int currentYear = Grades.ShowGrades(studentNumber, studentName);

            switch (currentYear)
            {
                case 1:
                    if (CheckEligibility(studentGrades, "CALCULUS 2", "DIFFERENTIAL EQUATIONS"))
                    {
                        enrolledSubjects.Add("DIFFERENTIAL EQUATIONS");
                    }

                    if (CheckEligibility(studentGrades, "OBJECT ORIENTED PROGRAMMING", "DATA STRUCTURES AND ALGORITHMS"))
                    {
                        enrolledSubjects.Add("DATA STRUCTURES AND ALGORITHMS");
                    }

                    if (CheckEligibility(studentGrades, "CALCULUS 2", "FUNDAMENTALS OF ELECTRICAL CIRCUITS"))
                    {
                        enrolledSubjects.Add("FUNDAMENTALS OF ELECTRICAL CIRCUITS");
                    }
                    Console.WriteLine("ART APPRECIATION = Enrolled");
                    
                    Console.WriteLine("POLITICS, GOVERNANCE AND CITIZENSHIP = Enrolled");
                    
                    
                    Console.WriteLine("BUHAY AT MGA SINULAT NI RIZAL = Enrolled");
                    Console.WriteLine("FILIPINOLOHIYA AT PAMBANSANG KAUNLARAN = Enrolled");
                    Console.WriteLine("PHYSICAL ACTIVITY TOWARDS HEALTH AND FITNESS 3 = Enrolled");

                    enrolledSubjects.Add("ART APPRECIATION");
                    enrolledSubjects.Add("POLITICS, GOVERNANCE AND CITIZENSHIP");
                 
                    enrolledSubjects.Add("BUHAY AT MGA SINULAT NI RIZAL");
                    enrolledSubjects.Add("FILIPINOLOHIYA AT PAMBANSANG KAUNLARAN");
                    enrolledSubjects.Add("PHYSICAL ACTIVITY TOWARDS HEALTH AND FITNESS 3");

                    break;
                case 2:
                    if (CheckEligibility(studentGrades, "FUNDAMENTALS OF ELECTRONIC CIRCUITS", "LOGIC CIRCUITS"))
                    {
                        enrolledSubjects.Add("LOGIC CIRCUITS");
                    }

                    if (CheckEligibility(studentGrades, "FUNDAMENTALS OF ELECTRONIC CIRCUITS", "DATA AND DIGITAL COMMUNICATIONS"))
                    {
                        enrolledSubjects.Add("DATA AND DIGITAL COMMUNICATIONS");
                    }

                    if (CheckEligibility(studentGrades, "FUNDAMENTALS OF ELECTRONIC CIRCUITS", "INTRODUCTION TO HARDWARE DESCRIPTIVE LANGUAGE (HDL)"))
                    {
                        enrolledSubjects.Add("INTRODUCTION TO HARDWARE DESCRIPTIVE LANGUAGE (HDL)");
                    }
                    Console.WriteLine("TECHNICAL REPORT WRITING = Enrolled");

                    enrolledSubjects.Add("TECHNICAL REPORT WRITING");

                    if (CheckEligibility(studentGrades, "FUNDAMENTALS OF ELECTRONIC CIRCUITS", "COMPUTER ENGINEERING"))
                    {
                        enrolledSubjects.Add("COMPUTER ENGINEERING");
                    }

                    if (CheckEligibility(studentGrades, "FUNDAMENTALS OF ELECTRONIC CIRCUITS", "DRAFTING AND DESIGN"))
                    {
                        enrolledSubjects.Add("DRAFTING AND DESIGN");
                    }

                    if (CheckEligibility(studentGrades, "FUNDAMENTALS OF ELECTRONIC CIRCUITS", "FUNDAMENTALS OF MIXED SIGNALS AND SENSORS"))
                    {
                        enrolledSubjects.Add("FUNDAMENTALS OF MIXED SIGNALS AND SENSORS");
                    }

                    Console.WriteLine("CPE ELECTIVE 1 = Enrolled");
                    Console.WriteLine("ENGINEERING ECONOMICS = Enrolled");

                    enrolledSubjects.Add("CPE ELECTIVE 1");
                    enrolledSubjects.Add("ENGINEERING ECONOMICS");
                    break;
                case 3:

                    Console.WriteLine("DATABASE MANAGEMENT SYSTEMS = Enrolled");
                    enrolledSubjects.Add("DATABASE MANAGEMENT SYSTEMS");

                    if (CheckEligibility(studentGrades, "MICROPROCESSORS", "COMPUTER ARCHITECTURE AND ORGANIZATION"))
                    {
                        enrolledSubjects.Add("COMPUTER ARCHITECTURE AND ORGANIZATION");
                    }

                    if (CheckEligibility(studentGrades, "MICROPROCESSORS", "CPE PRACTICE AND DESIGN 1"))
                    {
                        enrolledSubjects.Add("CPE PRACTICE AND DESIGN 1");
                    }

                    if (CheckEligibility(studentGrades, "FEEDBACK AND CONTROL SYSTEM", "DIGITAL SIGNAL PROCESSING"))
                    {
                        enrolledSubjects.Add("DIGITAL SIGNAL PROCESSING");
                    }

                    Console.WriteLine("CPE ELECTIVE 3 = Enrolled");
                    Console.WriteLine("READING VISUAL ARTS = Enrolled");
                    enrolledSubjects.Add("CPE ELECTIVE 3");
                    enrolledSubjects.Add("READING VISUAL ARTS");
                    break;
            }

            PrintEnrollmentResult(studentNumber, studentName, enrolledSubjects);
        }


        private bool CheckEligibility(List<Grades> studentGrades, string prerequisiteSubject, string subjectToEnroll)
        {
            Grades prerequisiteGrade = null;
            foreach (Grades grade in studentGrades) 
            { 
                if (grade.Subject == prerequisiteSubject)
                {
                    prerequisiteGrade = grade;
                    break;
                }
            
            }

            if (prerequisiteGrade != null && prerequisiteGrade.GradeValue == 5.00)
            {
                Console.WriteLine($"*{subjectToEnroll} = Failed to Enroll. Must not have a failing grade of 5.00 in {prerequisiteSubject}");
                return false;
            }
            else
            {
                Console.WriteLine($"{subjectToEnroll} = Enrolled");
                return true;
            }

        }
        public void PrintEnrollmentResult(string studentNumber, string studentName, List<string> enrolledSubjects)
        {
            Console.WriteLine("Processing... press any key to proceed");
            Console.ReadLine();
            Console.Clear();

            int column1Width = 20;
            int column2Width = 30;

            string separator = new string('-', column1Width + column2Width + 5);
            string headerName = String.Format("| {0,-" + column1Width + "} | {1,-" + column2Width + "} |", "Student Name", studentName);
            string studentNumberLine = String.Format("| {0,-" + column1Width + "} | {1,-" + column2Width + "} |", "Student Number", studentNumber);
            string subjectHeader = String.Format("| {0,-" + (column1Width + column2Width + 3) + "} |", "Subjects");

            Console.WriteLine("Enrollment Status:");
            Console.WriteLine(separator);
            Console.WriteLine(headerName);
            Console.WriteLine(studentNumberLine);
            Console.WriteLine(separator);
            Console.WriteLine("Status: Officially Enrolled");
            Console.WriteLine(subjectHeader);
            Console.WriteLine(separator);
            foreach (var subject in enrolledSubjects)
            {
                Console.WriteLine(String.Format("| {0,-" + (column1Width + column2Width + 3) + "} |", subject));
            }
            Console.WriteLine(separator);
        }
    }
}
    


