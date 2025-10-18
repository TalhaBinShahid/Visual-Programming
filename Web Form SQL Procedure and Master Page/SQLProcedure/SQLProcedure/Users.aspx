<%@ Page Title="" Language="C#" MasterPageFile="~/BootStrap.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="SQLProcedure.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHTitle" runat="server">
    User Management
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
    <div class="container">
        <form id="form1" runat="server" class="w-75 mx-auto pt-3">
            <h1 class="m-3 text-center display-3">User Details</h1>
            <!-- Search Section -->
            <div class="mb-3">
                <asp:Label ID="Labid" runat="server" Text="Select User:" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="DDLUsers" runat="server" CssClass="form-select"></asp:DropDownList>
                <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" CssClass="btn btn-primary mt-2" />
            </div>

            <!-- User Details -->
            <div class="mb-3">
                <asp:Label ID="LabName" runat="server" Text="Name:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="LabEmail" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="LabAddress" runat="server" Text="Address:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TxtAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Buttons -->
            <div class="mb-3">
                <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" CssClass="btn btn-success me-2" />
                <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" CssClass="btn btn-warning text-white me-2" />
                <asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click" CssClass="btn btn-danger me-2" />
                <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click" CssClass="btn btn-info text-white" />
            </div>

            <!-- Result Label -->
            <div class="mb-3">
                <asp:Label ID="LabResult" runat="server" CssClass="form-label" Text=""></asp:Label>
            </div>

            <!-- GridView -->
            <div class="mb-3">
                <asp:GridView ID="GVUsers" runat="server" CssClass="table table-bordered table-striped text-center"></asp:GridView>
            </div>
        </form>
    </div>
</asp:Content>
