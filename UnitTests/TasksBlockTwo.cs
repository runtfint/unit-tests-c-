using System.Collections.Generic;
using System.Data;

namespace UnitTests;

public class TasksBlockTwo
{
    // 1. Задание: Найти сумму чисел в столбце "Amount" таблицы.
    public decimal CalculateSum(DataTable table)
    {
        decimal sum = table.AsEnumerable()
            .Where(row => row["Amount"] != DBNull.Value)
            .Sum(row => (decimal)row["Amount"]);
        return sum;
    }

    // 2. Задание: Посчитать количество строк, содержащих значение "True" в столбце "IsCompleted".
    public int CountCompletedRows(DataTable table)
    {
        int count = table.AsEnumerable()
            .Count(row => row.Field<bool?>("IsCompleted") == true);
        return count;
    }

    // 3. Задание: Найти минимальное значение в столбце "Price" таблицы и вернуть соответствующую строку.
    public DataRow FindMinPriceRow(DataTable table)
    {
        var rowWithMinPrice = table.AsEnumerable()
            .Where(row => row["Price"] != DBNull.Value)
            .OrderBy(row => (decimal)row["Price"])
            .FirstOrDefault();
        return rowWithMinPrice;
    }

    // 4. Задание: Проверить, содержит ли столбец "Name" таблицы хотя бы одну строку, начинающуюся на букву "A".
    public bool ContainsNameStartingWithA(DataTable table)
    {
        bool containsNameStartingWithA = table.AsEnumerable()
            .Any(row => row.Field<string>("Name").StartsWith("A", StringComparison.OrdinalIgnoreCase));
        return containsNameStartingWithA;

    }

    // 5. Задание: Получить список уникальных значений в столбце "Category" таблицы.
    public List<string> GetUniqueCategories(DataTable table)
    {
        var uniqueCategories = table.AsEnumerable()
            .Where(row => row["Category"] != DBNull.Value)
            .Select(row => row.Field<string>("Category"))
            .Distinct()
            .ToList();
        return uniqueCategories;
    }
    
    // 6. Метод, который возвращает список всех животных, чей возраст больше 3 лет и тип животного - кошка.
    public List<string> GetOldCats(DataTable animalsTable)
    {
        var query = from row in animalsTable.AsEnumerable()
                    where row.Field<string>("Тип животного") == "Кошка"
                       && row.Field<int>("Возраст животного") > 3
                    select row.Field<string>("Имя животного");

        return query.ToList();
    }

    // 7. Метод, который возвращает список всех телефонов хозяев животных, чьи имена начинаются на букву "М".
    public List<string> GetPhoneNumbersStartingWithM(DataTable animalsTable)
    {
        var query = from row in animalsTable.AsEnumerable()
                    where row.Field<string>("Имя животного").StartsWith("М", StringComparison.OrdinalIgnoreCase)
                    select row.Field<string>("Телефон хозяина");

        return query.ToList();
    }

    // 8. Метод, который возвращает список всех типов животных и количество животных каждого типа.
    public Dictionary<string, int> GetAnimalTypesCount(DataTable animalsTable)
    {
        var query = from row in animalsTable.AsEnumerable()
                    group row by row.Field<string>("Тип животного") into g
                    select new
                    {
                        AnimalType = g.Key,
                        Count = g.Count()
                    };

        return query.ToDictionary(item => item.AnimalType, item => item.Count);
    }
}
