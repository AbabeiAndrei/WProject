<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WProject.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <script>

    </script>
    <link rel="stylesheet" type="text/css" href="Css/dashboardStyle.css">
    <script src="Scripts/dashboardScripts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="container">
        <div class="springs">
            <a href="#" id="springCollapseIcon">
                <img src="Resources/Icons/collapse_s.png" alt="Collapse" class="collapseIcon"/>
            </a>
            <asp:TreeView ID="tvSprings" runat="server" ImageSet="Arrows" Width="237px" OnSelectedNodeChanged="tvSprings_SelectedNodeChanged">
                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                <NodeStyle Font-Names="Segoe-UI" Font-Size="14pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                <ParentNodeStyle Font-Bold="False" />
                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
            </asp:TreeView>
        </div>
        <div id="springsSeparator"></div>
        <div id="springsCollapsedSeparator">
            <a href="#"  id="springExpandIcon">
                <img src="Resources/Icons/expand_s.png" alt="Expand" class="expandIcon"/>
            </a>
            <div class="rotateNineteenDegree">
                <a href="#" style="text-decoration: none">
                    <asp:Label ID="lblSelectedSpring" runat="server" Text="SelectedSpring" CssClass="selectedSpring"></asp:Label>
                </a>
            </div>
        </div>
        
        <div class="backlogs">
            <div class="backlog-header">
                <div class="backlog-header-item"></div>
                <div class="backlog-header-item left_border">    
                    <span class="backlog-header-item-text">To do</span>
                </div>
                <div class="backlog-header-item left_border">    
                    <span class="backlog-header-item-text">In progress</span>
                </div>
                <div class="backlog-header-item left_border">    
                    <span class="backlog-header-item-text">Done</span>
                </div>
            </div>
            <div class="backlogs-container">
                <asp:PlaceHolder ID="phBacklogs" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div>

</asp:Content>
