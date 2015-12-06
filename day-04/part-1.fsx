open System.IO
open System.Security.Cryptography
open System.Text

let computeHash (md5 : MD5) key number =
    let input = sprintf "%s%d" key number

    Encoding.UTF8.GetBytes input
    |> md5.ComputeHash 

let isAdventCoinHash (hash : byte array) =
    hash.[0] = 0uy && hash.[1] = 0uy && hash.[2] < 16uy

let mineAdventCoins md5 key =
    Seq.initInfinite id
    |> Seq.map (fun number -> number, computeHash md5 key number)
    |> Seq.filter (snd >> isAdventCoinHash)
    |> Seq.map fst

let md5 = MD5.Create ()

File.ReadAllText "input"
|> mineAdventCoins md5
|> Seq.head
|> printfn "%d"