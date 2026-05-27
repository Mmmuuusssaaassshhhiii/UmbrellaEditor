namespace UmbrellaCore.Entities
{
    public class SecurityUnit : UmbrellaEntity
    {
        public string Weapon { get; set; }

        public override string GetInfo()
        {
            return $"Security: {Name} Weapon={Weapon}";
        }
    }
}