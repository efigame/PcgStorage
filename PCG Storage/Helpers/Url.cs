using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pcg_Storage.Helpers
{
    public class Url
    {
        public static string Party(int userId, int partyId)
        {
            return String.Format("~/{0}/party/{1}", userId, partyId);
        }

        public static string PartyEdit(int userId, int partyId)
        {
            return String.Format("~/{0}/party/{1}/edit", userId, partyId);
        }

        public static string PartyIndex(int userId)
        {
            return String.Format("~/{0}/party/index", userId);
        }

        public static string PartyNew(int userId)
        {
            return String.Format("~/{0}/party/new", userId);
        }

        public static string PartyCharacter(int userId, int partyId, int characterId)
        {
            return String.Format("~/{0}/party/{1}/character/{2}", userId, partyId, characterId);
        }

        public static string PartyCharacterEdit(int userId, int partyId, int characterId)
        {
            return String.Format("~/{0}/party/{1}/character/{2}/edit", userId, partyId, characterId);
        }

        public static string UserCreate()
        {
            return String.Format("~/user/create");
        }

        public static string UserForgottenPassword()
        {
            return String.Format("~/user/forgotten");
        }
    }
}