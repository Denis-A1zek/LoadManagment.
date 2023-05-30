using Sigida.LoadManagment.Shared;
using Sigida.LoadManagment.Shared.Models;

namespace Sigida.LoadManagment.Services.Interfaces;

public interface IPositionsService
{
    Task<Response<IEnumerable<PositionViewModel>>> GetPositions();
}
