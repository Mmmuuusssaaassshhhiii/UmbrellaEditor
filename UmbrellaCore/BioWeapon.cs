namespace UmbrellaCore.Entities
{
    public class BioWeapon : UmbrellaEntity
    {
        public int KillRadius { get; set; }

        public override string GetInfo()
        {
            return $"BioWeapon: {Name} Radius={KillRadius}";
        }
    }
}