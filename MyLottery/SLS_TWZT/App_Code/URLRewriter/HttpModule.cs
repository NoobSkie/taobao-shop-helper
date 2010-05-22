namespace URLRewriter
{
    using System;
    using System.Web;

    public abstract class HttpModule : IHttpModule
    {
        protected HttpModule()
        {
        }

        protected virtual void BaseModuleRewriter_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication) sender;
            this.Rewrite(app.Request.Path, app);
        }

        public virtual void Dispose()
        {
        }

        public virtual void Init(HttpApplication app)
        {
            app.BeginRequest += new EventHandler(this.BaseModuleRewriter_AuthorizeRequest);
        }

        protected abstract void Rewrite(string requestedPath, HttpApplication app);
    }
}

