using System;
using System.Reflection;

public class ReflectionPPPI
{
    private int id;
    protected string name;
    public float radius;
    public double cost;
    internal bool flag;

    private void SetId(int id)
    {
        this.id = id;
    }

    public void PrintCost()
    {
        Console.WriteLine(cost);
    }

    protected void ManageFlag()
    {
        flag = Console.ReadLine() == "True";
    }

    public static void Main()
    {
        ReflectionPPPI reflection = new ReflectionPPPI();
        reflection.name = "Banana";
        System.Type type = reflection.name.GetType();
        Console.WriteLine(type);
        TypeInfo type1 = typeof(ReflectionPPPI).GetTypeInfo();
        Console.WriteLine(type1);
        IEnumerable<MethodInfo> methodList = type1.DeclaredMethods;
        foreach (MethodInfo method in methodList)
        {
            Console.WriteLine("Method: " + method);
        }

        Console.WriteLine("Members");
        foreach (MemberInfo mi in type1.GetMembers())
        {
            Console.WriteLine("Member: " + mi);
        }

        FieldInfo[] fi = type1.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        Console.WriteLine("FieldInfo");
        for (int i = 0; i < fi.Length; i++)
        {
            Console.WriteLine("Name            : {0}", fi[i].Name);
            Console.WriteLine("Declaring Type  : {0}", fi[i].DeclaringType);
            Console.WriteLine("MemberType      : {0}", fi[i].MemberType);
            Console.WriteLine("FieldType       : {0}", fi[i].FieldType);
            Console.WriteLine();
        }

        MethodInfo methodInfo = type1.GetDeclaredMethod("SetId");
        Console.WriteLine("Info about SetId method");
        Console.WriteLine("Return Type: " + methodInfo.ReturnType);
        Console.WriteLine("Return parameter: " + methodInfo.ReturnParameter);
        Console.WriteLine("Is abstract: " + methodInfo.IsAbstract);
        Console.WriteLine("Is public: " + methodInfo.IsPublic + "\n");

        Console.WriteLine("Invoke method with Reflection");
        methodInfo.Invoke(reflection, new object[]{5});
        Console.WriteLine("Id is " + reflection.id);
    }
}