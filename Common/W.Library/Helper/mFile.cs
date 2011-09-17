using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace W.Library.Helper
{
    public class mFile
    {
        private static HttpContext context = HttpContext.Current;

        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public static void CopyFile(string from, string to)
        {
            from = HttpContext.Current.Server.MapPath(from);
            to = HttpContext.Current.Server.MapPath(to);
            if (File.Exists(from))
                File.Copy(from, to, true);
        }

        /// <summary>
        /// 以指定的ContentType输出指定文件文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="filename">输出的文件名</param>
        /// <param name="filetype">将文件输出时设置的ContentType</param>
        public static void ResponseFile(string filepath, string filename, string filetype)
        {
            Stream iStream = null;

            // 缓冲区为10k
            byte[] buffer = new Byte[10000];
            // 文件长度
            int length;
            // 需要读的数据长度
            long dataToRead;

            try
            {
                // 打开文件
                iStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
                // 需要读的数据长度
                dataToRead = iStream.Length;

                context.Response.ContentType = filetype;
                context.Response.AddHeader("Content-Disposition", "attachment;filename=" + mUrl.Encode(filename.Trim()).Replace("+", " "));

                while (dataToRead > 0)
                {
                    // 检查客户端是否还处于连接状态
                    if (context.Response.IsClientConnected)
                    {
                        length = iStream.Read(buffer, 0, 10000);
                        context.Response.OutputStream.Write(buffer, 0, length);
                        context.Response.Flush();
                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        // 如果不再连接则跳出死循环
                        dataToRead = -1;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (iStream != null)
                {
                    // 关闭文件
                    iStream.Close();
                }
            }
            context.Response.End();
        }

        /// <summary>
        /// 返回指定目录下的非 UTF8 字符集文件
        /// </summary>
        /// <param name="Path">路径</param>
        /// <returns>文件名的字符串数组</returns>
        public static List<string> FindNoUTF8File(string Path)
        {
            List<string> files = new List<string>();
            DirectoryInfo Folder = new DirectoryInfo(Path);
            FileInfo[] subFiles = Folder.GetFiles();
            for (int j = 0; j < subFiles.Length; j++)
            {
                if (subFiles[j].Extension.ToLower().Equals(".htm"))
                {
                    FileStream fs = new FileStream(subFiles[j].FullName, FileMode.Open, FileAccess.Read);
                    bool bUtf8 = IsUTF8(fs);
                    fs.Close();
                    if (!bUtf8)
                    {
                        files.Add(subFiles[j].FullName);
                    }
                }
            }

            return files;

        }

        //0000 0000-0000 007F - 0xxxxxxx  (ascii converts to 1 octet!)
        //0000 0080-0000 07FF - 110xxxxx 10xxxxxx    ( 2 octet format)
        //0000 0800-0000 FFFF - 1110xxxx 10xxxxxx 10xxxxxx (3 octet format)

        /// <summary>
        /// 判断文件流是否为UTF8字符集
        /// </summary>
        /// <param name="sbInputStream">文件流</param>
        /// <returns>判断结果</returns>
        private static bool IsUTF8(FileStream sbInputStream)
        {
            int i;
            byte cOctets;  // octets to go in this UTF-8 encoded character 
            byte chr;
            bool bAllAscii = true;
            long iLen = sbInputStream.Length;

            cOctets = 0;
            for (i = 0; i < iLen; i++)
            {
                chr = (byte)sbInputStream.ReadByte();

                if ((chr & 0x80) != 0) bAllAscii = false;

                if (cOctets == 0)
                {
                    if (chr >= 0x80)
                    {
                        do
                        {
                            chr <<= 1;
                            cOctets++;
                        }
                        while ((chr & 0x80) != 0);

                        cOctets--;
                        if (cOctets == 0) return false;
                    }
                }
                else
                {
                    if ((chr & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    cOctets--;
                }
            }

            if (cOctets > 0)
            {
                return false;
            }

            if (bAllAscii)
            {
                return false;
            }

            return true;

        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileUpload">FileUpload对象</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="saveFileName">保存的文件名称</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadFile(FileUpload fileUpload, string saveFolderPath,
            string saveFileName, string fileTypes, int allowedMaxSize, out string errors)
        {
            mFileUpload fu = new mFileUpload(fileUpload.PostedFile, saveFolderPath, saveFileName, fileTypes, allowedMaxSize);
            fu.UploadFile();
            errors = fu.Errors;
            return fu.UploadedFilePath;
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileUpload">FileUpload对象</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadFile(FileUpload fileUpload, string saveFolderPath,
             string fileTypes, int allowedMaxSize, out string errors)
        {
            if (null == fileUpload || fileUpload.PostedFile.ContentLength <= 0)
            {
                errors = "没有选定被上传的文件！";
                return string.Empty;
            }
            string fileName = fileUpload.FileName;

            //生成文件名
            string saveFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(fileName);

            //生成保存路径
            saveFolderPath = mUrl.Combine(saveFolderPath, DateTime.Now.ToString("yyyyMMdd"));

            string returnfilePath = Path.Combine(saveFolderPath.Substring(saveFolderPath.LastIndexOf("/") + 1), saveFileName);
            UploadFile(fileUpload, saveFolderPath, saveFileName, fileTypes, allowedMaxSize, out  errors);
            if (string.IsNullOrEmpty(errors))
            {
                return returnfilePath.Replace("\\", "/");
            }
            return string.Empty;

        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fileUpload">FileUpload对象</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadImage(FileUpload fileUpload, string saveFolderPath,
            string fileTypes, int allowedMaxSize, out string errors)
        {

            int allowedWidth = 100000;
            int allowedHeight = 100000;
            return UploadImage(fileUpload, saveFolderPath, fileTypes, allowedMaxSize, allowedWidth, allowedHeight, out errors);
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fileUpload">上传FileUpload控件</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="allowedWidth">允许宽度</param>
        /// <param name="allowedHeight">允许高度</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadImage(FileUpload fileUpload, string saveFolderPath,
            string fileTypes, int allowedMaxSize, int allowedWidth, int allowedHeight, out string errors)
        {
            if (null == fileUpload || fileUpload.PostedFile.ContentLength <= 0)
            {
                errors = "没有选定被上传的文件！";
                return string.Empty;
            }

            #region 文件扩展名判断
            if (!string.IsNullOrEmpty(fileTypes) && fileTypes != "*")
            {
                if (!fileTypes.StartsWith(","))
                {
                    fileTypes = "," + fileTypes;
                }
                if (!fileTypes.EndsWith(","))
                {
                    fileTypes = fileTypes + ",";
                }
            }

            if (!(string.IsNullOrEmpty(fileTypes) || fileTypes == "*") &&
                fileTypes.IndexOf("," + Path.GetExtension(fileUpload.FileName).Replace(".", "").ToLower() + ",") < 0)
            {
                errors = "文件必须是以" + fileTypes + "为扩展名的文件";
                return string.Empty;
            }

            #endregion

            string fileName = fileUpload.PostedFile.FileName;
            using (System.Drawing.Image image = System.Drawing.Image.FromStream(fileUpload.PostedFile.InputStream))
            {
                if (image.Width > allowedWidth || image.Height > allowedHeight)
                {
                    errors = string.Format("图片尺寸不符合规定大小{0}X{1}!", allowedWidth, allowedHeight);
                    return string.Empty;
                }
            }



            return UploadFile(fileUpload, saveFolderPath, fileTypes, allowedMaxSize, out errors);

        }

        #region HtmlInputFile

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileUpload">FileUpload对象</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="saveFileName">保存的文件名称</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadFile(HtmlInputFile fileUpload, string saveFolderPath,
            string saveFileName, string fileTypes, int allowedMaxSize, out string errors)
        {
            mFileUpload fu = new mFileUpload(fileUpload.PostedFile, saveFolderPath, saveFileName, fileTypes, allowedMaxSize);
            fu.UploadFile();
            errors = fu.Errors;
            return fu.UploadedFilePath;
        }


        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileUpload">FileUpload对象</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadFile(HtmlInputFile fileUpload, string saveFolderPath,
             string fileTypes, int allowedMaxSize, out string errors)
        {
            if (null == fileUpload || fileUpload.PostedFile.ContentLength <= 0)
            {
                errors = "没有选定被上传的文件！";
                return string.Empty;
            }
            string fileName = fileUpload.PostedFile.FileName;

            //生成文件名
            string saveFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(fileName);

            //生成保存路径
            saveFolderPath = mUrl.Combine(saveFolderPath, DateTime.Now.ToString("yyyyMMdd"));

            string returnfilePath = Path.Combine(saveFolderPath.Substring(saveFolderPath.LastIndexOf("/") + 1), saveFileName);
            UploadFile(fileUpload, saveFolderPath, saveFileName, fileTypes, allowedMaxSize, out  errors);
            if (string.IsNullOrEmpty(errors))
            {
                return returnfilePath.Replace("\\", "/");
            }
            return string.Empty;

        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fileUpload">上传HtmlInputFile控件</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadImage(HtmlInputFile fileUpload, string saveFolderPath,
            string fileTypes, int allowedMaxSize, out string errors)
        {
            if (null == fileUpload || fileUpload.PostedFile.ContentLength <= 0)
            {
                errors = "没有选定被上传的文件！";
                return string.Empty;
            }
            return UploadFile(fileUpload, saveFolderPath, fileTypes, allowedMaxSize, out  errors);
        }
        
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fileUpload">上传FileUpload控件</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="allowedWidth">允许宽度</param>
        /// <param name="allowedHeight">允许高度</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadImage(HtmlInputFile fileUpload, string saveFolderPath,
            string fileTypes, int allowedMaxSize, int allowedWidth, int allowedHeight, out string errors)
        {
            if (null == fileUpload || fileUpload.PostedFile.ContentLength <= 0)
            {
                errors = "没有选定被上传的文件！";
                return string.Empty;
            }

            #region 文件扩展名判断
            if (!string.IsNullOrEmpty(fileTypes) && fileTypes != "*")
            {
                if (!fileTypes.StartsWith(","))
                {
                    fileTypes = "," + fileTypes;
                }
                if (!fileTypes.EndsWith(","))
                {
                    fileTypes = fileTypes + ",";
                }
            }

            if (!(string.IsNullOrEmpty(fileTypes) || fileTypes == "*") &&
                fileTypes.IndexOf("," + Path.GetExtension(fileUpload.PostedFile.FileName).Replace(".", "").ToLower() + ",") < 0)
            {
                errors = "文件必须是以" + fileTypes + "为扩展名的文件";
                return string.Empty;
            }

            #endregion

            string fileName = fileUpload.PostedFile.FileName;
            using (System.Drawing.Image image = System.Drawing.Image.FromStream(fileUpload.PostedFile.InputStream))
            {
                if (image.Width > allowedWidth || image.Height > allowedHeight)
                {
                    errors = string.Format("图片尺寸不符合规定大小{0}X{1}!", allowedWidth, allowedHeight);
                    return string.Empty;
                }
            }
            return UploadImage(fileUpload, saveFolderPath, fileTypes, allowedMaxSize, out errors);

        }
        /// <summary>
        /// 上传图片并生成缩略图
        /// </summary>
        /// <param name="fileUpload">上传FileUpload控件</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="thumbnailWidth">缩略图宽度</param>
        /// <param name="thumbnailHeight">缩略图高度</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadImageAndMakeThumbnail(HtmlInputFile fileUpload, string saveFolderPath,
            string fileTypes, int allowedMaxSize, int thumbnailWidth, int thumbnailHeight,
              out string errors)
        {
            if (null == fileUpload && fileUpload.PostedFile.ContentLength <= 0)
            {
                errors = "没有选定被上传的文件！";
                return string.Empty;
            }

            ThumbnailMode thumbnailMode = ThumbnailMode.AccordingWidth;

            int allowedWidth = 10000;
            int allowedHeight = 10000;
            using (System.Drawing.Image image = System.Drawing.Image.FromStream(fileUpload.PostedFile.InputStream))
            {
                if (image.Width < image.Height)
                {
                    thumbnailMode = ThumbnailMode.AccordingHeight;
                }

            }

            return UploadImageAndMakeThumbnail(fileUpload, saveFolderPath,
              fileTypes, allowedMaxSize, allowedWidth, allowedHeight, thumbnailWidth, thumbnailHeight,
               thumbnailMode, out  errors);
        }

        /// <summary>
        /// 上传图片并生成缩略图
        /// </summary>
        /// <param name="fileUpload">上传FileUpload控件</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="allowedWidth">允许图片宽度</param>
        /// <param name="allowedHeight">允许图片高度</param>
        /// <param name="thumbnailWidth">缩略图宽度</param>
        /// <param name="thumbnailHeight">缩略图高度</param>
        /// <param name="thumbnailMode">缩略类型</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadImageAndMakeThumbnail(HtmlInputFile fileUpload, string saveFolderPath,
            string fileTypes, int allowedMaxSize, int allowedWidth, int allowedHeight, int thumbnailWidth, int thumbnailHeight,
             ThumbnailMode thumbnailMode, out string errors)
        {
            if (null == fileUpload || fileUpload.PostedFile.ContentLength <= 0)
            {
                errors = "没有选定被上传的文件！";
                return string.Empty;
            }

            //上传图片
            string uploadedFileName
                = UploadImage(fileUpload, saveFolderPath, fileTypes, allowedMaxSize, allowedWidth, allowedHeight, out errors);

            if (string.IsNullOrEmpty(uploadedFileName))
            {
                return string.Empty;
            }

            if (!saveFolderPath.EndsWith("/"))
            {
                saveFolderPath = VirtualPathUtility.AppendTrailingSlash(saveFolderPath);
            }


            uploadedFileName = uploadedFileName.Replace(saveFolderPath, "");

            string fullUploadedImagePath = mUrl.Combine(saveFolderPath, uploadedFileName);
            string fullThumbnailPath = mUrl.Combine(saveFolderPath, "t" + uploadedFileName);

            //生成缩略图
            mImage ih = new mImage(thumbnailWidth, thumbnailHeight, (int)WaterType.None, (int)thumbnailMode);
            string thumbnailPath = ih.MakeThumbnail(fullUploadedImagePath, fullThumbnailPath, thumbnailWidth, thumbnailHeight);
            //string thumbnailPath =
            //    Client.Web.mImage.GenThumbnailImage(fullUploadedImagePath, fullThumbnailPath, thumbnailWidth, thumbnailHeight, thumbnailMode);

            return thumbnailPath.Replace(saveFolderPath, "");

        }

        #endregion

        #region HttpPostedFile

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileUpload">FileUpload对象</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="saveFileName">保存的文件名称</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadFile(HttpPostedFile fileUpload, string saveFolderPath,
            string saveFileName, string fileTypes, int allowedMaxSize, out string errors)
        {
            mFileUpload fu = new mFileUpload(fileUpload, saveFolderPath, saveFileName, fileTypes, allowedMaxSize);
            if (!saveFolderPath.StartsWith("/") && saveFolderPath.IndexOf("\\") > 0)
            {
                fu.UploadFile();
            }
            else
            {
                fu.UploadFile(saveFolderPath);
            }
            errors = fu.Errors;
            return fu.UploadedFilePath;
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileUpload">FileUpload对象</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadFile(HttpPostedFile fileUpload, string saveFolderPath,
             string fileTypes, int allowedMaxSize, out string errors)
        {
            if (null == fileUpload || fileUpload.ContentLength <= 0)
            {
                errors = "没有选定被上传的文件！";
                return string.Empty;
            }
            string fileName = fileUpload.FileName;

            //生成文件名
            string saveFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(fileName);

            //生成保存路径
            saveFolderPath = mUrl.Combine(saveFolderPath, DateTime.Now.ToString("yyyyMMdd"));

            string returnfilePath = Path.Combine(saveFolderPath.Substring(saveFolderPath.LastIndexOf("/") + 1), saveFileName);
            UploadFile(fileUpload, saveFolderPath, saveFileName, fileTypes, allowedMaxSize, out  errors);
            if (string.IsNullOrEmpty(errors))
            {
                return returnfilePath.Replace("\\", "/");
            }
            return string.Empty;

        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fileUpload">FileUpload对象</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadImage(HttpPostedFile fileUpload, string saveFolderPath,
            string fileTypes, int allowedMaxSize, out string errors)
        {
            int allowedWidth = 100000;
            int allowedHeight = 100000;
            return UploadImage(fileUpload, saveFolderPath, fileTypes, allowedMaxSize, allowedWidth, allowedHeight, out errors);
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fileUpload">上传FileUpload控件</param>
        /// <param name="saveFolderPath">保存文件的目录</param>
        /// <param name="fileTypes">允许上传文件类型 多个请用英文逗号隔开</param>
        /// <param name="allowedMaxSize">上传文件大小上限 单位：KB</param>
        /// <param name="allowedWidth">允许宽度</param>
        /// <param name="allowedHeight">允许高度</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static string UploadImage(HttpPostedFile fileUpload, string saveFolderPath,
            string fileTypes, int allowedMaxSize, int allowedWidth, int allowedHeight, out string errors)
        {
            if (null == fileUpload || fileUpload.ContentLength <= 0)
            {
                errors = "没有选定被上传的文件！";
                return string.Empty;
            }
            #region 文件扩展名判断
            if (!string.IsNullOrEmpty(fileTypes) && fileTypes != "*")
            {
                if (!fileTypes.StartsWith(","))
                {
                    fileTypes = "," + fileTypes;
                }
                if (!fileTypes.EndsWith(","))
                {
                    fileTypes = fileTypes + ",";
                }
            }

            if (!(string.IsNullOrEmpty(fileTypes) || fileTypes == "*") &&
                fileTypes.IndexOf("," + Path.GetExtension(fileUpload.FileName).Replace(".", "").ToLower() + ",") < 0)
            {
                errors = "文件必须是以" + fileTypes + "为扩展名的文件";
                return string.Empty;
            }

            #endregion

            string fileName = fileUpload.FileName;
            using (System.Drawing.Image image = System.Drawing.Image.FromStream(fileUpload.InputStream))
            {
                if (image.Width > allowedWidth || image.Height > allowedHeight)
                {
                    errors = string.Format("图片尺寸不符合规定大小{0}X{1}!", allowedWidth, allowedHeight);
                    return string.Empty;
                }
            }


            //生成文件名
            string saveFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(fileName);

            //生成保存路径
            saveFolderPath = mUrl.Combine(saveFolderPath, DateTime.Now.ToString("yyyyMMdd"));


            string returnfilePath = Path.Combine(saveFolderPath.Substring(saveFolderPath.LastIndexOf("/") + 1), saveFileName);

            if (!saveFolderPath.StartsWith("/") && saveFolderPath.IndexOf("\\") > 0)
            {
                UploadFile(fileUpload, saveFolderPath, saveFileName, fileTypes, allowedMaxSize, out errors);
                if (string.IsNullOrEmpty(errors))
                {
                    return returnfilePath.Replace("\\", "/");
                }
            }
            else
            {
                returnfilePath = DateTime.Now.ToString("yyyyMMdd") + "/" + saveFileName;
                UploadFile(fileUpload, saveFolderPath, saveFileName, fileTypes, allowedMaxSize, out errors);
                if (string.IsNullOrEmpty(errors))
                {
                    return returnfilePath;
                }
            }

            return string.Empty;

        }
        #endregion
    }
}
