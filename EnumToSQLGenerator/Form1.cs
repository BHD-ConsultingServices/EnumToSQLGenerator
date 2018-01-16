using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;

namespace EnumToSQLGenerator
{
    public partial class Form1 : Form
    {
        private Assembly asm = null;
        StringBuilder sqlBuilder = new StringBuilder();
        string fileName = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadAssembly_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog();
                dlg.Filter = ".NET Binary Assemblies (*.dll) |*.dll ; *.dll ; *.dll";
                dlg.Multiselect = false;
                dlg.RestoreDirectory = true;
                dlg.ShowDialog();
                this.txtboxAssemblyLocation.Text = dlg.FileName;
                LoadAssembly(dlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
        }
        private void LoadAssembly(string location)
        {
            checkedListBoxDiscoveredEnums.Items.Clear();
            asm = Assembly.LoadFile(location);
            var enums = asm.GetExportedTypes().Where(t => t.IsEnum);
            foreach (var e in enums)
            {
                checkedListBoxDiscoveredEnums.Items.Add(e.FullName);
            }
        }

        private void checkedListBoxDiscoveredEnums_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var selectedItem = (SelectedItem)
            var checkList = (CheckedListBox)sender;
            var selectedEnumName = checkList.SelectedItem.ToString();
            sqlBuilder.Clear();

