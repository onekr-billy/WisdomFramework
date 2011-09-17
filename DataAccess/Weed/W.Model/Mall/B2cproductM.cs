
using System;
using System.Data;

using Weed.SDQ;
using W.DataBase;

namespace W.Model.Mall
{
    /// <summary>
    /// 生成:2011/07/12 09:11:26
    /// 作者:自动生成
    ///	
    /// 备注:请确保与[数据表].[字段]的对应关系正确!!!
    /// </summary>
    [Serializable]
    public class B2cproductM : QTable
    {
        public B2cproductM() : base(DbConfig.Mall) { }
        public B2cproductM(SdqConfig config) : base(config) { }
        public B2cproductM(string sdqName) : base(sdqName) { }

        public override IQBinder Clone()
        {
            return new B2cproductM();
        }
        
        protected override void OnInit()
        {
            this.TableName = "b2cproducts";

            //Add(col = New<type>(string name, QDbType type, DbType dbType, bool isKey));
            //
            Add(B2CGoodsID = New<int>("B2CGoodsID", QDbType.NUM, DbType.Int32, true)); 
            Add(Id = New<int>("id", QDbType.NUM, DbType.Int32, false)); 
            Add(Class_id = New<int>("class_id", QDbType.NUM, DbType.Int32, false)); 
            Add(B2CClassID = New<string>("B2CClassID", QDbType.Text, DbType.String, false)); 
            Add(B2CClassName = New<string>("B2CClassName", QDbType.Text, DbType.String, false)); 
            Add(Goodstitle = New<string>("goodstitle", QDbType.Text, DbType.String, false)); 
            Add(Goodstitle2 = New<string>("goodstitle2", QDbType.Text, DbType.String, false)); 
            Add(Goodspic = New<string>("goodspic", QDbType.Text, DbType.String, false)); 
            Add(Brandid = New<int>("brandid", QDbType.NUM, DbType.Int32, false)); 
            Add(Brandname = New<string>("brandname", QDbType.Text, DbType.String, false)); 
            Add(Goodstxt = New<string>("goodstxt", QDbType.Text, DbType.String, false)); 
            Add(Goodsstate = New<short>("goodsstate", QDbType.NUM, DbType.Int16, false)); 
            Add(Keywords = New<string>("keywords", QDbType.Text, DbType.String, false)); 
            Add(Unit = New<string>("unit", QDbType.Text, DbType.String, false)); 
            Add(BeginTime = New<DateTime>("BeginTime", QDbType.Time, DbType.DateTime, false)); 
            Add(EndTime = New<DateTime>("EndTime", QDbType.Time, DbType.DateTime, false)); 
            Add(MemberPric1 = New<decimal>("MemberPric1", QDbType.NUM, DbType.Decimal, false)); 
            Add(MemberPric2 = New<decimal>("MemberPric2", QDbType.NUM, DbType.Decimal, false)); 
            Add(MemberPric3 = New<decimal>("MemberPric3", QDbType.NUM, DbType.Decimal, false)); 
            Add(MemberPric4 = New<decimal>("MemberPric4", QDbType.NUM, DbType.Decimal, false)); 
            Add(MemberPric5 = New<decimal>("MemberPric5", QDbType.NUM, DbType.Decimal, false)); 
            Add(MemberPric6 = New<decimal>("MemberPric6", QDbType.NUM, DbType.Decimal, false)); 
            Add(Pricescosts = New<decimal>("pricescosts", QDbType.NUM, DbType.Decimal, false)); 
            Add(Listprice = New<decimal>("listprice", QDbType.NUM, DbType.Decimal, false)); 
            Add(Minpric = New<decimal>("minpric", QDbType.NUM, DbType.Decimal, false)); 
            Add(Maxpric = New<decimal>("maxpric", QDbType.NUM, DbType.Decimal, false)); 
            Add(BarCode = New<long>("BarCode", QDbType.NUM, DbType.Int64, false)); 
            Add(Weight = New<int>("Weight", QDbType.NUM, DbType.Int32, false)); 
            Add(WeightBz = New<int>("WeightBz", QDbType.NUM, DbType.Int32, false)); 
            Add(ServiceNote = New<string>("ServiceNote", QDbType.Text, DbType.String, false)); 
            Add(SaleCount = New<int>("SaleCount", QDbType.NUM, DbType.Int32, false)); 
            Add(IsInsured = New<short>("IsInsured", QDbType.NUM, DbType.Int16, false)); 
            Add(InsuredScale = New<short>("InsuredScale", QDbType.NUM, DbType.Int16, false)); 
            Add(WarrantyType = New<short>("WarrantyType", QDbType.NUM, DbType.Int16, false)); 
            Add(WarrantyLimit = New<int>("WarrantyLimit", QDbType.NUM, DbType.Int32, false)); 
            Add(RetreatRule = New<short>("RetreatRule", QDbType.NUM, DbType.Int16, false)); 
            Add(ProductType = New<short>("ProductType", QDbType.NUM, DbType.Int16, false)); 
            Add(IsPost = New<short>("IsPost", QDbType.NUM, DbType.Int16, false)); 
            Add(IsPreferential = New<short>("IsPreferential", QDbType.NUM, DbType.Int16, false)); 
            Add(IsBind = New<short>("IsBind", QDbType.NUM, DbType.Int16, false)); 
            Add(IsNotdiscount = New<short>("IsNotdiscount", QDbType.NUM, DbType.Int16, false)); 
            Add(IsPromotion = New<short>("IsPromotion", QDbType.NUM, DbType.Int16, false)); 
            Add(IsaretGift = New<short>("IsaretGift", QDbType.NUM, DbType.Int16, false)); 
            Add(IsGift = New<short>("IsGift", QDbType.NUM, DbType.Int16, false)); 
            Add(BuyNumber = New<int>("BuyNumber", QDbType.NUM, DbType.Int32, false)); 
            Add(CollectNumber = New<int>("CollectNumber", QDbType.NUM, DbType.Int32, false)); 
            Add(BrowsingNumber = New<int>("BrowsingNumber", QDbType.NUM, DbType.Int32, false)); 
            Add(OrderID = New<int>("OrderID", QDbType.NUM, DbType.Int32, false)); 
            Add(IsExchange = New<short>("IsExchange", QDbType.NUM, DbType.Int16, false)); 
            Add(IntegralVal = New<int>("IntegralVal", QDbType.NUM, DbType.Int32, false)); 
            Add(MofifyTime = New<DateTime>("MofifyTime", QDbType.Time, DbType.DateTime, false)); 
            Add(Specjson = New<string>("specjson", QDbType.Text, DbType.String, false)); 
            Add(Expselected = New<string>("expselected", QDbType.Text, DbType.String, false)); 
            Add(Accessory = New<string>("accessory", QDbType.Text, DbType.String, false)); 
            Add(Kzs0 = New<string>("kzs0", QDbType.Text, DbType.String, false)); 
            Add(Kzv0 = New<string>("kzv0", QDbType.Text, DbType.String, false)); 
            Add(Kzs1 = New<string>("kzs1", QDbType.Text, DbType.String, false)); 
            Add(Kzv1 = New<string>("kzv1", QDbType.Text, DbType.String, false)); 
            Add(Kzs2 = New<string>("kzs2", QDbType.Text, DbType.String, false)); 
            Add(Kzv2 = New<string>("kzv2", QDbType.Text, DbType.String, false)); 
            Add(Kzs3 = New<string>("kzs3", QDbType.Text, DbType.String, false)); 
            Add(Kzv3 = New<string>("kzv3", QDbType.Text, DbType.String, false)); 
            Add(Kzs4 = New<string>("kzs4", QDbType.Text, DbType.String, false)); 
            Add(Kzv4 = New<string>("kzv4", QDbType.Text, DbType.String, false)); 
            Add(Kzs5 = New<string>("kzs5", QDbType.Text, DbType.String, false)); 
            Add(Kzv5 = New<string>("kzv5", QDbType.Text, DbType.String, false)); 
            Add(Kzs6 = New<string>("kzs6", QDbType.Text, DbType.String, false)); 
            Add(Kzv6 = New<string>("kzv6", QDbType.Text, DbType.String, false)); 
            Add(Kzs7 = New<string>("kzs7", QDbType.Text, DbType.String, false)); 
            Add(Kzv7 = New<string>("kzv7", QDbType.Text, DbType.String, false)); 
            Add(Kzs8 = New<string>("kzs8", QDbType.Text, DbType.String, false)); 
            Add(Kzv8 = New<string>("kzv8", QDbType.Text, DbType.String, false)); 
            Add(Kzs9 = New<string>("kzs9", QDbType.Text, DbType.String, false)); 
            Add(Kzv9 = New<string>("kzv9", QDbType.Text, DbType.String, false)); 
            Add(DaySales = New<int>("DaySales", QDbType.NUM, DbType.Int32, false)); 
            Add(SevenDaySales = New<int>("SevenDaySales", QDbType.NUM, DbType.Int32, false)); 
            Add(MonthSales = New<int>("MonthSales", QDbType.NUM, DbType.Int32, false)); 
            Add(IsSnapup = New<short>("IsSnapup", QDbType.NUM, DbType.Int16, false)); 
            Add(ConsultCount = New<int>("ConsultCount", QDbType.NUM, DbType.Int32, false)); 
            Add(EvaluateAvg = New<float>("EvaluateAvg", QDbType.NUM, DbType.Single, false)); 
            Add(EvaluateCount = New<int>("EvaluateCount", QDbType.NUM, DbType.Int32, false)); 
            Add(CarinfoTitle = New<string>("CarinfoTitle", QDbType.Text, DbType.String, false)); 
            Add(Specfzids = New<string>("specfzids", QDbType.Text, DbType.String, false)); 
            Add(Usableintegral = New<int>("usableintegral", QDbType.NUM, DbType.Int32, false)); 
            Add(OrgDesc = New<string>("OrgDesc", QDbType.Text, DbType.String, false)); 
            Add(FineLevel = New<short>("FineLevel", QDbType.NUM, DbType.Int16, false)); 
            Add(Origin = New<string>("origin", QDbType.Text, DbType.String, false)); 
            Add(Newproduct = New<short>("newproduct", QDbType.NUM, DbType.Int16, false)); 
            Add(Hotsell = New<short>("hotsell", QDbType.NUM, DbType.Int16, false)); 
            Add(Functionid = New<int>("functionid", QDbType.NUM, DbType.Int32, false)); 
            Add(Functionname = New<string>("functionname", QDbType.Text, DbType.String, false)); 
            Add(ExtGoodsID = New<int>("ExtGoodsID", QDbType.NUM, DbType.Int32, false)); 
            Add(Priceshy = New<decimal>("priceshy", QDbType.NUM, DbType.Decimal, false)); 
            Add(Pricesdx = New<decimal>("pricesdx", QDbType.NUM, DbType.Decimal, false)); 
            Add(Priceszd = New<decimal>("priceszd", QDbType.NUM, DbType.Decimal, false)); 
            Add(Caroutput = New<string>("Caroutput", QDbType.Text, DbType.String, false)); 
            Add(Caryear = New<string>("Caryear", QDbType.Text, DbType.String, false)); 
            Add(Carinfo = New<string>("Carinfo", QDbType.Text, DbType.String, false)); 
            Add(CarBrand = New<string>("CarBrand", QDbType.Text, DbType.String, false)); 
            Add(CarinfonfID = New<string>("CarinfonfID", QDbType.Text, DbType.String, false)); 
            Add(CarinfoID = New<string>("CarinfoID", QDbType.Text, DbType.String, false)); 
            Add(CarBrandID = New<string>("CarBrandID", QDbType.Text, DbType.String, false)); 
            Add(Cpids = New<string>("Cpids", QDbType.Text, DbType.String, false)); 
            Add(GoodsTag = New<string>("GoodsTag", QDbType.Text, DbType.String, false)); 
            Add(TaobaoTitle = New<string>("TaobaoTitle", QDbType.Text, DbType.String, false)); 
            Add(TaobaoContent = New<string>("TaobaoContent", QDbType.Text, DbType.String, false)); 
        }

