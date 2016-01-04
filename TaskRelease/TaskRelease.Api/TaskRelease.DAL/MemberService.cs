using System;
using System.Collections.Generic;
using System.Text;
using TaskRelease.Model;
using TaskRelease.Utility;
using SingleTableCRUD;
using System.Data.SqlClient;



namespace TaskRelease.DAL
{
    public class MemberService
    {
        private Service _service;
        public MemberService()
        {
            _service = new Service();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginId">登录名(邮箱，手机号,用户名)</param>
        /// <returns></returns>
        public Member UserLogin(string loginId)
        {
            string sql = string.Format(@"SELECT [Id]
                                      ,[RealName]
                                      ,[PhoneNo]
                                      ,[Category]
                                      ,[HeadImageUrl]
                                      ,[Completed]
                                      ,[SertId]
                                      ,[UserName]
                                      ,[QQNo]
                                      ,[Email]
                                      ,[Gender]
                                  FROM [Member] where PhoneNo='{0}' or Email='{0}' or UserName='{0}'", loginId);

            try
            {
                var ds = SqlDBHelper.Query(sql);
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return DataTableHelper.ToEntity<Member>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                ex.WriterLog("TaskRelease.DAL.dll", "MemberService", "UserLogin");
                return null;
            }
        }

        public bool Insert(Member member)
        {
            try
            {
                return _service.Insert(member);
            }
            catch (Exception ex)
            {
                ex.WriterLog("TaskRelease.DAL", "MemberService", "Insert");
                return false;
            }

        }

        public bool Update(Member member)
        {
            try
            {
                return _service.Update(member);
            }
            catch (Exception ex)
            {
                ex.WriterLog("TaskRelease.DAL", "MemberService", "Update");
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                return _service.Delete<Member>(id);
            }
            catch (Exception ex)
            {
                ex.WriterLog("TaskRelease.DAL", "MemberService", "Delete");
                return false;
            }
        }

        public Member GetMemeberById(string id)
        {
            const string sql = @"SELECT [Id]
                          ,[RealName]
                          ,[PhoneNo]
                          ,[Category]
                          ,[RegisterDate]
                          ,[HeadImageUrl]
                          ,[Completed]
                          ,[SertId]
                          ,[UserName]
                          ,[QQNo]
                          ,[Email]
                          ,[Gender]
                      FROM [Member] where Id=@Id";
            var parm = new[]
                {
                    new SqlParameter("@Id",id)
                };
            try
            {
                var ds = SqlDBHelper.Query(sql, parm);
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return DataTableHelper.ToEntity<Member>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                ex.WriterLog("TaskRelease.DAL.dll", "MemberService", "GetMemeberById");
                return null;

            }


        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="condition"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public IList<Member> GetMember(int pageindex, int pagesize, out int totalCount, string condition = "1=1", string order = "RegisterDate", string ordertype = "desc")
        {
            totalCount = 0;
            var sqlBuider = new StringBuilder();
            sqlBuider.AppendFormat(" select * from (select ROW_NUMBER() OVER(order by {0} {1}) RowIndex,Id,RealName,PhoneNo, ", order, ordertype);
            sqlBuider.Append(" Category,RegisterDate,HeadImageUrl,Completed,SertId,UserName,QQNo,");
            sqlBuider.AppendFormat("Email,Gender from Member where {2} )b where  {2} and RowIndex >={0} and RowIndex <= {1} ;", (pageindex - 1) * pagesize, pageindex * pagesize);
            sqlBuider.AppendFormat(" select count(1) from (select ROW_NUMBER() OVER(order by {0} {1}) RowIndex,Id,RealName,PhoneNo, ", order, ordertype);
            sqlBuider.Append(" Category,RegisterDate,HeadImageUrl,Completed,SertId,UserName,QQNo,");
            sqlBuider.AppendFormat("Email,Gender from Member where {2} )b where  {2} ;");
            var ds = SqlDBHelper.Query(sqlBuider.ToString());
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                totalCount = ds.Tables[1].Rows[0][0].ToInt();
                return DataTableHelper.ToList<Member>(ds.Tables[0]);
            }
            return null;
        }
    }
}
