namespace PaySpaceTech.API.Entities.TaxTypes
{
    public class FlatRateTax : TaxType
    {
        public override decimal IncomeTax()
        {
            //Get the monthly income for calculations
            decimal monthlyIncome = GetMonthlyIncome();

            //Calculate the 17.5% tax of annual income
            return monthlyIncome * 12 / 100 * (decimal)17.5;
        }
    }
}
