using System.Collections.Generic;
using System.Threading.Tasks;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Services.Interfaces
{
    public interface IBodyService
    {
        Task<BodyDto> GetBodyByIdAsync(string id);
        Task<List<BodyDto>> GetBodiesAsync();
    }
}
