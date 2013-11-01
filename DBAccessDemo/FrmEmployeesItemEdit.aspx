<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmEmployeesItemEdit.aspx.cs" Inherits="FrmEmployeesItemEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <asp:Label ID="lblEmployeeID" runat="server" Style="z-index: 100; left: 15px; position: absolute;
          top: 93px; right: 786px;">EmployeeID</asp:Label>
           <asp:Label ID="lblLastName" runat="server" Style="z-index: 113; left: 15px; position: absolute;
          top: 131px">Last Name</asp:Label>
           <asp:Label ID="lblFirstName" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 168px">First Name</asp:Label>
           <asp:Label ID="lblTitle" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 206px; height: 18px; width: 110px;">Title</asp:Label>
           <asp:Label ID="TitleOfCourtesy" runat="server" Style="z-index: 104; left: 15px; position: absolute;
          top: 246px; width: 106px;">Title Of Courtesy</asp:Label>
          <asp:Label ID="lblBirthDate" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 289px">Birth Date</asp:Label>
           <asp:Label ID="lblHireDate" runat="server" Style="z-index: 106; left: 15px; position: absolute;
          top: 323px; height: 14px;">Hire Date</asp:Label>
          <asp:Label ID="lblAddress" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 354px">Address</asp:Label>
           <asp:Label ID="lblCity" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 387px">City</asp:Label>
          <asp:Label ID="lblRegion" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 421px">Region</asp:Label>
          <asp:Label ID="lblPostalCode" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 459px; right: 840px;">PostalCode</asp:Label>
           <asp:Label ID="lblCountry" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 492px">Country</asp:Label>
          <asp:Label ID="lblHomePhone" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 540px">Home Phone</asp:Label>
          <asp:Label ID="lblExtension" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 580px">Extension</asp:Label>
          <asp:Label ID="lblPhoto" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 620px">Photo</asp:Label>
          <asp:Label ID="lblNotes" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 660px">Notes</asp:Label>
          <asp:Label ID="lblReportsTo" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 700px">Reports To</asp:Label>


          <asp:TextBox ID="txtEmployeeID" runat="server" Enabled="False" Style="z-index: 114; left: 137px;
          position: absolute; top: 91px" Width="320px" MaxLength="5" ></asp:TextBox>
           <asp:TextBox ID="txtLastName" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 128px" Width="320px" MaxLength="20"></asp:TextBox>
          <asp:TextBox ID="txtFirstName" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 165px" Width="320px" MaxLength="10"></asp:TextBox>               
          <asp:TextBox ID="txtTitle" runat="server"  Style="z-index: 114; left: 137px;
          position: absolute; top: 209px" Width="320px" MaxLength="30"></asp:TextBox>
          <asp:TextBox ID="txtTitleOfCourtesy" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 251px" Width="320px" MaxLength="25"></asp:TextBox>
          <asp:TextBox ID="txtBirthDate" runat="server"  Style="z-index: 114; left: 137px;
          position: absolute; top: 289px" Width="320px"></asp:TextBox>
          <asp:TextBox ID="txtHireDate" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 319px" Width="320px"></asp:TextBox>
          <asp:TextBox ID="txtAddress" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 350px" Width="320px" MaxLength="60"></asp:TextBox>
          <asp:TextBox ID="txtCity" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 383px; right: 416px;" Width="320px" MaxLength="15"></asp:TextBox>
          <asp:TextBox ID="txtRegion" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 418px" Width="320px" MaxLength="15"></asp:TextBox>
          <asp:TextBox ID="txtPostalCode" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 453px" Width="320px" MaxLength="10"></asp:TextBox>
          <asp:TextBox ID="txtCountry" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 489px" Width="320px" MaxLength="15"></asp:TextBox>
          <asp:TextBox ID="txtHomePhone" runat="server"  Style="z-index: 114; left: 137px;
          position: absolute; top: 534px" Width="320px" MaxLength="24"></asp:TextBox>
          <asp:TextBox ID="txtExtension" runat="server"  Style="z-index: 114; left: 137px;
          position: absolute; top: 575px" Width="320px" MaxLength="4"></asp:TextBox>
          <asp:TextBox ID="txtPhoto" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 619px" Width="320px" MaxLength="255"></asp:TextBox>
          <asp:TextBox ID="txtNotes" runat="server"  Style="z-index: 114; left: 137px;
          position: absolute; top: 657px" Width="320px"></asp:TextBox>
          <asp:TextBox ID="txtReportsTo" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 695px" Width="320px"></asp:TextBox>

       
          
       <asp:Label ID="lblEmployeesDetails" runat="server" Font-Size="Large" 
            Height="32px" Style="z-index: 115;
          left: 19px; position: absolute; top: 54px" Width="444px">Employees Details</asp:Label>


       <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Style="z-index: 101;
          left: 16px; position: absolute; top: 731px; margin-bottom: 15px;" Text="Return to maintenance page" 
            Width="200px" />
       <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Style="z-index: 101;
          left: 239px; position: absolute; top: 731px" Text="Update" Width="100px" 
           Visible="False" />
       <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Style="z-index: 101;
          left: 356px; position: absolute; top: 729px; right: 465px;" Text="Insert" Width="100px" 
           Visible="False" />
       <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Style="z-index: 101;
          left: 136px; position: absolute; top: 772px; right: 685px;" Text="Cancel" 
           Width="100px" Visible="False" />


       <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Style="z-index: 101;
          left: 356px; position: absolute; top: 769px" Text="Delete" 
        Width="100px" />


    </div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
       <asp:Button ID="btnReplace" runat="server" OnClick="btnReplace_Click" Style="z-index: 101;
          left: 18px; position: absolute; top: 771px; height: 26px;" Text="Replace" Width="100px" 
           Visible="False" />
       </p>
    </form>
</body>
</html>
