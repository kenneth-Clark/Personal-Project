<!DOCTYPE html>
<html>
<head>
<meta name="viewport" content="width=device-width, initial-scale=1">
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<style>
	/*
	
	*/
	#location {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#location td, #location th {
  border: 1px solid #ddd;
  padding: 8px;
}

#location tr:nth-child(even){background-color: #f2f2f2;}

#location tr:hover {background-color: #ddd;}

#location th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #0489aa;
  color: white;
}


#location2 {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#location2 td, #location2 th {
  border: 1px solid #ddd;
  padding: 8px;
}

#location2 tr:nth-child(even){background-color: #f2f2f2;}

#location2 tr:hover {background-color: #ddd;}

#location2 th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #0489aa;
  color: white;
}

#addUser td, #addUser th {
  border: 1px solid #ddd;
  padding: 8px;
}

#addUser tr:nth-child(even){background-color: #f2f2f2;}

#addUser tr:hover {background-color: #ddd;}

#addUser th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #0489aa;
  color: white;
}
/* */
* {box-sizing: border-box}

/* Set height of body and the document to 100% */
body, html {
  height: 100%;
  margin: 0;
  font-family: Arial;
}

/* Style tab links */
.tablink {
  background-color: #555;
  color: white;
  float: left;
  border: none;
  outline: none;
  cursor: pointer;
  padding: 14px 16px;
  font-size: 17px;
  width: 25%;
}

.tablink:hover {
  background-color: #0489aa;
}

/* Style the tab content (and add height:100% for full page content) */
.tabcontent {
  color: black;
  display: none;
  padding: 100px 20px;
  height: 100%;
}
.scrollit {
    overflow:scroll;
    height:500px;
}
.tableFixHead {
        overflow-y: auto;
        height: 400px;
      }
      .tableFixHead thead th {
        position: sticky;
        top: 0;
      }
      table {
        border-collapse: collapse;
        width: 100%;
      }
      th,
      td {
        padding: 8px 16px;
        border: 1px solid #ccc;
      }
      th {
        background: #eee;
      }

#Home {background-color: white;}
#News {background-color: white;}
#Contact {background-color: white;}
#About {background-color: white;}
</style>
</head>
<body>
<button class="tablink" onclick="openPage2('Home2', this, 'black')"id="defaultOpen">VIEW ALL USER</button>
<button class="tablink" onclick="openPage('Home', this, 'black')" id="myBtn">SEARCH USER</button>
<button class="tablink" onclick="openPage('News', this, 'black')" id ="AddTab">ADD</button>
<button class="tablink" onclick="BackToHome()">HOME</button>
<div id="Home2" class="tabcontent">
	<div class="tableFixHead">
	<table id="location2" border='1'>
		<thead>
		<tr>
			<th>ID</th>
			<th>First Name</th>
			<th>Middle Name</th>
			<th>Last Name</th>
			<th>Age</th>
			<th>Contact Number</th>
			<th>Address</th>
		</tr>
	</thead>
		<tr>
		</tr>
	</table>
</div>
</div>

<div id="Home" class="tabcontent">
  <h3>SEARCH BY ID</h3>
  <input id ="myValue"></input><button onclick =SearchButton()>SEARCH</button>

  <table id="location" border='1'>
    <tr>
		 <th>ID</th>
         <th>First Name</th>
         <th>Middle Name</th>
		 <th>Last Name</th>
		 <th>Age</th>
		 <th>Contact Number</th>
		 <th>Address</th>
		 <th></th>
		 <th></th>
    </tr>
</table>
<button id = "btnSave"hidden onclick = SaveButton()>SAVE</button><button onclick = "cancelButton()"id = "btnCancel" hidden>CANCEL</button>

</div>

<div id="News" class="tabcontent">
  <h3>ADD USER INFORMATION</h3>
  <table id="addUser" border='1'>
    <tr>
         <th></th>
         <th></th>
		 <th></th>
		 <th></th>
         <th></th>
		 <th></th>
    </tr>
	<td><input id ='insertTxtName' placeholder = "First Name"></input></td>
	<td><input id ='insertTxtMName' placeholder = "Middle Name"></input></td>
	<td><input id ='insertTxtLName' placeholder = "Last Name"></input></td>
	<td><input id ='insertTxtAge' placeholder = "Age"></input></td>
	<td><input id ='insertTxtCNumber' placeholder = "Contact Number"></input></td>
	<td><input id ='insertTxtAddress' placeholder = "Address"></input></td>
</table>
<button onclick = InsertSaveButton() >SAVE</button><button onclick = InserCancelButton()>CANCEL</button>
</div>

