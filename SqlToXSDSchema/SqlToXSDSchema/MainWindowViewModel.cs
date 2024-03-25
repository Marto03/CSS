using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public ObservableCollection<object[]> QueryResult { get; } = new ObservableCollection<object[]>();
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

        private async Task? ConvertCommandAction()
        {
            string connectionString = "Server=localhost;Database=PubDatabase;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                {
                    try
                    {
                        using (SqlDataReader reader = command?.ExecuteReader())
                        {
                            QueryResult.Clear();
                            IsExecuted = true;
                            while (reader.Read())
                            {
                                object[] row = new object[reader.FieldCount];
                                reader.GetValues(row);
                                QueryResult.Add(row);
                            }
                        }
                    }catch (SqlException e) 
                    {
                        QueryResult.Clear();
                        return; 
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
