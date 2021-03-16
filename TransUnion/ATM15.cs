using System;
using System.Collections.Generic;

namespace TransUnion
{
    public class ATM15
    {
        private SortedDictionary<double, int> _cashRepository = new SortedDictionary<double, int>(new DescendingComparer<double>());
        public ATM15()
        {
            var random = new Random();
            _cashRepository.Add(500, random.Next(1, 10));
            _cashRepository.Add(200, random.Next(1, 10));
            _cashRepository.Add(100, random.Next(1, 10));
            _cashRepository.Add(50, random.Next(1, 10));
            _cashRepository.Add(20, random.Next(1, 10));
            _cashRepository.Add(10, random.Next(1, 10));
            _cashRepository.Add(5, random.Next(1, 10));
            _cashRepository.Add(2, random.Next(1, 10));
            _cashRepository.Add(1, random.Next(1, 10));
            _cashRepository.Add(0.5, random.Next(1, 10));
            _cashRepository.Add(0.2, random.Next(1, 10));
            _cashRepository.Add(0.1, random.Next(1, 10));
            _cashRepository.Add(0.05, random.Next(1, 10));
            _cashRepository.Add(0.02, random.Next(1, 10));
            _cashRepository.Add(0.01, random.Next(1, 10));
        }

        //TODO Since this is greedy algorithm for ATM, it will fail to exchange on some cases when some of the nominals amount is less than 1
        //TODO  For such cases need to implement one of other Knapsack problem algorithms
        public Dictionary<double, int> Exchange(double amount)
        {
            var leftoverAmount = amount;
            var exchangedMoney = new Dictionary<double, int>();
            var availableBills = new List<double>(_cashRepository.Keys);

            foreach (var nominal in availableBills)
            {
                var bills = (int)(leftoverAmount / nominal);
                if (bills > 0)
                {
                    var availableBillsAmount = Math.Min(bills, _cashRepository[nominal]);
                    leftoverAmount -= availableBillsAmount * nominal;
                    exchangedMoney.Add(nominal, availableBillsAmount);
                    _cashRepository[nominal] -= availableBillsAmount;
                    if (leftoverAmount < 0.001)
                        break;
                }
            }

            return leftoverAmount > 0 ? null : exchangedMoney;
        }
    }
}
