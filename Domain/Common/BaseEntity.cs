using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
