using System;

namespace Returning_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new DummyRepository();

            ExceptionTest(repo);

            HandleTest(repo);
        }

        public static void ExceptionTest(DummyRepository repo)
        {
            // No Exception occurs due to access, could perform unintended actions
            try
            {
                var obj = repo.GetReturnDefault("id");
                Console.WriteLine(obj.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Exception thrown, difficult to tell what caused it especially in more complex code.
            try
            {
                var obj = repo.GetReturnNull("id");
                Console.WriteLine(obj.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // If the bool output is ignored then the same issues as above
            try
            {
                repo.TryGetDummy("id", out var obj);
                Console.WriteLine(obj.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void HandleTest(DummyRepository repo)
        {
            var test1 = repo.GetReturnDefault("id");
            if (test1 == new DummyModel()) // Does not work by default, would require overloading
            {
                Console.WriteLine("Object was not found");
            }

            if (test1.Equals(new DummyModel())) // Does not work by default would require overloading
            {
                Console.WriteLine("Object was not found");
            }

            if (string.IsNullOrEmpty(test1.Id)) // Requires knowledge about the model
            {
                Console.WriteLine("Object was not found");
            }

            var test2 = repo.GetReturnNull("id");
            if (test2 is null) 
            {
                Console.WriteLine("Object was not found");
            }

            if (!repo.TryGetDummy("id", out var test3)) // test3 is still available but we know explicitly if it exists or not
            {
                Console.WriteLine("Object was not found");
            }

            test3 = new DummyModel();
        }
    }
}
