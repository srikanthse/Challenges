using System.Collections.Generic;
using Challenges.Application.Dtos;
using Challenges.API.Request;

namespace Challenges.API.RequestValidator
{
    public interface ITrolleyTotalRequestValidator
    {
        IEnumerable<ValidationResultDto> Validate(TrolleyTotalRequest request);
    }
}
