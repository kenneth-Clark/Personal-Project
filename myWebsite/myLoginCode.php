<?php
	class myObject
	{
		public function myLoginFunction()
		{
			$conn_array = array (
				"UID" => "sa",
				"PWD" => "Admin123!",
				"Database" => "localb",
			);
			$conn = sqlsrv_connect('DESKTOP-RJQPENS\MY_NEW_SQLSERVER', $conn_array);
			if ($conn){
				$params = array($_POST["uname"],$_POST["psw"]);
				if(($result = sqlsrv_query($conn,"SELECT accountType from myAccountTable Where accountName =? and accountPassword =?", $params)) != false){
					$row_count = sqlsrv_has_rows($result);
					if( $row_count  == false)
					{
						echo json_encode(array("responsCode"=> "0","responseMessage"=> "No Data Found!"));
					}
					else
					{
						$data = array();
						$accountType = array();
		
						while( $obj = sqlsrv_fetch_object( $result )) {
							 $accountType[]	=  array($obj->accountType);
						}
						$data['accountType'] = $accountType;
						$data['responsCode'] = "1";
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
	$obj->myLoginFunction();
?>