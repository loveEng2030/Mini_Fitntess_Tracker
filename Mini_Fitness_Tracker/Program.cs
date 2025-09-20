
﻿using System;
using System.Globalization;
using System.Text;
using FitnesTraker_project;

namespace FitnesTraker_project
{
    class Program
    {
        static User currentUser = null;
        static ProgressTracker tracker = new ProgressTracker();

        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
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
                //GetRandomDua();

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        CreateNewUser(); 
                        GetRandomDua();
                        break;
                    case 2:
                        UpdateProfile(); GetRandomDua();
                        break;
                    case 3:
                        LogWorkout(); GetRandomDua();
                        break;
                    case 4:
                        ViewWorkoutPlan(); GetRandomDua();
                        break;
                    case 5:
                        tracker.ShowWeeklyProgress(); GetRandomDua();
                        Pause();
                        break;
                    case 6:
                        ViewProfile(); GetRandomDua();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Green;
                        GetRandomDua();
                        Console.WriteLine("\t\t\t\t\t Exiting program. Goodbye!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        
                        Console.WriteLine("\t\t\t\t\t Invalid choice. Try again.");
                        GetRandomDua();
                        Pause();
                        break;
                }
            } while (choice != 7);
        }
        //\\\\\\\\\\\\\\\\\\\\\\\\\\/////////////////+++++++++++/////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        //انشاء حساب
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

                if (int.TryParse(ageInput, out age) && age > 10&&age<100)
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

                if (double.TryParse(weightInput, out weight) && weight >= 20&&weight<150)
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\t\t Invalid weight! Please enter a valid number (+20).");
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

                if (double.TryParse(heightInput, out height) && height > 100&&height<250)
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\t\t Invalid height! Please enter a valid number (+50).");
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
        
        /// /////////////////////\\///////////////++++++++++++++++++++++++++++++++++///////////////////\\\\\\\//////////////////////////
      

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
        /// <summary>
        /// ////////////////////////////////////****************************/////////////////////////////////////////////////
        /// </summary>
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

        //\/\///////////////////\/\/\\//\\/\\/\/\/\/\/\/\//\/\/\/\/\/\/\//////////////////\\/\/\/\/\/\/\/
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
      //  \//\/\/\/\/\\/\/\//\\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
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
        //\\\/\/\\/\/\/\/\/\//\\//\\/\/\/\/\\/\/\/\/\/\/\/\/\/\/\/\/\\/\/\/\/\/\/\/\/\/
        public static void GetRandomDua()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string[] duas = {
        "اللهم إني أسألك العفو والعافية",
        "اللهم اجعلني من الصالحين",
        "ربنا آتنا في الدنيا حسنة وفي الآخرة حسنة",
        "اللهم صل على محمد وعلى آل محمد",
        "اللهم اجعل عملي خالصًا لوجهك الكريم",
        "اللهم اهدني وسدد خطاي",
        "اللهم وفقني لما تحبه وترضاه",
        "اللهم ارزقني بر والدي",
        "اللهم اغفر لي ولوالدي وللمؤمنين جميعًا",
        "اللهم اجعل القرآن ربيع قلبي ونور صدري",
        "اللهم اجعلني من الذاكرين الشاكرين",
        "اللهم اكفني بحلالك عن حرامك واغنني بفضلك عمن سواك"
    };

            Random random = new Random();
            int indexDua = random.Next(duas.Length);

            // عكس النص العربي علشان يظهر مضبوط في الكونسول
            string finalDua = ReverseText(duas[indexDua]);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\t\t\t\t\t " +finalDua);
            Console.ResetColor();
        }

        // دالة لعكس النص بشكل صحيح مع الحركات
        private static string ReverseText(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var si = new StringInfo(input);
            int length = si.LengthInTextElements;
            string[] elements = new string[length];

            for (int i = 0; i < length; i++)
                elements[i] = si.SubstringByTextElements(i, 1);

            Array.Reverse(elements);
            return string.Concat(elements);
        }


        //\\\/\/\/\/\/\\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\\/\/\/\/\//\\//\\\/
        static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\t\t\t\t\t Press any key to continue...");
            Console.ReadKey();
        }
    }
}