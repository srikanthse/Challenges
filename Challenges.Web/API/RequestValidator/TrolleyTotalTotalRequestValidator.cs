using System.Collections.Generic;
using Challenges.Application.Dtos;
using Challenges.API.Request;

namespace Challenges.API.RequestValidator
{
    public class TrolleyTotalTotalRequestValidator : ITrolleyTotalRequestValidator
    {
        public IEnumerable<ValidationResultDto> Validate(TrolleyTotalRequest request)
        {
            var validationErrors = new List<ValidationResultDto>();
            if (request == null)
            {
                AddValidationError(validationErrors, "Request cannot be null");
                return validationErrors;
            }

            if (request.Products == null)
                AddValidationError(validationErrors, "The Products field is required.");

            if (request.Specials == null)
                AddValidationError(validationErrors, "The Specials field is required.");

            if (request.Quantities == null)
                AddValidationError(validationErrors, "The Quantities field is required.");

            return validationErrors;
        }

        private static void AddValidationError(List<ValidationResultDto> validationErrors, string message)
        {
            validationErrors.Add(new ValidationResultDto { Message = message });
        }
    }
}
