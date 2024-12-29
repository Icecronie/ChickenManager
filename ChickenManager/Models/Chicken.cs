namespace ChickenManager.Models
{
    public class Chicken
    {
        public Chicken()
        {
            Breed = new Breed();
            Gender = new Gender();
            Color = new Color();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Breed Breed { get; set; }
        public string BreedName { get; set; }
        public Gender Gender { get; set; }
        public string GenderName { get; set; }
        public Color Color { get; set; }
        public string ColorName { get; set; }
        public int Age { get; set; }
        public bool LaysEggs { get; set; }
        public User User { get; set; }
    }
}
