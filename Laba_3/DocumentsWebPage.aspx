<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentsWebPage.aspx.cs" Inherits="Laba_3.DocumentsWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Documents</title>
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/jquery.unobtrusive-ajax.js"></script>
    <script type="text/javascript">
        function GetCurrentDoc(id, type) {
            var requestData = { docId: id, docType: type };
            var result;
            $.ajax({
                method: "POST",
                url: "DocumentsWebPage.aspx/GetDocumentDataById",
                data: JSON.stringify(requestData),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (responce) {
                    document.getElementById('resultedDocument').innerHTML = responce.d;
                },
                error: (error) => {
                    alert(JSON.stringify(error));
                }
            });
        }
    </script>
</head>
<body>
    <h3>Документы</h3>
    <form id="form1" runat="server">
        <div id="main" class="mainContainer">
            <div id="docs" runat="server"></div>
        </div>
        <div id="resultedDocument" class="resultContainer"></div>
    </form>
</body>
</html>
