open System.IO

let changeFloor floor char =
    match char with
    | '(' -> floor + 1
    | ')' -> floor - 1
    | _ -> failwithf "Read unexpected character %c" char

File.ReadAllText "input"
|> Seq.scan changeFloor 0
|> Seq.findIndex (fun floor -> floor < 0)
|> printfn "%d"