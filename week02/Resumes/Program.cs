using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "City of San Antonio";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2023;
        job1._endYear = 2025;

        job1.DisplayJobDetails();

        Job job2 = new Job();
        job2._company = "AT&T";
        job2._jobTitle = "Technician";
        job2._startYear = 2013;
        job2._endYear = 2022;

        job2.DisplayJobDetails();

        Resume myResume = new Resume();
        myResume._name = "Joshua Wrigjht";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}