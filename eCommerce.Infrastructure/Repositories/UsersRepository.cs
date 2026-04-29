using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;
        public UsersRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            //return Task.FromResult<ApplicationUser?>(user);

            //Before dapper just returning the user
            //Generate a new unique user ID for the user
            //user.UserID = Guid.NewGuid();

            //return user;

            //After dapper
            user.UserID = Guid.NewGuid();

            // SQL Query to insert user data into the "Users" table.
            string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
            int rowCountAffected= await _dbContext.DbConnection.ExecuteAsync(query,user);
            if (rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }

            }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            //Before dapper just returning the user
            //return new ApplicationUser()
            //{
            //    UserID = Guid.NewGuid(),
            //    Email = email,
            //    Password = password,
            //    PersonName = "Person name",
            //    Gender = GenderOptions.Male.ToString()
            //};

            //After Dapper
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
            var parameters = new { Email = email, Password = password };
            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
            return user;
        }

    }
}

//using var connection = _dbContext.CreateConnection();