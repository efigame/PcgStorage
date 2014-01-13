﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class PcgUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public PcgUser()
        {
        }

        public static PcgUser Get(string email, string password)
        {
            PcgUser pcgUser = null;

            using (var data = new PcgStorageEntities())
            {
                var user = data.pcgusers.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user != null)
                    pcgUser = new PcgUser(user);
            }

            return pcgUser;
        }

        public static List<PcgUser> All()
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        internal PcgUser(DataAccess.pcguser pcgUser)
        {
            Id = pcgUser.Id;
            Email = pcgUser.Email;
            Password = pcgUser.Password;
        }

        internal pcguser ToEntity()
        {
            var pcgUser = new DataAccess.pcguser
            {
                Email = this.Email,
                Password = this.Password
            };

            return pcgUser;
        }
    }
}
