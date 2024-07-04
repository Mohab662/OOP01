namespace OOP01
{

    #region Problem1
    enum WeekDays
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
    #endregion

    #region Problem3
    enum Season
    {
        Spring, Summer, Autumn, Winter
    }


    #endregion

    #region Problem4
    [Flags]
    enum Permissions : byte
    {
        Read = 1, write = 2, Delete = 4, Execute = 8
    }

    #endregion

    #region Problem5
    enum Colors
    {
        Red, Green, Blue, Yellow, Orange, Purple
    }
    #endregion

    internal class Program
    {
        #region Problem6
        static double CalculateDistance(point p1, point p2)
        {
            ///d=√((x2 – x1)² + (y2 – y1)²) >>> Distance between two points 

            double dx = Math.Pow((p2.x - p1.x), 2);
            double dy = Math.Pow((p2.y - p1.y), 2);

            double res = Math.Sqrt(dx + dy);

            return res;

        } 
        #endregion
        static void Main(string[] args)
        {
            #region Q1: Create an enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this enum.
            for (int i = 0; i < Enum.GetValues(typeof(WeekDays)).Length; i++)
            {
                Console.WriteLine((WeekDays)i);
            }
            #endregion

            #region Q2: Define a struct "Person" with properties "Name" and "Age". Create an array of three "Person" objects and populate it with data. Then, write a C# program to display the details of all the persons in the array.
            Person[] people = new Person[3];


            people[0] = new Person { name = "Alice", age = 30 };
            people[1] = new Person { name = "Bob", age = 25 };
            people[2] = new Person { name = "Charlie", age = 42 };
            // Console.WriteLine(people[0].name);

            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine($"Person {i} Name is : {people[i].name} && Age is : {people[i].age}");
            }
            #endregion

            #region Q3: Create an enum called "Season" with the four seasons (Spring, Summer, Autumn, Winter) as its members. Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season. Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)
            {
                Console.WriteLine("enter season name");
                Season selectedSeason;
                string s = Console.ReadLine();
                Enum.TryParse<Season>(s, true, out selectedSeason);
                if (selectedSeason == Season.Spring)
                {
                    Console.WriteLine("March to May");
                }
                else if (selectedSeason == Season.Summer)
                {
                    Console.WriteLine("June to August");
                }
                else if (selectedSeason == Season.Autumn)
                {
                    Console.WriteLine("September to November");
                }
                else
                {
                    Console.WriteLine("December to February");
                }
            }
            #endregion

            #region Q4: Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum.
            Permissions permissions = Permissions.Read | Permissions.write;

            Console.WriteLine("Initial permissions: " + permissions);

            permissions |= Permissions.Execute;
            Console.WriteLine("Added Execute permission: " + permissions);

            permissions &= ~Permissions.write;
            Console.WriteLine("Removed Write permission: " + permissions);

            Console.WriteLine("Has Read permission: " + (permissions.HasFlag(Permissions.Read)));
            Console.WriteLine("Has Delete permission: " + (permissions.HasFlag(Permissions.Delete)));
            #endregion

            # region  Q5: Create an enum called "Colors" with the basic colors (Red, Green, Blue) as its members. Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.
            Console.Write("Enter a color: ");
            string colorInput = Console.ReadLine();

            Colors color;
            if (Enum.TryParse(colorInput, true, out color))
            {
                bool isPrimary = color == Colors.Red || color == Colors.Green || color == Colors.Blue;
                Console.WriteLine(color + " is " + (isPrimary ? "" : "not ") + "a primary color");
            }
            else
            {
                Console.WriteLine("Invalid color");
            }
            #endregion

            #region Q6: Create a struct called "Point" to represent a 2D point with properties "X" and "Y". Write a C# program that takes two points as input from the user and calculates the distance between them.
            bool flag = false;
            double x1, y1, x2, y2;

            ///point 1
            do
            {
                Console.Write("Enter Point X1 : ");
                flag = double.TryParse(Console.ReadLine(), out x1);
            }
            while (!flag);
            do
            {
                Console.Write("Enter Point Y1 : ");
                flag = double.TryParse(Console.ReadLine(), out y1);
            }
            while (!flag);

            /// point 2
            do
            {
                Console.Write("Enter Point X2 : ");
                flag = double.TryParse(Console.ReadLine(), out x2);
            }
            while (!flag);
            do
            {
                Console.Write("Enter Point Y2 : ");
                flag = double.TryParse(Console.ReadLine(), out y2);
            }
            while (!flag);

            point p1 = new point { x = x1, y = y1 };
            point p2 = new point { x = x2, y = y2 };

            Console.WriteLine(CalculateDistance(p1, p2));
            #endregion

            #region Q7: Create a struct called "Person" with properties "Name" and "Age". Write a C# program that takes details of 3 persons as input from the user and displays the name and age of the oldest person.
            bool flag1;
            int agge = 0;
            int oldestAge = 0, oldestAgeIndex = 0; ;

            Person2[] People = new Person2[3];

            for (int i = 0; i < People.Length; i++)
            {
                Console.Write($"Enter Person{i} Name : ");
                People[i].Name = Console.ReadLine();

                do
                {
                    Console.Write($"Enter Person{i} Age : ");
                    flag1 = int.TryParse(Console.ReadLine(), out agge);
                }
                while (!flag1);
                People[i].Age = agge;
            }
            oldestAge = People[0].Age;
            for (int i = 1; i < People.Length; i++)
            {

                if (People[i].Age > oldestAge)
                {
                    oldestAge = People[i].Age;
                    oldestAgeIndex = i;
                }
            }
            Console.WriteLine($"The Oldest Name Is : {People[oldestAgeIndex].Name} && Age Is : {People[oldestAgeIndex].Age}");

            #endregion
        }
    }
}
