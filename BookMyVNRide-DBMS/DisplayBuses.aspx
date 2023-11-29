<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayout.Master" AutoEventWireup="true" CodeBehind="DisplayBuses.aspx.cs" Inherits="BookMyVNRide_DBMS.DisplayBuses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
    <h3>Buses Page</h3>
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
                  <th>
                      Route
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
                <td>
                    <asp:Button ID="viewRoute" runat="server" Text="View Route" OnClick="viewRoute_Click" CommandArgument='<%#Eval("bno") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
