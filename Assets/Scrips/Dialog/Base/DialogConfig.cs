using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogIndex
{
    PauseDialog = 1,
    CancelDialog = 2,
    SelectDialog = 3,
    CheckRobotDialog = 4,
}
public class DialogParam
{

}

public class DialogConfig 
{
    public static DialogIndex[] dialogIndices =
    {
        DialogIndex.PauseDialog,
        DialogIndex.CancelDialog,
        DialogIndex.SelectDialog,
        DialogIndex.CheckRobotDialog,
    };
}
