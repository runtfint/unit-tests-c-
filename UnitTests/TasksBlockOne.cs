using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests;

public class TasksBlockOne
{
	// Задание 1:
	// Найти все имена из списка, которые начинаются на букву "A".
	public List<string> FindNamesStartingWithA(List<string> names)
	{
		var sortedNames = names.Where(name => name[0] == 'A').ToList();
		return sortedNames;
	}


	// Задание 2:
	// Найти средний возраст из списка пользователей.
	public double CalculateAverageAge(List<User> users)
	{
		double averageAge = users.Average(user => user.Age);
		return averageAge;
	}


	// Задание 3:
	// Отсортировать список чисел по убыванию.
	public List<int> SortNumbersDescending(List<int> numbers)
	{
		var sortedNumbers = numbers.OrderByDescending(num => num).ToList();
		return sortedNumbers;

	}


	// Задание 4:
	// Проверить, содержит ли список хотя бы одно число, кратное 5.
	public bool CheckIfAnyNumberIsMultipleOfFive(List<int> numbers)
	{
		bool checkMultipleOf5 = numbers.Any(num => num % 5 == 0);
		return checkMultipleOf5;
	}


	// Задание 5:
	// Вычислить сумму всех положительных чисел из списка.
	public int CalculateSumOfPositiveNumbers(List<int> numbers)
	{
		int sumOfPositives = numbers.Where(num => num > 0).Sum();
		return sumOfPositives;
	}


	// Задание 6:
	// Найти самое большое число из списка.
	public int FindLargestNumber(List<int> numbers)
	{
		int max = numbers.Max();
		return max;
	}


	// Задание 7:
	// Получить список уникальных городов из списка пользователей.
	public List<string> GetUniqueCities(List<User> users)
	{
		List<string> uniqueCities = users.Select(user => user.City).Distinct().ToList();
		return uniqueCities;
    }


    // Задание 8:
    // Отфильтровать список имен, оставив только имена длиной больше 5 символов.
    public List<string> FilterNamesByLength(List<string> names)
	{
		var filteredNames = names.Where(name => name.Length > 5).ToList();
		return filteredNames;
	}


	// Задание 9:
	// Получить список пользователей, чьи имена начинаются на гласные буквы.
	public List<User> GetUsersWithNamesStartingWithVowel(List<User> users)
	{
        var startingWithVowel = users.Where(user => "AEIOUaeiou".Contains(user.Name[0])).ToList();
		return startingWithVowel;
    }


	// Задание 10:
	// Получить список чисел, возведенных в квадрат.
	public List<int> GetSquaredNumbers(List<int> numbers)
	{
        var squaredNumbers = numbers.Select(num => num * num).ToList();
		return squaredNumbers;
    }
}
