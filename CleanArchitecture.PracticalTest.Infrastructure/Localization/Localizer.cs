using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Infrastructure.Localization
{
    public class Localizer(IStringLocalizerFactory factory) : ILocalizer
    {
        private readonly IStringLocalizer _localizer = factory.Create("SharedResources",typeof(Localizer).Assembly.FullName);

        public string GetDomainConcept(string key, params object[] args)
        {
            return GetLocalizedString("Domain. " +  key, args);
        }

        public string GetEnumValue(string key, params object[] args)
        {
            return GetLocalizedString("Enum. " + key, args);
        }

        public string GetExceptionMessage(string key, params object[] args)
        {
            return GetLocalizedString("Exception. " + key, args);
        }

        public string GetLoggerMessage(string key, params object[] args)
        {
            return GetLocalizedString("Logger. " + key, args);
        }

        public string GetResponseMessage(string key, params object[] args)
        {
            return GetLocalizedString("Response. " + key, args);
        }

        public string GetValidationMessage(string key, params object[] args)
        {
            return GetLocalizedString("Validation. " + key, args);
        }

        private string GetLocalizedString(string key, params object[] args)
        {
            var localizedString = _localizer[key];
            return localizedString.ResourceNotFound ? key : string.Format(localizedString.Value, args); 
        }

    }
}
