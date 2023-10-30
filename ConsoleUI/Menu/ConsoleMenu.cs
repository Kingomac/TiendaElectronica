using System.Collections.Immutable;
using System.Numerics;

namespace ConsoleUI.Menu;

public class ConsoleMenu
{
    public static void Run(string title, IDictionary<string, Action> options)
    {
        var choose = int.MinValue;
        int i;
        var keys = options.Keys.ToList();
        var end = false;
        do
        {
            Console.WriteLine(title);
            for (i = 0; i < options.Count; i++) Console.WriteLine($"{i + 1}. {keys[i]}");

            try
            {
                choose = Convert.ToInt32(Console.ReadLine());
                end = true;
            }
            catch (FormatException e)
            {
                end = false;
            }
        } while (!end && (choose < 0 || choose > i));

        options[keys[choose - 1]].Invoke();
    }

    public static string AskForString(string question)
    {
        string? result;
        do
        {
            Console.WriteLine(question);
            result = Console.ReadLine();
        } while (string.IsNullOrEmpty(result));

        return result;
    }

    public static T AskForEnum<T>(string question) where T : Enum
    {
        var names = Enum.GetNames(typeof(T));
        int choose;
        do
        {
            Console.WriteLine(question);
            for (var i = 0; i < names.Length; i++) Console.WriteLine($"{i + 1}. {names[i]}");

            choose = AskForNumber<int>();
        } while (choose <= 0 || choose > names.Length);

        return (T)Enum.Parse(typeof(T), names[choose - 1], true);
    }

    public static T AskForNumber<T>(string question, T minValue, T maxValue)
        where T : INumber<T>, IMinMaxValue<T>, IParsable<T>, IFormattable
    {
        T result;
        bool isType;
        do
        {
            Console.WriteLine(question);
            try
            {
                result = T.Parse(Console.ReadLine(), null);
                isType = true;
            }
            catch (FormatException e)
            {
                isType = false;
                result = T.Zero;
            }
        } while (!isType || result < minValue || result > maxValue);

        return result;
    }

    public static T AskForNumber<T>(string question)
        where T : INumber<T>, IMinMaxValue<T>, IParsable<T>, IFormattable
    {
        return AskForNumber(question, T.MinValue, T.MaxValue);
    }

    public static T AskForNumber<T>()
        where T : INumber<T>, IMinMaxValue<T>, IParsable<T>, IFormattable
    {
        return AskForNumber<T>("");
    }

    public static bool AskForBool(string question)
    {
        string? read;
        do
        {
            Console.WriteLine(question + " (S/n)");
            read = Console.ReadLine().ToLower();
        } while (read != "" || (read.Length > 0 && (read[0] != 's' || read[0] != 'n')));

        return read.Length == 0 || read[0] == 's';
    }

    public static T AskForClass<T>() where T : struct
    {
        var numberTypes = new List<Type>
        {
            typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(int),
            typeof(uint), typeof(double), typeof(float), typeof(Int128), typeof(UInt128)
        }.ToImmutableList();
        var result = default(T);
        var type = typeof(T);
        var props = type.GetProperties();
        foreach (var prop in props)
        {
            var propType = prop.PropertyType;
            if (propType == typeof(string))
                prop.SetValue(result, AskForString(prop.Name));
            else if (numberTypes.Contains(propType))
                prop.SetValue(result, typeof(ConsoleMenu).GetMethod("AskForNumber").MakeGenericMethod(propType)
                    .Invoke(prop.Name, Array.Empty<object>()));
            else if (propType.IsEnum)
                prop.SetValue(result,
                    typeof(ConsoleMenu).GetMethod("AskForEnum").MakeGenericMethod(propType)
                        .Invoke(prop.Name, Array.Empty<object?>()));
        }

        return result;
    }
}