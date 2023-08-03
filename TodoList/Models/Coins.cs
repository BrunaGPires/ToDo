﻿using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Coins
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime DateEarned { get; set; }
    }
}
