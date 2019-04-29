function GetAllDocs() {
    $.ajax({
        method: "POST",
        url: "DocumentsWebPage.aspx/GetAllDocs",
        contentType: "application/json; charset=utf-8",
        success: function (responce) {
            document.getElementById('docs').innerHTML = responce.d;
        },
        error: (error) => {
            alert(JSON.stringify(error));
        }
    });
}
function GetBillDocs() {
    $.ajax({
        method: "POST",
        url: "DocumentsWebPage.aspx/GetBills",
        contentType: "application/json; charset=utf-8",
        success: function (responce) {
            document.getElementById('docs').innerHTML = responce.d;
        },
        error: (error) => {
            alert(JSON.stringify(error));
        }
    });
}
function GetRecieptDocs() {
    $.ajax({
        method: "POST",
        url: "DocumentsWebPage.aspx/GetReciepts",
        contentType: "application/json; charset=utf-8",
        success: function (responce) {
            document.getElementById('docs').innerHTML = responce.d;
        },
        error: (error) => {
            alert(JSON.stringify(error));
        }
    });
}
function GetInvoiceDocs() {
    $.ajax({
        method: "POST",
        url: "DocumentsWebPage.aspx/GetInvoices",
        contentType: "application/json; charset=utf-8",
        success: function (responce) {
            document.getElementById('docs').innerHTML = responce.d;
        },
        error: (error) => {
            alert(JSON.stringify(error));
        }
    });
}
function GetSpecialDoc() {
    var id = document.getElementById("requestedDocId").value;
    var requestData = { docId: id };
    $.ajax({
        method: "POST",
        url: "DocumentsWebPage.aspx/GetSpecialDoc",
        data: JSON.stringify(requestData),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (responce) {
            document.getElementById('docs').innerHTML = responce.d;
        },
        error: (error) => {
            alert(JSON.stringify(error));
        }
    });
}
function GetCurrentDoc(id, type) {
    var requestData = { docId: id, docType: type };
    $.ajax({
        method: "POST",
        url: "DocumentsWebPage.aspx/GetSelectedDocument",
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
                document.getElementById('resultedDocument').className = 'resultContainer col-7 shadow rounded border border-info';
                document.getElementById('goodsSumSpan').className = ' badge badge-info';
            }
        },
        error: (error) => {
            alert(JSON.stringify(error));
        }
    });
}