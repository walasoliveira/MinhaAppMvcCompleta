using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace DevIO.App.Extension
{
    [HtmlTargetElement("*", Attributes = "supress-by-claim-name")]
    [HtmlTargetElement("*", Attributes = "supress-by-claim-value")]
    public class ApagaElementoPorClaimTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAcessor;

        public ApagaElementoPorClaimTagHelper(IHttpContextAccessor contextAcessor)
        {
            _contextAcessor = contextAcessor;
        }

        [HtmlAttributeName("supress-by-claim-name")]
        public string IdentityClaimName { get; set; }

        [HtmlAttributeName("supress-by-claim-value")]
        public string IdentityClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null) throw new ArgumentException(nameof(context));

            if (output == null) throw new ArgumentException(nameof(output));

            var temAcesso = CustomAuthorization.ValidarClaimsUsuario(_contextAcessor.HttpContext, IdentityClaimName, IdentityClaimValue);

            if (temAcesso) return;

            output.SuppressOutput();
        }
    }
}
