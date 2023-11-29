<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="AddRoute.aspx.cs" Inherits="BookMyVNRide_DBMS.AddRoute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add Route</h1>
        <div>
            <label>Bus Route Number:</label>
            <asp:TextBox ID="busRouteNoTextBox" runat="server" CssClass="route-input"></asp:TextBox>
            <br />
            <label>Routes (comma-separated):</label>
            <asp:TextBox ID="routesTextBox" runat="server" TextMode="MultiLine" Rows="5" CssClass="route-input"></asp:TextBox>
            <br />
            <asp:Button ID="submitRoutesButton" runat="server" Text="Submit Routes" OnClick="submitRoutesButton_Click" />
        </div>
</asp:Content>
