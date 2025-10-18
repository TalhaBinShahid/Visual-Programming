<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="UserWebForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Management</title>
</head>
<body>
    <h1>Web Form</h1>
    <br />
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabID" runat="server" Text="Please Enter Id"></asp:Label>
            <asp:DropDownList ID="DDLUsers" runat="server" Height="16px" style="margin-left: 114px" Width="128px"></asp:DropDownList>
            <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" style="margin-left: 51px" />
            <br />
        </div>
        <div>
            <asp:Label ID="LabName" runat="server" Text="Please Enter Name"></asp:Label>
            <asp:TextBox ID="TxtName" runat="server" style="margin-left: 88px"></asp:TextBox>
            <br />
        </div>
        <div>
            <asp:Label ID="LabEmail" runat="server" Text="Please Enter Email"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server" style="margin-left: 90px"></asp:TextBox>
            <br />
        </div>
        <div>
            <asp:Label ID="LabAddress" runat="server" Text="Please Enter Address"></asp:Label>
            <asp:TextBox ID="TxtAddress" runat="server" style="margin-left: 72px"></asp:TextBox>
            <br />
        </div>
        <br />
        <div style="height: 96px">
            <br />
            <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" Height="49px" style="margin-left: 50px" Width="72px" />
            <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" Height="47px" style="margin-left: 52px" />
            <asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click" Height="46px" style="margin-left: 50px" />
            <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click" Height="44px" style="margin-left: 49px" />
            <br />
        </div>
        <div>
            <asp:Label ID="LabResult" runat="server"></asp:Label>
            <br />
            <br />
        </div>
        <div>
            <asp:GridView runat="server" ID="CRUDGrid" style="margin-left: 164px" Width="655px"></asp:GridView>
        </div>
    </form>
</body>
</html>