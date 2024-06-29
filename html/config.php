<?php

$host="127.0.0.1";
$username="root";
$password="";
$db_name="vrp";
$port = 3306; 

$dbh = new PDO("mysql:host=$host;dbname=$db_name;port=$port", $username, $password);
?>
