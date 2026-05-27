namespace UmbrellaCore.Entities
{
    public class VirusSample : UmbrellaEntity
    {
        public int DangerLevel { get; set; }

        public override string GetInfo()
        {
            return $"Virus: {Name} Danger={DangerLevel}";
        }
    }
}