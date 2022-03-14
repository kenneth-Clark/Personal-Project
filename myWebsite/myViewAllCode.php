<?php
	class myObject{
		public function myFunction ()
		{
		$id= $_POST['id'];
		$conn_array = array (
			"UID" => "sa",
			"PWD" => "Admin123!",
			"Database" => "localb",
		);
		$conn = sqlsrv_connect('DESKTOP-RJQPENS\MY_NEW_SQLSERVER', $conn_array);
		if ($conn){
			$params = array($id);
			if(($result = sqlsrv_query($conn,"SELECT  [PersonID],[firstName],[middleName],[lastName],[Age],[contactNumber] ,[address] FROM [dbo].[myUserTable]")) != false){
				$row_count = sqlsrv_has_rows($result);
				if( $row_count  == false)
				{
					echo json_encode(array("responsCode"=> "0","responseMessage"=> "No Data Found!"));
				}
				else
				{
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
						$arrayContactNumber[] = array($obj->contactNumber);
						$arrayAddress[] = array($obj->address);
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
		}
	}
?>
<?php
	$obj = new myObject();
	$obj->myFunction();
?>