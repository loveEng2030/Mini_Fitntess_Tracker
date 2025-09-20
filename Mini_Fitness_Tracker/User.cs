using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesTraker_project
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public List<Workout> WorkoutPlans { get; set; }

        public User(string name, int age, double weight, double height)//Constructor
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
            WorkoutPlans = new List<Workout>();
        }

        public void UpdateProfile(string NewName, int NewAge, double NewWeight, double NewHeight)//UpdateProfile_method
        {
            Name = NewName;
            Age = NewAge;
            Weight = NewWeight;
            Height = NewHeight;
        }

        public void ViewProfile()//ViewProfile_Method
        {
            Console.WriteLine($"\t\t\t\t\t Name :{Name}");
            Console.WriteLine($"\t\t\t\t\t Age :{Age}");
            Console.WriteLine($"\t\t\t\t\t Weight :{Weight}");
            Console.WriteLine($"\t\t\t\t\t Height :{Height}");
            Console.WriteLine($"\t\t\t\t\t Workout Plans Count :{WorkoutPlans.Count}");
        }
    }
}