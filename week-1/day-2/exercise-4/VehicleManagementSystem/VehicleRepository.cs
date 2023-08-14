using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    public class VehicleRepository : IRepository<Entity>
    {
        List<Entity> myentities = new List<Entity>();
        int id = 1;

        public Entity GetById(int id)
        {
            return myentities.Find(entity => entity.Id == id)!;
        }

        public IEnumerable<Entity> GetAll()
        {
            return myentities;
        }

        public void Add(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = id;
            myentities.Add(entity);
            id++;
        }

        public void Update(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            int index = myentities.FindIndex(e => e.Id == entity.Id);
            if (index >= 0)
            {
                myentities[index] = entity;
            }
        }

        public void Delete(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            myentities.RemoveAll(e => e.Id == entity.Id);
        }

    }
}

