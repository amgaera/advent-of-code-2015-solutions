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

let calculateRibbonLength (dimensions : Dimensions) =
    let dimensionsBySize =
        [ dimensions.Length; dimensions.Width; dimensions.Height ]
        |> List.sort

    let smallestFacePerimeter = 2u * dimensionsBySize.[0] + 2u * dimensionsBySize.[1]
    let presentVolume = dimensions.Length * dimensions.Width * dimensions.Height;

    smallestFacePerimeter + presentVolume

File.ReadLines "input"
|> Seq.map parseDimensions
|> Seq.map calculateRibbonLength
|> Seq.sum
|> printfn "%d"