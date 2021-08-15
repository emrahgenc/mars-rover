using Refit;
using System;
using System.Threading.Tasks;

namespace MarsRoger.Client.ApiClients
{
    public interface IMarsRoverApiClient
    {
        [Post("/Plateau")]
        Task<Guid> CreatePlateauAsync(CreatePlateauRequest createPlateauRequest);

        [Post("/Rover")]
        Task<Guid> CreateRoverAsync(CreateRoverRequest createRoverRequest);

        [Patch("/Rover/{id}/Land")]
        Task LandRoverToPlateauAsync(Guid id, LandToPlateauRequest landToPlateauRequest);

        [Patch("/Rover/{id}/Move")]
        Task MoveRoverAsync(Guid id, MoveRoverRequest moveRoverRequest);

        [Patch("/Rover/{id}/Left")]
        Task TurnLeftRoverAsync(Guid id, TurnLeftRoverRequest turnLeftRoverRequest);

        [Patch("/Rover/{id}/Right")]
        Task TurnRightRoverAsync(Guid id, TurnRightRoverRequest turnRightRoverRequest);

        [Get("/Rover/{id}/Position")]
        Task<PositionViewModel> GetPositionAsync(Guid id);
    }
}
