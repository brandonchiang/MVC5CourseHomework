namespace Homework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人
    {
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        [Email不可重覆]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [RegularExpression(@"\d{4}-\d{6}",ErrorMessage ="格式應為：前4位數字-後6位數字")]
        //[手機格式]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        public bool IsDeleted { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }
    }

    public partial class Email不可重覆Attribute : DataTypeAttribute
    {
        public Email不可重覆Attribute():base(DataType.Text)
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            客戶聯絡人Repository repo客戶聯絡人 = RepositoryHelper.Get客戶聯絡人Repository();

            var context = (客戶聯絡人)validationContext.ObjectInstance;

            var valid=repo客戶聯絡人.CheckEmail(context.Id, value.ToString());

            if (!valid)
                return new ValidationResult("同一個客戶下的聯絡人，Email 不能重複"); 
            else
                return null;
            //return base.IsValid(value, validationContext);
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}
