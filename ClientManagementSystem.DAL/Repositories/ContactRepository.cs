using ClientManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClientManagementSystem.DAL.Repositories
{
    public class ContactRepository
    {
        private readonly string _connectionString;

        public ContactRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddContact(ContactInfo contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"INSERT INTO ContactInfo (ClientId, ContactTypeId, ContactDetail)
                                     VALUES(@ClientId, @ContactTypeId, @ContactDetail);
                                     SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ClientId", contact.ClientId);
                    cmd.Parameters.AddWithValue("@ContactTypeId", contact.ContactTypeId);
                    cmd.Parameters.AddWithValue("@ContactDetail", contact.ContactDetail);

                    con.Open();
                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    return newId;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the contact. Please try again later.");
            }
        }

        public ContactInfo GetContact(int contactInfoId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT *
                                     FROM ContactInfo
                                     WHERE ContactInfoId = @ContactInfoId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ContactInfoId", contactInfoId);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ContactInfo
                            {
                                ContactInfoId = (int)reader["ContactInfoId"],
                                ClientId = (int)reader["ClientId"],
                                ContactTypeId = (int)reader["ContactTypeId"],
                                ContactDetail = (string)reader["ContactDetail"]
                            };
                        }
                        else
                        {
                            throw new Exception("No record found with the specified ContactInfoId.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the contact. Please try again later.");
            }
        }

        public List<ContactInfo> GetAllContacts()
        {
            try
            {
                var contacts = new List<ContactInfo>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT *
                                     FROM ContactInfo";

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contacts.Add(new ContactInfo
                            {
                                ContactInfoId = (int)reader["ContactInfoId"],
                                ClientId = (int)reader["ClientId"],
                                ContactTypeId = (int)reader["ContactTypeId"],
                                ContactDetail = (string)reader["ContactDetail"]
                            });
                        }
                    }
                }

                return contacts;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving all contacts. Please try again later.");
            }
        }

        public void UpdateContact(ContactInfo contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE ContactInfo 
                                     SET ClientId = @ClientId, 
                                         ContactTypeId = @ContactTypeId, 
                                         ContactDetail = @ContactDetail 
                                     WHERE ContactInfoId = @ContactInfoId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ContactInfoId", contact.ContactInfoId);
                    cmd.Parameters.AddWithValue("@ClientId", contact.ClientId);
                    cmd.Parameters.AddWithValue("@ContactTypeId", contact.ContactTypeId);
                    cmd.Parameters.AddWithValue("@ContactDetail", contact.ContactDetail);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the contact. Please try again later.");
            }
        }

        public void DeleteContact(int contactInfoId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM ContactInfo WHERE ContactInfoId = @ContactInfoId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ContactInfoId", contactInfoId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting the contact. Please try again later.");
            }
        }

        public List<ContactType> GetAllContactTypes()
        {
            try
            {
                var contactTypes = new List<ContactType>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT *
                                    FROM ContactType";

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contactTypes.Add(
                                new ContactType
                                {
                                    ContactTypeId = (int)reader["ContactTypeId"],
                                    TypeName = (string)reader["TypeName"]
                                });
                        }
                    }
                }
                return contactTypes;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving all contact types. Please try again later.", ex);
            }
        }
    }
}
