using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediaService.Common
{
    public static class DataHelper
    {
        #region 数据转换
        /// <summary>
        /// 获取string类型数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return string.Empty;
            }
            return obj.ToString();
        }

        /// <summary>
        /// 获取int型数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetInt32(object obj)
        {
            int result = 0;

            if (obj != DBNull.Value && obj != null)
            {
                if (!int.TryParse(obj.ToString(), out result))
                    throw new Exception("整形转换失败");
            }
            return result;
        }

        public static Guid GetGuid(object obj)
        {
            Guid result = Guid.Empty;
            if (obj != DBNull.Value && obj != null)
            {
               if(! Guid.TryParse(obj.ToString(),out result))
                    throw new Exception("Guid类型转换失败");
            }
            return result;
        }

        /// <summary>        
        /// 获取双精度类型数据
        /// </summary>   
        /// <param name="obj"></param>
        /// <returns></returns>         
        public static double GetDouble(object obj)
        {
            double result = 0.00;
            if (obj != DBNull.Value && obj != null)
            {
                if (!double.TryParse(obj.ToString(), out result))
                    throw new Exception("双精度类型转换失败");
            }
            return result;
        }

        /// <summary>         
        /// 获取decimal类型数据        
        /// </summary>         
        /// <param name="obj"></param> 
        /// <returns></returns>         
        public static decimal GetDecimal(object obj)
        {
            decimal result = 0.00m;
            if (obj != DBNull.Value && obj != null)
            {
                if (!decimal.TryParse(obj.ToString(), out result))
                    throw new Exception("Decimal类型转换失败");
            }
            return result;
        }


        /// <summary>         
        /// 获取bool类型数据如果传值是1或者是返回true;       
        /// </summary>       
        /// <param name="obj"></param>
        /// <returns></returns>         
        public static bool GetBool(object obj)
        {
            if (obj != DBNull.Value && obj != null)
            {
                return obj.ToString() == "1" || obj.ToString() == "是" || obj.ToString().ToLower() == "true";
            }
            return false;
        }

        /// <summary>         
        /// 获取DateTime类型数据        
        /// </summary>         
        ///<param name="obj"></param>
        /// <returns></returns>       
        public static DateTime GetDateTime(object obj)
        {
            DateTime result = DateTime.Now;
            if (obj != DBNull.Value && obj != null)
            {
                if (!DateTime.TryParse(obj.ToString(), out result))
                    throw new Exception("日期格式数据转换失败");
            }
            return result;
        }

        /// <summary>
        /// 将字符串转为guid类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid GetGuid(string obj)
        {
            try
            {
                Guid guid = new Guid(obj);
                return guid;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 通过反射将DataTable转为List泛型集合
        public static List<T> GetList<T>(DataTable table)
        {
            List<T> list = new List<T>();
            T t = default(T);
            PropertyInfo[] propertypes = null;
            string tempName = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                t = Activator.CreateInstance<T>();
                propertypes = t.GetType().GetProperties();
                foreach (PropertyInfo pro in propertypes)
                {
                  
                    tempName = pro.Name;
                    if (table.Columns.Contains(tempName))
                    {
                        object value = string.Empty;
                        var propertyType = Nullable.GetUnderlyingType(pro.PropertyType) ?? pro.PropertyType;
                        #region 判断table中数据类型
                        switch (propertyType.Name)
                        {
                            case "Guid":
                                value = DataHelper.GetGuid(row[tempName]);
                                break;
                            case "Int32":
                                value = DataHelper.GetInt32(row[tempName]);
                                break;
                            case "String":
                                value = DataHelper.GetString(row[tempName]);
                                break;
                            case "Decimal":
                                value = DataHelper.GetDecimal(row[tempName]);
                                break;
                            case "Double":
                                value = DataHelper.GetDouble(row[tempName]);
                                break;
                            case "DateTime":
                                value = DataHelper.GetDateTime(row[tempName]);
                                break;
                            default:
                                value = row[tempName];
                                break;
                        }
                        #endregion
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            pro.SetValue(t, value);
                        }
                        else {
                            pro.SetValue(t, string.Empty);
                        }
                    }
                }
                list.Add(t);
            }
            return list.Count == 0 ? null : list;
        }
        #endregion

        #region 通过反射将DataTable转为泛型对象
        public static T GetModel<T>(DataTable table)
        {
            T t = default(T);
            PropertyInfo[] propertypes = null;
            string tempName = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                t = Activator.CreateInstance<T>();
                propertypes = t.GetType().GetProperties();
                foreach (PropertyInfo pro in propertypes)
                {
                    tempName = pro.Name;
                    if (table.Columns.Contains(tempName))
                    {
                        object value = string.Empty;
                        #region 判断table中数据类型
                        switch (pro.PropertyType.Name)
                        {
                            case "Int32":
                                value = DataHelper.GetInt32(row[tempName]);
                                break;
                            case "Nullable":
                                break;
                            case "String":
                                value = DataHelper.GetString(row[tempName]);
                                break;
                            case "Decimal":
                                value = DataHelper.GetDecimal(row[tempName]);
                                break;
                            case "Double":
                                value = DataHelper.GetDouble(row[tempName]);
                                break;
                            case "DateTime":
                                value = DataHelper.GetDateTime(row[tempName]);
                                break;
                            default:
                                value = row[tempName];
                                break;
                        }
                        #endregion
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            pro.SetValue(t, value);
                        }
                    }
                  
                }
            }
            return t;
        }
        #endregion


        #region 将List集合类转换成DataTable

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="list">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> entitys)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }


        #endregion


    }
}
