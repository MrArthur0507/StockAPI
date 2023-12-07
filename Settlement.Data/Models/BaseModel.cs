using Settlement.API.Controllers.SettlementContracts;


namespace Settlement.Infrastructure.Models
{
    public class BaseModel : IBaseModel
    {
        public string Id { get; set; }
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
