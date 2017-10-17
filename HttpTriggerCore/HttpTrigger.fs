namespace HttpTriggerCore

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Primitives
open Microsoft.AspNetCore.Http
open Microsoft.Azure.WebJobs.Host
open System.Linq

module HttpTrigger =
  let Run(req: HttpRequest, log: TraceWriter) =
    log.Info("F# HTTP trigger function processed a request.")

    let found, value = req.Query.TryGetValue "name"
    if found then    
      OkObjectResult("Hi, " + value.First()) :> IActionResult
    else
      BadRequestObjectResult "Please pass a name on the query string or in the request body" :> IActionResult