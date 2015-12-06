open System.IO

let changePosition (position : int * int) direction =
    let x, y = position

    match direction with
    | '^' -> x, y + 1
    | 'v' -> x, y - 1
    | '>' -> x + 1, y
    | '<' -> x - 1, y
    | _ -> failwithf "Read unexpected direction %c" direction

let getVisitedHouses directions =
    directions
    |> Seq.map snd
    |> Seq.scan changePosition (0, 0)

let humanSantaDirections, roboSantaDirections =
    File.ReadAllText "input"
    |> Seq.indexed
    |> List.ofSeq
    |> List.partition (fun (index, direction) -> index % 2 = 0)

[ humanSantaDirections; roboSantaDirections ]
|> List.map getVisitedHouses
|> Seq.concat
|> Set.ofSeq
|> Set.count
|> printfn "%d"