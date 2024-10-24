<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Workouts.aspx.cs" Inherits="FitnessTrackerWebApp.Workouts" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Workouts Management</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f0f4f8; /* Light background */
            margin: 0;
            padding: 20px;
            color: #818597; /* grayText */
        }
        .container {
            max-width: 800px;
            margin: 0 auto;
            background-color: #ffffff;
            padding: 30px;
            border-radius: 16px; /* Fully rounded corners */
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }
        h2 {
            color: #162f56; /* deepBlueHead */
            margin-bottom: 20px;
            text-align: center;
        }
        nav {
            margin-bottom: 20px;
            padding: 10px;
            background-color: #0b72e7; /* lightBlue500 */
            border-radius: 12px; /* Rounded corners for the nav */
            text-align: center;
        }
        .nav-link {
            color: white;
            margin: 0 15px;
            text-decoration: none;
            font-size: 16px;
            transition: color 0.3s;
        }
        .nav-link:hover {
            color: #61cea6; /* greenLight hover effect */
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
            color: #525a76; /* gray2 */
        }
        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #344a6c; /* grayBlue */
            border-radius: 12px; /* Rounded corners for input fields */
            box-sizing: border-box;
        }
        .btn-group {
            margin-top: 20px;
            text-align: center;
        }
        .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 12px; /* Rounded corners for buttons */
            cursor: pointer;
            font-size: 14px;
            margin: 0 5px;
            transition: background-color 0.3s, transform 0.2s;
        }
        .btn-primary {
            background-color: #2b84ea; /* lightBlue */
            color: white;
        }
        .btn-primary:hover {
            background-color: #4b94ed; /* lightBlue300 */
            transform: translateY(-3px); /* Subtle hover lift */
        }
        .btn-warning {
            background-color: #f39c12;
            color: white;
        }
        .btn-warning:hover {
            background-color: #d35400;
            transform: translateY(-3px);
        }
        .btn-danger {
            background-color: #e74c3c;
            color: white;
        }
        .btn-danger:hover {
            background-color: #c0392b;
            transform: translateY(-3px);
        }
        .grid-view {
            margin-top: 30px;
            width: 100%;
            border-collapse: collapse;
            border-radius: 12px; /* Rounded corners for grid */
            overflow: hidden;
        }
        .grid-view th {
            background-color: #0b72e7; /* lightBlue500 */
            color: white;
            padding: 12px;
            text-align: left;
        }
        .grid-view td {
            border: 1px solid #344a6c; /* grayBlue */
            padding: 12px;
        }
        .grid-view tr:nth-child(even) {
            background-color: #e2e2e2; /* lightGray */
        }
        .grid-view tr:hover {
            background-color: #e6e6e6;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <asp:HyperLink ID="lnkUsers" runat="server" NavigateUrl="~/Users.aspx" Text="Users" CssClass="nav-link"></asp:HyperLink> |
            <asp:HyperLink ID="lnkWorkouts" runat="server" NavigateUrl="~/Workouts.aspx" Text="Workouts" CssClass="nav-link"></asp:HyperLink> |
            <asp:HyperLink ID="lnkNutrition" runat="server" NavigateUrl="~/Nutrition.aspx" Text="Nutrition" CssClass="nav-link"></asp:HyperLink> |
            <asp:HyperLink ID="lnkProgress" runat="server" NavigateUrl="~/Progress.aspx" Text="Progress" CssClass="nav-link"></asp:HyperLink>
        </nav>

        <div class="container">
            <h2>Manage Workouts</h2>
            <div class="form-group">
                <asp:Label ID="lblId" runat="server" Text="ID (For Update/Delete)" />
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblUserId" runat="server" Text="User ID" />
                <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblWorkoutType" runat="server" Text="Workout Type" />
                <asp:TextBox ID="txtWorkoutType" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblDuration" runat="server" Text="Duration (in minutes)" />
                <asp:TextBox ID="txtDuration" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblCaloriesBurned" runat="server" Text="Calories Burned" />
                <asp:TextBox ID="txtCaloriesBurned" runat="server" CssClass="form-control" />
            </div>
            <div class="btn-group">
                <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-warning" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-danger" />
            </div>
            <asp:GridView ID="gvWorkouts" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="UserId" HeaderText="User ID" />
                    <asp:BoundField DataField="WorkoutType" HeaderText="Workout Type" />
                    <asp:BoundField DataField="Duration" HeaderText="Duration" />
                    <asp:BoundField DataField="CaloriesBurned" HeaderText="Calories Burned" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
