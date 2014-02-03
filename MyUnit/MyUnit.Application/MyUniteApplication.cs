using MyUnit.CustomAttributes;

namespace MyUnit.Application
{
    class MyUniteApplication
    {
        static void Main(string[] args)
        {
            var loadAssembly = new LoadAssembly();
            loadAssembly.ExecuteTest(args[0]);
        }
    }
}
