using AoC2022.Services;
using Microsoft.AspNetCore.Mvc;

namespace AoC2022.Controllers;

[ApiController]
[Route("[controller]")]
public class Aoc2022Controller : ControllerBase
{
    private readonly IAoc2022Service service;

    public Aoc2022Controller(IAoc2022Service service)
    {
        this.service = service;
    }

    [HttpGet("1")]
    public int AoC1()
    {
        return service.AoC001();
    }

}