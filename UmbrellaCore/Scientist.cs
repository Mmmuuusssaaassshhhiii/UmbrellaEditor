namespace UmbrellaCore.Entities
{
    public class Scientist : UmbrellaEntity
    {
        public string Rank { get; set; }

        public override string GetInfo()
        {
            return $"Scientist: {Name} Rank={Rank}";
        }
    }
}