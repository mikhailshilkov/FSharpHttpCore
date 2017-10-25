namespace HttpTriggerCore

open System.Linq
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http
open Microsoft.Azure.WebJobs.Host

module SimpleHttp =

  let run(req: HttpRequest, log: TraceWriter) =
    log.Info("F# HTTP trigger function processed a request.")

    let found, value = req.Query.TryGetValue "name"
    if found then    
      OkObjectResult("Hi, " + value.First()) :> IActionResult
    else
      BadRequestObjectResult "Please pass a name on the query string or in the request body" :> IActionResult