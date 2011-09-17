<script>function GetRenZhengHtml(){
var str,id;
id = GetRandomChars();
str = "<input type='hidden' name='renzid' id='renzid' value="+id+">";
str += "<img onclick='ReIntiRenZheng(this)' src=' alidateCode alidateCode/img.aspx?id="+id+"' onmousemove=this.style.cursor='hand'>";
return str;}
function ReIntiRenZheng(thisImg){
var renzid,id;
renzid = document.getElementById("renzid");
id = GetRandomChars();
renzid.value = id;
thisImg.src = " alidateCode/img.aspx?id="+id;}
function GetRandomChars(){
var id = Math.random().toString(16);
var id1 = Math.random().toString(16);
return id.substr(2,8)+id1.substr(2,8);}
document.write(GetRenZhengHtml());
</script> 



private void Page_Load(object sender, System.EventArgs e)
		{
			String id = Request.QueryString["id"];
			if(id != null && id.Length != 0)
			{
				if(id.Length > 16)
				{
					id = id.Substring(0,16);
				}
			
				String code = GenVCode.GenCode();
				(new VCDal()).Generate(id,code);

				Response.Buffer = true;
				(new GenVCode()).Set(Response.OutputStream,code,true);
			}
			else
			{
				(new GenVCode()).Set(Response.OutputStream,"",false);
			} 
		} 