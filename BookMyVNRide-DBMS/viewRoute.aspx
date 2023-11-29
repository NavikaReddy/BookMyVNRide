<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayout.Master" AutoEventWireup="true" CodeBehind="viewRoute.aspx.cs" Inherits="BookMyVNRide_DBMS.viewRoute" %>
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

    <asp:Repeater ID="rep" runat="server">
        <HeaderTemplate>
          <table id="buses">
              <tr>
                  <th>
                      Boarding Point
                  </th>
                  <th>
                      Register
                  </th>
              </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("stopName") %>
                </td>
                <td>
                    <asp:Button ID="register" runat="server" Text="Book Bus" OnClick="register_Click" CommandArgument='<%#Eval("bptid") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
