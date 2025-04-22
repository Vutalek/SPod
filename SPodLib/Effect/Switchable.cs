namespace SPodLib.Effect
{
    public abstract class Switchable
    {
        private bool _enabled = false;

        public void Disable()
        {
            _enabled = false;
        }

        public void Enable()
        {
            _enabled = true;
        }

        public bool IsEnabled()
        {
            return _enabled;
        }
    }
}
