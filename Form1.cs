﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        DatabaseConnection objConnect;
        string conString;

        DataSet ds;

        DataRow dRow;

        int MaxRows;
        int inc = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                objConnect = new DatabaseConnection();
                conString = Properties.Settings.Default.QuestConnectionString;
                objConnect.connection_string = conString;

                objConnect.Sql = Properties.Settings.Default.SQL;
                ds = objConnect.GetConnection;

                MaxRows = ds.Tables[0].Rows.Count;
                NavigateRecords();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);

            }
        }

        private void NavigateRecords()
        {

            dRow = ds.Tables[0].Rows[inc];

            txtTask.Text = dRow.ItemArray.GetValue(1).ToString();
            txtOptionA.Text = dRow.ItemArray.GetValue(2).ToString();
            txtOptionB.Text = dRow.ItemArray.GetValue(3).ToString();
            txtOptionC.Text = dRow.ItemArray.GetValue(4).ToString();
            txtOptionD.Text = dRow.ItemArray.GetValue(5).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inc < MaxRows - 1)
            {

                inc++;
                NavigateRecords();

            }
            else
            {

                inc = 0;
                NavigateRecords();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (inc > 0)
            {

                inc--;
                NavigateRecords();

            }
            else
            {

                inc = MaxRows - 1;
                NavigateRecords();

            }
        }
    }
}
