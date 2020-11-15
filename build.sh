cd cheat-wasm
dotnet publish -c release -o ../
cd ..
rm web.config
mv wwwroot/* .
rm -rf wwwroot
