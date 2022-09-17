using Dapper;
using demo_aspnet_dapper_5._0.Data;
using demo_aspnet_dapper_5._0.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace demo_aspnet_dapper_5._0.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private IDbConnection db;

        public CompanyRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Company Add(Company company)
        {
            var query = "INSERT INTO Companies VALUES (@Name, @Address, @City, @State, @PostalCode)"
                + "SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = db.Query<int>(query, new
            {
                company.Name,
                company.Address,
                company.City,
                company.State,
                company.PostalCode
            }).Single();
            company.CompanyId = id;

            return company;
        }
        public Company Find(int id)
        {
            var query = "SELECT * FROM Companies WHERE CompanyId = @CompanyId";

            return db.Query<Company>(query, new { @CompanyId = id }).Single();
        }
        public List<Company> GetAll()
        {
            var query = "SELECT * FROM Companies";

            return db.Query<Company>(query).ToList();
        }
        public void Remove(int id)
        {
            var query = "DELETE FROM Companies WHERE CompanyId=@Id";

            db.Execute(query, new { id });
        }
        public Company Update(Company company)
        {
            var query = "UPDATE Companies SET Name=@Name, Address=@Address, City=@City, State=@State, PostalCode=@PostalCode WHERE CompanyId=@CompanyId";
            db.Execute(query, company);

            return company;
        }
    }
}
