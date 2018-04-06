# Giphy

A Fable port of [the HTTP example][elm-http] in the Elm Introduction.

  [elm-http]: https://guide.elm-lang.org/architecture/effects/http.html

## Building

You'll need Node.js, Yarn and the .NET Core SDK to build this example on your machine. If you're on Linux or macOS, you'll also need Mono. When you're all set up, run the following commands in your terminal:

``` shell
.paket/paket.exe restore
dotnet restore src/
yarn install
cd src/
dotnet fable yarn-run start
```

Now you can open your browser and navigate to [localhost:8080](http://localhost:8080).
