using Settlement.Infrastructure.SettlementContracts.AccountContracts;

namespace Settlement.Infrastructure.Models.AccountModels
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
