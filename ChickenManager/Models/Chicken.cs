﻿namespace ChickenManager.Models
{
    public class Chicken
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Breed Breed { get; set; }
        public Gender Gender { get; set; }
        public Color Color { get; set; }
        public int Age { get; set; }
        public bool LaysEggs { get; set; }
        public User User { get; set; }
    }
}
