using PaySpaceTech.DataLayer.Models;

namespace PaySpaceTech.API.Entities.TaxTypes
{
    public class ProgressiveTax : TaxType
    {
        public override decimal IncomeTax()
        {
            //Holder list for tax brackets
            List<Bracket> brackets;

            //Connection to the database
            using (var db = new PaySpaceDBContext())
            {
                //Get the tax brackets from the database for calculations
                brackets = db.Brackets.OrderBy(x => x.PercentageRate).ToList();
            }

            //Check to make sure there are tax brackets loaded
            if (brackets == null)
            {
                throw new ArgumentException("No tax brackets found to use for calculations");
            }

            //Get the monthly income for calculations
            decimal monthlyIncome = GetMonthlyIncome();
            decimal annualIncome = monthlyIncome * 12;

            //Holder variable for the tax 
            decimal tax = 0;

            foreach (var bracket in brackets)
            {
                //Check if the monthly income is more than the to(max) value of the current bracket
                //If true calculate tax with the rate on the full value (To - From) for each bracket 
                //until false and then just work out the partial value (annualIncome - From) for that bracket and break out of loop
                if (annualIncome >= bracket.To)
                {
                    tax += (decimal)(bracket.To - bracket.From) / 100 * bracket.PercentageRate;
                }
                else
                {
                    tax += (annualIncome - bracket.From) / 100 * bracket.PercentageRate;
                    break;
                }
            }

            return tax;
        }
    }
}
