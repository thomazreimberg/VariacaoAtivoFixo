/opt/mssql/bin/sqlservr &


/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Teste123@456" -Q "CREATE DATABASE VariacaoAtivoFixoDB"

status=1
while [ $status -ne 0 ]; do
    /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Teste123@456" -Q "SELECT 1" &>/dev/null
    status=$?
    sleep 1
done

tail -f /dev/null