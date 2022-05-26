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
        public PetModel(Pet pet)
        {
            Id = pet.Id;
            Name = pet.Name;
            Вreed = pet.Вreed;
            Photo = pet.Photo;
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
        public byte[] Photo { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Size { get; set; }
        public string Discription { get; set; }
        public string Gender { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
