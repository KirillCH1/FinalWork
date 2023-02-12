
// Написать программу, которая из имеющегося массива строк формирует массив из строк, длинна которых меньше либо равна 3 символам. Первоначальный массив
// можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно 
// массивами. 


Console.Clear();

int size = EnteringArraySize("Введите размер массива: ", "Ошибка ввода");       // Запрашивает у пользователя размер массива
string[] array = new string[size];                                              // Инициализация массива
FillingArray(size);                                                             // Заполнение массива данными пользователя
string[] shortArray = ShortArray(FindSizeArray(array));                         // Инициализирует и заполняет массив строками <=3
PrintArray(array);                                                              // Выводит первый массив
Console.Write(" -> ");                                                          // Разделитель
PrintArray(shortArray);                                                         // Выводит второй массив


void PrintArray(string[] printArray)        // Выводит массив на экран
{
    Console.Write("[");
    for (int i = 0; i < printArray.Length; i++)
    {
        if (printArray[0] == "")
        {
            Console.Write("");
            break;
        }
        if (i == printArray.Length - 1)
        {
            Console.Write($"\"{printArray[i]}\"");
        }
        else
        {
            Console.Write($"\"{printArray[i]}\",");
        }
    }
    Console.Write("] ");
}

string[] ShortArray(int size)       // Заполняет массив элементами <= 3 из основного массива
{
    if (size == 0)
    {
        string[] shortArr = new string[1] { "" };
        return shortArr;
    }
    else
    {
        string[] shortArr = new string[size];
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Length <= 3)
            {
                shortArr[counter] = array[i];
                counter++;
            }
        }
        return shortArr;

    }
}

int FindSizeArray(string[] array)       // Определяет размер малого массива
{
    int sizeArray = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= 3)
        {
            sizeArray++;
        }
    }
    return sizeArray;
}

string[] FillingArray(int size)         // Заполняте основной массив данными пользователя
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"Введите {i + 1} элемент массива: ");
        array[i] = (Console.ReadLine() ?? "");
    }
    return array;
}

int EnteringArraySize(string message, string errorMessage)      // Задает размер основного массива
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect && userNumber > 0)
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}
