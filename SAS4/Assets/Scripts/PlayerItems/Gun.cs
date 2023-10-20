namespace PlayerItems
{
    public abstract class Gun
    {
        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        
        public float Spread { get; protected set; }
    }
    
    public class Pistol : Gun
    {
        public Pistol()
        {
            Name = "Pistol";
            Damage = 3;
            Spread = 5;
        }
    }
}