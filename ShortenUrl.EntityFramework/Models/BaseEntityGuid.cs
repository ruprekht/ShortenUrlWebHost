using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortenUrl.EntityFramework.Models
{
    public abstract class BaseEntityGuid
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
