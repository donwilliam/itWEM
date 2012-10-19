<?php 
//SERVER     : dq8781598d.database.windows.net,1433 
//DATABASE : tmp
//USERNAME: itwemadmin



$connectionInfo = array("UID" => "itwemadmin@dq8781598d", "pwd" => "1de8c2ed85,", "Database" => "tmp", "LoginTimeout" => 30, "Encrypt" => 1);
$serverName = "tcp:dq8781598d.database.windows.net,1433";
$dbname = "tmp";
$conn = sqlsrv_connect($serverName, $connectionInfo) or die('Could not connect to server: ' . mysql_error());

$sql = "INSERT INTO Tmp VALUES (GetDate(),25.2)";
$result=mysql_query($sql) or die('could not insert ' . $sql . ': ' . mysql_error());
?>