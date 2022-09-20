using UnityEngine;

 
    public class PauseController
    {
        private bool _pauseState;

        public bool GetPauseState()
        {
            return _pauseState;
        }

        public void PauseOn()
        {
            _pauseState = true;
            Time.timeScale = 0;
        }

        public void PauseOff()
        {
            _pauseState = false;
            Time.timeScale = 1;
        }
    }
 