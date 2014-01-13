using PcgManager.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager
{
    public class PcgManager : IPcgManager
    {
        public IEnumerable<Dto.Card> GetCards()
        {
            // TODO: Should be changed to be something else like ... view method, or perhaps part of another object

            var cardDtos = new List<Dto.Card>();

            var cardDto = new Dto.Card
            {
                Id = 1,
                Traits = new List<Dto.Trait>()
            };

            var traitDto = new Dto.Trait();

            using (var data = new DataAccess.Data())
            {
                var traits = data.GetTraits().ToList();

                var random = new Random();
                var index = random.Next(0, traits.Count());

                traitDto = new Dto.Trait(traits[index]);
            }

            cardDto.Traits.Add(traitDto);

            cardDtos.Add(cardDto);

            return cardDtos;
        }

        public IEnumerable<Dto.Card> GetCards(Dto.CardType cardType)
        {
            // TODO: Should be changed to be something else like ... view method, or perhaps part of another object

            var cardDtos = new List<Dto.Card>();

            using (var data = new DataAccess.Data())
            {
                switch (cardType)
                {
                    case Dto.CardType.Character:
                        var characterCards = DataAccess.Dto.CharacterCard.All();
                        cardDtos.AddRange(characterCards.Select(c => new Dto.Card(c)));
                        break;
                    case Dto.CardType.Monster:
                        break;
                }
            }

            return cardDtos;
        }

        public List<Dto.Party> GetParties(int userId)
        {
            // TODO: Consider if this should be part of the returned user object or view method

            var parties = new List<Dto.Party>();

            using (var data = new DataAccess.Data())
            {
                var partyList = data.GetParties(userId);
                parties.AddRange(partyList.Select(p => new Dto.Party(p, false)));
            }

            return parties;
        }

        public Dto.Party GetParty(int partyId)
        {
            var partyDto = new Dto.Party();

            using(var data = new DataAccess.Data())
            {
                var party = DataAccess.Dto.Party.Get(partyId);
                partyDto = new Dto.Party(party);
            }

            return partyDto;
        }

        public SuccessMessage CreateUser(string email, string password)
        {
            var successMessage = new SuccessMessage
            {
                Success = false
            };

            using (var data = new DataAccess.Data())
            {
                var pcgUser = new DataAccess.Dto.PcgUser
                {
                    Email = email,
                    Password = password
                };

                if (!data.CheckUserByEmail(pcgUser.Email))
                {
                    pcgUser.Persist();

                    if (pcgUser.Id > 0) successMessage.Success = true;
                }
                else
                {
                    successMessage.Success = false;
                    successMessage.FailedType = FailedType.UserAlreadyExists;
                }
            }

            return successMessage;
        }

        public User LoginUser(string email, string password)
        {
            User user = null;

            var pcgUser = DataAccess.Dto.PcgUser.Get(email, password);
            if (pcgUser != null) user = new User(pcgUser);

            return user;
        }
    }
}
