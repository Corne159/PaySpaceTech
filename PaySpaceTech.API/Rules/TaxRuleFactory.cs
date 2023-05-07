namespace PaySpaceTech.API.Rules
{
    public class TaxRuleFactory
    {
        private IReadOnlyDictionary<string, ITaxType> _TaxRules;

        public TaxRuleFactory()
        {
            var taxRuleType = typeof(ITaxType);
            _TaxRules = taxRuleType.Assembly.ExportedTypes
                .Where(x => taxRuleType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<ITaxType>()
                .ToDictionary(x => x.TaxTypeCode, x => x);
        }

        public ITaxType GetTaxTypeChecker(string code)
        {
            return _TaxRules[code] ?? throw new ArgumentException("");
        }
    }
}
