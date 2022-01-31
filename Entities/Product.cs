using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }
}
