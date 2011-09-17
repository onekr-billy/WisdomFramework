
using System;

using Weed;
using Weed.SDQ;

namespace W.Entity.Mall
{
    /// <summary>
    /// 生成:2011/07/12 09:11:27
    /// 作者:Weed Studio
    /// </summary>
    [Serializable]
    public class B2cproduct : QEntity
    {
        /// <summary>
        /// B2C商品ID
        /// </summary>
        public int B2CGoodsID { get { return _B2CGoodsID; } set{ _B2CGoodsID = value; } }
        private int _B2CGoodsID;
        
        /// <summary>
        /// 产品ID
        /// </summary>
        public int Id { get { return _Id; } set{ _Id = value; } }
        private int _Id;
        
        /// <summary>
        /// 产品功能分类ID
        /// </summary>
        public int Class_id { get { return _Class_id; } set{ _Class_id = value; } }
        private int _Class_id;
        
        /// <summary>
        /// 虚拟分类ID
        /// </summary>
        public string B2CClassID { get { return _B2CClassID; } set{ _B2CClassID = value; } }
        private string _B2CClassID;
        
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string B2CClassName { get { return _B2CClassName; } set{ _B2CClassName = value; } }
        private string _B2CClassName;
        
        /// <summary>
        /// 商品特征名
        /// </summary>
        public string Goodstitle { get { return _Goodstitle; } set{ _Goodstitle = value; } }
        private string _Goodstitle;
        
        /// <summary>
        /// 商品销售名
        /// </summary>
        public string Goodstitle2 { get { return _Goodstitle2; } set{ _Goodstitle2 = value; } }
        private string _Goodstitle2;
        
        /// <summary>
        /// 商品图片
        /// </summary>
        public string Goodspic { get { return _Goodspic; } set{ _Goodspic = value; } }
        private string _Goodspic;
        
        /// <summary>
        /// 品牌ID
        /// </summary>
        public int Brandid { get { return _Brandid; } set{ _Brandid = value; } }
        private int _Brandid;
        
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string Brandname { get { return _Brandname; } set{ _Brandname = value; } }
        private string _Brandname;
        
        /// <summary>
        /// 商品介绍
        /// </summary>
        public string Goodstxt { get { return _Goodstxt; } set{ _Goodstxt = value; } }
        private string _Goodstxt;
        
        /// <summary>
        /// 上下架状态
        /// </summary>
        public short Goodsstate { get { return _Goodsstate; } set{ _Goodsstate = value; } }
        private short _Goodsstate;
        
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keywords { get { return _Keywords; } set{ _Keywords = value; } }
        private string _Keywords;
        
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get { return _Unit; } set{ _Unit = value; } }
        private string _Unit;
        
        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime BeginTime { get { return _BeginTime; } set{ _BeginTime = value; } }
        private DateTime _BeginTime;
        
        /// <summary>
        /// 下架时间
        /// </summary>
        public DateTime EndTime { get { return _EndTime; } set{ _EndTime = value; } }
        private DateTime _EndTime;
        
        /// <summary>
        /// 普通会员价
        /// </summary>
        public decimal MemberPric1 { get { return _MemberPric1; } set{ _MemberPric1 = value; } }
        private decimal _MemberPric1;
        
        /// <summary>
        /// 铜牌会员
        /// </summary>
        public decimal MemberPric2 { get { return _MemberPric2; } set{ _MemberPric2 = value; } }
        private decimal _MemberPric2;
        
        /// <summary>
        /// 银牌会员
        /// </summary>
        public decimal MemberPric3 { get { return _MemberPric3; } set{ _MemberPric3 = value; } }
        private decimal _MemberPric3;
        
        /// <summary>
        /// 金牌会员
        /// </summary>
        public decimal MemberPric4 { get { return _MemberPric4; } set{ _MemberPric4 = value; } }
        private decimal _MemberPric4;
        
        /// <summary>
        /// 待定
        /// </summary>
        public decimal MemberPric5 { get { return _MemberPric5; } set{ _MemberPric5 = value; } }
        private decimal _MemberPric5;
        
        /// <summary>
        /// 待定
        /// </summary>
        public decimal MemberPric6 { get { return _MemberPric6; } set{ _MemberPric6 = value; } }
        private decimal _MemberPric6;
        
