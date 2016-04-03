<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WProject.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WProjects - Login</title>
    <link rel="stylesheet" type="text/css" href="Css/mainStyle.css">
    <link rel="stylesheet" type="text/css" href="Css/loginStyle.css">
    <link rel="stylesheet" type="text/css" href="Css/animationStyle.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="Scripts/loginScripts.js"></script>
    <script src="Scripts/utilScripts.js"></script>
    <script>
        ExecuteLogin = function () {
            var mjd;
            var methdToCall;
            if (onPasswordLost) {
                mjd = '{email: "' + $('#<%=txtEmail.ClientID%>')[0].value + '"}';
                methdToCall = "PasswordLost";
            } else {
                mjd = '{email: "' + $('#<%=txtEmail.ClientID%>')[0].value + '",' +
                    'pass:"' + $('#<%=txtPass.ClientID%>')[0].value + '"}';
                methdToCall = "ExecuteLogin";
            }
            sendAjax("Login.aspx", methdToCall, mjd,
                function(response) {
                    var majaxmres = JSON.parse(response.d);
                    if (!majaxmres.Success)
                        showNotificationBar(majaxmres.Error, majaxmres.TimeError);
                    functionSetRotationCircleDash(false);
                    if (majaxmres.Success)
                        document.forms[0].submit();
                }, function(response) {

                    alert(response);
                    functionSetRotationCircleDash(false);
                });
        };
    </script>
</head>
<body class="loginBackground">
    <form runat="server">
        <div class="statusBar">
            <p class="alignleft">WProject&copy; 2015</p>
            <p class="alignright">WallBrakers&copy; 2015</p>
        </div>
        <br/>
        <div class="loginForm loginBorder">
            <div class="titleBar"></div>
            <img src="Resources/Logo.png" alt="WProject"/>
            <h2>Email</h2>
            <asp:TextBox ID="txtEmail" runat="server" Width="94%" CssClass="txtBoxes" BorderColor="#575757" BorderStyle="Solid" BorderWidth="1px" CausesValidation="True"></asp:TextBox>
            <h2 id="lblPass">Password</h2>
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="94%" CssClass="txtBoxes" BorderColor="#575757" BorderStyle="Solid" BorderWidth="1px" CausesValidation="True"></asp:TextBox>
            <div class="login cursorHand" id="loginContainerButton">
                <img src="Resources/Icons/circle.png" id="circleLogin" class="loginLoginControlTransparent" alt="Login"/>
                <img src="Resources/Icons/arrow_left_l.png" id="arrowLogin" class="loginLoginControlTransparent" alt="Login"/>
            </div>
            <div class="helpLinks">
                <a id="passwordLostLabel" href="#">Password lost</a>
                <br/>
                <a id="helpLabel" href="#">Help</a>
            </div>
        </div>
    </form>
</body>
</html>
