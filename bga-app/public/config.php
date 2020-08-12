<?php
//connection works fine
$host = "localhost:3306";
$user = "root";
$password = "tylerp93";
$dbname = "mydb";

$con = mysqli_connect($host, $user, $password, $dbname);

$userData = mysqli_query($con, "select * from player order by playerId desc");
$response = array();

while($row = mysqli_fetch_assoc($userData)){
    $response[] = $row;
}

echo json_encode($response);

if (!$con){
    die("Connection failed: " . mysqli_connect_error());
}
?>
