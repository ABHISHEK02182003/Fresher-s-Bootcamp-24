using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class CsvDataAttribute : DataAttribute
{
    private readonly string filePath;
    private readonly bool hasHeaders;

    public CsvDataAttribute(string filePath, bool hasHeaders)
    {
        this.filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        this.hasHeaders = hasHeaders;
    }

    public override IEnumerable<object[]> GetData(MethodInfo methodInfo)
    {
        ValidateMethodInfo(methodInfo);

        var parameterTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();

        using (var streamReader = new StreamReader(filePath))
        {
            if (hasHeaders)
                streamReader.ReadLine(); // Skip headers if present

            string csvLine;
            while ((csvLine = streamReader.ReadLine()) != null)
            {
                var csvRow = csvLine.Split(',');
                yield return ConvertCsv(csvRow, parameterTypes);
            }
        }
    }

    private static void ValidateMethodInfo(MethodInfo methodInfo)
    {
        if (methodInfo == null)
            throw new ArgumentNullException(nameof(methodInfo), "Method info cannot be null.");

        if (methodInfo.GetParameters().Length == 0)
            throw new InvalidOperationException("Method must have parameters for CSV data.");
    }

    private static object[] ConvertCsv(string[] csvRow, Type[] parameterTypes)
    {
        var convertedObject = new object[parameterTypes.Length];

        for (int i = 0; i < parameterTypes.Length; i++)
        {
            if (i < csvRow.Length)
            {
                convertedObject[i] = Convert.ChangeType(csvRow[i], parameterTypes[i]);
            }
            else
            {
                convertedObject[i] = GetDefaultValue(parameterTypes[i]);
            }
        }

        return convertedObject;
    }

    private static object GetDefaultValue(Type type)
    {
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }
}
