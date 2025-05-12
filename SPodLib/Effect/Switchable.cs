namespace SPodLib.Effect
{
    /// <summary>
    /// Abstract class representing switchable entity.
    /// Disabled by default.
    /// </summary>
    public abstract class Switchable
    {
        private bool _enabled = false;

        /// <summary>
        /// Disable entity.
        /// </summary>
        public void Disable()
        {
            _enabled = false;
        }

        /// <summary>
        /// Enable entity.
        /// </summary>
        public void Enable()
        {
            _enabled = true;
        }

        /// <summary>
        /// Check if entity is enabled.
        /// </summary>
        /// <returns>true if enabled.</returns>
        public bool IsEnabled()
        {
            return _enabled;
        }
    }
}
