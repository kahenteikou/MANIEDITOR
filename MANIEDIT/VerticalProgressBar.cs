using System;
using System.Windows.Forms;
using System.Security.Permissions;

/// <summary>
/// 垂直ProgressBarコントロールを表します。
/// </summary>
public class VerticalProgressBar : ProgressBar
{
    private int PBS_VERTICAL = 0x0004;

    protected override CreateParams CreateParams
    {
        [SecurityPermission(SecurityAction.Demand,
            Flags = SecurityPermissionFlag.UnmanagedCode)]
        get
        {
            CreateParams cps = base.CreateParams;
            //コントロールのスタイルにPBS_VERTICALを追加する
            cps.Style |= PBS_VERTICAL;
            return cps;
        }
    }
}
