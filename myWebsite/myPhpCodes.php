<?php
	class myObject{
		public function mySearch()
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
				if(($result = sqlsrv_query($conn,"SELECT [PersonID],[firstName],[middleName],[lastName],[Age],[contactNumber] ,[address] FROM [dbo].[myUserTable] Where [PersonID] =?",$params)) != false){
					$row_count = sqlsrv_has_rows($result);
					if( $row_count  == false)
					{
						echo json_encode(array("responsCode"=> "0","responseMessage"=> "No Data Found!"));
					}
					else
					{
						while( $obj = sqlsrv_fetch_object( $result )) {
							echo json_encode(array("id"=>$obj->PersonID,"name"=>"$obj->firstName","midName"=>$obj->middleName,"lName"=>$obj->lastName,"age"=>$obj->Age,"cNumber"=>$obj->contactNumber,"address"=>$obj->address ,"responsCode"=> "1","responseMessage"=> "Data Found!"));
						}
					}
				}
			}else{
				die(print_r(sqlsrv_errors(), true));
			}
		}//
	}
?>
<?php
	$obj = new myObject();
	$obj->mySearch();
	?>