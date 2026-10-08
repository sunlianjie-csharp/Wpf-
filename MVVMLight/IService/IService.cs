using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLigtDemo.IService
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">增删改的时候操作表</typeparam>
    /// <typeparam name="K">查的时候差视图</typeparam>
    public interface IService<T, K>where T : class, new()where K : class, new()
    {
        /// <summary>
        /// 向某个表中添加数据
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns>布尔，true成功，false失败</returns>
        bool Add(T model);

        /// <summary>
        /// 修改某个表中的数据
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns>布尔，true成功，false失败</returns>
        bool Update(T model);

        /// <summary>
        /// 根据表的主键删除一条记录，逻辑删除
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns>布尔，true成功，false失败</returns>
        bool Delete(int primaryKey);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="exp">查询表达式</param>
        /// <returns>泛型列表</returns>
        List<K> GetList(Expressionable<K> exp);

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="exp">查询表达式</param>
        /// <param name="page">当前页码</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <param name="totalCount">记录数</param>
        /// <returns></returns>
        List<K> GetListByPage(Expressionable<K> exp, int page, int pageSize, ref int totalCount);

        /// <summary>
        /// 根据主键获取一个实体模型
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns>一个实体模型</returns>
        T GetModel(int primaryKey);
    }
}
