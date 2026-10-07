using BlazingPizzaApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazingPizzaApp.Data
{
    public interface IPizzaSpecials
    {
        Task<IEnumerable<PizzaSpecial>> GetPizzaSpecialsAsync();
    }
}
