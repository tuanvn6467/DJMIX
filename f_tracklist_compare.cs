﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicIdentification
{
    public partial class f_tracklist_compare : Form
    {
        List<string> listTrackMatched = new List<string>();
        List<string> listTrackMatchedArtist = new List<string>();
        List<string> listTrackMatchedCompare = new List<string>();
        List<string> listTrackMatchedAristCompare = new List<string>();
        public f_tracklist_compare()
        {
            InitializeComponent();
        }
        public f_tracklist_compare(List<string> listTrackMatched, List<string> listTrackMatchedArtist, List<string> listTrackMatchedCompare, List<string> listTrackMatchedAristCompare)
        {
            InitializeComponent();
            this.listTrackMatched = listTrackMatched;
            this.listTrackMatchedArtist = listTrackMatchedArtist;
            this.listTrackMatchedCompare = listTrackMatchedCompare;
            this.listTrackMatchedAristCompare = listTrackMatchedAristCompare;
        }
        private void f_tracklist_compare_Load(object sender, EventArgs e)
        {
            try
            {
                bindListTrack();
                bindListTrackCompare();
                bindListTrackResult();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void bindListTrack()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("stt");
            dt.Columns.Add("name");
            var sid = 1;
            foreach (var item in listTrackMatchedCompare)
            {
                DataRow row = dt.NewRow();
                row["stt"] = sid;
                sid++;
                row["name"] = item;
                dt.Rows.Add(row);
            }

            dataGridView_ListTrack.DataSource = dt;
            dataGridView_ListTrack.Columns[0].Width = 108;
            dataGridView_ListTrack.Columns[1].Width = 500;
        }
        private void bindListTrackCompare()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("stt");
            dt.Columns.Add("name");
            var sid = 1;
            foreach (var item in listTrackMatched)
            {
                DataRow row = dt.NewRow();
                row["stt"] = sid;
                sid++;
                row["name"] = item;
                dt.Rows.Add(row);
            }
            dataGridView_ListFound.DataSource = dt;
            dataGridView_ListFound.Columns[0].Width = 108;
            dataGridView_ListFound.Columns[1].Width = 500;
        }
        private void bindListTrackResult()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("stt");
            dt.Columns.Add("name");
            var sid = 1;
            foreach (var item in listTrackMatched)
            {
                foreach (var item2 in listTrackMatchedCompare)
                {
                    if (item.ToLower().Contains(item2.ToLower()))
                    {
                        DataRow row = dt.NewRow();
                        row["stt"] = sid;
                        sid++;
                        row["name"] = item;
                        dt.Rows.Add(row);
                    }
                }

            }
            dataGridView_ListResult.DataSource = dt;
            dataGridView_ListResult.Columns[0].Width = 108;
            dataGridView_ListResult.Columns[1].Width = 500;
        }
    }
}
