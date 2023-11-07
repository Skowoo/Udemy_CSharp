namespace Udemy_CSharp
{
    public static class Delegates_Training
    {
        public static void PseudoMain()
        {
            AgeFilterExample();
        }

        #region Exercise 15

        public delegate float OperationDelegate(float first, float second);

        public static float ApplyOperation(float a, float b, OperationDelegate del) => del(a, b);

        public static float Add(float a, float b) => a + b;
        public static float Subtract(float a, float b) => a - b;
        public static float Multiply(float a, float b) => a * b;
        public static float Divide(float a, float b) => a / b;

        #endregion

        #region Age Filter example

        //Defining delegate time which takes Person p and return bool
        public delegate bool FilterDelegate(Person p);

        public static void AgeFilterExample()
        {
            Person p1 = new Person() { Name = "Michael", Age = 10 };
            Person p2 = new Person() { Name = "Pablo", Age = 15 };
            Person p3 = new Person() { Name = "Marcelo", Age = 30 }; ;
            Person p4 = new Person() { Name = "Jonas", Age = 40 };
            Person p5 = new Person() { Name = "David", Age = 80 };
            List<Person> people = new List<Person>() { p1, p2, p3, p4, p5 };

            //Call method with different methods
            DisplayPeople("Under age:", people, UnderAge);
            DisplayPeople("Over age:", people, OverAge);
            DisplayPeople("Elder age:", people, ElderAge);

            //Anonymous method - created like a variable
            FilterDelegate filter = delegate (Person input)
            {
                return input.Age > 20 && input.Age < 35;
            };
            DisplayPeople("Anonymous method:", people, filter);

            //Anonymous method created in single line:
            DisplayPeople("Pablo:", people, delegate (Person p) { return p.Name == "Pablo"; });

            //Anonymous method passed as Lambda expression
            DisplayPeople("Age = 10:", people, p => p.Age == 10);
        }

        //Method takes also delegate type (Which is something like blueprint of requested function
        //(takes Person, returns bool - as delegate defined in line 12))
        static void DisplayPeople(string title, List<Person> list, FilterDelegate filter)
        {
            Console.WriteLine(title);

            foreach (Person person in list)
                if (filter(person))
                    Console.WriteLine(person);

            Console.Write(Environment.NewLine);
        }

        //Filters (methods which matches delegate type)
        static bool UnderAge(Person input) => input.Age < 18;

        static bool OverAge(Person input) => input.Age > 18 && input.Age < 60;

        static bool ElderAge(Person input) => input.Age > 60;

        public class Person
        {
            public string? Name { get; set; }

            public int Age { get; set; }

            public override string ToString() => $"Name: {Name}, Age: {Age}";
        }

        #endregion

        #region RemoveAll example
        public static void RemoveAllExample()
        {
            List<string> names = new() { "Adam", "Marcin", "Paweł", "Damian" };

            Console.WriteLine("Before RemoveAll");
            foreach (string name in names)
                Console.WriteLine(name);

            //RemoveAll methods takes method as a argument - Filter in this example
            names.RemoveAll(Filter);

            Console.WriteLine("\nAfter RemoveAll");
            foreach (string name in names)
                Console.WriteLine(name);
        }

        //Method to be passed as delegate - must match delegate type.
        static bool Filter(string input) => input.Contains("i");
        #endregion
    }
}