        /// <summary>
        /// 成本价
        /// </summary>
        public decimal Pricescosts { get { return _Pricescosts; } set{ _Pricescosts = value; } }
        private decimal _Pricescosts;
        
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal Listprice { get { return _Listprice; } set{ _Listprice = value; } }
        private decimal _Listprice;
        
        /// <summary>
        /// 最小价格
        /// </summary>
        public decimal Minpric { get { return _Minpric; } set{ _Minpric = value; } }
        private decimal _Minpric;
        
        /// <summary>
        /// 最大价格
        /// </summary>
        public decimal Maxpric { get { return _Maxpric; } set{ _Maxpric = value; } }
        private decimal _Maxpric;
        
        /// <summary>
        /// 货号
        /// </summary>
        public long BarCode { get { return _BarCode; } set{ _BarCode = value; } }
        private long _BarCode;
        
        /// <summary>
        /// 重量
        /// </summary>
        public int Weight { get { return _Weight; } set{ _Weight = value; } }
        private int _Weight;
        
        /// <summary>
        /// 包装重量
        /// </summary>
        public int WeightBz { get { return _WeightBz; } set{ _WeightBz = value; } }
        private int _WeightBz;
        
        /// <summary>
        /// 售后服务
        /// </summary>
        public string ServiceNote { get { return _ServiceNote; } set{ _ServiceNote = value; } }
        private string _ServiceNote;
        
        /// <summary>
        /// 售销数量
        /// </summary>
        public int SaleCount { get { return _SaleCount; } set{ _SaleCount = value; } }
        private int _SaleCount;
        
        /// <summary>
        /// 是否保价
        /// </summary>
        public short IsInsured { get { return _IsInsured; } set{ _IsInsured = value; } }
        private short _IsInsured;
        
        /// <summary>
        /// 保价比例
        /// </summary>
        public short InsuredScale { get { return _InsuredScale; } set{ _InsuredScale = value; } }
        private short _InsuredScale;
        
        /// <summary>
        /// 保修方式
        /// </summary>
        public short WarrantyType { get { return _WarrantyType; } set{ _WarrantyType = value; } }
        private short _WarrantyType;
        
        /// <summary>
        /// 保修时限
        /// </summary>
        public int WarrantyLimit { get { return _WarrantyLimit; } set{ _WarrantyLimit = value; } }
        private int _WarrantyLimit;
        
        /// <summary>
        /// 退换规则
        /// </summary>
        public short RetreatRule { get { return _RetreatRule; } set{ _RetreatRule = value; } }
        private short _RetreatRule;
        
        /// <summary>
        /// 产品类型
        /// </summary>
        public short ProductType { get { return _ProductType; } set{ _ProductType = value; } }
        private short _ProductType;
        
        /// <summary>
        /// 是否包邮
        /// </summary>
        public short IsPost { get { return _IsPost; } set{ _IsPost = value; } }
        private short _IsPost;
        
        /// <summary>
        /// 是否接受优惠券
        /// </summary>
        public short IsPreferential { get { return _IsPreferential; } set{ _IsPreferential = value; } }
        private short _IsPreferential;
        
        /// <summary>
        /// 是否有捆绑商品
        /// </summary>
        public short IsBind { get { return _IsBind; } set{ _IsBind = value; } }
        private short _IsBind;
        
        /// <summary>
        /// 是否是不打折商品
        /// </summary>
        public short IsNotdiscount { get { return _IsNotdiscount; } set{ _IsNotdiscount = value; } }
        private short _IsNotdiscount;
        
        /// <summary>
        /// 是否促销商品
        /// </summary>
        public short IsPromotion { get { return _IsPromotion; } set{ _IsPromotion = value; } }
        private short _IsPromotion;
        
        /// <summary>
        /// 是否有赠品
        /// </summary>
        public short IsaretGift { get { return _IsaretGift; } set{ _IsaretGift = value; } }
        private short _IsaretGift;
        
        /// <summary>
        ///  是否是赠品
        /// </summary>
        public short IsGift { get { return _IsGift; } set{ _IsGift = value; } }
        private short _IsGift;
        
        /// <summary>
        /// 购买次数
        /// </summary>
        public int BuyNumber { get { return _BuyNumber; } set{ _BuyNumber = value; } }
        private int _BuyNumber;
        
