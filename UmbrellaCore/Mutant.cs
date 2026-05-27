namespace UmbrellaCore.Entities
{
    public class Mutant : UmbrellaEntity
    {
        public double Aggression { get; set; }

        public override string GetInfo()
        {
            return $"Mutant: {Name} Aggression={Aggression}";
        }
    }
}