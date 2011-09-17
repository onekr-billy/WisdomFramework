using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text.RegularExpressions;

namespace W.Library.Helper
{
    #region Enums
    public enum WaterType
    {
        None = 0,
        Text = 1,
        Image = 2
    }
    public enum CutMode
    {
        Scale = 0,
        Pull = 1,
        Cut = 2,
        CutSpec = 3 //按指定位置大小剪切
    }
    /// <summary>
    /// 缩略图的方式
    /// </summary>
    public enum ThumbnailMode
    {
        /// <summary>
        /// //指定高宽缩放（可能变形）
        /// </summary>
        HeightAndWidth,
        /// <summary>
        /// //指定宽，高按比例     
        /// </summary>
        AccordingWidth,
        /// <summary>
        /// //指定高，宽按比例
        /// </summary>
        AccordingHeight,
        /// <summary>
        /// 指定高宽裁减（不变形） 
        /// </summary>
        CutImage,
        /// <summary>
        /// 宽高自适应
        /// </summary>
        SelfAdapting

    }

    /// <summary>
    /// 水印位置
    /// </summary>
    public enum WatermarkPosition
    {
        /// <summary>
        /// 没有水印
        /// </summary>
        None = 0,
        /// <summary>
        /// 左上
        /// </summary>
        TOP_LEFT,

        /// <summary>
        /// 上中
        /// </summary>
        TOP_CENTER,

        /// <summary>
        /// 右上
        /// </summary>
        TOP_RIGHT,

        /// <summary>
        /// 右中
        /// </summary>
        CENTER_RIGHT,

        /// <summary>
        /// 中中
        /// </summary>
        CENTER_CENTER,

        /// <summary>
        /// 左中
        /// </summary>
        CENTER_LEFT,

        /// <summary>
        /// 左下
        /// </summary>
        BOTTOM_LEFT,

        /// <summary>
        /// 下中
        /// </summary>
        BOTTOM_CENTER,

        /// <summary>
        /// 右下
        /// </summary>
        BOTTOM_RIGHT
    }
    #endregion

    #region mImage
    /// <summary>
    /// 图像裁剪辅助类
    /// </summary>
    public class mImage
    {
        #region ** 属性 **
        private bool _IsFillRect = true;
        /// <summary>
        /// 是否完全填充整个图片的大小
        /// </summary>
        public bool IsFillRect
        {
            get { return _IsFillRect; }
            set { _IsFillRect = value; }
        }

        private static string root = "/upload/images/";
        /// <summary>
        /// 上传图片的根目录
        /// </summary>
        public string Root
        {
            get { return root; }
            set { root = value; }
        }

        private int widthImage = 0;
        /// <summary>
        /// 缩略图默认宽度
        /// </summary>
        public int WidthImage
        {
            get { return widthImage; }
            set { widthImage = value; }
        }
        private int heightImage = 0;
        /// <summary>
        /// 缩略图默认高度
        /// </summary>
        public int HeightImage
        {
            get { return heightImage; }
            set { heightImage = value; }
        }
        private WaterType wType = WaterType.None;
        /// <summary>
        /// 水印类型
        /// </summary>
        public WaterType WType
        {
            get { return wType; }
            set { wType = value; }
        }
        private CutMode cMode = CutMode.Cut;
        /// <summary>
        /// 缩略图裁减类型
        /// </summary>
        public CutMode CMode
        {
            get { return cMode; }
            set { cMode = value; }
        }
        #endregion
        #region 多种尺寸压缩
        private bool _IsAllAddMarker = false;
        /// <summary>
        /// 是否将所有的缩略图加水印，如果不是，则在WatermarkPosition不为None的情况下，只对最后一张加水印
        /// </summary>
        public bool IsAllAddMarker
        {
            get { return _IsAllAddMarker; }
            set { _IsAllAddMarker = value; }
        }

