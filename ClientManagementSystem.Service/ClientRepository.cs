using ClientManagementSystem.DAL.Models;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace ClientManagementSystem.DAL
{
    public class ClientRepository
    {
        private readonly string _connectionString;
        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddClient(Client client)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Client (Name, Gender, DateOfBirth, EmailAddress, PhoneNumber, Occupation, Nationality, PreferredContactMethod) " + "VALUES (@Name, @Gender, @DateOfBirth, @EmailAddress, @PhoneNumber, @Occupation, @Nationality, @PreferredContactMethod)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", client.Name);
                cmd.Parameters.AddWithValue("@Gender", client.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", client.DateOfBirth);
                cmd.Parameters.AddWithValue("@EmailAddress", client.EmailAddress);
                cmd.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);
                cmd.Parameters.AddWithValue("@Occupation", client.Occupation);
                cmd.Parameters.AddWithValue("@Nationality", client.Nationality);
                cmd.Parameters.AddWithValue("@PreferredContactMethod", client.PreferredContactMethod);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public Client GetClient(int clientId)
        {
            Client client = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Client WHERE ClientId = @ClientId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ClientId", clientId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        client = new Client
                        {
                            ClientId = (int)reader["ClientId"],
                            Name = (string)reader["Name"],
                            Gender = (string)reader["Gender"],
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            EmailAddress = (string)reader["EmailAddress"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            Occupation = (string)reader["Occupation"],
                            Nationality = (string)reader["Nationality"],
                            PreferredContactMethod = (string)reader["PreferredContactMethod"]
                        };
                    }
                }
            }
            return client;
        }
        public List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Client";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            ClientId = (int)reader["ClientId"],
                            Name = (string)reader["Name"],
                            Gender = (string)reader["Gender"],
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            EmailAddress = (string)reader["EmailAddress"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            Occupation = (string)reader["Occupation"],
                            Nationality = (string)reader["Nationality"],
                            PreferredContactMethod = (string)reader["PreferredContactMethod"]
                        });
                    }
                }
            }
            return clients;
        }
    }
}
