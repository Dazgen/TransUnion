using System.Collections.Generic;
using System.Linq;

namespace TransUnion
{
    public class ATM14
    {
        private SortedDictionary<double, int> _cashRepository = new SortedDictionary<double, int>(new DescendingComparer<double>());
        public ATM14()
        {
            _cashRepository.Add(500, int.MaxValue);
            _cashRepository.Add(200, int.MaxValue);
            _cashRepository.Add(100, int.MaxValue);
            _cashRepository.Add(50, int.MaxValue);
            _cashRepository.Add(20, int.MaxValue);
            _cashRepository.Add(10, int.MaxValue);
            _cashRepository.Add(5, int.MaxValue);
            _cashRepository.Add(2, int.MaxValue);
            _cashRepository.Add(1, int.MaxValue);
            _cashRepository.Add(0.5, int.MaxValue);
            _cashRepository.Add(0.2, int.MaxValue);
            _cashRepository.Add(0.1, int.MaxValue);
            _cashRepository.Add(0.05, int.MaxValue);
            _cashRepository.Add(0.02, int.MaxValue);
            _cashRepository.Add(0.01, int.MaxValue);
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