        private IList<string> _SizeList = new List<string>();
        /// <summary>
        /// 多种尺寸压缩,如170X170
        /// </summary>
        public IList<string> SizeList
        {
            get { return _SizeList; }
            set { _SizeList = value; }
        }
        /// <summary>
        /// 如果从指定位置剪切时，X起始位置
        /// </summary>
        private int _PosX;

        public int PosX
        {
            get { return _PosX; }
            set { _PosX = value; }
        }
        /// <summary>
        /// 如果从指定位置剪切时，Y起始位置
        /// </summary>
        private int _PosY;

        public int PosY
        {
            get { return _PosY; }
            set { _PosY = value; }
        }
        #endregion
        #region Construct
        /// <summary>
        /// 
        /// </summary>
        public mImage()
        {
        }
        /// <summary>
        /// 构造函数 初始化生成图的宽高, 水印类型, 裁剪模式
        /// </summary>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="type">水印类型</param>
        /// <param name="mode">裁剪模式</param>
        public mImage(int width, int height, int type, int mode)
        {
            widthImage = width;
            heightImage = height;
            this.cMode = (CutMode)mode;
            this.wType = (WaterType)type;
        }
        #endregion
        #region Upload

        /// <summary>
        /// 图片处理函数
        /// </summary>
        /// <param name="oriFile">原图片文件</param>
        /// <param name="extName">扩展名</param>
        /// <param name="imgName">生成后图片的名称</param>
        /// <returns>返回生成后图片的完整路径</returns>
        public string PicUpload(Stream oriFile, string extName, string imgName)
        {
            return PicUpload(oriFile, extName, imgName, null, null, WatermarkPosition.None);
        }

