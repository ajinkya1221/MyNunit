using MyUnit.CustomAttributes;

namespace MyUnit.Application
{
    class myUniteApplication
    {
        static void Main(string[] args)
        {
            LoadAssembly loadAssembly = new LoadAssembly();
            loadAssembly.ExecuteTest(args[0]);
        }
    }
}