		/// <summary>
        /// B2C商品ID
        /// </summary>
        public QColumnT<int> B2CGoodsID;
		/// <summary>
        /// 产品ID
        /// </summary>
        public QColumnT<int> Id;
		/// <summary>
        /// 产品功能分类ID
        /// </summary>
        public QColumnT<int> Class_id;
		/// <summary>
        /// 虚拟分类ID
        /// </summary>
        public QColumnT<string> B2CClassID;
		/// <summary>
        /// 商品分类名称
        /// </summary>
        public QColumnT<string> B2CClassName;
		/// <summary>
        /// 商品特征名
        /// </summary>
        public QColumnT<string> Goodstitle;
		/// <summary>
        /// 商品销售名
        /// </summary>
        public QColumnT<string> Goodstitle2;
		/// <summary>
        /// 商品图片
        /// </summary>
        public QColumnT<string> Goodspic;
		/// <summary>
        /// 品牌ID
        /// </summary>
        public QColumnT<int> Brandid;
		/// <summary>
        /// 品牌名称
        /// </summary>
        public QColumnT<string> Brandname;
		/// <summary>
        /// 商品介绍
        /// </summary>
        public QColumnT<string> Goodstxt;
		/// <summary>
        /// 上下架状态
        /// </summary>
        public QColumnT<short> Goodsstate;
		/// <summary>
        /// 关键词
        /// </summary>
        public QColumnT<string> Keywords;
		/// <summary>
        /// 计量单位
        /// </summary>
        public QColumnT<string> Unit;
		/// <summary>
        /// 上架时间
        /// </summary>
        public QColumnT<DateTime> BeginTime;
		/// <summary>
        /// 下架时间
        /// </summary>
        public QColumnT<DateTime> EndTime;
		/// <summary>
        /// 普通会员价
        /// </summary>
        public QColumnT<decimal> MemberPric1;
		/// <summary>
        /// 铜牌会员
        /// </summary>
        public QColumnT<decimal> MemberPric2;
		/// <summary>
        /// 银牌会员
        /// </summary>
        public QColumnT<decimal> MemberPric3;
		/// <summary>
        /// 金牌会员
        /// </summary>
        public QColumnT<decimal> MemberPric4;
		/// <summary>
        /// 待定
        /// </summary>
        public QColumnT<decimal> MemberPric5;
		/// <summary>
        /// 待定
        /// </summary>
        public QColumnT<decimal> MemberPric6;
		/// <summary>
        /// 成本价
        /// </summary>
        public QColumnT<decimal> Pricescosts;
		/// <summary>
        /// 市场价
        /// </summary>
        public QColumnT<decimal> Listprice;
		/// <summary>
        /// 最小价格
        /// </summary>
        public QColumnT<decimal> Minpric;
		/// <summary>
        /// 最大价格
        /// </summary>
        public QColumnT<decimal> Maxpric;
		/// <summary>
        /// 货号
        /// </summary>
        public QColumnT<long> BarCode;
		/// <summary>
        /// 重量
        /// </summary>
        public QColumnT<int> Weight;
		/// <summary>
        /// 包装重量
        /// </summary>
        public QColumnT<int> WeightBz;
		/// <summary>
        /// 售后服务
        /// </summary>
        public QColumnT<string> ServiceNote;
		/// <summary>
        /// 售销数量
        /// </summary>
        public QColumnT<int> SaleCount;
		/// <summary>
        /// 是否保价
        /// </summary>
        public QColumnT<short> IsInsured;
		/// <summary>
        /// 保价比例
        /// </summary>
        public QColumnT<short> InsuredScale;
		/// <summary>
        /// 保修方式
        /// </summary>
        public QColumnT<short> WarrantyType;
		/// <summary>
        /// 保修时限
        /// </summary>
        public QColumnT<int> WarrantyLimit;
		/// <summary>
        /// 退换规则
        /// </summary>
        public QColumnT<short> RetreatRule;
		/// <summary>
        /// 产品类型
        /// </summary>
        public QColumnT<short> ProductType;
		/// <summary>
        /// 是否包邮
        /// </summary>
        public QColumnT<short> IsPost;
		/// <summary>
        /// 是否接受优惠券
        /// </summary>
        public QColumnT<short> IsPreferential;
		/// <summary>
        /// 是否有捆绑商品
        /// </summary>
        public QColumnT<short> IsBind;
		/// <summary>
        /// 是否是不打折商品
        /// </summary>
        public QColumnT<short> IsNotdiscount;
		/// <summary>
        /// 是否促销商品
        /// </summary>
        public QColumnT<short> IsPromotion;
		/// <summary>
        /// 是否有赠品
        /// </summary>
        public QColumnT<short> IsaretGift;
		/// <summary>
        ///  是否是赠品
        /// </summary>
        public QColumnT<short> IsGift;
		/// <summary>
        /// 购买次数
        /// </summary>
        public QColumnT<int> BuyNumber;
		/// <summary>
        /// 收藏次数
        /// </summary>
        public QColumnT<int> CollectNumber;
		/// <summary>
        /// 留言次数
        /// </summary>
        public QColumnT<int> BrowsingNumber;
		/// <summary>
        /// 排序ID
        /// </summary>
        public QColumnT<int> OrderID;
		/// <summary>
        /// 是否可以积分兑换
        /// </summary>
        public QColumnT<short> IsExchange;
		/// <summary>
        /// 赠送积分数
        /// </summary>
        public QColumnT<int> IntegralVal;
		/// <summary>
        /// 最后更新时间
        /// </summary>
        public QColumnT<DateTime> MofifyTime;
		/// <summary>
        /// 规格值
        /// </summary>
        public QColumnT<string> Specjson;
		/// <summary>
        /// 规格组合方式
        /// </summary>
        public QColumnT<string> Expselected;
		/// <summary>
        /// 附件
        /// </summary>
        public QColumnT<string> Accessory;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzs0;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzv0;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzs1;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzv1;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzs2;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzv2;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzs3;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzv3;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzs4;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzv4;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzs5;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzv5;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzs6;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzv6;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzs7;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzv7;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzs8;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzv8;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzs9;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Kzv9;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<int> DaySales;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<int> SevenDaySales;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<int> MonthSales;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<short> IsSnapup;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<int> ConsultCount;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<float> EvaluateAvg;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<int> EvaluateCount;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> CarinfoTitle;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Specfzids;
		/// <summary>
        /// 最多可以兑换的积分
        /// </summary>
        public QColumnT<int> Usableintegral;
		/// <summary>
        /// 旧描述
        /// </summary>
        public QColumnT<string> OrgDesc;
		/// <summary>
        /// 资料完成度
        /// </summary>
        public QColumnT<short> FineLevel;
		/// <summary>
        /// 产地
        /// </summary>
        public QColumnT<string> Origin;
		/// <summary>
        /// 新品
        /// </summary>
        public QColumnT<short> Newproduct;
		/// <summary>
        /// 热卖
        /// </summary>
        public QColumnT<short> Hotsell;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<int> Functionid;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Functionname;
		/// <summary>
        /// -1普通商品 0主商品 >0 扩展商品的主商品ID
        /// </summary>
        public QColumnT<int> ExtGoodsID;
		/// <summary>
        /// erp 会员价
        /// </summary>
        public QColumnT<decimal> Priceshy;
		/// <summary>
        /// erp 代销价
        /// </summary>
        public QColumnT<decimal> Pricesdx;
		/// <summary>
        /// erp 指导价
        /// </summary>
        public QColumnT<decimal> Priceszd;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Caroutput;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Caryear;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> Carinfo;
		/// <summary>
        /// 车型品牌
        /// </summary>
        public QColumnT<string> CarBrand;
		/// <summary>
        /// 
        /// </summary>
        public QColumnT<string> CarinfonfID;
		/// <summary>
        /// 车型ID
        /// </summary>
        public QColumnT<string> CarinfoID;
		/// <summary>
        /// 车型品牌ID
        /// </summary>
        public QColumnT<string> CarBrandID;
		/// <summary>
        /// 汽车派件选项id
        /// </summary>
        public QColumnT<string> Cpids;
		/// <summary>
        /// 商品标签
        /// </summary>
        public QColumnT<string> GoodsTag;
		/// <summary>
        /// 淘宝标题
        /// </summary>
        public QColumnT<string> TaobaoTitle;
		/// <summary>
        /// 淘宝描述
        /// </summary>
        public QColumnT<string> TaobaoContent;
    }
}
    