        /// <summary>
        /// 收藏次数
        /// </summary>
        public int CollectNumber { get { return _CollectNumber; } set{ _CollectNumber = value; } }
        private int _CollectNumber;
        
        /// <summary>
        /// 留言次数
        /// </summary>
        public int BrowsingNumber { get { return _BrowsingNumber; } set{ _BrowsingNumber = value; } }
        private int _BrowsingNumber;
        
        /// <summary>
        /// 排序ID
        /// </summary>
        public int OrderID { get { return _OrderID; } set{ _OrderID = value; } }
        private int _OrderID;
        
        /// <summary>
        /// 是否可以积分兑换
        /// </summary>
        public short IsExchange { get { return _IsExchange; } set{ _IsExchange = value; } }
        private short _IsExchange;
        
        /// <summary>
        /// 赠送积分数
        /// </summary>
        public int IntegralVal { get { return _IntegralVal; } set{ _IntegralVal = value; } }
        private int _IntegralVal;
        
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime MofifyTime { get { return _MofifyTime; } set{ _MofifyTime = value; } }
        private DateTime _MofifyTime;
        
        /// <summary>
        /// 规格值
        /// </summary>
        public string Specjson { get { return _Specjson; } set{ _Specjson = value; } }
        private string _Specjson;
        
        /// <summary>
        /// 规格组合方式
        /// </summary>
        public string Expselected { get { return _Expselected; } set{ _Expselected = value; } }
        private string _Expselected;
        
        /// <summary>
        /// 附件
        /// </summary>
        public string Accessory { get { return _Accessory; } set{ _Accessory = value; } }
        private string _Accessory;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzs0 { get { return _Kzs0; } set{ _Kzs0 = value; } }
        private string _Kzs0;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzv0 { get { return _Kzv0; } set{ _Kzv0 = value; } }
        private string _Kzv0;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzs1 { get { return _Kzs1; } set{ _Kzs1 = value; } }
        private string _Kzs1;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzv1 { get { return _Kzv1; } set{ _Kzv1 = value; } }
        private string _Kzv1;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzs2 { get { return _Kzs2; } set{ _Kzs2 = value; } }
        private string _Kzs2;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzv2 { get { return _Kzv2; } set{ _Kzv2 = value; } }
        private string _Kzv2;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzs3 { get { return _Kzs3; } set{ _Kzs3 = value; } }
        private string _Kzs3;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzv3 { get { return _Kzv3; } set{ _Kzv3 = value; } }
        private string _Kzv3;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzs4 { get { return _Kzs4; } set{ _Kzs4 = value; } }
        private string _Kzs4;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzv4 { get { return _Kzv4; } set{ _Kzv4 = value; } }
        private string _Kzv4;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzs5 { get { return _Kzs5; } set{ _Kzs5 = value; } }
        private string _Kzs5;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzv5 { get { return _Kzv5; } set{ _Kzv5 = value; } }
        private string _Kzv5;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzs6 { get { return _Kzs6; } set{ _Kzs6 = value; } }
        private string _Kzs6;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzv6 { get { return _Kzv6; } set{ _Kzv6 = value; } }
        private string _Kzv6;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzs7 { get { return _Kzs7; } set{ _Kzs7 = value; } }
        private string _Kzs7;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzv7 { get { return _Kzv7; } set{ _Kzv7 = value; } }
        private string _Kzv7;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzs8 { get { return _Kzs8; } set{ _Kzs8 = value; } }
        private string _Kzs8;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzv8 { get { return _Kzv8; } set{ _Kzv8 = value; } }
        private string _Kzv8;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzs9 { get { return _Kzs9; } set{ _Kzs9 = value; } }
        private string _Kzs9;
        
        /// <summary>
        /// 
        /// </summary>
        public string Kzv9 { get { return _Kzv9; } set{ _Kzv9 = value; } }
        private string _Kzv9;
        
        /// <summary>
        /// 
        /// </summary>
        public int DaySales { get { return _DaySales; } set{ _DaySales = value; } }
        private int _DaySales;
        
        /// <summary>
        /// 
        /// </summary>
        public int SevenDaySales { get { return _SevenDaySales; } set{ _SevenDaySales = value; } }
        private int _SevenDaySales;
        
