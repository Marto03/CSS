using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SqlToXSDSchema
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string sqlQuery;
        private DelegateCommand saveCommand;
        private DelegateCommand convertCommand;
        private bool isExecuted;
        public DataTable QueryResult { get; } = new DataTable();
        public RelayCommand<DataGridAutoGeneratingColumnEventArgs> AutoGeneratingColumnCommand { get; }

        public MainWindowViewModel()
        {
            AutoGeneratingColumnCommand = new RelayCommand<DataGridAutoGeneratingColumnEventArgs>(AutoGeneratingColumn);
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
                    OnPropertyChanged(SqlQuery);
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
                    OnPropertyChanged();
                }
            }
        }
        public DelegateCommand ConvertCommand
        {
            get
            {
                if (convertCommand == null)
                    convertCommand = new DelegateCommand(async () => await ConvertCommandAction());
                return convertCommand;
            }
        }

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
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            QueryResult.Clear();
                            QueryResult.Load(reader);
                            IsExecuted = true;
                        }
                    }
                    catch (SqlException e)
                    {
                        QueryResult.Clear();
                        IsExecuted = false;
                    }
                }
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
        private async Task SaveCommandAction()
        {
            PromptForFilePath();
        }
        private void SaveAsXsd(string filePath)
        {
            File.WriteAllText(filePath , sqlQuery);

            Console.WriteLine($"XSD file saved at: {filePath}");
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void AutoGeneratingColumn(DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = e.PropertyName;
        }
    }

}
