using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;

namespace File_Sorter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public void top_dir()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string string_dir = folderBrowserDialog1.SelectedPath;
                var file_types_list = new List<string>();
                int count = Directory.GetFiles(string_dir, "*", SearchOption.TopDirectoryOnly).Length;
                System.IO.DirectoryInfo sys_dir = new System.IO.DirectoryInfo(string_dir);

                string[] fileEntries = Directory.GetFiles(string_dir);

                for (int x = 0; x < count; x++)
                {
                    string file = fileEntries[x];
                    string file_type = Path.GetExtension(file);
                    string new_folder_dir = string_dir + "\\" + file_type;
                    string file_name = Path.GetFileName(file);
                    string new_file = new_folder_dir + "\\" + file_name;
                    System.IO.DirectoryInfo new_folder_sys_dir = new System.IO.DirectoryInfo(new_folder_dir);

                    string[] file_types_array = file_types_list.ToArray();
                    int file_types_count = file_types_array.Length;

                    if (System.IO.Directory.Exists(new_folder_dir))
                    {
                        System.IO.File.Move(file, new_file);
                    }

                    if (!System.IO.Directory.Exists(new_folder_dir))
                    {
                        System.IO.Directory.CreateDirectory(new_folder_dir);
                        var di = new DirectoryInfo(new_folder_dir);
                        FileAttributes f = di.Attributes;

                        System.IO.File.Move(file, new_file);
                    }
                }

                if (Directory.Exists(string_dir))
                {
                    foreach (string subdirectory in Directory.GetDirectories(string_dir))
                    {
                        string[] file = Directory.GetFiles(subdirectory, "*.*");

                        if (file.Length == 0)
                        {
                            Directory.Delete(subdirectory);
                        }
                    }
                }
            }
        }

        public void all_dir()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string string_dir = folderBrowserDialog1.SelectedPath;
                var file_types_list = new List<string>();
                int count = Directory.GetFiles(string_dir, "*", SearchOption.AllDirectories).Length;
                System.IO.DirectoryInfo sys_dir = new System.IO.DirectoryInfo(string_dir);

                string[] fileEntries = Directory.GetFiles(string_dir,"*", SearchOption.AllDirectories);

                for (int x = 0; x < count; x++)
                {
                    string file = fileEntries[x];
                    string file_type = Path.GetExtension(file);
                    string new_folder_dir = string_dir + "\\" + file_type;
                    string file_name = Path.GetFileName(file);
                    string new_file = new_folder_dir + "\\" + file_name;
                    System.IO.DirectoryInfo new_folder_sys_dir = new System.IO.DirectoryInfo(new_folder_dir);

                    string[] file_types_array = file_types_list.ToArray();
                    int file_types_count = file_types_array.Length;

                    if (System.IO.Directory.Exists(new_folder_dir))
                    {
                        System.IO.File.Move(file, new_file);
                    }

                    if (!System.IO.Directory.Exists(new_folder_dir))
                    {
                        System.IO.Directory.CreateDirectory(new_folder_dir);
                        var di = new DirectoryInfo(new_folder_dir);
                        FileAttributes f = di.Attributes;

                        System.IO.File.Move(file, new_file);
                    }
                }

                if (Directory.Exists(string_dir))
                {
                    foreach (string subdirectory in Directory.GetDirectories(string_dir))
                    {
                        string[] file = Directory.GetFiles(subdirectory, "*.*");

                        if (file.Length == 0)
                        {
                            Directory.Delete(subdirectory);
                        }
                    }
                }
            }
        }

        private void Folder_Select_Click(object sender, EventArgs e)
        {
            if (recursive_check.Checked)
            {
                all_dir();
            }
            else
            {
                top_dir();
            }

        }
    }
}
