namespace PaySpaceTech.API.Entities.Dto
{
    public class PostalCodeDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string CalculationType { get; set; } = null!;
    }
}
