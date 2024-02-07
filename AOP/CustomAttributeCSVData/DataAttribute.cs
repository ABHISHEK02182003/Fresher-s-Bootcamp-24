using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public abstract class DataAttribute : Attribute
{
    public abstract IEnumerable<object[]> GetData(MethodInfo methodInfo);
}
