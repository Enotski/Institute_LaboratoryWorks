<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentsWebPage.aspx.cs" Inherits="Laba_3.DocumentsWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Documents</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
    <link rel="stylesheet" type="text/css"  href="Content/myCssStyle.css" />
    <style>
        .main {
            margin-bottom: 30px !important;
        }
        .resultContainer{
            padding:12px 12px;
        }
    </style>
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/jquery.unobtrusive-ajax.js"></script>
    <script src="Scripts/myScripts.js"></script>
</head>
<body>
    <div class="container main">
        <div class="header">
            <h3 >Документы</h3>
        </div>
        <form id="form1" runat="server">
            <div class="row justify-content-between">
                <div class="col-4">
                    <nav class="navbar navbar-light bg-light">
                        <div>
                            <input type="button" class="btn btn-outline-dark my-md-2 mr-4" onclick="GetAllDocs()" value ="Все"/>
                            <input type="button" class="btn btn-outline-success my-md-2 mr-4" onclick="GetBillDocs()" value ="С"/>
                            <input type="button" class="btn btn-outline-warning my-md-2 mr-4" onclick="GetInvoiceDocs()" value ="Н"/>
                            <input type="button" class="btn btn-outline-info my-md-2" onclick="GetRecieptDocs()" value ="К"/>
                            <div class="d-flex flex-row justify-content-between">
                                <input type="button" class="btn btn-outline-primary my-md-2 mr-3" onclick="GetSpecialDoc()" value="Найти"/>
                                <input  id="requestedDocId" class="form-control my-sm-2" type="search" placeholder="Search" aria-label="Search" />
                            </div>
                        </div>
                    </nav>
                    <table id="mainTable" class=" table table-striped shadow rounded table-hover docTable">
                        <thead class="thead-dark">
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Документ</th>
                                <th scope="col">ИНН документа</th>
                            </tr>
                        </thead>    
                        <tbody id="docs" class="tableContent" runat="server"></tbody>
                    </table>
                </div>
                <div id="resultedDocument" class="resultContainer col-7 shadow rounded border border-secondary"></div>
            </div>
        </form>
    </div>   
</body>
</html>
