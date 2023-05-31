using System;
namespace BL.DataSync.Server
{
    /// <summary>
    /// 字段池设置.每个字段均为唯一注册
    /// </summary>
    public class FieldsPoolItem
    {
        public FieldsPoolItem()
        {
        }
        /// <summary>
        /// 数据集(学生,教师,etc)
        /// </summary>
        public string Ds { get; set; }
        /// <summary>
        /// 字段/属性(Info_Name,Info_Sex,etc)
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 来源,每个字段的值只能由一个来源变更(通常为API),如学生姓名,仅由学生API更新
        /// </summary>
        public string Origin { get; set; }
    }
    /// <summary>
    /// 字段变更跟踪者(字段变更后,向对方发送最新值)
    /// </summary>
    public class FieldTracker
    {
        public string Tracker { get; set; }

    }
}
