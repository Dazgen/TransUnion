using System;
using System.Collections.Generic;

namespace TransUnion
{
    public class ATM12
    {
        private SortedDictionary<double, int> _cashRepository = new SortedDictionary<double, int>();
        public ATM12()
        {
            _cashRepository.Add(200, int.MaxValue);
        }

        public Dictionary<double, int> Exchange(double amount)
        {
            var exchangedMoney = new Dictionary<double, int>();
            var twoHundredBills = (int)Math.Ceiling(amount/200);
            exchangedMoney.Add(200, twoHundredBills);
            _cashRepository[200] -= twoHundredBills;
            return exchangedMoney;
        }
    }
}
