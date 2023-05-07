namespace PaySpaceTech.API.Rules
{
    public interface ITaxType
    {
        string TaxTypeCode { get; set; }
        public decimal IncomeTax(decimal monthlyIncome);
    }
}
