using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ6
{
    public class DataManager
    {
        private string connectionString;

        public DataManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Методы для работы с данными о странах
        public void AddCountry(string name, float area, string continent)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Countries (Name, Area, Continent) VALUES (@Name, @Area, @Continent)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Area", area);
                command.Parameters.AddWithValue("@Continent", continent);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCountry(int countryID, string newName, float newArea, string newContinent)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Countries SET Name = @NewName, Area = @NewArea, Continent = @NewContinent WHERE CountryID = @CountryID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewName", newName);
                command.Parameters.AddWithValue("@NewArea", newArea);
                command.Parameters.AddWithValue("@NewContinent", newContinent);
                command.Parameters.AddWithValue("@CountryID", countryID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCountry(int countryID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Countries WHERE CountryID = @CountryID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CountryID", countryID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Методы для работы с данными о столицах
        public void AddCapital(string name, int population, int countryID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Capitals (Name, Population, CountryID) VALUES (@Name, @Population, @CountryID)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Population", population);
                command.Parameters.AddWithValue("@CountryID", countryID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCapital(int capitalID, string newName, int newPopulation, int newCountryID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Capitals SET Name = @NewName, Population = @NewPopulation, CountryID = @NewCountryID WHERE CapitalID = @CapitalID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewName", newName);
                command.Parameters.AddWithValue("@NewPopulation", newPopulation);
                command.Parameters.AddWithValue("@NewCountryID", newCountryID);
                command.Parameters.AddWithValue("@CapitalID", capitalID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCapital(int capitalID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Capitals WHERE CapitalID = @CapitalID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CapitalID", capitalID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Методы для работы с данными о городах
        public void AddCity(string name, int population, int countryID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Cities (Name, Population, CountryID) VALUES (@Name, @Population, @CountryID)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Population", population);
                command.Parameters.AddWithValue("@CountryID", countryID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCity(int cityID, string newName, int newPopulation, int newCountryID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cities SET Name = @NewName, Population = @NewPopulation, CountryID = @NewCountryID WHERE CityID = @CityID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewName", newName);
                command.Parameters.AddWithValue("@NewPopulation", newPopulation);
                command.Parameters.AddWithValue("@NewCountryID", newCountryID);
                command.Parameters.AddWithValue("@CityID", cityID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCity(int cityID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Cities WHERE CityID = @CityID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CityID", cityID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
