using Domain.Common;


namespace Domain
{
    public  class TestClassTwo : BaseDomainModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }
    }
}
