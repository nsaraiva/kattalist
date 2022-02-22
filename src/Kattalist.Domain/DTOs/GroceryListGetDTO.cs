using Kattalist.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kattalist.Domain.DTOs
{
    public class GroceryListGetDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public int AmountOfGoods { get; set; }

        public GroceryListGetDTO()
        {
            this.AmountOfGoods = 0;
        }
    }
}
