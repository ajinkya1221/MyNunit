using System;
using System.Collections.Generic;
using System.Reflection;

namespace MyUnit.CustomAttributes
{
    public class LoadAssembly
    {
        Assembly _assembly;
        List<Type> classes=new List<Type>();
        private Attribute _customattribute;
        public void ExecuteTest(string path)
        {
            try
            {
                _assembly = Assembly.LoadFrom(path);
            }
            catch (Exception)
            {
                Console.WriteLine("file not found");
            }
            GetClass(_assembly);
        }

        private void GetClass(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                Attribute customattribute = type.GetCustomAttribute(typeof (TestFixture));
                if (customattribute != null)
                {
                    classes.Add(type);
                }
            }
            GetMethod(classes);
        }

        private void GetMethod(List<Type> classes)
        {
            foreach (var type in classes)
            {
                MethodInfo[] methodInfos = type.GetMethods();
                foreach (var info in methodInfos)
                {
                    _customattribute = info.GetCustomAttribute(typeof(Test));
                    if (_customattribute != null)
                    {
                        try
                        {
                            info.Invoke(Activator.CreateInstance(type, null), null);
                            Console.WriteLine("success");
                            Console.WriteLine("\n(press enter to continue......)");
                            Console.ReadLine();
                        }
                        catch (TargetInvocationException ex)
                        {
                            Console.WriteLine(ex.InnerException.Message);
                            Console.WriteLine("\n(press enter to continue......)");
                            Console.ReadLine();
                        }

                    }
                }  
            }
        }
    }
}
