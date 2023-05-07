using PaySpaceTech.API.Rules;

namespace PaySpaceTech.API.Entities
{
    public class TaxCalculator
    {
        private ITaxType _taxType;
        public TaxCalculator(ITaxType taxType)
        {
            this._taxType = taxType;
        }

        public decimal CalculateIncomeTax(decimal monthlyIncome)
        {
            return _taxType.IncomeTax(monthlyIncome);
        }
    }
}
