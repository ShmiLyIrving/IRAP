using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Collections;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystem;
using IRAP.Entities.MES;
using IRAP.Entity.MES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmProductPackage : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string caption = "";

        //包装箱对应内存表
        private DataTable dtBox = null;
        private DataTable dtBoxLayer = null;
        private DataTable dtCarton = null;
        private DataTable dtCartonLayer = null;
        private DataTable dtPallet = null;
        private DataTable dtPalletLayer = null;
        private List<DataTable> palletUnitTables = null;
        /// <summary>
        /// 包装规格下拉列表对应内存表
        /// </summary>
        private DataTable dtPackageTypes = null;
        private PackageType objPackageType = null;
        private List<PackageType> packageTypeList = new List<PackageType>();
        private int allBoxNum = 0;
        private int allNumCartonsInPallet = 0;
        private long transactNo = 0;
        private TextEdit ft;

        public frmProductPackage()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System information";
            else
                caption = "系统信息";
        }

        #region 自定义函数
        private void EditFocused(object sender, EventArgs e)
        {
            ft = sender as TextEdit;
        }

        /// <summary>
        /// 初始化 GridView
        /// </summary>
        private void InitGridView()
        {
            dgvBoxLayer.AutoGenerateColumns = false;
            dgvBox.AutoGenerateColumns = true;
            dgvCarton.AutoGenerateColumns = true;
            dgvCartonLayer.AutoGenerateColumns = false;
            dgvPalletLayer.AutoGenerateColumns = false;
            dgvPallet.AutoGenerateColumns = true;
        }

        /// <summary>
        /// 初始化点击包装开始按钮时相应控件的状态
        /// </summary>
        /// <param name="btnPackageStartEnable"></param>
        private void InitPackageStart(bool btnPackageStartEnable)
        {
            edtProductSN.Text = "";
            edtBoxSN.Text = "";
            edtCartonSN.Text = "";
            edtPalletLayerSN.Text = "";

            edtProductSN.Properties.ReadOnly = btnPackageStartEnable;
            edtBoxSN.Properties.ReadOnly = true;
            edtCartonSN.Properties.ReadOnly = true;
            edtPalletLayerSN.Properties.ReadOnly = true;

            dgvBox.DataSource = null;
            dgvBoxLayer.DataSource = null;
            dgvCarton.DataSource = null;
            dgvCartonLayer.DataSource = null;
            dgvPallet.DataSource = null;
            dgvPalletLayer.DataSource = null;

            btnRePrint.Enabled = false;
            btnPackageStart.Enabled = btnPackageStartEnable;

            chkAllowRePrint.Checked = false;
            chkStorePackage.Checked = !btnPackageStartEnable;
        }

        /// <summary>
        /// 批量更新包装信息内存表
        /// </summary>
        private void BatchUpdateMemTable(
            int palletUnitIndex,
            string fileName, 
            string fileValue)
        {
            for (int r = 0; r < allBoxNum; r++)
            {
                palletUnitTables[palletUnitIndex].Rows[r][fileName] = fileValue;
            }
        }

        /// <summary>
        /// 初始化包装
        /// </summary>
        private void InitPackageLocation()
        {
            allNumCartonsInPallet = 
                objPackageType.NumLayersOfPallet * 
                objPackageType.NumCartonsPerLayerOfPallet;
            if (objPackageType.T117LabelID_Pallet == 0 || 
                objPackageType.NumLayersOfPallet == 0)
            {
                // 默认为1，虽然实际情况可能存在不需要托，但是为了方便界面处理，所以
                // 最小值设定为1。但是托层必须隐藏，处理页面操作时要注意判断下
                // T117LabelID_Pallet 的值,以做相应的处理 。 
                objPackageType.NumLayersOfPallet = 1;
                objPackageType.NumCartonsPerLayerOfPallet = 1;
                allNumCartonsInPallet = 1;
            }

            allBoxNum =
                objPackageType.NumLayersOfCarton * 
                objPackageType.NumBoxPerColOfCarton * 
                objPackageType.NumBoxPerRowOfCarton *
                objPackageType.NumLayersOfBox * 
                objPackageType.QtyPerColOfBox * 
                objPackageType.QtyPerRowOfBox;
            palletUnitTables = new List<DataTable>();
            for (int i = 0; i < allNumCartonsInPallet; i++)
            {
                DataTable dt = CreatePackageInfoMemberTable();
                palletUnitTables.Add(dt);
            }

            //获取未完成包装信息  
            string palletSN = "";
            UncompletedPackage uncompletedPackage = GetUncompletedPackage();
            //有未完成箱包装
            if (uncompletedPackage != null)
            {
                transactNo = uncompletedPackage.TransactNo;
                if (transactNo == 0 &&
                    string.IsNullOrEmpty(uncompletedPackage.PalletSerialNumber))
                {
                    if (objPackageType.T117LabelID_Pallet > 0)
                    {
                        //申请托序列号
                        palletSN = GetNextPackageSN("PLT");
                    }
                }
                else
                {
                    List<FactPackaging> packageList = 
                        GetFactList_Packaging(
                            uncompletedPackage.TransactNo,
                            Options.SelectProduct.T102LeafID);
                    if (packageList != null)
                    {
                        int maxPalletUnitIndex = 0;
                        int maxOrdinal = 0;
                        foreach (FactPackaging fact in packageList)
                        {
                            Int64 factNo = fact.FactID;
                            int layerIdxOfPallet = fact.LayerIdxOfPallet; //铲板第几层
                            int cartonIdxOfLayer = fact.CartonIdxOfLayer; //当前层第几箱

                            int layerIdxOfCarton = fact.LayerIdxOfCarton; //箱内第几层内包装(盒）
                            int rowIdxOfCarton = fact.RowIdxOfCarton; //箱内第几排内包装(盒)
                            int colIdxOfCarton = fact.ColIdxOfCarton; //箱内第几列内包装(盒)

                            int layerIdxOfBox = fact.LayerIdxOfBox;  //盒内第几层产品
                            int rowIdxOfBox = fact.RowIdxOfBox; //盒内第几排产品
                            int colIdxOfBox = fact.ColIdxOfBox; //盒内第几列产品

                            string wipCode = fact.WIPCode;  //产品主标识代码
                            string altWIPCode = fact.AltWIPCode; //产品副标识代码
                            string serialNumber = fact.SerialNumber; //产品序列号

                            string boxSerialNumbe = fact.BoxSerialNumber;    //内包装序列号
                            string cartonSerialNumber = fact.CartonSerialNumber; //箱包装序列号
                            string layerSerialNumber = fact.LayerSerialNumber;  //包装托层序列号
                            string palletSerialNumber = fact.PalletSerialNumber; //铲板标签序列号

                            int palletUnitIndex = (layerIdxOfPallet - 1) * objPackageType.NumLayersOfPallet + cartonIdxOfLayer - 1;
                            int ordinal = 
                                GetBoxIndex(
                                    layerIdxOfCarton, 
                                    rowIdxOfCarton, 
                                    colIdxOfCarton,
                                    layerIdxOfBox, 
                                    rowIdxOfBox, 
                                    colIdxOfBox);

                            palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["FactNo"] = factNo;
                            palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["ProductSN"] = serialNumber == string.Empty ? wipCode == string.Empty ? altWIPCode : wipCode : serialNumber;
                            palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["BoxPackageSN"] = boxSerialNumbe;
                            palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["CartonPackageSN"] = cartonSerialNumber;
                            palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["PalletLayerSN"] = layerSerialNumber;
                            palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["PalletPackageSN"] = palletSerialNumber;
                            palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["Do"] = 2;

                            if (ordinal > maxOrdinal)
                            {
                                maxOrdinal = ordinal;
                                maxPalletUnitIndex = palletUnitIndex;
                            }
                        }
                        if (palletUnitTables[maxPalletUnitIndex].Rows.Count > maxOrdinal)
                        {
                            palletUnitTables[maxPalletUnitIndex].Rows[maxOrdinal]["Do"] = 1;
                        }
                    }
                }
            }
            if (objPackageType.T117LabelID_Pallet > 0)
            {
                for (int i = 0; i < allNumCartonsInPallet; i++)
                {
                    BatchUpdateMemTable(i, "PalletPackageSN", palletSN);
                    int layer = i / objPackageType.NumLayersOfPallet + 1;
                    string palletLayerSN = palletSN + layer.ToString();
                    BatchUpdateMemTable(i, "PalletLayerSN", palletSN);
                }
            }
            //初始显示的标签
            edtBoxSN.Text = palletUnitTables[0].Rows[0]["BoxPackageSN"].ToString();
            edtCartonSN.Text = palletUnitTables[0].Rows[0]["CartonPackageSN"].ToString();
            edtPalletLayerSN.Text = palletUnitTables[0].Rows[0]["PalletLayerSN"].ToString();
            //注意顺序
            if (transactNo == 0)
            {
                //当没有未完成包装时
                GenerateBox(0, 1, 1, 1, 1);
                GenerateBoxLayer(0, 1, 1, 1, 1);
                GenerateCarton(0, 1, 1, 1);
                GenerateCartonLayer(0);
                GeneratePallet(1);
                GeneratePalletLayer();
            }
            else
            {
                //当有未完成包装时
                InitHadFinishPackage();
            }

        }

        /// <summary>
        /// 初始化未完成包装
        /// </summary>
        private void InitHadFinishPackage()
        {
            int palletUnitIndex = -1;
            for (int i = 0; i < allNumCartonsInPallet; i++)
            {
                if (palletUnitTables[i].Rows[0]["Do"].ToString() != "2" &&
                    palletUnitTables[i].Rows[allBoxNum - 1]["Do"].ToString() != "2")
                {
                    palletUnitIndex = i;
                    break;
                }
                if (palletUnitTables[i].Rows[0]["Do"].ToString() == "2" &&
                    palletUnitTables[i].Rows[allBoxNum - 1]["Do"].ToString() != "2")
                {
                    palletUnitIndex = i;
                    break;
                }
            }
            if (palletUnitIndex == -1) return;
            int currentPalletLayer = (palletUnitIndex / objPackageType.NumCartonsPerLayerOfPallet) + 1;
            int currentPalletCol = palletUnitIndex + 1 - (currentPalletLayer - 1) * objPackageType.NumCartonsPerLayerOfPallet;

            for (int i = 0; i < allBoxNum; i++)
            {
                string doStatus = palletUnitTables[palletUnitIndex].Rows[i]["Do"].ToString();
                if (doStatus == "1")
                {
                    int ordinal = i + 1;
                    int cartonLayer, cartonRow, cartonCol, boxLayer, boxRow, boxCol;

                    SetBoxOrdinal(
                        ordinal,
                        out cartonLayer, 
                        out cartonRow, 
                        out cartonCol,
                        out boxLayer, 
                        out boxRow, 
                        out boxCol);

                    GenerateBox(palletUnitIndex, cartonLayer, cartonRow, cartonCol, boxLayer);
                    GenerateBoxLayer(palletUnitIndex, cartonLayer, cartonRow, cartonCol, boxLayer);
                    GenerateCarton(palletUnitIndex, cartonLayer, cartonRow, cartonCol);
                    GenerateCartonLayer(palletUnitIndex);

                    break;
                }
            }
        }

        /// <summary>
        /// 获取大包装和小包装的序号对应的坐标
        /// </summary>
        private void SetBoxOrdinal(
            int ordinal, 
            out int cartonLayer, 
            out int cartonRow, 
            out int cartonCol,
            out int boxLayer, 
            out int boxRow, 
            out int boxCol)
        {
            int smallTemp;
            int FPalletLayers = objPackageType.NumLayersOfPallet;
            int FPalletCols = objPackageType.NumCartonsPerLayerOfPallet;
            int FLargeLayers = objPackageType.NumLayersOfCarton;
            int FLargeRows = objPackageType.NumBoxPerColOfCarton;
            int FLargeCols = objPackageType.NumBoxPerRowOfCarton;
            int FSmallLayers = objPackageType.NumLayersOfBox;
            int FSmallRows = objPackageType.QtyPerColOfBox;
            int FSmallCols = objPackageType.QtyPerRowOfBox;

            //大包装    
            int totalSLBoxNum = 
                FLargeLayers * 
                FLargeRows * 
                FLargeCols * 
                FSmallLayers *
                FSmallRows * 
                FSmallCols;
            cartonLayer = 
                1 + 
                (ordinal - 1) / 
                (totalSLBoxNum / FLargeLayers);

            cartonRow = ordinal - (cartonLayer - 1) * totalSLBoxNum / FLargeLayers;
            cartonRow = (cartonRow - 1) / (FLargeCols * FSmallLayers * FSmallRows * FSmallCols) + 1;
            cartonCol = 
                ordinal - 
                (cartonLayer - 1) * 
                totalSLBoxNum / 
                FLargeLayers - 
                (cartonRow - 1) * 
                FLargeCols * 
                FSmallLayers * 
                FSmallRows * 
                FSmallCols;
            cartonCol = (cartonCol - 1) / (FSmallLayers * FSmallRows * FSmallCols) + 1;

            //小包装 
            smallTemp = (ordinal - 1) % (FSmallLayers * FSmallRows * FSmallCols) + 1;
            boxLayer = 1 + (smallTemp - 1) / FSmallRows / FSmallCols;
            boxRow = smallTemp - (boxLayer - 1) * FSmallRows * FSmallCols;
            boxRow = (boxRow - 1) / FSmallCols + 1;
            boxCol = (ordinal - 1) % FSmallCols + 1;
        }

        /// <summary>
        /// 获取大包装和小包装和托的序号对应的坐标
        /// </summary>
        private void SetBoxOrdinal(
            int ordinal,
            out int palletLayer, 
            out int palletRow, 
            out int palletCol,
            out int cartonLayer, 
            out int cartonRow, 
            out int cartonCol,
            out int boxLayer, 
            out int boxRow, 
            out int boxCol)
        {
            int smallTemp, totalBoxNum;
            int fPalletLayers = objPackageType.NumLayersOfPallet;
            int fPalletRows = 1;
            int fPalletCols = objPackageType.NumCartonsPerLayerOfPallet;
            int fLargeLayers = objPackageType.NumLayersOfCarton;
            int fLargeRows = objPackageType.NumBoxPerColOfCarton;
            int fLargeCols = objPackageType.NumBoxPerRowOfCarton;
            int fSmallLayers = objPackageType.NumLayersOfBox;
            int fSmallRows = objPackageType.QtyPerColOfBox;
            int fSmallCols = objPackageType.QtyPerRowOfBox;

            //托
            totalBoxNum = 
                fPalletLayers * 
                fPalletRows * 
                fPalletCols * 
                fLargeLayers * 
                fLargeRows * 
                fLargeCols * 
                fSmallLayers * 
                fSmallRows * 
                fSmallCols;
            palletLayer = 1 + (ordinal - 1) / (totalBoxNum / fPalletLayers);
            palletRow = 1; //托行数量固定为1
            palletCol = ordinal - (palletLayer - 1) * totalBoxNum / fLargeLayers;
            palletCol = 
                (palletCol - 1) / 
                (fLargeLayers * fLargeRows * fLargeCols * fSmallLayers * fSmallRows * fSmallCols) + 
                1;

            //大包装   
            int totalSLBoxNum = fLargeLayers * fLargeRows * fLargeCols * fSmallLayers *
                fSmallRows * fSmallCols;
            cartonLayer = 1 + (ordinal - 1) / (totalSLBoxNum / fLargeLayers);

            cartonRow = ordinal - (cartonLayer - 1) * totalSLBoxNum / fLargeLayers;
            cartonRow = (cartonRow - 1) / (fLargeCols * fSmallLayers * fSmallRows * fSmallCols) + 1;
            cartonCol = 
                ordinal - 
                (cartonLayer - 1) * 
                totalSLBoxNum / 
                fLargeLayers - 
                (cartonRow - 1) * 
                fLargeCols * 
                fSmallLayers * 
                fSmallRows * 
                fSmallCols;
            cartonCol = (cartonCol - 1) / (fSmallLayers * fSmallRows * fSmallCols) + 1;

            //小包装 
            smallTemp = (ordinal - 1) % (fSmallLayers * fSmallRows * fSmallCols) + 1;
            boxLayer = 1 + (smallTemp - 1) / fSmallRows / fSmallCols;
            boxRow = smallTemp - (boxLayer - 1) * fSmallRows * fSmallCols;
            boxRow = (boxRow - 1) / fSmallCols + 1;
            boxCol = (ordinal - 1) % fSmallCols + 1;
        }

        /// <summary>
        /// 通过坐标获取对应的大包装和小包装的序号
        /// </summary>
        private int GetBoxIndex(
            int palletLayer, 
            int palletRow, 
            int palletCol,
            int cartonLayer, 
            int cartonRow, 
            int cartonCol,
            int boxLayer, 
            int boxRow, 
            int boxCol)
        {
            int ordinal =
                (palletLayer - 1) *
                (1 * objPackageType.NumCartonsPerLayerOfPallet) *
                (objPackageType.NumLayersOfCarton *
                    objPackageType.NumBoxPerRowOfCarton *
                    objPackageType.NumBoxPerColOfCarton) *
                (objPackageType.NumLayersOfBox *
                    objPackageType.QtyPerRowOfBox *
                    objPackageType.QtyPerColOfBox) +
                (palletRow - 1) *
                objPackageType.NumCartonsPerLayerOfPallet *
                (objPackageType.NumLayersOfCarton *
                    objPackageType.NumBoxPerRowOfCarton *
                    objPackageType.NumBoxPerColOfCarton) *
                (objPackageType.NumLayersOfBox *
                    objPackageType.QtyPerRowOfBox *
                    objPackageType.QtyPerColOfBox) +
                (palletCol - 1) *
                (objPackageType.NumLayersOfCarton *
                    objPackageType.NumBoxPerRowOfCarton *
                    objPackageType.NumBoxPerColOfCarton) *
                (objPackageType.NumLayersOfBox *
                    objPackageType.QtyPerRowOfBox *
                    objPackageType.QtyPerColOfBox) +
                (cartonLayer - 1) *
                (objPackageType.NumBoxPerRowOfCarton *
                    objPackageType.NumBoxPerColOfCarton) *
                (objPackageType.NumLayersOfBox *
                    objPackageType.QtyPerRowOfBox *
                    objPackageType.QtyPerColOfBox) +
                (cartonRow - 1) *
                objPackageType.NumBoxPerRowOfCarton *
                (objPackageType.NumLayersOfBox *
                    objPackageType.QtyPerColOfBox *
                    objPackageType.QtyPerRowOfBox) +
                (cartonCol - 1) *
                (objPackageType.NumLayersOfBox *
                    objPackageType.QtyPerRowOfBox *
                    objPackageType.QtyPerColOfBox) +
                (boxLayer - 1) *
                (objPackageType.QtyPerRowOfBox *
                    objPackageType.QtyPerColOfBox) +
                (boxRow - 1) *
                objPackageType.QtyPerRowOfBox +
                boxCol;
            return ordinal;
        }

        /// <summary>
        /// 通过坐标获取对应的大包装和小包装和托的序号
        /// </summary>
        private int GetBoxIndex(
            int cartonLayer, 
            int cartonRow, 
            int cartonCol,  
            int boxLayer, 
            int boxRow, 
            int boxCol)
        {
            int ordinal =
                (cartonLayer - 1) *
                (objPackageType.NumBoxPerRowOfCarton *
                    objPackageType.NumBoxPerColOfCarton) *
                (objPackageType.NumLayersOfBox *
                    objPackageType.QtyPerRowOfBox *
                    objPackageType.QtyPerColOfBox) +
                (cartonRow - 1) *
                objPackageType.NumBoxPerRowOfCarton *
                (objPackageType.NumLayersOfBox *
                    objPackageType.QtyPerColOfBox *
                    objPackageType.QtyPerRowOfBox) +
                (cartonCol - 1) *
                (objPackageType.NumLayersOfBox *
                    objPackageType.QtyPerRowOfBox *
                    objPackageType.QtyPerColOfBox) +
                (boxLayer - 1) *
                (objPackageType.QtyPerRowOfBox *
                    objPackageType.QtyPerColOfBox) +
                (boxRow - 1) *
                objPackageType.QtyPerRowOfBox +
                boxCol;
            return ordinal;
        }

        /// <summary>
        /// 创建包装箱内存表
        /// </summary>
        private DataTable CreatePackageInfoMemberTable()
        {
            DataTable dtTempPackageInfo = new DataTable();
            dtTempPackageInfo.Columns.Add("Ordinal", typeof(int));
            dtTempPackageInfo.Columns.Add("TransactNo", typeof(long));
            dtTempPackageInfo.Columns.Add("FactNo", typeof(long));
            dtTempPackageInfo.Columns.Add("ProductSN", typeof(string));  // 每个小Box对应的产品标签 
            dtTempPackageInfo.Columns.Add("BoxPackageSN", typeof(string));  // 小包装箱标签
            dtTempPackageInfo.Columns.Add("CartonPackageSN", typeof(string));  // 大包装箱标签
            dtTempPackageInfo.Columns.Add("PalletLayerSN", typeof(string));  // 托每层标签
            dtTempPackageInfo.Columns.Add("PalletPackageSN", typeof(string));  // 托包装标签
            dtTempPackageInfo.Columns.Add("Do", typeof(int));  // 小Box状态：0-未包装；1-正在包装；2-已包装
            dtTempPackageInfo.Columns.Add("CartonLayer", typeof(int));
            dtTempPackageInfo.Columns.Add("CartonRow", typeof(int));
            dtTempPackageInfo.Columns.Add("CartonCol", typeof(int));
            dtTempPackageInfo.Columns.Add("BoxLayer", typeof(int));
            dtTempPackageInfo.Columns.Add("BoxRow", typeof(int));
            dtTempPackageInfo.Columns.Add("BoxCol", typeof(int));

            int cartonLayerSet, cartonRowSet, cartonColSet,
                boxLayerSet, boxRowSet, boxColSet;
            for (int i = 0; i < allBoxNum; i++)
            {
                int ordinal = i + 1;
                SetBoxOrdinal(ordinal,
                out cartonLayerSet, out cartonRowSet, out cartonColSet,
                out boxLayerSet, out boxRowSet, out boxColSet);

                DataRow dr = dtTempPackageInfo.NewRow();

                dr["Ordinal"] = i + 1;
                dr["TransactNo"] = 0;
                dr["FactNo"] = 0;
                dr["ProductSN"] = "";
                dr["BoxPackageSN"] = "";
                dr["CartonPackageSN"] = "";
                dr["PalletLayerSN"] = "";
                dr["PalletPackageSN"] = "";
                dr["Do"] = 0;
                dr["CartonLayer"] = cartonLayerSet;
                dr["CartonRow"] = cartonRowSet;
                dr["CartonCol"] = cartonColSet;
                dr["BoxLayer"] = boxLayerSet;
                dr["BoxRow"] = boxRowSet;
                dr["BoxCol"] = boxColSet;
                dtTempPackageInfo.Rows.Add(dr);
            }
            dtTempPackageInfo.Rows[0]["Do"] = 1;

            return dtTempPackageInfo;
        }

        /// <summary>
        /// 生成托层
        /// </summary>
        private void GeneratePalletLayer()
        {
            try
            {
                dtPalletLayer = new DataTable();
                dtPalletLayer.Columns.Add("PalletLayer", typeof(string));
                int layerCount = objPackageType.NumLayersOfPallet;
                for (int i = 0; i < layerCount; i++)
                {
                    DataRow dr = dtPalletLayer.NewRow();
                    dr[0] = string.Format("{0}L", i + 1);
                    dtPalletLayer.Rows.Add(dr);
                }
                dgvPalletLayer.RowTemplate.Height = dgvPalletLayer.Height / layerCount;
                dgvPalletLayer.DataSource = dtPalletLayer;
                for (int i = 0; i < layerCount; i++)
                {
                    int palletLayer = i + 1;
                    Color color = GetPalletLayerColor(palletLayer);
                    dgvPalletLayer.Rows[i].Cells[0].Style.BackColor = color;
                    dgvPalletLayer.Rows[i].Cells[0].Style.SelectionBackColor = color;
                    if (color == Color.Blue) dgvPalletLayer.Rows[i].Cells[0].Selected = true;
                }
                dgvPalletLayer.Rows[layerCount - 1].Height = dgvPalletLayer.Height / layerCount - 3;

            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    string.Format(
                        "生成托层时发生异常：{0}",
                        error.Message), 
                    caption,
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 生成托列
        /// </summary>
        private void GeneratePallet(int palletLayer)
        {
            try
            {
                int colCount = objPackageType.NumCartonsPerLayerOfPallet;
                dtPallet = new DataTable();
                for (int i = 0; i < colCount; i++)
                {
                    dtPallet.Columns.Add("Pallet" + i.ToString(), typeof(string));
                }
                DataRow dr = dtPallet.NewRow();
                for (int i = 0; i < colCount; i++)
                {
                    dr[i] = (i + 1).ToString();
                }
                dtPallet.Rows.Add(dr);
                int rowsCount = 1;
                dgvPallet.RowTemplate.Height = dgvPallet.Height / rowsCount;
                dgvPallet.DataSource = dtPallet;
                for (int j = 0; j < dgvPallet.Columns.Count; j++)
                {
                    int palletCol = j + 1;
                    Color color = GetPalletColor(palletLayer, palletCol);
                    dgvPallet.Rows[0].Cells[j].Style.BackColor = color;
                    dgvPallet.Rows[0].Cells[j].Style.SelectionBackColor = color;
                    if (color == Color.Blue) dgvPallet.Rows[0].Cells[j].Selected = true;
                }
                dgvPallet.Rows[rowsCount - 1].Height = dgvPalletLayer.Height / rowsCount - 3;
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    string.Format(
                        "生成托列时发生异常：{0}",
                        error.Message),
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 生成大包装层
        /// </summary>
        private void GenerateCartonLayer(int palletUnitIndex)
        {
            try
            {
                dtCartonLayer = new DataTable();
                dtCartonLayer.Columns.Add("CartonLayer", typeof(string));
                int layerCount = objPackageType.NumLayersOfCarton;
                for (int i = 0; i < layerCount; i++)
                {
                    DataRow dr = dtCartonLayer.NewRow();
                    dr[0] = string.Format("{0}L", i + 1);
                    dtCartonLayer.Rows.Add(dr);
                }
                dgvCartonLayer.RowTemplate.Height = dgvCartonLayer.Height / layerCount;
                dgvCartonLayer.DataSource = dtCartonLayer;
                for (int i = 0; i < layerCount; i++)
                {
                    int cartonLayer = i + 1;
                    Color color = GetCartonLayerColor(palletUnitIndex, cartonLayer, 1, 1, 1, 1, 1);
                    dgvCartonLayer.Rows[i].Cells[0].Style.BackColor = color;
                    dgvCartonLayer.Rows[i].Cells[0].Style.SelectionBackColor = color;
                    if (color == Color.Blue) dgvCartonLayer.Rows[i].Cells[0].Selected = true;
                }
                dgvCartonLayer.Rows[layerCount - 1].Height = dgvCartonLayer.Height / layerCount - 3;
                //dgvCartonLayer.ClearSelection();
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    string.Format(
                        "生成大包装层发生异常：{0}",
                        error.Message), 
                    caption,
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 生成大包装行列
        /// </summary>
        private void GenerateCarton(
            int palletUnitIndex, 
            int cartonLayer, 
            int focusCartonRow, 
            int focusCartonCol)
        {
            try
            {
                dtCarton = new DataTable();
                int colCount = objPackageType.NumBoxPerRowOfCarton;
                for (int i = 0; i < colCount; i++)
                {
                    dtCarton.Columns.Add("Carton" + i.ToString(), typeof(string));
                }
                int rowCount = objPackageType.NumBoxPerColOfCarton;
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow dr = dtCarton.NewRow();
                    for (int j = 0; j < colCount; j++)
                    {
                        dr[j] = (i * 2 + j + 1).ToString();
                    }
                    dtCarton.Rows.Add(dr);
                }
                dgvCarton.RowTemplate.Height = dgvCarton.Height / rowCount;
                dgvCarton.DataSource = dtCarton;
                dgvCarton.Rows[rowCount - 1].Height = dgvCarton.Height / rowCount - 3;
                for (int i = 0; i < dgvCarton.Rows.Count; i++)
                {
                    int cartonRow = i + 1;
                    for (int j = 0; j < dgvCarton.ColumnCount; j++)
                    {
                        int cartonCol = j + 1;
                        Color color = GetCartonColor(palletUnitIndex, cartonLayer, cartonRow, cartonCol, 1, 1, 1);
                        dgvCarton.Rows[i].Cells[j].Style.BackColor = color;
                        dgvCarton.Rows[i].Cells[j].Style.SelectionBackColor = color;
                    }
                }
                dgvCarton.Rows[focusCartonRow - 1].Cells[focusCartonCol - 1].Selected = true;
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    string.Format(
                        "生成大包装行列发生异常：{0}",
                        error.Message), 
                    caption,
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 生产小包装层
        /// </summary>
        private void GenerateBoxLayer(
            int palletUnitIndex, 
            int cartonLayer, 
            int cartonRow, 
            int cartonCol, 
            int focusBoxLayer)
        {
            try
            {
                dtBoxLayer = new DataTable();
                dtBoxLayer.Columns.Add("BoxLayer", typeof(string));

                //设置每个单元格显示的内容
                int layerCount = objPackageType.NumLayersOfBox;
                for (int i = 0; i < layerCount; i++)
                {
                    DataRow dr = dtBoxLayer.NewRow();
                    dr[0] = string.Format("{0}L", i + 1);
                    dtBoxLayer.Rows.Add(dr);
                }
                
                //设置单元格高度，使单元格总高度等于表格的高度
                dgvBoxLayer.RowTemplate.Height = dgvBoxLayer.Height / layerCount;
                dgvBoxLayer.DataSource = dtBoxLayer;
                
                //设置每个单元格显示的背景颜色
                for (int i = 0; i < dgvBoxLayer.Rows.Count; i++)
                {
                    int boxLayer = i + 1;
                    Color color = GetBoxLayerColor(palletUnitIndex,
                        cartonLayer, cartonRow, cartonCol, boxLayer, 1, 1);
                    dgvBoxLayer.Rows[i].Cells[0].Style.BackColor = color;
                    dgvBoxLayer.Rows[i].Cells[0].Style.SelectionBackColor = color;
                }
                
                //调整最后一行的高度
                dgvBoxLayer.Rows[layerCount - 1].Height = dgvBoxLayer.Height / layerCount - 3;
                //
                dgvBoxLayer.Rows[focusBoxLayer - 1].Cells[0].Selected = true;
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    string.Format(
                        "生成小包装层时发生异常：{0}",
                        error.Message),
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 生成小包装行列
        /// </summary> 
        /// <param name="cartonLayer">大包装层坐标</param>
        /// <param name="cartonRow">大包装行坐标</param>
        /// <param name="cartonCol">大包装列坐标</param>
        /// <param name="boxLayer">小包装层坐标</param> 
        private void GenerateBox(
            int palletUnitIndex,
            int cartonLayer, 
            int cartonRow, 
            int cartonCol,
            int boxLayer)
        {
            try
            {
                dtBox = new DataTable();
                int colCount = objPackageType.QtyPerRowOfBox;
                for (int i = 0; i < colCount; i++)
                {
                    dtBox.Columns.Add("Box" + i.ToString(), typeof(string));
                }
                int rowCount = objPackageType.QtyPerColOfBox;
                int ordinal = 0;
            
                //设置每个单元格显示的序号
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow dr = dtBox.NewRow();
                    for (int j = 0; j < colCount; j++)
                    {
                        int boxRow = i + 1;
                        int boxCol = j + 1;
                        ordinal = GetBoxIndex(cartonLayer,
                            cartonRow, cartonCol, boxLayer, boxRow, boxCol);
                        dr[j] = ordinal;
                    }
                    dtBox.Rows.Add(dr);
                }
                
                //设置单元格高度，使之正好能填满整个表格
                dgvBox.RowTemplate.Height = dgvBoxLayer.Height / rowCount;
                dgvBox.DataSource = dtBox;
                dgvBox.Rows[rowCount - 1].Height = dgvBoxLayer.Height / rowCount - 3;

                if (palletUnitTables[palletUnitIndex] != null)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int j = 0; j < colCount; j++)
                        {
                            ordinal = int.Parse(dgvBox.Rows[i].Cells[j].Value.ToString());
                            string doStatus = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["Do"].ToString();
                            if (doStatus == "0")
                            {
                                dgvBox.Rows[i].Cells[j].Style.BackColor = Color.White;
                                dgvBox.Rows[i].Cells[j].Style.SelectionBackColor = Color.White;
                            }
                            if (doStatus == "1")
                            {
                                dgvBox.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                                dgvBox.Rows[i].Cells[j].Style.SelectionBackColor = Color.Blue;
                                dgvBox.Rows[i].Cells[j].Selected = true;
                                break;
                            }
                            if (doStatus == "2")
                            {
                                dgvBox.Rows[i].Cells[j].Style.BackColor = Color.Green;
                                dgvBox.Rows[i].Cells[j].Style.SelectionBackColor = Color.Green;
                            }
                        }
                    }
                }
                edtBoxSN.Text = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["BoxPackageSN"].ToString();
                edtCartonSN.Text = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["CartonPackageSN"].ToString();
                edtPalletLayerSN.Text = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["PalletLayerSN"].ToString();
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    string.Format(
                        "生成小包装行列发生异常：{0}",
                        error.Message),
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 通过坐标获取 Pellet 的颜色
        /// </summary>
        private Color GetPalletColor(
            int palletLayer, 
            int palletCol)
        {
            Color color = Color.White;
            int maxPalletCol = objPackageType.NumCartonsPerLayerOfPallet;
            int tempPalletUnitIndex = ((palletLayer - 1) * maxPalletCol + palletCol) - 1;
            int firstDoStatus = 0;
            int.TryParse(palletUnitTables[tempPalletUnitIndex].Rows[0]["Do"].ToString(), out firstDoStatus);
            int lastDoStatus = 0;
            int.TryParse(palletUnitTables[tempPalletUnitIndex].Rows[allBoxNum - 1]["Do"].ToString(), out lastDoStatus);
            switch (lastDoStatus)
            {
                case 0:
                    {
                        if (firstDoStatus == 2) color = Color.Blue;
                        if (firstDoStatus < 2)
                        {
                            if (PalletPrepared(maxPalletCol))
                            {
                                color = Color.White;
                            }
                            else
                            {
                                color = Color.Blue;
                            }
                        }
                    }
                    break;
                case 1:
                    {
                        color = Color.Blue;
                    }
                    break;
                case 2:
                    {
                        color = Color.Green;
                    }
                    break;
                default: color = Color.White; break;
            }
            return color;
        }

        /// <summary>
        /// 获取 PalletLayer 的颜色
        /// </summary>
        private Color GetPalletLayerColor(int palletLayer)
        {
            Color color = Color.White;
            int maxPalletCol = objPackageType.NumCartonsPerLayerOfPallet;
            int maxPalletLayer = objPackageType.NumLayersOfPallet;
            int tempPalletFirstUnitIndex = ((palletLayer - 1) * maxPalletCol + 1) - 1;
            int tempPalletLastUnitIndex = ((palletLayer - 1) * maxPalletCol + maxPalletCol) - 1;
            int firstDoStatus = 0;
            int.TryParse(palletUnitTables[tempPalletFirstUnitIndex].Rows[0]["Do"].ToString(), out firstDoStatus);
            int lastDoStatus = 0;
            int.TryParse(palletUnitTables[tempPalletLastUnitIndex].Rows[allBoxNum - 1]["Do"].ToString(), out lastDoStatus);

            switch (lastDoStatus)
            {
                case 2:
                    {
                        color = Color.Green;
                    }
                    break;
                case 1:
                    {
                        if (!PalletLayerPrepared(maxPalletLayer)) color = Color.Blue;
                    }
                    break;
                case 0:
                    {
                        if (firstDoStatus == 0)
                        {
                            color = Color.White;
                        }
                        else
                        {
                            if (!PalletLayerPrepared(maxPalletLayer)) color = Color.Blue;
                        }
                    }
                    break;
                default: color = Color.White; break;
            }

            return color;
        }

        /// <summary>
        /// 获取 BoxLayer 的颜色
        /// </summary>
        /// <param name="palletUnitIndex"></param>
        /// <param name="cartonLayer"></param>
        /// <param name="cartonRow"></param>
        /// <param name="cartonCol"></param>
        /// <param name="boxLayer"></param>
        /// <param name="boxRow"></param>
        /// <param name="boxCol"></param>
        /// <returns></returns>
        private Color GetBoxLayerColor(
            int palletUnitIndex, 
            int cartonLayer, 
            int cartonRow, 
            int cartonCol,
            int boxLayer, 
            int boxRow, 
            int boxCol)
        {
            Color color = Color.White;
            int ordinal = 0;
            int maxBoxRow = objPackageType.QtyPerColOfBox;
            int maxBoxCol = objPackageType.QtyPerRowOfBox;
            ordinal = GetBoxIndex(cartonLayer, cartonRow, cartonCol,
                boxLayer, maxBoxRow, maxBoxCol);
            int doMaxStatus = 0;
            int.TryParse(palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["Do"].ToString(), out doMaxStatus);
            switch (doMaxStatus)
            {
                case 0:
                    {
                        for (int i = ordinal - maxBoxRow * maxBoxCol + 1; i < ordinal; i++)
                        {
                            if (palletUnitTables[palletUnitIndex].Rows[i - 1]["Do"].ToString() == "1")
                            {
                                color = Color.Blue;
                                break;
                            }
                        }
                    }
                    break;
                case 1: color = Color.Blue; break;
                case 2: color = Color.Green; break;
                default: color = Color.White; break;
            }
            return color;
        }

        /// <summary>
        /// 获取 Carton 的颜色
        /// </summary>
        private Color GetCartonColor(
            int palletUnitIndex, 
            int cartonLayer, 
            int cartonRow, 
            int cartonCol,
            int boxLayer, 
            int boxRow, 
            int boxCol)
        {
            Color color = Color.White;
            int ordinal = 0;
            int doMaxStatus = 0;
            int maxBoxRow = objPackageType.QtyPerColOfBox;
            int maxBoxCol = objPackageType.QtyPerRowOfBox;
            int maxBoxLayer = objPackageType.NumLayersOfBox;
            ordinal = GetBoxIndex(cartonLayer, cartonRow, cartonCol,
                maxBoxLayer, maxBoxRow, maxBoxCol);

            int.TryParse(palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["Do"].ToString(), out doMaxStatus);

            switch (doMaxStatus)
            {
                case 0:
                    {
                        int maxCartonRow = objPackageType.NumBoxPerColOfCarton;
                        int maxCartonCol = objPackageType.NumBoxPerRowOfCarton;
                        if (!BoxLayerPrepared(maxBoxLayer)) break;
                        if (CartonPrepared(maxCartonRow, maxCartonCol)) break;
                        color = Color.Blue;

                    }
                    break;
                case 1: color = Color.Blue; break;
                case 2: color = Color.Green; break;
                default: color = Color.White; break;
            }
            return color;
        }

        /// <summary>
        /// 获取 CartonLayer 的颜色
        /// </summary>
        private Color GetCartonLayerColor(
            int palletUnitIndex, 
            int cartonLayer, 
            int cartonRow, 
            int cartonCol,
            int boxLayer, 
            int boxRow, 
            int boxCol)
        {
            Color color = Color.White;
            int ordinal = 0;
            int doMaxStatus = 0;
            int maxBoxRow = objPackageType.QtyPerColOfBox;
            int maxBoxCol = objPackageType.QtyPerRowOfBox;
            int maxBoxLayer = objPackageType.NumLayersOfBox;
            int maxCartonRow = objPackageType.NumBoxPerColOfCarton;
            int maxCartonCol = objPackageType.NumBoxPerRowOfCarton;
            ordinal = GetBoxIndex(cartonLayer, maxCartonRow, maxCartonCol,
                maxBoxLayer, maxBoxRow, maxBoxCol);
            int.TryParse(palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["Do"].ToString(), out doMaxStatus);

            switch (doMaxStatus)
            {
                case 0:
                    {
                        int maxCartonLayer = objPackageType.NumLayersOfCarton;
                        if (CartonLayerPrepared(maxCartonLayer)) break;
                        if (CartonPrepared(maxCartonRow, maxCartonCol))
                            color = Color.Blue;
                    }
                    break;
                case 1: color = Color.Blue; break;
                case 2: color = Color.Green; break;
                default: color = Color.White; break;
            }
            return color;
        }

        private bool PalletLayerPrepared(int palletLayer)
        {
            bool rlt = false;
            for (int i = 0; i < palletLayer; i++)
            {
                if (dgvPalletLayer.Rows[i].Cells[0].Style.BackColor == Color.Blue)
                {
                    rlt = true;
                    break;
                }
            }
            return rlt;
        }

        private bool PalletPrepared(int palletCol)
        {
            bool rlt = false;
            for (int j = 0; j < palletCol; j++)
            {
                if (dgvPallet.Rows[0].Cells[j].Style.BackColor == Color.Blue)
                {
                    rlt = true;
                    break;
                }
            }
            return rlt;
        }

        private bool BoxLayerPrepared(int boxLayer)
        {
            bool rlt = false;
            for (int i = 0; i < boxLayer; i++)
            {
                if (dgvBoxLayer.Rows[i].Cells[0].Style.BackColor == Color.Blue)
                {
                    rlt = true;
                    break;
                }
            }
            return rlt;
        }

        private bool CartonPrepared(int cartonRow, int cartonCol)
        {
            bool rlt = false;
            for (int i = 0; i < cartonRow; i++)
            {
                for (int j = 0; j < cartonCol; j++)
                {
                    if (dgvCarton.Rows[i].Cells[j].Style.BackColor == Color.Blue)
                    {
                        rlt = true;
                        break;
                    }
                }
                if (rlt) break;
            }
            return rlt;
        }

        private bool CartonLayerPrepared(int cartonLayer)
        {
            bool rlt = false;
            for (int i = 0; i < cartonLayer; i++)
            {
                if (dgvCartonLayer.Rows[i].Cells[0].Style.BackColor == Color.Blue)
                {
                    rlt = true;
                    break;
                }
            }
            return rlt;
        }

        /// <summary>
        /// 获取包装规格列表
        /// </summary>
        private void GetKanban_PackageTypes()
        {
            if (Options.SelectStation == null ||
                Options.SelectProduct == null)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "选项一或选项二没有配置！",
                    caption);
                return;
            }

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                try
                {
                    IRAPMESPKGClient.Instance.ufn_GetKanban_PackageTypes(
                        IRAPUser.Instance.CommunityID,
                        Options.SelectProduct.T102LeafID,
                        Options.SelectStation.T107LeafID,
                        IRAPUser.Instance.SysLogID,
                        ref packageTypeList,
                        out errCode,
                        out errText);
                }
                catch (Exception error)
                {
                    errCode = -1;
                    errText = error.Message;
                }

                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    dtPackageTypes = new DataTable();
                    dtPackageTypes.Columns.Add("id", typeof(int));
                    dtPackageTypes.Columns.Add("text", typeof(string));

                    foreach (PackageType pkgType in packageTypeList)
                    {
                        DataRow dr = dtPackageTypes.NewRow();
                        dr[0] = pkgType.CorrelationID;
                        dr[1] = pkgType.SpecDesc;
                        dtPackageTypes.Rows.Add(dr);
                    }

                    lpPackage.Properties.ValueMember = "id";
                    lpPackage.Properties.DisplayMember = "text";
                    lpPackage.Properties.NullText = "[请选择包装规格]";
                    lpPackage.Properties.DataSource = dtPackageTypes;
                    if (packageTypeList.Count > 0)
                        lpPackage.ItemIndex = 1;
                }
                else
                {
                    lpPackage.Properties.DataSource = null;
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        caption);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

        }

        /// <summary>
        /// 获取未完成包装信息
        /// </summary>
        private UncompletedPackage GetUncompletedPackage()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            UncompletedPackage rlt = null;
            try
            {
                int errCode = 0;
                string errText = "";

                try
                {
                    IRAPMESPKGClient.Instance.ufn_GetInfo_UncompletedPackage(
                        IRAPUser.Instance.CommunityID,
                        Options.SelectProduct.T102LeafID,
                        Options.SelectStation.T107EntityID,
                        objPackageType.Ordinal,
                        IRAPUser.Instance.SysLogID,
                        ref rlt,
                        out errCode,
                        out errText);
                }
                catch (Exception error)
                {
                    errCode = -1;
                    errText = error.Message;
                }

                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode != 0)
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        caption);

                return rlt;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

        }

        /// <summary>
        /// 获取未完成包装产品明细信息
        /// </summary>
        /// <param name="transactNo">包装交易号</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <returns></returns>
        private List<FactPackaging> GetFactList_Packaging(
            long transactNo,
            int productLeaf)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            List<FactPackaging> rlt = new List<FactPackaging>();
            try
            {
                int errCode = 0;
                string errText = "";

                try
                {
                    IRAPMESPKGClient.Instance.ufn_GetFactList_Packaging(
                        IRAPUser.Instance.CommunityID,
                        transactNo,
                        productLeaf,
                        IRAPUser.Instance.SysLogID,
                        ref rlt,
                        out errCode,
                        out errText);
                }
                catch (Exception error)
                {
                    errCode = -1;
                    errText = error.Message;
                }

                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode != 0)
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        caption);

                return rlt;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

        }

        private bool usp_SaveFact_Packaging(FactPackaging factPackage)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            bool result = false;
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                Hashtable paramDict = new Hashtable();
                int communityID = IRAPUser.Instance.CommunityID;
                Int64 factID = factPackage.FactID;
                int productLeaf = Options.SelectProduct.T102LeafID;
                int workUnitLeaf = Options.SelectStation.T107EntityID;
                int packagingSpecNo = factPackage.PackagingSpecNo;
                string wipPattern = factPackage.WIPCode;
                int layerNumOfPallet = factPackage.LayerIdxOfPallet;
                int cartonNumOfLayer = factPackage.CartonIdxOfLayer;
                int layerNumOfCarton = factPackage.LayerIdxOfCarton;
                int rowNumOfCarton = factPackage.RowIdxOfCarton;
                int colNumOfCarton = factPackage.ColIdxOfCarton;
                int layerNumOfBox = factPackage.LayerIdxOfBox;
                int rowNumOfBox = factPackage.RowIdxOfBox;
                int colNumOfBox = factPackage.ColIdxOfBox;
                string boxSerialNumber = factPackage.BoxSerialNumber;
                string cartonSerialNumber = factPackage.CartonSerialNumber;
                string layerSerialNumber = factPackage.LayerSerialNumber;
                string palletSerialNumber = factPackage.PalletSerialNumber;
                Int64 sysLogID = IRAPUser.Instance.SysLogID;

                paramDict.Add("CommunityID", communityID);
                paramDict.Add("TransactNo", transactNo);
                paramDict.Add("FactID", factID);
                paramDict.Add("ProductLeaf", productLeaf);
                paramDict.Add("WorkUnitLeaf", workUnitLeaf);
                paramDict.Add("PackagingSpecNo", packagingSpecNo);
                paramDict.Add("WIPPattern", wipPattern);
                paramDict.Add("LayerNumOfPallet", layerNumOfPallet);
                paramDict.Add("CartonNumOfLayer", cartonNumOfLayer);
                paramDict.Add("LayerNumOfCarton", layerNumOfCarton);
                paramDict.Add("RowNumOfCarton", rowNumOfCarton);
                paramDict.Add("ColNumOfCarton", colNumOfCarton);
                paramDict.Add("LayerNumOfBox", layerNumOfBox);
                paramDict.Add("RowNumOfBox", rowNumOfBox);
                paramDict.Add("ColNumOfBox", colNumOfBox);
                paramDict.Add("BoxSerialNumber", boxSerialNumber);
                paramDict.Add("CartonSerialNumber", cartonSerialNumber);
                paramDict.Add("LayerSerialNumber", layerSerialNumber);
                paramDict.Add("PalletSerialNumber", palletSerialNumber);
                paramDict.Add("SysLogID", sysLogID);

                WriteLog.Instance.Write(
                    string.Format(
                        "开始保存产品包装事实，输入参数: CommunityID={0}|TransactNo={1}|FactID={2}|" +
                        "ProductLeaf={3}|WorkUnitLeaf={4}|PackagingSpecNo={5}|WIPPattern={6}|"+
                        "LayerNumOfPallet={7}|CartonNumOfLayer={8}|LayerNumOfCarton={9}|"+
                        "RowNumOfCarton={10}|ColNumOfCarton={11}|LayerNumOfBox={12}|"+
                        "RowNumOfBox={13}|ColNumOfBox={14}|BoxSerialNumber={15}|"+
                        "CartonSerialNumber={16}|LayerSerialNumber={17}|PalletSerialNumber={18}|"+
                        "SysLogID={19}",
                        communityID,
                        transactNo,
                        factID,
                        productLeaf,
                        workUnitLeaf,
                        packagingSpecNo,
                        wipPattern,
                        layerNumOfPallet,
                        cartonNumOfLayer,
                        layerNumOfCarton,
                        rowNumOfCarton,
                        colNumOfCarton,
                        layerNumOfBox,
                        rowNumOfBox,
                        colNumOfBox,
                        boxSerialNumber,
                        cartonSerialNumber,
                        layerSerialNumber,
                        palletSerialNumber,
                        sysLogID),
                    strProcedureName);
                try
                {
                    //IRAPMESPKGClient.Instance.usp_SaveFact_Packaging();
                    //WCFClient wcfClient = new WCFClient();
                    //object obj = wcfClient.ExChange("IRAP.MES.BL.Packaging.dll",
                    //    "IRAP.MES.BL.Packaging.Packing", "usp_SaveFact_Packaging",
                    //    paramDict, out errCode, out errText);

                    //if (errCode == 0)
                    //{
                    //    result = true;
                    //    WriteLog.Instance.Write(string.Format("包装事实保存成功，返回值ErrCode：{0}, ErrText:{1}",
                    //        errCode, errText));
                    //}
                    //else
                    //{
                    //    WriteLog.Instance.Write(string.Format("包装事实保存失败，返回值ErrCode：{0}, ErrText:{1}",
                    //        errCode, errText));
                    //    XtraMessageBox.Show(errText, "系统提示",
                    //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                catch (Exception error)
                {
                    errCode = -1;
                    errText = error.Message;
                }
                return result;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 删除产品包装事实
        /// </summary>
        /// <decription>删除指定包装中某个产品，重新扫描，实现替换产品的功能，可暂时不用，前台暂时可不开通。</decription>
        private bool DeleFact_Packaging()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            Boolean result = false;
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                //int errCode = 0;
                //string errText = "";

                //Hashtable paramDict = new Hashtable();
                //int communityID = 0;
                //Int64 transactNo = 0;
                //int productLeaf = 0;
                //Int64 sysLogID = IRAPUser.Instance.SysLogID;

                //paramDict.Add("CommunityID", communityID);
                //paramDict.Add("TransactNo", transactNo);
                //paramDict.Add("ProductLeaf", productLeaf);
                //paramDict.Add("SysLogID", sysLogID);

                //WriteLog.Instance.Write(
                //    string.Format("开始保存产品包装事实，输入参数: CommunityID:{0}|TransactNo:{1}|ProductLeaf:{2}|SysLogID:{3}",
                //    communityID,
                //    transactNo,
                //    productLeaf,
                //    sysLogID
                //    ),
                //    strProcedureName);
                //try
                //{
                //    WCFClient wcfClient = new WCFClient();
                //    object obj = wcfClient.ExChange("IRAP.MES.BL.Packaging.dll",
                //        "IRAP.MES.BL.Packaging.Packing", "usp_DeleFact_Packaging",
                //        paramDict, out errCode, out errText);

                //    if (errCode == 0)
                //    {
                //        result = true;
                //        WriteLog.Instance.Write(string.Format("包装事实保存成功，返回值ErrCode：{0}, ErrText:{1}",
                //            errCode, errText));
                //    }
                //    else
                //    {
                //        WriteLog.Instance.Write(string.Format("包装事实保存失败，返回值ErrCode：{0}, ErrText:{1}",
                //            errCode, errText));
                //        XtraMessageBox.Show(errText, "系统提示",
                //            MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    WriteLog.Instance.Write(ex.ToString(), strProcedureName);
                //    XtraMessageBox.Show(ex.ToString(), "系统信息", MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //}
                return result;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 通过产品序列号获取到匹配的产品标签
        /// </summary>
        /// <param name="serialNumber">产品序列号</param>
        private string GetWIPPattern(string serialNumber)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            string rlt = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                WIPIDCode data = new WIPIDCode();

                try
                {
                    IRAPMESClient.Instance.ufn_GetInfo_WIPIDCode(
                        IRAPUser.Instance.CommunityID,
                        serialNumber,
                        Options.SelectProduct.T102LeafID,
                        Options.SelectStation.T107EntityID,
                        false,
                        IRAPUser.Instance.SysLogID,
                        ref data,
                        out errCode,
                        out errText);
                }
                catch (Exception error)
                {
                    errCode = -1;
                    errText = error.Message;
                }
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    if (data.BarcodeStatus != 0)
                    {
                        WriteLog.Instance.Write(data.BarcodeStatusStr, strProcedureName);
                        IRAPMessageBox.Instance.ShowErrorMessage(
                            data.BarcodeStatusStr,
                            caption);
                    }
                    else if (data.RoutingStatus != 0)
                    {
                        WriteLog.Instance.Write(data.RoutingStatusStr, strProcedureName);
                        IRAPMessageBox.Instance.ShowErrorMessage(
                            data.RoutingStatusStr,
                            caption);
                    }
                    else
                    {
                        rlt = data.WIPPattern;
                        WriteLog.Instance.Write(
                            string.Format("得到产品标签：[{0}]", rlt),
                            strProcedureName);
                    }
                }

                return rlt;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取打印信息
        /// </summary>
        /// <param name="labelID"></param>
        /// <param name="serialNo"></param>
        /// <returns></returns>
        private List<LabelFMTStr> ufn_GetLabelFMTStr(int labelID, string serialNo)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            List<LabelFMTStr> labelFMTStr = null;
            try
            {
                //int errCode = 0;
                //string errText = "";
                //Hashtable paramDict = new Hashtable();
                //int correlationID = objPackageType.CorrelationID;
                //paramDict.Add("CommunityID", currentCommunityID);
                //paramDict.Add("CorrelationID", correlationID);
                //paramDict.Add("LabelID", labelID);
                //paramDict.Add("SerialNo", serialNo);
                //paramDict.Add("PHStr1", "");
                //paramDict.Add("PHStr2", "");
                //paramDict.Add("PHStr3", "");
                //paramDict.Add("PHStr4", "");
                //paramDict.Add("PHStr5", "");
                //paramDict.Add("PHStr6", "");
                //paramDict.Add("PHStr7", "");
                //paramDict.Add("PHStr8", "");
                //paramDict.Add("PHStr9", "");
                //paramDict.Add("PHStr10", "");
                //paramDict.Add("PHStr11", "");
                //paramDict.Add("PHStr12", "");
                //paramDict.Add("PHStr13", "");
                //paramDict.Add("PHStr14", "");
                //paramDict.Add("PHStr15", "");
                //paramDict.Add("SysLogID", IRAPUser.Instance.SysLogID);
                //WriteLog.Instance.Write(
                //    string.Format("获取打印信息，输入参数:CommunityID:{0}|CorrelationID:{1}|LabelID={2}|SerialNo={3}|SysLogID:{4}",
                //    currentCommunityID,
                //    correlationID,
                //    labelID,
                //    serialNo,
                //    IRAPUser.Instance.SysLogID
                //    ),
                //    strProcedureName);
                //try
                //{
                //    WCFClient wcfClient = new WCFClient();
                //    object obj = wcfClient.ExChange("IRAP.MES.BL.Packaging.dll",
                //        "IRAP.MES.BL.Packaging.Packing", "ufn_GetLabelFMTStr",
                //        paramDict, out errCode, out errText);

                //    if (errCode == 0)
                //    {
                //        labelFMTStr = obj as IList<LabelFMTStr>;
                //        WriteLog.Instance.Write(string.Format("函数调用成功，共返回{0}条数据", 1), strProcedureName);
                //    }
                //    else
                //    {
                //        WriteLog.Instance.Write(errText, strProcedureName);
                //        XtraMessageBox.Show(errText, "系统提示",
                //            MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    WriteLog.Instance.Write(errText, strProcedureName);
                //    XtraMessageBox.Show(ex.ToString(), "系统信息", MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //}
                return labelFMTStr;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private string GetNextPackageSN(string labelType)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            string packageSN = "";
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                IRAPMESPKGClient.Instance.ufn_GetNextPackageSN(
                    IRAPUser.Instance.CommunityID,
                    objPackageType.CorrelationID,
                    objPackageType.Ordinal,
                    labelType,
                    DateTime.Now,
                    IRAPUser.Instance.SysLogID,
                    ref packageSN,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("{0}.{1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                    WriteLog.Instance.Write(
                        string.Format(
                            "申请包装序列号成功：{0}", packageSN),
                        strProcedureName);
                else
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        caption);

                return packageSN;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 复核交易
        /// </summary>
        /// <param name="transactNo">待复核的交易号</param>
        private bool ssp_CheckTransaction(long transactNo)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            bool rlt = false;
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                try
                {
                    IRAPUTSClient.Instance.ssp_CheckTransaction(
                        IRAPUser.Instance.CommunityID,
                        transactNo,
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                }
                catch (Exception error)
                {
                    errCode = -1;
                    errText = error.Message;
                }

                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                rlt = errCode == 0;

                if (errCode != 0)
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        caption);

                return rlt;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private long GetTransactNo(string opCode)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                long sequenceNo = 0;

                sequenceNo = IRAPUTSClient.Instance.mfn_GetTransactNo(
                    IRAPUser.Instance.CommunityID,
                    1,
                    IRAPUser.Instance.SysLogID,
                    opCode);
                return sequenceNo;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 申请下一个序列号
        /// </summary>
        /// <param name="sequenceCode"></param>
        /// <param name="counts"></param>
        /// <returns></returns>
        private long GetNextSequenceNo(string sequenceCode, int counts)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                long sequenceNo = 0;

                IRAPUTSClient.Instance.msp_GetSequenceNo(
                    IRAPUser.Instance.CommunityID,
                    sequenceCode,
                    counts,
                    IRAPUser.Instance.SysLogID,
                    ref sequenceNo,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                    IRAPMessageBox.Instance.ShowErrorMessage(errText, caption);

                return sequenceNo;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 打印标签
        /// </summary>
        /// <param name="labelID"></param>
        /// <param name="serialNo"></param>
        /// <returns></returns>
        private bool PrintLabel(int labelID, string serialNo)
        {
            Boolean result = false;
            IList<LabelFMTStr> labelFMTStr = ufn_GetLabelFMTStr(labelID, serialNo);
            if (labelFMTStr == null) return false;

            IRAP.Global.LPTPrint print = new LPTPrint();
            try
            {
                //打印标签
                for (int i = 0; i < labelFMTStr.Count; i++)
                {
                    string printPort = labelFMTStr[i].PrintPort;
                    string printStr = labelFMTStr[i].TemplateFMTStr;
                    string filePath = labelFMTStr[i].FilePath;

                    if (filePath.IndexOf("<Action") >= 0)
                    {
                        try
                        {
                            Actions.UDFActions.DoActions(filePath, null);
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(
                                string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                                    error.Message,
                                    error.StackTrace),
                                string.Format("{0}.{1}",
                                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                    MethodBase.GetCurrentMethod().Name));
                        }
                    }
                    else
                    {
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = "cmd.exe";//要执行的程序名称 
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardInput = true;//可能接受来自调用程序的输入信息 
                        p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息 
                        p.StartInfo.CreateNoWindow = true;//不显示程序窗口 
                        p.Start();//启动程序 
                        //向CMD窗口发送输入信息： 
                        p.StandardInput.WriteLine(string.Format("copy {0} {1}", filePath, printPort));
                        print.LPTOpen(printPort);
                        print.LPTWrite(printPort, printStr);
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                WriteLog.Instance.Write(ex.ToString(), className + ".标签打印");
            }
            print.LPTClose();
            return result;
        }
        #endregion

        private void lpPackage_QueryPopUp(object sender, CancelEventArgs e)
        {
            chkAllowRePrint.Checked = false;
            btnRePrint.Enabled = false;
        }

        private void lpPackage_EditValueChanged(object sender, EventArgs e)
        {
            if (lpPackage.ItemIndex != -1)
            {
                if (packageTypeList.Count > lpPackage.ItemIndex)
                {
                    objPackageType = packageTypeList[lpPackage.ItemIndex];
                    lblSmallPackageType.Text = string.Format("小包装： {0} 层 {1} 行 {2} 列",
                        objPackageType.NumLayersOfBox,
                        objPackageType.QtyPerColOfBox,
                        objPackageType.QtyPerRowOfBox);
                    lblLargePackageType.Text = string.Format("大包装： {0} 层 {1} 行 {2} 列",
                        objPackageType.NumLayersOfCarton,
                        objPackageType.NumBoxPerColOfCarton,
                        objPackageType.NumBoxPerRowOfCarton);

                    if (objPackageType.T117LabelID_Pallet > 0)
                    {
                        layoutControlItemPallet.Width = layoutControl1.Width / 3;
                        layoutControlItemBox.Width = layoutControl1.Width / 3;
                        layoutControlItemCarton.Width = layoutControl1.Width / 3;
                        layoutControlItemPallet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItemPalletLayer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    }
                    else
                    {
                        layoutControlItemPallet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutControlItemPalletLayer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutControlItemBox.Width = layoutControl1.Width / 2;
                        layoutControlItemCarton.Width = layoutControl1.Width / 2;
                    }
                }
            }
        }

        private void dgvPallet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //将Pallet坐标转换成List中对应的索引
            int palletColIndex = e.ColumnIndex;
            int palletLayerIndex = 
                dgvPalletLayer.SelectedCells.Count > 0 ?
                    dgvPalletLayer.SelectedCells[0].RowIndex : 
                    0;
            int palletUnitIndex = 
                palletLayerIndex * 
                objPackageType.NumCartonsPerLayerOfPallet + 
                palletColIndex;

            //呈现包装箱
            GenerateBox(palletUnitIndex, 1, 1, 1, 1);
            GenerateBoxLayer(palletUnitIndex, 1, 1, 1, 1);
            GenerateCarton(palletUnitIndex, 1, 1, 1);
            GenerateCartonLayer(palletUnitIndex);
        }

        private void dgvPallet_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPallet.SelectedCells.Count > 0)
            {
                int rowIndex = dgvPallet.SelectedCells[0].RowIndex;
                int colIndex = dgvPallet.SelectedCells[0].ColumnIndex;
                dgvPallet.Rows[rowIndex].Cells[colIndex].Style.SelectionBackColor =
                    dgvPallet.Rows[rowIndex].Cells[colIndex].Style.BackColor;
            }
        }

        private void dgvPalletLayer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //将Pallet坐标转换成List中对应的索引
            int palletLayerIndex = e.RowIndex;
            int palletColIndex = 
                dgvPallet.SelectedCells.Count > 0 ?
                    dgvPallet.SelectedCells[0].ColumnIndex : 
                    0;
            int palletUnitIndex = palletLayerIndex * objPackageType.NumCartonsPerLayerOfPallet + palletColIndex;
            //呈现包装箱
            GenerateBox(palletUnitIndex, 1, 1, 1, 1);
            GenerateBoxLayer(palletUnitIndex, 1, 1, 1, 1);
            GenerateCarton(palletUnitIndex, 1, 1, 1);
            GenerateCartonLayer(palletUnitIndex);
        }

        private void dgvPalletLayer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPalletLayer.SelectedCells.Count > 0)
            {
                int rowIndex = dgvPalletLayer.SelectedCells[0].RowIndex;
                int colIndex = dgvPalletLayer.SelectedCells[0].ColumnIndex;
                dgvPalletLayer.Rows[rowIndex].Cells[colIndex].Style.SelectionBackColor =
                    dgvPalletLayer.Rows[rowIndex].Cells[colIndex].Style.BackColor;
            }

        }

        private void dgvCarton_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int palletColIndex = dgvPallet.SelectedCells.Count > 0 ?
                dgvPallet.SelectedCells[0].ColumnIndex : 0;
            int palletLayerIndex = dgvPalletLayer.SelectedCells.Count > 0 ?
                dgvPalletLayer.SelectedCells[0].RowIndex : 0;
            int palletUnitIndex = palletLayerIndex * objPackageType.NumCartonsPerLayerOfPallet + palletColIndex;

            int rowIndex = dgvCarton.SelectedCells[0].RowIndex;
            int colIndex = dgvCarton.SelectedCells[0].ColumnIndex;
            int cartonLayerSet = 1;
            if (dgvCartonLayer.SelectedCells.Count > 0)
            {
                cartonLayerSet = dgvCartonLayer.SelectedCells[0].RowIndex + 1;
            }
            int boxLayer = 1;
            if (dgvBoxLayer.SelectedCells.Count > 0)
            {
                boxLayer = dgvBoxLayer.SelectedCells[0].RowIndex + 1;
            }

            int cartonRow = rowIndex + 1;
            int cartonCol = colIndex + 1;

            GenerateBox(palletUnitIndex, cartonLayerSet, cartonRow, cartonCol, boxLayer);
            GenerateBoxLayer(palletUnitIndex, cartonLayerSet, cartonRow, cartonCol, boxLayer);
        }

        private void dgvCarton_SelectionChanged(object sender, EventArgs e)
        {
            if (objPackageType == null) return;
            if (dgvCarton.SelectedCells.Count == 0)
                return;
            int rowIndex = dgvCarton.SelectedCells[0].RowIndex;
            int colIndex = dgvCarton.SelectedCells[0].ColumnIndex;
            dgvCarton.Rows[rowIndex].Cells[colIndex].Style.SelectionBackColor =
                dgvCarton.Rows[rowIndex].Cells[colIndex].Style.BackColor;
        }

        private void dgvCartonLayer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int palletColIndex = 
                dgvPallet.SelectedCells.Count > 0 ?
                    dgvPallet.SelectedCells[0].ColumnIndex : 
                    0;
            int palletLayerIndex = 
                dgvPalletLayer.SelectedCells.Count > 0 ?
                    dgvPalletLayer.SelectedCells[0].RowIndex : 
                    0;
            int palletUnitIndex = 
                palletLayerIndex * 
                objPackageType.NumCartonsPerLayerOfPallet + 
                palletColIndex;
            int rowIndex = dgvCartonLayer.SelectedCells[0].RowIndex;
            int colIndex = dgvCartonLayer.SelectedCells[0].ColumnIndex;
            int cartonRowSet = 1;
            if (dgvCarton.SelectedCells.Count > 0)
            {
                cartonRowSet = dgvCarton.SelectedCells[0].RowIndex + 1;
            }
            int cartonColSet = 1;
            if (dgvCarton.SelectedCells.Count > 0)
            {
                cartonColSet = dgvCarton.SelectedCells[0].ColumnIndex + 1;
            }
            int boxLayer = 1;
            if (dgvBoxLayer.SelectedCells.Count > 0)
            {
                boxLayer = dgvBoxLayer.SelectedCells[0].RowIndex + 1;
            }
            int cartonLayer = rowIndex + 1;

            GenerateBox(
                palletUnitIndex, 
                cartonLayer, 
                cartonRowSet, 
                cartonColSet, 
                boxLayer);
            GenerateBoxLayer(
                palletUnitIndex, 
                cartonLayer, 
                cartonRowSet, 
                cartonColSet, 
                boxLayer);
            GenerateCarton(
                palletUnitIndex, 
                cartonLayer, 
                cartonRowSet, 
                cartonColSet);
        }

        private void dgvCartonLayer_SelectionChanged(object sender, EventArgs e)
        {
            if (objPackageType == null) return;
            if (dgvCartonLayer.SelectedCells.Count == 0)
                return;
            int rowIndex = dgvCartonLayer.SelectedCells[0].RowIndex;
            int colIndex = dgvCartonLayer.SelectedCells[0].ColumnIndex;

            dgvCartonLayer.Rows[rowIndex].Cells[colIndex].Style.SelectionBackColor =
                dgvCartonLayer.Rows[rowIndex].Cells[colIndex].Style.BackColor;
        }

        private void dgvBox_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 点击单元格，自动定位坐标（小包装箱层、大包装箱、大包装箱层）

            if (objPackageType == null) return;
            int cartonLayer, cartonRow, cartonCol, boxLayer, boxRow, boxCol;
            int ordinal = int.Parse(dgvBox.SelectedCells[0].Value.ToString());

            SetBoxOrdinal(
                ordinal,
                out cartonLayer, 
                out cartonRow, 
                out cartonCol,
                out boxLayer, 
                out boxRow, 
                out boxCol);
        }

        private void dgvBox_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (sender is DataGridView)
            {
                int palletColIndex = dgvPallet.SelectedCells.Count > 0 ?
                dgvPallet.SelectedCells[0].ColumnIndex : 0;
                int palletLayerIndex = dgvPalletLayer.SelectedCells.Count > 0 ?
                    dgvPalletLayer.SelectedCells[0].RowIndex : 0;
                int palletUnitIndex = palletLayerIndex * objPackageType.NumCartonsPerLayerOfPallet + palletColIndex;

                if (e.RowIndex < 0) return;
                int ordinal = 0;
                if (!int.TryParse(dgvBox.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out ordinal)) return;
                string productSN = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["ProductSN"].ToString();
                string boxPackageSN = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["BoxPackageSN"].ToString();
                string cartonPackageSN = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["CartonPackageSN"].ToString();
                string doStatus = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["Do"].ToString();
                doStatus = doStatus == "2" ? "完成包装" : "未完成包装";
                string cartonLayerSet = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["CartonLayer"].ToString();
                string cartonRowSet = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["CartonRow"].ToString();
                string cartonColSet = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["CartonCol"].ToString();
                string boxLayerSet = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["BoxLayer"].ToString();
                string boxRowSet = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["BoxRow"].ToString();
                string boxColSet = palletUnitTables[palletUnitIndex].Rows[ordinal - 1]["BoxCol"].ToString();
                string location = string.Format("大包装坐标:{0}层 {1}行 {2}列\r\n小包装坐标{3}层 {4}行 {5}列",
                    cartonLayerSet, cartonRowSet, cartonColSet, boxLayerSet, boxRowSet, boxColSet);
                string hintText = string.Format("序号:{0}\n\r产品序列号:{1}\n\r小包装序列号:{2}\n\r大包装序列号:{3}\n\r状态:{4}\n\r{5}",
                    ordinal, productSN, boxPackageSN, cartonPackageSN, doStatus, location);
                DevExpress.Utils.ToolTipControllerShowEventArgs tip = new DevExpress.Utils.ToolTipControllerShowEventArgs();
                tip.Title = "";
                tip.ToolTip = hintText;
                tip.Appearance.Font = new Font("微软雅黑", 16, FontStyle.Bold);
                tip.Appearance.Options.UseFont = true;
                tip.ShowBeak = true;
                tip.Rounded = true;////圆角 
                tip.RoundRadius = 7;//圆角率 
                tip.ToolTipStyle = DevExpress.Utils.ToolTipStyle.Windows7;
                tip.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
                tip.IconType = DevExpress.Utils.ToolTipIconType.None;
                tip.IconSize = DevExpress.Utils.ToolTipIconSize.Small;

                toolTipController.ShowHint(tip);
            }
        }

        private void dgvBox_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBox.SelectedCells.Count > 0)
            {
                int rowIndex = dgvBox.SelectedCells[0].RowIndex;
                int colIndex = dgvBox.SelectedCells[0].ColumnIndex;
                dgvBox.Rows[rowIndex].Cells[colIndex].Style.SelectionBackColor =
                    dgvBox.Rows[rowIndex].Cells[colIndex].Style.BackColor;
            }
        }

        private void dgvBox_SizeChanged(object sender, EventArgs e)
        {
            DataGridView dtGrid = sender as DataGridView;
            if (dtGrid.Rows.Count > 0)
            {
                int rowCount = dtGrid.Rows.Count;
                int height = dtGrid.Height;
                for (int i = 0; i < rowCount; i++)
                {
                    dtGrid.Rows[i].Height = height / rowCount;
                }
                dtGrid.Rows[rowCount - 1].Height = height / rowCount - 3;
            }
        }

        private void dgvBoxLayer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int palletColIndex = 
                dgvPallet.SelectedCells.Count > 0 ?
                    dgvPallet.SelectedCells[0].ColumnIndex : 
                    0;
            int palletLayerIndex = 
                dgvPalletLayer.SelectedCells.Count > 0 ?
                    dgvPalletLayer.SelectedCells[0].RowIndex : 
                    0;
            int palletUnitIndex = 
                palletLayerIndex * 
                objPackageType.NumCartonsPerLayerOfPallet + 
                palletColIndex;
            int rowIndex = dgvBoxLayer.SelectedCells[0].RowIndex;
            int colIndex = dgvBoxLayer.SelectedCells[0].ColumnIndex;
            int cartonLayerSet = 1;
            if (dgvCartonLayer.SelectedCells.Count > 0)
            {
                cartonLayerSet = dgvCartonLayer.SelectedCells[0].RowIndex + 1;
            }
            int cartonRowSet = 1;
            if (dgvCarton.SelectedCells.Count > 0)
            {
                cartonRowSet = dgvCarton.SelectedCells[0].RowIndex + 1;
            }
            int cartonColSet = 1;
            if (dgvCarton.SelectedCells.Count > 0)
            {
                cartonColSet = dgvCarton.SelectedCells[0].ColumnIndex + 1;
            }
            int boxLayer = rowIndex + 1;

            GenerateBox(
                palletUnitIndex, 
                cartonLayerSet, 
                cartonRowSet,
                cartonColSet, 
                boxLayer);
        }

        private void dgvBoxLayer_SelectionChanged(object sender, EventArgs e)
        {
            if (objPackageType == null) return;
            if (dgvBoxLayer.SelectedCells.Count == 0)
                return;
            int rowIndex = dgvBoxLayer.SelectedCells[0].RowIndex;
            int colIndex = dgvBoxLayer.SelectedCells[0].ColumnIndex;

            dgvBoxLayer.Rows[rowIndex].Cells[colIndex].Style.SelectionBackColor =
                dgvBoxLayer.Rows[rowIndex].Cells[colIndex].Style.BackColor;
        }

        private void edtProductSN_Enter(object sender, EventArgs e)
        {
            chkAllowRePrint.Checked = false;
            btnRePrint.Enabled = false;
        }

        private void edtProductSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string serialNumber = edtProductSN.Text.Trim().ToString();
                if (string.IsNullOrEmpty(serialNumber))
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        "产品序列号为空，请确认输入！", 
                        caption);
                    return;
                }

                edtProductSN.Text = "";
                int palletUnitIndex = -1;
                for (int i = 0; i < allNumCartonsInPallet; i++)
                {
                    if (palletUnitTables[i].Rows[0]["Do"].ToString() != "2" &&
                        palletUnitTables[i].Rows[allBoxNum - 1]["Do"].ToString() != "2")
                    {
                        palletUnitIndex = i;
                        break;
                    }
                    if (palletUnitTables[i].Rows[0]["Do"].ToString() == "2" &&
                        palletUnitTables[i].Rows[allBoxNum - 1]["Do"].ToString() != "2")
                    {
                        palletUnitIndex = i;
                        break;
                    }
                }

                if (palletUnitIndex == -1)
                    return;
                int currentPalletLayer = (palletUnitIndex / objPackageType.NumCartonsPerLayerOfPallet) + 1;
                int currentPalletCol = palletUnitIndex + 1 - (currentPalletLayer - 1) * objPackageType.NumCartonsPerLayerOfPallet;

                for (int i = 0; i < allBoxNum; i++)
                {
                    string doStatus = palletUnitTables[palletUnitIndex].Rows[i]["Do"].ToString();
                    //如果状态为待包装
                    if (doStatus == "1")
                    {
                        int ordinal = i + 1;
                        int cartonLayer, cartonRow, cartonCol, boxLayer, boxRow, boxCol;

                        SetBoxOrdinal(
                            ordinal,
                            out cartonLayer, 
                            out cartonRow, 
                            out cartonCol,
                            out boxLayer, 
                            out boxRow, 
                            out boxCol);

                        #region 保存事实并打印标签 
                        string boxSerialNumber = palletUnitTables[palletUnitIndex].Rows[i]["BoxPackageSN"].ToString();
                        int boxNumOfInCarton = objPackageType.QtyPerColOfBox * objPackageType.QtyPerRowOfBox;
                        //已包装产品数量是Box容量整倍数时，需要申请Box序列号
                        if (i % boxNumOfInCarton == 0)
                        {
                            boxSerialNumber = GetNextPackageSN("BOX");
                            //更新内存表
                            for (int r = i; r < i + boxNumOfInCarton; r++)
                            {
                                palletUnitTables[palletUnitIndex].Rows[r]["BoxPackageSN"] = boxSerialNumber;
                            }
                        }
                        string cartonSerialNumber = palletUnitTables[palletUnitIndex].Rows[i]["CartonPackageSN"].ToString();
                        //每个Carton需要申请一个新的交易号和标签号
                        if (i == 0)
                        {
                            //申请交易号
                            transactNo = GetTransactNo("-12");
                            if (transactNo == 0)
                            {
                                XtraMessageBox.Show("交易号申请失败！", "提示", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return;
                            }
                            //更新内存表
                            BatchUpdateMemTable(palletUnitIndex, "TransactNo", transactNo.ToString());
                            cartonSerialNumber = GetNextPackageSN("CRT");
                            edtCartonSN.Text = cartonSerialNumber;
                            BatchUpdateMemTable(palletUnitIndex, "CartonPackageSN", cartonSerialNumber);
                        }
                        string PalletSerialNumber = palletUnitTables[palletUnitIndex].Rows[i]["PalletPackageSN"].ToString();
                        string layerSerialNumber = palletUnitTables[palletUnitIndex].Rows[i]["PalletLayerSN"].ToString();

                        //每包完一箱都要进行一次数据提交动作
                        string wipPattern = GetWIPPattern(serialNumber);
                        if (string.IsNullOrEmpty(wipPattern)) return;
                        Int64 factNo = GetNextSequenceNo("NextFactNo", 1);
                        FactPackaging factPackage = new FactPackaging();
                        factPackage.FactID = factNo;
                        factPackage.PackagingSpecNo = ordinal;
                        factPackage.WIPCode = wipPattern;
                        factPackage.LayerIdxOfPallet = currentPalletLayer;
                        factPackage.CartonIdxOfLayer = currentPalletCol;
                        factPackage.LayerIdxOfCarton = cartonLayer;
                        factPackage.RowIdxOfCarton = cartonRow;
                        factPackage.ColIdxOfCarton = cartonCol;
                        factPackage.LayerIdxOfBox = boxLayer;
                        factPackage.RowIdxOfBox = boxRow;
                        factPackage.ColIdxOfBox = boxCol;
                        factPackage.BoxSerialNumber = boxSerialNumber;
                        factPackage.CartonSerialNumber = cartonSerialNumber;
                        factPackage.LayerSerialNumber = layerSerialNumber;
                        factPackage.PalletSerialNumber = PalletSerialNumber;

                        Boolean saveResult = usp_SaveFact_Packaging(factPackage);
                        //如果数据提交动作数据库返回成功状态，则再进行 
                        if (!saveResult) return;
                        //事实保存成功，打印标签
                        //判断是否已包满一Box，如果已满，则打印Box标签
                        if (boxRow == objPackageType.QtyPerColOfBox &&
                            boxCol == objPackageType.QtyPerRowOfBox)
                        {
                            PrintLabel(objPackageType.T117LabelID_Box, boxSerialNumber);
                        }
                        //判断是否已已包满一大包装箱，如果已满，则打印Carton标签 
                        if (ordinal == allBoxNum)
                        {
                            //Carton包满或点包装完成按钮时复核交易
                            if (ssp_CheckTransaction(transactNo))
                            {
                                PrintLabel(objPackageType.T117LabelID_Carton, cartonSerialNumber);
                            }
                        }
                        if (objPackageType.T117LabelID_Layer > 0)
                        {
                            //判断是否已包满一托中的层，如果已满，则打印托层的标签
                            if (ordinal == allBoxNum && currentPalletCol == objPackageType.NumCartonsPerLayerOfPallet)
                            {
                                PrintLabel(objPackageType.T117LabelID_Layer, layerSerialNumber);
                            }
                            //判断是否已包满一托的标签，如果已满，则打印托标签
                            if (ordinal == allBoxNum && currentPalletLayer == objPackageType.NumLayersOfPallet)
                            {
                                PrintLabel(objPackageType.T117LabelID_Pallet, factPackage.PalletSerialNumber);
                            }
                        }
                        palletUnitTables[palletUnitIndex].Rows[i]["ProductSN"] = serialNumber;
                        palletUnitTables[palletUnitIndex].Rows[i]["TransactNo"] = transactNo;
                        palletUnitTables[palletUnitIndex].Rows[i]["FactNo"] = factNo;
                        #endregion 
                        //改变Box状态，标识其已经包装完成
                        palletUnitTables[palletUnitIndex].Rows[i]["Do"] = 2;
                        //同时将下一个包装箱的状态设置为带包装
                        if (i < allBoxNum - 1)
                        {
                            palletUnitTables[palletUnitIndex].Rows[i + 1]["Do"] = 1;
                        }
                        //如果小包装箱已满，则需要换箱，即将Box的序列号向前推进1
                        if (boxRow == objPackageType.QtyPerColOfBox &&
                            boxCol == objPackageType.QtyPerRowOfBox)
                        {
                            SetBoxOrdinal(ordinal + 1,
                            out cartonLayer, out cartonRow, out cartonCol,
                            out boxLayer, out boxRow, out boxCol);
                        }

                        if (ordinal == allBoxNum)
                        {
                            if (objPackageType.T117LabelID_Pallet > 0)
                            {
                                //判断托是否已满
                                if (currentPalletLayer == objPackageType.NumLayersOfPallet)
                                {
                                    InitPackageStart(true);
                                    return;
                                }
                                //如果大包装箱已满，则需要换箱，将此包装箱数据暂存至List中
                                if (palletUnitIndex < allNumCartonsInPallet)
                                {
                                    palletUnitIndex += 1;
                                }
                                else
                                {
                                    palletUnitIndex = 0;
                                }
                                GeneratePallet(currentPalletLayer);
                                GeneratePalletLayer();
                            }
                            else
                            {
                                //当Carton已包装满，则需要结束交易，进行初始化  
                                InitPackageStart(true);
                                return;
                            }

                        }

                        GenerateBox(palletUnitIndex, cartonLayer, cartonRow, cartonCol, boxLayer);
                        GenerateBoxLayer(palletUnitIndex, cartonLayer, cartonRow, cartonCol, boxLayer);

                        GenerateCarton(palletUnitIndex, cartonLayer, cartonRow, cartonCol);
                        GenerateCartonLayer(palletUnitIndex);

                        break;
                    }
                }
            }
        }

        private void chkAllowRePrint_EditValueChanged(object sender, EventArgs e)
        {
            if (chkAllowRePrint.Checked)
            {
                btnRePrint.Enabled = true;
                edtBoxSN.Properties.ReadOnly = false;
                edtCartonSN.Properties.ReadOnly = false;
                edtPalletLayerSN.Properties.ReadOnly = false;
            }
            else
            {
                btnRePrint.Enabled = false;
                edtBoxSN.Properties.ReadOnly = true;
                edtCartonSN.Properties.ReadOnly = true;
                edtPalletLayerSN.Properties.ReadOnly = true;
            }
        }

        private void frmProductPackage_Activated(object sender, EventArgs e)
        {
            Options.Visible = true;

            GetKanban_PackageTypes();
        }

        private void btnPackageFinish_Click(object sender, EventArgs e)
        {
            if (transactNo == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "尚未进行包装！", caption);
                return;
            }
            if (!chkStorePackage.Checked)
            {
                if (!ssp_CheckTransaction(transactNo))
                    return;

                //打标签
                //寻找最新的大包装标签
                string cartonSerialNumber = "";
                for (int i = allNumCartonsInPallet - 1; i >= 0; i--)
                {
                    Boolean bk = false;
                    for (int j = allBoxNum - 1; j >= 0; j--)
                    {
                        if (palletUnitTables[i].Rows[j]["CartonPackageSN"].ToString().Trim() != "")
                        {
                            cartonSerialNumber = palletUnitTables[i].Rows[j]["CartonPackageSN"].ToString().Trim();
                            bk = true;
                            break;
                        }
                    }
                    if (bk) break;
                }
                PrintLabel(objPackageType.T117LabelID_Carton, cartonSerialNumber);
                if (objPackageType.T117LabelID_Pallet > 0)
                {
                    string palletSerialNumber = palletUnitTables[0].Rows[0]["PalletPackageSN"].ToString();
                    PrintLabel(objPackageType.T117LabelID_Pallet, palletSerialNumber);
                }
            }
            InitPackageStart(true);
        }

        private void btnPackageStart_Click(object sender, EventArgs e)
        {
            if (lpPackage.ItemIndex < 0)
            {
                IRAPMessageBox.Instance.ShowInformation("请选择包装规格", caption);
                return;
            }

            InitPackageStart(false);
            InitPackageLocation();
        }

        private void btnRePrint_Click(object sender, EventArgs e)
        {
            if (ft == null)
            {
                XtraMessageBox.Show("请将光标定位在您需要重新打印的标签文本框内！", "系统提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            ft.Focus();
            if (ft.Name == edtBoxSN.Name)
            {
                string boxSN = edtBoxSN.Text.Trim().ToString();
                if (string.IsNullOrEmpty(boxSN))
                {
                    XtraMessageBox.Show("小包装序列号为空！请选择或输入您需要进行重新打印的标签序列号！",
                        "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ft = null;
                    return;
                }
                PrintLabel(objPackageType.T117LabelID_Box, boxSN);
            }
            else
            if (ft.Name == edtCartonSN.Name)
            {
                string cartonSN = edtCartonSN.Text.Trim().ToString();
                if (string.IsNullOrEmpty(cartonSN))
                {
                    XtraMessageBox.Show("大包装序列号为空！请选择或输入您需要进行重新打印的标签序列号！",
                        "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ft = null;
                    return;
                }
                PrintLabel(objPackageType.T117LabelID_Carton, cartonSN);
            }
            else
            if (ft.Name == edtPalletLayerSN.Name)
            {
                string palletLayerSN = edtPalletLayerSN.Text.Trim().ToString();
                if (string.IsNullOrEmpty(palletLayerSN))
                {
                    XtraMessageBox.Show("托层序列号为空！请选择或输入您需要进行重新打印的标签序列号！",
                        "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ft = null;
                    return;
                }
                PrintLabel(objPackageType.T117LabelID_Layer, palletLayerSN);
            }
            ft = null;
        }
    }
}
