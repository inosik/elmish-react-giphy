module Main

open Elmish
open Elmish.React
open Elmish.HMR

Program.mkProgram App.init App.update (View.root true)
|> Program.withHMR
|> Program.withConsoleTrace
|> Program.withReact "app"
|> Program.run
