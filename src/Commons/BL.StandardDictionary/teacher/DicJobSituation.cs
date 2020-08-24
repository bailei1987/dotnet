using System;
using System.Collections.Generic;
using System.Text;

namespace BL.StandardDictionary
{
    /// <summary>
    /// 在岗情况
    /// </summary>
    public class DicJobSituation : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","在岗"),
                new DicItem("2","抽调"),
                new DicItem("3","驻村"),
                new DicItem("4","产假"),
                new DicItem("5","外聘"),
                new DicItem("6","聘用"),
                new DicItem("7","无"),

            };

        }
    }
}
