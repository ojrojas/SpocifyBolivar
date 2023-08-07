namespace JukeBox.Api.Endpoints;

public static class JukeBoxGroupRoute
{
    public static RouteGroupBuilder AddJukeBoxGroupRoute(this RouteGroupBuilder group)
    {
        group.MapGet("/jukebox/artist/{id}",
            [Authorize] async
            (HttpContext _context, IJukeBoxService _service, [FromRoute] string id, CancellationToken cancellationToken) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
             throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            var principal = result.Principal;

            return await _service.GetArtistAsync(id, principal, cancellationToken);
        });

        group.MapGet("/jukebox/search/{query}",
            [Authorize] async
            (HttpContext _context, IJukeBoxService _service, [FromRoute] string query, CancellationToken cancellationToken) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            var principal = result.Principal;
            return await _service.GetSearchAsync(query, principal, cancellationToken);
        });

        group.MapGet("/jukebox/album/{query}",
            [Authorize] async
            (HttpContext _context, IJukeBoxService _service, [FromRoute] string query, CancellationToken cancellationToken) =>
            {
                var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
                throw new InvalidOperationException("Error request opration not found a valid request open iddict");
                var principal = result.Principal;
                return await _service.GetAlbumAsync(query, principal, cancellationToken);
            });

        return group;
    }
}