using System;

namespace IocContainer
{
    public class Shopper
    {
        private readonly ICreditCard _creditCard;

        public Shopper(ICreditCard creditCard)
        {
            this._creditCard = creditCard;
        }

        public void Charge()
        {
            var chargeMessage = _creditCard.Charge();
            Console.WriteLine(chargeMessage);
        }
    }
}