<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WProject.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WProjects</title>
    <link rel="stylesheet" type="text/css" href="Css/mainStyle.css">
    <link rel="stylesheet" type="text/css" href="Css/loginStyle.css">
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
            <asp:TextBox ID="txtEmail" runat="server" Width="90%" CssClass="txtBoxes"></asp:TextBox>
            <h2>Password</h2>
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="90%" CssClass="txtBoxes"></asp:TextBox>
            <div class="login">
                <img src="Resources/Icons/circle.png" id="circleLogin" alt="Login"/>
                <img src="Resources/Icons/arrow_left_l.png" id="arrowLogin" alt="Login"/>
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
