using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;
using System.Data.Entity;

namespace SocailApp.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private SocialAppEntities _db;
        public void Create(Organization Entity)
        {
            try
            {
                _db = new SocialAppEntities();
                _db.Organizations.Add(Entity);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(int? id)
        {
            {
                var organization = GetById(id);
                _db.Organizations.Remove(organization);
                _db.SaveChanges();
            }

        }

        public Organization GetById(int? id)
        {
            try
            {
                _db = new SocialAppEntities();
                var organization = _db.Organizations.Where(o => o.OrganizationID == id).FirstOrDefault();
                return organization;
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        public IEnumerable<Organization> Retrive()
        {
            try
            {
                _db = new SocialAppEntities();
                var organizations = _db.Organizations.ToList();
                return organizations;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public void Update(Organization Entity)
        {
            try
            {
                _db = new SocialAppEntities();
                _db.Entry(Entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        
        }
    }
}