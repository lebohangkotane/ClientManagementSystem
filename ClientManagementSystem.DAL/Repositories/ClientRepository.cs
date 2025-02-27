﻿using ClientManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClientManagementSystem.DAL.Repositories
{
    public class ClientRepository
    {
        private readonly string _connectionString;
        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int AddClient(Client client)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"INSERT INTO Client (FirstName, LastName, Gender, Nationality, Occupation) 
                                    VALUES (@FirstName, @LastName, @Gender, @Nationality, @Occupation);
                                    SELECT SCOPE_IDENTITY(); ";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", client.LastName);
                    cmd.Parameters.AddWithValue("@Gender", client.Gender);
                    cmd.Parameters.AddWithValue("@Occupation", client.Occupation);
                    cmd.Parameters.AddWithValue("@Nationality", client.Nationality);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    int newId = Convert.ToInt32(cmd.ExecuteScalar());

                    return newId;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Client GetClient(int clientId)
        {
            try
            {
                Client client = null;

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT * 
                                     FROM Client 
                                     WHERE ClientId = @ClientId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ClientId", clientId); con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            client = new Client
                            {
                                ClientId = (int)reader["ClientId"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Gender = (string)reader["Gender"],
                                Occupation = (string)reader["Occupation"],
                                Nationality = (string)reader["Nationality"],
                            };
                        }
                    }
                }

                return client;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public List<Client> GetAllClients()
        {
            try
            {
                List<Client> clients = new List<Client>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT * 
                                FROM Client";

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client
                            {
                                ClientId = (int)reader["ClientId"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Gender = (string)reader["Gender"],
                                Occupation = (string)reader["Occupation"],
                                Nationality = (string)reader["Nationality"],
                            });
                        }
                    }
                }

                return clients;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void UpdateClient(Client client)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE Client 
                                        SET FirstName = @FirstName, 
                                            LastName = @LastName, 
                                            Gender = @Gender, 
                                            Occupation = @Occupation, 
                                            Nationality = @Nationality
                                    WHERE ClientId = @ClientId";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@ClientId", client.ClientId);
                    cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", client.LastName);
                    cmd.Parameters.AddWithValue("@Gender", client.Gender);
                    cmd.Parameters.AddWithValue("@Occupation", client.Occupation);
                    cmd.Parameters.AddWithValue("@Nationality", client.Nationality);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void DeleteClient(int clientId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"DELETE FROM Client 
                                WHERE ClientId = @ClientId";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@ClientId", clientId);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
