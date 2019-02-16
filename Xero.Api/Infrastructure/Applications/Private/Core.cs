using Xero.Api.Core;
using Xero.Api.Infrastructure.Authenticators;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Infrastructure.Applications.Private
{
    public class Core : XeroCoreApi
    {
        public Core(bool includeRateLimiter = false, XeroApiSettings ApplicationSettings = null) :
        this(ApplicationSettings, new PrivateAuthenticator(ApplicationSettings.SigningCertificatePath, ApplicationSettings.SigningCertificatePassword), includeRateLimiter)
        {
        }

        public Core(XeroApiSettings ApplicationSettings, IAuthenticator authenticator, bool includeRateLimiter = false)
            : base(authenticator, ApplicationSettings, rateLimiter: includeRateLimiter ? new RateLimiter.RateLimiter() : null)
        {
        }
    }
}
