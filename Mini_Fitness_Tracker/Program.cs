
﻿using System;
using FitnesTraker_project;

namespace FitnesTraker_project
{
    class Program
    {
        static User currentUser = null;
        static ProgressTracker tracker = new ProgressTracker();

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("\t\t\t\t   ====   Mini Fitness Tracker   ====\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t\t\t 1. Create New User");
                Console.WriteLine("\t\t\t\t\t 2. Update Profile");
                Console.WriteLine("\t\t\t\t\t 3. Log New Workout");
                Console.WriteLine("\t\t\t\t\t 4. View Today's Workout Plan");
                Console.WriteLine("\t\t\t\t\t 5. View Weekly Progress");
                Console.WriteLine("\t\t\t\t\t 6. View User Profile");
                Console.WriteLine("\t\t\t\t\t 7. Exit\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t\t\t\t\t Choose an option: ");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        CreateNewUser();
                        break;
                    case 2:
                        UpdateProfile();
                        break;
                    case 3:
                        LogWorkout();
                        break;
                    case 4:
                        ViewWorkoutPlan();
                        break;
                    case 5:
                        tracker.ShowWeeklyProgress();
                        Pause();
                        break;
                    case 6:
                        ViewProfile();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\t\t\t\t Exiting program. Goodbye!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\t\t\t\t\t Invalid choice. Try again.");
                        Pause();
                        break;
                }
            } while (choice != 7);
        }

        static void CreateNewUser()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\t=== Create New User Account ===\n");
            Console.ResetColor();

            // إدخال الاسم
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\t Enter Your Name:");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\t\t\t\t Name cannot be empty. Please try again.");
                Console.ResetColor();
                Console.Write("\t\t\t\t\t ");
                name = Console.ReadLine();
            }

            // إدخال العمر
            int age;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t\t\t Enter Age:");
                Console.ResetColor();
                Console.Write("\t\t\t\t\t ");
                string ageInput = Console.ReadLine();

                if (int.TryParse(ageInput, out age) && age > 18)
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\t\t Invalid age! Please enter a valid number  (+18).");
                    Console.ResetColor();
                }
            }

            // إدخال الوزن
            double weight;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t\t\t Enter Weight (kg):");
                Console.ResetColor();
                Console.Write("\t\t\t\t\t ");
                string weightInput = Console.ReadLine();

                if (double.TryParse(weightInput, out weight) && weight > 40)
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\t\t Invalid weight! Please enter a valid number (+40).");
                    Console.ResetColor();
                }
            }

            // إدخال الطول
            double height;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t\t\t Enter Height (cm):");
                Console.ResetColor();
                Console.Write("\t\t\t\t\t ");
                string heightInput = Console.ReadLine();

                if (double.TryParse(heightInput, out height) && height > 100)
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\t\t Invalid height! Please enter a valid number (+100).");
                    Console.ResetColor();
                }
            }

            // إنشاء الحساب
            currentUser = new User(name, age, weight, height);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\t\t\t\t User profile created successfully!");
            Console.WriteLine($"\t\t\t\t\t Welcome, {currentUser.Name}!");
            Console.ResetColor();

            Pause();
        }


        static void UpdateProfile()
        {
            if (currentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\t\t\t\t No user profile found. Please create a user first.");
                Pause();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\t\t\t\t\t Enter new name: ");
            string newName = Console.ReadLine();

            Console.Write("\t\t\t\t\t Enter new age: ");
            int newAge = int.Parse(Console.ReadLine());

            Console.Write("\t\t\t\t\t Enter new weight (kg): ");
            double newWeight = double.Parse(Console.ReadLine());

            Console.Write("\t\t\t\t\t Enter new height (cm): ");
            double newHeight = double.Parse(Console.ReadLine());

            currentUser.UpdateProfile(newName, newAge, newWeight, newHeight);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\t\t\t\t Profile updated successfully!");
            Pause();
        }

        static void LogWorkout()
        {
            if (currentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\t No user profile found. Please create a user first.");
                Pause();
                return;
            }

            Workout workout = new Workout();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t Enter exercises (type 'done' when finished):");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                // إدخال اسم التمرين
                Console.Write("\t\t\t\t\t Exercise name: ");
                string name = Console.ReadLine().Trim(); // .Trim() لإزالة أي مسافات أو تاب

                // شرط الخروج
                if (name.ToLower() == "done")
                {
                    break;
                }

                // إدخال المدة
                int duration;
                while (true)
                {
                    Console.Write("\t\t\t\t\t Duration (minutes): ");
                    string durationInput = Console.ReadLine();

                    if (int.TryParse(durationInput, out duration) && duration > 0)
                    {
                        break; // تم إدخال قيمة صحيحة
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\t\t\t\t\t Invalid duration. Please enter a positive number.");
                    }
                }

                // إدخال السعرات المحروقة في الدقيقة
                double calPerMin;
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\t\t\t\t\t Calories burned per minute: ");
                    string calInput = Console.ReadLine();

                    if (double.TryParse(calInput, out calPerMin) && calPerMin > 0)
                    {
                        break; // تم إدخال قيمة صحيحة
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\t\t\t Invalid value. Please enter a positive number.");
                    }
                }

                // إضافة التمرين
                workout.AddExercise(name, duration, calPerMin);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t\t\t Exercise added successfully!\n");
            }

            // حفظ التمرينات
            currentUser.WorkoutPlans.Add(workout);
            tracker.UpdateProgress(workout);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t\t Workout logged successfully!");
            Pause();
        }


        static void ViewWorkoutPlan()
        {
            if (currentUser == null || currentUser.WorkoutPlans.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\t\t\t\t No workout plans available.");
                Pause();
                return;
            }

            var latestWorkout = currentUser.WorkoutPlans[currentUser.WorkoutPlans.Count - 1];
            latestWorkout.ShowPlan();

            Pause();
        }

        static void ViewProfile()
        {
            if (currentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\t\t\t\t No user profile found. Please create a user first.");
            }
            else
            {
                currentUser.ViewProfile();
            }
            Pause();
        }

        static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\t\t\t\t\t Press any key to continue...");
            Console.ReadKey();
        }
    }
}