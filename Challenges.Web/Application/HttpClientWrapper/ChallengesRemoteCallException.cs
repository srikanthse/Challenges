using System;

namespace Challenges.Application.HttpClientWrapper
{
    public class ChallengesRemoteServiceException : Exception
    {
        public ChallengesRemoteServiceException(string message) : base(message)
        {

        }
    }
}
