sh clean.sh
cd cheat-wasm
dotnet clean
dotnet publish -c release -o ../
cd ..
rm web.config
mv wwwroot/* .
echo '* binary' > _framework/.gitattributes 
rm -rf wwwroot
