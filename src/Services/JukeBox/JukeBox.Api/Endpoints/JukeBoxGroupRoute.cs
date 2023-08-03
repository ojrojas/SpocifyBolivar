namespace JukeBox.Api.Endpoints;

public static class JukeBoxGroupRoute
{
    public static RouteGroupBuilder AddJukeBoxGroupRoute(this RouteGroupBuilder group)
    {
        group.MapGet("/jukebox/severalbrowse/{country}/{locale}/{limit}",
            [Authorize] async
            (HttpContext _context, IJukeBoxService _service, [FromRoute] string country, [FromRoute] string locale, [FromRoute] int limit, CancellationToken cancellationToken) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
            var userId = result.Principal!.FindFirst("sub")!.Value;

            return await _service.GetSeveralBrowseAsync(new SeveralBrowseRequest { Country = country, Limit = limit, Locale = locale }, userId, cancellationToken);
        });

        group.MapGet("/jukebox/artist/{id}",
            [Authorize] async
            (HttpContext _context, IJukeBoxService _service, [FromRoute] string id, CancellationToken cancellationToken) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
            var userId = result.Principal!.FindFirst("sub")!.Value;

            return await _service.GetArtistAsync(id, userId, cancellationToken);
        });

        group.MapGet("/jukebox/search/{query}/{type}/{limit}",
            [Authorize] async
            (HttpContext _context, IJukeBoxService _service, [FromRoute] string query, [FromRoute] string type, [FromRoute] int limit, CancellationToken cancellationToken) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
            var userId = result.Principal!.FindFirst("sub")!.Value;

            return await _service.GetSearchAsync(new SearchRequest { Query = query, Type = type, Limit = limit }, userId, cancellationToken);
        });
        return group;
    }
}