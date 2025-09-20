
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesTraker_project
{
    // خطة التمرين اليومية
    public class Workout
    {
        // قائمة التمارين
        public List<Exercise> Exercises = new List<Exercise>();

        // إضافة تمرين
        public void AddExercise(string name, int duration, double calPerMin)
        {
            Exercise ex = new Exercise();
            ex.Name = name;
            ex.DurationMinutes = duration;
            ex.CaloriesPerMinute = calPerMin;

            Exercises.Add(ex);
        }

        // حساب إجمالي السعرات
        public double GetTotalCalories()
        {
            double total = 0;
            foreach (var ex in Exercises)
            {
                total += ex.GetCalories();
            }
            return total;
        }

        // عرض التمارين
        public void ShowPlan()
        {
            Console.WriteLine("\t\t\t\t\t Workout Plan:");
            foreach (var ex in Exercises)
            {
                Console.WriteLine($"\t\t\t\t\t - {ex.Name} | {ex.DurationMinutes} دقيقة | {ex.GetCalories()} سعر حراري");
            }
            Console.WriteLine($"إجمالي السعرات\t\t\t\t\t : {GetTotalCalories()}");
        }
    }
}