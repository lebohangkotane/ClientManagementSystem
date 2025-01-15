using ClientManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClientManagementSystem.DAL.Repositories
{
    public class AddressRepository
    {
        private readonly string _connectionString;

        public AddressRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddAddress(Address address)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Address (ClientId, AddressType, AddressDetail)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ClientId", address.ClientId);
                cmd.Parameters.AddWithValue("@AddressType", address.AddressType);
                cmd.Parameters.AddWithValue("@AddressDetail", address.AddressDetail);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Address GetAddress(int addressId)
        {
            Address address = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * 
                                FROM Address 
                                WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", addressId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        address = new Address
                        {
                            AddressId = (int)reader["AddressId"],
                            ClientId = (int)reader["ClientId"],
                            AddressTypeId = (int)reader["AddressTypeId"],
                            AddressDetail = (string)reader["AddressDetail"],
                        };
                    }
                }
            }
            return address;
        }

        public List<Address> GetAddressesByClient(int clientId)
        {
            List<Address> addresses = new List<Address>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * 
                                FROM Address 
                                WHERE ClientId = @ClientId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ClientId", clientId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addresses.Add(new Address
                        {
                            AddressId = (int)reader["AddressId"],
                            ClientId = (int)reader["ClientId"],
                            AddressTypeId = (int)reader["AddressTypeId"],
                            AddressDetail = (string)reader["AddressDetail"],
                        });
                    }
                }
            }
            return addresses;
        }

        public void UpdateAddress(Address address)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Address SET ClientId = @ClientId, AddressType = @AddressType, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, City = @City, State = @State, ZipCode = @ZipCode
                                WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", address.Id);
                cmd.Parameters.AddWithValue("@ClientId", address.ClientId);
                cmd.Parameters.AddWithValue("@AddressType", address.AddressType);
                cmd.Parameters.AddWithValue("@AddressLine1", address.AddressLine1);
                cmd.Parameters.AddWithValue("@AddressLine2", address.AddressLine2);
                cmd.Parameters.AddWithValue("@City", address.City);
                cmd.Parameters.AddWithValue("@State", address.State);
                cmd.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAddress(int addressId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Address WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", addressId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
