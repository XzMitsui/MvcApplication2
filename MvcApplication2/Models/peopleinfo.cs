//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class peopleinfo
    {
        public int ID { get; set; }
        [Display(Name="姓名")]
        [Required(ErrorMessage="姓名不能为空")]
        public string Name { get; set; }
        [Display(Name="地址")]
        [Required(ErrorMessage="地址不能为空")]
        public string Address { get; set; }
    }
}