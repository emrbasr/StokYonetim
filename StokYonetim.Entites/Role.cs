﻿using StokYonetim.Entites.Abstract;

namespace StokYonetim.Entites
{
    public class Role : BaseEntity
    {

        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