        /// <summary>
        /// 
        /// </summary>
        public int MonthSales { get { return _MonthSales; } set{ _MonthSales = value; } }
        private int _MonthSales;
        
        /// <summary>
        /// 
        /// </summary>
        public short IsSnapup { get { return _IsSnapup; } set{ _IsSnapup = value; } }
        private short _IsSnapup;
        
        /// <summary>
        /// 
        /// </summary>
        public int ConsultCount { get { return _ConsultCount; } set{ _ConsultCount = value; } }
        private int _ConsultCount;
        
        /// <summary>
        /// 
        /// </summary>
        public float EvaluateAvg { get { return _EvaluateAvg; } set{ _EvaluateAvg = value; } }
        private float _EvaluateAvg;
        
        /// <summary>
        /// 
        /// </summary>
        public int EvaluateCount { get { return _EvaluateCount; } set{ _EvaluateCount = value; } }
        private int _EvaluateCount;
        
        /// <summary>
        /// 
        /// </summary>
        public string CarinfoTitle { get { return _CarinfoTitle; } set{ _CarinfoTitle = value; } }
        private string _CarinfoTitle;
        
        /// <summary>
        /// 
        /// </summary>
        public string Specfzids { get { return _Specfzids; } set{ _Specfzids = value; } }
        private string _Specfzids;
        
        /// <summary>
        /// 最多可以兑换的积分
        /// </summary>
        public int Usableintegral { get { return _Usableintegral; } set{ _Usableintegral = value; } }
        private int _Usableintegral;
        
        /// <summary>
        /// 旧描述
        /// </summary>
        public string OrgDesc { get { return _OrgDesc; } set{ _OrgDesc = value; } }
        private string _OrgDesc;
        
        /// <summary>
        /// 资料完成度
        /// </summary>
        public short FineLevel { get { return _FineLevel; } set{ _FineLevel = value; } }
        private short _FineLevel;
        
        /// <summary>
        /// 产地
        /// </summary>
        public string Origin { get { return _Origin; } set{ _Origin = value; } }
        private string _Origin;
        
        /// <summary>
        /// 新品
        /// </summary>
        public short Newproduct { get { return _Newproduct; } set{ _Newproduct = value; } }
        private short _Newproduct;
        
        /// <summary>
        /// 热卖
        /// </summary>
        public short Hotsell { get { return _Hotsell; } set{ _Hotsell = value; } }
        private short _Hotsell;
        
        /// <summary>
        /// 
        /// </summary>
        public int Functionid { get { return _Functionid; } set{ _Functionid = value; } }
        private int _Functionid;
        
        /// <summary>
        /// 
        /// </summary>
        public string Functionname { get { return _Functionname; } set{ _Functionname = value; } }
        private string _Functionname;
        
        /// <summary>
        /// -1普通商品 0主商品 >0 扩展商品的主商品ID
        /// </summary>
        public int ExtGoodsID { get { return _ExtGoodsID; } set{ _ExtGoodsID = value; } }
        private int _ExtGoodsID;
        
        /// <summary>
        /// erp 会员价
        /// </summary>
        public decimal Priceshy { get { return _Priceshy; } set{ _Priceshy = value; } }
        private decimal _Priceshy;
        
        /// <summary>
        /// erp 代销价
        /// </summary>
        public decimal Pricesdx { get { return _Pricesdx; } set{ _Pricesdx = value; } }
        private decimal _Pricesdx;
        
        /// <summary>
        /// erp 指导价
        /// </summary>
        public decimal Priceszd { get { return _Priceszd; } set{ _Priceszd = value; } }
        private decimal _Priceszd;
        
        /// <summary>
        /// 
        /// </summary>
        public string Caroutput { get { return _Caroutput; } set{ _Caroutput = value; } }
        private string _Caroutput;
        
        /// <summary>
        /// 
        /// </summary>
        public string Caryear { get { return _Caryear; } set{ _Caryear = value; } }
        private string _Caryear;
        
        /// <summary>
        /// 
        /// </summary>
        public string Carinfo { get { return _Carinfo; } set{ _Carinfo = value; } }
        private string _Carinfo;
        
        /// <summary>
        /// 车型品牌
        /// </summary>
        public string CarBrand { get { return _CarBrand; } set{ _CarBrand = value; } }
        private string _CarBrand;
        
