using System;

namespace WebAppForms.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}