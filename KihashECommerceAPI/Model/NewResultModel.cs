using System.ComponentModel.DataAnnotations;

namespace KihashECommerceAPI.Model
{
    public class NewResultModel
    {
        [Key]
        public int  Id {  get; set; }
        public string  Name { get; set; }
    }
}
