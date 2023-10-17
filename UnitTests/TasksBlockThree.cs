using System.Globalization;
using System.Xml.Linq;

namespace UnitTests;

public class TasksBlockThree
{
    // 1. Напишите метод, который принимает XML-документ, содержащий информацию о списке студентов(элементы<student>), и возвращает их имена в виде списка строк.
    public List<string> GetStudentNames(XDocument xmlDocument)
    {
        var studentNames = xmlDocument
            .Descendants("student")
            .Select(student => student.Element("name")?.Value)
            .Where(name => !string.IsNullOrEmpty(name))
            .ToList();

        return studentNames;
    }

    // 2. Напишите метод, который принимает XML-документ, содержащий информацию о списке товаров(элементы<product>), и возвращает сумму цен товаров этого списка.
    public double GetTotalPriceOfProducts(XDocument xmlDocument)
    {
        var query = from product in xmlDocument.Descendants("product")
                    let priceElement = product.Element("price")
                    where priceElement != null
                    let price = decimal.Parse(priceElement.Value, CultureInfo.InvariantCulture)
                    select price;

        return (double)query.Sum();
    }

    // 3. Напишите метод, который принимает XML-документ, содержащий информацию о списке студентов (элементы <student>), и возвращает количество студентов, у которых оценка по математике выше 90.
    public int GetNumberOfStudentsWithMathGradeAbove90(XDocument xmlDocument)
    {
        var query = from student in xmlDocument.Descendants("student")
                    let mathGradeElement = student.Element("mathGrade")
                    where mathGradeElement != null
                    let mathGrade = int.Parse(mathGradeElement.Value)
                    where mathGrade > 90
                    select student;

        return query.Count();
    }

    // 4. Напишите метод, который принимает XML-документ, содержащий информацию о списке книг (элементы <book>), и возвращает список названий книг, отсортированный по возрастанию года издания.
    public List<string> GetBookTitlesOrderedByYear(XDocument xmlDocument)
    {
        var query = from book in xmlDocument.Descendants("book")
                    let yearElement = book.Element("year")
                    where yearElement != null
                    let year = int.Parse(yearElement.Value)
                    orderby year
                    select book.Element("title")?.Value;

        return query.ToList();
    }

    // 5. Напишите метод, который принимает XML-документ, содержащий информацию о списке студентов (элементы <student>), и возвращает средний балл по английскому языку для студентов, у которых оценка по математике выше 80.
    public double GetAverageEnglishGradeForMathGradeAbove80(XDocument xmlDocument)
    {
        var query = from student in xmlDocument.Descendants("student")
                    let mathElement = student.Element("mathGrade")
                    let englishElement = student.Element("englishGrade")
                    where mathElement != null && englishElement != null
                    let mathGrade = int.Parse(mathElement.Value)
                    let englishGrade = double.Parse(englishElement.Value, CultureInfo.InvariantCulture)
                    where mathGrade > 80
                    select englishGrade;

        return query.Average();
    }
}
