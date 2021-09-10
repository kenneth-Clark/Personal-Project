<?php
	$firstName = $_POST['ifirstName'];
	$middleName = $_POST['imiddleName'];
	$lastName = $_POST['ilastName'];
	$age = $_POST['iage'];
	$contactNumber = $_POST['icontactNumber'];
	$address = $_POST['iaddress'];

	$conn_array = array (
		"UID" => "sa",
		"PWD" => "Admin123!",
		"Database" => "localb",
	);
	$conn = sqlsrv_connect('ZOZOSQLSERVER', $conn_array);
	if ($conn){
		$sql = "INSERT INTO [dbo].[myUserTable] ([firstName],[middleName],[lastName],[Age],[contactNumer],[address]) VALUES(?,?,?,?,?,?)";
		$params =  array($firstName, $middleName, $lastName, $age, $contactNumber, $address);
		$stmt = sqlsrv_query( $conn, $sql, $params);
		if( $stmt === false ) {
			echo json_encode(array("responseCode"=>"0","responseMessage"=>"Insert Failed!"));
		}
		else
		{
			echo json_encode(array("responseCode"=>"1","responseMessage"=> "Data Succesfuly Inserted!"));
		}
	}else{
		die(print_r(sqlsrv_errors(), true));
	}
	?>