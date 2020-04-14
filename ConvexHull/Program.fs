// Learn more about F# at http://fsharp.org

open System

let [<Literal>] Whitespace = " "

type Point = { X: float; Y: float }

let clockwise (p1, p2, p3) =
   (p2.X - p1.X) * (p3.Y - p1.Y)
   - (p2.Y - p1.Y) * (p3.X - p1.X)
   <= 0.0

let distance point1 point2=
    let x = (point2.X - point1.X)
    let y = (point2.Y - point1.Y)
    ((x ** 2.) + (y ** 2.))
    |>  Math.Sqrt

let rec chain (hull: Point list) (candidates: Point list) =
   match candidates with
   | [ ] -> hull
   | c :: rest ->
      match hull with
      | [ ] -> chain [ c ] rest
      | [ start ] -> chain [c ; start] rest
      | b :: a :: tail -> 
         if clockwise (a, b, c) then chain (c :: hull) rest else
         chain (a :: tail) rest

let hull (points: Point list) =
   match points with
   | [ ] -> points
   | [ _ ] -> points
   | _ ->
       let sorted = List.sort points
       let upper = chain [ ] sorted
       let lower = chain [ ] (List.rev sorted)
       List.append (List.tail upper) (List.tail lower)

let perimeter (points: Point list) =
    let mutable lastPoint = points.Head
    points |> List.fold (
        fun acum point ->
            let res = acum + (lastPoint |> distance point)
            lastPoint <- point
            res) 0.

[<EntryPoint>]
let main argv =
    let t = Console.ReadLine() |> int
    let rec xy i =
        let data = Whitespace |> Console.ReadLine().Split
        match i with 
        | 1 -> [{ X = (data.[0] |> float); Y = (data.[1] |> float) }]
        | _ -> [{ X = (data.[0] |> float); Y = (data.[1] |> float) }] @ xy(i-1) 
    xy t |> hull |> perimeter |> printfn "%.1f"
    0
