using System.Collections.Generic;
using System.Linq;
using Glimpse.Agent.Web.Options;
using Glimpse.Web;
using Microsoft.Framework.OptionsModel;

namespace Glimpse.Agent.Web.Framework
{
    public class ContentTypeIgnoredRequestPolicy : IIgnoredRequestPolicy
    {
        private readonly IReadOnlyCollection<string> _contextType;

        public ContentTypeIgnoredRequestPolicy(IIgnoredContentTypeProvider ignoredContentTypeProvider)
        {
            _contextType = ignoredContentTypeProvider.ContentTypes;
        }

        public bool ShouldIgnore(IHttpContext context)
        {
            return _contextType.Contains(context.Response.ContentType);
        }
    }
}