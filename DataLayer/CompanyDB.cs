using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataLayer
{
    class CompanyDB
    {
        public Company getCompany(int personId)
        {
            Company c = null;
            using (var enities = new Entities())
            {
                var company = enities.Companyies.Where(a => a.personId == personId).FirstOrDefault();
                if (company != null)
                {
                    c = new Company();
                    c.name = company.name;
                    c.link = company.link;
                    c.description = company.description;
                }
            }
            return c;
        }
    }
}
