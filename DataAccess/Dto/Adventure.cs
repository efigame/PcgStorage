using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class Adventure
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Adventure Get(int id)
        {
            Adventure adventure = null;

            using (var data = new PcgStorageEntities())
            {
                var adventureData = data.adventures.SingleOrDefault(p => p.Id == id);
                if (adventureData != null) adventure = new Adventure(adventureData);
            }

            return adventure;
        }
        public static List<Adventure> All()
        {
            var adventures = new List<Adventure>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.adventures.ToList();
                adventures.AddRange(all.Select(a => new Adventure(a)));
            }

            return adventures;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = this.ToEntity();
                data.adventures.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var adventure = data.adventures.SingleOrDefault(s => s.Id == Id);
                if (adventure != null)
                {
                    adventure.Name = Name;

                    data.SaveChanges();
                }
            }
        }
        public void Delete() // TODO: Remember foreign relations
        {
            using (var data = new PcgStorageEntities())
            {
                var adventure = data.adventures.SingleOrDefault(s => s.Id == Id);
                if (adventure != null)
                {
                    data.adventures.Remove(adventure);
                    data.SaveChanges();
                }
            }
        }

        public Adventure()
        {
        }

        internal Adventure(adventure adventure)
        {
            Id = adventure.Id;
            Name = adventure.Name;
        }
        internal adventure ToEntity()
        {
            var adventure = new adventure
            {
                Name = this.Name
            };

            return adventure;
        }
    }
}
