[<AutoOpen>]
module Prelude

/// Creates a function that _always_ returns the same value.
let always x _ = x

/// Creates a function that delays the evaluation of `f x`.
let delay f x _ = f x
