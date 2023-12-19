using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using yshakova_7;

namespace yshakova_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BindingList<Room> data1 = new BindingList<Room>();
        BindingList<Stay> data2 = new BindingList<Stay>();
        BindingList<Client> data3 = new BindingList<Client>();
        public void DGRefresh1()
        {
            data1.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                var infolist = db.room.FromSqlRaw("SELECT * FROM room").ToList();
                for (int i = 0; i < infolist.Count(); i++)
                {
                    data1.Add(infolist[i]);
                    dataGridView1.DataSource = data1;
                }
            }
        }
        public void DGRefresh2()
        {
            data2.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                var infolist = db.stay.FromSqlRaw("SELECT * FROM stay").ToList();
                for (int i = 0; i < infolist.Count(); i++)
                {
                    data2.Add(infolist[i]);
                    dataGridView2.DataSource = data2;
                }
            }
        }
        public void DGRefresh3()
        {
            data3.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                var infolist = db.client.FromSqlRaw("SELECT * FROM client").ToList();
                for (int i = 0; i < infolist.Count(); i++)
                {
                    data3.Add(infolist[i]);
                    dataGridView3.DataSource = data3;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = data1;
            dataGridView2.DataSource = data2;
            dataGridView3.DataSource = data3;
            DGRefresh1();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                DGRefresh1();
            }

            if (tabControl1.SelectedIndex == 1)
            {
                DGRefresh2();
            }

            if (tabControl1.SelectedIndex == 2)
            {
                DGRefresh3();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {
                    Room ni = new Room();
                    for (int i = 0; i <= dataGridView1.RowCount; i++)
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == Convert.ToInt32(dataGridView2.CurrentRow.Cells[3].Value))
                        {
                            ni = new Room(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), dataGridView1.Rows[i].Cells[1].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value));
                            break;
                        }
                    }
                    textBox5.Text = Convert.ToString(ni.room_cost / ni.capacity);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Stay a = new Stay(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));

                    db.stay.Add(a);
                    db.SaveChanges();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    DGRefresh2();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (dataGridView2.CurrentRow != null)
                    {
                        Stay a = new Stay(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));

                        db.stay.Update(a);
                        db.SaveChanges();
                        DGRefresh2();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (dataGridView2.CurrentRow != null)
                    {
                        Stay a = new Stay(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value), Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value), Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value), Convert.ToInt32(dataGridView2.CurrentRow.Cells[3].Value));

                        db.stay.Remove(a);
                        db.SaveChanges();
                        DGRefresh2();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {
                    Room ni_2 = new Room();
                    for (int i = 0; i <= dataGridView1.RowCount; i++)
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == Convert.ToInt32(dataGridView2.CurrentRow.Cells[3].Value))
                        {
                            ni_2 = new Room(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), dataGridView1.Rows[i].Cells[1].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value));
                            break;
                        }
                    }
                    textBox6.Text = Convert.ToString((ni_2.room_cost * Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value)) / ni_2.capacity);
                    textBox6.Text += Environment.NewLine + (Convert.ToString(ni_2.room_cost * Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Stay[] stays = new Stay[100];
                Random random = new Random();
                using (ApplicationContext db = new ApplicationContext())
                {
                    for (int i = 0; i < stays.Length; i++)
                    {
                        stays[i] = new Stay(i + 1, random.Next(1, 7), random.Next(1, 30), random.Next(1, 7));
                    }
                    for (int i = 0; i < stays.Count(); i++)
                    {
                        db.stay.Add(stays[i]);
                        db.SaveChanges();
                    }
                }
                DGRefresh2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Stay[] stays = new Stay[100];
                    for (int i = 0; i < stays.Length; i++)
                    {
                        stays[i] = new Stay(Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value), Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value), Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value), Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value));
                    }
                    db.stay.RemoveRange(stays);
                    db.SaveChanges();

                }
                DGRefresh2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            data1.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                var infolist = db.room.FromSqlRaw("SELECT * FROM room").OrderBy(r => r.room_cost).ToList();
                for (int i = 0; i < infolist.Count(); i++)
                {
                    data1.Add(infolist[i]);
                    dataGridView1.DataSource = data1;
                }
            }
        }
    }
}