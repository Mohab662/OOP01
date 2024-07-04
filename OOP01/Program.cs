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
            #region Problem1
            for (int i = 0; i < Enum.GetValues(typeof(WeekDays)).Length; i++)
            {
                Console.WriteLine((WeekDays)i);
            }
            #endregion


            #region Problem2
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


            #region Problem3
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


            #region Problem4
            Permissions permissions = Permissions.Read | Permissions.write;

            Console.WriteLine("Initial permissions: " + permissions);

            permissions |= Permissions.Execute;
            Console.WriteLine("Added Execute permission: " + permissions);

            permissions &= ~Permissions.write;
            Console.WriteLine("Removed Write permission: " + permissions);

            Console.WriteLine("Has Read permission: " + (permissions.HasFlag(Permissions.Read)));
            Console.WriteLine("Has Delete permission: " + (permissions.HasFlag(Permissions.Delete)));
            #endregion

            # region  Problem5
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
            #region Problem6
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
            #region Problem7
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
