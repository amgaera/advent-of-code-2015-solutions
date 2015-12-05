open System.IO

let changeFloor floor char =
    match char with
    | '(' -> floor + 1
    | ')' -> floor - 1
    | _ -> failwithf "Read unexpected character %c" char

File.ReadAllText "input"
|> Seq.fold changeFloor 0
|> printfn "%d"