using ProyectoMvcSergioDeSanClemente.Helpers;
using SegundoPost.Data;
using SegundoPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoPost.Repositories {
    public class UsersRepository {
        public UsersContext context;
        public UsersRepository(UsersContext context) {
            this.context = context;
        }
        public List<User> GetUsers() {
            List<User> users = this.context.Users.ToList();
            foreach (User user in users) {
                user.Email = HelperCryptography.DecryptString(user.Email, user.Salt);

            }
            return this.context.Users.ToList();    
        }
        public void RegisterUser(string name, string surname, string email, string department, string job, string password) {
            User user = new User();
            user.Name = name;
            user.Surname = surname;
            user.Departament = department;
            user.Job = job;
            user.Salt = HelperCryptography.GenerateSalt();
            //Nonreversible Encrpytation
            user.Password = HelperCryptography.EncriptarPassword(password, user.Salt);
            //Reversible encryptation
            user.Email = HelperCryptography.EncryptString(email,user.Salt);
            this.context.Users.Add(user);
            this.context.SaveChanges();

        }
    }
}
