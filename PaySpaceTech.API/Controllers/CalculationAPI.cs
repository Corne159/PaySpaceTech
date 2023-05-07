using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaySpaceTech.API.Entities;
using PaySpaceTech.API.Entities.Dto;
using PaySpaceTech.API.Rules;
using PaySpaceTech.DataLayer.Models;

namespace PaySpaceTech.API.Controllers
{
    [ApiController]
    [Route("api/calculations/[action]")]
    public class CalculationAPI : ControllerBase
    {
        private readonly PaySpaceDBContext _context;
        private TaxRuleFactory _taxFactory;

        public CalculationAPI(PaySpaceDBContext context)
        {
            _context = context;
            _taxFactory = new TaxRuleFactory();
        }

        [HttpPost(Name = "SaveCalculation")]
        public async Task<decimal> SaveCalculation([FromBody] CalculationDto calculation)
        {
            #region Checks and Validations

            //Check that the DTO is not null
            if (calculation == null)
            {
                throw new ArgumentException("Invalid data received");
            }

            //Check that the monthlyincome is valid
            if (string.IsNullOrEmpty(calculation.MonthlyIncome))
            {
                throw new ArgumentException("Invalid MonthlyIncome received");
            }

            //Check that the monthlyincome is in correct format
            if (!decimal.TryParse(calculation.MonthlyIncome, out decimal dMonthlyIncome))
            {
                throw new ArgumentException("Invalid MonthlyIncome type");
            }

            //Check that the dMonthlyIncome is in a valid range
            if (dMonthlyIncome <= 0)
            {
                throw new ArgumentException("Invalid dMonthlyIncome range");
            }

            //Check that the postal code is valid
            if (string.IsNullOrEmpty(calculation.PostalCode))
            {
                throw new ArgumentException("Invalid Postal Code received");
            }

            //Check that the postal code exists in the database.
            var postalCode = await _context.Postalcodes.FirstOrDefaultAsync(x => x.Code.ToLower() == calculation.PostalCode.ToLower());
            if (postalCode == null)
            {
                throw new ArgumentException("Postal Code does not exist");
            }

            #endregion

            #region Do Calculation

            var taxType = _taxFactory.GetTaxTypeChecker(postalCode.CalculationType);

            TaxCalculator _taxCalculator = new(taxType);
            var calcualtedValue = _taxCalculator.CalculateIncomeTax(dMonthlyIncome);

            #endregion

            #region Save to database

            _context.Calculations.Add(new Calculation
            {
                CreatedDate = DateTime.Now,
                PostalCode = postalCode,
                MonthlyIncome = dMonthlyIncome,
                CalculatedValue = calcualtedValue
            });
            await _context.SaveChangesAsync();

            #endregion

            return calcualtedValue;
        }
    }
}