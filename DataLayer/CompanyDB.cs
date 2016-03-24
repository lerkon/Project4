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

        public bool setCompany(Person p)
        {
            using (var enities = new Entities())
            {
                enities.Companyies.Add(new Companyy()
                {
                    name = p.company.name,
                    link = p.company.link,
                    description = p.company.description,
                    personId = p.id
                });
                int ok = enities.SaveChanges();
                if (ok == 1)
                    return true;
                else
                    return false;
            }
        }
    }
}
