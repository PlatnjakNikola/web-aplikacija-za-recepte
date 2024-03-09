﻿namespace Server.Models
{
    public class RecipeCreateUpdateDTO
    {
        public string? Title { get; set; }

        public List<string>? Ingredients { get; set; }

        public string? Description { get; set; }

        public int? TimeToPrepare { get; set; }

        public string? Type { get; set; }

        public string? Image { get; set; }

        public bool Enabled { get; set; }
    }
}