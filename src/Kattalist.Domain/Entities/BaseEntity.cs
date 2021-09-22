using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kattalist.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public BaseEntity()
        {
            DataCriacao = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
