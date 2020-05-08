namespace BL.StandardDictionary
{
    /// <summary>
    /// JSLX 教室类型代码 JT1001
    /// </summary>
    public class DicClassRoomType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","多媒体教室"),
                new DicItem("2","语音室"),
                new DicItem("3","实验室"),
                new DicItem("4","计算机房"),
                new DicItem("5","普通教室"),
                new DicItem("6","专用教室"),
                new DicItem("9","其他"),

                #region 中华职校扩展

                new DicItem("21","办公室"),
                new DicItem("22","实训室"),
                new DicItem("23","心理室"),
                new DicItem("24","厨房"),
                new DicItem("25","监控室"),
                new DicItem("26","会议室"),
                new DicItem("27","图书馆"),
                new DicItem("28","卫生室"),
                new DicItem("29","更衣室"),
                new DicItem("30","档案室")

                #endregion
            };
            
        }
    }
}
