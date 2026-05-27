namespace UmbrellaCore.Entities
{
    public class Experiment : UmbrellaEntity
    {
        public bool IsSuccessful { get; set; }

        public override string GetInfo()
        {
            return $"Experiment: {Name} Success={IsSuccessful}";
        }
    }
}