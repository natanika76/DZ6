using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Countries; Integrated Security=SSPI;";

            DataManager dataManager = new DataManager(connectionString);
 /*           
                        // Mетоды для работы с данными о странах
                        dataManager.AddCountry("Russia", 17098242.00f, "Europe");
                        dataManager.UpdateCountry(1, "Russian Federation", 17125242.00f, "Eurasia");
                        dataManager.DeleteCountry(1);
 
                        // Mетоды для работы с данными о столицах
                        dataManager.AddCapital("Moscow", 12692466, 1);
                        dataManager.UpdateCapital(1, "Moscow City", 12702466, 1);
                        dataManager.DeleteCapital(1);
           
                        // Mетоды для работы с данными о странах о городах
                        dataManager.AddCity("Saint Petersburg", 5383890, 1);
                        dataManager.UpdateCity(1, "St. Petersburg", 5384890, 1);
                        dataManager.DeleteCity(1);
          */   
            // Вызовы хранимых процедур
           
            DisplayTop3CapitalsByPopulation(dataManager);
         
            DisplayCityWithMaxPopulation(dataManager);

            Console.ReadLine();
        }
        static void DisplayTop3CapitalsByPopulation(DataManager dataManager)
        {
            Console.WriteLine("Top 3 capitals by population:");
            DataTable top3Capitals = ExecuteStoredProcedure(dataManager, "GetTop3CapitalsByPopulation");
            PrintDataTable(top3Capitals);
        }
        static void DisplayCityWithMaxPopulation(DataManager dataManager)
        {
            Console.WriteLine("City with the maximum population:");
            DataTable maxPopulationCity = ExecuteStoredProcedure(dataManager, "GetCityWithMaxPopulation");
            PrintDataTable(maxPopulationCity);
        }
        // Метод для выполнения хранимых процедур и получения результатов в виде DataTable
        static DataTable ExecuteStoredProcedure(DataManager dataManager, string procedureName)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Countries; Integrated Security=SSPI;";

            DataTable resultTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(resultTable);
            }
            return resultTable;
        }

        // Метод для печати результатов DataTable
        static void PrintDataTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    Console.WriteLine($"{col.ColumnName}: {row[col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
/*
 CREATE TABLE Countries (
    CountryID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Area FLOAT,
    Continent NVARCHAR(100)
);
-- Создание таблицы городов с инкрементом для CityID
CREATE TABLE Cities (
    CityID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Population INT,
    CountryID INT,
    FOREIGN KEY (CountryID) REFERENCES Countries(CountryID)
);
-- Создание таблицы столиц с инкрементом для CapitalID
CREATE TABLE Capitals (
    CapitalID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Population INT,
    CountryID INT,
    FOREIGN KEY (CountryID) REFERENCES Countries(CountryID)
);
-- Вставка данных в таблицу Countries
INSERT INTO Countries (Name, Area, Continent) VALUES ('USA', 9833517.00, 'North America');
INSERT INTO Countries (Name, Area, Continent) VALUES ('Canada', 9984670.00, 'North America');
INSERT INTO Countries (Name, Area, Continent) VALUES ('Russia', 17098242.00, 'Europe');
INSERT INTO Countries (Name, Area, Continent) VALUES ('China', 9596960.00, 'Asia');
INSERT INTO Countries (Name, Area, Continent) VALUES ('Brazil', 8515767.00, 'South America');

-- Данные для таблицы Cities
INSERT INTO Cities (Name, Population, CountryID) 
VALUES ('New York', 8537673, (SELECT CountryID FROM Countries WHERE Name = 'USA'));

INSERT INTO Cities (Name, Population, CountryID) 
VALUES ('Los Angeles', 3979576, (SELECT CountryID FROM Countries WHERE Name = 'USA'));

INSERT INTO Cities (Name, Population, CountryID) 
VALUES ('Moscow', 12692466, (SELECT CountryID FROM Countries WHERE Name = 'Russia'));

INSERT INTO Cities (Name, Population, CountryID) 
VALUES ('Saint Petersburg', 5383890, (SELECT CountryID FROM Countries WHERE Name = 'Russia'));

INSERT INTO Cities (Name, Population, CountryID) 
VALUES ('Beijing', 21516000, (SELECT CountryID FROM Countries WHERE Name = 'China'));

INSERT INTO Cities (Name, Population, CountryID) 
VALUES ('Shanghai', 24183300, (SELECT CountryID FROM Countries WHERE Name = 'China'));

INSERT INTO Cities (Name, Population, CountryID) 
VALUES ('Sao Paulo', 12252023, (SELECT CountryID FROM Countries WHERE Name = 'Brazil'));

INSERT INTO Cities (Name, Population, CountryID) 
VALUES ('Rio de Janeiro', 6747815, (SELECT CountryID FROM Countries WHERE Name = 'Brazil'));

-- Данные для таблицы Capitals
INSERT INTO Capitals (Name, Population, CountryID) 
VALUES ('Washington, D.C.', 705749, (SELECT CountryID FROM Countries WHERE Name = 'USA'));

INSERT INTO Capitals (Name, Population, CountryID) 
VALUES ('Ottawa', 934243, (SELECT CountryID FROM Countries WHERE Name = 'Canada'));

INSERT INTO Capitals (Name, Population, CountryID) 
VALUES ('Moscow', 12692466, (SELECT CountryID FROM Countries WHERE Name = 'Russia'));

INSERT INTO Capitals (Name, Population, CountryID) 
VALUES ('Beijing', 21516000, (SELECT CountryID FROM Countries WHERE Name = 'China'));

INSERT INTO Capitals (Name, Population, CountryID) 
VALUES ('Brasilia', 3015268, (SELECT CountryID FROM Countries WHERE Name = 'Brazil'));

CREATE PROCEDURE GetCityWithMaxPopulation
AS
BEGIN
    SELECT TOP 1 Name, Population
    FROM Cities
    ORDER BY Population DESC;
END;

CREATE PROCEDURE GetTop3CapitalsByPopulation
AS
BEGIN
    SELECT TOP 3 Name, Population
    FROM Capitals
    ORDER BY Population DESC;
END;
 */