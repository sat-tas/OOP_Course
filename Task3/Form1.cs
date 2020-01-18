using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task3.Entity;

namespace Task3
{
    public partial class Form1 : Form
    {
        private TrainList trainList;

        public Form1()
        {
            trainList = new TrainList();
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                trainList.Add(textBox1.Text, Convert.ToInt32(textBox2.Text), TimeSpan.Parse(textBox3.Text));

                TrainSortAndFind trainSort = new TrainSortAndFind("Ost", trainList);
                trainList = trainSort.Sort();
                update();
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные", "Error", MessageBoxButtons.OK);
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            if (MessageBox.Show($"{trainList[id].ToString()}", "Вы действительно хотите удалить запись", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                trainList.Reamove(id);
                update();
            }
        }


        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Выберите из какого файла загрузить данные";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                trainList.ReadFromFile(fileDialog.FileName);
            }

            TrainSortAndFind trainSort = new TrainSortAndFind("Ost", trainList);
            trainList = trainSort.Sort();
            update();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Выберите в какой файла загрузить данные";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                trainList.WriteToFile(fileDialog.FileName);
            }
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            string val;
            if (radioButton1.Checked)
                val = "Ost";
            else if (radioButton2.Checked)
                val = "Number";
            else
                val = "Time";

            TrainSortAndFind trainSort = new TrainSortAndFind(val, trainList);
            trainList = trainSort.Sort();
            update();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            List<Train> result;
            try
            {
                if (radioButton1.Checked)
                {
                    TrainSortAndFind trainSort = new TrainSortAndFind("Ost", trainList);
                    result = trainSort.Find(textBox1.Text);
                }
                else if (radioButton2.Checked)
                {
                    TrainSortAndFind trainSort = new TrainSortAndFind("Number", trainList);
                    result = trainSort.Find(Convert.ToInt32(textBox2.Text));
                }
                else
                {
                    TrainSortAndFind trainSort = new TrainSortAndFind("Time", trainList);
                    result = trainSort.Find(TimeSpan.Parse(textBox3.Text));
                }
                dataGridView2.Visible = true;
                dataGridView2.Rows.Clear();
                for (int i = 0; i < result.Count; i++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = i.ToString();
                    dataGridView2.Rows[i].Cells[1].Value = result[i].Ost;
                    dataGridView2.Rows[i].Cells[2].Value = result[i].Number.ToString();
                    dataGridView2.Rows[i].Cells[3].Value = result[i].Time;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные", "Error", MessageBoxButtons.OK);
            }
        }

        private void IDZ_Click(object sender, EventArgs e)
        {
            List<Train> result = new List<Train>();
            try
            {
                TimeSpan time = TimeSpan.Parse(textBox3.Text);
                for (int i = 0; i < trainList.Count; i++)
                {
                    if (trainList[i].Time > time)
                        result.Add(trainList[i]);
                }

                dataGridView2.Visible = true;
                dataGridView2.Rows.Clear();
                for (int i = 0; i < result.Count; i++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = i.ToString();
                    dataGridView2.Rows[i].Cells[1].Value = result[i].Ost;
                    dataGridView2.Rows[i].Cells[2].Value = result[i].Number.ToString();
                    dataGridView2.Rows[i].Cells[3].Value = result[i].Time;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные", "Error", MessageBoxButtons.OK);
            }

        }

        private void update()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < trainList.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i.ToString();
                dataGridView1.Rows[i].Cells[1].Value = trainList[i].Ost;
                dataGridView1.Rows[i].Cells[2].Value = trainList[i].Number.ToString();
                dataGridView1.Rows[i].Cells[3].Value = trainList[i].Time;
            }
        }

    }
}
