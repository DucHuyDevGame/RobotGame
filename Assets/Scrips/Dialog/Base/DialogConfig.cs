using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogIndex
{
    PauseDialog = 1,
    WinDialog = 2,
}
public class DialogParam
{

}
public class WinDialogParam : DialogParam
{
    public ConfigLevelRecord cf_level;
}

public class DialogConfig 
{
    public static DialogIndex[] dialogIndices =
    {
        DialogIndex.PauseDialog,
        DialogIndex.WinDialog,
    };
}
