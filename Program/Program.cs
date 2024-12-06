using Infrustructure.Models;
using Infrustructure.Service;
using System;

    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();

            var newUser = new User
            {
                Name = "Fakhriddin Mardonov",
                Email = "Fakhriddin.Mardonov@list.ru",
                Password = "Mardonov19"
            };

            bool isInserted = userService.InsertUser(newUser);
            Console.WriteLine(isInserted ? "Пользователь успешно добавлен." : "Не удалось добавить пользователя.");

            var users = userService.GetUsers();
            Console.WriteLine("Пользователи в системе:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}: {user.Name} ({user.Email})");
            }

            var userById = userService.GetUserById(1);
            if (userById != null)
            {
                Console.WriteLine($"Найден пользователь: {userById.Name} ({userById.Email})");
            }
            else
            {
                Console.WriteLine("Пользователь не найден.");
            }

            if (userById != null)
            {
                userById.Name = "Fakhriddin Updated";
                userById.Email = "Fakhriddin.Updated@list.ru";
                bool isUpdated = userService.UpdateUser(userById);
                Console.WriteLine(isUpdated ? "Пользователь успешно обновлен." : "Не удалось обновить пользователя.");
            }

            bool isDeleted = userService.DeleteUser(1);
            Console.WriteLine(isDeleted ? "Пользователь успешно удален." : "Не удалось удалить пользователя.");
        }
    }
