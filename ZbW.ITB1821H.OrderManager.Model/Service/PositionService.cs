using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class PositionService : ServiceBase<Position, PositionDto>, IPositionService
    {
        public PositionService(IPositionRepository repo) : base(repo) { }
    }
}
