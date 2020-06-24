using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class MapData
    {
        // 1 - 
        // 2 - 
        // 3 - 
        // 4 - 
        // 5 -     
        public MapData()
        {
            map = new int[100, 100];
        }

        //data members
       public int[,] map;
    }
}// end of namespace SaveLoadSystem
