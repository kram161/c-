using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileWork;

namespace Files
{
    public partial class MainForm : Form
    {

        BinFile binFile;
        public MainForm()
        {
            InitializeComponent();
            binFile  = new BinFile();
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    binFile.Path = openFileDialog.FileName;
                    binFile.Read();
                    state.Text = "прочитан файл длинной " + binFile.Data.Length + " байт";
                    SaveBtn.Enabled = true;
                }
                catch (Exception ex)
                {
                    state.Text = "ошибка чтения файла \n" + ex.Message;
                    SaveBtn.Enabled = false;
                }
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    binFile.Path = saveFileDialog.FileName;
                    binFile.Write();
                    state.Text = state.Text + '\n' + "файл успешно записан";
                }
                catch (Exception ex)
                {
                    state.Text = state.Text + '\n' + ex.Message;
                }
            }
        }
    }
}
