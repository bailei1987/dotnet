using System.ComponentModel.DataAnnotations;

namespace BL.Dto
{
    public class ExportFieldDto
    {
        public ExportFieldDto() { }
        public ExportFieldDto(string model, string field, string name)
        {
            Model = model;
            Field = field;
            Name = name;
        }
        /// <summary>
        /// 字段所属属性名
        /// </summary>
        [Required]
        public string Model { get; set; }
        /// <summary>
        /// 要导出的字段
        /// </summary>
        [Required]
        public string Field { get; set; }
        /// <summary>
        /// 要导出的字段中文
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
