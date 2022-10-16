using ExplicitMapper.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExplicitMapper();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/stateInfo", (
    [FromQuery] string? abbreviation,
    [FromQuery] string? fullName,
    [FromServices] ExplicitMapper.Mappings.ExplicitMapper mapper) =>
{
    if (!string.IsNullOrEmpty(abbreviation))
        return new StateInfo(abbreviation, mapper.Map(abbreviation).ToStateFullName());

    if (!string.IsNullOrEmpty(fullName))
        return new StateInfo(mapper.Map(fullName).ToStateAbbreviation(), fullName);

    return new StateInfo("", "");
})
.WithName("GetStateInfo");

app.Run();

internal record StateInfo(string Abbreviation, string FullName);
