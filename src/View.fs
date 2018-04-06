module View

open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props
open App

let radio name isChecked labelStr onChange : ReactElement =
  label [] [
    input [
      Type "radio"
      Name name
      Checked isChecked
      OnChange onChange
    ]
    str labelStr
  ]

let pickerFor items selectedItem groupName toLabel dispatch =
  items
  |> List.map (fun x -> radio groupName (x = selectedItem) (toLabel x) (delay dispatch x))
  |> fieldset []

let displayTextOfTopic t =
  match t with
  | Dogs -> "Dogs"
  | Cats -> "Cats"

let root showImage model dispatch =
  let topics =
    typeof<Topic>
    |> Reflection.FSharpType.GetUnionCases
    |> Array.map (fun info -> Reflection.FSharpValue.MakeUnion (info, [||]) :?> Topic)
    |> List.ofArray

  let imageView src =
    if showImage then
      img [ Src src ]
    else
      span [] [
        str src
      ]

  div [] [
    pickerFor topics model.Topic "topic" displayTextOfTopic (ChangeTopic >> dispatch)
    imageView model.GifUrl
    button [ OnClick (delay dispatch More) ] [
      str "Another one!"
    ]
  ]
