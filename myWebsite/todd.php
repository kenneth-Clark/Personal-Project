<!DOCTYPE html>
<html>
<head>
<link rel="stylesheet" href="myCss.css">
<meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body onload = "loadThisShit()">
<div id="id01" class="modal">
  
  <form class="modal-content animate" action="mainPage.php" method="post">


    <div class="container">
      <label for="uname"><b>Username</b></label>
      <input type="text" placeholder="Enter Username" name="uname" required>
      <label for="psw"><b>Password</b></label>
      <input type="password" placeholder="Enter Password" name="psw" required>
			<button type="submit">LOGIN</button>
    </div>

  </form>
</div>

<script>
// Get the modal
var modal = document.getElementById('id01');
function loadThisShit()
{
	document.getElementById('id01').style.display='block';
}
// When the user clicks anywhere outside of the modal, close it

window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "block";
    }
}
</script>

</body>
</html>
