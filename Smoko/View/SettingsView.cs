using Smoko.Properties;
using Smoko.Service;
using System;
using System.Windows.Forms;

namespace Smoko.View
{
    public partial class SettingsView : Form, ISettingsView
    {
        private bool _closeAllowed;
        private readonly int _popupDelay;

        public SettingsView()
        {
            InitializeComponent();
            _popupDelay = AppSettings.GetPopupDelay();
        }

        public event EventHandler ViewLoaded;
        public event EventHandler InviteRequested;

        public void ShowInvitePopup(string sender)
        {
            notifyIcon.ShowBalloonTip(_popupDelay, Resources.InviteSubject, string.Format(Resources.AnnouncementText, sender), ToolTipIcon.Info);
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            Hide();
            SetDefaults();
            notifyIcon.ShowBalloonTip(_popupDelay, Resources.AppName, Resources.AppStarted, ToolTipIcon.Info);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _closeAllowed = true;
            Close();
        }

        private void SettingsView_Load(object sender, EventArgs e)
        {
            ViewLoaded?.Invoke(sender, e);
        }

        private void SmokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InviteRequested?.Invoke(sender, e);
        }

        private void SettingsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_closeAllowed)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void SetDefaults()
        {
            numericUpDownPort.Value = AppSettings.GetPort();
            textBoxName.Text = AppSettings.GetName();
        }
    }
}
