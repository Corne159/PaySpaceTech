using PaySpaceTech.API.Entities.TaxTypes;

namespace PaySpaceTech.API.Entities
{
    public class TaxCalculator
    {
        private TaxType _taxType;
        public TaxCalculator(TaxType taxType)
        {
            this._taxType = taxType;
        }

        public decimal CalculateIncomeTax()
        {
            return _taxType.IncomeTax();
        }
    }
}
