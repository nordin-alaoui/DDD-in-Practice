using System;
using System.Linq;

using static DddInPractice.Logic2.Money;

namespace DddInPractice.Logic2
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyIn { get; private set; } = Money.None;
        public Money MoneyInTransaction { get; private set; } = Money.None;


        public void InsertMoney(Money money)
        {
            Money[] coinsAndBills =
                {Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };

            if(!coinsAndBills.Contains(money)) 
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = Money.None;
        }

        public void BuySnack()
        {
            MoneyInTransaction = Money.None;
            MoneyIn += MoneyInTransaction;
        }
    }
}
