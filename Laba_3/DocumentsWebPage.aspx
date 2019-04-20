<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentsWebPage.aspx.cs" Inherits="Laba_3.DocumentsWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Documents</title>
</head>
<body>
    <h3>Документы</h3>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewDocuments" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridViewDocuments_SelectedIndexChanged"  runat="server"></asp:GridView>
            <asp:Label ID="LabelDocPrint" runat="server" ></asp:Label>
        </div>
    </form>
</body>
</html>
