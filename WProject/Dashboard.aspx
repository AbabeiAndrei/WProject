<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WProject.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    
        <br />
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" Width="55px" />
    
    </div>
    </form>
</body>
</html>
