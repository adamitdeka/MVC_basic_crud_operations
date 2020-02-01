using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Install  entity framework 6 on Tools > Manage Nuget Packages > Microsoft Entity Framework (ver 6.4)
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetGrooming.Models.ViewModels
{
    public class UpdatePet
    {
        //Information needed to update pet work
        //Info about one pet
        //Info about many species

        public Pet pet { get; set; }
        public List<Species> species { get; set; }

    }
}