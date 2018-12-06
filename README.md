# natwarehouse

Start MS SQL Docker image:
sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=SecretPass0!' -p 1433:1433 --name mssql -d microsoft/mssql-server-linux:2017-latest

