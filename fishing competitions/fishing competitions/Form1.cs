using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fishing_competitions
{
    public partial class Form1 : Form
    {
        List<fisherman> FishermanList = new List<fisherman>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            FishermanList.Add(new fisherman(textBox1.Text, textBox2.Text, dateTimePicker1.Value.Date, Convert.ToInt32(numericUpDown1.Value), 
                                Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown4.Value)));
            foreach (fisherman item in FishermanList)
            {
                string[] row = { item.Name, item.SurName, Convert.ToString(item.BirthDate.ToShortDateString()), Convert.ToString(item.FishingPlaceNumber),
                                Convert.ToString(item.FishingNumber), Convert.ToString(item.MaxSizeFish), Convert.ToString(item.NumberFish) };
                var listItem = new ListViewItem(row);
                listView1.Items.Add(listItem);
            }
            clearInput();
           
        }

        public void clearInput() 
        {
            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.Value = DateTime.Now;
            numericUpDown1.Value = default;
            numericUpDown2.Value = default;
            numericUpDown3.Value = default;
            numericUpDown4.Value = default;
            textBox1.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listView1.Items.Clear();
            //FishermanList.Sort((x, y) => y.FishingNumber.CompareTo(x.FishingNumber));
            FishermanList.Sort((x, y) =>
            {
                int result = decimal.Compare(y.FishingNumber, x.FishingNumber);
                if (result == 0)
                {
                    if ((y.FishingNumber == 0) && (x.FishingNumber == 0))
                    {
                        result = decimal.Compare(x.FishingPlaceNumber, y.FishingPlaceNumber);
                    }
                    else
                    {
                        result = decimal.Compare(y.NumberFish, x.NumberFish);
                    }
                }
                    
                return result;
            });

            int countFischerman = 1;
            DateTime minD = DateTime.MinValue;
            string youngName = default;
            string youngSurName = default;

            string maxFishName = default;
            string maxFishSurName = default;
            int maxFishLenght = default;

            foreach (fisherman item in FishermanList)
            {
                
                listBox1.Items.Add(countFischerman + ". " + item.Name + " " + item.SurName + " - lovné místo: " + item.FishingPlaceNumber + " - počet ryb: " + item.NumberFish + " - bodů: " + item.FishingNumber);
                countFischerman++;

                string[] row = { item.Name, item.SurName, Convert.ToString(item.BirthDate.ToShortDateString()), Convert.ToString(item.FishingPlaceNumber),
                                Convert.ToString(item.FishingNumber), Convert.ToString(item.MaxSizeFish), Convert.ToString(item.NumberFish) };
                var listItem = new ListViewItem(row);
                listView1.Items.Add(listItem);

                if (item.BirthDate.Date > minD) 
                {
                    minD = item.BirthDate.Date;
                    youngName = item.Name;
                    youngSurName = item.SurName;
                }

                if (item.MaxSizeFish > maxFishLenght)
                {
                    maxFishLenght = item.MaxSizeFish;
                    maxFishName = item.Name;
                    maxFishSurName = item.SurName;
                } 
                else if (item.MaxSizeFish == maxFishLenght) 
                {
                    maxFishName += "," + item.Name;
                    maxFishSurName += "," + item.SurName;
                }
            }

            listBox1.Items.Add("Nejmladší účastník závodu: " + youngName + " " + youngSurName + " - " + minD.ToShortDateString());
            listBox1.Items.Add("Největší ulovená ryba: " + maxFishName + " " + maxFishSurName + " - " + maxFishLenght);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listView1.SelectedItems[0].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                dateTimePicker1.Value = Convert.ToDateTime(listView1.SelectedItems[0].SubItems[2].Text);
                numericUpDown1.Value = Convert.ToInt32(listView1.SelectedItems[0].SubItems[3].Text);
                numericUpDown2.Value = Convert.ToInt32(listView1.SelectedItems[0].SubItems[4].Text);
                numericUpDown3.Value = Convert.ToInt32(listView1.SelectedItems[0].SubItems[5].Text);
                numericUpDown4.Value = Convert.ToInt32(listView1.SelectedItems[0].SubItems[6].Text);
            }
            catch 
            {
             
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems[0].Text = textBox1.Text;
            listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text;
            listView1.SelectedItems[0].SubItems[2].Text = Convert.ToString(dateTimePicker1.Value.ToShortDateString());
            listView1.SelectedItems[0].SubItems[3].Text = Convert.ToString(numericUpDown1.Value);
            listView1.SelectedItems[0].SubItems[4].Text = Convert.ToString(numericUpDown2.Value);
            listView1.SelectedItems[0].SubItems[5].Text = Convert.ToString(numericUpDown3.Value);
            listView1.SelectedItems[0].SubItems[6].Text = Convert.ToString(numericUpDown4.Value);


            int indexList = listView1.Items.IndexOf(listView1.SelectedItems[0]);

            FishermanList.RemoveAt(indexList);
            FishermanList.Insert(indexList, new fisherman(textBox1.Text, textBox2.Text, dateTimePicker1.Value, Convert.ToInt32(numericUpDown1.Value),
                                    Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown4.Value)));
            clearInput();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Opravdu si přejete vymazat záznam ?", "Odstranit záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) 
            {
                int indexList = listView1.Items.IndexOf(listView1.SelectedItems[0]);
                FishermanList.RemoveAt(indexList);

                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item);
                }

                clearInput();
            }
            
        }
    }
}
