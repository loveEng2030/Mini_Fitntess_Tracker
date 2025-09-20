using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesTraker_project
{
    // علشان اعمل  التمرين
    public class Exercise
    {
        public string Name;
        public int DurationMinutes;
        public double CaloriesPerMinute;

        //  حساب السعرات المحروقة
        public double GetCalories()
        {
            return DurationMinutes * CaloriesPerMinute;
        }
    }
}