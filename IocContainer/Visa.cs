namespace IocContainer
{
    public class Visa : ICreditCard
    {
        public string Charge()
        {
            return "charging with the visa";
        }
    }
}