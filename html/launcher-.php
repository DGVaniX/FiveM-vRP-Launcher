<?php
$Action = $_GET["act"];

include('../config.php');

if ($Action == "findID"){
	$id = $_GET['identifier'];
	$theID = 0;
	$sql=$dbh->prepare("SELECT * FROM `vrp_user_ids` WHERE `identifier` = ?");
	$sql->execute(array($id));
	while($row=$sql->fetch()){
		$theID = $row['user_id'];
	}
	echo($theID);
}
?>