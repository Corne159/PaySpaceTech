using PaySpaceTech.API.Entities;
using PaySpaceTech.API.Rules;

namespace PaySpaceTech.nUnitTests
{
    public class CalculatorTests
    {
        private TaxCalculator TaxCalculator { get; set; } = null!;

        /// Progressive Tax ///
        [TestCase(500,600, "Progressive")] //10% bracket
        [TestCase(1000, 1382.35, "Progressive")] //15% bracket
        [TestCase(5000, 11187.1, "Progressive")] //25% bracket
        [TestCase(10000, 27319.32, "Progressive")] //28% bracket
        [TestCase(20000, 64341.49, "Progressive")] //33% bracket
        [TestCase(50000, 187682.14, "Progressive")] //35% bracket

        /// Flat Rate Tax ///
        [TestCase(500, 1050, "Flat Rate")]
        [TestCase(10000, 21000, "Flat Rate")]

        /// Flat Value Tax ///
        [TestCase(10000, 6000, "Flat Value")]
        [TestCase(17000, 10000, "Flat Value")]

        public void CalculateTax_ShouldReturnCorrectTax(decimal monthlyIncome, decimal expectedTax, string calculationType)
        {
            // Assign
            TaxRuleFactory _taxFactory = new TaxRuleFactory();
            var taxType = _taxFactory.GetTaxTypeChecker(calculationType);
            TaxCalculator = new TaxCalculator(taxType);

            // Act
            decimal actualTax = TaxCalculator.CalculateIncomeTax(monthlyIncome);

            // Assert
            Assert.That(actualTax, Is.EqualTo(expectedTax));
        }
    }
}