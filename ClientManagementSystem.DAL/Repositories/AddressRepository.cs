using ClientManagementSystem.DAL.Models;
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
                string query = @"INSERT INTO Address (AddressType, AddressDetail)
                                VALUES(@AddressType, @AddressDetail)";

                SqlCommand cmd = new SqlCommand(query, con);
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

        public List<Address> GetAllAddresses()
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

        public List<Address> GetAllAddressesByClientId(int clientId)
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

        public List<AddressType> GetAllAddressTypes()
        {
            List<AddressType> AddressTypeses = new List<AddressType>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * 
                                FROM AddressTypes";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
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

        public void UpdateAddress(Address address)
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

        public void DeleteAddress(int addressId)
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
    }
}
