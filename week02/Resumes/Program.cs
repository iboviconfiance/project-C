using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Manager";
        job1._company = "Microsoft";
        job1._startYear = 2017;
        job1._endYear = 2023;

        Job job2 = new Job();
        job2._jobTitle = "software Engineer";
        job2._company = "Google";
        job2._startYear = 2023;
        job2._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Confiance Ibovi";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}