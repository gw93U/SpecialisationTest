// Написать программу, которая из имеющегося массива строк формирует новый массив из строк,
// длина которых меньше, либо равна 3 символам.
// Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма.
// При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

int InputNumber(string text) // Ручной ввод целого числа
{
    int number = 0;
    do
    {
        Console.Write(text);
    } while (int.TryParse(Console.ReadLine(), out number) == false);
    return number;
}

int InputLimitedNumber(string text, int min, int max) // Ручной ввод целого числа с ограничениями
{
    int number = 0;
    do
    {
        number = InputNumber(text);
    } while (number < min || number > max);
    return number;
}

string StringArray(string[] array, string split) // Преобразование массива в строку с заданным разделителем
{
    int length = array.Length;
    string textArray = String.Empty;
    for (int i = 0; i < length; i++)
    {
        textArray +=  "\""+array[i]+"\"";
        if (i < length - 1)
            textArray += split;
    }
    return textArray;
}

void InputStringArray(string[] array) // Ручной ввод строкового массива
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = Console.ReadLine();
    }
}

string[] GetArrayWithLimitedValues(string[] array, int charLimit)
{
    int count = 0;
    int n = array.Length;
    for (int i = 0; i < n; i++)
    {
        if (array[i].Length <= charLimit)
            count++;
    }
    string[] resultArray = new string[count];
    count = 0;
    for (int i = 0; i < n; i++)
    {
        if (array[i].Length <= charLimit)
        {
            resultArray[count] = array[i];
            count++;
        }
    }
    return resultArray;
}

int stringLimit = 3;
int n = InputLimitedNumber("Введите размерность массива: ", 1, Int32.MaxValue);
string[] array = new string[n];
Console.WriteLine("Введите строковые значения массива:");
InputStringArray(array);
Console.WriteLine($"Массив: [{StringArray(array, ", ")}]");
string[] newArray = GetArrayWithLimitedValues(array, stringLimit);
Console.WriteLine(
    $"Новый массив, со значениями строк, длиной не больше {stringLimit} символов: [{StringArray(newArray, ", ")}]"
);
