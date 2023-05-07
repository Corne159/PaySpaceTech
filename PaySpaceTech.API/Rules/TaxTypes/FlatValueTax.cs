namespace PaySpaceTech.API.Rules.TaxTypes
{
    public class FlatValueTax : ITaxType
    {
        public string TaxTypeCode { get; set; } = "Flat Value";

        public decimal IncomeTax(decimal monthlyIncome)
        {
            //Set the default tax to 10k
            decimal tax = 10000;

            //Get the monthly income for calculations
            decimal annualIncome = monthlyIncome * 12;

            //Check whether the monthly income is less than 200k 
            if (annualIncome < 200000)
            {
                //Calculate 5% of the monthly income
                tax = annualIncome / 100 * 5;
            }

            return tax;
        }
    }
}
