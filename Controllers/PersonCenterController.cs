using CSum.Application.Dtos;
using CSum.Application.Service;
using CSum.Core;
using CSum.Runtime.Session;
using CSum.Util;
using CSum.Util.Extension;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace CSum.WebUI
{
    /// <summary>
    /// 描 述：个人中心
    /// </summary>
    public class PersonCenterController : MvcControllerBase
    {
        public IUserService UserService { get; set; }

        #region 视图功能
        /// <summary>
        /// 个人中心
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.userId = SessionManager.Instance.Current().UserId;
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerifyCode()
        {
            string chkCode = "";
            var byts = VerifyCodeHelper.GetVerifyCode(out chkCode);
            //写入Session、验证码加密
            WebHelper.WriteSession("session_verifycode", Md5Helper.MD5(chkCode.ToLower(), 16));
            return File(byts, @"image/Gif");
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存个人信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, UserCenterFormDto dto)
        {
            var user = UserService.GetEntity<UserFormDto>(keyValue);
            user.Description = dto.Description;
            user.Email = dto.Email;
            user.Mobile = dto.Mobile;
            UserService.SaveUserForm(keyValue, user);
            return Success("操作成功。");
        }

        /// <summary>
        /// 上传头像  TODO:重新优化
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadFile()
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            //没有文件上传，直接返回
            if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName))
            {
                return HttpNotFound();
            }
            //string FileEextension = Path.GetExtension(files[0].FileName);
            //string UserId = OperatorProvider.Provider.Current().UserId;
            //string virtualPath = string.Format("/Resource/PhotoFile/{0}{1}", UserId, FileEextension);
            //string fullFileName = Server.MapPath("~" + virtualPath);
            ////创建文件夹，保存文件
            //string path = Path.GetDirectoryName(fullFileName);
            //Directory.CreateDirectory(path);
            //files[0].SaveAs(fullFileName);

            //UserService.UpdateHeadIcon(OperatorProvider.Provider.Current().UserId, virtualPath);
            return Success("上传成功。");
        }
        /// <summary>
        /// 验证旧密码
        /// </summary>
        /// <param name="OldPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ValidationOldPassword(string OldPassword)
        {
            //OldPassword = Md5Helper.MD5(DESEncrypt.Encrypt(Md5Helper.MD5(OldPassword, 32).ToLower(), OperatorProvider.Provider.Current().Secretkey).ToLower(), 32).ToLower();
            //if (OldPassword != OperatorProvider.Provider.Current().Password)
            //{

            //    return Error("原密码错误，请重新输入");
            //}
            //else
            //{
            //    return Success("通过信息验证");
            //}
            return Success("通过信息验证");
        }
        /// <summary>
        /// 提交修改密码
        /// </summary>
        /// <param name="password">新密码</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="verifyCode">验证码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitResetPassword(string password, string oldPassword, string verifyCode)
        {
            var user = UserService.GetEntity<UserEntryDto>(SessionManager.Instance.Current().UserId);
            verifyCode = Md5Helper.MD5(verifyCode.ToLower(), 16);
            if (Session["session_verifycode"].IsEmpty() || verifyCode != Session["session_verifycode"].ToString())
            {
                return Error("验证码错误，请重新输入");
            }

            oldPassword = Md5Helper.MD5(DESEncrypt.Encrypt(oldPassword, user.Secretkey).ToLower(), 32).ToLower();
            if (oldPassword != user.Password)
            {
                return Error("原密码错误，请重新输入");
            }
            if (SessionManager.Instance.Current().IsSystem)
            {
                return Error("当前账户不能修改密码");
            }

            UserService.RevisePassword(user.Id, password.ToLower());
            Session.Abandon(); Session.Clear();
            return Success("密码修改成功，请牢记新密码。\r 将会自动安全退出。");
        }
        #endregion
    }
}
