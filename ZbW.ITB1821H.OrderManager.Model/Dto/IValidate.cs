using System.ComponentModel;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public interface IValidate
    {
        bool IsValid { get; }
    }
}
