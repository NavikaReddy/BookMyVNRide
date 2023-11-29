<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayout.Master" AutoEventWireup="true" CodeBehind="SearchBuses.aspx.cs" Inherits="BookMyVNRide_DBMS.SearchBuses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
#buses {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#buses td, #buses th {
  border: 1px solid #ddd;
  padding: 8px;
}

#buses tr:nth-child(even){background-color: #f2f2f2;}

#buses tr:hover {background-color: #ddd;}

#buses th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #901d26;
  color: white;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="col-10">
                <label for="fname">Select Boarding Point</label>
            </div>
            <div class="col-90">
              <asp:DropDownList ID="ddlstop" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
                    </asp:DropDownList>
            </div>
        <br />
        <br />
            <asp:Button ID="btnget" runat="server" Text="Get Details" OnClick="btnget_Click"/>
        </div>
    <br />
    <asp:Repeater ID="rep" runat="server">
        <HeaderTemplate>
          <table id="buses">
              <tr>
                  <th>
                      Route No
                  </th>
                  <th>
                      Route Name
                  </th>
                  <th>
                      Fare
                  </th>
                  <th>
                      Start Time
                  </th>
                  <th>
                      Arrival Time
                  </th>
                  <th>
                      Driver contact
                  </th>
              </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("bno") %>
                </td>
                 <td>
                    <%#Eval("busRoute") %>
                </td>
                 <td>
                    <%#Eval("fare") %>
                </td>
                 <td>
                    <%#Eval("startTime") %>
                </td>
                 <td>
                    <%#Eval("arrivalTime") %>
                </td>
                 <td>
                    <%#Eval("driverContact") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
