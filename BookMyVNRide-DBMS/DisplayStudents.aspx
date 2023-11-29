<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="DisplayStudents.aspx.cs" Inherits="BookMyVNRide_DBMS.DisplayStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
#students {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#students td, #students th {
  border: 1px solid #ddd;
  padding: 8px;
}

#students tr:nth-child(even){background-color: #f2f2f2;}

#students tr:hover {background-color: #ddd;}

#students th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #1c608c;
  color: white;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Students Page</h3>
    <asp:Button ID="del" runat="server" OnClick="del_Click"  Text="Delete previous year passes"/>
    <asp:Repeater ID="rep" runat="server">
        <HeaderTemplate>
          <table id="students">
              <tr>
                  <th>
                      Sno
                  </th>
                  <th>
                      Student Name
                  </th>
                  <th>
                      Student RollNo
                  </th>
                  <th>
                      Branch
                  </th>
                  <th>
                      Bus Route No
                  </th>
                  <th>
                     Year
                  </th>
                <th>
                      Boarding Point
                  </th>
                  <th>
                      Contact Number
                  </th>
              </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("sno") %>
                </td>
                 <td>
                    <%#Eval("sname") %>
                </td>
                 <td>
                    <%#Eval("rollno") %>
                </td>
                 <td>
                    <%#Eval("branch") %>
                </td>
                 <td>
                    <%#Eval("bno") %>
                </td>
                 <td>
                    <%#Eval("yearOfStd") %>
                </td>
               <td>
                    <%#Eval("boardingPoint") %>
                </td>
                <td>
                    <%#Eval("phone") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
