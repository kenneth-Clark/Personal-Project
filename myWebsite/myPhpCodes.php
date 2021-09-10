<?php
	$id= $_POST['id'];
	$conn_array = array (
		"UID" => "sa",
		"PWD" => "Admin123!",
		"Database" => "localb",
	);
	$conn = sqlsrv_connect('ZOZOSQLSERVER', $conn_array);
	if ($conn){
		$params = array($id);
		if(($result = sqlsrv_query($conn,"SELECT [PersonID],[firstName],[middleName],[lastName],[Age],[contactNumer] ,[address] FROM [dbo].[myUserTable] Where [PersonID] =?",$params)) != false){
			$row_count = sqlsrv_has_rows($result);
			if( $row_count  == false)
			{
				echo json_encode(array("responsCode"=> "0","responseMessage"=> "No Data Found!"));
			}
			else
			{
				while( $obj = sqlsrv_fetch_object( $result )) {
					echo json_encode(array("id"=>$obj->PersonID,"name"=>$obj->firstName,"midName"=>$obj->middleName,"lName"=>$obj->lastName,"age"=>$obj->Age,"cNumber"=>$obj->contactNumer,"address"=>$obj->address ,"responsCode"=> "1","responseMessage"=> "Data Found!"));
				}
			}
		}
	}else{
		die(print_r(sqlsrv_errors(), true));
	}
	?>