namespace IocContainer
{
    public class MasterCard : ICreditCard
    {
        public string Charge()
        {
            return "Swiping hte MasterCard!";
        }
    }
}