<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="AddBus.aspx.cs" Inherits="BookMyVNRide_DBMS.AddBus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        * {
            box-sizing: border-box;
        }

        input[type=text], input[type=email], input[type=number], input[type=select], input[type=date], input[type=select], input[type=password], input[type=tel] {
            width: 45%;
            padding: 12px;
            border: 1px solid rgb(168, 166, 166);
            border-radius: 4px;
            resize: vertical;
        }

        textarea {
            width: 45%;
            padding: 12px;
            border: 1px solid rgb(168, 166, 166);
            border-radius: 4px;
            resize: vertical;
        }

        input[type=radio], input[type=checkbox] {
            width: 1%;
            padding-left: 0%;
            border-radius: 4px;
            resize: vertical;
        }

        h1 {
            font-family: Arial;
            font-size: medium;
            font-style: normal;
            font-weight: bold;
            color: brown;
            text-align: center;
            text-decoration: underline;
        }

        label {
            padding: 12px 12px 12px 0;
            display: inline-block;
        }

        input[type=submit] {
            background-color: #4CAF50;
            color: white;
            padding: 12px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            float: left;
        }

            input[type=submit]:hover {
                background-color: #32a336;
            }

        .container {
            border-radius: 5px;
            background-color: #f2f2f2;
            padding: 20px;
        }

        .col-10 {
            float: left;
            width: 10%;
            margin-top: 6px;
        }

        .col-90 {
            float: left;
            width: 90%;
            margin-top: 6px;
        }

        .row:after {
            content: "";
            display: table;
            clear: both;
        }

        @media screen and (max-width: 600px) {
            .col-10, .col-90, input[type=submit] {
                width: 100%;
                margin-top: 0;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add new bus Form</h2>
    <div class="container">
        <div class="row">
            <div class="col-10">
                <label for="bno">Bus Number:</label>
            </div>
            <div class="col-90">
                <asp:TextBox ID="txtnum" runat="server" placeholder="Enter busno"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-10">
                <label for="busRoute">Route Name:</label>
            </div>
            <div class="col-90">
                <asp:TextBox ID="txtbusname" runat="server" placeholder="Enter Route Name"></asp:TextBox>

            </div>
        </div>
        <div class="row">
            <div class="col-10">
                <label for="fare">Enter bus fare:</label>
            </div>
            <div class="col-90">
                <asp:TextBox ID="txtfare" runat="server" placeholder="Enter fare"></asp:TextBox>

            </div>
        </div> 
        <div class="row">
            <div class="col-10">
                <label for="stime">Enter start time:</label>
            </div>
            <div class="col-90">
                <asp:TextBox ID="stime" runat="server" placeholder="Enter start time"></asp:TextBox>
            </div>
        </div> 
        <div class="row">
            <div class="col-10">
                <label for="atime">Enter arrival time:</label>
            </div>
            <div class="col-90">
                <asp:TextBox ID="atime" runat="server" placeholder="Enter arrival time"></asp:TextBox>
            </div>
        </div> 

        <div class="row">
            <div class="col-10">
                <label for="phone">Enter Driver contact number:</label>
            </div>
            <div class="col-90">
                <asp:TextBox ID="txtmobile" runat="server" placeholder="Enter driver mobile number"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <asp:Button ID="btnreg" runat="server" Text="Save Data" OnClick="btnreg_Click"/>
        </div>
    </div>

</asp:Content>