        /// <summary>
        /// 图片处理函数
        /// </summary>
        /// <param name="oriFile">原图片文件</param>
        /// <param name="extName">扩展名</param>
        /// <param name="imgName">生成后图片的名称</param>
        /// <param name="waterImg">水印图存放路径</param>
        /// <param name="character">水印文字内容</param>
        /// <returns>返回生成后图片的完整路径</returns>
        public string PicUpload(Stream oriFile, string extName, string imgName, string waterImg, string character, WatermarkPosition wp)
        {
            //生成图片存放目录
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(root)))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(root));
            string webFilePath = HttpContext.Current.Server.MapPath(root + imgName + extName);				// 处理后图片保存路径
            string webFilePathA = HttpContext.Current.Server.MapPath(root + imgName + "_O" + extName);				// 处理后图片保存路径
            string webFilePath_sy = HttpContext.Current.Server.MapPath(waterImg);　		// 水印图存放路径

            string result = "";
            //假如已经存在,先删除
            if (File.Exists(webFilePath))
                File.Delete(webFilePath);
            try
            {
                //保存原图,原图不加水印？
                MakeThumbnail(oriFile, webFilePathA, 0, 0, webFilePath_sy, character, WatermarkPosition.None);     // 生成缩略图
                if (wp != WatermarkPosition.None)
                    MakeThumbnail(oriFile, webFilePath, -1, -1, webFilePath_sy, character, WatermarkPosition.CENTER_CENTER);     //强制将水印放在中间位置
                else
                    MakeThumbnail(oriFile, webFilePath, 0, 0, webFilePath_sy, character, WatermarkPosition.None);     // 直接保存，不生成缩略图
                result = root + imgName + extName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            //LogHelper.Log("UploadFile:"+this._SizeList.Count);

            //生成扩展的压缩图片
            int i = 0;
            foreach (string size in this.SizeList)
            {
                i++;
                //LogHelper.Log("UploadFile Size:" + size);
                string[] wh = size.Split(',');
                if (wh.Length < 2) continue;

                int w = 0;
                int h = 0;
                int.TryParse(wh[0], out w);
                int.TryParse(wh[1], out h);
                if (w == 0 && h == 0) continue;

                webFilePath = HttpContext.Current.Server.MapPath(root + imgName + "." + w + "X" + h + extName);				// 处理后图片保存路径

                try
                {
                    if (wp != WatermarkPosition.None && !IsAllAddMarker)
                    {
                        if (i >= this._SizeList.Count)
                            MakeThumbnail(oriFile, webFilePath, w, h, webFilePath_sy, character, wp);     // 生成缩略图
                        else
                            MakeThumbnail(oriFile, webFilePath, w, h, webFilePath_sy, character, WatermarkPosition.None);     // 生成缩略图
                    }
                    else
                        MakeThumbnail(oriFile, webFilePath, w, h, webFilePath_sy, character, wp);     // 生成缩略图
                    /*if (WaterType.Text == wType)
                    {
                        AddWaterText(webFilePath, webFilePath, character);						//生成文字水印图
                    }
                    else if (WaterType.Image == wType)
                    {
                        AddWaterPic(webFilePath, webFilePath, webFilePath_sy);		//生成图片水印图
                    }*/
                }
                catch (Exception ex)
                {
                    throw new Exception("生成文件缩略图出错：", ex);
                    //throw new Exception(ex.ToString());
                }
            }
            return result;
        }
        #endregion
        #region MakeThumbnail Function1
        public string MakeThumbnail(string orgUrl, string tarUrl, int tarW, int tarH)
        {
            return MakeThumbnail(orgUrl, tarUrl, tarW, tarH, 0, 0);
        }
        public string MakeThumbnail(string orgUrl, string tarUrl, int tarWidth, int tarHeight, int rectWidth, int rectHeight)
        {
            string returnImageUrl = string.Empty;
            orgUrl = GetUploadImageUrl(orgUrl, 0, 0);
            tarUrl = GetUploadImageUrl(tarUrl, 0, 0);

            string orgPhyFullFileName = HttpContext.Current.Server.MapPath(orgUrl);//源图物理路径
            if (File.Exists(orgPhyFullFileName))
            {
                string tarFullFileName = HttpContext.Current.Server.MapPath(tarUrl);//缩略图物理路径
                string tarFullPath = Path.GetDirectoryName(tarFullFileName);
                if (!Directory.Exists(tarFullPath))
                {
                    try
                    {
                        Directory.CreateDirectory(tarFullPath);
                    }
                    catch
                    {
                        return string.Empty;
                    }
                }

                FileStream fs = new FileStream(orgPhyFullFileName, FileMode.Open);
                try
                {
                    MakeThumbnail(fs, tarFullFileName, tarWidth, tarHeight, null, null, WatermarkPosition.None, rectWidth, rectHeight);
                }
                finally
                {
                    fs.Close();
                }

                returnImageUrl = tarUrl;

            }
            return returnImageUrl;

        }
        protected void MakeThumbnail(Stream oriFile, string thumbnailPath, int width, int height, string markerfile, string character, WatermarkPosition wp)
        {
            MakeThumbnail(oriFile, thumbnailPath, width, height, markerfile, character, wp, 0, 0);
        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="orgFileStream">源图路径（物理路径）</param>
        /// <param name="targetFileName">缩略图路径（物理路径）</param>
        /// <param name="tarWidth">缩略图宽度</param>
        /// <param name="tarHeight">缩略图高度</param>
        /// <param name="rWidth">源图中截获一个矩形区域的宽度</param>
        /// <param name="rHeight">源图中截获一个矩形区域的宽度</param>
        protected void MakeThumbnail(Stream orgFileStream, string targetFileName, int tarWidth, int tarHeight, string markerfile, string character, WatermarkPosition wp, int rWidth, int rHeight)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromStream(orgFileStream);

            if (tarWidth == 0 && tarHeight == 0)
            {
                originalImage.Save(targetFileName);
                return;
                //tarWidth = originalImage.Width;
                //tarHeight = originalImage.Height;
            }
            else if (tarWidth < 0 || tarHeight < 0)
            {
                tarWidth = originalImage.Width;
                tarHeight = originalImage.Height;
            }
            //目标大小
            int towidth = tarWidth;
            int toheight = tarHeight;

            int x = 0;
            int y = 0;
            //当需要填充白边时，两个方向的座标的起始位置
            int posx = 0;
            int posy = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            if (rWidth > 0 && rHeight > 0)
            {
                ow = rWidth;
                oh = rHeight;
            }
            if (toheight == 0 || towidth == 0) cMode = CutMode.Scale;  //如果有一个为0，表示仅限一边，其它按比例压缩
            switch (cMode)
            {
                case CutMode.Scale://按比例自适应宽高（不变形）
                    if (towidth == 0)
                    {
                        double rateo = (double)oh / (double)toheight;
                        towidth = (int)(ow * rateo);
                    }
                    else if (toheight == 0)
                    {
                        double rateh = (double)ow / (double)towidth;
                        toheight = (int)(oh * rateh);
                    }
                    else
                    {
                        if (_IsFillRect)//如果要将图片填充满,最后形成的图片是一张大小与要求一样的图
                        {
                            double rateo = (double)ow / (double)oh;
                            double raten = (double)towidth / (double)toheight;

                            if (rateo > raten) //如果原图比目标宽，则Y座标需要计算
                            {
                                posy = (int)(toheight - (double)towidth / (double)ow * oh) / 2;//Y向居中起始位置
                            }
                            else
                            {
                                posx = (int)(towidth - (double)toheight / (double)oh * ow) / 2;//X向居中起始位置
                            }
                        }
                        else //最后形成的图片可能比目标图片小，但宽和高有一个与要求的大小一致
                        {
                            if ((double)ow / (double)oh > (double)towidth / (double)toheight)
                            {
                                toheight = (int)(oh * tarWidth / (double)ow);
                            }
                            else
                            {
                                towidth = (int)(ow * tarHeight / (double)oh);
                            }
                        }
                    }
                    break;
                case CutMode.Pull://指定高宽缩放（可能变形） 
                    break;
                case CutMode.Cut://指定高宽裁减（不变形）
                    if ((double)ow / (double)oh > (double)towidth / (double)toheight)
                    {
                        //oh = originalImage.Height;
                        int ow1 = ow;
                        ow = (int)(ow * towidth / (double)toheight);
                        y = 0;
                        x = (ow1 - ow) / 2;
                    }
                    else
                    {
                        //ow = originalImage.Width;
                        int oh1 = oh;
                        oh = ow * tarHeight / towidth;
                        x = 0;
                        y = (oh1 - oh) / 2;
                    }
                    break;
                //从指定位置剪切固定大小的图
                case CutMode.CutSpec:
                    x = _PosX;
                    y = _PosY;
                    if (rWidth <= 0 && rHeight <= 0)
                    {
                        ow = towidth;
                        oh = toheight;
                    }
                    break;
                default:
                    break;
            }
            //ImageCodecInfo ici = Getco
            long lngDefinition = 90;
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, lngDefinition);


            //新建一个bmp图片
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(towidth, toheight, PixelFormat.Format32bppArgb);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            //System.Drawing.Imaging.ImageCodecInfo codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1]; 
            //System.Drawing.Imaging.EncoderParameters eParams = new System.Drawing.Imaging.EncoderParameters(1);
            //eParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);   

            //清空画布并以白色背景色填充
            g.Clear(System.Drawing.Color.White);

            //在指定位置并且按指定大小绘制原图片的指定部分
            if (_IsFillRect)
            {
                g.DrawImage(originalImage, new System.Drawing.Rectangle(posx, posy, towidth - posx * 2, toheight - posy * 2),
                  new System.Drawing.Rectangle(x, y, ow, oh),
                  System.Drawing.GraphicsUnit.Pixel);
            }
            else
            {
                g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                 new System.Drawing.Rectangle(x, y, ow, oh),
                 System.Drawing.GraphicsUnit.Pixel);
            }
            if (wp != WatermarkPosition.None)
            {
                if (WaterType.Text == wType)
                {
                    if (character == null) character = "NULL";
                    AddWatermarkText(ref g, towidth, toheight, character, wp);
                }
                else if (markerfile != null)
                {
                    Image wimg = Image.FromFile(markerfile);
                    AddWatermarkImage(ref g, towidth, toheight, wimg, wp);
                }
            }
            try
            {
                SaveImage(bitmap, 100L, targetFileName);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        /// <summary>
        /// 保存图片。
        /// </summary>
        /// <param name="image">要保存的图片</param>
        /// <param name="quality">品质（1L~100L之间，数值越大品质越好）</param>
        /// <param name="filename">保存路径</param>
        public static void SaveImage(Bitmap image, long quality, string filename)
        {
            using (EncoderParameters encoderParams = new EncoderParameters(1))
            {
                using (EncoderParameter parameter = (encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality)))
                {
                    ImageCodecInfo encoder = null;
                    //取得扩展名
                    string ext = Path.GetExtension(filename);
                    if (string.IsNullOrEmpty(ext))
                        ext = ".jpg";
                    //根据扩展名得到解码、编码器
                    foreach (ImageCodecInfo codecInfo in ImageCodecInfo.GetImageEncoders())
                    {
                        if (Regex.IsMatch(codecInfo.FilenameExtension, string.Format(@"(;|^)\*\{0}(;|$)", ext), RegexOptions.IgnoreCase))
                        {
                            encoder = codecInfo;
                            break;
                        }
                    }
                    try
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(filename)))
                            Directory.CreateDirectory(Path.GetDirectoryName(filename));
                    }
                    catch (Exception ex) { }
                    image.Save(filename, encoder, encoderParams);
                }
            }
        }

        #endregion
        #region AddWaterText Function1
        /*
        /// <summary>
        /// 在图片上增加文字水印
        /// </summary>
        /// <param name="Path">图片路径</param>
        /// <param name="text">水印文字</param>
        protected void AddWaterText(string Path, string TmpPath, string text)
        {
            //删除缓存图
            File.Delete(TmpPath);
            //建立新缓存图
            File.Copy(Path, TmpPath);

            System.Drawing.Image image = System.Drawing.Image.FromFile(TmpPath);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            System.Drawing.Font f = new System.Drawing.Font("Verdana", 60);
            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);

            g.DrawString(text, f, b, 35, 35);
            g.Dispose();

            image.Save(Path);
            image.Dispose();
        }

        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="Path">图片路径</param>
        /// <param name="Path_sy">水印图片路径</param>
        protected void AddWaterPic(string Path, string TmpPath, string Path_sy)
        {
            //删除缓存图
            File.Delete(TmpPath);
            //建立新缓存图
            File.Copy(Path, TmpPath);

            System.Drawing.Image image = System.Drawing.Image.FromFile(TmpPath);
            System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sy);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();

            image.Save(Path);
            image.Dispose();
        }*/
        #endregion
        #region Clone
        /// <summary>
        /// 复制专辑封面图
        /// </summary>
        /// <param name="albumOriID">原专辑ID</param>
        /// <param name="albumNewID">新专辑ID</param>
        /// <param name="root">图片文件所在目录</param>
        public static string CloneCover(int albumOriID, int albumNewID, string root)
        {
            string oriFilePath = HttpContext.Current.Server.MapPath(root + "Cover" + albumOriID + ".jpg");
            string newFilePath = HttpContext.Current.Server.MapPath(root + "Cover" + albumNewID + ".jpg");
            //假如已经存在,先删除
            if (!File.Exists(oriFilePath))
                return string.Empty;
            if (File.Exists(newFilePath))
                File.Delete(newFilePath);
            File.Copy(oriFilePath, newFilePath);
            return newFilePath;
        }
        /// <summary>
        /// 复制专辑封面图
        /// </summary>
        /// <param name="albumOriID">原专辑ID</param>
        /// <param name="albumNewID">新专辑ID</param>
        public static string CloneCover(int albumOriID, int albumNewID)
        {
            return CloneCover(albumOriID, albumNewID, root);
        }
        #endregion
        #region DeleteFile
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="isMapPath"></param>
        /// <returns></returns>
        public void DeleteFile(string path, bool isMapPath)
        {
            if (!isMapPath)
                path = HttpContext.Current.Server.MapPath(path);
            if (File.Exists(path))
                File.Delete(path);
        }
        #endregion


        #region WaterMark

        /// <summary>
        /// 添加水印文字到图片中
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="watermarkText"></param>
        /// <param name="position"></param>
        public static void AddWatermarkText(ref Graphics picture, int width, int height, string watermarkText, WatermarkPosition position)
        {
            int alpha = 250;
            AddWatermarkText(ref picture, width, height, watermarkText, position, alpha);
        }

        /// <summary>
        /// 添加水印文字到图片中
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="watermarkText"></param>
        /// <param name="position"></param>
        /// <param name="alpha"></param>
        public static void AddWatermarkText(ref Graphics picture, int width, int height, string watermarkText, WatermarkPosition position, int alpha)
        {
            int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };
            Font crFont = null;
            SizeF crSize = new SizeF();
            for (int i = 0; i < 7; i++)
            {
                crFont = new Font("Verdana", sizes[i], FontStyle.Bold);
                crSize = picture.MeasureString(watermarkText, crFont);

                if ((ushort)crSize.Width < (ushort)width)
                    break;
            }

            float xpos = 0;
            float ypos = 0;

            switch (position)
            {
                case WatermarkPosition.TOP_LEFT:
                    xpos = ((float)width * (float).01) + (crSize.Width / 2);
                    ypos = (float)height * (float).01;
                    break;
                case WatermarkPosition.TOP_CENTER:
                    xpos = ((float)width - crSize.Width) / 2;
                    ypos = (float)height * (float).01;
                    break;
                case WatermarkPosition.TOP_RIGHT:
                    xpos = ((float)width * (float).99) - (crSize.Width / 2);
                    ypos = (float)height * (float).01;
                    break;
                case WatermarkPosition.CENTER_LEFT:
                    xpos = ((float)width * (float).01) + (crSize.Width / 2);
                    ypos = ((float)height - crSize.Height) / 2;
                    break;
                case WatermarkPosition.CENTER_CENTER:
                    xpos = ((float)width - crSize.Width) / 2;
                    ypos = ((float)height - crSize.Height) / 2;
                    break;
                case WatermarkPosition.CENTER_RIGHT:
                    xpos = ((float)width * (float).99) - (crSize.Width / 2);
                    ypos = ((float)height - crSize.Height) / 2;
                    break;
                case WatermarkPosition.BOTTOM_RIGHT:
                    xpos = ((float)width - crSize.Width) / 2;
                    ypos = ((float)height * (float).99) - crSize.Height;
                    break;
                case WatermarkPosition.BOTTOM_CENTER:
                    xpos = ((float)width * (float).99) - (crSize.Width / 2);
                    ypos = ((float)height * (float).99) - crSize.Height;
                    break;
                case WatermarkPosition.BOTTOM_LEFT:
                    xpos = ((float)width * (float).01) + (crSize.Width / 2);
                    ypos = ((float)height * (float).99) - crSize.Height;
                    break;
            }

            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;

            SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0));
            picture.DrawString(watermarkText, crFont, semiTransBrush2, xpos + 1, ypos + 1, StrFormat);

            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(alpha, 255, 255, 255));
            picture.DrawString(watermarkText, crFont, semiTransBrush, xpos, ypos, StrFormat);


            semiTransBrush2.Dispose();
            semiTransBrush.Dispose();
        }

        /// <summary>
        /// 添加水印图片到图片中
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="watermark"></param>
        /// <param name="position"></param>
        public static void AddWatermarkImage(ref Graphics picture, int width, int height, Image watermark, WatermarkPosition position)
        {

            using (ImageAttributes imageAttributes = new ImageAttributes())
            {
                ColorMap colorMap = new ColorMap();

                colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
                colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
                ColorMap[] remapTable = { colorMap };

                imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

                float[][] colorMatrixElements = {
												new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
												new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
												new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
												new float[] {0.0f,  0.0f,  0.0f,  1.0f, 0.0f},
												new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
											};

                ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

                imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                int xpos = 0;
                int ypos = 0;

                switch (position)
                {
                    case WatermarkPosition.TOP_LEFT:
                        xpos = 10;
                        ypos = 10;
                        break;
                    case WatermarkPosition.TOP_CENTER:
                        xpos = (width - watermark.Width) / 2;
                        ypos = 10;
                        break;
                    case WatermarkPosition.TOP_RIGHT:
                        xpos = ((width - watermark.Width) - 10);
                        ypos = 10;
                        break;
                    case WatermarkPosition.CENTER_RIGHT:
                        xpos = ((width - watermark.Width) - 10);
                        ypos = (height - watermark.Height) / 2;
                        break;
                    case WatermarkPosition.CENTER_CENTER:
                        xpos = (width - watermark.Width) / 2;
                        ypos = (height - watermark.Height) / 2;
                        break;
                    case WatermarkPosition.CENTER_LEFT:
                        xpos = 10;
                        ypos = (height - watermark.Height) / 2;
                        break;
                    case WatermarkPosition.BOTTOM_RIGHT:
                        xpos = ((width - watermark.Width) - 10);
                        ypos = height - watermark.Height - 10;
                        break;
                    case WatermarkPosition.BOTTOM_CENTER:
                        xpos = (width - watermark.Width) / 2;
                        ypos = height - watermark.Height - 10;
                        break;
                    case WatermarkPosition.BOTTOM_LEFT:
                        xpos = 10;
                        ypos = height - watermark.Height - 10;
                        break;
                }

                picture.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);


                watermark.Dispose();
                imageAttributes.Dispose();
            }
        }
        public static void AddWatermarkImage(string path, string targetPath, string markerfile, string character, WaterType wType, WatermarkPosition wp)
        {
            if (!File.Exists(path)) throw new FileNotFoundException((path == null ? "" : path) + " Not Find!");
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(path);

            //ImageCodecInfo ici = Getco
            long lngDefinition = 90;
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, lngDefinition);
            int towidth = originalImage.Width;
            int toheight = originalImage.Height;

            //新建一个bmp图片
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(towidth, toheight, PixelFormat.Format32bppArgb);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            //System.Drawing.Imaging.ImageCodecInfo codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1]; 
            //System.Drawing.Imaging.EncoderParameters eParams = new System.Drawing.Imaging.EncoderParameters(1);
            //eParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);   

            //清空画布并以白色背景色填充
            g.Clear(System.Drawing.Color.White);

            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
             new System.Drawing.Rectangle(0, 0, towidth, toheight),
             System.Drawing.GraphicsUnit.Pixel);

            if (wp != WatermarkPosition.None)
            {
                if (WaterType.Text == wType)
                {
                    if (character == null) character = "NULL";
                    AddWatermarkText(ref g, towidth, toheight, character, wp);
                }
                else if (markerfile != null)
                {
                    Image wimg = Image.FromFile(markerfile);
                    AddWatermarkImage(ref g, towidth, toheight, wimg, wp);
                }
            }
            try
            {
                SaveImage(bitmap, 100L, targetPath);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion
        #region 获得正确的图片全地址
        static Regex reg = new Regex(@"(?<n>.*)(\.\d+x\d+)?(?<ext>\.(jpg|gif|bmp|png|jpeg|icon|swf))$", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.RightToLeft);
        static Regex regImg = new Regex(@"(?<n>.*)(?<ext>\.(jpg|gif|bmp|png|jpeg|icon|swf))$", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.RightToLeft);
        static Regex regImgStart = new Regex(@"^" + HttpContext.Current.Request.ApplicationPath + @"/upload/|^" + HttpContext.Current.Request.ApplicationPath, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        static Regex regImgStart2 = new Regex(@"^/", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        /// <summary>
        /// 格式化用户上传图片的全地址
        /// </summary>
        /// <param name="relurl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static string GetUploadImageUrl(string relurl, int width, int height)
        {
            string root = "";
            if (HttpContext.Current != null)
                root = HttpContext.Current.Request.ApplicationPath;
            else
                root = AppDomain.CurrentDomain.BaseDirectory;
            if (string.IsNullOrEmpty(relurl) || !regImg.IsMatch(relurl))
                return root.TrimEnd('/') + "/Themes/Default/images/noimage.100x100.jpg";
            else
            {
                if (regImg.Match(relurl).Groups["ext"].Value.ToLower() == "swf")
                {
                    width = 0;
                    height = 0;
                }
                else if (regImg.Match(relurl).Groups["ext"].Value.ToLower() == "gif" && width == 0 && height == 0)
                {
                    width = -1;
                    height = -1;
                }
            }
            if (relurl.ToLower().StartsWith("http://"))
            {
                return relurl;
            }
            else
            {
                if (width > 0 && height > 0)
                {
                    Match m = reg.Match(relurl);
                    if (m.Success)
                    {
                        relurl = string.Format("{0}.{1}x{2}{3}",
                            m.Groups["n"].Value, width, height, m.Groups["ext"].Value);
                    }
                }
                else if (width < 0 || height < 0)
                {
                    Match m = reg.Match(relurl);
                    if (m.Success)
                    {
                        relurl = string.Format("{0}_O{1}",
                            m.Groups["n"].Value, m.Groups["ext"].Value);
                    }
                }
                if (regImgStart.IsMatch(relurl))
                {
                    return relurl;
                }
                else if (regImgStart2.IsMatch(relurl))
                {

                    return root.TrimEnd('/') + relurl;
                    //return relurl;
                }
                else
                {
                    return string.Format(root.TrimEnd('/') + "/upload/{0}", relurl);
                }
            }
        }
        /// <summary>
        /// 格式化用户上传图片的全地址
        /// </summary>
        /// <param name="relurl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static string GetUploadImageUrl(string relurl, int width, int height, int objectType)
        {
            string root = "";
            if (HttpContext.Current != null)
                root = HttpContext.Current.Request.ApplicationPath;
            else
                root = AppDomain.CurrentDomain.BaseDirectory;
            if (string.IsNullOrEmpty(relurl) || !regImg.IsMatch(relurl))
            {
                //switch ((Framework.Enumerations.ObjectType)objectType)
                //{
                //    case Framework.Enumerations.ObjectType.User:
                //        return root.TrimEnd('/') + "/Themes/Default/images/nopersonimage.jpg";
                //    case Framework.Enumerations.ObjectType.Hotel:
                //    case Framework.Enumerations.ObjectType.HotelRoom:
                //        return root.TrimEnd('/') + "/Themes/Default/images/icon_no_hotel_image_90.jpg";
                //    case Framework.Enumerations.ObjectType.Traffic:
                //    case Framework.Enumerations.ObjectType.Train:
                //    case Framework.Enumerations.ObjectType.Aireport:
                //    case Framework.Enumerations.ObjectType.Line:
                //    case Framework.Enumerations.ObjectType.Scene:
                //    default:
                //        return root.TrimEnd('/') + "/Themes/Default/images/noimage.100X100.jpg";
                //}
            }
            //return root.TrimEnd('/') + "/Themes/Default/images/noimage.100x100.jpg";
            if (relurl.ToLower().StartsWith("http://"))
            {
                return relurl;
            }
            else
            {
                if (width > 0 && height > 0)
                {
                    Match m = reg.Match(relurl);
                    if (m.Success)
                    {
                        relurl = string.Format("{0}.{1}x{2}{3}",
                            m.Groups["n"].Value, width, height, m.Groups["ext"].Value);
                    }
                }
                if (regImgStart.IsMatch(relurl))
                {
                    return relurl;
                }
                else if (regImgStart2.IsMatch(relurl))
                {

                    return root.TrimEnd('/') + relurl;
                    //return relurl;
                }
                else
                {
                    return string.Format(root.TrimEnd('/') + "/upload/{0}", relurl);
                }
            }
        }
        #endregion
    }
    #endregion
}
