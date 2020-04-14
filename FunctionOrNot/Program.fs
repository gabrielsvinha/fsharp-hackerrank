// Learn more about F# at http://fsharp.org

open System
open System.Collections.Generic

let [<Literal>] NO = "NO"
let [<Literal>] YES = "YES"
let [<Literal>] Whitespace = " "

let testCase() =
    let n = Console.ReadLine() |> int
    let rec xy i =
        let data = Whitespace |> Console.ReadLine().Split
        match i with 
        | 1 -> [(data.[0], data.[1])]
        | _ -> [(data.[0], data.[1])] @ xy(i-1) 

    let tuples = xy n
    let dc = tuples |> dict
    match dc.Keys.Count <> tuples.Length with
    | true -> NO
    | false -> YES
    |> printfn "%s"
    ()

[<EntryPoint>]
let main argv =
    let t = Console.ReadLine() |> int
    let rec loop i =
        match i with
        | 0 -> ()
        | _ ->
            testCase()
            loop (i-1)
    loop t
    0 // return an integer exit code