            Type selectedEnumType = null;
            if (asm != null && selectedEnumName != null)
            {
                selectedEnumType = asm.GetType(selectedEnumName, true, true);
                fileName = $"{DateTime.Today.ToShortDateString()}_{selectedEnumType.Name}.sql";
                //now we have the enum

                //get description
                //cast its struct value
                //generate table text template
                //generate insert statement
                sqlBuilder.AppendLine($"---Author: Mpho Majenge");
                sqlBuilder.AppendLine($"---Date {DateTime.Now}");
                sqlBuilder.AppendLine($"---Description: Script for creating a lookup table for {selectedEnumType.Name}");

                sqlBuilder.AppendLine($"---BEGIN {selectedEnumType.Name} STRUCTURE");
                sqlBuilder.AppendLine("BEGIN TRANSACTION ");
                sqlBuilder.AppendLine("BEGIN TRY");
                sqlBuilder.AppendLine($"CREATE TABLE dbo.{selectedEnumType.Name}");
                sqlBuilder.AppendLine("\t\t(");

                sqlBuilder.AppendLine("\t\tId int NOT NULL IDENTITY (1, 1),");
                sqlBuilder.AppendLine("\t\tCorrelationId int NOT NULL,");
                sqlBuilder.AppendLine("\t\t[Description] nvarchar(50) NOT NULL");

                sqlBuilder.AppendLine("\t\t)  ON [PRIMARY]");

                sqlBuilder.AppendLine($"ALTER TABLE dbo.{selectedEnumType.Name} ADD CONSTRAINT");
                if (radioButtonInteger.Checked)
                {
                    sqlBuilder.AppendLine($"\t\tPK_{selectedEnumType.Name} PRIMARY KEY CLUSTERED ");
                }
                else
                {
                    sqlBuilder.AppendLine($"\t\tPK_{selectedEnumType.Name} PRIMARY KEY NONCLUSTERED ");
                }
                sqlBuilder.AppendLine("\t\t(Id)WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

                sqlBuilder.AppendLine("COMMIT");
                sqlBuilder.AppendLine("END TRY");
                sqlBuilder.AppendLine("BEGIN CATCH");
                sqlBuilder.AppendLine(" \tDECLARE @ErrorMessage NVARCHAR(4000); ");
                sqlBuilder.AppendLine(" \tDECLARE @ErrorSeverity INT; ");
                sqlBuilder.AppendLine(" \tDECLARE @ErrorState INT; ");
                sqlBuilder.AppendLine();
                sqlBuilder.AppendLine(" SELECT   ");
                sqlBuilder.AppendLine("@ErrorMessage = ERROR_MESSAGE(),  ");
                sqlBuilder.AppendLine("@ErrorSeverity = ERROR_SEVERITY(), ");
                sqlBuilder.AppendLine("@ErrorState = ERROR_STATE();   ");
                sqlBuilder.AppendLine();
                sqlBuilder.AppendLine("RAISERROR \t(@ErrorMessage, ");
                sqlBuilder.AppendLine(" \t@ErrorSeverity, ");
                sqlBuilder.AppendLine(" \t@ErrorState ");
                sqlBuilder.AppendLine(" \t);  ");
                sqlBuilder.AppendLine("ROLLBACK");
                sqlBuilder.AppendLine("END CATCH");
                sqlBuilder.AppendLine();
                sqlBuilder.AppendLine($"---END {selectedEnumType.Name} STRUCTURE");

                //generate inserts
                sqlBuilder.AppendLine($"---BEGIN {selectedEnumType.Name} INSERTS");
                sqlBuilder.AppendLine();
                sqlBuilder.AppendLine("BEGIN TRANSACTION ");
                sqlBuilder.AppendLine("BEGIN TRY");
                sqlBuilder.AppendLine();
                if (radioButtonInteger.Checked)
                {
                    sqlBuilder.AppendLine($"INSERT INTO dbo.{selectedEnumType.Name}(CorrelationId,[Description]) ");
                }
                else
                {
                    sqlBuilder.AppendLine($"INSERT INTO dbo.{selectedEnumType.Name}({selectedEnumType.Name}Id,CorrelationId,[Description]) ");
                }
                sqlBuilder.AppendLine("VALUES");

                var enumValues = Enum.GetValues(selectedEnumType);

                int count = 0;
                foreach (var enumValue in enumValues)
                {
                    var description = GetDescription((Enum)enumValue);
                    if (string.IsNullOrEmpty(description))
                        description = enumValue.ToString();

                    if (radioButtonInteger.Checked)
                    {
                        var value = (int)enumValue;
                        if (count < enumValues.Length - 1)
                        {
                            sqlBuilder.AppendLine($"({value},\'{description}\'),");
                        }
                        else
                        {
                            sqlBuilder.AppendLine($"({value},\'{description}\')");
                        }
                    }
                    else
                    {
                        var value = (int)enumValue;
                        var uuid = Guid.NewGuid();
                        if (count < enumValues.Length - 1)
                        {
                            sqlBuilder.AppendLine($"(\'{uuid}\',{value},\'{description}\'),");
                        }
                        else
                        {
                            sqlBuilder.AppendLine($"(\'{uuid}\',{value},\'{description}\')");
                        }
                    }


                    count++;
                }


                sqlBuilder.AppendLine();
                sqlBuilder.AppendLine("COMMIT");
                sqlBuilder.AppendLine("END TRY");
                sqlBuilder.AppendLine("BEGIN CATCH");
                sqlBuilder.AppendLine();
                sqlBuilder.AppendLine(" SELECT   ");
                sqlBuilder.AppendLine("@ErrorMessage = ERROR_MESSAGE(),  ");
                sqlBuilder.AppendLine("@ErrorSeverity = ERROR_SEVERITY(), ");
                sqlBuilder.AppendLine("@ErrorState = ERROR_STATE();   ");
                sqlBuilder.AppendLine();
                sqlBuilder.AppendLine("RAISERROR \t(@ErrorMessage, ");
                sqlBuilder.AppendLine(" \t@ErrorSeverity, ");
                sqlBuilder.AppendLine(" \t@ErrorState ");
                sqlBuilder.AppendLine(" \t);  ");
                sqlBuilder.AppendLine("ROLLBACK");
                sqlBuilder.AppendLine("END CATCH");
                sqlBuilder.AppendLine();
                sqlBuilder.AppendLine($"---END {selectedEnumType.Name} INSERTS");

            }

            richTextBoxSQL.Text = sqlBuilder.ToString();
        }

        private string GetDescription(Enum enumerationValue)
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(sqlBuilder.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            string fileDestination = Path.Combine(dlg.SelectedPath, fileName);
            File.WriteAllText(fileDestination, sqlBuilder.ToString());

            MessageBox.Show($"File [{fileName}] saved to [{dlg.SelectedPath}]");
        }

    }
}
