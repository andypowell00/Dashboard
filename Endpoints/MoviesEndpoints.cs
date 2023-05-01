using Dashboard.DataAccess.Data;
using Dashboard.DataAccess.Entities;
using Dashboard.Extensions;
using Dashboard.Filters;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace Dashboard.Endpoints
{
    public static class MoviesEndpoints
    {
        public static void MapMovieEndpoints(this WebApplication app)
        {
            app.MapGet("/movies", List);
            app.MapGet("/movies/{id}", Get);
            app.MapPost("/movies", Create).AddEndpointFilter<ValidationFilter<Movie>>();
            app.MapPut("/movies", Update);
            app.MapDelete("/movies/{id}", Delete);
        }

        public static async Task<IResult> List(DashboardDbContext db)
        {
            var result = await db.Movies.ToListAsync();
            return Results.Ok(result);
        }
        public static async Task<IResult> Get(DashboardDbContext db, int id) {

            return await db.Movies.FindAsync(id) is Movie movie ? Results.Ok(movie) : Results.NotFound();

        }
        public static async Task<IResult> Create(DashboardDbContext db, Movie movie)
        {

            db.Movies.Add(movie);
            await db.SaveChangesAsync();

            return Results.Created($"/movies/{movie.Id}", movie);
        }
        public static async Task<IResult> Update(DashboardDbContext db, IValidator<Movie> validator, Movie updatedMovie)
        {

            var movie = await db.Movies.FindAsync(updatedMovie.Id);

            db.Movies.Update(updatedMovie);
            await db.SaveChangesAsync();

            return Results.NoContent(); 
        }
        public static async Task<IResult> Delete(DashboardDbContext db, int id)
        {

            if(await db.Movies.FindAsync(id) is Movie movie)
            {
                db.Movies.Remove(movie);
                await db.SaveChangesAsync();
                return Results.Ok(movie);

            }
            return Results.NotFound();
        } 
    }
}
