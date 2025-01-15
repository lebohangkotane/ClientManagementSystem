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

        public int AddAddress(Address address)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"INSERT INTO Address (ClientId, AddressTypeId, AddressDetail)
                                    VALUES(@ClientId, @AddressTypeId, @AddressDetail);
                                    SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ClientId", address.ClientId);
                    cmd.Parameters.AddWithValue("@AddressTypeId", address.AddressTypeId);
                    cmd.Parameters.AddWithValue("@AddressDetail", address.AddressDetail);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    int newId = Convert.ToInt32(cmd.ExecuteScalar());

                    return newId;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Address GetAddress(int addressId)
        {
            try
            {
                Address address = null;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT * 
                                FROM Address 
                                WHERE AddressId = @AddressId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("Address@Id", addressId);
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
            catch (Exception)
            {

                throw;
            }
        }

        public List<Address> GetAllAddresses()
        {
            try
            {
                List<Address> addresses = new List<Address>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT * 
                                FROM Address";

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            addresses.Add(
                                new Address
                                {
                                    AddressId = (int)reader["AddressId"],
                                    ClientId = (int)reader["ClientId"],
                                    AddressTypeId = (int)reader["AddressTypeId"],
                                    AddressDetail = (string)reader["AddressDetail"],
                                }
                            );
                        }
                    }
                }

                return addresses;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Address> GetAllAddressesByClientId(int clientId)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public List<AddressType> GetAllAddressTypes()
        {
            try
            {

                List<AddressType> AddressTypeses = new List<AddressType>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT * 
                                FROM AddressType";

                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AddressTypeses.Add(
                                new AddressType
                                {
                                    AddressTypeId = (int)reader["AddressTypeId"],
                                    TypeName = (string)reader["TypeName"],
                                }
                            );
                        }
                    }
                }

                return AddressTypeses;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateAddress(Address address)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE Address 
                                SET ClientId = @ClientId, 
                                    AddressTypeId = @AddressTypeId, 
                                    AddressDetail = @AddressDetail, 
                                WHERE AddressId = @AddressId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@AddressId", address.AddressId);
                    cmd.Parameters.AddWithValue("@ClientId", address.ClientId);
                    cmd.Parameters.AddWithValue("@AddressTypeId", address.AddressTypeId);
                    cmd.Parameters.AddWithValue("@AddressDetail", address.AddressDetail);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteAddress(int addressId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Address WHERE AddressId = @AddressId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@AddressId", addressId);
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
