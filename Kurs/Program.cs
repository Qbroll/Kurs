using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Linq.Expressions;

//метод обмена элементов
static void Swap(ref int value1, ref int value2)
{
    var temp = value1;
    value1 = value2;
    value2 = temp;
}

//метод для генерации следующего шага
static int GetNextStep(int s)
{
    s = s * 1000 / 1247;
    return s > 1 ? s : 1;
}

//сортировка расческой
static int[] CombSort(int[] array)
{
    var arrayLength = array.Length;
    var currentStep = arrayLength - 1;

    while (currentStep > 1)
    {
        for (int i = 0; i + currentStep < array.Length; i++)
        {
            if (array[i] > array[i + currentStep])
            {
                Swap(ref array[i], ref array[i + currentStep]);
            }
        }

        currentStep = GetNextStep(currentStep);
    }

    //сортировка пузырьком
    for (var i = 1; i < arrayLength; i++)
    {
        var swapFlag = false;
        for (var j = 0; j < arrayLength - i; j++)
        {
            if (array[j] > array[j + 1])
            {
                Swap(ref array[j], ref array[j + 1]);
                swapFlag = true;
            }
        }

        if (!swapFlag)
        {
            break;
        }
    }

    return array;
}

string path = "array.txt";
int [] ten = { };
int [] hundred = { };
int [] thousand = { };
int f = 0;

// асинхронное чтение
try
{
    using (StreamReader reader = new StreamReader(path))
    {
        string? line;

        while ((line = await reader.ReadLineAsync()) != null)
        {
            f++;

            if (f == 1)
            {
                ten = Array.ConvertAll(line.Split(','), s => int.Parse(s));
            }
            if (f == 2)
            {
                hundred = Array.ConvertAll(line.Split(','), s => int.Parse(s));
            }
            if (f == 3)
            {
                thousand = Array.ConvertAll(line.Split(','), s => int.Parse(s));
            }

        }
    }

}catch(Exception e)
{
    Console.WriteLine($"Ошибка: {e.Message}");
    return;
}


Console.WriteLine("Входные данные: {0}", string.Join(", ", ten));
Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", CombSort(ten)));

Console.WriteLine("Входные данные: {0}", string.Join(", ", hundred));
Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", CombSort(hundred)));

Console.WriteLine("Входные данные: {0}", string.Join(", ", thousand));
Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", CombSort(thousand)));
Console.ReadLine();