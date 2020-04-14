// Learn more about F# at http://fsharp.org

open System

let [<Literal>] Whitespace = " "
let [<Literal>] WrongPassword = "WRONG PASSWORD"

let testCase() =
    let n = Console.ReadLine() |> int
    let passwords = 
        Whitespace
        |> Console.ReadLine().Split
        |> Set.ofArray
    let loginAttempt = Console.ReadLine() |> Seq.map (fun c ->  [ c |> string ] )
    let reducedValue = 
        loginAttempt
        |> Seq.reduce (fun pass1 pass2 ->
            let matchingStr = pass1 |> List.last
            match passwords |> Set.contains matchingStr with
            | true ->
                pass1 @ pass2
            | false -> pass1.GetSlice (Some 0, Some (pass1.Length - 2)) @ [matchingStr + (pass2 |> List.head)])
    let usedPasswords = match passwords |> Set.contains (reducedValue.Item(reducedValue.Length - 1)) with 
                        | true -> reducedValue
                        | false -> reducedValue.GetSlice (Some 0, Some (reducedValue.Length - 2))
    let x = usedPasswords |> Seq.sumBy (fun str1-> str1 |> String.length)
    match x <> (loginAttempt |> Seq.length) with
    | true -> WrongPassword 
    | false -> String.Join(Whitespace, usedPasswords)
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
