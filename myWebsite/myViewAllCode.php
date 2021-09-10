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
		if(($result = sqlsrv_query($conn,"SELECT  [PersonID],[firstName],[middleName],[lastName],[Age],[contactNumer] ,[address] FROM [dbo].[myUserTable]")) != false){
			$row_count = sqlsrv_has_rows($result);
			if( $row_count  == false)
			{
				echo json_encode(array("responsCode"=> "0","responseMessage"=> "No Data Found!"));
			}
			else
			{
				//header('Content-Type: application/json');
				$data = array();
				$arrayID = array();
				$arrayFirstName = array();
				$arrayMiddleName = array();
				$arrayLastName = array();
				$arrayAge = array();
				$arrayContactNumber = array();
				$arrayAddress = array();

				while( $obj = sqlsrv_fetch_object( $result )) {
					 $arrayID[]	=  array($obj->PersonID);
					 $arrayFirstName[] =  array($obj->firstName);
					 $arrayMiddleName[] = array($obj->middleName);
					 $arrayLastName[] = array($obj->lastName);
					 $arrayAge[] = array($obj->Age);
					 $arrayContactNumber[] = array($obj->contactNumer);
					 $arrayAddress[] = array($obj->address);
					//echo json_encode(array("id"=>$obj->PersonID,"name"=>$obj->firstName,"midName"=>$obj->middleName,"lName"=>$obj->lastName,"age"=>$obj->Age,"cNumber"=>$obj->contactNumer,"address"=>$obj->address ,"responsCode"=> "1","responseMessage"=> "Data Found!"));
				}
				$data['resultid'] = $arrayID;
				$data['resultfirstName'] = $arrayFirstName;
				$data['resultmiddleName'] = $arrayMiddleName;
				$data['resultlastName'] = $arrayLastName;
				$data['resultage'] = $arrayAge;
				$data['resultContactNumber'] = $arrayContactNumber;
				$data['resultaddress'] = $arrayAddress;
				$data['responsCode'] = "1";
				$data['responseMessage'] = "Data Found!";
				echo json_encode($data);
			}
		}
	}else{
		die(print_r(sqlsrv_errors(), true));
	}
	?>