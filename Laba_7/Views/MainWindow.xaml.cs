using System;
using System.Activities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Laba_7.Controls;
using OP_ClassLib;

namespace Laba_7.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SideWorker.ServicesSwitcher serviceToUse = SideWorker.ServicesSwitcher.client;
        SideWorker.GetDocsSwitcher getDocsType = SideWorker.GetDocsSwitcher.special;
        public static MyAsmxService.DocumentsWebService asmxService;
        public static MyWcfService.DocumentsWebServiceWcfClient wcfClient;
        ObservableCollection<Document> docCollection = new ObservableCollection<Document>();
        string filePath = @"..\..\DataStore\LocalDocumentsStore.xml";
        string docToGet;
        public static FileInfo info;

        public MainWindow()
        {
            InitializeComponent();
            dataGridDocumentsList.ItemsSource = docCollection;
            info = new FileInfo(filePath);

            asmxService = new MyAsmxService.DocumentsWebService();
            wcfClient = new MyWcfService.DocumentsWebServiceWcfClient();
            wcfClient.Open();

            asmxService.GetAllDocumentsCompleted += AsmxService_GetAllDocumentsCompleted;
            asmxService.GetSpecialDocumentsCompleted += AsmxService_GetSpecialDocumentsCompleted;
            asmxService.GetSpecialDocumentCompleted += AsmxService_GetSpecialDocumentCompleted;
        }

        private void ButtonDocAdd_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedDoc = comboBoxDocTypeToAdd.SelectedItem as ComboBoxItem;
            if (selectedDoc.Content is "Квитанция")
            {
                RecieptWindow RecConst = new RecieptWindow();
                RecConst.docList = docCollection;
                RecConst.serviceToUse = serviceToUse;
                RecConst.mainWinGrid = dataGridDocumentsList;
                RecConst.Show();
            }
            else if (selectedDoc.Content is "Счет")
            {
                BillWindow BillConst = new BillWindow();
                BillConst.docList = docCollection;
                BillConst.serviceToUse = serviceToUse;
                BillConst.mainWinGrid = dataGridDocumentsList;
                BillConst.Show();
            }
            else if (selectedDoc.Content is "Накладная")
            {
                InvoiceWindow InvConst = new InvoiceWindow();
                InvConst.docList = docCollection;
                InvConst.serviceToUse = serviceToUse;
                InvConst.mainWinGrid = dataGridDocumentsList;
                InvConst.Show();
            }
        }

        private async void ButtonRefreshDataGrid_Click(object sender, RoutedEventArgs e)
        {
            if (serviceToUse == SideWorker.ServicesSwitcher.asmx)
            {
                if (getDocsType == SideWorker.GetDocsSwitcher.all)
                {
                    asmxService.GetAllDocumentsAsync();
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.invoices)
                {
                    asmxService.GetSpecialDocumentsAsync("Invoice");
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.reciepts)
                {
                    asmxService.GetSpecialDocumentsAsync("Reciept");
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.bills)
                {
                    asmxService.GetSpecialDocumentsAsync("Bill");
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.special)
                {
                    asmxService.GetSpecialDocumentAsync(docToGet);
                }
            }
            else if (serviceToUse == SideWorker.ServicesSwitcher.wcf)
            {
                if (getDocsType == SideWorker.GetDocsSwitcher.all)
                {
                    var res = await wcfClient.GetAllDocumentsAsync();
                    await WcfService_GetAllDocumentsCompleted(res.Body);
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.invoices)
                {
                    var res = await wcfClient.GetSpecialDocumentsAsync("Invoice");
                    await WcfService_GetSpecialDocumentsCompleted(res.Body);
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.reciepts)
                {
                    var res = await wcfClient.GetSpecialDocumentsAsync("Reciept");
                    await WcfService_GetSpecialDocumentsCompleted(res.Body);
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.bills)
                {
                    var res = await wcfClient.GetSpecialDocumentsAsync("Bill");
                    await WcfService_GetSpecialDocumentsCompleted(res.Body);
                }
                else if (getDocsType == SideWorker.GetDocsSwitcher.special)
                {
                    var res = await wcfClient.GetSpecialDocumentAsync(docToGet);
                    await WcfService_GetSpecialDocumentCompleted(res.Body);
                }
            }
            else if (serviceToUse == SideWorker.ServicesSwitcher.client)
            {
                var newList = await SideWorker.DeserializeActivity(info.FullName);
                foreach (var d in newList)
                    docCollection.Add(d);
            }
        }

        private async void ButtonRefreshFile_Click(object sender, RoutedEventArgs e)
        {
            await SideWorker.SerializeActivity(docCollection.ToList(), info.FullName);
        }

        private void TextServiceUri_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(((TextBox)sender).Text))
                asmxService.Url = ((TextBox)sender).Text;
        }

        private void TextBoxDocSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchData(((TextBox)sender).Text);
            docToGet = ((TextBox)sender).Text;
        }

        private void DataGridDocumentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBlockDocPrint.Text = (((DataGrid)sender).SelectedItem as Document)?.Print();
        }
        // поиск(фильтрация таблицы)
        private void SearchData(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                dataGridDocumentsList.ItemsSource = docCollection;
            else
            {
                var tmpSource = new BindingList<Document>(new BindingList<Document>(docCollection.Where(m => m.DocId.ToLower().Contains(value.ToLower())).ToList()));
                dataGridDocumentsList.ItemsSource = tmpSource;
            }
        }

        #region Обработка асинхронного получения данных из базы через сервисы
        private void AsmxService_GetSpecialDocumentCompleted(object sender, MyAsmxService.GetSpecialDocumentCompletedEventArgs e)
        {
            if (e.Result is null)
                return;
            var newList = e.Result.Select(SideWorker.CastToClientDocuments).ToList();
            foreach (var d in newList)
                docCollection.Add(d);
            SearchData(docToGet);
        }
        private void AsmxService_GetSpecialDocumentsCompleted(object sender, MyAsmxService.GetSpecialDocumentsCompletedEventArgs e)
        {
            if (e.Result is null)
                return;
            var newList = e.Result.Select(SideWorker.CastToClientDocuments).ToList();
            foreach (var d in newList)
                docCollection.Add(d);
        }
        private void AsmxService_GetAllDocumentsCompleted(object sender, MyAsmxService.GetAllDocumentsCompletedEventArgs e)
        {
            if (e.Result is null)
                return;
            var newList = e.Result.Select(SideWorker.CastToClientDocuments).ToList();
            foreach (var d in newList)
                docCollection.Add(d);
        }
        //=====================================================================================================================//
        private async Task WcfService_GetSpecialDocumentsCompleted(MyWcfService.GetSpecialDocumentsResponseBody responce)
        {
            List<Document> newList = await Task.Run(() =>
            {
                var res = responce.GetSpecialDocumentsResult.Select(SideWorker.CastToClientDocuments).ToList();
                return res;
            });
            foreach (var d in newList)
                docCollection.Add(d);
            SearchData(docToGet);
        }
        private async Task WcfService_GetSpecialDocumentCompleted(MyWcfService.GetSpecialDocumentResponseBody responce)
        {
            List<Document> newList = await Task.Run(() =>
            {
                var res = responce.GetSpecialDocumentResult.Select(SideWorker.CastToClientDocuments).ToList();
                return res;
            });
            foreach (var d in newList)
                docCollection.Add(d);
            SearchData(docToGet);
        }
        private async Task WcfService_GetAllDocumentsCompleted(MyWcfService.GetAllDocumentsResponseBody responce)
        {
            List<Document> newList = await Task.Run(() =>
            {
                var res = responce.GetAllDocumentsResult.Select(SideWorker.CastToClientDocuments).ToList();
                return res;
            });
            foreach (var d in newList)
                docCollection.Add(d);
            SearchData(docToGet);
        }
        #endregion

        #region события радио-кнопок (переключение между сервисами и тд.)
        private void RbAsmx_Checked(object sender, RoutedEventArgs e)
        {
            serviceToUse = SideWorker.ServicesSwitcher.asmx;

            panelDocsToLoad.Visibility = Visibility.Visible;
            textBoxServiceUrl.Visibility = Visibility.Visible;
            buttonRefreshFile.Visibility = Visibility.Hidden;
        }
        private void RbWcf_Checked(object sender, RoutedEventArgs e)
        {
            serviceToUse = SideWorker.ServicesSwitcher.wcf;

            panelDocsToLoad.Visibility = Visibility.Visible;
            textBoxServiceUrl.Visibility = Visibility.Visible;
            buttonRefreshFile.Visibility = Visibility.Hidden;
        }
        private void RbClient_Checked(object sender, RoutedEventArgs e)
        {
            serviceToUse = SideWorker.ServicesSwitcher.client;
            if(panelDocsToLoad != null)
            {
                panelDocsToLoad.Visibility = Visibility.Hidden;

                textBoxServiceUrl.Visibility = Visibility.Hidden;

                buttonRefreshFile.Visibility = Visibility.Visible;
            }            
        }
        private void RbAllDocs_Checked(object sender, RoutedEventArgs e)
        {
            getDocsType = SideWorker.GetDocsSwitcher.all;
        }
        private void RbInvoices_Checked(object sender, RoutedEventArgs e)
        {
            getDocsType = SideWorker.GetDocsSwitcher.invoices;
        }
        private void RbReciebts_Checked(object sender, RoutedEventArgs e)
        {
            getDocsType = SideWorker.GetDocsSwitcher.reciepts;
        }
        private void RbBills_Checked(object sender, RoutedEventArgs e)
        {
            getDocsType = SideWorker.GetDocsSwitcher.bills;
        }
        private void RbById_Checked(object sender, RoutedEventArgs e)
        {
            getDocsType = SideWorker.GetDocsSwitcher.special;
        }
        #endregion

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Document currentDoc = ((DataGridRow)sender).DataContext as Document;

            if (currentDoc != null)
            {
                if (currentDoc is Reciept)
                {
                    RecieptWindow RecConst = new RecieptWindow();
                    RecConst.reciept = (Reciept)currentDoc;
                    RecConst.docList = docCollection;
                    RecConst.toEdit = true;
                    RecConst.serviceToUse = serviceToUse;
                    RecConst.mainWinGrid = dataGridDocumentsList;
                    RecConst.Show();
                }
                else if (currentDoc is Bill)
                {
                    BillWindow BillConst = new BillWindow();
                    BillConst.bill = (Bill)currentDoc;
                    BillConst.docList = docCollection;
                    BillConst.toEdit = true;
                    BillConst.serviceToUse = serviceToUse;
                    BillConst.mainWinGrid = dataGridDocumentsList;
                    BillConst.Show();
                }
                else if (currentDoc is Invoice)
                {
                    InvoiceWindow InvConst = new InvoiceWindow();
                    InvConst.invoice = (Invoice)currentDoc;
                    InvConst.docList = docCollection;
                    InvConst.toEdit = true;
                    InvConst.serviceToUse = serviceToUse;
                    InvConst.mainWinGrid = dataGridDocumentsList;
                    InvConst.Show();
                }
            }
        }
    }
}
