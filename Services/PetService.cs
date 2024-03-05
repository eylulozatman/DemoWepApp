using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DemoWepApp.Models;

namespace DemoWepApp.Services
{
    public class PetService
    {
   
        public PetService(){}

        public int GetPetEnergyById(int id, List<Pet> petsList)
        {
            var pet = petsList.Find(p => p.Id == id);
            return pet != null ? pet.Energy : -1; // Pet bulunamazsa -1 dön
        }

        public IActionResult CreateNewPet(Pet pet, List<Pet> petsList)
        { 
            if (CheckIdOk(pet.Id,petsList))
            {
                petsList.Add(pet);
                 return new OkResult(); 
            }
            else
            {
                 return new BadRequestObjectResult("Bu ID ile zaten bir evcil hayvan var."); // BadRequest() yerine new BadRequestObjectResult() kullanılmalı
            }
           
        }

        private bool CheckIdOk(int id, List<Pet> petsList)
        {
            return !petsList.Any(p => p.Id == id);
        }

        internal object GetPetById(int id, List<Pet> petsList)
        {
            var pet = petsList.Find(p => p.Id == id);
            if(pet != null)
            {
                 return pet;
            }
            return null;
        }

        internal void DeletePet(object petToDelete, List<Pet> petsList)
        {
            petsList.Remove((Pet)petToDelete);
            throw new NotImplementedException();
        }
    }
}
