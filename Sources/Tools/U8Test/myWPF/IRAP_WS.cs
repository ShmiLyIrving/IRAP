using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Web.Services;
using System.Windows.Forms;
using System.Xml;
using UFIDA.U8.U8APIFramework;
using UFIDA.U8.U8APIFramework.Parameter;
using UFIDA.U8.U8MOMAPIFramework;
namespace myWPF
{
    /// <summary>
    /// IRAP_WS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class IRAP_WS : System.Web.Services.WebService
    {
        [WebMethod]
        public string test(string thisstring)
        {
            return thisstring + "ok";
        }
        public delegate void OutputLog(string msg, string mode, ToolTipIcon icon);
        public OutputLog Outputlog;

        //材料出库单
        [WebMethod]
        public bool MaterialOutAdd(System.String sVouchType,
        string DomHeadXml,
        string domBodyXml,
        System.Object domPosition,
        out System.String errMsg,
        object cnnFromO,
        ref System.String VouchId,
        out object domMsgO,
        System.Boolean bCheck,
        System.Boolean bBeforCheckStock,
        System.Boolean bIsRedVouch,
        System.String sAddedState,
        System.Boolean bReMote)
        {
            try
            {
                //MSXML2.IXMLDOMDocument2 DomHead = (MSXML2.IXMLDOMDocument2)DomHeadO;
                //MSXML2.IXMLDOMDocument2 domBody = (MSXML2.IXMLDOMDocument2)domBodyO;
                domMsgO = new MSXML2.DOMDocumentClass();
                MSXML2.IXMLDOMDocument2 domMsg = (MSXML2.IXMLDOMDocument2)domMsgO;
                ADODB.Connection cnnFrom = (ADODB.Connection)cnnFromO;
                //第一步：构造u8login对象并登陆(引用U8API类库中的Interop.U8Login.dll)
                //如果当前环境中有login对象则可以省去第一步
                U8Login.clsLogin u8Login = new U8Login.clsLogin();
                String sAccID = SysParams.Instance.U8VouchCode;
                String sUserID = SysParams.Instance.U8uid;
                String sPassword = SysParams.Instance.U8pwd;
                String sServer = SysParams.Instance.U8ServerIP;
                String sSubId = "DP";
                String sYear = "2017";
                String sDate = "2017-03-13";
                String sSerial = "";
                if (!u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUserID, ref sPassword, ref sDate, ref sServer, ref sSerial))
                {
                    errMsg = "登陆失败，原因：" + u8Login.ShareString;
                    WriteLog.Instance.Write(errMsg);
                    Marshal.FinalReleaseComObject(u8Login);
                    domMsgO = null;
                    return false;
                }

                //第二步：构造环境上下文对象，传入login，并按需设置其它上下文参数
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = u8Login;


                //第三步：设置API地址标识(Url)
                //当前API：添加新单据的地址标识为：U8API/MaterialOut/Add
                U8ApiAddress myApiAddress = new U8ApiAddress("U8API/MaterialOut/Add");

                //第四步：构造APIBroker
                U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

                //第五步：API参数赋值

                //给普通参数sVouchType赋值。此参数的数据类型为System.String，此参数按值传递，表示单据类型：10

                broker.AssignNormalValue("sVouchType", sVouchType);

                //给BO表头参数DomHead赋值，此BO参数的业务类型为产成品入库单，属表头参数。BO参数均按引用传递
                //提示：给BO表头参数DomHead赋值有两种方法

                //方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("DomHead", DomHead);

                //方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject DomHead = broker.GetBoParam("DomHead");
                setBusinessObject(ref DomHead, DomHeadXml);
                //DomHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
                ////给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //DomHead[0]["id"] = "1"; //主关键字段，int类型
                //DomHead[0]["ccode"] = "1"; //入库单号，string类型
                //DomHead[0]["ddate"] = DateTime.Now.ToString(); ; //入库日期，DateTime类型
                //DomHead[0]["cwhname"] = "1"; //仓库，string类型

                /////***************************** 以下是非必输字段 ****************************/
                //DomHead[0]["cmodifyperson"] = "1"; //修改人，string类型
                //DomHead[0]["dmodifydate"] = DateTime.Now.ToString(); //修改日期，DateTime类型
                //DomHead[0]["dnmaketime"] = "1"; //制单时间，DateTime类型
                //DomHead[0]["dnmodifytime"] = "1"; //修改时间，DateTime类型
                //DomHead[0]["dnverifytime"] = "1"; //审核时间，DateTime类型
                //DomHead[0]["dchkdate"] = DateTime.Now.ToString();  //检验日期，DateTime类型
                //DomHead[0]["iavaquantity"] = "1"; //可用量，string类型
                //DomHead[0]["iavanum"] = "1"; //可用件数，string类型
                //DomHead[0]["ipresentnum"] = "1"; //现存件数，string类型
                //DomHead[0]["ufts"] = "1490581317"; //时间戳，string类型
                //DomHead[0]["cpspcode"] = "1"; //产品，string类型
                //DomHead[0]["iproorderid"] = "1"; //生产订单ID，string类型
                //DomHead[0]["cmpocode"] = "1"; //生产订单号，string类型
                //DomHead[0]["cprobatch"] = "1"; //生产批号，string类型
                //DomHead[0]["iverifystate"] = "1"; //iverifystate，string类型
                //DomHead[0]["iswfcontrolled"] = "1"; //iswfcontrolled，string类型
                //DomHead[0]["ireturncount"] = "1"; //ireturncount，string类型
                //DomHead[0]["cdepname"] = "1"; //部门，string类型
                //DomHead[0]["crdname"] = "1"; //入库类别，string类型
                //DomHead[0]["dveridate"] = DateTime.Now.ToString(); //审核日期，DateTime类型
                //DomHead[0]["cmemo"] = "1"; //备注，string类型
                //DomHead[0]["cchkperson"] = "1"; //检验员，string类型
                //DomHead[0]["cmaker"] = "1"; //制单人，string类型
                //DomHead[0]["chandler"] = "1"; //审核人，string类型
                //DomHead[0]["itopsum"] = "1"; //最高库存量，string类型
                //DomHead[0]["caccounter"] = "1"; //记账人，string类型
                //DomHead[0]["ilowsum"] = "1"; //最低库存量，string类型
                //DomHead[0]["ipresent"] = "1"; //现存量，string类型
                //DomHead[0]["isafesum"] = "1"; //安全库存量，string类型
                //DomHead[0]["cbustype"] = "1"; //业务类型，int类型
                //DomHead[0]["cpersonname"] = "1"; //业务员，string类型
                //DomHead[0]["cdefine1"] = "1"; //表头自定义项1，string类型
                //DomHead[0]["cdefine11"] = "1"; //表头自定义项11，string类型
                //DomHead[0]["cdefine12"] = "1"; //表头自定义项12，string类型
                //DomHead[0]["cdefine13"] = "1"; //表头自定义项13，string类型
                //DomHead[0]["cdefine14"] = "1"; //表头自定义项14，string类型
                //DomHead[0]["cdefine2"] = "1"; //表头自定义项2，string类型
                //DomHead[0]["cdefine3"] = "1"; //表头自定义项3，string类型
                //DomHead[0]["csource"] = "1"; //单据来源，int类型
                //DomHead[0]["cdefine5"] = "1"; //表头自定义项5，int类型
                //DomHead[0]["cdefine15"] = "1"; //表头自定义项15，int类型
                //DomHead[0]["cdefine6"] = DateTime.Now.ToString(); //表头自定义项6，DateTime类型
                //DomHead[0]["brdflag"] = "1"; //收发标志，string类型
                //DomHead[0]["cdefine7"] = "1"; //表头自定义项7，double类型
                //DomHead[0]["cdefine16"] = "1"; //表头自定义项16，double类型
                //DomHead[0]["cdefine8"] = "1"; //表头自定义项8，string类型
                //DomHead[0]["cdefine9"] = "1"; //表头自定义项9，string类型
                //DomHead[0]["cdefine10"] = "1"; //表头自定义项10，string类型
                //DomHead[0]["cvouchtype"] = "1"; //单据类型，string类型
                //DomHead[0]["cwhcode"] = "1"; //仓库编码，string类型
                //DomHead[0]["crdcode"] = "1"; //入库类别编码，string类型
                //DomHead[0]["cdepcode"] = "1"; //部门编码，string类型
                //DomHead[0]["cpersoncode"] = "1"; //业务员编码，string类型
                //DomHead[0]["vt_id"] = "1"; //模版号，int类型
                //DomHead[0]["cdefine4"] = DateTime.Now.ToString();//表头自定义项4，DateTime类型

                ////给BO表体参数domBody赋值，此BO参数的业务类型为产成品入库单，属表体参数。BO参数均按引用传递
                ////提示：给BO表体参数domBody赋值有两种方法

                ////方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("domBody", domBody);

                ////方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject domBody = broker.GetBoParam("domBody");
                setBusinessObject(ref domBody, domBodyXml);
                //domBody.RowCount = 1; //设置BO对象行数
                //////可以自由设置BO对象行数为大于零的整数，也可以不设置而自动增加行数
                //////给BO对象的字段赋值，值可以是真实类型，也可以是无类型字符串
                //////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                /////****************************** 以下是必输字段 ****************************/
                //domBody[0]["autoid"] = "1"; //主关键字段，int类型
                //domBody[0]["cinvcode"] = "1"; //产品编码，string类型
                //domBody[0]["editprop"] = "A"; //编辑属性：A表新增，M表修改，D表删除，string类型

                /////***************************** 以下是非必输字段 ****************************/
                //domBody[0]["id"] = "1"; //与主表关联项，int类型
                //domBody[0]["cinvaddcode"] = "1"; //产品代码，string类型
                //domBody[0]["cinvname"] = "1"; //产品名称，string类型
                //domBody[0]["cinvstd"] = "1"; //规格型号，string类型
                //domBody[0]["cinvm_unit"] = "1"; //主计量单位，string类型
                //domBody[0]["cinva_unit"] = "1"; //库存单位，string类型
                //domBody[0]["creplaceitem"] = "1"; //替换件，string类型
                //domBody[0]["cposition"] = "1"; //货位编码，string类型
                //domBody[0]["cinvdefine1"] = "1"; //存货自定义项1，string类型
                //domBody[0]["cinvdefine2"] = "1"; //存货自定义项2，string类型
                //domBody[0]["cinvdefine3"] = "1"; //存货自定义项3，string类型
                //domBody[0]["cfree1"] = ""; //存货自由项1，string类型
                //domBody[0]["cbatchproperty1"] = ""; //批次属性1，double类型
                //domBody[0]["cbatchproperty2"] = ""; //批次属性2，double类型
                //domBody[0]["cfree2"] = "1"; //存货自由项2，string类型
                //domBody[0]["cbatch"] = "1"; //批号，string类型
                //domBody[0]["iinvexchrate"] = "1"; //换算率，double类型
                //domBody[0]["inum"] = "1"; //件数，double类型
                //domBody[0]["iquantity"] = "1"; //数量，double类型
                //domBody[0]["iunitcost"] = "1"; //单价，double类型
                //domBody[0]["iprice"] = "1"; //金额，double类型
                //domBody[0]["ipunitcost"] = "1"; //计划单价，double类型
                //domBody[0]["ipprice"] = "1"; //计划金额，double类型
                //domBody[0]["dvdate"] = DateTime.Now.ToString(); //失效日期，DateTime类型
                //domBody[0]["isoutquantity"] = "1"; //累计出库数量，double类型
                //domBody[0]["isoutnum"] = "1"; //累计出库件数，double类型
                //domBody[0]["dsdate"] = DateTime.Now.ToString(); ; //结算日期，DateTime类型
                //domBody[0]["ifquantity"] = "1"; //实际数量，double类型
                //domBody[0]["ifnum"] = "1"; //实际件数，double类型
                //domBody[0]["cvouchcode"] = "1"; //对应入库单id，string类型
                //domBody[0]["cfree3"] = "1"; //存货自由项3，string类型
                //domBody[0]["cbatchproperty3"] = "1"; //批次属性3，double类型
                //domBody[0]["cbatchproperty4"] = "1"; //批次属性4，double类型
                //domBody[0]["cfree4"] = "1"; //存货自由项4，string类型
                //domBody[0]["cfree5"] = "1"; //存货自由项5，string类型
                //domBody[0]["cbatchproperty5"] = "1"; //批次属性5，double类型
                //domBody[0]["cbatchproperty6"] = "1"; //批次属性6，string类型
                //domBody[0]["cfree6"] = "1"; //存货自由项6，string类型
                //domBody[0]["cfree7"] = "1"; //存货自由项7，string类型
                //domBody[0]["cbatchproperty7"] = "1"; //批次属性7，string类型
                //domBody[0]["cbatchproperty8"] = "1"; //批次属性8，string类型
                //domBody[0]["cfree8"] = "1"; //存货自由项8，string类型
                //domBody[0]["cfree9"] = "1"; //存货自由项9，string类型
                //domBody[0]["cbatchproperty9"] = "1"; //批次属性9，string类型
                //domBody[0]["cbatchproperty10"] = DateTime.Now.ToString(); //批次属性10，DateTime类型
                //domBody[0]["cfree10"] = "1"; //存货自由项10，string类型
                //domBody[0]["cdefine36"] = "1"; //表体自定义项15，DateTime类型
                //domBody[0]["cdefine37"] = "1"; //表体自定义项16，DateTime类型
                //domBody[0]["cinvdefine13"] = "1"; //存货自定义项13，string类型
                //domBody[0]["cinvdefine14"] = "1"; //存货自定义项14，string类型
                //domBody[0]["cinvdefine15"] = "1"; //存货自定义项15，string类型
                //domBody[0]["cinvdefine16"] = "1"; //存货自定义项16，string类型
                //domBody[0]["inquantity"] = "1"; //应收数量，double类型
                //domBody[0]["innum"] = "1"; //应收件数，double类型
                //domBody[0]["dmadedate"] = DateTime.Now.ToString(); //生产日期，DateTime类型
                //domBody[0]["impoids"] = "1"; //生产订单子表ID，int类型
                ////domBody[0]["icheckids"] = "1"; //检验单子表ID，int类型
                //domBody[0]["isodid"] = "1"; //销售订单子表ID，string类型
                ////domBody[0]["brelated"] = "1"; //是否联副产品，int类型
                //domBody[0]["cbvencode"] = "1"; //供应商编码，string类型
                //domBody[0]["cinvouchcode"] = "1"; //对应入库单号，string类型
                //domBody[0]["cvenname"] = "1"; //供应商，string类型
                //domBody[0]["imassdate"] = DateTime.Now.ToString(); //保质期，int类型
                //domBody[0]["cassunit"] = "1"; //库存单位码，string类型
                //domBody[0]["corufts"] = "1490581317"; //对应单据时间戳，string类型
                //domBody[0]["cposname"] = "1"; //货位，string类型
                //domBody[0]["cmolotcode"] = "1"; //生产批号，string类型
                //domBody[0]["cmassunit"] = "1"; //保质期单位，int类型
                //domBody[0]["csocode"] = "1"; //需求跟踪号，string类型
                //domBody[0]["cmocode"] = "1"; //生产订单号，string类型
                //domBody[0]["cvmivencode"] = "1"; //代管商代码，string类型
                //domBody[0]["cvmivenname"] = "1"; //代管商，string类型
                //domBody[0]["bvmiused"] = "1"; //代管消耗标识，int类型
                //domBody[0]["ivmisettlequantity"] = "1"; //代管挂账确认单数量，double类型
                //domBody[0]["ivmisettlenum"] = "1"; //代管挂账确认单件数，double类型
                //domBody[0]["cdemandmemo"] = "1"; //需求分类代号说明，string类型
                //domBody[0]["iordertype"] = "1"; //销售订单类别，int类型
                //domBody[0]["iorderdid"] = "1"; //iorderdid，int类型
                //domBody[0]["iordercode"] = "1"; //销售订单号，string类型
                //domBody[0]["iorderseq"] = "1"; //销售订单行号，string类型
                //domBody[0]["iexpiratdatecalcu"] = DateTime.Now.ToString(); //有效期推算方式，int类型
                //domBody[0]["cexpirationdate"] = DateTime.Now.ToString();//有效期至，string类型
                //domBody[0]["dexpirationdate"] = DateTime.Now.ToString(); //有效期计算项，string类型
                //domBody[0]["cciqbookcode"] = "1"; //手册号，string类型
                //domBody[0]["ibondedsumqty"] = "1"; //累计保税处理抽取数量，string类型
                //domBody[0]["copdesc"] = "1"; //工序说明，string类型
                //domBody[0]["cmworkcentercode"] = "1"; //工作中心编码，string类型
                //domBody[0]["cmworkcenter"] = "1"; //工作中心，string类型
                //domBody[0]["isotype"] = "1"; //需求跟踪方式，int类型
                //domBody[0]["cbaccounter"] = "1"; //记账人，string类型
                //domBody[0]["bcosting"] = "1"; //是否核算，string类型
                //domBody[0]["isoseq"] = "1"; //需求跟踪行号，string类型
                //domBody[0]["imoseq"] = "1"; //生产订单行号，string类型
                //domBody[0]["iopseq"] = "1"; //工序行号，string类型
                //domBody[0]["cdefine34"] = "1"; //表体自定义项13，int类型
                //domBody[0]["cdefine35"] = "1"; //表体自定义项14，int类型
                //domBody[0]["cdefine22"] = "1"; //表体自定义项1，string类型
                //domBody[0]["cdefine28"] = "1"; //表体自定义项7，string类型
                //domBody[0]["cdefine29"] = "1"; //表体自定义项8，string类型
                //domBody[0]["cdefine30"] = "1"; //表体自定义项9，string类型
                //domBody[0]["cdefine31"] = "1"; //表体自定义项10，string类型
                //domBody[0]["cdefine32"] = "1"; //表体自定义项11，string类型
                //domBody[0]["cdefine33"] = "1"; //表体自定义项12，string类型
                //domBody[0]["cinvdefine4"] = "1"; //存货自定义项4，string类型
                //domBody[0]["cinvdefine5"] = "1"; //存货自定义项5，string类型
                //domBody[0]["cinvdefine6"] = "1"; //存货自定义项6，string类型
                //domBody[0]["cinvdefine7"] = "1"; //存货自定义项7，string类型
                //domBody[0]["cinvdefine8"] = "1"; //存货自定义项8，string类型
                //domBody[0]["cinvdefine9"] = "1"; //存货自定义项9，string类型
                //domBody[0]["cinvdefine10"] = "1"; //存货自定义项10，string类型
                //domBody[0]["cinvdefine11"] = "1"; //存货自定义项11，string类型
                //domBody[0]["cinvdefine12"] = "1"; //存货自定义项12，string类型
                //domBody[0]["cbarcode"] = "1"; //条形码，string类型
                //domBody[0]["cdefine23"] = "1"; //表体自定义项2，string类型
                //domBody[0]["cdefine24"] = "1"; //表体自定义项3，string类型
                //domBody[0]["cdefine25"] = "1"; //表体自定义项4，string类型
                //domBody[0]["itrids"] = "1"; //特殊单据子表标识，double类型
                //domBody[0]["cdefine26"] = "1"; //表体自定义项5，double类型
                //domBody[0]["cdefine27"] = "1"; //表体自定义项6，double类型
                //domBody[0]["citemcode"] = "1"; //项目编码，string类型
                //domBody[0]["cname"] = "1"; //项目，string类型
                //domBody[0]["citem_class"] = "1"; //项目大类编码，string类型
                //domBody[0]["citemcname"] = "1"; //项目大类名称，string类型

                //给普通参数domPosition赋值。此参数的数据类型为System.Object，此参数按引用传递，表示货位：传空
                broker.AssignNormalValue("domPosition", domPosition);

                //该参数errMsg为OUT型参数，由于其数据类型为System.String，为一般值类型，因此不必传入一个参数变量。在API调用返回时，可以通过GetResult("errMsg")获取其值

                //给普通参数cnnFrom赋值。此参数的数据类型为ADODB.Connection，此参数按引用传递，表示连接对象,如果由调用方控制事务，则需要设置此连接对象，否则传空
                broker.AssignNormalValue("cnnFrom", cnnFrom);

                //该参数VouchId为INOUT型普通参数。此参数的数据类型为System.String，此参数按值传递。在API调用返回时，可以通过GetResult("VouchId")获取其值
                broker.AssignNormalValue("VouchId", VouchId);

                //该参数domMsg为OUT型参数，由于其数据类型为MSXML2.IXMLDOMDocument2，非一般值类型，因此必须传入一个参数变量。在API调用返回时，可以直接使用该参数

                broker.AssignNormalValue("domMsg", domMsg);
                domMsgO = domMsg;

                //给普通参数bCheck赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否控制可用量。
                broker.AssignNormalValue("bCheck", bCheck);

                //给普通参数bBeforCheckStock赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示检查可用量
                broker.AssignNormalValue("bBeforCheckStock", bBeforCheckStock);

                //给普通参数bIsRedVouch赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否红字单据
                broker.AssignNormalValue("bIsRedVouch", bIsRedVouch);

                //给普通参数sAddedState赋值。此参数的数据类型为System.String，此参数按值传递，表示传空字符串
                broker.AssignNormalValue("sAddedState", sAddedState);

                //给普通参数bReMote赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否远程：转入false
                broker.AssignNormalValue("bReMote", bReMote);

                //第六步：调用API
                if (!broker.Invoke())
                {
                    //错误处理
                    Exception apiEx = broker.GetException();
                    if (apiEx != null)
                    {
                        if (apiEx is MomSysException)
                        {
                            MomSysException sysEx = apiEx as MomSysException;
                            WriteLog.Instance.Write("系统异常：" + sysEx.Message,"");
                            //todo:异常处理
                        }
                        else if (apiEx is MomBizException)
                        {
                            MomBizException bizEx = apiEx as MomBizException;
                            WriteLog.Instance.Write("API异常：" + bizEx.Message,"");
                            //todo:异常处理
                        }
                        //异常原因
                        String exReason = broker.GetExceptionString();
                        if (exReason.Length != 0)
                        {
                            WriteLog.Instance.Write("异常原因：" + exReason,"");
                        }
                    }
                    //结束本次调用，释放API资源
                    broker.Release();
                    domMsgO = null;
                    errMsg = apiEx.Message+apiEx.StackTrace;
                    return false;

                }

                //第七步：获取返回结果

                //获取返回值
                //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值:true:成功,false:失败
                System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

                //获取out/inout参数值

                //获取普通OUT参数errMsg。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String errMsgRet = broker.GetResult("errMsg") as System.String;
                errMsg = errMsgRet;
                //获取普通INOUT参数VouchId。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String VouchIdRet = broker.GetResult("VouchId") as System.String;
                VouchId = VouchIdRet;
                //获取普通OUT参数domMsg。此返回值数据类型为MSXML2.IXMLDOMDocument2，在使用该参数之前，请判断是否为空
                MSXML2.IXMLDOMDocument2 domMsgRet = (MSXML2.IXMLDOMDocument2)broker.GetResult("domMsg");
                domMsgO = domMsgRet;
                //结束本次调用，释放API资源
                broker.Release();
                return result;
            }
            catch (Exception e)
            {
                domMsgO = null;
                errMsg = "提交前发生错误," + e.Message+e.StackTrace;
                return false;
            }
        }

