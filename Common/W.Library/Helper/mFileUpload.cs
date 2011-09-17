using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace W.Library.Helper
{
    public class mFileUpload
    {
        #region Constructors
        /// <summary>
        /// 文件上传构造器
        /// </summary>
        public mFileUpload() { }
        /// <summary>
        /// 文件上传构造器
        /// </summary>
        /// <param name="postedFile">上传的文件对象</param>
        /// <param name="saveFolderPath">保存文件的目录Url形式的相对目录 如：/upload/test/</param>
        /// <param name="saveFileName">保存的文件名（含扩展名）</param>
        public mFileUpload(HttpPostedFile postedFile, string saveFolderPath, string saveFileName)
        {
            PostedFile = postedFile;
            SaveFolderPath = saveFolderPath;
            SaveFileName = SaveFileName;
        }

        /// <summary>
        /// 文件上传构造器
        /// </summary>
        /// <param name="postedFile">上传的文件对象</param>
        /// <param name="saveFolderPath">保存文件的目录Url形式的相对目录 如：/upload/test/</param>
        /// <param name="saveFileName">保存的文件名（含扩展名）</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="allowedFileTypes">允许上传文件类型 多个请用逗号隔开，如：rar,jpg,gif。 为空或者“*”时将不限上传类型。</param>
        public mFileUpload(HttpPostedFile postedFile, string saveFolderPath, string saveFileName, string allowedFileTypes, int allowedMaxSize)
        {
            PostedFile = postedFile;
            SaveFolderPath = saveFolderPath;
            SaveFileName = saveFileName;
            AllowedFileTypes = allowedFileTypes;
            AllowedMaxSize = allowedMaxSize;
        }
        #endregion

        #region Properties

        private HttpPostedFile postedFile;
        /// <summary>
        /// 上传的文件对象
        /// </summary>
        public HttpPostedFile PostedFile
        {
            get { return postedFile; }
            set { postedFile = value; }
        }

        private string saveFolderPath;
        /// <summary>
        /// 保存文件的目录Url形式的相对目录
        /// 如：/upload/test/
        /// </summary>
        public string SaveFolderPath
        {
            get { return saveFolderPath; }
            set { saveFolderPath = value; }
        }

        private string saveFileName;
        /// <summary>
        /// 保存的文件名（含扩展名）
        /// </summary>
        public string SaveFileName
        {
            get { return saveFileName; }
            set { saveFileName = value; }
        }

        private string errors = string.Empty;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Errors
        {
            get { return errors; }
        }

        private int allowedMaxSize = 999999999;
        /// <summary>
        /// 上传文件大小上限 单位：KB
        /// </summary>
        public int AllowedMaxSize
        {
            get { return allowedMaxSize; }
            set { allowedMaxSize = value; }
        }

        private string allowedFileTypes = "";
        /// <summary>
        /// 允许上传文件类型
        /// 多个请用逗号隔开，如：rar,jpg,gif
        /// 为空或者“*”时将不限上传类型。
        /// </summary>
        public string AllowedFileTypes
        {
            get { return allowedFileTypes; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value != "*")
                {
                    if (!value.StartsWith(","))
                    {
                        value = "," + value;
                    }
                    if (!value.EndsWith(","))
                    {
                        value = value + ",";
                    }

                    allowedFileTypes = value;
                }
            }
        }


        private string uploadedFilePath;
        /// <summary>
        /// 上传后的文件路径
        /// </summary>
        public string UploadedFilePath
        {
            get { return uploadedFilePath; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns>是否上传成功</returns>
        public bool UploadFile()
        {
            #region 验证

            #region 参数验证
            if (string.IsNullOrEmpty(SaveFolderPath))
            {
                errors = "上传文件保存目录不能为空！";
                return false;
            }
            #endregion

            #endregion

            string physicalSavePath = HttpContext.Current.Server.MapPath(saveFolderPath);

            return UploadFile(physicalSavePath);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="physicalSavePath">上传保存的物理地址</param>
        /// <returns>是否上传成功</returns>
        public bool UploadFile(string physicalSavePath)
        {
            #region 验证

            #region 参数验证
            if (null == PostedFile)
            {
                errors = "上传对象PostedFile不能为空！";
                return false;
            }
            if (string.IsNullOrEmpty(PostedFile.FileName))
            {
                errors = "上传文件不存在！";
                return false;
            }
            if (string.IsNullOrEmpty(physicalSavePath))
            {
                errors = "上传文件保存物理目录不能为空！";
                return false;
            }
            if (string.IsNullOrEmpty(SaveFileName))
            {
                errors = "上传文件保存文件名不能为空！";
                return false;
            }
            if (allowedMaxSize <= 0)
            {
                errors = "允许上传文件大小必须大于零！";
                return false;
            }
            #endregion

            #region 文件大小判断

            int fileLength = PostedFile.ContentLength;

            if (string.IsNullOrEmpty(PostedFile.FileName) || PostedFile.ContentLength <= 0)
            {
                errors = "没有选定被上传的文件！";
                return false;
            }
            if (fileLength / 1024 > AllowedMaxSize)
            {
                errors = string.Format("文件超出规定大小{0}KB！", allowedMaxSize);
                return false;
            }

            #endregion

            #region 文件扩展名判断

            if (!(string.IsNullOrEmpty(AllowedFileTypes) || AllowedFileTypes == "*") &&
                AllowedFileTypes.IndexOf("," + Path.GetExtension(PostedFile.FileName).Replace(".", "").ToLower() + ",") < 0)
            {
                errors = "文件必须是以" + AllowedFileTypes + "为扩展名的文件";
                return false;
            }

            #endregion

            #endregion

            #region 上传文件
            string filePath = mUrl.Combine(SaveFolderPath, SaveFileName);
            SaveFolderPath = physicalSavePath;

            if (!Directory.Exists(SaveFolderPath))
            {
                try
                {
                    Directory.CreateDirectory(SaveFolderPath);
                }
                catch
                {
                    errors = "创建上传目录失败！";
                    return false;
                }
            }


            uploadedFilePath = Path.Combine(SaveFolderPath, SaveFileName);

            try
            {
                PostedFile.SaveAs(uploadedFilePath);
                uploadedFilePath = filePath;
            }
            catch
            {
                errors = "上传文件保存失败！";
                uploadedFilePath = string.Empty;
                return false;
            }
            #endregion

            return string.IsNullOrEmpty(errors);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="postedFile">上传的文件对象</param>
        /// <param name="saveFolderPath">保存文件的目录Url形式的相对目录 如：/upload/test/</param>
        /// <param name="saveFileName">保存的文件名（含扩展名）</param>
        /// <returns>是否上传成功</returns>
        public bool UploadFile(HttpPostedFile postedFile, string saveFolderPath, string saveFileName)
        {
            PostedFile = postedFile;
            SaveFolderPath = saveFolderPath;
            SaveFileName = saveFileName;

            return UploadFile();
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="postedFile">上传的文件对象</param>
        /// <param name="saveFolderPath">保存文件的目录Url形式的相对目录 如：/upload/test/</param>
        /// <param name="saveFileName">保存的文件名（含扩展名）</param>
        /// <param name="allowedFileTypes">允许上传文件类型 多个请用逗号隔开，如：rar,jpg,gif。 为空或者“*”时将不限上传类型。</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="errors">错误信息</param>
        /// <returns>是否上传成功</returns>
        public static bool UploadFile(HttpPostedFile postedFile, string saveFolderPath, string saveFileName,
             string allowedFileTypes, int allowedMaxSize, out string errors)
        {
            mFileUpload fu = new mFileUpload(postedFile, saveFolderPath, saveFileName, allowedFileTypes, allowedMaxSize);
            bool results = fu.UploadFile();
            errors = fu.Errors;
            return results;

        }

        #endregion
    }
}
