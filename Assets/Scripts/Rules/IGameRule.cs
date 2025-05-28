using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public interface IGameRule
    {
        void FrameCheck();          
        bool ShouldPlayerDie();         
    }

