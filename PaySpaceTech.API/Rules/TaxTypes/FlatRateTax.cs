namespace PaySpaceTech.API.Rules.TaxTypes
{
    public class FlatRateTax : ITaxType
    {
        public string TaxTypeCode { get; set; } = "Flat Rate";

        public decimal IncomeTax(decimal monthlyIncome)
        {
            //Calculate the 17.5% tax of annual income
            return monthlyIncome * 12 / 100 * (decimal)17.5;
        }
    }
}