<script>
function openPage(pageName,elmnt,color) {
  var i, tabcontent, tablinks;
  tabcontent = document.getElementsByClassName("tabcontent");
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }
  tablinks = document.getElementsByClassName("tablink");
  for (i = 0; i < tablinks.length; i++) {
    tablinks[i].style.backgroundColor = "";
  }
  document.getElementById(pageName).style.display = "block";
  elmnt.style.backgroundColor = color;
}
function openPage2(pageName,elmnt,color) {
  var i, tabcontent, tablinks;
  tabcontent = document.getElementsByClassName("tabcontent");
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }
  tablinks = document.getElementsByClassName("tablink");
  for (i = 0; i < tablinks.length; i++) {
    tablinks[i].style.backgroundColor = "";
  }
  document.getElementById(pageName).style.display = "block";
  elmnt.style.backgroundColor = color;
  LoginFunction();
}

// Get the element with id="defaultOpen" and click on it
document.getElementById("defaultOpen").click();
function updateButton()
{
	document.getElementById("updateBtn").disabled = true;
	document.getElementById("deleteBtn").disabled = true;
	document.getElementById("txtName").readOnly = false;
	document.getElementById("txtMName").readOnly = false;
	document.getElementById("txtLName").readOnly = false;
	document.getElementById("txtAge").readOnly = false;
	document.getElementById("txtCNumber").readOnly = false;
	document.getElementById("txtAddress").readOnly = false;
	$('#btnSave').show();
	$('#btnCancel').show();
}
function cancelButton()
{
	document.getElementById("updateBtn").disabled = false;
	document.getElementById("deleteBtn").disabled = false;
	document.getElementById("txtName").readOnly = true;
	document.getElementById("txtMName").readOnly = true;
	document.getElementById("txtLName").readOnly = true;
	document.getElementById("txtAge").readOnly = true;
	document.getElementById("txtCNumber").readOnly = true;
	document.getElementById("txtAddress").readOnly = true;
	$('#btnSave').hide();
	$('#btnCancel').hide();
    SearchButton();
}
 function LoginFunction()
{
	
	var username = sessionStorage.getItem('userName')
	var password = sessionStorage.getItem('userPassWord')
	

	$.ajax({
            url:"http://localhost:8080/myWebsite/myLoginCode.php",
            type: "POST",
            dataType: 'json',
			data: {uname:username,psw:password},
			cache: false,
            success:function(result)
			{
				var datas = jQuery.parseJSON(JSON.stringify(result));
				if($("#location2 td").length > 0)
				{
					$("#location2 td").remove();
				}
				if(datas.responsCode == "1")
				{	
					if(datas.accountType != "ADMIN")
					{
						document.getElementById("myBtn").disabled = true;
						document.getElementById("AddTab").disabled = true;		
						document.getElementById("myBtn").style.backgroundColor = "red";
						document.getElementById("AddTab").style.backgroundColor = "red";
					}
					ViewAllButton(); 
				}
				else
				{
					var r = alert('Login Failed!'); if (r == r) { window.location.href='http://localhost:8080/myWebsite/todd.php'; }
				}
            },
			error: function(data, errorThrown)
          {
              alert('request failed 2:'+errorThrown);
          }
        });
}

function ViewAllButton()
{
	var value = "1";
	$.ajax({
            url:"http://localhost:8080/myWebsite/myViewAllCode.php",
            type: "POST",    //request type,
            dataType: 'Json',
			data: {id:value},
			cache: false,
            success:function(result)
			{
				console.log(result);
				var datas = jQuery.parseJSON(JSON.stringify(result));
				if($("#location2 td").length > 0)
				{
					$("#location2 td").remove();
				}
				if(datas.responsCode == "1")
				{
					
					for (var i = 0; i < datas.resultfirstName.length; i++)
					{			
						$("#location2 tbody").append(
							"<tr id='viewAllTr'>"
								+"<td>"+datas.resultid[i]+"</td>"
								+"<td>"+datas.resultfirstName[i]+"</td>"
								+"<td>"+datas.resultmiddleName[i]+"</td>"
								+"<td>"+datas.resultlastName[i]+"</td>"
								+"<td>"+datas.resultage[i]+"</td>"
								+"<td>"+datas.resultContactNumber[i]+"</td>"
								+"<td>"+datas.resultaddress[i]+"</td>"
							+"</tr>" )

					}
				}
            },
			error: function(data, errorThrown)
          {
              alert('request failed 2:'+errorThrown + data);
          }
        });
}

