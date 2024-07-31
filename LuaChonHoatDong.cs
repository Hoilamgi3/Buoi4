using System;
using System.Collections.Generic;
using System.Linq;

class Activity
{
    public int StartTime { get; set; }
    public int EndTime { get; set; }
}

class ActivitySelection
{
    static void Main()
    {
        var activities = new List<Activity>
        {
            new Activity { StartTime = 1, EndTime = 4 },
            new Activity { StartTime = 3, EndTime = 5 },
            new Activity { StartTime = 0, EndTime = 6 },
            new Activity { StartTime = 5, EndTime = 7 },
            new Activity { StartTime = 8, EndTime = 9 }
        };

        List<Activity> selectedActivities = SelectActivities(activities);

        Console.WriteLine("Selected activities:");
        foreach (var activity in selectedActivities)
        {
            Console.WriteLine("Start: {0}, End: {1}" ,activity.StartTime,activity.EndTime);
        }
        Console.ReadLine();
    }

    public static List<Activity> SelectActivities(List<Activity> activities)
    {
        // Sort activities by their ending time
        var sortedActivities = activities.OrderBy(a => a.EndTime).ToList();

        List<Activity> result = new List<Activity>();
        int lastEndTime = 0;

        foreach (var activity in sortedActivities)
        {
            if (activity.StartTime >= lastEndTime)
            {
                result.Add(activity);
                lastEndTime = activity.EndTime;
            }
        }

        return result;
    }
}
