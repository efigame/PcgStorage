using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class CardType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureId { get; set; }

        public static CardType Get(int id)
        {
            CardType cardtype = null;

            using (var data = new PcgStorageEntities())
            {
                var cardtypeData = data.cardtypes.SingleOrDefault(p => p.Id == id);
                if (cardtypeData != null) cardtype = new CardType(cardtypeData);
            }

            return cardtype;
        }
        public static List<CardType> All()
        {
            var cardtypes = new List<CardType>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.cardtypes.ToList();
                cardtypes.AddRange(all.Select(a => new CardType(a)));
            }

            return cardtypes;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = this.ToEntity();
                data.cardtypes.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var cardtype = data.cardtypes.SingleOrDefault(s => s.Id == Id);
                if (cardtype != null)
                {
                    cardtype.Name = Name;

                    data.SaveChanges();
                }
            }
        }
        public void Delete() // TODO: Remember foreign relations
        {
            using (var data = new PcgStorageEntities())
            {
                var cardtype = data.cardtypes.SingleOrDefault(s => s.Id == Id);
                if (cardtype != null)
                {
                    data.cardtypes.Remove(cardtype);
                    data.SaveChanges();
                }
            }
        }

        public CardType()
        {
        }

        internal CardType(cardtype cardtype)
        {
            Id = cardtype.Id;
            Name = cardtype.Name;
        }
        internal cardtype ToEntity()
        {
            var cardtype = new cardtype
            {
                Name = this.Name
            };

            return cardtype;
        }
    }
}
