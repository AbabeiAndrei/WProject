<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WProject.Dispatcher.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>WProject</title>
	<style>
		.container{

		}
		.item{
			display:block;
			padding:5px
		}
		.status {
			display: inline-block
		}
		div.status{
			width:16px;
			height:16px;
			margin-right:6px;
			border-radius: 50%;
			margin-top:16px
		}
		.green{
			background-color:green
		}
		.red{
			background-color:red
		}
		span.status{
			font: 32px 'Segoe UI', sans-serif
		}
	</style>
</head>
<body>
	<form id="form1" runat="server">
	<div class="container">
		<asp:Literal ID="lblServer" runat="server"></asp:Literal>
		<asp:Literal ID="lblMysql" runat="server"></asp:Literal>
		<asp:Literal ID="lblSignalR" runat="server"></asp:Literal>
	</div>
	</form>
</body>
</html>
