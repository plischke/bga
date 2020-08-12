<?php
include "config.php";

$data = json_decode(file_get_contents("php://input"));

$request = $data->request;

//fetch all player records
if($request == 1){
    $userData = mysqli_query($con, "select * from player order by playerId desc");

    $response = array();
    while($row = mysqli_fetch_assoc($userData)){
        $response[] = $row;
    }

    echo json_encode($response);
    exit;
    
}

?>