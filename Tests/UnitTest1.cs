using System.Data;
using System.Xml.Linq;

using UnitTests;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void FindNamesStartingWithA_ShouldReturnMatchingNames()
        {
            // Arrange
            List<string> names = new List<string> { "Amy", "Adam", "Anna", "Emily", "Noah" };
            List<string> expected = new List<string> { "Amy", "Adam", "Anna" };
            var sut = new TasksBlockOne();

            // Act
            var result = sut.FindNamesStartingWithA(names);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateAverageAge_ShouldReturnAverageAge()
        {
            // Arrange
            List<User> users = GenerateUserList();
            double expected = 34;
            var sut = new TasksBlockOne();

            // Act
            double result = sut.CalculateAverageAge(users);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortNumbersDescending_ShouldReturnSortedNumbersDescending()
        {
            // Arrange
            List<int> numbers = new List<int> { 7, 10, 3, 5, 8 };
            List<int> expected = new List<int> { 10, 8, 7, 5, 3 };
            var sut = new TasksBlockOne();

            // Act
            var result = sut.SortNumbersDescending(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckIfAnyNumberIsMultipleOfFive_ShouldReturnTrueIfMultipleOfFiveExists()
        {
            // Arrange
            List<int> numbers = new List<int> { 12, 25, 8 };
            bool expected = true;
            var sut = new TasksBlockOne();

            // Act
            bool result = sut.CheckIfAnyNumberIsMultipleOfFive(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateSumOfPositiveNumbers_ShouldReturnSumOfPositiveNumbers()
        {
            // Arrange
            List<int> numbers = new List<int> { -3, 5, 10, -2, 12 };
            int expected = 27;
            var sut = new TasksBlockOne();

            // Act
            int result = sut.CalculateSumOfPositiveNumbers(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindLargestNumber_ShouldReturnLargestNumber()
        {
            // Arrange
            List<int> numbers = new List<int> { 7, 10, 3, 5, 8 };
            int expected = 10;
            var sut = new TasksBlockOne();

            // Act
            int result = sut.FindLargestNumber(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetUniqueCities_ShouldReturnUniqueCities()
        {
            // Arrange
            List<User> users = GenerateUserList();
            List<string> expected = new List<string> { "New York", "London", "Paris" };
            var sut = new TasksBlockOne();

            // Act
            var result = sut.GetUniqueCities(users);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FilterNamesByLength_ShouldReturnFilteredNamesByLength()
        {
            // Arrange
            List<string> names = new List<string> { "John", "Alice", "Amy", "Samantha", "Benjamin", "Anna", "Victoria" };
            List<string> expected = new List<string> { "Samantha", "Benjamin", "Victoria" };
            var sut = new TasksBlockOne();

            // Act
            var result = sut.FilterNamesByLength(names);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetUsersWithNamesStartingWithVowel_ShouldReturnUsersWithNamesStartingWithVowel()
        {
            // Arrange
            List<User> users = GenerateUserList();
            List<string> expected = new List<string>
            {
                "Alice",
                "Olivia"
            };
            var sut = new TasksBlockOne();

            // Act
            var result = sut.GetUsersWithNamesStartingWithVowel(users);

            // Assert
            Assert.Equal(expected.Order(), result.Select(u => u.Name).ToList().Order());
        }

        [Fact]
        public void GetSquaredNumbers_ShouldReturnSquaredNumbers()
        {
            // Arrange
            List<int> numbers = new List<int> { 5, 7, 8, -4, 10 };
            List<int> expected = new List<int> { 25, 49, 64, 16, 100 };
            var sut = new TasksBlockOne();

            // Act
            var result = sut.GetSquaredNumbers(numbers);

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void CalculateSum_ShouldReturnCorrectSum()
        {
            // Arrange
            DataTable table = new DataTable();
            table.Columns.Add("Amount", typeof(decimal));
            table.Rows.Add(10.5m);
            table.Rows.Add(15.3m);
            table.Rows.Add(DBNull.Value);
            table.Rows.Add(20.7m);
            decimal expectedSum = 46.5m;

            // Act
            decimal actualSum = new TasksBlockTwo().CalculateSum(table);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void CountCompletedRows_ShouldReturnCorrectCount()
        {
            // Arrange
            DataTable table = new DataTable();
            table.Columns.Add("IsCompleted", typeof(bool));
            table.Rows.Add(true);
            table.Rows.Add(DBNull.Value);
            table.Rows.Add(false);
            table.Rows.Add(true);
            int expectedCount = 2;

            // Act
            int actualCount = new TasksBlockTwo().CountCompletedRows(table);

            // Assert
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void FindMinPriceRow_ShouldReturnCorrectRow()
        {
            // Arrange
            DataTable table = new DataTable();
            table.Columns.Add("Price", typeof(decimal));
            table.Rows.Add(10.5m);
            table.Rows.Add(15.3m);
            table.Rows.Add(DBNull.Value);
            table.Rows.Add(5.7m);
            DataRow expectedRow = table.Rows[3];

            // Act
            DataRow actualRow = new TasksBlockTwo().FindMinPriceRow(table);

            // Assert
            Assert.Equal(expectedRow, actualRow);
        }

        [Fact]
        public void ContainsNameStartingWithA_ShouldReturnTrueIfMatchFound()
        {
            // Arrange
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Rows.Add("Amy");
            table.Rows.Add("Ben");
            table.Rows.Add("Charlie");
            table.Rows.Add("David");

            // Act
            bool result = new TasksBlockTwo().ContainsNameStartingWithA(table);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetUniqueCategories_ShouldReturnUniqueCategories()
        {
            // Arrange
            DataTable table = new DataTable();
            table.Columns.Add("Category", typeof(string));
            table.Rows.Add("Electronics");
            table.Rows.Add("Clothing");
            table.Rows.Add(DBNull.Value);
            table.Rows.Add("Electronics");
            List<string> expectedCategories = new List<string> { "Electronics", "Clothing" };

            // Act
            List<string> actualCategories = new TasksBlockTwo().GetUniqueCategories(table);

            // Assert
            Assert.Equal(expectedCategories, actualCategories);
        }

        [Fact]
        public void GetOldCats_ReturnsCorrectResult()
        {
            // Arrange
            DataTable animalsTable = CreateAnimalsTable();
            var expected = new List<string> { "Тимоша" };
            var sut = new UnitTests.TasksBlockTwo();
            // Act
            var result = sut.GetOldCats(animalsTable);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetPhoneNumbersStartingWithM_ReturnsCorrectResult()
        {
            // Arrange
            DataTable animalsTable = CreateAnimalsTable();
            var expected = new List<string> { "+7 (345) 678-90-12", "+7 (890) 123-45-67" };
            var sut = new UnitTests.TasksBlockTwo();
            // Act
            var result = sut.GetPhoneNumbersStartingWithM(animalsTable);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAnimalTypesCount_ReturnsCorrectResult()
        {
            // Arrange
            DataTable animalsTable = CreateAnimalsTable();
            var expected = new Dictionary<string, int>
            {
                { "Кошка", 4 },
                { "Собака", 3 },
                { "Хомяк", 1 },
                { "Насекомое", 2 }
            };
            var sut = new UnitTests.TasksBlockTwo();

            // Act
            var result = sut.GetAnimalTypesCount(animalsTable);

            // Assert
            Assert.Equal(expected, result);
        }



        [Fact]
        public void GetStudentNames_ShouldReturnCorrectListOfNames()
        {
            // Arrange
            var xmlDocument = new XDocument(
                new XElement("students",
                    new XElement("student",
                        new XElement("name", "John")),
                    new XElement("student",
                        new XElement("name", "Alice"))));

            var service = new TasksBlockThree();

            // Act
            var result = service.GetStudentNames(xmlDocument);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains("John", result);
            Assert.Contains("Alice", result);
        }


        [Fact]
        public void GetTotalPriceOfProducts_ShouldReturnCorrectTotalPrice()
        {
            // Arrange
            var xmlDocument = new XDocument(
                new XElement("products",
                    new XElement("product",
                        new XElement("name", "Product 1"),
                        new XElement("price", "10.5")),
                    new XElement("product",
                        new XElement("name", "Product 2"),
                        new XElement("price", "19.9"))));

            var service = new TasksBlockThree();

            // Act
            var result = service.GetTotalPriceOfProducts(xmlDocument);

            // Assert
            Assert.Equal(30.4, result);
        }

        [Fact]
        public void GetNumberOfStudentsWithMathGradeAbove90_ShouldReturnCorrectCount()
        {
            // Arrange
            var xmlDocument = new XDocument(
                new XElement("students",
                    new XElement("student",
                        new XElement("name", "John"),
                        new XElement("mathGrade", "95")),
                    new XElement("student",
                        new XElement("name", "Alice"),
                        new XElement("mathGrade", "85"))));

            var service = new TasksBlockThree();

            // Act
            var result = service.GetNumberOfStudentsWithMathGradeAbove90(xmlDocument);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void GetBookTitlesOrderedByYear_ShouldReturnTitlesInAscendingOrder()
        {
            // Arrange
            var xmlDocument = new XDocument(
                new XElement("books",
                    new XElement("book",
                        new XElement("title", "Book 1"),
                        new XElement("year", "2000")),
                    new XElement("book",
                        new XElement("title", "Book 2"),
                        new XElement("year", "1995"))));

            var service = new TasksBlockThree();

            // Act
            var result = service.GetBookTitlesOrderedByYear(xmlDocument);

            // Assert
            var expectedOrder = new List<string> { "Book 2", "Book 1" };
            Assert.Equal(expectedOrder, result);
        }

        [Fact]
        public void GetAverageEnglishGradeForMathGradeAbove80_ShouldReturnCorrectAverageGrade()
        {
            // Arrange
            var xmlDocument = new XDocument(
                new XElement("students",
                    new XElement("student",
                        new XElement("name", "John"),
                        new XElement("mathGrade", "85"),
                        new XElement("englishGrade", "90")),
                    new XElement("student",
                        new XElement("name", "Alice"),
                        new XElement("mathGrade", "75"),
                        new XElement("englishGrade", "80"))));

            var service = new TasksBlockThree();

            // Act
            var result = service.GetAverageEnglishGradeForMathGradeAbove80(xmlDocument);

            // Assert
            Assert.Equal(90, result);
        }


        // ��������������� ����� ��� ��������� ������ �������������
        private List<User> GenerateUserList()
        {
            List<User> users = new List<User>
        {
            new User { Name = "John", Age = 25, City = "New York" },
            new User { Name = "Alice", Age = 30, City = "London" },
            new User { Name = "Bob", Age = 40, City = "Paris" },
            new User { Name = "Michael", Age = 28, City = "New York" },
            new User { Name = "Samantha", Age = 35, City = "Paris" },
            new User { Name = "Benjamin", Age = 48, City = "London" },
            new User { Name = "Olivia", Age = 32, City = "New York" }
        };

            return users;
        }

        // ��������������� ����� ��� ��������� ������ ��������
        private DataTable CreateAnimalsTable()
        {
            DataTable animalsTable = new DataTable();
            animalsTable.Columns.Add("Имя животного", typeof(string));
            animalsTable.Columns.Add("Тип животного", typeof(string));
            animalsTable.Columns.Add("Возраст животного", typeof(int));
            animalsTable.Columns.Add("Телефон хозяина", typeof(string));

            animalsTable.Rows.Add("Барсик", "Кошка", 3, "+7 (123) 456-78-90");
            animalsTable.Rows.Add("Рекс", "Собака", 5, "+7 (234) 567-89-01");
            animalsTable.Rows.Add("Мурзик", "Кошка", 2, "+7 (345) 678-90-12");
            animalsTable.Rows.Add("Хомяк", "Хомяк", 1, "+7 (456) 789-01-23");
            animalsTable.Rows.Add("Бабочка", "Насекомое", 0, "+7 (567) 890-12-34");
            animalsTable.Rows.Add("Тимоша", "Кошка", 7, "+7 (678) 901-23-45");
            animalsTable.Rows.Add("Джек", "Собака", 4, "+7 (789) 012-34-56");
            animalsTable.Rows.Add("Майло", "Собака", 2, "+7 (890) 123-45-67");
            animalsTable.Rows.Add("Черныш", "Кошка", 1, "+7 (901) 234-56-78");
            animalsTable.Rows.Add("Жучка", "Насекомое", 0, "+7 (012) 345-67-89");

            return animalsTable;
        }
    }

}