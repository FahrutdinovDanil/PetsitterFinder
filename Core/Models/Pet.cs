using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.DB
{
    public partial class Pet
    {
        public Pet(PetModel pet)
        {
            Id = pet.Id;
            Name = pet.Name;
            Вreed = pet.Вreed;
            Year = pet.Year;
            Month = pet.Month;
            Size = pet.Size;
            Discription = pet.Discription;
            Gender = pet.Gender;
            IsDeleted = pet.IsDeleted;
        }
    }
}
