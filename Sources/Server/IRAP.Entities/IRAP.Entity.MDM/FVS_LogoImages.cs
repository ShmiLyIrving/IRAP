using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// Logo图片信息
    /// </summary>
    public class FVS_LogoImages
    {
        /// <summary>
        /// 公司Logo图片(Base64转换)
        /// </summary>
        public string CompanyLogoImage { get; set; }
        /// <summary>
        /// 客户Logo图片(Base64转换)
        /// </summary>
        public string CustomerLogoImage { get; set; }
        /// <summary>
        /// 客户产品图片(Base64转换)
        /// </summary>
        public string CustomerProductImage { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public Image CompanyLogo
        {
            get { return Base64ToImage(CompanyLogoImage); }
        }
        [IRAPORMMap(ORMMap =false)]
        public Image CustomerLogo
        {
            get { return Base64ToImage(CustomerLogoImage); }
        }
        [IRAPORMMap(ORMMap =false)]
        public Image CustomerProduct
        {
            get { return Base64ToImage(CustomerProductImage); }
        }

        private Image Base64ToImage(string stringBase64)
        {
            byte[] imageBytes;
            try
            {
                imageBytes = Convert.FromBase64String(stringBase64);
                return Tools.BytesToImage(imageBytes);
            }
            catch 
            {
                return null;
            }
        }

        public FVS_LogoImages Clone()
        {
            return MemberwiseClone() as FVS_LogoImages;
        }
    }
}