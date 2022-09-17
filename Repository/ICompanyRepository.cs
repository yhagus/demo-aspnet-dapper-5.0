using demo_aspnet_dapper_5._0.Models;
using System.Collections.Generic;

namespace demo_aspnet_dapper_5._0.Repository
{
    public interface ICompanyRepository
    {
        Company Find(int id);
        List<Company> GetAll();

        Company Add(Company company);
        Company Update(Company company);
        void Remove(int id);
    }
}
