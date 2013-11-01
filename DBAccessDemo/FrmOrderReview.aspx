<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmOrderReview.aspx.cs" Inherits="FrmOrderReview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
       <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Style="z-index: 100;
          left: 11px; position: absolute; top: 58px" Text="Confirm Order" CausesValidation="False" Width="114px" />
       <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Style="z-index: 102;
          left: 155px; position: absolute; top: 58px" Text="Cancel" Width="68px" />
    
        <br />
    <asp:Label ID="lblOutOfStock" runat="server"></asp:Label>
    
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    </form>
</body>
</html>
