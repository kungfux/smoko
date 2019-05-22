using System;

namespace Smoko.View
{
    internal interface ISettingsView
    {
        event EventHandler ViewLoaded;
        event EventHandler InviteRequested;

        void ShowInvitePopup(string sender);
    }
}
