using Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PetModel
    {
        public PetModel()
        {

            Id = 0;
            Name = "";
            Вreed = "";
            Year = 0;
            Month = 0;
            Size = 0;
            Discription = "";
            Gender = "";
            IsDeleted = null;

        }

        public PetModel(Pet pet)
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Вreed { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Size { get; set; }
        public string Discription { get; set; }
        public string Gender { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        //public Pet GetPet(PetModel petModel)
        //{
        //    return new Pet
        //    {
        //        Id = petModel.Id,
        //        Name = petModel.Name,
        //        Discription = petModel.Discription,
        //        Gender = petModel.Gender,
        //        IsDeleted = petModel.IsDeleted,
        //        Year = petModel.Year,
        //        Month = petModel.Month,
        //        Size = petModel.Size,
        //        Вreed = petModel.Вreed
        //    };
        //}
    }
}
