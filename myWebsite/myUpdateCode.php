<?php
	class myObject
	{
		public function myUpdate()
		{
			$id= $_POST['id'];
			$firstName = $_POST['firstName'];
			$middleName = $_POST['middleName'];
			$lastName = $_POST['lastName'];
			$age = $_POST['age'];
			$contactNumber = $_POST['contactNumber'];
			$address = $_POST['address'];
		
			$conn_array = array (
				"UID" => "sa",
				"PWD" => "Admin123!",
				"Database" => "localb",
			);
			$conn = sqlsrv_connect('DESKTOP-RJQPENS\MY_NEW_SQLSERVER', $conn_array);
			if ($conn){
				$sql = "UPDATE [dbo].[myUserTable] SET [firstName] = ? ,[middleName] = ? ,[lastName] = ? ,[Age] = ? ,[contactNumber] = ? ,[address] = ? WHERE Personid = ?";
				$params =  array($firstName, $middleName, $lastName, $age, $contactNumber, $address,$id);
		
				$stmt = sqlsrv_query( $conn, $sql, $params);
				if( $stmt === false ) {
					echo json_encode(array("responseCode"=>"0","responseMessage"=>"Update Failed!"));
				}
				else
				{
					echo json_encode(array("responseCode"=>"1","responseMessage"=> "Data Succesfuly Updated!"));
				}
			}else{
				die(print_r(sqlsrv_errors(), true));
			}
		}
	}
?>
<?php
	$obj = new myObject();
	$obj->myUpdate();
?>