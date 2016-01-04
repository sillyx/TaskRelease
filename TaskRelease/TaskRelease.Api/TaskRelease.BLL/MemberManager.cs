using System.Collections.Generic;
using TaskRelease.Model;
using TaskRelease.DAL;
using TaskRelease.Utility;

namespace TaskRelease.BLL
{
    public class MemberManager
    {
        private MemberService _service;
        public MemberManager()
        {
            _service = new MemberService();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="pwd"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserLoginState UserLogin(string loginId, string pwd, out Member user)
        {
            var member = _service.UserLogin(loginId);
            if (member == null)
            {
                user = null;
                return UserLoginState.NoExist;
            }
            if (!member.Pwd.CompareNotIgnoreCase(pwd.ToMD5()))
            {
                user = null;
                return UserLoginState.PwdError;
            }
            user = member;
            return UserLoginState.Succeed;
        }

        public bool Insert(Member member)
        {
            return _service.Insert(member);
        }

        public bool Update(Member member)
        {
            return _service.Update(member);
        }

        public bool Delete(string id)
        {
            return _service.Delete(id);
        }

        public Member GetMemeberById(string id)
        {
            return _service.GetMemeberById(id);
        }

        //用户列表 
        public IList<Member> GetMember(int pageindex, int pagesize, out int totalCount, string condition,
                                       string order, string ordertype)
        {
            return _service.GetMember(pageindex, pagesize, out totalCount, condition, order, ordertype);
        }
    }
}
