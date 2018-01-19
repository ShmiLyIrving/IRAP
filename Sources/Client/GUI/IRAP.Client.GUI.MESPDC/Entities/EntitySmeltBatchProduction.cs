using IRAP.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IRAP.Client.GUI.MESPDC.Entities {
    public class SmeltMaterialItemClient {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// 原材料叶标识
        /// </summary>
        public int T101LeafID { get; set; }

        /// <summary>
        /// 原材料代码
        /// </summary>
        public string T101Code { get; set; }

        /// <summary>
        /// 原材料名称
        /// </summary>
        public string T101Name { get; set; }

        /// <summary>
        /// 默认放大数量级
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// 历史记录  暂时不用考略
        /// </summary>
        public string DataXML { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public int LotNumber { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public long Qty { get; set; }

        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly {
            get { return this._isReadOnly; }
            set { this._isReadOnly = value; }
        }
        private bool _isReadOnly = false;

        public static SmeltMaterialItemClient Mapper<SmeltMaterialItemClient, SmeltMaterialItem>(SmeltMaterialItem s) {
            SmeltMaterialItemClient d = Activator.CreateInstance<SmeltMaterialItemClient>();
            try {
                var Types = s.GetType();//获得类型  
                var Typed = typeof(SmeltMaterialItemClient);
                foreach (PropertyInfo sp in Types.GetProperties())//获得类型的属性字段  
               {
                    foreach (PropertyInfo dp in Typed.GetProperties()) {
                        if (dp.Name == sp.Name)//判断属性名是否相同  
                       {
                            dp.SetValue(d, sp.GetValue(s, null), null);//获得s对象属性的值复制给d对象的属性  
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
            return d;
        } 

    }

    public class SmeltMethodItemClient {

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// 检验项目叶标识
        /// </summary>
        public int T20LeafID { get; set; }

        /// <summary>
        /// 检验项目代码
        /// </summary>
        public string T20Code { get; set; }

        /// <summary>
        /// 检验项目名称
        /// </summary>
        public string T20Name { get; set; }

        /// <summary>
        /// 默认放大数量级
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// 历史记录  暂时不用考略
        /// </summary>
        public string DataXML { get; set; }

        /// <summary>
        /// 生产开炉参数值
        /// </summary>
        public string Value { get; set; }

        public static SmeltMethodItemClient Mapper<SmeltMethodItemClient, SmeltMethodItem>(SmeltMethodItem s) {
            SmeltMethodItemClient d = Activator.CreateInstance<SmeltMethodItemClient>();
            try {
                var Types = s.GetType();//获得类型  
                var Typed = typeof(SmeltMethodItemClient);
                foreach (PropertyInfo sp in Types.GetProperties())//获得类型的属性字段  
               {
                    foreach (PropertyInfo dp in Typed.GetProperties()) {
                        if (dp.Name == sp.Name)//判断属性名是否相同  
                       {
                            dp.SetValue(d, sp.GetValue(s, null), null);//获得s对象属性的值复制给d对象的属性  
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
            return d;
        } 
    }

    public enum Optype { 
        Spectrum,Sample,Baked 
    }

}
