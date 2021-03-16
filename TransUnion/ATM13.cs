using System.Collections.Generic;
using System.Linq;

namespace TransUnion
{
    public class ATM13
    {
        private SortedDictionary<double, int> _cashRepository = new SortedDictionary<double, int>(new DescendingComparer<double>());
        public ATM13()
        {
            _cashRepository.Add(0.01, int.MaxValue);
            _cashRepository.Add(200, int.MaxValue);
        }

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
                    leftoverAmount -= bills * nominal;
                    exchangedMoney.Add(nominal, bills);
                    _cashRepository[nominal] -= bills;
                    if (leftoverAmount < 0.001)
                        break;
                }
            }

            if (leftoverAmount > 0)
            {
                var smallestBill = _cashRepository.Keys.Last();
                if (exchangedMoney.ContainsKey(smallestBill))
                {
                    exchangedMoney[smallestBill] += 1;
                }
                else
                {
                    exchangedMoney.Add(smallestBill, 1);
                }

                _cashRepository[smallestBill] -= 1;
            }


            return exchangedMoney;
        }
    }
}
