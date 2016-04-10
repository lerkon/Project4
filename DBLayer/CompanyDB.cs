using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DBLayer
{
    class CompanyDB
    {
        public CompanyLocal getCompany(int personId)
        {
            CompanyLocal c = null;
            using (var enities = new dmaj0914_2Sem_5Entities1())
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
            using (var enities = new dmaj0914_2Sem_5Entities1())
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

        public bool updateCompany(PersonLocal p)
        {
            using (var enities = new dmaj0914_2Sem_5Entities1())
            {
                var c = enities.Companies.Where(a => a.personId == p.id).FirstOrDefault();
                c.name = p.company.name;
                c.link = p.company.link;
                c.description = p.company.description;
                c.personId = p.id;
                int ok = enities.SaveChanges();
                if (ok != 0)
                    return true;
                else
                    return false;
            }
        }

        public bool deleteCompany(PersonLocal person)
        {
            using (var enities = new dmaj0914_2Sem_5Entities1())
            {
                var c = enities.Companies.Where(a => a.personId == person.id).FirstOrDefault();
                enities.Companies.Remove(c);
                if (enities.SaveChanges() != 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
