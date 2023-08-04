namespace JukeBox.Api.Endpoints;

public static class JukeBoxGroupRoute
{
    public static RouteGroupBuilder AddJukeBoxGroupRoute(this RouteGroupBuilder group)
    {
        group.MapGet("/jukebox/severalbrowse/{query}",
            [Authorize] async
            (HttpContext _context, IJukeBoxService _service, [FromRoute] string query, CancellationToken cancellationToken) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
            var userId = result.Principal!.FindFirst("sub")!.Value;

            return await _service.GetSeveralBrowseAsync(query, userId, cancellationToken);
        });

        group.MapGet("/jukebox/artist/{id}",
            [Authorize] async
            (HttpContext _context, IJukeBoxService _service, [FromRoute] string id, CancellationToken cancellationToken) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
            var userId = result.Principal!.FindFirst("sub")!.Value;

            return await _service.GetArtistAsync(id, userId, cancellationToken);
        });

        group.MapGet("/jukebox/search/{query}",
            [Authorize] async
            (HttpContext _context, IJukeBoxService _service, [FromRoute] string query, CancellationToken cancellationToken) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
            var userId = result.Principal!.FindFirst("sub")!.Value;
            return await _service.GetSearchAsync(query, userId, cancellationToken);
        });
        return group;
    }
}