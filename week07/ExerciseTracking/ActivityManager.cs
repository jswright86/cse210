using System;
using System.Security.Authentication.ExtendedProtection;
using ExerciseTracker;
namespace ExerciseTracker
{
    public class ActivityManager
{
        public static void CreateActivities()
        {
            //creates activities in an activities list calling each constructor from each Activity class
            List<Activity> activities = new List<Activity>();
            activities.Add(new Running(DateTime.Now, 60, 10.5f));
            activities.Add(new Swimming(DateTime.Now, 60, 55));
            activities.Add(new Bicycling(DateTime.Now, 90, 35));

            List<string> activitySummaries = new List<string>();
            foreach (Activity activity in activities)
            {
                string summary = activity.GetSummary();
                activitySummaries.Add(summary);
                
            }
            //Shows activitySummaries list
            Console.WriteLine("\n---Summary of Activities---");
            for (int i = 0; i < activitySummaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {activitySummaries[i]}");
            }
            


    }

}
}