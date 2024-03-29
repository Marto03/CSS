using Microsoft.Win32;
using Prism.Commands;
using SqlToXSDSchema.XsdSchema;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SqlToXSDSchema
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string sqlQuery;
        private DelegateCommand saveCommand;
        private DelegateCommand convertCommand;
        private bool isExecuted;
        private DataTable queryResult;
        private string popupText;
        private bool isPopupOpen;
        private readonly XsdSchemaGenerator xsdSchemaGenerator;
        private string xsdSchema;

        public MainWindowViewModel()
        {
            xsdSchemaGenerator = new XsdSchemaGenerator();
            QueryResult = new DataTable();
            AutoGeneratingColumnCommand = new RelayCommand<DataGridAutoGeneratingColumnEventArgs>(AutoGeneratingColumn);
        }

        #region Properties
        public DataTable QueryResult
        {
            get
            {
                return queryResult;
            }
            set
            {
                if (queryResult != value)
                {
                    queryResult = value;
                    OnPropertyChanged(nameof(QueryResult));
                }
            }
        }

        public string SqlQuery
        {
            get 
            {
                return sqlQuery; 
            }
            set 
            {
                if(sqlQuery != value)
                {
                    sqlQuery = value;
                    OnPropertyChanged(nameof(SqlQuery));
                }
            }
        }
        public bool IsExecuted
        {
            get 
            { 
                return isExecuted; 
            }
            set
            {
                if(isExecuted != value)
                {
                    isExecuted = value;
                    OnPropertyChanged(nameof(IsExecuted));
                }
            }
        }
        public string PopupText
        {
            get
            {
                return popupText;
            }
            set
            {
                if(popupText != value)
                {
                    popupText = value;
                    OnPropertyChanged(nameof(PopupText));
                }
            }
        }
        public bool IsPopupOpen
        {
            get
            {
                return isPopupOpen;
            }
            set
            {
                if(isPopupOpen != value)
                {
                    isPopupOpen = value;
                    OnPropertyChanged(nameof(IsPopupOpen));
                }
            }
        }
        public string XsdSchema
        {
            get 
            { 
                return xsdSchema; 
            }
            set
            {
                if(xsdSchema != value)
                {
                    xsdSchema = value;
                    OnPropertyChanged(nameof(XsdSchema));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public RelayCommand<DataGridAutoGeneratingColumnEventArgs> AutoGeneratingColumnCommand { get; private set; }
        #endregion

        #region Commands
        public DelegateCommand ConvertCommand
        {
            get
            {
                if (convertCommand == null)
                    convertCommand = new DelegateCommand(async () => await ConvertCommandAction());
                return convertCommand;
            }
        }
        public DelegateCommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new DelegateCommand(async () => await SaveCommandAction());
                return saveCommand;
            }
        }
        #endregion

        #region Actions
        private async Task ConvertCommandAction()
        {
            string connectionString = "Server=localhost;Database=PubDatabase;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                {
                    try
                    {
                        using (SqlDataReader reader = await command?.ExecuteReaderAsync())
                        {
                            DataTable newTable = new DataTable();
                            newTable.Load(reader);
                            QueryResult?.Clear();
                            QueryResult?.Columns.Clear();
                            QueryResult = newTable;
                            QueryResult.DefaultView.AllowNew = false;
                            XsdSchema = await xsdSchemaGenerator.ConvertToXsdAsync(connectionString, QueryResult);
                            IsExecuted = true;
                        }
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show("Wrong query", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        QueryResult.Clear();
                        IsExecuted = false;
                    }
                    catch(ConstraintException ce)
                    {
                        MessageBox.Show("Wrong query", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        QueryResult.Clear();
                        IsExecuted = false;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Wrong query", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        QueryResult.Clear();
                        IsExecuted = false;
                    }
                }
            }
        }
        private async Task SaveCommandAction()
        {
            PromptForFilePath();
        }
        #endregion

        #region Methods
        private void PromptForFilePath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XSD files (*.xsd)|*.xsd|All files (*.*)|*.*";
            saveFileDialog.Title = "Save XSD file";
            if (saveFileDialog.ShowDialog() == true)
            {
                SaveAsXsd(saveFileDialog.FileName);
            }
        }
        private void SaveAsXsd(string filePath)
        {
            File.WriteAllText(filePath, XsdSchema);

            Console.WriteLine($"XSD file saved at: {filePath}");
        }

        #endregion

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void AutoGeneratingColumn(DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = e.PropertyName;
        }
    }

}
