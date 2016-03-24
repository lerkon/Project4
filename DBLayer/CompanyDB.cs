using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DBLayer;

namespace DataLayer
{
    class CompanyDB
    {
        public CompanyLocal getCompany(int personId)
        {
            CompanyLocal c = null;
            using (var enities = new dmaj0914_2Sem_5Entities())
            {
                var company = enities.Companies.Where(a => a.personId == personId).FirstOrDefault();
                if (company != null)
                {
                    c = new CompanyLocal();
                    c.name = company.name;
                    c.link = company.link;
                    c.description = company.description;
                }
            }
            return c;
        }

        public bool setCompany(PersonLocal p)
        {
            using (var enities = new dmaj0914_2Sem_5Entities())
            {
                enities.Companies.Add(new Company()
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
