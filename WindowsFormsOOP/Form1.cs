using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsOOP
{
    public partial class Form1 : Form
    {
        bool successLoadIndications;
        bool successLoadConditions;
        double absolute, relation;
        Indicate indicationData;
        Condite conditionData;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Indication files (*.indc)|*.indc";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                indicationData = new Indicate(openFileDialog1.FileName);
                if (indicationData.Success)
                {
                    successLoadIndications = true;
                    MessageBox.Show("Данные загружены!");
                }
                else
                {
                    MessageBox.Show(indicationData.ResultException.Message, "Ошибка формата файла!");
                    successLoadIndications = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            successLoadConditions = false;
            successLoadIndications = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = "c:\\";
            openFileDialog2.Filter = "Conditions files (*.cond)|*.cond";
            openFileDialog2.FilterIndex = 1;
            openFileDialog2.RestoreDirectory = true;
            openFileDialog2.FileName = "";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                conditionData = new Condite(openFileDialog2.FileName);
                if (conditionData.Success)
                {
                    successLoadConditions = true;
                    MessageBox.Show("Данные загружены!");
                }
                else
                {
                    MessageBox.Show(conditionData.ResultException.Message, "Ошибка формата файла!");
                    successLoadConditions = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (successLoadConditions && successLoadIndications && textBox1.Text !="" && textBox2.Text!="")
            {
                if (double.TryParse(textBox1.Text, out absolute) && absolute > 0)
                {
                    if (double.TryParse(textBox2.Text, out relation) && relation>0)
                    {
                        DataAnalize analizes = new DataAnalize();
                        analizes.SetData(conditionData.Condition, indicationData.Indications, absolute, relation);
                        analizes.DoAnalize();
                        if (analizes.SuccessAnalize)
                        {
                            analizes.PrintResult(dataGridView1);
                            if (dataGridView1.Rows.Count == 0)
                            {
                                MessageBox.Show("Исключительных событий не выявлено");
                            }
                        }
                        else
                            MessageBox.Show("Ошибка при попытке проанализировать данные");
                    }
                    else
                        MessageBox.Show("Некорректный ввод относительного значения");
                }
                else
                    MessageBox.Show("Некорректный ввод абсолютного значения");
            }
            else
                if (!successLoadConditions)
                    MessageBox.Show("Выберите файл фильтров");
                else
                    MessageBox.Show("Выберите файл показаний");
        }
    }
}