        /// <summary>
        /// 
        /// </summary>
        public string CarinfonfID { get { return _CarinfonfID; } set{ _CarinfonfID = value; } }
        private string _CarinfonfID;
        
        /// <summary>
        /// 车型ID
        /// </summary>
        public string CarinfoID { get { return _CarinfoID; } set{ _CarinfoID = value; } }
        private string _CarinfoID;
        
        /// <summary>
        /// 车型品牌ID
        /// </summary>
        public string CarBrandID { get { return _CarBrandID; } set{ _CarBrandID = value; } }
        private string _CarBrandID;
        
        /// <summary>
        /// 汽车派件选项id
        /// </summary>
        public string Cpids { get { return _Cpids; } set{ _Cpids = value; } }
        private string _Cpids;
        
        /// <summary>
        /// 商品标签
        /// </summary>
        public string GoodsTag { get { return _GoodsTag; } set{ _GoodsTag = value; } }
        private string _GoodsTag;
        
        /// <summary>
        /// 淘宝标题
        /// </summary>
        public string TaobaoTitle { get { return _TaobaoTitle; } set{ _TaobaoTitle = value; } }
        private string _TaobaoTitle;
        
        /// <summary>
        /// 淘宝描述
        /// </summary>
        public string TaobaoContent { get { return _TaobaoContent; } set{ _TaobaoContent = value; } }
        private string _TaobaoContent;
        
    
        public override void Bind(GetHandler get, SourceType src)
        {
            //1.get:获取数据的方法指针；src：当前提供get的源类型[DataBase|Entity|Collection]
            //
            _B2CGoodsID = Eval<int>(get("B2CGoodsID"));
            _Id = Eval<int>(get("id"));
            _Class_id = Eval<int>(get("class_id"));
            _B2CClassID = Eval<string>(get("B2CClassID"));
            _B2CClassName = Eval<string>(get("B2CClassName"));
            _Goodstitle = Eval<string>(get("goodstitle"));
            _Goodstitle2 = Eval<string>(get("goodstitle2"));
            _Goodspic = Eval<string>(get("goodspic"));
            _Brandid = Eval<int>(get("brandid"));
            _Brandname = Eval<string>(get("brandname"));
            _Goodstxt = Eval<string>(get("goodstxt"));
            _Goodsstate = Eval<short>(get("goodsstate"));
            _Keywords = Eval<string>(get("keywords"));
            _Unit = Eval<string>(get("unit"));
            _BeginTime = Eval<DateTime>(get("BeginTime"));
            _EndTime = Eval<DateTime>(get("EndTime"));
            _MemberPric1 = Eval<decimal>(get("MemberPric1"));
            _MemberPric2 = Eval<decimal>(get("MemberPric2"));
            _MemberPric3 = Eval<decimal>(get("MemberPric3"));
            _MemberPric4 = Eval<decimal>(get("MemberPric4"));
            _MemberPric5 = Eval<decimal>(get("MemberPric5"));
            _MemberPric6 = Eval<decimal>(get("MemberPric6"));
            _Pricescosts = Eval<decimal>(get("pricescosts"));
            _Listprice = Eval<decimal>(get("listprice"));
            _Minpric = Eval<decimal>(get("minpric"));
            _Maxpric = Eval<decimal>(get("maxpric"));
            _BarCode = Eval<long>(get("BarCode"));
            _Weight = Eval<int>(get("Weight"));
            _WeightBz = Eval<int>(get("WeightBz"));
            _ServiceNote = Eval<string>(get("ServiceNote"));
            _SaleCount = Eval<int>(get("SaleCount"));
            _IsInsured = Eval<short>(get("IsInsured"));
            _InsuredScale = Eval<short>(get("InsuredScale"));
            _WarrantyType = Eval<short>(get("WarrantyType"));
            _WarrantyLimit = Eval<int>(get("WarrantyLimit"));
            _RetreatRule = Eval<short>(get("RetreatRule"));
            _ProductType = Eval<short>(get("ProductType"));
            _IsPost = Eval<short>(get("IsPost"));
            _IsPreferential = Eval<short>(get("IsPreferential"));
            _IsBind = Eval<short>(get("IsBind"));
            _IsNotdiscount = Eval<short>(get("IsNotdiscount"));
            _IsPromotion = Eval<short>(get("IsPromotion"));
            _IsaretGift = Eval<short>(get("IsaretGift"));
            _IsGift = Eval<short>(get("IsGift"));
            _BuyNumber = Eval<int>(get("BuyNumber"));
            _CollectNumber = Eval<int>(get("CollectNumber"));
            _BrowsingNumber = Eval<int>(get("BrowsingNumber"));
            _OrderID = Eval<int>(get("OrderID"));
            _IsExchange = Eval<short>(get("IsExchange"));
            _IntegralVal = Eval<int>(get("IntegralVal"));
            _MofifyTime = Eval<DateTime>(get("MofifyTime"));
            _Specjson = Eval<string>(get("specjson"));
            _Expselected = Eval<string>(get("expselected"));
            _Accessory = Eval<string>(get("accessory"));
            _Kzs0 = Eval<string>(get("kzs0"));
            _Kzv0 = Eval<string>(get("kzv0"));
            _Kzs1 = Eval<string>(get("kzs1"));
            _Kzv1 = Eval<string>(get("kzv1"));
            _Kzs2 = Eval<string>(get("kzs2"));
            _Kzv2 = Eval<string>(get("kzv2"));
            _Kzs3 = Eval<string>(get("kzs3"));
            _Kzv3 = Eval<string>(get("kzv3"));
            _Kzs4 = Eval<string>(get("kzs4"));
            _Kzv4 = Eval<string>(get("kzv4"));
            _Kzs5 = Eval<string>(get("kzs5"));
            _Kzv5 = Eval<string>(get("kzv5"));
            _Kzs6 = Eval<string>(get("kzs6"));
            _Kzv6 = Eval<string>(get("kzv6"));
            _Kzs7 = Eval<string>(get("kzs7"));
            _Kzv7 = Eval<string>(get("kzv7"));
            _Kzs8 = Eval<string>(get("kzs8"));
            _Kzv8 = Eval<string>(get("kzv8"));
            _Kzs9 = Eval<string>(get("kzs9"));
            _Kzv9 = Eval<string>(get("kzv9"));
            _DaySales = Eval<int>(get("DaySales"));
            _SevenDaySales = Eval<int>(get("SevenDaySales"));
            _MonthSales = Eval<int>(get("MonthSales"));
            _IsSnapup = Eval<short>(get("IsSnapup"));
            _ConsultCount = Eval<int>(get("ConsultCount"));
            _EvaluateAvg = Eval<float>(get("EvaluateAvg"));
            _EvaluateCount = Eval<int>(get("EvaluateCount"));
            _CarinfoTitle = Eval<string>(get("CarinfoTitle"));
            _Specfzids = Eval<string>(get("specfzids"));
            _Usableintegral = Eval<int>(get("usableintegral"));
            _OrgDesc = Eval<string>(get("OrgDesc"));
            _FineLevel = Eval<short>(get("FineLevel"));
            _Origin = Eval<string>(get("origin"));
            _Newproduct = Eval<short>(get("newproduct"));
            _Hotsell = Eval<short>(get("hotsell"));
            _Functionid = Eval<int>(get("functionid"));
            _Functionname = Eval<string>(get("functionname"));
            _ExtGoodsID = Eval<int>(get("ExtGoodsID"));
            _Priceshy = Eval<decimal>(get("priceshy"));
            _Pricesdx = Eval<decimal>(get("pricesdx"));
            _Priceszd = Eval<decimal>(get("priceszd"));
            _Caroutput = Eval<string>(get("Caroutput"));
            _Caryear = Eval<string>(get("Caryear"));
            _Carinfo = Eval<string>(get("Carinfo"));
            _CarBrand = Eval<string>(get("CarBrand"));
            _CarinfonfID = Eval<string>(get("CarinfonfID"));
            _CarinfoID = Eval<string>(get("CarinfoID"));
            _CarBrandID = Eval<string>(get("CarBrandID"));
            _Cpids = Eval<string>(get("Cpids"));
            _GoodsTag = Eval<string>(get("GoodsTag"));
            _TaobaoTitle = Eval<string>(get("TaobaoTitle"));
            _TaobaoContent = Eval<string>(get("TaobaoContent"));
        }
        
        public override IQBinder Clone()
        {
            return new B2cproduct();
        }
    }
}
    