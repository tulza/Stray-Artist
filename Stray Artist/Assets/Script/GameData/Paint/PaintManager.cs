using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour
{
    //variable to watch which paint has been collected
    public static List<string> CollectedPaint = new List<string>{};
    //save selected stage here
    public static int SelectedStage = 0;

    private void Start() {
        CollectedPaint = new List<string>{};
        SelectedStage = 0;
    }
}
