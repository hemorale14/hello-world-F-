namespace WebApi.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

[<ApiController>]
[<Route("[controller]")>]
type GreetingController (logger : ILogger<GreetingController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let values =  [|"Hello World F#/ASP.NET Core web API!"; "Alumno: Hector Rocha Morales"; "Materia: Contenedores"; "Universidad Internacional de La Rioja en México"|]
        ActionResult<string[]>(values)
