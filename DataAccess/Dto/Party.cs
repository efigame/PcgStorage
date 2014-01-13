using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class Party
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PcgUserId { get; set; }

        public static Party Get(int id)
        {
            Party party = null;

            using (var data = new PcgStorageEntities())
            {
                var partyData = data.parties.SingleOrDefault(p => p.Id == id);
                if (partyData != null) party = new Party(partyData);
            }

            return party;
        }
        public static List<Party> All(int userId)
        {
            var parties = new List<Party>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.parties.Where(p => p.PcgUserId == userId);
                parties.AddRange(all.Select(a => new Party(a)));
            }

            return parties;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = this.ToEntity();
                data.parties.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var party = data.parties.SingleOrDefault(p => p.Id == Id);
                if (party != null)
                {
                    party.Name = Name;
                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var party = data.parties.SingleOrDefault(u => u.Id == Id);
                if (party != null)
                {
                    data.parties.Remove(party);
                    data.SaveChanges();
                }
            }
        }

        public Party()
        {
        }

        internal Party(party party)
        {
            Id = party.Id;
            Name = party.Name;
            PcgUserId = party.PcgUserId;
        }
        internal party ToEntity()
        {
            var party = new party
            {
                Name = this.Name,
                PcgUserId = this.PcgUserId
            };

            return party;
        }
    }
}
