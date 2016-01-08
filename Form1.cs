using System;
using System.Windows.Forms;
using System.IO;

namespace junkData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            int fileSize = 0;
            int numFiles = 0;
            int.TryParse(textBoxFileSize.Text, out fileSize);
            int.TryParse(textBoxNumFiles.Text, out numFiles);
            Random rnd = new Random();
            Byte[] b = new Byte[fileSize * 1024];

            string folder = "junkData";
            Directory.CreateDirectory(folder);
            string filePrefix = "file";
            progressBar1.Visible = true;
            for (int c = 0; c < numFiles; c++)
            {
                string filename = folder + "\\" + filePrefix + c.ToString("D9");
                BinaryWriter bw = new BinaryWriter(File.Open(filename, FileMode.Create));
                rnd.NextBytes(b);
                bw.Write(b);
                bw.Flush();
                bw.Close();
                if (c % 10 == 0)
                    progressBar1.Value = (int)((double)c * (progressBar1.Maximum - progressBar1.Minimum) / numFiles);
            }
            progressBar1.Visible = false;
        }
    }
}
