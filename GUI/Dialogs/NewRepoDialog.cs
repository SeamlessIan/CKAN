﻿using System;
using System.Windows.Forms;

namespace CKAN
{


    public partial class NewRepoDialog : Form
    {
        public NewRepoDialog()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void NewRepoDialog_Load(object sender, EventArgs e)
        {
            RepositoryList repositories;

            try
            {
                repositories = Main.FetchMasterRepositoryList();
            }
            catch
            {
                ReposListBox.Items.Add(Properties.Resources.NewRepoDialogFailed);
                return;
            }

            ReposListBox.Items.Clear();

            if (repositories.repositories == null)
            {
                ReposListBox.Items.Add(Properties.Resources.NewRepoDialogFailed);
                return;
            }

            foreach (Repository repository in repositories.repositories)
            {
                ReposListBox.Items.Add(String.Format("{0} | {1}", repository.name, repository.uri));
            }
        }

        private void ReposListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReposListBox.SelectedItem == null)
            {
                return;
            }

            RepoUrlTextBox.Text = (string) ReposListBox.SelectedItem;
        }

        private void RepoUrlTextBox_TextChanged(object sender, EventArgs e)
        {
            RepoOK.Enabled = RepoUrlTextBox.Text.Length != 0;
        }

    }
}
