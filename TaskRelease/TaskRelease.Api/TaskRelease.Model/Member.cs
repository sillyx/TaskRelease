using System;

namespace TaskRelease.Model
{
    [Serializable]
   public class Member
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 证件编号
        /// </summary>
        public string SertId { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 类型（个人 or boss）
        /// </summary>
        public int Category { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public string RegisterDate { get; set; }
        /// <summary>
        /// 个人头像
        /// </summary>
        public string HeadImageUrl { get; set; }
        /// <summary>
        /// 资料完整度
        /// </summary>
        public string Completed { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        public string QQNo { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
     

    }
}
