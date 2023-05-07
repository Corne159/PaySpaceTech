using PaySpaceTech.API.Entities;
using PaySpaceTech.API.Entities.TaxTypes;

namespace PaySpaceTech.nUnitTests
{
    public class CalculatorTests
    {
        private TaxCalculator TaxCalculator { get; set; } = null!;


        /// Progressive Tax ///

        [TestCase(500,600)] //10% bracket
        [TestCase(1000, 1382.35)] //15% bracket
        [TestCase(5000, 11187.1)] //25% bracket
        [TestCase(10000, 27319.32)] //28% bracket
        [TestCase(20000, 64341.49)] //33% bracket
        [TestCase(50000, 187682.14)] //35% bracket
        public void CalculateProgressiveTax_WithMonthlyIncomeOf500_ShouldReturnCorrectTax(decimal monthlyIncome, decimal expectedTax)
        {
            // Assign
            var progressiveTax = new ProgressiveTax();
            progressiveTax.SetMonthlyIncome(monthlyIncome);
            TaxCalculator = new TaxCalculator(progressiveTax);

            // Act
            decimal actualTax = TaxCalculator.CalculateIncomeTax();

            // Assert
            Assert.That(actualTax, Is.EqualTo(expectedTax));
        }


        /// Flat Rate Tax ///

        [TestCase(10)]
        [TestCase(500)]
        [TestCase(7000)]
        [TestCase(10000)]
        [TestCase(50000)]
        public void CalculateFlatRateTax_ShouldReturnCorrectTax(decimal monthlyIncome)
        {
            // Assign
            decimal expectedTax = monthlyIncome * 12 / 100 * (decimal)17.5;

            var flatRateTax = new FlatRateTax();
            flatRateTax.SetMonthlyIncome(monthlyIncome);
            TaxCalculator = new TaxCalculator(flatRateTax);

            // Act
            decimal actualTax = TaxCalculator.CalculateIncomeTax();

            // Assert
            Assert.That(actualTax, Is.EqualTo(expectedTax));
        }


        /// Flat Value Tax /// 
        /// Correct

        [TestCase(500)]
        [TestCase(3000)]
        [TestCase(7000)]
        [TestCase(10000)]
        [TestCase(16000)]
        public void CalculateFlatValueTax_WithMonthlyIncomeOf10000_ShouldReturnCorrectTax(decimal monthlyIncome)
        {
            // Assign
            decimal expectedTax = monthlyIncome * 12 / 100 * 5;

            var flatValueTax = new FlatValueTax();
            flatValueTax.SetMonthlyIncome(monthlyIncome);
            TaxCalculator = new TaxCalculator(flatValueTax);

            // Act
            decimal actualTax = TaxCalculator.CalculateIncomeTax();

            // Assert
            Assert.That(actualTax, Is.EqualTo(expectedTax));
        }

        [TestCase(17000)]
        [TestCase(20000)]
        [TestCase(30000)]
        [TestCase(50000)]
        [TestCase(80000)]
        public void CalculateFlatValueTax_WithMonthlyIncomeOf20000_ShouldReturnCorrectTax(decimal monthlyIncome)
        {
            // Assign
            decimal expectedTax = 10000;

            var flatValueTax = new FlatValueTax();
            flatValueTax.SetMonthlyIncome(monthlyIncome);
            TaxCalculator = new TaxCalculator(flatValueTax);

            // Act
            decimal actualTax = TaxCalculator.CalculateIncomeTax();

            // Assert
            Assert.That(actualTax, Is.EqualTo(expectedTax));
        }

        /// InCorrect

        [TestCase(17000)]
        [TestCase(20000)]
        [TestCase(30000)]
        [TestCase(50000)]
        [TestCase(80000)]
        public void CalculateFlatValueTax_WithMonthlyIncomeOf10000_ShouldReturnInCorrectTax(decimal monthlyIncome)
        {
            // Assign
            decimal expectedTax = monthlyIncome * 12 / 100 * 5;

            var flatValueTax = new FlatValueTax();
            flatValueTax.SetMonthlyIncome(monthlyIncome);
            TaxCalculator = new TaxCalculator(flatValueTax);

            // Act
            decimal actualTax = TaxCalculator.CalculateIncomeTax();

            // Assert
            Assert.That(actualTax, Is.Not.EqualTo(expectedTax));
        }

        [TestCase(10)]
        [TestCase(500)]
        [TestCase(3000)]
        [TestCase(7000)]
        [TestCase(10000)]
        [TestCase(16000)]
        public void CalculateFlatValueTax_WithMonthlyIncomeOf20000_ShouldReturnInCorrectTax(decimal monthlyIncome)
        {
            // Assign
            decimal expectedTax = 10000;

            var flatValueTax = new FlatValueTax();
            flatValueTax.SetMonthlyIncome(monthlyIncome);
            TaxCalculator = new TaxCalculator(flatValueTax);

            // Act
            decimal actualTax = TaxCalculator.CalculateIncomeTax();

            // Assert
            Assert.That(actualTax, Is.Not.EqualTo(expectedTax));
        }
    }
}