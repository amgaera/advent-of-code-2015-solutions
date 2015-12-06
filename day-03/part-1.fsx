open System.IO

let changePosition (position : int * int) direction =
    let x, y = position

    match direction with
    | '^' -> x, y + 1
    | 'v' -> x, y - 1
    | '>' -> x + 1, y
    | '<' -> x - 1, y
    | _ -> failwithf "Read unexpected direction %c" direction

File.ReadAllText "input"
|> Seq.scan changePosition (0, 0)
|> Set.ofSeq
|> Set.count
|> printfn "%d"