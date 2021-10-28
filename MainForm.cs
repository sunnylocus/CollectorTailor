using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CsvHelper;
using System.Diagnostics;
using CsvHelper.Configuration;

namespace CollectorTailor
{
    public partial class MyMainForm : Form
    {
        private Configuration configFile;
        private CheckedListBox checkedListBox_features;
        private ListView listView1;
        private Button button1;
        private Button button2;
        private KeyValueConfigurationCollection settings;
        
        public MyMainForm()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = AppContext.BaseDirectory + "TCISDataCollector.dll.config"
            };

            configFile = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            settings = configFile.AppSettings.Settings;
            InitializeComponent();
       
        }

    
        

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.listView1.BeginUpdate();
            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            foreach (ListViewItem lvw in checkedItems)
            {
                lvw.BackColor = Color.Snow;
            }
            this.listView1.EndUpdate();
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            this.listView1.BeginUpdate();
            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            foreach (ListViewItem item in checkedItems)
            {
                item.BackColor = Color.LightGreen;
            }
            this.listView1.EndUpdate();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMainForm));
            this.checkedListBox_features = new System.Windows.Forms.CheckedListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox_features
            // 
            this.checkedListBox_features.CheckOnClick = true;
            this.checkedListBox_features.FormattingEnabled = true;
            this.checkedListBox_features.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox_features.Name = "checkedListBox_features";
            this.checkedListBox_features.Size = new System.Drawing.Size(433, 1156);
            this.checkedListBox_features.TabIndex = 0;
            this.checkedListBox_features.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkedListBox_features_MouseUp);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(452, 85);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1585, 1083);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(628, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 67);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 67);
            this.button2.TabIndex = 3;
            this.button2.Text = "Csv File...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MyMainForm
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2049, 1173);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.checkedListBox_features);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MyMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tcis Tailor";
            this.Load += new System.EventHandler(this.MyMainForm_Load);
            this.ResumeLayout(false);

        }

        private void MyMainForm_Load(object sender, EventArgs e)
        {
            string[] featureList = new string[] { "" };
            // Restore the checked Features and Processes
            if (settings["Features"] != null)
            {
                string features = this.settings["Features"].Value;
                Debug.WriteLine(features);
                featureList = features.Split(",");
            }
            PropertyInfo[] pros = typeof(AppInfo).GetProperties().ToArray();
            var inx = 0;
            foreach (var prop in pros)
            {
                checkedListBox_features.Items.Add(prop.Name);
                if (featureList.Contains(prop.Name))
                    checkedListBox_features.SetItemChecked(inx, true);
                inx++;
            }
            // init list views
            listView1.View = View.Details;
            listView1.Columns.Add("Choice");
            listView1.Columns.Add("No.");
            listView1.Columns.Add("Description");
            listView1.Columns.Add("ExecutablePath");

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Tcis csv files(*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    this.listView1.BeginUpdate();
                    var rowCounter = 0;
                    HashSet<string> pList = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    using (StreamReader reader = new StreamReader(filePath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        //csv.Read();
                        //csv.ReadHeader();
                        csv.Context.RegisterClassMap<MyBeanMap>();
                        while (csv.Read())
                        {
                            if (rowCounter == 50000) break; // The amount of rows is enough.
                            try { 
                                var record = csv.GetRecord<MyBean>();
                                pList.Add(record.Description.Trim() + "," + record.ExecutablePath.Trim());
                                rowCounter++;
                            } 
                            catch
                            {
                                const string message = "Please choose a Csv file that C# data collector produced.";
                                const string caption = "Information Hint";
                                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    rowCounter = 1;
                    
                    foreach (var item in pList)
                    {
                        var curr_item = new ListViewItem();
                        curr_item.SubItems.Add(rowCounter.ToString());
                        curr_item.SubItems.Add(item.Split(",")[0]);
                        curr_item.SubItems.Add(item.Split(",")[1]);
                        this.listView1.Items.Add(curr_item);
                        rowCounter++;
                    }
                    this.listView1.EndUpdate(); 
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string keyName = "Process";
            configFile.AppSettings.Settings.Remove(keyName);
            foreach (ListViewItem item in this.listView1.CheckedItems)
            {
                if (settings[keyName] == null)
                    settings.Add(keyName, item.SubItems[2].Text + "=" + item.SubItems[3].Text);
                else
                    settings[keyName].Value += ("," + item.SubItems[2].Text + "=" + item.SubItems[3].Text);
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            const string message = "Information has been saved sucessfully!";
            const string caption = "Information Hint";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkedListBox_features_MouseUp(object sender, MouseEventArgs e)
        {
            const string keyName = "Features";
            configFile.AppSettings.Settings.Remove(keyName);
            string ori = "";
            foreach (var checkedItem in this.checkedListBox_features.CheckedItems)
            {
                ori += (checkedItem.ToString().Trim() + ",");
            }
            ori = ori.Remove(ori.Length - 1, 1);
            settings.Add(keyName, ori);
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }
}
