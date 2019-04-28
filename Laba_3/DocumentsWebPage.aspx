<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentsWebPage.aspx.cs" Inherits="Laba_3.DocumentsWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Documents</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
    <link rel="stylesheet" type="text/css"  href="Content/myCssStyle.css" />
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
                    if (type === "Счет") {
                        document.getElementById('resultedDocument').className = 'resultContainer col-7 shadow rounded border border-success';
                        document.getElementById('goodsSumSpan').className = 'badge badge-success';
                    }
                    else if (type === "Накладная") {
                        document.getElementById('resultedDocument').className = 'resultContainer col-7 shadow rounded border border-warning';
                        document.getElementById('goodsSumSpan').className = 'badge badge-warning';
                    }
                    else if (type === "Квитанция") {
                        document.getElementById('resultedDocument').className = 'resultContainer col-7 shadow rounded border border-danger';
                        document.getElementById('goodsSumSpan').className = 'badge badge-danger';
                    }
                },
                error: (error) => {
                    alert(JSON.stringify(error));
                }
            });
        }
    </script>
</head>
<body>
    <div class="container">
        <div class="header">
            <h3 >Документы</h3>
        </div>
        <form id="form1" runat="server">
            <div class="row justify-content-between">
                <table id="mainTable" class="col-4 table table-striped shadow rounded table-hover ">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Документ</th>
                            <th scope="col">ИНН документа</th>
                        </tr>
                    </thead>
                    <tbody id="docs" runat="server"></tbody>
                </table>
                <div id="resultedDocument" class="resultContainer col-7 shadow rounded border border-secondary"></div>
            </div>
        </form>
    </div>   
</body>
</html>