function SearchButton()
{
	var value = $("#myValue").val();
	$.ajax({
            url:"http://localhost:8080/myWebsite/myPhpCodes.php",
            type: "post",    //request type,
            dataType: 'json',
			data: {id:value},
            success:function(result)
			{
				if(result.responsCode == "1")
				{
					$('#trID').remove();
					$("#location tbody").append(
					"<tr id='trID'>"
						+"<td><input id ='txtId' value ='"+result.id+"' readonly size='1'></td>"
						+"<td><input id ='txtName' value ='"+result.name+"' readonly></input></td>"
						+"<td><input id ='txtMName' value ='"+result.midName+"' readonly></input></td>"
						+"<td><input id ='txtLName' value ='"+result.lName+"' readonly></input></td>"
						+"<td><input id ='txtAge' value ='"+result.age+"' readonly size='4'></input></td>"
						+"<td><input id ='txtCNumber' value ='"+result.cNumber+"' readonly></input></td>"
						+"<td><input id ='txtAddress' value ='"+result.address+"' readonly></input></td>"
						+"<td><button onclick = updateButton() id ='updateBtn'>UPATE</button></td>"
						+"<td><button onclick = DeleteButton() id ='deleteBtn'>REMOVE</button></td>"
					+"</tr>" )
				}
				else
				{
					alert(result.responseMessage);
				}
            },
			error: function(data, errorThrown)
          {
              alert('request failed 3:'+errorThrown);
          }
        });
}
function SaveButton()
{
	var id = $("#txtId").val();
	var firstName = $("#txtName").val();
	var middleName = $("#txtMName").val()
	var lastName = $("#txtLName").val()
	var age = $("#txtAge").val()
	var contactNumber = $("#txtCNumber").val()
	var address = $("#txtAddress").val()
	$.ajax({
            url:"http://localhost:8080/myWebsite/myUpdateCode.php",
            type: "post",    //request type,
            dataType: 'json',
			data: {id:id, firstName:firstName, middleName:middleName, lastName:lastName, age:age, contactNumber:contactNumber, address:address},//{firstName:firstName, middleName:middleName},//, middleName:middleName, lastName:lastName, age:age, contactNumber:contactNumber, address:address},
            success:function(result){
					alert(result.responseMessage);
					$('#btnSave').hide();
					$('#btnCancel').hide();
					$('#trID').remove();
            },
			error: function(data, errorThrown)
          {
              alert('request failed 4:'+errorThrown);
          }
        });
}
function InsertSaveButton()
{
	var ifirstName = $("#insertTxtName").val();
	var imiddleName = $("#insertTxtMName").val()
	var ilastName = $("#insertTxtLName").val()
	var iage = $("#insertTxtAge").val()
	var icontactNumber = $("#insertTxtCNumber").val()
	var iaddress = $("#insertTxtAddress").val()
	$.ajax({
            url:"http://localhost:8080/myWebsite/myInsertCode.php",
            type: "post",    //request type,
            dataType: 'json',
			data: {ifirstName:ifirstName, imiddleName:imiddleName, ilastName:ilastName, iage:iage, icontactNumber:icontactNumber, iaddress:iaddress},//{firstName:firstName, middleName:middleName},//, middleName:middleName, lastName:lastName, age:age, contactNumber:contactNumber, address:address},
            success:function(result){
					alert(result.responseMessage);
			$("#insertTxtName").val("");
			$("#insertTxtMName").val("");
			$("#insertTxtLName").val("");
			$("#insertTxtAge").val("");
		    $("#insertTxtCNumber").val("");
			$("#insertTxtAddress").val("");
            },
			error: function(data, errorThrown)
          {
              alert('request failed 5:'+errorThrown);
          }
        });
}
function DeleteButton()
{
	var r = confirm("Are you sure you want to remove this Data?");
	if (r == true) {
		var id = $("#txtId").val();
		$.ajax({
				url:"http://localhost:8080/myWebsite/myDeleteCode.php",
				type: "post",    //request type,
				dataType: 'json',
				data: {id:id},
				success:function(result){
						$('#trID').remove();
						alert(result.responseMessage);
				},
				error: function(data, errorThrown)
			{
				alert('request failed 6:'+errorThrown);
			}
			});
	} 
	
}
function InserCancelButton()
{
			$("#insertTxtName").val("");
			$("#insertTxtMName").val("");
			$("#insertTxtLName").val("");
			$("#insertTxtAge").val("");
		    $("#insertTxtCNumber").val("");
			$("#insertTxtAddress").val("");
}
function BackToHome()
{
	location.replace("http://localhost:8080/myWebsite/todd.php");
}
</script>
   
</body>
</html> 
