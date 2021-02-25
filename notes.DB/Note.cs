using System;
using System.ComponentModel.DataAnnotations;

namespace notes.DB
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
