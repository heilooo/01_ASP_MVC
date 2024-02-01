using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace app6_web.Models
{
    public class Category
    {
        [Key] public int Id { get; set; }
        [Required(ErrorMessage ="لطفا نام دسته را وارد کنید")][DisplayName("عنوان دسته")]public string Name { get; set; }
        [Required(ErrorMessage ="ترتیب نمایش اجباری است")]
        [Range(1,100,ErrorMessage ="ترتیب نمایش باید بین 1 تا 100 باشد")]
        [DisplayName("ترتیب نمایش")] public string DisplayOrder { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}
