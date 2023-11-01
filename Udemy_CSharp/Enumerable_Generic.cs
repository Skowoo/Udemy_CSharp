using System.Collections;

namespace Udemy_CSharp
{
    public static class Enumerable_Generic
    {
        public static void PseudoMain()
        {
            var collection = new CustomCollection();

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class CustomCollection : IEnumerable<ExampleObj>
    {
        public List<ExampleObj> list;

        public CustomCollection()
        {
            list = new List<ExampleObj>();
            for (int i = 0; i < 10; i++)
                list.Add(new ExampleObj());
        }

        public IEnumerator<ExampleObj> GetEnumerator() //Enumerator for generic collections - return enumerator from in-class List
        {
            return ((IEnumerable<ExampleObj>)list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() //Enumerator for non-generic collections - return enumerator from in-class List (in this case optional)
        {
            return ((IEnumerable)list).GetEnumerator();
        }
    }

    public class ExampleObj
    {
        public static int Counter = 0;

        public string Name { get; set; }

        public bool HaveOptions { get; set; }

        public ExampleObj() 
        {
            Name = $"Object {++Counter}";
            HaveOptions = Counter % 2 == 0;
        }

        public override string ToString() => $"Name is {this.Name} and options are {this.HaveOptions}";
    }
}
