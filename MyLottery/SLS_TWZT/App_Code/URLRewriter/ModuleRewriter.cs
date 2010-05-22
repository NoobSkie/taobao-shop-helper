namespace URLRewriter
{
    using System;
    using System.Text.RegularExpressions;
    using System.Web;

    public class ModuleRewriter : HttpModule
    {
        protected override void Rewrite(string requestedPath, HttpApplication app)
        {
            app.Context.Trace.Write("ModuleRewriter", "Entering ModuleRewriter");
            RewriterRuleCollection rules = RewriterConfiguration.GetConfig().Rules;
            for (int i = 0; i < rules.Count; i++)
            {
                Regex regex = new Regex("^" + RewriterUtils.ResolveUrl(app.Context.Request.ApplicationPath, rules[i].LookFor) + "$", RegexOptions.IgnoreCase);
                if (regex.IsMatch(requestedPath))
                {
                    string sendToUrl = RewriterUtils.ResolveUrl(app.Context.Request.ApplicationPath, regex.Replace(requestedPath, rules[i].SendTo));
                    app.Context.Trace.Write("ModuleRewriter", "Rewriting URL to " + sendToUrl);
                    RewriterUtils.RewriteUrl(app.Context, sendToUrl);
                    break;
                }
            }
            app.Context.Trace.Write("ModuleRewriter", "Exiting ModuleRewriter");
        }
    }
}

