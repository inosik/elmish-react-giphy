module Main

open Elmish
open Elmish.React
open Elmish.HMR

Program.mkProgram App.init App.update (View.root true)
#if DEBUG
|> Program.withHMR
|> Program.withConsoleTrace
#endif
|> Program.withReact "app"
|> Program.run
