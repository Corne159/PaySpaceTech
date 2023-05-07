namespace PaySpaceTech.API.Entities.TaxTypes
{
    public abstract class TaxType
    {
        private decimal _monthlyIncome;

        public decimal GetMonthlyIncome()
        {
            return _monthlyIncome;
        }
        public void SetMonthlyIncome(decimal monthlyIncome)
        {
            _monthlyIncome = monthlyIncome;
        }

        public abstract decimal IncomeTax();
    }
}
