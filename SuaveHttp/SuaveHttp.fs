namespace HttpTriggerCore

module App =
  open Suave
  open Suave.Successful
  open Suave.Operators
  open Suave.Filters

  let app = 
    GET >=> choose
      [ path "/api/suave/hello" >=> OK "Hello GET"
        path "/api/suave/goodbye" >=> OK "Good bye GET" ]

module SuaveHttp =
  open Suave.Azure.Functions.Context

  let run req =
    req |> runWebPart App.app  |> Async.StartAsTask