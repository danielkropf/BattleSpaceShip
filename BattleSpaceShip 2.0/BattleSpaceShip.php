<?php
$servername = "mysql.hostinger.com.br";
$username = "u695866113_root";
$password = "Senha@88";
$dbname = "u695866113_rpgjv";
// Create connection
$conn = mysqli_connect($servername, $username, $password, $dbname);
// Check connection
if (!$conn) {
    die("Connection failed: " . mysqli_connect_error());
}
if($_POST["Service"] == "Save")
{
	$sql = "SELECT * FROM `BattleSpaceShip` WHERE `UserID`='" . $_POST["UserID"] . "'";
	$result = mysqli_query($conn, $sql);
	if (mysqli_num_rows($result) > 0) {
		//JA EXISTE USUARIO
		echo "TEM USUARIO";
	} else {
		//NAO EXISTE
		$sql = "INSERT INTO `Save` (`user`)
		VALUES ('" . $_POST["User"] . "')";
		if (mysqli_query($conn, $sql)) {
			echo "Record updated successfully";
		} else {
			echo "Error updating record: " . mysqli_error($conn);
		}
	}
	$sql = "UPDATE Save SET " .
	"`Senha`=" . $_POST["Senha"] . ", " .
	" WHERE `UserID`='" . $_POST["UserID"] . "'";
	echo "  " . $sql . "  ";
	if (mysqli_query($conn, $sql)) {
		echo "Record updated successfully";
	} else {
		echo "Error updating record: " . mysqli_error($conn);
	}
}
else if($_POST["Service"] == "Load")
{
	$sql = "SELECT * FROM `BattleSpaceShip` WHERE `UserID`='" . $_POST["UserID"] . "'";
	$result = mysqli_query($conn, $sql);
	if (mysqli_num_rows($result) > 0) {
		while($row = mysqli_fetch_assoc($result)) {
			echo "Senha=" . $row["Senha"]. ";";
		}
	} else {
		echo "error";
	}
}
mysqli_close($conn);
?>