module App

open Elmish

type Topic =
  | Dogs
  | Cats

type Model =
  { Topic : Topic
    GifUrl : string }

type Msg =
  | NoOp
  | More
  | NewGif of string
  | ChangeTopic of Topic

let init () =
  { Topic = Dogs; GifUrl = "" }, Cmd.ofMsg More

let fetchGif topic =
  let topic =
    match topic with
    | Dogs -> "dogs"
    | Cats -> "cats"
  Cmd.ofPromise Giphy.fetchGif topic NewGif (always NoOp)

let update msg model =
  match msg with
  | NoOp -> model, Cmd.none
  | More -> model, fetchGif model.Topic
  | NewGif url ->
    { model with GifUrl = url }, Cmd.none
  | ChangeTopic newTopic when model.Topic <> newTopic ->
    { model with Topic = newTopic }, fetchGif newTopic
  | ChangeTopic _ -> model, Cmd.none
