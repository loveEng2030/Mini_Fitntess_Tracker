using System;
using System.Collections.Generic;
using FitnesTraker_project;

namespace FitnesTraker_project
{
    public class ProgressTracker
    {
        public double WeeklyCalories;
        public int TotalWorkoutTime;
        public Dictionary<string, int> ExerciseStats;

        public ProgressTracker()
        {
            WeeklyCalories = 0;
            TotalWorkoutTime = 0;
            ExerciseStats = new Dictionary<string, int>();
        }

        // تحديث التقدم الأسبوعي بعد إضافة خطة جديدة
        public void UpdateProgress(Workout workout)
        {
            foreach (var exercise in workout.Exercises)
            {
                WeeklyCalories += exercise.GetCalories();
                TotalWorkoutTime += exercise.DurationMinutes;

                if (ExerciseStats.ContainsKey(exercise.Name))
                    ExerciseStats[exercise.Name]++;
                else
                    ExerciseStats[exercise.Name] = 1;
            }
        }

        // عرض إحصائيات الأسبوع
        public void ShowWeeklyProgress()
        {
            Console.WriteLine("\n\t\t\t\t\t ==== Weekly Progress ====");
            Console.WriteLine($"\t\t\t\t\t Total Calories Burned: {WeeklyCalories}");
            Console.WriteLine($"\t\t\t\t\t Total Workout Time: {TotalWorkoutTime} minutes");

            Console.WriteLine("\t\t\t\t\t Exercise Breakdown:");
            foreach (var stat in ExerciseStats)
            {
                Console.WriteLine($"\t\t\t\t\t - {stat.Key}: {stat.Value} times");
            }
        }
    }
}