
using System;
using System.ComponentModel.DataAnnotations;

namespace PanXPan.Api.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int NumberOfPages { get; set; }

        public DateTime DateOfPublication { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool IsDeleted { get; set; }

        public string Authors { get; set; }
    }
}