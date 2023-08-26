namespace MyAntDesignApp.Components
{
    public partial class DisplayModalDialog
    {
        private bool _visible;

        public void Show()
        {
            _visible = true;

            StateHasChanged();
        }

        public void Close()
        {
            _visible = false;

            StateHasChanged();
        }

        private void OnCancelClick()
        {
            Close();
        }
    }
}
