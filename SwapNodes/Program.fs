// Learn more about F# at http://fsharp.org

open System

type Node = { Value: int; Depth: int; }

type BinaryTree = 
    { Root: Node; Left: BinaryTree option; Right: BinaryTree option; }

let rec inOrderTransverse (binaryTree: BinaryTree) =
    binaryTree.Left
    |> Option.map(fun left -> inOrderTransverse left |> ignore)
    |> ignore
    printfn "%d" binaryTree.Root.Value
    binaryTree.Right
    |> Option.map(fun right -> inOrderTransverse right |> ignore)
    |> ignore

let parseInput() =
    let input = " " |> Console.In.ReadLine().Split


[<EntryPoint>]
let main argv =
    let rootNode = { Value = 0; Depth = 0; }
    let binTree = { Root = rootNode }
    let n = Console.In.ReadLine() |> int

    let n = Console.In.ReadLine() |> int
    0 // return an integer exit code
