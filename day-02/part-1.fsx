open System.IO

type Dimensions =
    { Length : uint32;
      Width : uint32;
      Height : uint32 }

let parseDimensions (line : string) =
    let dimensions =
        line.Split('x')
        |> Array.map uint32

    match dimensions with
    | [| length; width; height |] -> { Length = length; Width = width; Height = height }
    | _ -> failwithf "Failed to parse %s into a valid dimension" line

let calculateWrappingPaper (dimensions : Dimensions) =
    let sideSizes =
        [ dimensions.Length * dimensions.Width;
          dimensions.Width * dimensions.Height;
          dimensions.Height * dimensions.Length ]

    let coverPaper = sideSizes |> List.sumBy (fun size -> 2u * size)
    let slackPaper = sideSizes |> List.min

    coverPaper + slackPaper

File.ReadLines "input"
|> Seq.map parseDimensions
|> Seq.map calculateWrappingPaper
|> Seq.sum
|> printfn "%d"