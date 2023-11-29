<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayout.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BookMyVNRide_DBMS.Register" %>
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
    <h2>BookMyVNRide Application Form</h2>
    <div class="container">
        <div class="row">
            <div class="col-10">
                <label for="sname">Student Name:</label>
            </div>
            <div class="col-90">
                <asp:TextBox ID="txtname" runat="server" placeholder="Enter your name"></asp:TextBox>

            </div>
        </div>

        <div class="row">
            <div class="col-10">
                <label for="rollno">Roll Number:</label>
            </div>
            <div class="col-90">
                <asp:TextBox ID="txtroll" runat="server" placeholder="Enter your roll number"></asp:TextBox>

            </div>
        </div>
        <div class="row">
            <div class="col-10">
                <label for="branch">Branch:</label>
            </div>
            <div class="col-90">
                <asp:TextBox ID="txtbranch" runat="server" placeholder="Enter Branch"></asp:TextBox>

            </div>
        </div>
             <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            RouteNo:<asp:DropDownList ID="ddlroute" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlroute_SelectedIndexChanged">
                    </asp:DropDownList>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlroute" />
        </Triggers>
    </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Boarding Point:<asp:DropDownList ID="ddlboardingpt" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
                    </asp:DropDownList>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlboardingpt" />
        </Triggers>
    </asp:UpdatePanel>
        
        <div class="row">
            <div class="col-10">
                <label for="yearOfStd">Year of study:</label>
            </div>
            <div class="col-90">
                <asp:DropDownList ID="ddlyear" runat="server">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                    <asp:ListItem Value="2" Text="2"></asp:ListItem>
                    <asp:ListItem Value="3" Text="3"></asp:ListItem>
                    <asp:ListItem Value="4" Text="4"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-10">
                <label for="phone">Phone Number:</label>
            </div>
            <div class="col-90">
                <asp:TextBox ID="txtmobile" runat="server" placeholder="Enter your mobile number"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <asp:Button ID="btnreg" runat="server" Text="Save Data" OnClick="btnreg_Click"/>
        </div>
    </div>
</asp:Content>
