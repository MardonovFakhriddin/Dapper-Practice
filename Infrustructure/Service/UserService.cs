using Dapper;
using Npgsql;
using Infrustructure.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using Infrustructure.Service;

public class UserService : IUserService
    {
        string connectionString = "Server=localhost;Port=5432;Database=users;User Id=postgres;Password=LMard1909;";

        public bool DeleteUser(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    var sql = "DELETE FROM users WHERE id = @Id";
                    var affected = connection.Execute(sql, new { Id = id });
                    return affected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    var sql = "UPDATE users SET name = @Name, email = @Email, password = @Password WHERE id = @Id";
                    var affected = connection.Execute(sql, user);
                    return affected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertUser(User user)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    var sql = "INSERT INTO users (name, email, password) VALUES (@Name, @Email, @Password)";
                    var affected = connection.Execute(sql, user);
                    return affected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    var sql = "SELECT * FROM users";
                    List<User> users = connection.Query<User>(sql).ToList();
                    return users;
                }
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    var sql = "SELECT * FROM users WHERE id = @Id";
                    var user = connection.QuerySingleOrDefault<User>(sql, new { Id = id });
                    return user;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