        //产成品入库单
        [WebMethod]
        public bool ProductInAdd(System.String sVouchType,
        string DomHeadXml,
        string domBodyXml,
        System.Object domPosition,
        out System.String errMsg,
        object cnnFromO,
        ref System.String VouchId,
        out object domMsgO,
        System.Boolean bCheck,
        System.Boolean bBeforCheckStock,
        System.Boolean bIsRedVouch,
        System.String sAddedState,
        System.Boolean bReMote)
        {
            try
            {
                //MSXML2.IXMLDOMDocument2 DomHead = (MSXML2.IXMLDOMDocument2)DomHeadO;
                //MSXML2.IXMLDOMDocument2 domBody = (MSXML2.IXMLDOMDocument2)domBodyO;
                domMsgO = new MSXML2.DOMDocumentClass();
                MSXML2.IXMLDOMDocument2 domMsg = (MSXML2.IXMLDOMDocument2)domMsgO;
                ADODB.Connection cnnFrom = (ADODB.Connection)cnnFromO;
                //第一步：构造u8login对象并登陆(引用U8API类库中的Interop.U8Login.dll)
                //如果当前环境中有login对象则可以省去第一步
                U8Login.clsLogin u8Login = new U8Login.clsLogin();
                String sSubId = "DP";
                String sAccID = SysParams.Instance.U8VouchCode;
                String sUserID = SysParams.Instance.U8uid;
                String sPassword = SysParams.Instance.U8pwd;
                String sServer = SysParams.Instance.U8ServerIP;
                String sYear = "2017";
                String sDate = "2017-03-13";
                
                String sSerial = "";
                if (!u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUserID, ref sPassword, ref sDate, ref sServer, ref sSerial))
                {
                    errMsg = "登陆失败，原因：" + u8Login.ShareString;
                    WriteLog.Instance.Write(errMsg);
                    Marshal.FinalReleaseComObject(u8Login);
                    domMsgO = null;
                    return false;
                }

                //第二步：构造环境上下文对象，传入login，并按需设置其它上下文参数
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = u8Login;


                //第三步：设置API地址标识(Url)
                //当前API：添加新单据的地址标识为：U8API/ProductIn/Add
                U8ApiAddress myApiAddress = new U8ApiAddress("U8API/ProductIn/Add");

                //第四步：构造APIBroker
                U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

                //第五步：API参数赋值

                //给普通参数sVouchType赋值。此参数的数据类型为System.String，此参数按值传递，表示单据类型：10

                broker.AssignNormalValue("sVouchType", sVouchType);

                //给BO表头参数DomHead赋值，此BO参数的业务类型为产成品入库单，属表头参数。BO参数均按引用传递
                //提示：给BO表头参数DomHead赋值有两种方法

                //方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("DomHead", DomHead);

                //方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject DomHead = broker.GetBoParam("DomHead");
                setBusinessObject(ref DomHead, DomHeadXml);
                //DomHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
                ////给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //DomHead[0]["id"] = ""; //主关键字段，int类型
                //DomHead[0]["ccode"] = ""; //入库单号，string类型
                //DomHead[0]["ddate"] = ""; //入库日期，DateTime类型
                //DomHead[0]["cwhname"] = ""; //仓库，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //DomHead[0]["cmodifyperson"] = ""; //修改人，string类型
                //DomHead[0]["dmodifydate"] = ""; //修改日期，DateTime类型
                //DomHead[0]["dnmaketime"] = ""; //制单时间，DateTime类型
                //DomHead[0]["dnmodifytime"] = ""; //修改时间，DateTime类型
                //DomHead[0]["dnverifytime"] = ""; //审核时间，DateTime类型
                //DomHead[0]["dchkdate"] = ""; //检验日期，DateTime类型
                //DomHead[0]["iavaquantity"] = ""; //可用量，string类型
                //DomHead[0]["iavanum"] = ""; //可用件数，string类型
                //DomHead[0]["ipresentnum"] = ""; //现存件数，string类型
                //DomHead[0]["ufts"] = ""; //时间戳，string类型
                //DomHead[0]["cpspcode"] = ""; //产品，string类型
                //DomHead[0]["iproorderid"] = ""; //生产订单ID，string类型
                //DomHead[0]["cmpocode"] = ""; //生产订单号，string类型
                //DomHead[0]["cprobatch"] = ""; //生产批号，string类型
                //DomHead[0]["iverifystate"] = ""; //iverifystate，string类型
                //DomHead[0]["iswfcontrolled"] = ""; //iswfcontrolled，string类型
                //DomHead[0]["ireturncount"] = ""; //ireturncount，string类型
                //DomHead[0]["cdepname"] = ""; //部门，string类型
                //DomHead[0]["crdname"] = ""; //入库类别，string类型
                //DomHead[0]["dveridate"] = ""; //审核日期，DateTime类型
                //DomHead[0]["cmemo"] = ""; //备注，string类型
                //DomHead[0]["cchkperson"] = ""; //检验员，string类型
                //DomHead[0]["cmaker"] = ""; //制单人，string类型
                //DomHead[0]["chandler"] = ""; //审核人，string类型
                //DomHead[0]["itopsum"] = ""; //最高库存量，string类型
                //DomHead[0]["caccounter"] = ""; //记账人，string类型
                //DomHead[0]["ilowsum"] = ""; //最低库存量，string类型
                //DomHead[0]["ipresent"] = ""; //现存量，string类型
                //DomHead[0]["isafesum"] = ""; //安全库存量，string类型
                //DomHead[0]["cbustype"] = ""; //业务类型，int类型
                //DomHead[0]["cpersonname"] = ""; //业务员，string类型
                //DomHead[0]["cdefine1"] = ""; //表头自定义项1，string类型
                //DomHead[0]["cdefine11"] = ""; //表头自定义项11，string类型
                //DomHead[0]["cdefine12"] = ""; //表头自定义项12，string类型
                //DomHead[0]["cdefine13"] = ""; //表头自定义项13，string类型
                //DomHead[0]["cdefine14"] = ""; //表头自定义项14，string类型
                //DomHead[0]["cdefine2"] = ""; //表头自定义项2，string类型
                //DomHead[0]["cdefine3"] = ""; //表头自定义项3，string类型
                //DomHead[0]["csource"] = ""; //单据来源，int类型
                //DomHead[0]["cdefine5"] = ""; //表头自定义项5，int类型
                //DomHead[0]["cdefine15"] = ""; //表头自定义项15，int类型
                //DomHead[0]["cdefine6"] = ""; //表头自定义项6，DateTime类型
                //DomHead[0]["brdflag"] = ""; //收发标志，string类型
                //DomHead[0]["cdefine7"] = ""; //表头自定义项7，double类型
                //DomHead[0]["cdefine16"] = ""; //表头自定义项16，double类型
                //DomHead[0]["cdefine8"] = ""; //表头自定义项8，string类型
                //DomHead[0]["cdefine9"] = ""; //表头自定义项9，string类型
                //DomHead[0]["cdefine10"] = ""; //表头自定义项10，string类型
                //DomHead[0]["cvouchtype"] = ""; //单据类型，string类型
                //DomHead[0]["cwhcode"] = ""; //仓库编码，string类型
                //DomHead[0]["crdcode"] = ""; //入库类别编码，string类型
                //DomHead[0]["cdepcode"] = ""; //部门编码，string类型
                //DomHead[0]["cpersoncode"] = ""; //业务员编码，string类型
                //DomHead[0]["vt_id"] = ""; //模版号，int类型
                //DomHead[0]["cdefine4"] = ""; //表头自定义项4，DateTime类型

                ////给BO表体参数domBody赋值，此BO参数的业务类型为产成品入库单，属表体参数。BO参数均按引用传递
                ////提示：给BO表体参数domBody赋值有两种方法

                ////方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("domBody", domBody);

                ////方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject domBody = broker.GetBoParam("domBody");
                setBusinessObject(ref domBody, domBodyXml);
                //domBody.RowCount = 10; //设置BO对象行数
                ////可以自由设置BO对象行数为大于零的整数，也可以不设置而自动增加行数
                ////给BO对象的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //domBody[0]["autoid"] = ""; //主关键字段，int类型
                //domBody[0]["cinvcode"] = ""; //产品编码，string类型
                //domBody[0]["editprop"] = ""; //编辑属性：A表新增，M表修改，D表删除，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //domBody[0]["id"] = ""; //与主表关联项，int类型
                //domBody[0]["cinvaddcode"] = ""; //产品代码，string类型
                //domBody[0]["cinvname"] = ""; //产品名称，string类型
                //domBody[0]["cinvstd"] = ""; //规格型号，string类型
                //domBody[0]["cinvm_unit"] = ""; //主计量单位，string类型
                //domBody[0]["cinva_unit"] = ""; //库存单位，string类型
                //domBody[0]["creplaceitem"] = ""; //替换件，string类型
                //domBody[0]["cposition"] = ""; //货位编码，string类型
                //domBody[0]["cinvdefine1"] = ""; //存货自定义项1，string类型
                //domBody[0]["cinvdefine2"] = ""; //存货自定义项2，string类型
                //domBody[0]["cinvdefine3"] = ""; //存货自定义项3，string类型
                //domBody[0]["cfree1"] = ""; //存货自由项1，string类型
                //domBody[0]["cbatchproperty1"] = ""; //批次属性1，double类型
                //domBody[0]["cbatchproperty2"] = ""; //批次属性2，double类型
                //domBody[0]["cfree2"] = ""; //存货自由项2，string类型
                //domBody[0]["cbatch"] = ""; //批号，string类型
                //domBody[0]["iinvexchrate"] = ""; //换算率，double类型
                //domBody[0]["inum"] = ""; //件数，double类型
                //domBody[0]["iquantity"] = ""; //数量，double类型
                //domBody[0]["iunitcost"] = ""; //单价，double类型
                //domBody[0]["iprice"] = ""; //金额，double类型
                //domBody[0]["ipunitcost"] = ""; //计划单价，double类型
                //domBody[0]["ipprice"] = ""; //计划金额，double类型
                //domBody[0]["dvdate"] = ""; //失效日期，DateTime类型
                //domBody[0]["isoutquantity"] = ""; //累计出库数量，double类型
                //domBody[0]["isoutnum"] = ""; //累计出库件数，double类型
                //domBody[0]["dsdate"] = ""; //结算日期，DateTime类型
                //domBody[0]["ifquantity"] = ""; //实际数量，double类型
                //domBody[0]["ifnum"] = ""; //实际件数，double类型
                //domBody[0]["cvouchcode"] = ""; //对应入库单id，string类型
                //domBody[0]["cfree3"] = ""; //存货自由项3，string类型
                //domBody[0]["cbatchproperty3"] = ""; //批次属性3，double类型
                //domBody[0]["cbatchproperty4"] = ""; //批次属性4，double类型
                //domBody[0]["cfree4"] = ""; //存货自由项4，string类型
                //domBody[0]["cfree5"] = ""; //存货自由项5，string类型
                //domBody[0]["cbatchproperty5"] = ""; //批次属性5，double类型
                //domBody[0]["cbatchproperty6"] = ""; //批次属性6，string类型
                //domBody[0]["cfree6"] = ""; //存货自由项6，string类型
                //domBody[0]["cfree7"] = ""; //存货自由项7，string类型
                //domBody[0]["cbatchproperty7"] = ""; //批次属性7，string类型
                //domBody[0]["cbatchproperty8"] = ""; //批次属性8，string类型
                //domBody[0]["cfree8"] = ""; //存货自由项8，string类型
                //domBody[0]["cfree9"] = ""; //存货自由项9，string类型
                //domBody[0]["cbatchproperty9"] = ""; //批次属性9，string类型
                //domBody[0]["cbatchproperty10"] = ""; //批次属性10，DateTime类型
                //domBody[0]["cfree10"] = ""; //存货自由项10，string类型
                //domBody[0]["cdefine36"] = ""; //表体自定义项15，DateTime类型
                //domBody[0]["cdefine37"] = ""; //表体自定义项16，DateTime类型
                //domBody[0]["cinvdefine13"] = ""; //存货自定义项13，string类型
                //domBody[0]["cinvdefine14"] = ""; //存货自定义项14，string类型
                //domBody[0]["cinvdefine15"] = ""; //存货自定义项15，string类型
                //domBody[0]["cinvdefine16"] = ""; //存货自定义项16，string类型
                //domBody[0]["inquantity"] = ""; //应收数量，double类型
                //domBody[0]["innum"] = ""; //应收件数，double类型
                //domBody[0]["dmadedate"] = ""; //生产日期，DateTime类型
                //domBody[0]["impoids"] = ""; //生产订单子表ID，int类型
                //domBody[0]["icheckids"] = ""; //检验单子表ID，int类型
                //domBody[0]["isodid"] = ""; //销售订单子表ID，string类型
                //domBody[0]["brelated"] = ""; //是否联副产品，int类型
                //domBody[0]["cbvencode"] = ""; //供应商编码，string类型
                //domBody[0]["cinvouchcode"] = ""; //对应入库单号，string类型
                //domBody[0]["cvenname"] = ""; //供应商，string类型
                //domBody[0]["imassdate"] = ""; //保质期，int类型
                //domBody[0]["cassunit"] = ""; //库存单位码，string类型
                //domBody[0]["corufts"] = ""; //对应单据时间戳，string类型
                //domBody[0]["cposname"] = ""; //货位，string类型
                //domBody[0]["cmolotcode"] = ""; //生产批号，string类型
                //domBody[0]["cmassunit"] = ""; //保质期单位，int类型
                //domBody[0]["csocode"] = ""; //需求跟踪号，string类型
                //domBody[0]["cmocode"] = ""; //生产订单号，string类型
                //domBody[0]["cvmivencode"] = ""; //代管商代码，string类型
                //domBody[0]["cvmivenname"] = ""; //代管商，string类型
                //domBody[0]["bvmiused"] = ""; //代管消耗标识，int类型
                //domBody[0]["ivmisettlequantity"] = ""; //代管挂账确认单数量，double类型
                //domBody[0]["ivmisettlenum"] = ""; //代管挂账确认单件数，double类型
                //domBody[0]["cdemandmemo"] = ""; //需求分类代号说明，string类型
                //domBody[0]["iordertype"] = ""; //销售订单类别，int类型
                //domBody[0]["iorderdid"] = ""; //iorderdid，int类型
                //domBody[0]["iordercode"] = ""; //销售订单号，string类型
                //domBody[0]["iorderseq"] = ""; //销售订单行号，string类型
                //domBody[0]["iexpiratdatecalcu"] = ""; //有效期推算方式，int类型
                //domBody[0]["cexpirationdate"] = ""; //有效期至，string类型
                //domBody[0]["dexpirationdate"] = ""; //有效期计算项，string类型
                //domBody[0]["cciqbookcode"] = ""; //手册号，string类型
                //domBody[0]["ibondedsumqty"] = ""; //累计保税处理抽取数量，string类型
                //domBody[0]["copdesc"] = ""; //工序说明，string类型
                //domBody[0]["cmworkcentercode"] = ""; //工作中心编码，string类型
                //domBody[0]["cmworkcenter"] = ""; //工作中心，string类型
                //domBody[0]["isotype"] = ""; //需求跟踪方式，int类型
                //domBody[0]["cbaccounter"] = ""; //记账人，string类型
                //domBody[0]["bcosting"] = ""; //是否核算，string类型
                //domBody[0]["isoseq"] = ""; //需求跟踪行号，string类型
                //domBody[0]["imoseq"] = ""; //生产订单行号，string类型
                //domBody[0]["iopseq"] = ""; //工序行号，string类型
                //domBody[0]["cdefine34"] = ""; //表体自定义项13，int类型
                //domBody[0]["cdefine35"] = ""; //表体自定义项14，int类型
                //domBody[0]["cdefine22"] = ""; //表体自定义项1，string类型
                //domBody[0]["cdefine28"] = ""; //表体自定义项7，string类型
                //domBody[0]["cdefine29"] = ""; //表体自定义项8，string类型
                //domBody[0]["cdefine30"] = ""; //表体自定义项9，string类型
                //domBody[0]["cdefine31"] = ""; //表体自定义项10，string类型
                //domBody[0]["cdefine32"] = ""; //表体自定义项11，string类型
                //domBody[0]["cdefine33"] = ""; //表体自定义项12，string类型
                //domBody[0]["cinvdefine4"] = ""; //存货自定义项4，string类型
                //domBody[0]["cinvdefine5"] = ""; //存货自定义项5，string类型
                //domBody[0]["cinvdefine6"] = ""; //存货自定义项6，string类型
                //domBody[0]["cinvdefine7"] = ""; //存货自定义项7，string类型
                //domBody[0]["cinvdefine8"] = ""; //存货自定义项8，string类型
                //domBody[0]["cinvdefine9"] = ""; //存货自定义项9，string类型
                //domBody[0]["cinvdefine10"] = ""; //存货自定义项10，string类型
                //domBody[0]["cinvdefine11"] = ""; //存货自定义项11，string类型
                //domBody[0]["cinvdefine12"] = ""; //存货自定义项12，string类型
                //domBody[0]["cbarcode"] = ""; //条形码，string类型
                //domBody[0]["cdefine23"] = ""; //表体自定义项2，string类型
                //domBody[0]["cdefine24"] = ""; //表体自定义项3，string类型
                //domBody[0]["cdefine25"] = ""; //表体自定义项4，string类型
                //domBody[0]["itrids"] = ""; //特殊单据子表标识，double类型
                //domBody[0]["cdefine26"] = ""; //表体自定义项5，double类型
                //domBody[0]["cdefine27"] = ""; //表体自定义项6，double类型
                //domBody[0]["citemcode"] = ""; //项目编码，string类型
                //domBody[0]["cname"] = ""; //项目，string类型
                //domBody[0]["citem_class"] = ""; //项目大类编码，string类型
                //domBody[0]["citemcname"] = ""; //项目大类名称，string类型

                //给普通参数domPosition赋值。此参数的数据类型为System.Object，此参数按引用传递，表示货位：传空
                broker.AssignNormalValue("domPosition", domPosition);

                //该参数errMsg为OUT型参数，由于其数据类型为System.String，为一般值类型，因此不必传入一个参数变量。在API调用返回时，可以通过GetResult("errMsg")获取其值

                //给普通参数cnnFrom赋值。此参数的数据类型为ADODB.Connection，此参数按引用传递，表示连接对象,如果由调用方控制事务，则需要设置此连接对象，否则传空
                broker.AssignNormalValue("cnnFrom", cnnFrom);

                //该参数VouchId为INOUT型普通参数。此参数的数据类型为System.String，此参数按值传递。在API调用返回时，可以通过GetResult("VouchId")获取其值
                broker.AssignNormalValue("VouchId", VouchId);

                //该参数domMsg为OUT型参数，由于其数据类型为MSXML2.IXMLDOMDocument2，非一般值类型，因此必须传入一个参数变量。在API调用返回时，可以直接使用该参数

                broker.AssignNormalValue("domMsg", domMsg);
                domMsgO = domMsg;

                //给普通参数bCheck赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否控制可用量。
                broker.AssignNormalValue("bCheck", bCheck);

                //给普通参数bBeforCheckStock赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示检查可用量
                broker.AssignNormalValue("bBeforCheckStock", bBeforCheckStock);

                //给普通参数bIsRedVouch赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否红字单据
                broker.AssignNormalValue("bIsRedVouch", bIsRedVouch);

                //给普通参数sAddedState赋值。此参数的数据类型为System.String，此参数按值传递，表示传空字符串
                broker.AssignNormalValue("sAddedState", sAddedState);

                //给普通参数bReMote赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否远程：转入false
                broker.AssignNormalValue("bReMote", bReMote);

                //第六步：调用API
                if (!broker.Invoke())
                {
                    //错误处理
                    Exception apiEx = broker.GetException();
                    if (apiEx != null)
                    {
                        if (apiEx is MomSysException)
                        {
                            MomSysException sysEx = apiEx as MomSysException;
                            WriteLog.Instance.Write("系统异常：" + sysEx.Message);
                            //todo:异常处理
                        }
                        else if (apiEx is MomBizException)
                        {
                            MomBizException bizEx = apiEx as MomBizException;
                            WriteLog.Instance.Write("API异常：" + bizEx.Message);
                            //todo:异常处理
                        }
                        //异常原因
                        String exReason = broker.GetExceptionString();
                        if (exReason.Length != 0)
                        {
                            WriteLog.Instance.Write("异常原因：" + exReason);
                        }
                    }
                    //结束本次调用，释放API资源
                    broker.Release();
                    domMsgO = null;
                    errMsg = apiEx.Message;
                    return false;

                }

                //第七步：获取返回结果

                //获取返回值
                //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值:true:成功,false:失败
                System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

                //获取out/inout参数值

                //获取普通OUT参数errMsg。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String errMsgRet = broker.GetResult("errMsg") as System.String;
                errMsg = errMsgRet;
                //获取普通INOUT参数VouchId。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String VouchIdRet = broker.GetResult("VouchId") as System.String;
                VouchId = VouchIdRet;
                //获取普通OUT参数domMsg。此返回值数据类型为MSXML2.IXMLDOMDocument2，在使用该参数之前，请判断是否为空
                MSXML2.IXMLDOMDocument2 domMsgRet = (MSXML2.IXMLDOMDocument2)broker.GetResult("domMsg");
                domMsgO = domMsgRet;
                //结束本次调用，释放API资源
                broker.Release();
                return result;
            }
            catch (Exception e)
            {
                domMsgO = null;
                errMsg = "提交前发生错误," + e.Message;
                return false;
            }
        }

        //采购入库单
        [WebMethod]
        public bool PuStoreInAdd(System.String sVouchType,
        string DomHeadXml,
        string domBodyXml,
        System.Object domPosition,
        out System.String errMsg,
        object cnnFromO,
        ref System.String VouchId,
        out object domMsgO,
        System.Boolean bCheck,
        System.Boolean bBeforCheckStock,
        System.Boolean bIsRedVouch,
        System.String sAddedState,
        System.Boolean bReMote)
        {
            try
            {
                //MSXML2.IXMLDOMDocument2 DomHead = (MSXML2.IXMLDOMDocument2)DomHeadO;
                //MSXML2.IXMLDOMDocument2 domBody = (MSXML2.IXMLDOMDocument2)domBodyO;
                domMsgO = new MSXML2.DOMDocumentClass();
                MSXML2.IXMLDOMDocument2 domMsg = (MSXML2.IXMLDOMDocument2)domMsgO;
                ADODB.Connection cnnFrom = (ADODB.Connection)cnnFromO;
                //第一步：构造u8login对象并登陆(引用U8API类库中的Interop.U8Login.dll)
                //如果当前环境中有login对象则可以省去第一步
                U8Login.clsLogin u8Login = new U8Login.clsLogin();
                String sSubId = "DP";
                String sAccID = SysParams.Instance.U8VouchCode;
                String sUserID = SysParams.Instance.U8uid;
                String sPassword = SysParams.Instance.U8pwd;
                String sServer = SysParams.Instance.U8ServerIP;             
                String sYear = "2017";           
                String sDate = "2017-03-13";
                String sSerial = "";
                if (!u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUserID, ref sPassword, ref sDate, ref sServer, ref sSerial))
                {
                    errMsg = "登陆失败，原因：" + u8Login.ShareString;
                    WriteLog.Instance.Write(errMsg);
                    Marshal.FinalReleaseComObject(u8Login);
                    domMsgO = null;
                    return false;
                }

                //第二步：构造环境上下文对象，传入login，并按需设置其它上下文参数
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = u8Login;


                //第三步：设置API地址标识(Url)
                //当前API：添加新单据的地址标识为：U8API/PuStoreIn/Add
                U8ApiAddress myApiAddress = new U8ApiAddress("U8API/PuStoreIn/Add");

                //第四步：构造APIBroker
                U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

                //第五步：API参数赋值

                //给普通参数sVouchType赋值。此参数的数据类型为System.String，此参数按值传递，表示单据类型：10

                broker.AssignNormalValue("sVouchType", sVouchType);

                //给BO表头参数DomHead赋值，此BO参数的业务类型为产成品入库单，属表头参数。BO参数均按引用传递
                //提示：给BO表头参数DomHead赋值有两种方法

                //方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("DomHead", DomHead);

                //方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject DomHead = broker.GetBoParam("DomHead");
                setBusinessObject(ref DomHead, DomHeadXml);
                //DomHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
                ////给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //DomHead[0]["id"] = ""; //主关键字段，int类型
                //DomHead[0]["ccode"] = ""; //入库单号，string类型
                //DomHead[0]["ddate"] = ""; //入库日期，DateTime类型
                //DomHead[0]["cwhname"] = ""; //仓库，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //DomHead[0]["cmodifyperson"] = ""; //修改人，string类型
                //DomHead[0]["dmodifydate"] = ""; //修改日期，DateTime类型
                //DomHead[0]["dnmaketime"] = ""; //制单时间，DateTime类型
                //DomHead[0]["dnmodifytime"] = ""; //修改时间，DateTime类型
                //DomHead[0]["dnverifytime"] = ""; //审核时间，DateTime类型
                //DomHead[0]["dchkdate"] = ""; //检验日期，DateTime类型
                //DomHead[0]["iavaquantity"] = ""; //可用量，string类型
                //DomHead[0]["iavanum"] = ""; //可用件数，string类型
                //DomHead[0]["ipresentnum"] = ""; //现存件数，string类型
                //DomHead[0]["ufts"] = ""; //时间戳，string类型
                //DomHead[0]["cpspcode"] = ""; //产品，string类型
                //DomHead[0]["iproorderid"] = ""; //生产订单ID，string类型
                //DomHead[0]["cmpocode"] = ""; //生产订单号，string类型
                //DomHead[0]["cprobatch"] = ""; //生产批号，string类型
                //DomHead[0]["iverifystate"] = ""; //iverifystate，string类型
                //DomHead[0]["iswfcontrolled"] = ""; //iswfcontrolled，string类型
                //DomHead[0]["ireturncount"] = ""; //ireturncount，string类型
                //DomHead[0]["cdepname"] = ""; //部门，string类型
                //DomHead[0]["crdname"] = ""; //入库类别，string类型
                //DomHead[0]["dveridate"] = ""; //审核日期，DateTime类型
                //DomHead[0]["cmemo"] = ""; //备注，string类型
                //DomHead[0]["cchkperson"] = ""; //检验员，string类型
                //DomHead[0]["cmaker"] = ""; //制单人，string类型
                //DomHead[0]["chandler"] = ""; //审核人，string类型
                //DomHead[0]["itopsum"] = ""; //最高库存量，string类型
                //DomHead[0]["caccounter"] = ""; //记账人，string类型
                //DomHead[0]["ilowsum"] = ""; //最低库存量，string类型
                //DomHead[0]["ipresent"] = ""; //现存量，string类型
                //DomHead[0]["isafesum"] = ""; //安全库存量，string类型
                //DomHead[0]["cbustype"] = ""; //业务类型，int类型
                //DomHead[0]["cpersonname"] = ""; //业务员，string类型
                //DomHead[0]["cdefine1"] = ""; //表头自定义项1，string类型
                //DomHead[0]["cdefine11"] = ""; //表头自定义项11，string类型
                //DomHead[0]["cdefine12"] = ""; //表头自定义项12，string类型
                //DomHead[0]["cdefine13"] = ""; //表头自定义项13，string类型
                //DomHead[0]["cdefine14"] = ""; //表头自定义项14，string类型
                //DomHead[0]["cdefine2"] = ""; //表头自定义项2，string类型
                //DomHead[0]["cdefine3"] = ""; //表头自定义项3，string类型
                //DomHead[0]["csource"] = ""; //单据来源，int类型
                //DomHead[0]["cdefine5"] = ""; //表头自定义项5，int类型
                //DomHead[0]["cdefine15"] = ""; //表头自定义项15，int类型
                //DomHead[0]["cdefine6"] = ""; //表头自定义项6，DateTime类型
                //DomHead[0]["brdflag"] = ""; //收发标志，string类型
                //DomHead[0]["cdefine7"] = ""; //表头自定义项7，double类型
                //DomHead[0]["cdefine16"] = ""; //表头自定义项16，double类型
                //DomHead[0]["cdefine8"] = ""; //表头自定义项8，string类型
                //DomHead[0]["cdefine9"] = ""; //表头自定义项9，string类型
                //DomHead[0]["cdefine10"] = ""; //表头自定义项10，string类型
                //DomHead[0]["cvouchtype"] = ""; //单据类型，string类型
                //DomHead[0]["cwhcode"] = ""; //仓库编码，string类型
                //DomHead[0]["crdcode"] = ""; //入库类别编码，string类型
                //DomHead[0]["cdepcode"] = ""; //部门编码，string类型
                //DomHead[0]["cpersoncode"] = ""; //业务员编码，string类型
                //DomHead[0]["vt_id"] = ""; //模版号，int类型
                //DomHead[0]["cdefine4"] = ""; //表头自定义项4，DateTime类型

                ////给BO表体参数domBody赋值，此BO参数的业务类型为产成品入库单，属表体参数。BO参数均按引用传递
                ////提示：给BO表体参数domBody赋值有两种方法

                ////方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("domBody", domBody);

                ////方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject domBody = broker.GetBoParam("domBody");
                setBusinessObject(ref domBody, domBodyXml);
                //domBody.RowCount = 10; //设置BO对象行数
                ////可以自由设置BO对象行数为大于零的整数，也可以不设置而自动增加行数
                ////给BO对象的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //domBody[0]["autoid"] = ""; //主关键字段，int类型
                //domBody[0]["cinvcode"] = ""; //产品编码，string类型
                //domBody[0]["editprop"] = ""; //编辑属性：A表新增，M表修改，D表删除，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //domBody[0]["id"] = ""; //与主表关联项，int类型
                //domBody[0]["cinvaddcode"] = ""; //产品代码，string类型
                //domBody[0]["cinvname"] = ""; //产品名称，string类型
                //domBody[0]["cinvstd"] = ""; //规格型号，string类型
                //domBody[0]["cinvm_unit"] = ""; //主计量单位，string类型
                //domBody[0]["cinva_unit"] = ""; //库存单位，string类型
                //domBody[0]["creplaceitem"] = ""; //替换件，string类型
                //domBody[0]["cposition"] = ""; //货位编码，string类型
                //domBody[0]["cinvdefine1"] = ""; //存货自定义项1，string类型
                //domBody[0]["cinvdefine2"] = ""; //存货自定义项2，string类型
                //domBody[0]["cinvdefine3"] = ""; //存货自定义项3，string类型
                //domBody[0]["cfree1"] = ""; //存货自由项1，string类型
                //domBody[0]["cbatchproperty1"] = ""; //批次属性1，double类型
                //domBody[0]["cbatchproperty2"] = ""; //批次属性2，double类型
                //domBody[0]["cfree2"] = ""; //存货自由项2，string类型
                //domBody[0]["cbatch"] = ""; //批号，string类型
                //domBody[0]["iinvexchrate"] = ""; //换算率，double类型
                //domBody[0]["inum"] = ""; //件数，double类型
                //domBody[0]["iquantity"] = ""; //数量，double类型
                //domBody[0]["iunitcost"] = ""; //单价，double类型
                //domBody[0]["iprice"] = ""; //金额，double类型
                //domBody[0]["ipunitcost"] = ""; //计划单价，double类型
                //domBody[0]["ipprice"] = ""; //计划金额，double类型
                //domBody[0]["dvdate"] = ""; //失效日期，DateTime类型
                //domBody[0]["isoutquantity"] = ""; //累计出库数量，double类型
                //domBody[0]["isoutnum"] = ""; //累计出库件数，double类型
                //domBody[0]["dsdate"] = ""; //结算日期，DateTime类型
                //domBody[0]["ifquantity"] = ""; //实际数量，double类型
                //domBody[0]["ifnum"] = ""; //实际件数，double类型
                //domBody[0]["cvouchcode"] = ""; //对应入库单id，string类型
                //domBody[0]["cfree3"] = ""; //存货自由项3，string类型
                //domBody[0]["cbatchproperty3"] = ""; //批次属性3，double类型
                //domBody[0]["cbatchproperty4"] = ""; //批次属性4，double类型
                //domBody[0]["cfree4"] = ""; //存货自由项4，string类型
                //domBody[0]["cfree5"] = ""; //存货自由项5，string类型
                //domBody[0]["cbatchproperty5"] = ""; //批次属性5，double类型
                //domBody[0]["cbatchproperty6"] = ""; //批次属性6，string类型
                //domBody[0]["cfree6"] = ""; //存货自由项6，string类型
                //domBody[0]["cfree7"] = ""; //存货自由项7，string类型
                //domBody[0]["cbatchproperty7"] = ""; //批次属性7，string类型
                //domBody[0]["cbatchproperty8"] = ""; //批次属性8，string类型
                //domBody[0]["cfree8"] = ""; //存货自由项8，string类型
                //domBody[0]["cfree9"] = ""; //存货自由项9，string类型
                //domBody[0]["cbatchproperty9"] = ""; //批次属性9，string类型
                //domBody[0]["cbatchproperty10"] = ""; //批次属性10，DateTime类型
                //domBody[0]["cfree10"] = ""; //存货自由项10，string类型
                //domBody[0]["cdefine36"] = ""; //表体自定义项15，DateTime类型
                //domBody[0]["cdefine37"] = ""; //表体自定义项16，DateTime类型
                //domBody[0]["cinvdefine13"] = ""; //存货自定义项13，string类型
                //domBody[0]["cinvdefine14"] = ""; //存货自定义项14，string类型
                //domBody[0]["cinvdefine15"] = ""; //存货自定义项15，string类型
                //domBody[0]["cinvdefine16"] = ""; //存货自定义项16，string类型
                //domBody[0]["inquantity"] = ""; //应收数量，double类型
                //domBody[0]["innum"] = ""; //应收件数，double类型
                //domBody[0]["dmadedate"] = ""; //生产日期，DateTime类型
                //domBody[0]["impoids"] = ""; //生产订单子表ID，int类型
                //domBody[0]["icheckids"] = ""; //检验单子表ID，int类型
                //domBody[0]["isodid"] = ""; //销售订单子表ID，string类型
                //domBody[0]["brelated"] = ""; //是否联副产品，int类型
                //domBody[0]["cbvencode"] = ""; //供应商编码，string类型
                //domBody[0]["cinvouchcode"] = ""; //对应入库单号，string类型
                //domBody[0]["cvenname"] = ""; //供应商，string类型
                //domBody[0]["imassdate"] = ""; //保质期，int类型
                //domBody[0]["cassunit"] = ""; //库存单位码，string类型
                //domBody[0]["corufts"] = ""; //对应单据时间戳，string类型
                //domBody[0]["cposname"] = ""; //货位，string类型
                //domBody[0]["cmolotcode"] = ""; //生产批号，string类型
                //domBody[0]["cmassunit"] = ""; //保质期单位，int类型
                //domBody[0]["csocode"] = ""; //需求跟踪号，string类型
                //domBody[0]["cmocode"] = ""; //生产订单号，string类型
                //domBody[0]["cvmivencode"] = ""; //代管商代码，string类型
                //domBody[0]["cvmivenname"] = ""; //代管商，string类型
                //domBody[0]["bvmiused"] = ""; //代管消耗标识，int类型
                //domBody[0]["ivmisettlequantity"] = ""; //代管挂账确认单数量，double类型
                //domBody[0]["ivmisettlenum"] = ""; //代管挂账确认单件数，double类型
                //domBody[0]["cdemandmemo"] = ""; //需求分类代号说明，string类型
                //domBody[0]["iordertype"] = ""; //销售订单类别，int类型
                //domBody[0]["iorderdid"] = ""; //iorderdid，int类型
                //domBody[0]["iordercode"] = ""; //销售订单号，string类型
                //domBody[0]["iorderseq"] = ""; //销售订单行号，string类型
                //domBody[0]["iexpiratdatecalcu"] = ""; //有效期推算方式，int类型
                //domBody[0]["cexpirationdate"] = ""; //有效期至，string类型
                //domBody[0]["dexpirationdate"] = ""; //有效期计算项，string类型
                //domBody[0]["cciqbookcode"] = ""; //手册号，string类型
                //domBody[0]["ibondedsumqty"] = ""; //累计保税处理抽取数量，string类型
                //domBody[0]["copdesc"] = ""; //工序说明，string类型
                //domBody[0]["cmworkcentercode"] = ""; //工作中心编码，string类型
                //domBody[0]["cmworkcenter"] = ""; //工作中心，string类型
                //domBody[0]["isotype"] = ""; //需求跟踪方式，int类型
                //domBody[0]["cbaccounter"] = ""; //记账人，string类型
                //domBody[0]["bcosting"] = ""; //是否核算，string类型
                //domBody[0]["isoseq"] = ""; //需求跟踪行号，string类型
                //domBody[0]["imoseq"] = ""; //生产订单行号，string类型
                //domBody[0]["iopseq"] = ""; //工序行号，string类型
                //domBody[0]["cdefine34"] = ""; //表体自定义项13，int类型
                //domBody[0]["cdefine35"] = ""; //表体自定义项14，int类型
                //domBody[0]["cdefine22"] = ""; //表体自定义项1，string类型
                //domBody[0]["cdefine28"] = ""; //表体自定义项7，string类型
                //domBody[0]["cdefine29"] = ""; //表体自定义项8，string类型
                //domBody[0]["cdefine30"] = ""; //表体自定义项9，string类型
                //domBody[0]["cdefine31"] = ""; //表体自定义项10，string类型
                //domBody[0]["cdefine32"] = ""; //表体自定义项11，string类型
                //domBody[0]["cdefine33"] = ""; //表体自定义项12，string类型
                //domBody[0]["cinvdefine4"] = ""; //存货自定义项4，string类型
                //domBody[0]["cinvdefine5"] = ""; //存货自定义项5，string类型
                //domBody[0]["cinvdefine6"] = ""; //存货自定义项6，string类型
                //domBody[0]["cinvdefine7"] = ""; //存货自定义项7，string类型
                //domBody[0]["cinvdefine8"] = ""; //存货自定义项8，string类型
                //domBody[0]["cinvdefine9"] = ""; //存货自定义项9，string类型
                //domBody[0]["cinvdefine10"] = ""; //存货自定义项10，string类型
                //domBody[0]["cinvdefine11"] = ""; //存货自定义项11，string类型
                //domBody[0]["cinvdefine12"] = ""; //存货自定义项12，string类型
                //domBody[0]["cbarcode"] = ""; //条形码，string类型
                //domBody[0]["cdefine23"] = ""; //表体自定义项2，string类型
                //domBody[0]["cdefine24"] = ""; //表体自定义项3，string类型
                //domBody[0]["cdefine25"] = ""; //表体自定义项4，string类型
                //domBody[0]["itrids"] = ""; //特殊单据子表标识，double类型
                //domBody[0]["cdefine26"] = ""; //表体自定义项5，double类型
                //domBody[0]["cdefine27"] = ""; //表体自定义项6，double类型
                //domBody[0]["citemcode"] = ""; //项目编码，string类型
                //domBody[0]["cname"] = ""; //项目，string类型
                //domBody[0]["citem_class"] = ""; //项目大类编码，string类型
                //domBody[0]["citemcname"] = ""; //项目大类名称，string类型

                //给普通参数domPosition赋值。此参数的数据类型为System.Object，此参数按引用传递，表示货位：传空
                broker.AssignNormalValue("domPosition", domPosition);

                //该参数errMsg为OUT型参数，由于其数据类型为System.String，为一般值类型，因此不必传入一个参数变量。在API调用返回时，可以通过GetResult("errMsg")获取其值

                //给普通参数cnnFrom赋值。此参数的数据类型为ADODB.Connection，此参数按引用传递，表示连接对象,如果由调用方控制事务，则需要设置此连接对象，否则传空
                broker.AssignNormalValue("cnnFrom", cnnFrom);

                //该参数VouchId为INOUT型普通参数。此参数的数据类型为System.String，此参数按值传递。在API调用返回时，可以通过GetResult("VouchId")获取其值
                broker.AssignNormalValue("VouchId", VouchId);

                //该参数domMsg为OUT型参数，由于其数据类型为MSXML2.IXMLDOMDocument2，非一般值类型，因此必须传入一个参数变量。在API调用返回时，可以直接使用该参数

                broker.AssignNormalValue("domMsg", domMsg);
                domMsgO = domMsg;

                //给普通参数bCheck赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否控制可用量。
                broker.AssignNormalValue("bCheck", bCheck);

                //给普通参数bBeforCheckStock赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示检查可用量
                broker.AssignNormalValue("bBeforCheckStock", bBeforCheckStock);

                //给普通参数bIsRedVouch赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否红字单据
                broker.AssignNormalValue("bIsRedVouch", bIsRedVouch);

                //给普通参数sAddedState赋值。此参数的数据类型为System.String，此参数按值传递，表示传空字符串
                broker.AssignNormalValue("sAddedState", sAddedState);

                //给普通参数bReMote赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否远程：转入false
                broker.AssignNormalValue("bReMote", bReMote);

                //第六步：调用API
                if (!broker.Invoke())
                {
                    //错误处理
                    Exception apiEx = broker.GetException();
                    if (apiEx != null)
                    {
                        if (apiEx is MomSysException)
                        {
                            MomSysException sysEx = apiEx as MomSysException;
                            WriteLog.Instance.Write("系统异常：" + sysEx.Message);
                            //todo:异常处理
                        }
                        else if (apiEx is MomBizException)
                        {
                            MomBizException bizEx = apiEx as MomBizException;
                            WriteLog.Instance.Write("API异常：" + bizEx.Message);
                            //todo:异常处理
                        }
                        //异常原因
                        String exReason = broker.GetExceptionString();
                        if (exReason.Length != 0)
                        {
                            WriteLog.Instance.Write("异常原因：" + exReason);
                        }
                    }
                    //结束本次调用，释放API资源
                    broker.Release();
                    domMsgO = null;
                    errMsg = apiEx.Message;
                    return false;

                }

                //第七步：获取返回结果

                //获取返回值
                //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值:true:成功,false:失败
                System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

                //获取out/inout参数值

                //获取普通OUT参数errMsg。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String errMsgRet = broker.GetResult("errMsg") as System.String;
                errMsg = errMsgRet;
                //获取普通INOUT参数VouchId。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String VouchIdRet = broker.GetResult("VouchId") as System.String;
                VouchId = VouchIdRet;
                //获取普通OUT参数domMsg。此返回值数据类型为MSXML2.IXMLDOMDocument2，在使用该参数之前，请判断是否为空
                MSXML2.IXMLDOMDocument2 domMsgRet = (MSXML2.IXMLDOMDocument2)broker.GetResult("domMsg");
                domMsgO = domMsgRet;
                //结束本次调用，释放API资源
                broker.Release();
                return result;
            }
            catch (Exception e)
            {
                domMsgO = null;
                errMsg = "提交前发生错误," + e.Message;
                return false;
            }
        }

        //调拨单
        [WebMethod]
        public bool TransVouchAdd(System.String sVouchType,
        string DomHeadXml,
        string domBodyXml,
        System.Object domPosition,
        out System.String errMsg,
        object cnnFromO,
        ref System.String VouchId,
        out object domMsgO,
        System.Boolean bCheck,
        System.Boolean bBeforCheckStock,
        System.Boolean bIsRedVouch,
        System.String sAddedState,
        System.Boolean bReMote)
        {
            try
            {
                //MSXML2.IXMLDOMDocument2 DomHead = (MSXML2.IXMLDOMDocument2)DomHeadO;
                //MSXML2.IXMLDOMDocument2 domBody = (MSXML2.IXMLDOMDocument2)domBodyO;
                domMsgO = new MSXML2.DOMDocumentClass();
                MSXML2.IXMLDOMDocument2 domMsg = (MSXML2.IXMLDOMDocument2)domMsgO;
                ADODB.Connection cnnFrom = (ADODB.Connection)cnnFromO;
                //第一步：构造u8login对象并登陆(引用U8API类库中的Interop.U8Login.dll)
                //如果当前环境中有login对象则可以省去第一步
                U8Login.clsLogin u8Login = new U8Login.clsLogin();
                String sSubId = "DP";
                String sAccID = SysParams.Instance.U8VouchCode;
                String sUserID = SysParams.Instance.U8uid;
                String sPassword = SysParams.Instance.U8pwd;
                String sServer = SysParams.Instance.U8ServerIP;                
                String sYear = "2017";
                String sDate = "2017-03-13";
                String sSerial = "";
                if (!u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUserID, ref sPassword, ref sDate, ref sServer, ref sSerial))
                {
                    errMsg = "登陆失败，原因：" + u8Login.ShareString;
                    WriteLog.Instance.Write(errMsg);
                    Marshal.FinalReleaseComObject(u8Login);
                    domMsgO = null;
                    return false;
                }

                //第二步：构造环境上下文对象，传入login，并按需设置其它上下文参数
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = u8Login;


                //第三步：设置API地址标识(Url)
                //当前API：添加新单据的地址标识为：U8API/TransVouch/Add
                U8ApiAddress myApiAddress = new U8ApiAddress("U8API/TransVouch/Add");

                //第四步：构造APIBroker
                U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

                //第五步：API参数赋值

                //给普通参数sVouchType赋值。此参数的数据类型为System.String，此参数按值传递，表示单据类型：10

                broker.AssignNormalValue("sVouchType", sVouchType);

                //给BO表头参数DomHead赋值，此BO参数的业务类型为产成品入库单，属表头参数。BO参数均按引用传递
                //提示：给BO表头参数DomHead赋值有两种方法

                //方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("DomHead", DomHead);

                //方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject DomHead = broker.GetBoParam("DomHead");
                setBusinessObject(ref DomHead, DomHeadXml);
                //DomHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
                ////给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //DomHead[0]["id"] = ""; //主关键字段，int类型
                //DomHead[0]["ccode"] = ""; //入库单号，string类型
                //DomHead[0]["ddate"] = ""; //入库日期，DateTime类型
                //DomHead[0]["cwhname"] = ""; //仓库，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //DomHead[0]["cmodifyperson"] = ""; //修改人，string类型
                //DomHead[0]["dmodifydate"] = ""; //修改日期，DateTime类型
                //DomHead[0]["dnmaketime"] = ""; //制单时间，DateTime类型
                //DomHead[0]["dnmodifytime"] = ""; //修改时间，DateTime类型
                //DomHead[0]["dnverifytime"] = ""; //审核时间，DateTime类型
                //DomHead[0]["dchkdate"] = ""; //检验日期，DateTime类型
                //DomHead[0]["iavaquantity"] = ""; //可用量，string类型
                //DomHead[0]["iavanum"] = ""; //可用件数，string类型
                //DomHead[0]["ipresentnum"] = ""; //现存件数，string类型
                //DomHead[0]["ufts"] = ""; //时间戳，string类型
                //DomHead[0]["cpspcode"] = ""; //产品，string类型
                //DomHead[0]["iproorderid"] = ""; //生产订单ID，string类型
                //DomHead[0]["cmpocode"] = ""; //生产订单号，string类型
                //DomHead[0]["cprobatch"] = ""; //生产批号，string类型
                //DomHead[0]["iverifystate"] = ""; //iverifystate，string类型
                //DomHead[0]["iswfcontrolled"] = ""; //iswfcontrolled，string类型
                //DomHead[0]["ireturncount"] = ""; //ireturncount，string类型
                //DomHead[0]["cdepname"] = ""; //部门，string类型
                //DomHead[0]["crdname"] = ""; //入库类别，string类型
                //DomHead[0]["dveridate"] = ""; //审核日期，DateTime类型
                //DomHead[0]["cmemo"] = ""; //备注，string类型
                //DomHead[0]["cchkperson"] = ""; //检验员，string类型
                //DomHead[0]["cmaker"] = ""; //制单人，string类型
                //DomHead[0]["chandler"] = ""; //审核人，string类型
                //DomHead[0]["itopsum"] = ""; //最高库存量，string类型
                //DomHead[0]["caccounter"] = ""; //记账人，string类型
                //DomHead[0]["ilowsum"] = ""; //最低库存量，string类型
                //DomHead[0]["ipresent"] = ""; //现存量，string类型
                //DomHead[0]["isafesum"] = ""; //安全库存量，string类型
                //DomHead[0]["cbustype"] = ""; //业务类型，int类型
                //DomHead[0]["cpersonname"] = ""; //业务员，string类型
                //DomHead[0]["cdefine1"] = ""; //表头自定义项1，string类型
                //DomHead[0]["cdefine11"] = ""; //表头自定义项11，string类型
                //DomHead[0]["cdefine12"] = ""; //表头自定义项12，string类型
                //DomHead[0]["cdefine13"] = ""; //表头自定义项13，string类型
                //DomHead[0]["cdefine14"] = ""; //表头自定义项14，string类型
                //DomHead[0]["cdefine2"] = ""; //表头自定义项2，string类型
                //DomHead[0]["cdefine3"] = ""; //表头自定义项3，string类型
                //DomHead[0]["csource"] = ""; //单据来源，int类型
                //DomHead[0]["cdefine5"] = ""; //表头自定义项5，int类型
                //DomHead[0]["cdefine15"] = ""; //表头自定义项15，int类型
                //DomHead[0]["cdefine6"] = ""; //表头自定义项6，DateTime类型
                //DomHead[0]["brdflag"] = ""; //收发标志，string类型
                //DomHead[0]["cdefine7"] = ""; //表头自定义项7，double类型
                //DomHead[0]["cdefine16"] = ""; //表头自定义项16，double类型
                //DomHead[0]["cdefine8"] = ""; //表头自定义项8，string类型
                //DomHead[0]["cdefine9"] = ""; //表头自定义项9，string类型
                //DomHead[0]["cdefine10"] = ""; //表头自定义项10，string类型
                //DomHead[0]["cvouchtype"] = ""; //单据类型，string类型
                //DomHead[0]["cwhcode"] = ""; //仓库编码，string类型
                //DomHead[0]["crdcode"] = ""; //入库类别编码，string类型
                //DomHead[0]["cdepcode"] = ""; //部门编码，string类型
                //DomHead[0]["cpersoncode"] = ""; //业务员编码，string类型
                //DomHead[0]["vt_id"] = ""; //模版号，int类型
                //DomHead[0]["cdefine4"] = ""; //表头自定义项4，DateTime类型

                ////给BO表体参数domBody赋值，此BO参数的业务类型为产成品入库单，属表体参数。BO参数均按引用传递
                ////提示：给BO表体参数domBody赋值有两种方法

                ////方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("domBody", domBody);

                ////方法二是构造BusinessObject对象，具体方法如下：
                ////方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject domBody = broker.GetBoParam("domBody");
                setBusinessObject(ref domBody, domBodyXml);
                //domBody.RowCount = 10; //设置BO对象行数
                ////可以自由设置BO对象行数为大于零的整数，也可以不设置而自动增加行数
                ////给BO对象的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //domBody[0]["autoid"] = ""; //主关键字段，int类型
                //domBody[0]["cinvcode"] = ""; //产品编码，string类型
                //domBody[0]["editprop"] = ""; //编辑属性：A表新增，M表修改，D表删除，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //domBody[0]["id"] = ""; //与主表关联项，int类型
                //domBody[0]["cinvaddcode"] = ""; //产品代码，string类型
                //domBody[0]["cinvname"] = ""; //产品名称，string类型
                //domBody[0]["cinvstd"] = ""; //规格型号，string类型
                //domBody[0]["cinvm_unit"] = ""; //主计量单位，string类型
                //domBody[0]["cinva_unit"] = ""; //库存单位，string类型
                //domBody[0]["creplaceitem"] = ""; //替换件，string类型
                //domBody[0]["cposition"] = ""; //货位编码，string类型
                //domBody[0]["cinvdefine1"] = ""; //存货自定义项1，string类型
                //domBody[0]["cinvdefine2"] = ""; //存货自定义项2，string类型
                //domBody[0]["cinvdefine3"] = ""; //存货自定义项3，string类型
                //domBody[0]["cfree1"] = ""; //存货自由项1，string类型
                //domBody[0]["cbatchproperty1"] = ""; //批次属性1，double类型
                //domBody[0]["cbatchproperty2"] = ""; //批次属性2，double类型
                //domBody[0]["cfree2"] = ""; //存货自由项2，string类型
                //domBody[0]["cbatch"] = ""; //批号，string类型
                //domBody[0]["iinvexchrate"] = ""; //换算率，double类型
                //domBody[0]["inum"] = ""; //件数，double类型
                //domBody[0]["iquantity"] = ""; //数量，double类型
                //domBody[0]["iunitcost"] = ""; //单价，double类型
                //domBody[0]["iprice"] = ""; //金额，double类型
                //domBody[0]["ipunitcost"] = ""; //计划单价，double类型
                //domBody[0]["ipprice"] = ""; //计划金额，double类型
                //domBody[0]["dvdate"] = ""; //失效日期，DateTime类型
                //domBody[0]["isoutquantity"] = ""; //累计出库数量，double类型
                //domBody[0]["isoutnum"] = ""; //累计出库件数，double类型
                //domBody[0]["dsdate"] = ""; //结算日期，DateTime类型
                //domBody[0]["ifquantity"] = ""; //实际数量，double类型
                //domBody[0]["ifnum"] = ""; //实际件数，double类型
                //domBody[0]["cvouchcode"] = ""; //对应入库单id，string类型
                //domBody[0]["cfree3"] = ""; //存货自由项3，string类型
                //domBody[0]["cbatchproperty3"] = ""; //批次属性3，double类型
                //domBody[0]["cbatchproperty4"] = ""; //批次属性4，double类型
                //domBody[0]["cfree4"] = ""; //存货自由项4，string类型
                //domBody[0]["cfree5"] = ""; //存货自由项5，string类型
                //domBody[0]["cbatchproperty5"] = ""; //批次属性5，double类型
                //domBody[0]["cbatchproperty6"] = ""; //批次属性6，string类型
                //domBody[0]["cfree6"] = ""; //存货自由项6，string类型
                //domBody[0]["cfree7"] = ""; //存货自由项7，string类型
                //domBody[0]["cbatchproperty7"] = ""; //批次属性7，string类型
                //domBody[0]["cbatchproperty8"] = ""; //批次属性8，string类型
                //domBody[0]["cfree8"] = ""; //存货自由项8，string类型
                //domBody[0]["cfree9"] = ""; //存货自由项9，string类型
                //domBody[0]["cbatchproperty9"] = ""; //批次属性9，string类型
                //domBody[0]["cbatchproperty10"] = ""; //批次属性10，DateTime类型
                //domBody[0]["cfree10"] = ""; //存货自由项10，string类型
                //domBody[0]["cdefine36"] = ""; //表体自定义项15，DateTime类型
                //domBody[0]["cdefine37"] = ""; //表体自定义项16，DateTime类型
                //domBody[0]["cinvdefine13"] = ""; //存货自定义项13，string类型
                //domBody[0]["cinvdefine14"] = ""; //存货自定义项14，string类型
                //domBody[0]["cinvdefine15"] = ""; //存货自定义项15，string类型
                //domBody[0]["cinvdefine16"] = ""; //存货自定义项16，string类型
                //domBody[0]["inquantity"] = ""; //应收数量，double类型
                //domBody[0]["innum"] = ""; //应收件数，double类型
                //domBody[0]["dmadedate"] = ""; //生产日期，DateTime类型
                //domBody[0]["impoids"] = ""; //生产订单子表ID，int类型
                //domBody[0]["icheckids"] = ""; //检验单子表ID，int类型
                //domBody[0]["isodid"] = ""; //销售订单子表ID，string类型
                //domBody[0]["brelated"] = ""; //是否联副产品，int类型
                //domBody[0]["cbvencode"] = ""; //供应商编码，string类型
                //domBody[0]["cinvouchcode"] = ""; //对应入库单号，string类型
                //domBody[0]["cvenname"] = ""; //供应商，string类型
                //domBody[0]["imassdate"] = ""; //保质期，int类型
                //domBody[0]["cassunit"] = ""; //库存单位码，string类型
                //domBody[0]["corufts"] = ""; //对应单据时间戳，string类型
                //domBody[0]["cposname"] = ""; //货位，string类型
                //domBody[0]["cmolotcode"] = ""; //生产批号，string类型
                //domBody[0]["cmassunit"] = ""; //保质期单位，int类型
                //domBody[0]["csocode"] = ""; //需求跟踪号，string类型
                //domBody[0]["cmocode"] = ""; //生产订单号，string类型
                //domBody[0]["cvmivencode"] = ""; //代管商代码，string类型
                //domBody[0]["cvmivenname"] = ""; //代管商，string类型
                //domBody[0]["bvmiused"] = ""; //代管消耗标识，int类型
                //domBody[0]["ivmisettlequantity"] = ""; //代管挂账确认单数量，double类型
                //domBody[0]["ivmisettlenum"] = ""; //代管挂账确认单件数，double类型
                //domBody[0]["cdemandmemo"] = ""; //需求分类代号说明，string类型
                //domBody[0]["iordertype"] = ""; //销售订单类别，int类型
                //domBody[0]["iorderdid"] = ""; //iorderdid，int类型
                //domBody[0]["iordercode"] = ""; //销售订单号，string类型
                //domBody[0]["iorderseq"] = ""; //销售订单行号，string类型
                //domBody[0]["iexpiratdatecalcu"] = ""; //有效期推算方式，int类型
                //domBody[0]["cexpirationdate"] = ""; //有效期至，string类型
                //domBody[0]["dexpirationdate"] = ""; //有效期计算项，string类型
                //domBody[0]["cciqbookcode"] = ""; //手册号，string类型
                //domBody[0]["ibondedsumqty"] = ""; //累计保税处理抽取数量，string类型
                //domBody[0]["copdesc"] = ""; //工序说明，string类型
                //domBody[0]["cmworkcentercode"] = ""; //工作中心编码，string类型
                //domBody[0]["cmworkcenter"] = ""; //工作中心，string类型
                //domBody[0]["isotype"] = ""; //需求跟踪方式，int类型
                //domBody[0]["cbaccounter"] = ""; //记账人，string类型
                //domBody[0]["bcosting"] = ""; //是否核算，string类型
                //domBody[0]["isoseq"] = ""; //需求跟踪行号，string类型
                //domBody[0]["imoseq"] = ""; //生产订单行号，string类型
                //domBody[0]["iopseq"] = ""; //工序行号，string类型
                //domBody[0]["cdefine34"] = ""; //表体自定义项13，int类型
                //domBody[0]["cdefine35"] = ""; //表体自定义项14，int类型
                //domBody[0]["cdefine22"] = ""; //表体自定义项1，string类型
                //domBody[0]["cdefine28"] = ""; //表体自定义项7，string类型
                //domBody[0]["cdefine29"] = ""; //表体自定义项8，string类型
                //domBody[0]["cdefine30"] = ""; //表体自定义项9，string类型
                //domBody[0]["cdefine31"] = ""; //表体自定义项10，string类型
                //domBody[0]["cdefine32"] = ""; //表体自定义项11，string类型
                //domBody[0]["cdefine33"] = ""; //表体自定义项12，string类型
                //domBody[0]["cinvdefine4"] = ""; //存货自定义项4，string类型
                //domBody[0]["cinvdefine5"] = ""; //存货自定义项5，string类型
                //domBody[0]["cinvdefine6"] = ""; //存货自定义项6，string类型
                //domBody[0]["cinvdefine7"] = ""; //存货自定义项7，string类型
                //domBody[0]["cinvdefine8"] = ""; //存货自定义项8，string类型
                //domBody[0]["cinvdefine9"] = ""; //存货自定义项9，string类型
                //domBody[0]["cinvdefine10"] = ""; //存货自定义项10，string类型
                //domBody[0]["cinvdefine11"] = ""; //存货自定义项11，string类型
                //domBody[0]["cinvdefine12"] = ""; //存货自定义项12，string类型
                //domBody[0]["cbarcode"] = ""; //条形码，string类型
                //domBody[0]["cdefine23"] = ""; //表体自定义项2，string类型
                //domBody[0]["cdefine24"] = ""; //表体自定义项3，string类型
                //domBody[0]["cdefine25"] = ""; //表体自定义项4，string类型
                //domBody[0]["itrids"] = ""; //特殊单据子表标识，double类型
                //domBody[0]["cdefine26"] = ""; //表体自定义项5，double类型
                //domBody[0]["cdefine27"] = ""; //表体自定义项6，double类型
                //domBody[0]["citemcode"] = ""; //项目编码，string类型
                //domBody[0]["cname"] = ""; //项目，string类型
                //domBody[0]["citem_class"] = ""; //项目大类编码，string类型
                //domBody[0]["citemcname"] = ""; //项目大类名称，string类型

                //给普通参数domPosition赋值。此参数的数据类型为System.Object，此参数按引用传递，表示货位：传空
                broker.AssignNormalValue("domPosition", domPosition);

                //该参数errMsg为OUT型参数，由于其数据类型为System.String，为一般值类型，因此不必传入一个参数变量。在API调用返回时，可以通过GetResult("errMsg")获取其值

                //给普通参数cnnFrom赋值。此参数的数据类型为ADODB.Connection，此参数按引用传递，表示连接对象,如果由调用方控制事务，则需要设置此连接对象，否则传空
                broker.AssignNormalValue("cnnFrom", cnnFrom);

                //该参数VouchId为INOUT型普通参数。此参数的数据类型为System.String，此参数按值传递。在API调用返回时，可以通过GetResult("VouchId")获取其值
                broker.AssignNormalValue("VouchId", VouchId);

                //该参数domMsg为OUT型参数，由于其数据类型为MSXML2.IXMLDOMDocument2，非一般值类型，因此必须传入一个参数变量。在API调用返回时，可以直接使用该参数

                broker.AssignNormalValue("domMsg", domMsg);
                domMsgO = domMsg;

                //给普通参数bCheck赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否控制可用量。
                broker.AssignNormalValue("bCheck", bCheck);

                //给普通参数bBeforCheckStock赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示检查可用量
                broker.AssignNormalValue("bBeforCheckStock", bBeforCheckStock);

                //给普通参数bIsRedVouch赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否红字单据
                broker.AssignNormalValue("bIsRedVouch", bIsRedVouch);

                //给普通参数sAddedState赋值。此参数的数据类型为System.String，此参数按值传递，表示传空字符串
                broker.AssignNormalValue("sAddedState", sAddedState);

                //给普通参数bReMote赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否远程：转入false
                broker.AssignNormalValue("bReMote", bReMote);

                //第六步：调用API
                if (!broker.Invoke())
                {
                    //错误处理
                    Exception apiEx = broker.GetException();
                    if (apiEx != null)
                    {
                        if (apiEx is MomSysException)
                        {
                            MomSysException sysEx = apiEx as MomSysException;
                            WriteLog.Instance.Write("系统异常：" + sysEx.Message);
                            //todo:异常处理
                        }
                        else if (apiEx is MomBizException)
                        {
                            MomBizException bizEx = apiEx as MomBizException;
                            WriteLog.Instance.Write("API异常：" + bizEx.Message);
                            //todo:异常处理
                        }
                        //异常原因
                        String exReason = broker.GetExceptionString();
                        if (exReason.Length != 0)
                        {
                            WriteLog.Instance.Write("异常原因：" + exReason);
                        }
                    }
                    //结束本次调用，释放API资源
                    broker.Release();
                    domMsgO = null;
                    errMsg = apiEx.Message;
                    return false;

                }

                //第七步：获取返回结果

                //获取返回值
                //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值:true:成功,false:失败
                System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

                //获取out/inout参数值

                //获取普通OUT参数errMsg。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String errMsgRet = broker.GetResult("errMsg") as System.String;
                errMsg = errMsgRet;
                //获取普通INOUT参数VouchId。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String VouchIdRet = broker.GetResult("VouchId") as System.String;
                VouchId = VouchIdRet;
                //获取普通OUT参数domMsg。此返回值数据类型为MSXML2.IXMLDOMDocument2，在使用该参数之前，请判断是否为空
                MSXML2.IXMLDOMDocument2 domMsgRet = (MSXML2.IXMLDOMDocument2)broker.GetResult("domMsg");
                domMsgO = domMsgRet;
                //结束本次调用，释放API资源
                broker.Release();
                return result;
            }
            catch (Exception e)
            {
                domMsgO = null;
                errMsg = "提交前发生错误," + e.Message;
                return false;
            }
        }

        //销售出库单
        [WebMethod]
        public bool saleoutAdd(System.String sVouchType,
        string DomHeadXml,
        string domBodyXml,
        System.Object domPosition,
        out System.String errMsg,
        object cnnFromO,
        ref System.String VouchId,
        out object domMsgO,
        System.Boolean bCheck,
        System.Boolean bBeforCheckStock,
        System.Boolean bIsRedVouch,
        System.String sAddedState,
        System.Boolean bReMote)
        {
            try
            {
                //MSXML2.IXMLDOMDocument2 DomHead = (MSXML2.IXMLDOMDocument2)DomHeadO;
                //MSXML2.IXMLDOMDocument2 domBody = (MSXML2.IXMLDOMDocument2)domBodyO;
                domMsgO = new MSXML2.DOMDocumentClass();
                MSXML2.IXMLDOMDocument2 domMsg = (MSXML2.IXMLDOMDocument2)domMsgO;
                ADODB.Connection cnnFrom = (ADODB.Connection)cnnFromO;
                //第一步：构造u8login对象并登陆(引用U8API类库中的Interop.U8Login.dll)
                //如果当前环境中有login对象则可以省去第一步
                U8Login.clsLogin u8Login = new U8Login.clsLogin();
                String sSubId = "DP";
                String sAccID = SysParams.Instance.U8VouchCode;
                String sUserID = SysParams.Instance.U8uid;
                String sPassword = SysParams.Instance.U8pwd;
                String sServer = SysParams.Instance.U8ServerIP;     
                String sYear = "2017";
                String sDate = "2017-03-13";
                String sSerial = "";
                if (!u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUserID, ref sPassword, ref sDate, ref sServer, ref sSerial))
                {
                    errMsg = "登陆失败，原因：" + u8Login.ShareString;
                    WriteLog.Instance.Write(errMsg);
                    Marshal.FinalReleaseComObject(u8Login);
                    domMsgO = null;
                    return false;
                }

                //第二步：构造环境上下文对象，传入login，并按需设置其它上下文参数
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = u8Login;


                //第三步：设置API地址标识(Url)
                //当前API：添加新单据的地址标识为：U8API/saleout/Add
                U8ApiAddress myApiAddress = new U8ApiAddress("U8API/saleout/Add");

                //第四步：构造APIBroker
                U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

                //第五步：API参数赋值

                //给普通参数sVouchType赋值。此参数的数据类型为System.String，此参数按值传递，表示单据类型：10

                broker.AssignNormalValue("sVouchType", sVouchType);

                //给BO表头参数DomHead赋值，此BO参数的业务类型为产成品入库单，属表头参数。BO参数均按引用传递
                //提示：给BO表头参数DomHead赋值有两种方法

                //方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("DomHead", DomHead);

                //方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject DomHead = broker.GetBoParam("DomHead");
                setBusinessObject(ref DomHead, DomHeadXml);
                //DomHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
                ////给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //DomHead[0]["id"] = ""; //主关键字段，int类型
                //DomHead[0]["ccode"] = ""; //入库单号，string类型
                //DomHead[0]["ddate"] = ""; //入库日期，DateTime类型
                //DomHead[0]["cwhname"] = ""; //仓库，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //DomHead[0]["cmodifyperson"] = ""; //修改人，string类型
                //DomHead[0]["dmodifydate"] = ""; //修改日期，DateTime类型
                //DomHead[0]["dnmaketime"] = ""; //制单时间，DateTime类型
                //DomHead[0]["dnmodifytime"] = ""; //修改时间，DateTime类型
                //DomHead[0]["dnverifytime"] = ""; //审核时间，DateTime类型
                //DomHead[0]["dchkdate"] = ""; //检验日期，DateTime类型
                //DomHead[0]["iavaquantity"] = ""; //可用量，string类型
                //DomHead[0]["iavanum"] = ""; //可用件数，string类型
                //DomHead[0]["ipresentnum"] = ""; //现存件数，string类型
                //DomHead[0]["ufts"] = ""; //时间戳，string类型
                //DomHead[0]["cpspcode"] = ""; //产品，string类型
                //DomHead[0]["iproorderid"] = ""; //生产订单ID，string类型
                //DomHead[0]["cmpocode"] = ""; //生产订单号，string类型
                //DomHead[0]["cprobatch"] = ""; //生产批号，string类型
                //DomHead[0]["iverifystate"] = ""; //iverifystate，string类型
                //DomHead[0]["iswfcontrolled"] = ""; //iswfcontrolled，string类型
                //DomHead[0]["ireturncount"] = ""; //ireturncount，string类型
                //DomHead[0]["cdepname"] = ""; //部门，string类型
                //DomHead[0]["crdname"] = ""; //入库类别，string类型
                //DomHead[0]["dveridate"] = ""; //审核日期，DateTime类型
                //DomHead[0]["cmemo"] = ""; //备注，string类型
                //DomHead[0]["cchkperson"] = ""; //检验员，string类型
                //DomHead[0]["cmaker"] = ""; //制单人，string类型
                //DomHead[0]["chandler"] = ""; //审核人，string类型
                //DomHead[0]["itopsum"] = ""; //最高库存量，string类型
                //DomHead[0]["caccounter"] = ""; //记账人，string类型
                //DomHead[0]["ilowsum"] = ""; //最低库存量，string类型
                //DomHead[0]["ipresent"] = ""; //现存量，string类型
                //DomHead[0]["isafesum"] = ""; //安全库存量，string类型
                //DomHead[0]["cbustype"] = ""; //业务类型，int类型
                //DomHead[0]["cpersonname"] = ""; //业务员，string类型
                //DomHead[0]["cdefine1"] = ""; //表头自定义项1，string类型
                //DomHead[0]["cdefine11"] = ""; //表头自定义项11，string类型
                //DomHead[0]["cdefine12"] = ""; //表头自定义项12，string类型
                //DomHead[0]["cdefine13"] = ""; //表头自定义项13，string类型
                //DomHead[0]["cdefine14"] = ""; //表头自定义项14，string类型
                //DomHead[0]["cdefine2"] = ""; //表头自定义项2，string类型
                //DomHead[0]["cdefine3"] = ""; //表头自定义项3，string类型
                //DomHead[0]["csource"] = ""; //单据来源，int类型
                //DomHead[0]["cdefine5"] = ""; //表头自定义项5，int类型
                //DomHead[0]["cdefine15"] = ""; //表头自定义项15，int类型
                //DomHead[0]["cdefine6"] = ""; //表头自定义项6，DateTime类型
                //DomHead[0]["brdflag"] = ""; //收发标志，string类型
                //DomHead[0]["cdefine7"] = ""; //表头自定义项7，double类型
                //DomHead[0]["cdefine16"] = ""; //表头自定义项16，double类型
                //DomHead[0]["cdefine8"] = ""; //表头自定义项8，string类型
                //DomHead[0]["cdefine9"] = ""; //表头自定义项9，string类型
                //DomHead[0]["cdefine10"] = ""; //表头自定义项10，string类型
                //DomHead[0]["cvouchtype"] = ""; //单据类型，string类型
                //DomHead[0]["cwhcode"] = ""; //仓库编码，string类型
                //DomHead[0]["crdcode"] = ""; //入库类别编码，string类型
                //DomHead[0]["cdepcode"] = ""; //部门编码，string类型
                //DomHead[0]["cpersoncode"] = ""; //业务员编码，string类型
                //DomHead[0]["vt_id"] = ""; //模版号，int类型
                //DomHead[0]["cdefine4"] = ""; //表头自定义项4，DateTime类型

                ////给BO表体参数domBody赋值，此BO参数的业务类型为产成品入库单，属表体参数。BO参数均按引用传递
                ////提示：给BO表体参数domBody赋值有两种方法

                ////方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("domBody", domBody);

                ////方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject domBody = broker.GetBoParam("domBody");
                setBusinessObject(ref domBody, domBodyXml);
                //domBody.RowCount = 10; //设置BO对象行数
                ////可以自由设置BO对象行数为大于零的整数，也可以不设置而自动增加行数
                ////给BO对象的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //domBody[0]["autoid"] = ""; //主关键字段，int类型
                //domBody[0]["cinvcode"] = ""; //产品编码，string类型
                //domBody[0]["editprop"] = ""; //编辑属性：A表新增，M表修改，D表删除，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //domBody[0]["id"] = ""; //与主表关联项，int类型
                //domBody[0]["cinvaddcode"] = ""; //产品代码，string类型
                //domBody[0]["cinvname"] = ""; //产品名称，string类型
                //domBody[0]["cinvstd"] = ""; //规格型号，string类型
                //domBody[0]["cinvm_unit"] = ""; //主计量单位，string类型
                //domBody[0]["cinva_unit"] = ""; //库存单位，string类型
                //domBody[0]["creplaceitem"] = ""; //替换件，string类型
                //domBody[0]["cposition"] = ""; //货位编码，string类型
                //domBody[0]["cinvdefine1"] = ""; //存货自定义项1，string类型
                //domBody[0]["cinvdefine2"] = ""; //存货自定义项2，string类型
                //domBody[0]["cinvdefine3"] = ""; //存货自定义项3，string类型
                //domBody[0]["cfree1"] = ""; //存货自由项1，string类型
                //domBody[0]["cbatchproperty1"] = ""; //批次属性1，double类型
                //domBody[0]["cbatchproperty2"] = ""; //批次属性2，double类型
                //domBody[0]["cfree2"] = ""; //存货自由项2，string类型
                //domBody[0]["cbatch"] = ""; //批号，string类型
                //domBody[0]["iinvexchrate"] = ""; //换算率，double类型
                //domBody[0]["inum"] = ""; //件数，double类型
                //domBody[0]["iquantity"] = ""; //数量，double类型
                //domBody[0]["iunitcost"] = ""; //单价，double类型
                //domBody[0]["iprice"] = ""; //金额，double类型
                //domBody[0]["ipunitcost"] = ""; //计划单价，double类型
                //domBody[0]["ipprice"] = ""; //计划金额，double类型
                //domBody[0]["dvdate"] = ""; //失效日期，DateTime类型
                //domBody[0]["isoutquantity"] = ""; //累计出库数量，double类型
                //domBody[0]["isoutnum"] = ""; //累计出库件数，double类型
                //domBody[0]["dsdate"] = ""; //结算日期，DateTime类型
                //domBody[0]["ifquantity"] = ""; //实际数量，double类型
                //domBody[0]["ifnum"] = ""; //实际件数，double类型
                //domBody[0]["cvouchcode"] = ""; //对应入库单id，string类型
                //domBody[0]["cfree3"] = ""; //存货自由项3，string类型
                //domBody[0]["cbatchproperty3"] = ""; //批次属性3，double类型
                //domBody[0]["cbatchproperty4"] = ""; //批次属性4，double类型
                //domBody[0]["cfree4"] = ""; //存货自由项4，string类型
                //domBody[0]["cfree5"] = ""; //存货自由项5，string类型
                //domBody[0]["cbatchproperty5"] = ""; //批次属性5，double类型
                //domBody[0]["cbatchproperty6"] = ""; //批次属性6，string类型
                //domBody[0]["cfree6"] = ""; //存货自由项6，string类型
                //domBody[0]["cfree7"] = ""; //存货自由项7，string类型
                //domBody[0]["cbatchproperty7"] = ""; //批次属性7，string类型
                //domBody[0]["cbatchproperty8"] = ""; //批次属性8，string类型
                //domBody[0]["cfree8"] = ""; //存货自由项8，string类型
                //domBody[0]["cfree9"] = ""; //存货自由项9，string类型
                //domBody[0]["cbatchproperty9"] = ""; //批次属性9，string类型
                //domBody[0]["cbatchproperty10"] = ""; //批次属性10，DateTime类型
                //domBody[0]["cfree10"] = ""; //存货自由项10，string类型
                //domBody[0]["cdefine36"] = ""; //表体自定义项15，DateTime类型
                //domBody[0]["cdefine37"] = ""; //表体自定义项16，DateTime类型
                //domBody[0]["cinvdefine13"] = ""; //存货自定义项13，string类型
                //domBody[0]["cinvdefine14"] = ""; //存货自定义项14，string类型
                //domBody[0]["cinvdefine15"] = ""; //存货自定义项15，string类型
                //domBody[0]["cinvdefine16"] = ""; //存货自定义项16，string类型
                //domBody[0]["inquantity"] = ""; //应收数量，double类型
                //domBody[0]["innum"] = ""; //应收件数，double类型
                //domBody[0]["dmadedate"] = ""; //生产日期，DateTime类型
                //domBody[0]["impoids"] = ""; //生产订单子表ID，int类型
                //domBody[0]["icheckids"] = ""; //检验单子表ID，int类型
                //domBody[0]["isodid"] = ""; //销售订单子表ID，string类型
                //domBody[0]["brelated"] = ""; //是否联副产品，int类型
                //domBody[0]["cbvencode"] = ""; //供应商编码，string类型
                //domBody[0]["cinvouchcode"] = ""; //对应入库单号，string类型
                //domBody[0]["cvenname"] = ""; //供应商，string类型
                //domBody[0]["imassdate"] = ""; //保质期，int类型
                //domBody[0]["cassunit"] = ""; //库存单位码，string类型
                //domBody[0]["corufts"] = ""; //对应单据时间戳，string类型
                //domBody[0]["cposname"] = ""; //货位，string类型
                //domBody[0]["cmolotcode"] = ""; //生产批号，string类型
                //domBody[0]["cmassunit"] = ""; //保质期单位，int类型
                //domBody[0]["csocode"] = ""; //需求跟踪号，string类型
                //domBody[0]["cmocode"] = ""; //生产订单号，string类型
                //domBody[0]["cvmivencode"] = ""; //代管商代码，string类型
                //domBody[0]["cvmivenname"] = ""; //代管商，string类型
                //domBody[0]["bvmiused"] = ""; //代管消耗标识，int类型
                //domBody[0]["ivmisettlequantity"] = ""; //代管挂账确认单数量，double类型
                //domBody[0]["ivmisettlenum"] = ""; //代管挂账确认单件数，double类型
                //domBody[0]["cdemandmemo"] = ""; //需求分类代号说明，string类型
                //domBody[0]["iordertype"] = ""; //销售订单类别，int类型
                //domBody[0]["iorderdid"] = ""; //iorderdid，int类型
                //domBody[0]["iordercode"] = ""; //销售订单号，string类型
                //domBody[0]["iorderseq"] = ""; //销售订单行号，string类型
                //domBody[0]["iexpiratdatecalcu"] = ""; //有效期推算方式，int类型
                //domBody[0]["cexpirationdate"] = ""; //有效期至，string类型
                //domBody[0]["dexpirationdate"] = ""; //有效期计算项，string类型
                //domBody[0]["cciqbookcode"] = ""; //手册号，string类型
                //domBody[0]["ibondedsumqty"] = ""; //累计保税处理抽取数量，string类型
                //domBody[0]["copdesc"] = ""; //工序说明，string类型
                //domBody[0]["cmworkcentercode"] = ""; //工作中心编码，string类型
                //domBody[0]["cmworkcenter"] = ""; //工作中心，string类型
                //domBody[0]["isotype"] = ""; //需求跟踪方式，int类型
                //domBody[0]["cbaccounter"] = ""; //记账人，string类型
                //domBody[0]["bcosting"] = ""; //是否核算，string类型
                //domBody[0]["isoseq"] = ""; //需求跟踪行号，string类型
                //domBody[0]["imoseq"] = ""; //生产订单行号，string类型
                //domBody[0]["iopseq"] = ""; //工序行号，string类型
                //domBody[0]["cdefine34"] = ""; //表体自定义项13，int类型
                //domBody[0]["cdefine35"] = ""; //表体自定义项14，int类型
                //domBody[0]["cdefine22"] = ""; //表体自定义项1，string类型
                //domBody[0]["cdefine28"] = ""; //表体自定义项7，string类型
                //domBody[0]["cdefine29"] = ""; //表体自定义项8，string类型
                //domBody[0]["cdefine30"] = ""; //表体自定义项9，string类型
                //domBody[0]["cdefine31"] = ""; //表体自定义项10，string类型
                //domBody[0]["cdefine32"] = ""; //表体自定义项11，string类型
                //domBody[0]["cdefine33"] = ""; //表体自定义项12，string类型
                //domBody[0]["cinvdefine4"] = ""; //存货自定义项4，string类型
                //domBody[0]["cinvdefine5"] = ""; //存货自定义项5，string类型
                //domBody[0]["cinvdefine6"] = ""; //存货自定义项6，string类型
                //domBody[0]["cinvdefine7"] = ""; //存货自定义项7，string类型
                //domBody[0]["cinvdefine8"] = ""; //存货自定义项8，string类型
                //domBody[0]["cinvdefine9"] = ""; //存货自定义项9，string类型
                //domBody[0]["cinvdefine10"] = ""; //存货自定义项10，string类型
                //domBody[0]["cinvdefine11"] = ""; //存货自定义项11，string类型
                //domBody[0]["cinvdefine12"] = ""; //存货自定义项12，string类型
                //domBody[0]["cbarcode"] = ""; //条形码，string类型
                //domBody[0]["cdefine23"] = ""; //表体自定义项2，string类型
                //domBody[0]["cdefine24"] = ""; //表体自定义项3，string类型
                //domBody[0]["cdefine25"] = ""; //表体自定义项4，string类型
                //domBody[0]["itrids"] = ""; //特殊单据子表标识，double类型
                //domBody[0]["cdefine26"] = ""; //表体自定义项5，double类型
                //domBody[0]["cdefine27"] = ""; //表体自定义项6，double类型
                //domBody[0]["citemcode"] = ""; //项目编码，string类型
                //domBody[0]["cname"] = ""; //项目，string类型
                //domBody[0]["citem_class"] = ""; //项目大类编码，string类型
                //domBody[0]["citemcname"] = ""; //项目大类名称，string类型

                //给普通参数domPosition赋值。此参数的数据类型为System.Object，此参数按引用传递，表示货位：传空
                broker.AssignNormalValue("domPosition", domPosition);

                //该参数errMsg为OUT型参数，由于其数据类型为System.String，为一般值类型，因此不必传入一个参数变量。在API调用返回时，可以通过GetResult("errMsg")获取其值

                //给普通参数cnnFrom赋值。此参数的数据类型为ADODB.Connection，此参数按引用传递，表示连接对象,如果由调用方控制事务，则需要设置此连接对象，否则传空
                broker.AssignNormalValue("cnnFrom", cnnFrom);

                //该参数VouchId为INOUT型普通参数。此参数的数据类型为System.String，此参数按值传递。在API调用返回时，可以通过GetResult("VouchId")获取其值
                broker.AssignNormalValue("VouchId", VouchId);

                //该参数domMsg为OUT型参数，由于其数据类型为MSXML2.IXMLDOMDocument2，非一般值类型，因此必须传入一个参数变量。在API调用返回时，可以直接使用该参数

                broker.AssignNormalValue("domMsg", domMsg);
                domMsgO = domMsg;

                //给普通参数bCheck赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否控制可用量。
                broker.AssignNormalValue("bCheck", bCheck);

                //给普通参数bBeforCheckStock赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示检查可用量
                broker.AssignNormalValue("bBeforCheckStock", bBeforCheckStock);

                //给普通参数bIsRedVouch赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否红字单据
                broker.AssignNormalValue("bIsRedVouch", bIsRedVouch);

                //给普通参数sAddedState赋值。此参数的数据类型为System.String，此参数按值传递，表示传空字符串
                broker.AssignNormalValue("sAddedState", sAddedState);

                //给普通参数bReMote赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否远程：转入false
                broker.AssignNormalValue("bReMote", bReMote);

                //第六步：调用API
                if (!broker.Invoke())
                {
                    //错误处理
                    Exception apiEx = broker.GetException();
                    if (apiEx != null)
                    {
                        if (apiEx is MomSysException)
                        {
                            MomSysException sysEx = apiEx as MomSysException;
                            WriteLog.Instance.Write("系统异常：" + sysEx.Message);
                            //todo:异常处理
                        }
                        else if (apiEx is MomBizException)
                        {
                            MomBizException bizEx = apiEx as MomBizException;
                            WriteLog.Instance.Write("API异常：" + bizEx.Message);
                            //todo:异常处理
                        }
                        //异常原因
                        String exReason = broker.GetExceptionString();
                        if (exReason.Length != 0)
                        {
                            WriteLog.Instance.Write("异常原因：" + exReason);
                        }
                    }
                    //结束本次调用，释放API资源
                    broker.Release();
                    domMsgO = null;
                    errMsg = apiEx.Message;
                    return false;

                }

                //第七步：获取返回结果

                //获取返回值
                //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值:true:成功,false:失败
                System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

                //获取out/inout参数值

                //获取普通OUT参数errMsg。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String errMsgRet = broker.GetResult("errMsg") as System.String;
                errMsg = errMsgRet;
                //获取普通INOUT参数VouchId。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String VouchIdRet = broker.GetResult("VouchId") as System.String;
                VouchId = VouchIdRet;
                //获取普通OUT参数domMsg。此返回值数据类型为MSXML2.IXMLDOMDocument2，在使用该参数之前，请判断是否为空
                MSXML2.IXMLDOMDocument2 domMsgRet = (MSXML2.IXMLDOMDocument2)broker.GetResult("domMsg");
                domMsgO = domMsgRet;
                //结束本次调用，释放API资源
                broker.Release();
                return result;
            }
            catch (Exception e)
            {
                domMsgO = null;
                errMsg = "提交前发生错误," + e.Message;
                return false;
            }
        }

        //其他入库单
        [WebMethod]
        public bool otherinAdd(System.String sVouchType,
        string DomHeadXml,
        string domBodyXml,
        System.Object domPosition,
        out System.String errMsg,
        object cnnFromO,
        ref System.String VouchId,
        out object domMsgO,
        System.Boolean bCheck,
        System.Boolean bBeforCheckStock,
        System.Boolean bIsRedVouch,
        System.String sAddedState,
        System.Boolean bReMote)
        {
            try
            {
                //MSXML2.IXMLDOMDocument2 DomHead = (MSXML2.IXMLDOMDocument2)DomHeadO;
                //MSXML2.IXMLDOMDocument2 domBody = (MSXML2.IXMLDOMDocument2)domBodyO;
                domMsgO = new MSXML2.DOMDocumentClass();
                MSXML2.IXMLDOMDocument2 domMsg = (MSXML2.IXMLDOMDocument2)domMsgO;
                ADODB.Connection cnnFrom = (ADODB.Connection)cnnFromO;
                //第一步：构造u8login对象并登陆(引用U8API类库中的Interop.U8Login.dll)
                //如果当前环境中有login对象则可以省去第一步
                U8Login.clsLogin u8Login = new U8Login.clsLogin();
                String sSubId = "DP";
                String sAccID = SysParams.Instance.U8VouchCode;
                String sUserID = SysParams.Instance.U8uid;
                String sPassword = SysParams.Instance.U8pwd;
                String sServer = SysParams.Instance.U8ServerIP;
                String sYear = "2017";
                String sDate = "2017-03-13";
                String sSerial = "";
                if (!u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUserID, ref sPassword, ref sDate, ref sServer, ref sSerial))
                {
                    errMsg = "登陆失败，原因：" + u8Login.ShareString;
                    WriteLog.Instance.Write(errMsg);
                    Marshal.FinalReleaseComObject(u8Login);
                    domMsgO = null;
                    return false;
                }

                //第二步：构造环境上下文对象，传入login，并按需设置其它上下文参数
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = u8Login;


                //第三步：设置API地址标识(Url)
                //当前API：添加新单据的地址标识为：U8API/otherin/Add
                U8ApiAddress myApiAddress = new U8ApiAddress("U8API/otherin/Add");

                //第四步：构造APIBroker
                U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

                //第五步：API参数赋值

                //给普通参数sVouchType赋值。此参数的数据类型为System.String，此参数按值传递，表示单据类型：10

                broker.AssignNormalValue("sVouchType", sVouchType);

                //给BO表头参数DomHead赋值，此BO参数的业务类型为产成品入库单，属表头参数。BO参数均按引用传递
                //提示：给BO表头参数DomHead赋值有两种方法

                //方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("DomHead", DomHead);

                //方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject DomHead = broker.GetBoParam("DomHead");
                setBusinessObject(ref DomHead, DomHeadXml);
                //DomHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
                ////给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //DomHead[0]["id"] = ""; //主关键字段，int类型
                //DomHead[0]["ccode"] = ""; //入库单号，string类型
                //DomHead[0]["ddate"] = ""; //入库日期，DateTime类型
                //DomHead[0]["cwhname"] = ""; //仓库，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //DomHead[0]["cmodifyperson"] = ""; //修改人，string类型
                //DomHead[0]["dmodifydate"] = ""; //修改日期，DateTime类型
                //DomHead[0]["dnmaketime"] = ""; //制单时间，DateTime类型
                //DomHead[0]["dnmodifytime"] = ""; //修改时间，DateTime类型
                //DomHead[0]["dnverifytime"] = ""; //审核时间，DateTime类型
                //DomHead[0]["dchkdate"] = ""; //检验日期，DateTime类型
                //DomHead[0]["iavaquantity"] = ""; //可用量，string类型
                //DomHead[0]["iavanum"] = ""; //可用件数，string类型
                //DomHead[0]["ipresentnum"] = ""; //现存件数，string类型
                //DomHead[0]["ufts"] = ""; //时间戳，string类型
                //DomHead[0]["cpspcode"] = ""; //产品，string类型
                //DomHead[0]["iproorderid"] = ""; //生产订单ID，string类型
                //DomHead[0]["cmpocode"] = ""; //生产订单号，string类型
                //DomHead[0]["cprobatch"] = ""; //生产批号，string类型
                //DomHead[0]["iverifystate"] = ""; //iverifystate，string类型
                //DomHead[0]["iswfcontrolled"] = ""; //iswfcontrolled，string类型
                //DomHead[0]["ireturncount"] = ""; //ireturncount，string类型
                //DomHead[0]["cdepname"] = ""; //部门，string类型
                //DomHead[0]["crdname"] = ""; //入库类别，string类型
                //DomHead[0]["dveridate"] = ""; //审核日期，DateTime类型
                //DomHead[0]["cmemo"] = ""; //备注，string类型
                //DomHead[0]["cchkperson"] = ""; //检验员，string类型
                //DomHead[0]["cmaker"] = ""; //制单人，string类型
                //DomHead[0]["chandler"] = ""; //审核人，string类型
                //DomHead[0]["itopsum"] = ""; //最高库存量，string类型
                //DomHead[0]["caccounter"] = ""; //记账人，string类型
                //DomHead[0]["ilowsum"] = ""; //最低库存量，string类型
                //DomHead[0]["ipresent"] = ""; //现存量，string类型
                //DomHead[0]["isafesum"] = ""; //安全库存量，string类型
                //DomHead[0]["cbustype"] = ""; //业务类型，int类型
                //DomHead[0]["cpersonname"] = ""; //业务员，string类型
                //DomHead[0]["cdefine1"] = ""; //表头自定义项1，string类型
                //DomHead[0]["cdefine11"] = ""; //表头自定义项11，string类型
                //DomHead[0]["cdefine12"] = ""; //表头自定义项12，string类型
                //DomHead[0]["cdefine13"] = ""; //表头自定义项13，string类型
                //DomHead[0]["cdefine14"] = ""; //表头自定义项14，string类型
                //DomHead[0]["cdefine2"] = ""; //表头自定义项2，string类型
                //DomHead[0]["cdefine3"] = ""; //表头自定义项3，string类型
                //DomHead[0]["csource"] = ""; //单据来源，int类型
                //DomHead[0]["cdefine5"] = ""; //表头自定义项5，int类型
                //DomHead[0]["cdefine15"] = ""; //表头自定义项15，int类型
                //DomHead[0]["cdefine6"] = ""; //表头自定义项6，DateTime类型
                //DomHead[0]["brdflag"] = ""; //收发标志，string类型
                //DomHead[0]["cdefine7"] = ""; //表头自定义项7，double类型
                //DomHead[0]["cdefine16"] = ""; //表头自定义项16，double类型
                //DomHead[0]["cdefine8"] = ""; //表头自定义项8，string类型
                //DomHead[0]["cdefine9"] = ""; //表头自定义项9，string类型
                //DomHead[0]["cdefine10"] = ""; //表头自定义项10，string类型
                //DomHead[0]["cvouchtype"] = ""; //单据类型，string类型
                //DomHead[0]["cwhcode"] = ""; //仓库编码，string类型
                //DomHead[0]["crdcode"] = ""; //入库类别编码，string类型
                //DomHead[0]["cdepcode"] = ""; //部门编码，string类型
                //DomHead[0]["cpersoncode"] = ""; //业务员编码，string类型
                //DomHead[0]["vt_id"] = ""; //模版号，int类型
                //DomHead[0]["cdefine4"] = ""; //表头自定义项4，DateTime类型

                ////给BO表体参数domBody赋值，此BO参数的业务类型为产成品入库单，属表体参数。BO参数均按引用传递
                ////提示：给BO表体参数domBody赋值有两种方法

                ////方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("domBody", domBody);

                ////方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject domBody = broker.GetBoParam("domBody");
                setBusinessObject(ref domBody, domBodyXml);
                //domBody.RowCount = 10; //设置BO对象行数
                ////可以自由设置BO对象行数为大于零的整数，也可以不设置而自动增加行数
                ////给BO对象的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //domBody[0]["autoid"] = ""; //主关键字段，int类型
                //domBody[0]["cinvcode"] = ""; //产品编码，string类型
                //domBody[0]["editprop"] = ""; //编辑属性：A表新增，M表修改，D表删除，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //domBody[0]["id"] = ""; //与主表关联项，int类型
                //domBody[0]["cinvaddcode"] = ""; //产品代码，string类型
                //domBody[0]["cinvname"] = ""; //产品名称，string类型
                //domBody[0]["cinvstd"] = ""; //规格型号，string类型
                //domBody[0]["cinvm_unit"] = ""; //主计量单位，string类型
                //domBody[0]["cinva_unit"] = ""; //库存单位，string类型
                //domBody[0]["creplaceitem"] = ""; //替换件，string类型
                //domBody[0]["cposition"] = ""; //货位编码，string类型
                //domBody[0]["cinvdefine1"] = ""; //存货自定义项1，string类型
                //domBody[0]["cinvdefine2"] = ""; //存货自定义项2，string类型
                //domBody[0]["cinvdefine3"] = ""; //存货自定义项3，string类型
                //domBody[0]["cfree1"] = ""; //存货自由项1，string类型
                //domBody[0]["cbatchproperty1"] = ""; //批次属性1，double类型
                //domBody[0]["cbatchproperty2"] = ""; //批次属性2，double类型
                //domBody[0]["cfree2"] = ""; //存货自由项2，string类型
                //domBody[0]["cbatch"] = ""; //批号，string类型
                //domBody[0]["iinvexchrate"] = ""; //换算率，double类型
                //domBody[0]["inum"] = ""; //件数，double类型
                //domBody[0]["iquantity"] = ""; //数量，double类型
                //domBody[0]["iunitcost"] = ""; //单价，double类型
                //domBody[0]["iprice"] = ""; //金额，double类型
                //domBody[0]["ipunitcost"] = ""; //计划单价，double类型
                //domBody[0]["ipprice"] = ""; //计划金额，double类型
                //domBody[0]["dvdate"] = ""; //失效日期，DateTime类型
                //domBody[0]["isoutquantity"] = ""; //累计出库数量，double类型
                //domBody[0]["isoutnum"] = ""; //累计出库件数，double类型
                //domBody[0]["dsdate"] = ""; //结算日期，DateTime类型
                //domBody[0]["ifquantity"] = ""; //实际数量，double类型
                //domBody[0]["ifnum"] = ""; //实际件数，double类型
                //domBody[0]["cvouchcode"] = ""; //对应入库单id，string类型
                //domBody[0]["cfree3"] = ""; //存货自由项3，string类型
                //domBody[0]["cbatchproperty3"] = ""; //批次属性3，double类型
                //domBody[0]["cbatchproperty4"] = ""; //批次属性4，double类型
                //domBody[0]["cfree4"] = ""; //存货自由项4，string类型
                //domBody[0]["cfree5"] = ""; //存货自由项5，string类型
                //domBody[0]["cbatchproperty5"] = ""; //批次属性5，double类型
                //domBody[0]["cbatchproperty6"] = ""; //批次属性6，string类型
                //domBody[0]["cfree6"] = ""; //存货自由项6，string类型
                //domBody[0]["cfree7"] = ""; //存货自由项7，string类型
                //domBody[0]["cbatchproperty7"] = ""; //批次属性7，string类型
                //domBody[0]["cbatchproperty8"] = ""; //批次属性8，string类型
                //domBody[0]["cfree8"] = ""; //存货自由项8，string类型
                //domBody[0]["cfree9"] = ""; //存货自由项9，string类型
                //domBody[0]["cbatchproperty9"] = ""; //批次属性9，string类型
                //domBody[0]["cbatchproperty10"] = ""; //批次属性10，DateTime类型
                //domBody[0]["cfree10"] = ""; //存货自由项10，string类型
                //domBody[0]["cdefine36"] = ""; //表体自定义项15，DateTime类型
                //domBody[0]["cdefine37"] = ""; //表体自定义项16，DateTime类型
                //domBody[0]["cinvdefine13"] = ""; //存货自定义项13，string类型
                //domBody[0]["cinvdefine14"] = ""; //存货自定义项14，string类型
                //domBody[0]["cinvdefine15"] = ""; //存货自定义项15，string类型
                //domBody[0]["cinvdefine16"] = ""; //存货自定义项16，string类型
                //domBody[0]["inquantity"] = ""; //应收数量，double类型
                //domBody[0]["innum"] = ""; //应收件数，double类型
                //domBody[0]["dmadedate"] = ""; //生产日期，DateTime类型
                //domBody[0]["impoids"] = ""; //生产订单子表ID，int类型
                //domBody[0]["icheckids"] = ""; //检验单子表ID，int类型
                //domBody[0]["isodid"] = ""; //销售订单子表ID，string类型
                //domBody[0]["brelated"] = ""; //是否联副产品，int类型
                //domBody[0]["cbvencode"] = ""; //供应商编码，string类型
                //domBody[0]["cinvouchcode"] = ""; //对应入库单号，string类型
                //domBody[0]["cvenname"] = ""; //供应商，string类型
                //domBody[0]["imassdate"] = ""; //保质期，int类型
                //domBody[0]["cassunit"] = ""; //库存单位码，string类型
                //domBody[0]["corufts"] = ""; //对应单据时间戳，string类型
                //domBody[0]["cposname"] = ""; //货位，string类型
                //domBody[0]["cmolotcode"] = ""; //生产批号，string类型
                //domBody[0]["cmassunit"] = ""; //保质期单位，int类型
                //domBody[0]["csocode"] = ""; //需求跟踪号，string类型
                //domBody[0]["cmocode"] = ""; //生产订单号，string类型
                //domBody[0]["cvmivencode"] = ""; //代管商代码，string类型
                //domBody[0]["cvmivenname"] = ""; //代管商，string类型
                //domBody[0]["bvmiused"] = ""; //代管消耗标识，int类型
                //domBody[0]["ivmisettlequantity"] = ""; //代管挂账确认单数量，double类型
                //domBody[0]["ivmisettlenum"] = ""; //代管挂账确认单件数，double类型
                //domBody[0]["cdemandmemo"] = ""; //需求分类代号说明，string类型
                //domBody[0]["iordertype"] = ""; //销售订单类别，int类型
                //domBody[0]["iorderdid"] = ""; //iorderdid，int类型
                //domBody[0]["iordercode"] = ""; //销售订单号，string类型
                //domBody[0]["iorderseq"] = ""; //销售订单行号，string类型
                //domBody[0]["iexpiratdatecalcu"] = ""; //有效期推算方式，int类型
                //domBody[0]["cexpirationdate"] = ""; //有效期至，string类型
                //domBody[0]["dexpirationdate"] = ""; //有效期计算项，string类型
                //domBody[0]["cciqbookcode"] = ""; //手册号，string类型
                //domBody[0]["ibondedsumqty"] = ""; //累计保税处理抽取数量，string类型
                //domBody[0]["copdesc"] = ""; //工序说明，string类型
                //domBody[0]["cmworkcentercode"] = ""; //工作中心编码，string类型
                //domBody[0]["cmworkcenter"] = ""; //工作中心，string类型
                //domBody[0]["isotype"] = ""; //需求跟踪方式，int类型
                //domBody[0]["cbaccounter"] = ""; //记账人，string类型
                //domBody[0]["bcosting"] = ""; //是否核算，string类型
                //domBody[0]["isoseq"] = ""; //需求跟踪行号，string类型
                //domBody[0]["imoseq"] = ""; //生产订单行号，string类型
                //domBody[0]["iopseq"] = ""; //工序行号，string类型
                //domBody[0]["cdefine34"] = ""; //表体自定义项13，int类型
                //domBody[0]["cdefine35"] = ""; //表体自定义项14，int类型
                //domBody[0]["cdefine22"] = ""; //表体自定义项1，string类型
                //domBody[0]["cdefine28"] = ""; //表体自定义项7，string类型
                //domBody[0]["cdefine29"] = ""; //表体自定义项8，string类型
                //domBody[0]["cdefine30"] = ""; //表体自定义项9，string类型
                //domBody[0]["cdefine31"] = ""; //表体自定义项10，string类型
                //domBody[0]["cdefine32"] = ""; //表体自定义项11，string类型
                //domBody[0]["cdefine33"] = ""; //表体自定义项12，string类型
                //domBody[0]["cinvdefine4"] = ""; //存货自定义项4，string类型
                //domBody[0]["cinvdefine5"] = ""; //存货自定义项5，string类型
                //domBody[0]["cinvdefine6"] = ""; //存货自定义项6，string类型
                //domBody[0]["cinvdefine7"] = ""; //存货自定义项7，string类型
                //domBody[0]["cinvdefine8"] = ""; //存货自定义项8，string类型
                //domBody[0]["cinvdefine9"] = ""; //存货自定义项9，string类型
                //domBody[0]["cinvdefine10"] = ""; //存货自定义项10，string类型
                //domBody[0]["cinvdefine11"] = ""; //存货自定义项11，string类型
                //domBody[0]["cinvdefine12"] = ""; //存货自定义项12，string类型
                //domBody[0]["cbarcode"] = ""; //条形码，string类型
                //domBody[0]["cdefine23"] = ""; //表体自定义项2，string类型
                //domBody[0]["cdefine24"] = ""; //表体自定义项3，string类型
                //domBody[0]["cdefine25"] = ""; //表体自定义项4，string类型
                //domBody[0]["itrids"] = ""; //特殊单据子表标识，double类型
                //domBody[0]["cdefine26"] = ""; //表体自定义项5，double类型
                //domBody[0]["cdefine27"] = ""; //表体自定义项6，double类型
                //domBody[0]["citemcode"] = ""; //项目编码，string类型
                //domBody[0]["cname"] = ""; //项目，string类型
                //domBody[0]["citem_class"] = ""; //项目大类编码，string类型
                //domBody[0]["citemcname"] = ""; //项目大类名称，string类型

                //给普通参数domPosition赋值。此参数的数据类型为System.Object，此参数按引用传递，表示货位：传空
                broker.AssignNormalValue("domPosition", domPosition);

                //该参数errMsg为OUT型参数，由于其数据类型为System.String，为一般值类型，因此不必传入一个参数变量。在API调用返回时，可以通过GetResult("errMsg")获取其值

                //给普通参数cnnFrom赋值。此参数的数据类型为ADODB.Connection，此参数按引用传递，表示连接对象,如果由调用方控制事务，则需要设置此连接对象，否则传空
                broker.AssignNormalValue("cnnFrom", cnnFrom);

                //该参数VouchId为INOUT型普通参数。此参数的数据类型为System.String，此参数按值传递。在API调用返回时，可以通过GetResult("VouchId")获取其值
                broker.AssignNormalValue("VouchId", VouchId);

                //该参数domMsg为OUT型参数，由于其数据类型为MSXML2.IXMLDOMDocument2，非一般值类型，因此必须传入一个参数变量。在API调用返回时，可以直接使用该参数

                broker.AssignNormalValue("domMsg", domMsg);
                domMsgO = domMsg;

                //给普通参数bCheck赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否控制可用量。
                broker.AssignNormalValue("bCheck", bCheck);

                //给普通参数bBeforCheckStock赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示检查可用量
                broker.AssignNormalValue("bBeforCheckStock", bBeforCheckStock);

                //给普通参数bIsRedVouch赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否红字单据
                broker.AssignNormalValue("bIsRedVouch", bIsRedVouch);

                //给普通参数sAddedState赋值。此参数的数据类型为System.String，此参数按值传递，表示传空字符串
                broker.AssignNormalValue("sAddedState", sAddedState);

                //给普通参数bReMote赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否远程：转入false
                broker.AssignNormalValue("bReMote", bReMote);

                //第六步：调用API
                if (!broker.Invoke())
                {
                    //错误处理
                    Exception apiEx = broker.GetException();
                    if (apiEx != null)
                    {
                        if (apiEx is MomSysException)
                        {
                            MomSysException sysEx = apiEx as MomSysException;
                            WriteLog.Instance.Write("系统异常：" + sysEx.Message);
                            //todo:异常处理
                        }
                        else if (apiEx is MomBizException)
                        {
                            MomBizException bizEx = apiEx as MomBizException;
                            WriteLog.Instance.Write("API异常：" + bizEx.Message);
                            //todo:异常处理
                        }
                        //异常原因
                        String exReason = broker.GetExceptionString();
                        if (exReason.Length != 0)
                        {
                            WriteLog.Instance.Write("异常原因：" + exReason);
                        }
                    }
                    //结束本次调用，释放API资源
                    broker.Release();
                    domMsgO = null;
                    errMsg = apiEx.Message;
                    return false;

                }

                //第七步：获取返回结果

                //获取返回值
                //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值:true:成功,false:失败
                System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

                //获取out/inout参数值

                //获取普通OUT参数errMsg。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String errMsgRet = broker.GetResult("errMsg") as System.String;
                errMsg = errMsgRet;
                //获取普通INOUT参数VouchId。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String VouchIdRet = broker.GetResult("VouchId") as System.String;
                VouchId = VouchIdRet;
                //获取普通OUT参数domMsg。此返回值数据类型为MSXML2.IXMLDOMDocument2，在使用该参数之前，请判断是否为空
                MSXML2.IXMLDOMDocument2 domMsgRet = (MSXML2.IXMLDOMDocument2)broker.GetResult("domMsg");
                domMsgO = domMsgRet;
                //结束本次调用，释放API资源
                broker.Release();
                return result;
            }
            catch (Exception e)
            {
                domMsgO = null;
                errMsg = "提交前发生错误，" + e.Message;
                return false;
            }
        }

        //其他出库单
        [WebMethod]
        public bool otheroutAdd(System.String sVouchType,
        string DomHeadXml,
        string domBodyXml,
        System.Object domPosition,
        out System.String errMsg,
        object cnnFromO,
        ref System.String VouchId,
        out object domMsgO,
        System.Boolean bCheck,
        System.Boolean bBeforCheckStock,
        System.Boolean bIsRedVouch,
        System.String sAddedState,
        System.Boolean bReMote)
        {
            try
            {
                //MSXML2.IXMLDOMDocument2 DomHead = (MSXML2.IXMLDOMDocument2)DomHeadO;
                //MSXML2.IXMLDOMDocument2 domBody = (MSXML2.IXMLDOMDocument2)domBodyO;
                domMsgO = new MSXML2.DOMDocumentClass();
                MSXML2.IXMLDOMDocument2 domMsg = (MSXML2.IXMLDOMDocument2)domMsgO;
                ADODB.Connection cnnFrom = (ADODB.Connection)cnnFromO;
                //第一步：构造u8login对象并登陆(引用U8API类库中的Interop.U8Login.dll)
                //如果当前环境中有login对象则可以省去第一步
                U8Login.clsLogin u8Login = new U8Login.clsLogin();
                String sSubId = "DP";
                String sAccID = SysParams.Instance.U8VouchCode;
                String sUserID = SysParams.Instance.U8uid;
                String sPassword = SysParams.Instance.U8pwd;
                String sServer = SysParams.Instance.U8ServerIP;
                String sYear = "2017";
                String sDate = "2017-03-13";
                String sSerial = "";
                if (!u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUserID, ref sPassword, ref sDate, ref sServer, ref sSerial))
                {
                    errMsg = "登陆失败，原因：" + u8Login.ShareString;
                    WriteLog.Instance.Write(errMsg);
                    Marshal.FinalReleaseComObject(u8Login);
                    domMsgO = null;
                    return false;
                }

                //第二步：构造环境上下文对象，传入login，并按需设置其它上下文参数
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = u8Login;


                //第三步：设置API地址标识(Url)
                //当前API：添加新单据的地址标识为：U8API/otherout/Add
                U8ApiAddress myApiAddress = new U8ApiAddress("U8API/otherout/Add");

                //第四步：构造APIBroker
                U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

                //第五步：API参数赋值

                //给普通参数sVouchType赋值。此参数的数据类型为System.String，此参数按值传递，表示单据类型：10

                broker.AssignNormalValue("sVouchType", sVouchType);

                //给BO表头参数DomHead赋值，此BO参数的业务类型为产成品入库单，属表头参数。BO参数均按引用传递
                //提示：给BO表头参数DomHead赋值有两种方法

                //方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("DomHead", DomHead);

                //方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject DomHead = broker.GetBoParam("DomHead");
                setBusinessObject(ref DomHead, DomHeadXml);
                //DomHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
                ////给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //DomHead[0]["id"] = ""; //主关键字段，int类型
                //DomHead[0]["ccode"] = ""; //入库单号，string类型
                //DomHead[0]["ddate"] = ""; //入库日期，DateTime类型
                //DomHead[0]["cwhname"] = ""; //仓库，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //DomHead[0]["cmodifyperson"] = ""; //修改人，string类型
                //DomHead[0]["dmodifydate"] = ""; //修改日期，DateTime类型
                //DomHead[0]["dnmaketime"] = ""; //制单时间，DateTime类型
                //DomHead[0]["dnmodifytime"] = ""; //修改时间，DateTime类型
                //DomHead[0]["dnverifytime"] = ""; //审核时间，DateTime类型
                //DomHead[0]["dchkdate"] = ""; //检验日期，DateTime类型
                //DomHead[0]["iavaquantity"] = ""; //可用量，string类型
                //DomHead[0]["iavanum"] = ""; //可用件数，string类型
                //DomHead[0]["ipresentnum"] = ""; //现存件数，string类型
                //DomHead[0]["ufts"] = ""; //时间戳，string类型
                //DomHead[0]["cpspcode"] = ""; //产品，string类型
                //DomHead[0]["iproorderid"] = ""; //生产订单ID，string类型
                //DomHead[0]["cmpocode"] = ""; //生产订单号，string类型
                //DomHead[0]["cprobatch"] = ""; //生产批号，string类型
                //DomHead[0]["iverifystate"] = ""; //iverifystate，string类型
                //DomHead[0]["iswfcontrolled"] = ""; //iswfcontrolled，string类型
                //DomHead[0]["ireturncount"] = ""; //ireturncount，string类型
                //DomHead[0]["cdepname"] = ""; //部门，string类型
                //DomHead[0]["crdname"] = ""; //入库类别，string类型
                //DomHead[0]["dveridate"] = ""; //审核日期，DateTime类型
                //DomHead[0]["cmemo"] = ""; //备注，string类型
                //DomHead[0]["cchkperson"] = ""; //检验员，string类型
                //DomHead[0]["cmaker"] = ""; //制单人，string类型
                //DomHead[0]["chandler"] = ""; //审核人，string类型
                //DomHead[0]["itopsum"] = ""; //最高库存量，string类型
                //DomHead[0]["caccounter"] = ""; //记账人，string类型
                //DomHead[0]["ilowsum"] = ""; //最低库存量，string类型
                //DomHead[0]["ipresent"] = ""; //现存量，string类型
                //DomHead[0]["isafesum"] = ""; //安全库存量，string类型
                //DomHead[0]["cbustype"] = ""; //业务类型，int类型
                //DomHead[0]["cpersonname"] = ""; //业务员，string类型
                //DomHead[0]["cdefine1"] = ""; //表头自定义项1，string类型
                //DomHead[0]["cdefine11"] = ""; //表头自定义项11，string类型
                //DomHead[0]["cdefine12"] = ""; //表头自定义项12，string类型
                //DomHead[0]["cdefine13"] = ""; //表头自定义项13，string类型
                //DomHead[0]["cdefine14"] = ""; //表头自定义项14，string类型
                //DomHead[0]["cdefine2"] = ""; //表头自定义项2，string类型
                //DomHead[0]["cdefine3"] = ""; //表头自定义项3，string类型
                //DomHead[0]["csource"] = ""; //单据来源，int类型
                //DomHead[0]["cdefine5"] = ""; //表头自定义项5，int类型
                //DomHead[0]["cdefine15"] = ""; //表头自定义项15，int类型
                //DomHead[0]["cdefine6"] = ""; //表头自定义项6，DateTime类型
                //DomHead[0]["brdflag"] = ""; //收发标志，string类型
                //DomHead[0]["cdefine7"] = ""; //表头自定义项7，double类型
                //DomHead[0]["cdefine16"] = ""; //表头自定义项16，double类型
                //DomHead[0]["cdefine8"] = ""; //表头自定义项8，string类型
                //DomHead[0]["cdefine9"] = ""; //表头自定义项9，string类型
                //DomHead[0]["cdefine10"] = ""; //表头自定义项10，string类型
                //DomHead[0]["cvouchtype"] = ""; //单据类型，string类型
                //DomHead[0]["cwhcode"] = ""; //仓库编码，string类型
                //DomHead[0]["crdcode"] = ""; //入库类别编码，string类型
                //DomHead[0]["cdepcode"] = ""; //部门编码，string类型
                //DomHead[0]["cpersoncode"] = ""; //业务员编码，string类型
                //DomHead[0]["vt_id"] = ""; //模版号，int类型
                //DomHead[0]["cdefine4"] = ""; //表头自定义项4，DateTime类型

                ////给BO表体参数domBody赋值，此BO参数的业务类型为产成品入库单，属表体参数。BO参数均按引用传递
                ////提示：给BO表体参数domBody赋值有两种方法

                ////方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("domBody", domBody);

                ////方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject domBody = broker.GetBoParam("domBody");
                setBusinessObject(ref domBody, domBodyXml);
                //domBody.RowCount = 10; //设置BO对象行数
                ////可以自由设置BO对象行数为大于零的整数，也可以不设置而自动增加行数
                ////给BO对象的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //domBody[0]["autoid"] = ""; //主关键字段，int类型
                //domBody[0]["cinvcode"] = ""; //产品编码，string类型
                //domBody[0]["editprop"] = ""; //编辑属性：A表新增，M表修改，D表删除，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //domBody[0]["id"] = ""; //与主表关联项，int类型
                //domBody[0]["cinvaddcode"] = ""; //产品代码，string类型
                //domBody[0]["cinvname"] = ""; //产品名称，string类型
                //domBody[0]["cinvstd"] = ""; //规格型号，string类型
                //domBody[0]["cinvm_unit"] = ""; //主计量单位，string类型
                //domBody[0]["cinva_unit"] = ""; //库存单位，string类型
                //domBody[0]["creplaceitem"] = ""; //替换件，string类型
                //domBody[0]["cposition"] = ""; //货位编码，string类型
                //domBody[0]["cinvdefine1"] = ""; //存货自定义项1，string类型
                //domBody[0]["cinvdefine2"] = ""; //存货自定义项2，string类型
                //domBody[0]["cinvdefine3"] = ""; //存货自定义项3，string类型
                //domBody[0]["cfree1"] = ""; //存货自由项1，string类型
                //domBody[0]["cbatchproperty1"] = ""; //批次属性1，double类型
                //domBody[0]["cbatchproperty2"] = ""; //批次属性2，double类型
                //domBody[0]["cfree2"] = ""; //存货自由项2，string类型
                //domBody[0]["cbatch"] = ""; //批号，string类型
                //domBody[0]["iinvexchrate"] = ""; //换算率，double类型
                //domBody[0]["inum"] = ""; //件数，double类型
                //domBody[0]["iquantity"] = ""; //数量，double类型
                //domBody[0]["iunitcost"] = ""; //单价，double类型
                //domBody[0]["iprice"] = ""; //金额，double类型
                //domBody[0]["ipunitcost"] = ""; //计划单价，double类型
                //domBody[0]["ipprice"] = ""; //计划金额，double类型
                //domBody[0]["dvdate"] = ""; //失效日期，DateTime类型
                //domBody[0]["isoutquantity"] = ""; //累计出库数量，double类型
                //domBody[0]["isoutnum"] = ""; //累计出库件数，double类型
                //domBody[0]["dsdate"] = ""; //结算日期，DateTime类型
                //domBody[0]["ifquantity"] = ""; //实际数量，double类型
                //domBody[0]["ifnum"] = ""; //实际件数，double类型
                //domBody[0]["cvouchcode"] = ""; //对应入库单id，string类型
                //domBody[0]["cfree3"] = ""; //存货自由项3，string类型
                //domBody[0]["cbatchproperty3"] = ""; //批次属性3，double类型
                //domBody[0]["cbatchproperty4"] = ""; //批次属性4，double类型
                //domBody[0]["cfree4"] = ""; //存货自由项4，string类型
                //domBody[0]["cfree5"] = ""; //存货自由项5，string类型
                //domBody[0]["cbatchproperty5"] = ""; //批次属性5，double类型
                //domBody[0]["cbatchproperty6"] = ""; //批次属性6，string类型
                //domBody[0]["cfree6"] = ""; //存货自由项6，string类型
                //domBody[0]["cfree7"] = ""; //存货自由项7，string类型
                //domBody[0]["cbatchproperty7"] = ""; //批次属性7，string类型
                //domBody[0]["cbatchproperty8"] = ""; //批次属性8，string类型
                //domBody[0]["cfree8"] = ""; //存货自由项8，string类型
                //domBody[0]["cfree9"] = ""; //存货自由项9，string类型
                //domBody[0]["cbatchproperty9"] = ""; //批次属性9，string类型
                //domBody[0]["cbatchproperty10"] = ""; //批次属性10，DateTime类型
                //domBody[0]["cfree10"] = ""; //存货自由项10，string类型
                //domBody[0]["cdefine36"] = ""; //表体自定义项15，DateTime类型
                //domBody[0]["cdefine37"] = ""; //表体自定义项16，DateTime类型
                //domBody[0]["cinvdefine13"] = ""; //存货自定义项13，string类型
                //domBody[0]["cinvdefine14"] = ""; //存货自定义项14，string类型
                //domBody[0]["cinvdefine15"] = ""; //存货自定义项15，string类型
                //domBody[0]["cinvdefine16"] = ""; //存货自定义项16，string类型
                //domBody[0]["inquantity"] = ""; //应收数量，double类型
                //domBody[0]["innum"] = ""; //应收件数，double类型
                //domBody[0]["dmadedate"] = ""; //生产日期，DateTime类型
                //domBody[0]["impoids"] = ""; //生产订单子表ID，int类型
                //domBody[0]["icheckids"] = ""; //检验单子表ID，int类型
                //domBody[0]["isodid"] = ""; //销售订单子表ID，string类型
                //domBody[0]["brelated"] = ""; //是否联副产品，int类型
                //domBody[0]["cbvencode"] = ""; //供应商编码，string类型
                //domBody[0]["cinvouchcode"] = ""; //对应入库单号，string类型
                //domBody[0]["cvenname"] = ""; //供应商，string类型
                //domBody[0]["imassdate"] = ""; //保质期，int类型
                //domBody[0]["cassunit"] = ""; //库存单位码，string类型
                //domBody[0]["corufts"] = ""; //对应单据时间戳，string类型
                //domBody[0]["cposname"] = ""; //货位，string类型
                //domBody[0]["cmolotcode"] = ""; //生产批号，string类型
                //domBody[0]["cmassunit"] = ""; //保质期单位，int类型
                //domBody[0]["csocode"] = ""; //需求跟踪号，string类型
                //domBody[0]["cmocode"] = ""; //生产订单号，string类型
                //domBody[0]["cvmivencode"] = ""; //代管商代码，string类型
                //domBody[0]["cvmivenname"] = ""; //代管商，string类型
                //domBody[0]["bvmiused"] = ""; //代管消耗标识，int类型
                //domBody[0]["ivmisettlequantity"] = ""; //代管挂账确认单数量，double类型
                //domBody[0]["ivmisettlenum"] = ""; //代管挂账确认单件数，double类型
                //domBody[0]["cdemandmemo"] = ""; //需求分类代号说明，string类型
                //domBody[0]["iordertype"] = ""; //销售订单类别，int类型
                //domBody[0]["iorderdid"] = ""; //iorderdid，int类型
                //domBody[0]["iordercode"] = ""; //销售订单号，string类型
                //domBody[0]["iorderseq"] = ""; //销售订单行号，string类型
                //domBody[0]["iexpiratdatecalcu"] = ""; //有效期推算方式，int类型
                //domBody[0]["cexpirationdate"] = ""; //有效期至，string类型
                //domBody[0]["dexpirationdate"] = ""; //有效期计算项，string类型
                //domBody[0]["cciqbookcode"] = ""; //手册号，string类型
                //domBody[0]["ibondedsumqty"] = ""; //累计保税处理抽取数量，string类型
                //domBody[0]["copdesc"] = ""; //工序说明，string类型
                //domBody[0]["cmworkcentercode"] = ""; //工作中心编码，string类型
                //domBody[0]["cmworkcenter"] = ""; //工作中心，string类型
                //domBody[0]["isotype"] = ""; //需求跟踪方式，int类型
                //domBody[0]["cbaccounter"] = ""; //记账人，string类型
                //domBody[0]["bcosting"] = ""; //是否核算，string类型
                //domBody[0]["isoseq"] = ""; //需求跟踪行号，string类型
                //domBody[0]["imoseq"] = ""; //生产订单行号，string类型
                //domBody[0]["iopseq"] = ""; //工序行号，string类型
                //domBody[0]["cdefine34"] = ""; //表体自定义项13，int类型
                //domBody[0]["cdefine35"] = ""; //表体自定义项14，int类型
                //domBody[0]["cdefine22"] = ""; //表体自定义项1，string类型
                //domBody[0]["cdefine28"] = ""; //表体自定义项7，string类型
                //domBody[0]["cdefine29"] = ""; //表体自定义项8，string类型
                //domBody[0]["cdefine30"] = ""; //表体自定义项9，string类型
                //domBody[0]["cdefine31"] = ""; //表体自定义项10，string类型
                //domBody[0]["cdefine32"] = ""; //表体自定义项11，string类型
                //domBody[0]["cdefine33"] = ""; //表体自定义项12，string类型
                //domBody[0]["cinvdefine4"] = ""; //存货自定义项4，string类型
                //domBody[0]["cinvdefine5"] = ""; //存货自定义项5，string类型
                //domBody[0]["cinvdefine6"] = ""; //存货自定义项6，string类型
                //domBody[0]["cinvdefine7"] = ""; //存货自定义项7，string类型
                //domBody[0]["cinvdefine8"] = ""; //存货自定义项8，string类型
                //domBody[0]["cinvdefine9"] = ""; //存货自定义项9，string类型
                //domBody[0]["cinvdefine10"] = ""; //存货自定义项10，string类型
                //domBody[0]["cinvdefine11"] = ""; //存货自定义项11，string类型
                //domBody[0]["cinvdefine12"] = ""; //存货自定义项12，string类型
                //domBody[0]["cbarcode"] = ""; //条形码，string类型
                //domBody[0]["cdefine23"] = ""; //表体自定义项2，string类型
                //domBody[0]["cdefine24"] = ""; //表体自定义项3，string类型
                //domBody[0]["cdefine25"] = ""; //表体自定义项4，string类型
                //domBody[0]["itrids"] = ""; //特殊单据子表标识，double类型
                //domBody[0]["cdefine26"] = ""; //表体自定义项5，double类型
                //domBody[0]["cdefine27"] = ""; //表体自定义项6，double类型
                //domBody[0]["citemcode"] = ""; //项目编码，string类型
                //domBody[0]["cname"] = ""; //项目，string类型
                //domBody[0]["citem_class"] = ""; //项目大类编码，string类型
                //domBody[0]["citemcname"] = ""; //项目大类名称，string类型

                //给普通参数domPosition赋值。此参数的数据类型为System.Object，此参数按引用传递，表示货位：传空
                broker.AssignNormalValue("domPosition", domPosition);

                //该参数errMsg为OUT型参数，由于其数据类型为System.String，为一般值类型，因此不必传入一个参数变量。在API调用返回时，可以通过GetResult("errMsg")获取其值

                //给普通参数cnnFrom赋值。此参数的数据类型为ADODB.Connection，此参数按引用传递，表示连接对象,如果由调用方控制事务，则需要设置此连接对象，否则传空
                broker.AssignNormalValue("cnnFrom", cnnFrom);

                //该参数VouchId为INOUT型普通参数。此参数的数据类型为System.String，此参数按值传递。在API调用返回时，可以通过GetResult("VouchId")获取其值
                broker.AssignNormalValue("VouchId", VouchId);

                //该参数domMsg为OUT型参数，由于其数据类型为MSXML2.IXMLDOMDocument2，非一般值类型，因此必须传入一个参数变量。在API调用返回时，可以直接使用该参数

                broker.AssignNormalValue("domMsg", domMsg);
                domMsgO = domMsg;

                //给普通参数bCheck赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否控制可用量。
                broker.AssignNormalValue("bCheck", bCheck);

                //给普通参数bBeforCheckStock赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示检查可用量
                broker.AssignNormalValue("bBeforCheckStock", bBeforCheckStock);

                //给普通参数bIsRedVouch赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否红字单据
                broker.AssignNormalValue("bIsRedVouch", bIsRedVouch);

                //给普通参数sAddedState赋值。此参数的数据类型为System.String，此参数按值传递，表示传空字符串
                broker.AssignNormalValue("sAddedState", sAddedState);

                //给普通参数bReMote赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否远程：转入false
                broker.AssignNormalValue("bReMote", bReMote);

                //第六步：调用API
                if (!broker.Invoke())
                {
                    //错误处理
                    Exception apiEx = broker.GetException();
                    if (apiEx != null)
                    {
                        if (apiEx is MomSysException)
                        {
                            MomSysException sysEx = apiEx as MomSysException;
                            WriteLog.Instance.Write("系统异常：" + sysEx.Message);
                            //todo:异常处理
                        }
                        else if (apiEx is MomBizException)
                        {
                            MomBizException bizEx = apiEx as MomBizException;
                            WriteLog.Instance.Write("API异常：" + bizEx.Message);
                            //todo:异常处理
                        }
                        //异常原因
                        String exReason = broker.GetExceptionString();
                        if (exReason.Length != 0)
                        {
                            WriteLog.Instance.Write("异常原因：" + exReason);
                        }
                    }
                    //结束本次调用，释放API资源
                    broker.Release();
                    domMsgO = null;
                    errMsg = apiEx.Message;
                    return false;

                }

                //第七步：获取返回结果

                //获取返回值
                //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值:true:成功,false:失败
                System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

                //获取out/inout参数值

                //获取普通OUT参数errMsg。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String errMsgRet = broker.GetResult("errMsg") as System.String;
                errMsg = errMsgRet;
                //获取普通INOUT参数VouchId。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String VouchIdRet = broker.GetResult("VouchId") as System.String;
                VouchId = VouchIdRet;
                //获取普通OUT参数domMsg。此返回值数据类型为MSXML2.IXMLDOMDocument2，在使用该参数之前，请判断是否为空
                MSXML2.IXMLDOMDocument2 domMsgRet = (MSXML2.IXMLDOMDocument2)broker.GetResult("domMsg");
                domMsgO = domMsgRet;
                //结束本次调用，释放API资源
                broker.Release();
                return result;
            }
            catch (Exception e)
            {
                domMsgO = null;
                errMsg = "提交前发生错误," + e.Message;
                return false;
            }
        }

        //形态转换单
        [WebMethod]
        public bool ShapeChangVouchAdd(System.String sVouchType,
        string DomHeadXml,
        string domBodyXml,
        System.Object domPosition,
        out System.String errMsg,
        object cnnFromO,
        ref System.String VouchId,
        out object domMsgO,
        System.Boolean bCheck,
        System.Boolean bBeforCheckStock,
        System.Boolean bIsRedVouch,
        System.String sAddedState,
        System.Boolean bReMote)
        {
            try
            {
                //MSXML2.IXMLDOMDocument2 DomHead = (MSXML2.IXMLDOMDocument2)DomHeadO;
                //MSXML2.IXMLDOMDocument2 domBody = (MSXML2.IXMLDOMDocument2)domBodyO;
                domMsgO = new MSXML2.DOMDocumentClass();
                MSXML2.IXMLDOMDocument2 domMsg = (MSXML2.IXMLDOMDocument2)domMsgO;
                ADODB.Connection cnnFrom = (ADODB.Connection)cnnFromO;
                //第一步：构造u8login对象并登陆(引用U8API类库中的Interop.U8Login.dll)
                //如果当前环境中有login对象则可以省去第一步
                U8Login.clsLogin u8Login = new U8Login.clsLogin();
                String sSubId = "DP";
                String sAccID = SysParams.Instance.U8VouchCode;
                String sUserID = SysParams.Instance.U8uid;
                String sPassword = SysParams.Instance.U8pwd;
                String sServer = SysParams.Instance.U8ServerIP;
                String sYear = "2017";
                String sDate = "2017-03-13";
                String sSerial = "";
                if (!u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUserID, ref sPassword, ref sDate, ref sServer, ref sSerial))
                {
                    errMsg = "登陆失败，原因：" + u8Login.ShareString;
                    WriteLog.Instance.Write(errMsg);
                    Marshal.FinalReleaseComObject(u8Login);
                    domMsgO = null;
                    return false;
                }

                //第二步：构造环境上下文对象，传入login，并按需设置其它上下文参数
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = u8Login;


                //第三步：设置API地址标识(Url)
                //当前API：添加新单据的地址标识为：U8API/ShapeChangVouch/Add
                U8ApiAddress myApiAddress = new U8ApiAddress("U8API/ShapeChangVouch/Add");

                //第四步：构造APIBroker
                U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

                //第五步：API参数赋值

                //给普通参数sVouchType赋值。此参数的数据类型为System.String，此参数按值传递，表示单据类型：10

                broker.AssignNormalValue("sVouchType", sVouchType);

                //给BO表头参数DomHead赋值，此BO参数的业务类型为产成品入库单，属表头参数。BO参数均按引用传递
                //提示：给BO表头参数DomHead赋值有两种方法

                //方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("DomHead", DomHead);

                //方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject DomHead = broker.GetBoParam("DomHead");
                setBusinessObject(ref DomHead, DomHeadXml);
                //DomHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
                ////给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //DomHead[0]["id"] = ""; //主关键字段，int类型
                //DomHead[0]["ccode"] = ""; //入库单号，string类型
                //DomHead[0]["ddate"] = ""; //入库日期，DateTime类型
                //DomHead[0]["cwhname"] = ""; //仓库，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //DomHead[0]["cmodifyperson"] = ""; //修改人，string类型
                //DomHead[0]["dmodifydate"] = ""; //修改日期，DateTime类型
                //DomHead[0]["dnmaketime"] = ""; //制单时间，DateTime类型
                //DomHead[0]["dnmodifytime"] = ""; //修改时间，DateTime类型
                //DomHead[0]["dnverifytime"] = ""; //审核时间，DateTime类型
                //DomHead[0]["dchkdate"] = ""; //检验日期，DateTime类型
                //DomHead[0]["iavaquantity"] = ""; //可用量，string类型
                //DomHead[0]["iavanum"] = ""; //可用件数，string类型
                //DomHead[0]["ipresentnum"] = ""; //现存件数，string类型
                //DomHead[0]["ufts"] = ""; //时间戳，string类型
                //DomHead[0]["cpspcode"] = ""; //产品，string类型
                //DomHead[0]["iproorderid"] = ""; //生产订单ID，string类型
                //DomHead[0]["cmpocode"] = ""; //生产订单号，string类型
                //DomHead[0]["cprobatch"] = ""; //生产批号，string类型
                //DomHead[0]["iverifystate"] = ""; //iverifystate，string类型
                //DomHead[0]["iswfcontrolled"] = ""; //iswfcontrolled，string类型
                //DomHead[0]["ireturncount"] = ""; //ireturncount，string类型
                //DomHead[0]["cdepname"] = ""; //部门，string类型
                //DomHead[0]["crdname"] = ""; //入库类别，string类型
                //DomHead[0]["dveridate"] = ""; //审核日期，DateTime类型
                //DomHead[0]["cmemo"] = ""; //备注，string类型
                //DomHead[0]["cchkperson"] = ""; //检验员，string类型
                //DomHead[0]["cmaker"] = ""; //制单人，string类型
                //DomHead[0]["chandler"] = ""; //审核人，string类型
                //DomHead[0]["itopsum"] = ""; //最高库存量，string类型
                //DomHead[0]["caccounter"] = ""; //记账人，string类型
                //DomHead[0]["ilowsum"] = ""; //最低库存量，string类型
                //DomHead[0]["ipresent"] = ""; //现存量，string类型
                //DomHead[0]["isafesum"] = ""; //安全库存量，string类型
                //DomHead[0]["cbustype"] = ""; //业务类型，int类型
                //DomHead[0]["cpersonname"] = ""; //业务员，string类型
                //DomHead[0]["cdefine1"] = ""; //表头自定义项1，string类型
                //DomHead[0]["cdefine11"] = ""; //表头自定义项11，string类型
                //DomHead[0]["cdefine12"] = ""; //表头自定义项12，string类型
                //DomHead[0]["cdefine13"] = ""; //表头自定义项13，string类型
                //DomHead[0]["cdefine14"] = ""; //表头自定义项14，string类型
                //DomHead[0]["cdefine2"] = ""; //表头自定义项2，string类型
                //DomHead[0]["cdefine3"] = ""; //表头自定义项3，string类型
                //DomHead[0]["csource"] = ""; //单据来源，int类型
                //DomHead[0]["cdefine5"] = ""; //表头自定义项5，int类型
                //DomHead[0]["cdefine15"] = ""; //表头自定义项15，int类型
                //DomHead[0]["cdefine6"] = ""; //表头自定义项6，DateTime类型
                //DomHead[0]["brdflag"] = ""; //收发标志，string类型
                //DomHead[0]["cdefine7"] = ""; //表头自定义项7，double类型
                //DomHead[0]["cdefine16"] = ""; //表头自定义项16，double类型
                //DomHead[0]["cdefine8"] = ""; //表头自定义项8，string类型
                //DomHead[0]["cdefine9"] = ""; //表头自定义项9，string类型
                //DomHead[0]["cdefine10"] = ""; //表头自定义项10，string类型
                //DomHead[0]["cvouchtype"] = ""; //单据类型，string类型
                //DomHead[0]["cwhcode"] = ""; //仓库编码，string类型
                //DomHead[0]["crdcode"] = ""; //入库类别编码，string类型
                //DomHead[0]["cdepcode"] = ""; //部门编码，string类型
                //DomHead[0]["cpersoncode"] = ""; //业务员编码，string类型
                //DomHead[0]["vt_id"] = ""; //模版号，int类型
                //DomHead[0]["cdefine4"] = ""; //表头自定义项4，DateTime类型

                ////给BO表体参数domBody赋值，此BO参数的业务类型为产成品入库单，属表体参数。BO参数均按引用传递
                ////提示：给BO表体参数domBody赋值有两种方法

                ////方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("domBody", domBody);

                ////方法二是构造BusinessObject对象，具体方法如下：
                ////方法二是构造BusinessObject对象，具体方法如下：
                BusinessObject domBody = broker.GetBoParam("domBody");
                setBusinessObject(ref domBody, domBodyXml);
                //domBody.RowCount = 10; //设置BO对象行数
                ////可以自由设置BO对象行数为大于零的整数，也可以不设置而自动增加行数
                ////给BO对象的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ///****************************** 以下是必输字段 ****************************/
                //domBody[0]["autoid"] = ""; //主关键字段，int类型
                //domBody[0]["cinvcode"] = ""; //产品编码，string类型
                //domBody[0]["editprop"] = ""; //编辑属性：A表新增，M表修改，D表删除，string类型

                ///***************************** 以下是非必输字段 ****************************/
                //domBody[0]["id"] = ""; //与主表关联项，int类型
                //domBody[0]["cinvaddcode"] = ""; //产品代码，string类型
                //domBody[0]["cinvname"] = ""; //产品名称，string类型
                //domBody[0]["cinvstd"] = ""; //规格型号，string类型
                //domBody[0]["cinvm_unit"] = ""; //主计量单位，string类型
                //domBody[0]["cinva_unit"] = ""; //库存单位，string类型
                //domBody[0]["creplaceitem"] = ""; //替换件，string类型
                //domBody[0]["cposition"] = ""; //货位编码，string类型
                //domBody[0]["cinvdefine1"] = ""; //存货自定义项1，string类型
                //domBody[0]["cinvdefine2"] = ""; //存货自定义项2，string类型
                //domBody[0]["cinvdefine3"] = ""; //存货自定义项3，string类型
                //domBody[0]["cfree1"] = ""; //存货自由项1，string类型
                //domBody[0]["cbatchproperty1"] = ""; //批次属性1，double类型
                //domBody[0]["cbatchproperty2"] = ""; //批次属性2，double类型
                //domBody[0]["cfree2"] = ""; //存货自由项2，string类型
                //domBody[0]["cbatch"] = ""; //批号，string类型
                //domBody[0]["iinvexchrate"] = ""; //换算率，double类型
                //domBody[0]["inum"] = ""; //件数，double类型
                //domBody[0]["iquantity"] = ""; //数量，double类型
                //domBody[0]["iunitcost"] = ""; //单价，double类型
                //domBody[0]["iprice"] = ""; //金额，double类型
                //domBody[0]["ipunitcost"] = ""; //计划单价，double类型
                //domBody[0]["ipprice"] = ""; //计划金额，double类型
                //domBody[0]["dvdate"] = ""; //失效日期，DateTime类型
                //domBody[0]["isoutquantity"] = ""; //累计出库数量，double类型
                //domBody[0]["isoutnum"] = ""; //累计出库件数，double类型
                //domBody[0]["dsdate"] = ""; //结算日期，DateTime类型
                //domBody[0]["ifquantity"] = ""; //实际数量，double类型
                //domBody[0]["ifnum"] = ""; //实际件数，double类型
                //domBody[0]["cvouchcode"] = ""; //对应入库单id，string类型
                //domBody[0]["cfree3"] = ""; //存货自由项3，string类型
                //domBody[0]["cbatchproperty3"] = ""; //批次属性3，double类型
                //domBody[0]["cbatchproperty4"] = ""; //批次属性4，double类型
                //domBody[0]["cfree4"] = ""; //存货自由项4，string类型
                //domBody[0]["cfree5"] = ""; //存货自由项5，string类型
                //domBody[0]["cbatchproperty5"] = ""; //批次属性5，double类型
                //domBody[0]["cbatchproperty6"] = ""; //批次属性6，string类型
                //domBody[0]["cfree6"] = ""; //存货自由项6，string类型
                //domBody[0]["cfree7"] = ""; //存货自由项7，string类型
                //domBody[0]["cbatchproperty7"] = ""; //批次属性7，string类型
                //domBody[0]["cbatchproperty8"] = ""; //批次属性8，string类型
                //domBody[0]["cfree8"] = ""; //存货自由项8，string类型
                //domBody[0]["cfree9"] = ""; //存货自由项9，string类型
                //domBody[0]["cbatchproperty9"] = ""; //批次属性9，string类型
                //domBody[0]["cbatchproperty10"] = ""; //批次属性10，DateTime类型
                //domBody[0]["cfree10"] = ""; //存货自由项10，string类型
                //domBody[0]["cdefine36"] = ""; //表体自定义项15，DateTime类型
                //domBody[0]["cdefine37"] = ""; //表体自定义项16，DateTime类型
                //domBody[0]["cinvdefine13"] = ""; //存货自定义项13，string类型
                //domBody[0]["cinvdefine14"] = ""; //存货自定义项14，string类型
                //domBody[0]["cinvdefine15"] = ""; //存货自定义项15，string类型
                //domBody[0]["cinvdefine16"] = ""; //存货自定义项16，string类型
                //domBody[0]["inquantity"] = ""; //应收数量，double类型
                //domBody[0]["innum"] = ""; //应收件数，double类型
                //domBody[0]["dmadedate"] = ""; //生产日期，DateTime类型
                //domBody[0]["impoids"] = ""; //生产订单子表ID，int类型
                //domBody[0]["icheckids"] = ""; //检验单子表ID，int类型
                //domBody[0]["isodid"] = ""; //销售订单子表ID，string类型
                //domBody[0]["brelated"] = ""; //是否联副产品，int类型
                //domBody[0]["cbvencode"] = ""; //供应商编码，string类型
                //domBody[0]["cinvouchcode"] = ""; //对应入库单号，string类型
                //domBody[0]["cvenname"] = ""; //供应商，string类型
                //domBody[0]["imassdate"] = ""; //保质期，int类型
                //domBody[0]["cassunit"] = ""; //库存单位码，string类型
                //domBody[0]["corufts"] = ""; //对应单据时间戳，string类型
                //domBody[0]["cposname"] = ""; //货位，string类型
                //domBody[0]["cmolotcode"] = ""; //生产批号，string类型
                //domBody[0]["cmassunit"] = ""; //保质期单位，int类型
                //domBody[0]["csocode"] = ""; //需求跟踪号，string类型
                //domBody[0]["cmocode"] = ""; //生产订单号，string类型
                //domBody[0]["cvmivencode"] = ""; //代管商代码，string类型
                //domBody[0]["cvmivenname"] = ""; //代管商，string类型
                //domBody[0]["bvmiused"] = ""; //代管消耗标识，int类型
                //domBody[0]["ivmisettlequantity"] = ""; //代管挂账确认单数量，double类型
                //domBody[0]["ivmisettlenum"] = ""; //代管挂账确认单件数，double类型
                //domBody[0]["cdemandmemo"] = ""; //需求分类代号说明，string类型
                //domBody[0]["iordertype"] = ""; //销售订单类别，int类型
                //domBody[0]["iorderdid"] = ""; //iorderdid，int类型
                //domBody[0]["iordercode"] = ""; //销售订单号，string类型
                //domBody[0]["iorderseq"] = ""; //销售订单行号，string类型
                //domBody[0]["iexpiratdatecalcu"] = ""; //有效期推算方式，int类型
                //domBody[0]["cexpirationdate"] = ""; //有效期至，string类型
                //domBody[0]["dexpirationdate"] = ""; //有效期计算项，string类型
                //domBody[0]["cciqbookcode"] = ""; //手册号，string类型
                //domBody[0]["ibondedsumqty"] = ""; //累计保税处理抽取数量，string类型
                //domBody[0]["copdesc"] = ""; //工序说明，string类型
                //domBody[0]["cmworkcentercode"] = ""; //工作中心编码，string类型
                //domBody[0]["cmworkcenter"] = ""; //工作中心，string类型
                //domBody[0]["isotype"] = ""; //需求跟踪方式，int类型
                //domBody[0]["cbaccounter"] = ""; //记账人，string类型
                //domBody[0]["bcosting"] = ""; //是否核算，string类型
                //domBody[0]["isoseq"] = ""; //需求跟踪行号，string类型
                //domBody[0]["imoseq"] = ""; //生产订单行号，string类型
                //domBody[0]["iopseq"] = ""; //工序行号，string类型
                //domBody[0]["cdefine34"] = ""; //表体自定义项13，int类型
                //domBody[0]["cdefine35"] = ""; //表体自定义项14，int类型
                //domBody[0]["cdefine22"] = ""; //表体自定义项1，string类型
                //domBody[0]["cdefine28"] = ""; //表体自定义项7，string类型
                //domBody[0]["cdefine29"] = ""; //表体自定义项8，string类型
                //domBody[0]["cdefine30"] = ""; //表体自定义项9，string类型
                //domBody[0]["cdefine31"] = ""; //表体自定义项10，string类型
                //domBody[0]["cdefine32"] = ""; //表体自定义项11，string类型
                //domBody[0]["cdefine33"] = ""; //表体自定义项12，string类型
                //domBody[0]["cinvdefine4"] = ""; //存货自定义项4，string类型
                //domBody[0]["cinvdefine5"] = ""; //存货自定义项5，string类型
                //domBody[0]["cinvdefine6"] = ""; //存货自定义项6，string类型
                //domBody[0]["cinvdefine7"] = ""; //存货自定义项7，string类型
                //domBody[0]["cinvdefine8"] = ""; //存货自定义项8，string类型
                //domBody[0]["cinvdefine9"] = ""; //存货自定义项9，string类型
                //domBody[0]["cinvdefine10"] = ""; //存货自定义项10，string类型
                //domBody[0]["cinvdefine11"] = ""; //存货自定义项11，string类型
                //domBody[0]["cinvdefine12"] = ""; //存货自定义项12，string类型
                //domBody[0]["cbarcode"] = ""; //条形码，string类型
                //domBody[0]["cdefine23"] = ""; //表体自定义项2，string类型
                //domBody[0]["cdefine24"] = ""; //表体自定义项3，string类型
                //domBody[0]["cdefine25"] = ""; //表体自定义项4，string类型
                //domBody[0]["itrids"] = ""; //特殊单据子表标识，double类型
                //domBody[0]["cdefine26"] = ""; //表体自定义项5，double类型
                //domBody[0]["cdefine27"] = ""; //表体自定义项6，double类型
                //domBody[0]["citemcode"] = ""; //项目编码，string类型
                //domBody[0]["cname"] = ""; //项目，string类型
                //domBody[0]["citem_class"] = ""; //项目大类编码，string类型
                //domBody[0]["citemcname"] = ""; //项目大类名称，string类型

                //给普通参数domPosition赋值。此参数的数据类型为System.Object，此参数按引用传递，表示货位：传空
                broker.AssignNormalValue("domPosition", domPosition);

                //该参数errMsg为OUT型参数，由于其数据类型为System.String，为一般值类型，因此不必传入一个参数变量。在API调用返回时，可以通过GetResult("errMsg")获取其值

                //给普通参数cnnFrom赋值。此参数的数据类型为ADODB.Connection，此参数按引用传递，表示连接对象,如果由调用方控制事务，则需要设置此连接对象，否则传空
                broker.AssignNormalValue("cnnFrom", cnnFrom);

                //该参数VouchId为INOUT型普通参数。此参数的数据类型为System.String，此参数按值传递。在API调用返回时，可以通过GetResult("VouchId")获取其值
                broker.AssignNormalValue("VouchId", VouchId);

                //该参数domMsg为OUT型参数，由于其数据类型为MSXML2.IXMLDOMDocument2，非一般值类型，因此必须传入一个参数变量。在API调用返回时，可以直接使用该参数

                broker.AssignNormalValue("domMsg", domMsg);
                domMsgO = domMsg;

                //给普通参数bCheck赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否控制可用量。
                broker.AssignNormalValue("bCheck", bCheck);

                //给普通参数bBeforCheckStock赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示检查可用量
                broker.AssignNormalValue("bBeforCheckStock", bBeforCheckStock);

                //给普通参数bIsRedVouch赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否红字单据
                broker.AssignNormalValue("bIsRedVouch", bIsRedVouch);

                //给普通参数sAddedState赋值。此参数的数据类型为System.String，此参数按值传递，表示传空字符串
                broker.AssignNormalValue("sAddedState", sAddedState);

                //给普通参数bReMote赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否远程：转入false
                broker.AssignNormalValue("bReMote", bReMote);

                //第六步：调用API
                if (!broker.Invoke())
                {
                    //错误处理
                    Exception apiEx = broker.GetException();
                    if (apiEx != null)
                    {
                        if (apiEx is MomSysException)
                        {
                            MomSysException sysEx = apiEx as MomSysException;
                            WriteLog.Instance.Write("系统异常：" + sysEx.Message);
                            //todo:异常处理
                        }
                        else if (apiEx is MomBizException)
                        {
                            MomBizException bizEx = apiEx as MomBizException;
                            WriteLog.Instance.Write("API异常：" + bizEx.Message);
                            //todo:异常处理
                        }
                        //异常原因
                        String exReason = broker.GetExceptionString();
                        if (exReason.Length != 0)
                        {
                            WriteLog.Instance.Write("异常原因：" + exReason);
                        }
                    }
                    //结束本次调用，释放API资源
                    broker.Release();
                    domMsgO = null;
                    errMsg = apiEx.Message;
                    return false;

                }

                //第七步：获取返回结果

                //获取返回值
                //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值:true:成功,false:失败
                System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

                //获取out/inout参数值

                //获取普通OUT参数errMsg。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String errMsgRet = broker.GetResult("errMsg") as System.String;
                errMsg = errMsgRet;
                //获取普通INOUT参数VouchId。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String VouchIdRet = broker.GetResult("VouchId") as System.String;
                VouchId = VouchIdRet;
                //获取普通OUT参数domMsg。此返回值数据类型为MSXML2.IXMLDOMDocument2，在使用该参数之前，请判断是否为空
                MSXML2.IXMLDOMDocument2 domMsgRet = (MSXML2.IXMLDOMDocument2)broker.GetResult("domMsg");
                domMsgO = domMsgRet;
                //结束本次调用，释放API资源
                broker.Release();
                return result;
            }
            catch (Exception e)
            {
                domMsgO = null;
                errMsg = "提交前发生错误," + e.Message;
                return false;
            }
        }
        #region 材料出库审计
        public bool MaterialOutAudit(System.String saccID,
        System.String sVouchType,
        out System.String errMsg,
        object cnnFromO,
        System.String VouchId,
        out object domMsgO,
        System.Boolean bCheck,
        System.Boolean bBeforCheckStock)
        {
            try
            {
                //MSXML2.IXMLDOMDocument2 DomHead = (MSXML2.IXMLDOMDocument2)DomHeadO;
                //MSXML2.IXMLDOMDocument2 domBody = (MSXML2.IXMLDOMDocument2)domBodyO;
                domMsgO = new MSXML2.DOMDocumentClass();
                MSXML2.IXMLDOMDocument2 domMsg = (MSXML2.IXMLDOMDocument2)domMsgO;
                ADODB.Connection cnnFrom = (ADODB.Connection)cnnFromO;
                //第一步：构造u8login对象并登陆(引用U8API类库中的Interop.U8Login.dll)
                //如果当前环境中有login对象则可以省去第一步
                U8Login.clsLogin u8Login = new U8Login.clsLogin();
                String sSubId = "DP";
                String sAccID = saccID;
                String sYear = "2017";
                String sUserID = "000094";
                String sPassword = "xfliu94";
                String sDate = "2017-03-13";
                String sServer = "192.168.0.3";
                String sSerial = "";
                if (!u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUserID, ref sPassword, ref sDate, ref sServer, ref sSerial))
                {
                    errMsg = "登陆失败，原因：" + u8Login.ShareString;
                    Console.WriteLine(errMsg);
                    Marshal.FinalReleaseComObject(u8Login);
                    domMsgO = null;
                    return false;
                }

                //第二步：构造环境上下文对象，传入login，并按需设置其它上下文参数
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = u8Login;


                //第三步：设置API地址标识(Url)
                //当前API：审核单据的地址标识为：U8API/MaterialOut/Add
                U8ApiAddress myApiAddress = new U8ApiAddress("U8API/MaterialOut/Audit");

                //第四步：构造APIBroker
                U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

                //第五步：API参数赋值

                //给普通参数sVouchType赋值。此参数的数据类型为System.String，此参数按值传递，表示单据类型：10

                broker.AssignNormalValue("sVouchType", sVouchType);

                //给BO表头参数DomHead赋值，此BO参数的业务类型为产成品入库单，属表头参数。BO参数均按引用传递
                //提示：给BO表头参数DomHead赋值有两种方法

                //DomHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
                ////给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
                ////以下代码示例只设置第一行值。各字段定义详见API服务接口定义

                ////给BO表体参数domBody赋值，此BO参数的业务类型为产成品入库单，属表体参数。BO参数均按引用传递
                ////提示：给BO表体参数domBody赋值有两种方法

                ////方法一是直接传入MSXML2.DOMDocumentClass对象
                //broker.AssignNormalValue("domBody", domBody);


                //该参数errMsg为OUT型参数，由于其数据类型为System.String，为一般值类型，因此不必传入一个参数变量。在API调用返回时，可以通过GetResult("errMsg")获取其值

                //给普通参数cnnFrom赋值。此参数的数据类型为ADODB.Connection，此参数按引用传递，表示连接对象,如果由调用方控制事务，则需要设置此连接对象，否则传空
                broker.AssignNormalValue("cnnFrom", cnnFrom);

                //该参数VouchId为INOUT型普通参数。此参数的数据类型为System.String，此参数按值传递。在API调用返回时，可以通过GetResult("VouchId")获取其值
                broker.AssignNormalValue("VouchId", VouchId);
                //给普通参数TimeStamp赋值。此参数的数据类型为System.Object，此参数按值传递，表示单据时间戳，用于检查单据是否修改，空串时不检查
                broker.AssignNormalValue("TimeStamp", "");
                //该参数domMsg为OUT型参数，由于其数据类型为MSXML2.IXMLDOMDocument2，非一般值类型，因此必须传入一个参数变量。在API调用返回时，可以直接使用该参数

                broker.AssignNormalValue("domMsg", domMsg);
                domMsgO = domMsg;

                //给普通参数bCheck赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否控制可用量。
                broker.AssignNormalValue("bCheck", bCheck);

                //给普通参数bBeforCheckStock赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示检查可用量
                broker.AssignNormalValue("bBeforCheckStock", bBeforCheckStock);

                //给普通参数bList赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示传入空串
                broker.AssignNormalValue("bList", new System.Boolean());

                //给普通参数MakeWheres赋值。此参数的数据类型为VBA.Collection，此参数按值传递，表示传空
                //VBA.Collection MakeWheres = new VBA.Collection();
                //broker.AssignNormalValue("MakeWheres",MakeWheres);

                //给普通参数sWebXml赋值。此参数的数据类型为System.String，此参数按值传递，表示传入空串
                broker.AssignNormalValue("sWebXml", "");
                //Scripting.IDictionary oGenVouchids = new Scripting.Dictionary();
                //给普通参数oGenVouchIds赋值。此参数的数据类型为Scripting.IDictionary，此参数按值传递，表示返回审核时自动生成的单据的id列表,传空
                //broker.AssignNormalValue("oGenVouchIds", oGenVouchids);



                //第六步：调用API
                if (!broker.Invoke())
                {
                    //错误处理
                    Exception apiEx = broker.GetException();
                    if (apiEx != null)
                    {
                        if (apiEx is MomSysException)
                        {
                            MomSysException sysEx = apiEx as MomSysException;
                            Console.WriteLine("系统异常：" + sysEx.Message);
                            //todo:异常处理
                        }
                        else if (apiEx is MomBizException)
                        {
                            MomBizException bizEx = apiEx as MomBizException;
                            Console.WriteLine("API异常：" + bizEx.Message);
                            //todo:异常处理
                        }
                        //异常原因
                        String exReason = broker.GetExceptionString();
                        if (exReason.Length != 0)
                        {
                            Console.WriteLine("异常原因：" + exReason);
                        }
                    }
                    //结束本次调用，释放API资源
                    broker.Release();
                    domMsgO = null;
                    errMsg = apiEx.Message;
                    return false;

                }

                //第七步：获取返回结果

                //获取返回值
                //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值:true:成功,false:失败
                System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

                //获取out/inout参数值

                //获取普通OUT参数errMsg。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String errMsgRet = broker.GetResult("errMsg") as System.String;
                errMsg = errMsgRet;
                //获取普通INOUT参数VouchId。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
                System.String VouchIdRet = broker.GetResult("VouchId") as System.String;
                VouchId = VouchIdRet;
                //获取普通OUT参数domMsg。此返回值数据类型为MSXML2.IXMLDOMDocument2，在使用该参数之前，请判断是否为空
                MSXML2.IXMLDOMDocument2 domMsgRet = (MSXML2.IXMLDOMDocument2)broker.GetResult("domMsg");
                domMsgO = domMsgRet;
                //结束本次调用，释放API资源
                broker.Release();
                return result;
            }
            catch (Exception e)
            {
                domMsgO = null;
                errMsg = "web服务错误：" + e.Message;
                return false;
            }
        }
        #endregion

        void setBusinessObject(ref BusinessObject bo, string xmlStr)
        {
            DataSet ds = new DataSet();
            try
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;      
                //读取字符串中的信息  
                StrStream = new StringReader(xmlStr);
                //获取StrStream中的数据  
                Xmlrdr = new XmlTextReader(StrStream);
                //ds获取Xmlrdr中的数据                  
                ds.ReadXml(Xmlrdr);

                bo.RowCount = ds.Tables[0].Rows.Count;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        if (ds.Tables[0].Rows[i][j] != null)
                            bo[i][ds.Tables[0].Columns[j].ColumnName] = ds.Tables[0].Rows[i][ds.Tables[0].Columns[j].ColumnName].ToString();
                        else
                            bo[i][ds.Tables[0].Columns[j].ColumnName] = "";
                    }
                }
            }
            catch(Exception e)
            {
                if (ds.Tables.Count > 1)
                {
                    throw new Exception(e.Message + ",重复节点：" + ds.Tables[1].ToString());
                }
                else
                    throw e;
            }
        }
    }
}
