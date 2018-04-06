module Giphy

open Fable.Core.JsInterop
open Fable.Import.JS
open Fable.PowerPack

let fetchGif topic : Promise<string> = promise {
  let url = "https://api.giphy.com/v1/gifs/random?api_key=dc6zaTOxFJmzC&tag=" + topic
  let! result = Fetch.fetchAs<_> url []
  return !!result?data?image_url
}
