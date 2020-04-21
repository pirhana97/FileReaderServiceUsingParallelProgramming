using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileReaderUIClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += OnClosing;
        }

        private void OnBrowseClick(object sender, EventArgs e)
        {

            #region ParallelTasks
            Parallel.Invoke(


                () =>
                {

                    WriteFilePath filePath = new WriteFilePath();
                    string filename = filePath.writeFilePath();
                    FilePath.Text = filename;
                }

            );
            #endregion

        }

        private void OnGetContentsClick(object sender, EventArgs e)
        {
            FileReaderServiceProxy.FileReaderServiceProxy proxy = new FileReaderServiceProxy.FileReaderServiceProxy("httpEP");
            string filePath = FilePath.Text;
            FileInfo fileInfo = new FileInfo(filePath);

            StringBuilder stringBuilder = new StringBuilder();

            #region ParallelTasks
            Parallel.Invoke(


                () =>
                {
                   
                    FileAttributes.Text = proxy.GetAttributes(filePath);                   
                },
                                
                () =>
                {

                    stringBuilder.Append("Type : " + fileInfo.Extension+"\n");
                },
                () =>
                {

                    stringBuilder.Append("Is ReadOnly : " + fileInfo.IsReadOnly + "\n");
                },
                () =>
                {

                    stringBuilder.Append("Creation time : " + fileInfo.CreationTime + "\n");
                },

                () =>
                  {

                      stringBuilder.Append("Last access time : " + fileInfo.LastAccessTime + "\n");
                  },

                () =>
                {

                    stringBuilder.Append("Last write time : " + fileInfo.LastWriteTime + "\n");
                },

                () =>
                {
                    stringBuilder.Append("Directory Name : " + fileInfo.DirectoryName+"\n");
                   
                }

            );
            #endregion

            System.Windows.MessageBox.Show(stringBuilder.ToString(), "File Details");

        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            if (System.Windows.MessageBox.Show(this, "Are you sure you want to quit?", "Confirm", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                cancelEventArgs.Cancel = true;
            }
        }
    }
}

