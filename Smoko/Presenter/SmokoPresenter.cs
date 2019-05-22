using Smoko.Service;
using Smoko.View;
using System;

namespace Smoko.Presenter
{
    internal class SmokoPresenter
    {
        private readonly ISettingsView _view;
        private readonly ICommunication _communication;

        public SmokoPresenter(ISettingsView view, ICommunication communication)
        {
            _view = view;
            _view.ViewLoaded += ViewLoaded;
            _view.InviteRequested += InviteRequested;

            _communication = communication;
            _communication.DataReceived += DataReceived;
        }

        private void ViewLoaded(object sender, EventArgs e)
        {
            _communication.StartListening();
        }

        private void InviteRequested(object sender, EventArgs e)
        {
            _communication.SendMessage(AppSettings.GetName());
        }

        private void DataReceived(object sender, string e)
        {
            _view.ShowInvitePopup(e);
        }
    }
}
