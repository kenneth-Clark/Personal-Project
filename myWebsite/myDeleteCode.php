<?php
	$id= $_POST['id'];
	$conn_array = array (
		"UID" => "sa",
		"PWD" => "Admin123!",
		"Database" => "localb",
	);
	$conn = sqlsrv_connect('ZOZOSQLSERVER', $conn_array);
	if ($conn){
		$sql = "DELETE FROM [dbo].[myUserTable] WHERE PERSONID = ?";
		$params =  array($id);

		$stmt = sqlsrv_query( $conn, $sql, $params);
		if( $stmt === false ) {
			echo json_encode(array("responseCode"=>"0","responseMessage"=>"Delete Failed!"));
		}
		else
		{
			echo json_encode(array("responseCode"=>"1","responseMessage"=> "Data Succesfuly Deleted!"));
		}
	}else{
		die(print_r(sqlsrv_errors(), true));
	}
	?>