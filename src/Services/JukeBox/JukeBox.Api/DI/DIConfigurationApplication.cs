namespace JukeBox.Api.DI
{
    public static class DIConfigurationApplication
    {
        public static WebApplication AddDIConfigurationApplication(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.MapDefaultControllerRoute();

            app.MapGroup(string.Empty).AddJukeBoxGroupRoute();
            return app;
        }
    }
}

