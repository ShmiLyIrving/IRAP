
var PwoNO = "";
var VList = "";
var ParameterID = "";
var TabID = 0;
var tempData = {};

var CriterialData = [{ "ID": 1, "Criterion": "GELE", "LowX": "<=", "HighX": "<=" }, { "ID": 2, "Criterion": "GTLE", "LowX": "<", "HighX": "<=" },
                     { "ID": 3, "Criterion": "GTLT", "LowX": "<", "HighX": "<" }, { "ID": 4, "Criterion": "GELT", "LowX": "<=", "HightX": "<" },
                     { "ID": 5, "Criterion": "EQ", "LowX": "=", "HighX": "=" }, { "ID": 6, "Criterion": "NE", "LowX": "!=", "HighX": "!=" },
                     { "ID": 7, "Criterion": "GE", "LowX": "", "HighX": ">=" }, { "ID": 8, "Criterion": "LE", "LowX": "", "HighX": "<=" },
                     { "ID": 9, "Criterion": "GT", "LowX": "", "HighX": ">" }, { "ID": 10, "Criterion": "LT", "LowX": "", "HighX": "<" },
]
$(function ()
{
    //$('#myTab li:eq(1) a').tab('show');
    AccessibleLeafSetEx("ProLine");
})

//获取产线
function AccessibleLeafSetEx(ProLine) {
    $.ajax({
        type: "POST",
        url: '/MESPDC/Serach/Get_AccessibleLeafSetEx?timeStamp=' + new Date().getTime() + '&TreeID=' + 134 + '&ScenarioIndex='+1,
        dataType: "json",
        success: function (data) {
            if (data.errCode != 0) {
                alert(data.errText);
                return;
            } else {
                var len =data.DataList.length;
                var optionString = "";
                for (i = 0; i < len; i++) {
                    optionString += "<option value=\'" + data.DataList[i].LeafID + "\'>" + data.DataList[i].LeafName + "</option>";
                }
               var myobj = document.getElementById(ProLine);
                if (myobj.options.length == 0) {
                    $("#" + ProLine).html(optionString);
                    $("#" + ProLine).selectpicker('refresh');
                }
                //工序
                selectOnchang(myobj);
                //检验类型
                selectype();
            }
        },
  
    });
}
//onchange事件  获取工序
function selectOnchang(pline) {
    var value = $('#ProLine').val();
    //var value = pline.options[pline.selectedIndex].value;
    var process = "process";
    $.ajax({
        type: "POST",
        url: '/MESPDC/Serach/GetList_ProcessOfProductLine?timeStamp=' + new Date().getTime() + '&ProductLineID=' + value,
        dataType: "json",
        success: function (data) {
            if (data.errCode != 0) {
                alert(data.errText);
                return;
            } else {
                var len =data.DataList.length;
                var optionString = "";
                var DataList = data.DataList;
                for (i = 0; i < len; i++) {
                    optionString += "<option value=\'" + DataList[i].ProcessID + "\'>" + DataList[i].ProcessName + "</option>";
                }
                var myobj = document.getElementById(process);
                //if (myobj.options.length == 0) {
                    $("#" + process).html(optionString);
                    $("#" + process).selectpicker('refresh');
                //}
                //检验类型
                selectype();
            }
        },

    });
}
//获取检验类型
function selectype() {

    var ProLine = $('#ProLine').val();//获取产线
    var process = $('#process').val();//获取工序
    var checktype = "checktype";
    $.ajax({
        type: "POST",
        url: '/MESPDC/Serach/GetList_InspectType?timeStamp=' + new Date().getTime() + '&T134LeafID=' + ProLine + '&T216LeafID=' + process,
        dataType: "json",
        success: function (data) {
            if (data.errCode != 0) {
                alert(data.errText);
                return;
            } else {
                var TypeData = data.DataList;
                var len = TypeData.length;
                var optionString = "";
                for (i = 0; i < len; i++) {
                    optionString += "<option value=\'" + TypeData[i].InspectType + "\'>" + TypeData[i].InspectName + "</option>";
                }
                var myobj = document.getElementById(checktype);
                //if (myobj.options.length == 0) {
                    $("#" + checktype).html(optionString);
                    $("#" + checktype).selectpicker('refresh');
                //}
            }
        },

    });

}

function Search() {
    var ProLine = $('#ProLine').val();
    var Process = $('#process').val();
    var checktype = $('#checktype').val();
    $.ajax({
        type: "POST",
        url: '/MESPDC/Serach/GetFactList_InspectToPWO?timeStamp=' + new Date().getTime() + '&T134LeafID=' + ProLine + '&T216LeafID=' + Process + '&InspectType=' + checktype,
        dataType: "json",
        success: function (data) {
            if (data.errCode != 0) {
                alert(data.errText);
                return;
            } else {
                var OrderData = data.DataList;
                tempData = OrderData;
                Getli(OrderData);
                GetTab();
                }
            }
    });

}

function Getli(OrderData) {
    $('#order').html("");//清空
 
    for (var i = 0; i < OrderData.length; i++) {
     
            $("#order").append('<li id=' + OrderData[i].Ordinal + ' class="list-group-item"  onclick="OrderClick(' + OrderData[i].Ordinal + ',\''+OrderData[i].PWONo+ '\')">' + OrderData[i].PWONo + '┈┈┈┈→[' + OrderData[i].ProductCode + ']' + OrderData[i].ProductName + '<span class="badge" style="width:50px;background-color:' + OrderData[i].Color + '">' + OrderData[i].PWOStatusStr + '</span> </li>');
        }

}

//点击li变背景色
function OrderClick(id,pwono) {
    d = document.getElementsByTagName('li')
    for (p = d.length; p--;) {
        if (d[p].id != id) { d[p].style.backgroundColor = 'white' }
        else {
            d[p].style.backgroundColor = '#c0d9f2'/*点击的*/
            var Type = $('#tabs1-li a').attr("name");
            $('#myTab a:first').tab('show')//设置默认选中tab1
            PwoNO = pwono;
            InitTable(pwono,Type);//默认选中Tabl 初始化Tab 
        }
    }
}

function GetTab()
{
    var ProLine = $('#ProLine').val();//产线
    var Process = $('#process').val();//工序
    var checktype = $('#checktype').val();//检验类型
    $.ajax({
        type: "POST",
        url: '/MESPDC/Serach/GetList_InspectTypeOfProcess?T134LeafID=' + ProLine + '&T216LeafID=' + Process + '&InspectType=' + checktype,
        dataType: "json",
        success: function (data) {
            if (data.errCode != 0) {
                alert(data.errText);
                return;
            } else {
                var tabs = $("ul.nav-tabs");
             
                if ($('#myTab').length > 0) {
                    $('#myTab li').remove();
                    $('#myTabContent').html("");
                }
                var zcolor = "black"
                var ProcessData = data.DataList;
                for (var i = 0; i < ProcessData.length; i++) {
                    //if (ProcessData[i].ColorStatus == "#FFF8DC") {
                    //    zcolor = "black";
                    //}
                    tabs.addTabs({
                        "id": "tabs" + ProcessData[i].Ordinal,
                        "InspectType": ProcessData[i].InspectType,
                        "IsValid":ProcessData[i].IsValid,
                        "style":"background-color:"+ProcessData[i].ColorStatus+";color:"+zcolor+"",
                        "title": ProcessData[i].InspectName,
                        "content": '<div><table style="width:100%"  id="Table' + ProcessData[i].InspectType + '"></table> </div><div class="row" style="float:right;margin-right:10%;margin-top:1%">'+
                                   '<div class="col-md-4"><button type="button" id="btn'+ProcessData[i].Ordinal+'"  class="btn btn-primary" onclick="SaveTable(\'' + ProcessData[i].InspectType + '\')">保存</button></div></div>'
                    });
                }
                $('#myTab a:first').tab('show')//设置默认选中tab1
            }
        }
    });
}

//点击Tab调用函数
function SelectTab(Type, IsValid) {
    if (IsValid == 0) {
        alert("此为不可用！");
        return;
    }
    InitTable(PwoNO, Type);
}

//文本框回车事件
var temp = 0;
function GetKey() {
    temp = 0;
$('#ordertext').keydown(function(e){
    if (e.keyCode == 13) {
        var order = $('#ordertext').val();
        if (order == "" || order == null || order == undefined) {
            return;
        }
        if (temp == 1) {
            return;
        }
        if (tempData[0] == undefined || tempData[0] == null || tempData[0] == undefined) {
        
            alert("请先查询！没有数据无法进行筛选");
            return;
        }

        ArrayData(tempData, order);
        }
}); 
}

function ArrayData(data,order)
{
    if (data[0] == undefined || data[0] == null || data[0] == undefined) {
        temp = 1;
        alert("请先查询！没有数据无法进行筛选");
        return;
    }
    i = 0;
    $.each(data, function (name, value) {
        if (temp == 1) {
            return;
        }
        i++;
        if (order == value.ProductCode) {
            temp = 1;
            data.splice(i - 1,1);
            data.unshift(value);
            Getli(data);
            return;
        }
    });
}

 //查询Table
function InitTable(pwono,Type)
{
    var id = Type;
    if (pwono == "" || pwono == null) {
        alert("请先选择工单!");
        return;
    }
    var ProLine = $('#ProLine').val();//产线
    var process = $('#process').val();//工序
    var checktype = $('#checktype').val();//检验类型
    //获取当前选中的Table
    var inspecttab = Type;
    TabID=Type;
    $.ajax({
        url: '/MESPDC/Serach/GetList_MethodParameters?timeStamp='+  new Date().getTime(),
        type: 'post',
        data: { T134LeafID: ProLine, T216LeafID: process, InspectType: checktype, PWONo: pwono, InspectTab: inspecttab },
        dataType: "json",
        async: false,
        async: true,
        success: function (data) {
            if (data.errCode != 0) {
                alert(data.errText);
                return;
            } else {
                var TableData = data.DataList;
                if (TableData.length >= 0) {
                    InitColumn(id,TableData);
                    var temp = 0;
                    for (var i = 0; i < 8; i++)
                    {
                        temp = "Sample0" + Number(i + 1);
                        if (TableData[0][temp] == -999999) {
                            $('#Table' + id).bootstrapTable('hideColumn', temp);
                        }
                    }
                  
                    $('#Table' + id).bootstrapTable('load', TableData);
                    $('#Table' + id).bootstrapTable("resetView");
                }
                return;
            }
        }
    })
}

//初始化tab表格
function InitColumn(id, TableData) {
    TestValidate();
    if (id == 3) {
        $('#Table' + id).bootstrapTable({
            data: TableData,
            singleSelect: false,
            editable: true,//开启编辑模式  
            // cache: false, //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            // showRefresh: true,
            // search: true,
            clickToSelect: true,
            queryParams: function (param) {
                return {};
            },
            columns: [{
                title: '序号',//标题  可不加  
                field: 'Ordinal',//可不加  
                align: 'center',
                valign: 'middle',
                width: 60,
            }, {
                title: '参数名称',
                field: 'ParameterName',
                align: 'center',
                width: 100,
                valign: 'middle',
            }, {
                title: '参数ID',
                field: 'ParameterID',
                align: 'center',
                width: 100,
                valign: 'middle',
            }, {
                title: '样品01',
                field: 'Sample01',
                align: 'center',
                width: 100,
                valign: 'middle',
                //checkbox: true
                //formatter: function (value, row, index) {
                //    return "<div class='switch' data-animated='false'> <input type='checkbox' checked  value='1'/><div>";
                //}
                editable: {
                    type: 'select',
                    title: '是否合格',
                    source: [{ value: "1", text: "是" }, { value: "0", text: "否" }]
                }
            },
            {
                title: '样品02',
                field: 'Sample02',
                align: 'center',
                width: 100,
                valign: 'middle',
                //checkbox: true
                editable: {
                    type: 'select',
                    title: '是否合格',
                    source: [{ value: "1", text: "是" }, { value: "0", text: "否" }]
                }
            },
             {
                 title: '样品03',
                 field: 'Sample03',
                 align: 'center',
                 width: 100,
                 valign: 'middle',
                 //checkbox: true,
                 editable: {
                     type: 'select',
                     title: '是否合格',
                     source: [{ value: "1", text: "是" }, { value: "0", text: "否" }]
                 }
             },
              {
                  title: '样品04',
                  field: 'Sample04',
                  align: 'center',
                  width: 100,
                  valign: 'middle',
                  //checkbox: true
                  //formatter: function (value, row, index) {
                  //    return "<div class='switch' data-animated='false'> <input type='checkbox' checked /><div>";
                  //}
                  editable: {
                      type: 'select',
                      title: '是否合格',
                      source: [{ value: "1", text: "是" }, { value: "0", text: "否" }]
                  }
              }, {
                  title: '样品05',
                  field: 'Sample05',
                  align: 'center',
                  width: 100,
                  valign: 'middle',
                  //checkbox: true
                  //formatter: function (value, row, index) {
                  //    return "<div class='switch' data-animated='false'> <input type='checkbox' checked /><div>";
                  //}
                  editable: {
                      type: 'select',
                      title: '是否合格',
                      source: [{ value: "1", text: "是" }, { value: "0", text: "否" }]
                  }
              },
             {
                 title: '样品06',
                 field: 'Sample06',
                 align: 'center',
                 width: 100,
                 valign: 'middle',
                 //checkbox: true
                 //formatter: function (value, row, index) {
                 //    return "<div class='switch' data-animated='false'> <input type='checkbox' checked /><div>";
                 //}
                 editable: {
                     type: 'select',
                     title: '是否合格',
                     source: [{ value: "1", text: "是" }, { value: "0", text: "否" }]
                 }
             },
             {
                 title: '样品07',
                 field: 'Sample07',
                 align: 'center',
                 width: 100,
                 valign: 'middle',
                 //checkbox: true
                 //formatter: function (value, row, index) {
                 //    return "<div class='switch' data-animated='false'> <input type='checkbox' checked /><div>";
                 //}
                 editable: {
                     type: 'select',
                     title: '是否合格',
                     source: [{ value: "1", text: "是" }, { value: "0", text: "否" }]
                 }
             }, {
                 title: '样品08',
                 field: 'Sample08',
                 align: 'center',
                 width: 100,
                 valign: 'middle',
                 //checkbox: true
                 //formatter: function (value, row, index) {
                 //    return "<div class='switch' data-animated='false'> <input type='checkbox' checked /><div>";
                 //}
                 editable: {
                     type: 'select',
                     title: '是否合格',
                     source: [{ value: "1", text: "是" }, { value: "0", text: "否" }]
                 }
             }
            ],
            onLoadSuccess: function (data) {  //加载成功时执行  
                $("" + $table + " th").css("text-align", "center");  //设置表头内容居中
            },
            onEditableSave: function (field, row, oldValue, $el) {
             
            }
        })
    }
    else if(id==4)
    {



    }
    else {
    $('#Table' + id).bootstrapTable({
        data:TableData,
        singleSelect: false,
        editable: true,//开启编辑模式  
        cache: false, //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
       // showRefresh: true,
       // search: true,
        clickToSelect: true,
        queryParams: function (param) {
            return {};
        },
        columns: [{
            title: '序号',//标题  可不加  
            field: 'Ordinal',//可不加  
            align: 'center',
            valign: 'middle',
            width: 60,
        }, {
            title: '参数名称',
            field: 'ParameterName',
            align: 'center',
            width: 100,
            valign: 'middle',
        }, {
            title: '参数ID',
            field: 'ParameterID',
            align: 'center',
            width: 100,
            valign: 'middle',
        }, {
            title: '样品01',
            field: 'Sample01',
            align: 'center',
            width: 100,
            valign: 'middle',
            formatter: function (value, row, index)
            {
                if (value == 0) return "";
                else return value;
            },
            editable: {
                type: 'text',
                size:'16',
                title: '样品01',
                validate: function (v) {
                    if (isNaN(v)) return "只能输入数值类型";
                    if (!v) return '样品01不能为空';
                    var Istrue = VTest(id, v);
                    if (Istrue != true) {
                        return '输入数值不符合要求,请重新输入';
                    }

                },
            },
        },
        {
            title: '样品02',
            field: 'Sample02',
            align: 'center',
            width: 100,
            valign: 'middle',
            formatter: function (value, row, index)
            {
                if (value == 0) return "";
                else return value;
            },
            editable: {
                type: 'text',
                title: '样品02',
                validate: function (v) {
                    if (isNaN(v)) return "只能输入数值类型";
                    if(!v)
                        return "样品02不能为空"
                    var Istrue = VTest(id, v);
                    if (Istrue != true) {
                        return '输入数值不符合要求,请重新输入';
                    }
                }

            }
        },
         {
             title: '样品03',
             field: 'Sample03',
             align: 'center',
             width: 100,
             valign: 'middle',
             formatter: function (value, row, index) {
                 if (value == 0) return "";
                 else return value;
             },
             editable: {
                 type: 'text',
                 title: '样品03',
                 validate: function (v) {
                     if (isNaN(v)) return "只能输入数值类型";
                     if (!v) return "样品03不能为空";
                     var Istrue = VTest(id, v);
                     if (Istrue != true) {
                         return '输入数值不符合要求,请重新输入';
                     }
                 }
             }
         },
          {
              title: '样品04',
              field: 'Sample04',
              align: 'center',
              width: 100,
              valign: 'middle',
              formatter: function (value, row, index) {
                  if (value == 0) return "";
                  else return value;
              },
              editable: {
                  type: 'text',
                  title: '样品04',
                  validate: function (v) {
                      if (isNaN(v)) return "只能输入数值类型";
                      if (!v) return "样品04不能为空";
                      var Istrue = VTest(id, v);
                      if (Istrue != true) {
                          return '输入数值不符合要求,请重新输入';
                      }
                  }
              }
          }, {
              title: '样品05',
              field: 'Sample05',
              align: 'center',
              width: 100,
              valign: 'middle',
              formatter: function (value, row, index) {
                  if (value == 0) return "";
                  else return value;
              },
              editable: {
                  type: 'text',
                  title: '样品05',
                  validate: function (v) {
                      if (isNaN(v)) return "只能输入数值类型";
                      if (!v) return "样品04不能为空";
                      var Istrue = VTest(id, v);
                      if (Istrue != true) {
                          return '输入数值不符合要求,请重新输入';
                      }
                  }
              }
          },
         {
             title: '样品06',
             field: 'Sample06',
             align: 'center',
             width: 100,
             valign: 'middle',
             formatter: function (value, row, index) {
                 if (value == 0) return "";
                 else return value;
             },
             editable: {
                 type: 'text',
                 title: '样品06',
                 validate: function (v) {
                     if (isNaN(v)) return "只能输入数值类型";
                     if (!v) return "样品06不能为空";
                     var Istrue = VTest(id, v);
                     if (Istrue != true) {
                         return '输入数值不符合要求,请重新输入';
                     }
                 }
             }
         },
         {
             title: '样品07',
             field: 'Sample07',
             align: 'center',
             width: 100,
             valign: 'middle',
             formatter: function (value, row, index) {
                 if (value == 0) return "";
                 else return value;
             },
             editable: {
                 type: 'text',
                 title: '样品07',
                 validate: function (v) {
                     if (isNaN(v)) return "只能输入数值类型";
                     if (!v) return "样品07不能为空";
                     var Istrue = VTest(id, v);
                     if (Istrue != true) {
                         return '输入数值不符合要求,请重新输入';
                     }
                 }
             }
         }, {
             title: '样品08',
             field: 'Sample08',
             align: 'center',
             width: 100,
             valign: 'middle',
             formatter: function (value, row, index) {
                 if (value == 0) return "";
                 else return value;
             },
             editable: {
                 type: 'text',
                 title: '样品08',
                 validate: function (v) {
                     if (isNaN(v)) return "只能输入数值类型";
                     if (!v) return "样品08不能为空";
                     var Istrue = VTest(id, v);
                     if (Istrue != true) {
                         return '输入数值不符合要求,请重新输入';
                     }
                 }
             }
         },
         {
             title: '验证代码',
             field: 'ErrCode',
             align: 'center',
             width: 100,
             valign: 'middle',
         },
         {
             title: '验证结果',
             field: 'ErrText',
             align: 'center',
             width: 100,
             valign: 'middle',
             formatter: function (value, row, index) {
                 if (value == null || value == undefined)
                     value = "";
                 return "<span style='color:white;background-color:red'>"+value+"</span>"
             }
         },
        ],
     //   rowStyler: function (index, row) {
     //    if (row.ErrCode == 9999) {
     //        return "background-color:#0000CD;color:#FFFFFF;";
     //    }  
     //},
        onLoadSuccess: function (data) {  //加载成功时执行  
            $("" + $table + " th").css("text-align", "center");  //设置表头内容居中
        },
        onClickCell: function (field, value, row, $element) {
            ParameterID = row.ParameterID
        },
     
        onCheck: function (row, $element) {
            alert(row);
        },
        onEditableSave: function (field, row, oldValue, $el) {
        }
    })
    }
    $('#Table' + id).bootstrapTable('hideColumn', "ErrCode");
    $('#Table' + id).bootstrapTable('hideColumn', "ParameterID");
    $('#Table' + id).bootstrapTable("resetView");
}

function VTest(id, Tvalue) {
    //var VList = [{ "T20LeafID": 1, "T20NodeName": "1", "LowLimit": 100, "Criterion": "GELE", "HighLimit": 1000, "Scale": 2, "UnitOfMeasure": "KG" },
    //         { "T20LeafID": 2, "T20NodeName": "2", "LowLimit": 200, "Criterion": "GTLE", "HighLimit": 500, "Scale": 1, "UnitOfMeasure": "KG" },
    //         { "T20LeafID": 3, "T20NodeName": "3", "LowLimit": 10, "Criterion": "GTLT", "HighLimit": 1000, "Scale": 1, "UnitOfMeasure": "KG" },
    //]
    //var rows = $('#Table' + id).bootstrapTable('getData');//获取当前页的数据
    ////参数ID
    //var rows = $('#Table' + id).bootstrapTable('getSelections');
    var VParameterID =ParameterID;
    var value = 0;
    for (var i = 0; i < VList.length; i++) {
        value = 0;
        //var m = 0, s1 = Tvalue.toString();
        //value = Number(s1.replace(".", "")) * Math.pow(10, VList[i].Scale);
        value = Number(Tvalue) * Math.pow(10, VList[i].Scale);
        if (value.toString().length >= 10) {
            value =Math.round(value);
        }
        if(parseInt(value, 10)==false){
            alert("填写的数值不符合规范！应为整数");
            return false;
        }
        if (VList[i].T20LeafID == VParameterID) {
           switch (VList[i].Criterion) 
           {
               case "GELE":
                   if (VList[i].LowLimit <= value && value <= VList[i].HighLimit) {
                       return true;
                   } else {
                       return false;
                   }
               case "GTLE":
                   if (VList[i].LowLimit < value && value <= VList[i].HighLimit) {
                       return true;
                   } else {
                       return false;
                   }
               case "GTLT":
                   if (VList[i].LowLimit < value && value < VList[i].HighLimit) {
                       return true;
                   }
                   else {
                       return false;
                   }
               case "GELT":
                   if (VList[i].LowLimit <= value && value < VList[i].HighLimit) {
                       return true;
                   } else {
                       return false;
                   }
               case "EQ":
                   if (VList[i].LowLimit == value && value == VList[i].HighLimit) {
                       return true;
                   } else {
                       return false;
                   }
               case "NE":
                   if (VList[i].LowLimit != value && value != VList[i].HighLimit) {
                       return true;
                   }
                   else{
                       return false;
                   }
               case "GE":
                   if (value >= VList[i].LowLimit) {
                       return true;
                   } else {
                       return false;
                   }
               case "LE":
                   if (value <= VList[i].HighLimit)
                   {
                       return true;
                   } else {
                       return false;
                   }
               case "GT":
                   if (value > VList[i].LowLimit) {
                       return true;
                   } else {
                    return false;
                   }
               case "LT":
                   if (value < VList[i].HighLimit) {
                       return true;
                   } else {
                       return false;
                   }
               default:
                   return false;
           }
       }
    }
   
}

//点击保存按钮，检验数据是否为空
var TestCheck = 0;
function TestTable(id) {
   var rows = $('#Table' + id).bootstrapTable('getData');
   var rowstr = JSON.stringify(rows);
   $.ajax({
       url: '/MESPDC/Serach/Check_ForNCD?timeStamp=' + new Date().getTime(),
       type: 'post',
       //contentType: "application/json; charset=utf-8",
       data: { rowstr: rowstr },
       dataType: "json",
       async: false,
       
       success: function (data) {
           var jsonData = eval('(' + data.Data + ')');
           $('#Table' + id).bootstrapTable('load', jsonData);
           $('#Table' + id).bootstrapTable("resetView");
           if (data.errCode !== 0) {
               TestCheck = 1;
               $.messager.alert('错误', data.errText);
           } else {
               var flag = true;
               $(jsonData)
                   .each(function () {
                       if (this.ErrCode !== 0) {
                           flag = false;
                           return false;
                       }
                   });

               if (flag) {
                   $.messager.alert('提示', "校验完成！");
                   TestCheck = 0;
               } else {
                   TestCheck = 1;
               }
           }
       }
   })
}
//删除不符合要求的对象
function removeByValue(arr, val) {
    var temp = 0;
    for (var i = 0; i < 8; i++) {
        temp = Number(i + 1);
        if (arr["Sample0" + temp + ""] <= val) {
            delete (arr["Sample0" + temp + ""]);
        }
    }
    return arr;
}

//保存表格内容
function SaveTable(id) {
    var ProLine = $('#ProLine').val();//产线
    var process = $('#process').val();//工序
    var checktype = $('#checktype').val();//检验类型
    var rows = $('#Table' + id).bootstrapTable('getData');
    var SaveTable = [];
    if (TabID == 3) {
        for (var i = 0; i < rows.length; i++) {
            SaveTable.push({
                "Ordinal":  rows[i].Ordinal, "ParameterName": rows[i].ParameterName, "ParameterID": rows[i].ParameterID,
                "Sample01": rows[i].Sample01,
                "Sample02": rows[i].Sample02,
                "Sample03": rows[i].Sample03,
                "Sample03": rows[i].Sample04,
                "Sample05": rows[i].Sample05,
                "Sample06": rows[i].Sample06,
                "Sample07": rows[i].Sample07,
                "Sample08":rows[i].Sample08
            });
        }


    } else {
        TestTable(id);
        if (TestCheck != 0) {
            alert("内容有误，请修改后再进行保存");
            return;
        }
        for (var i = 0; i < rows.length; i++) {
            SaveTable.push({
                "Ordinal": rows[i].Ordinal, "ParameterName": rows[i].ParameterName, "ParameterID": rows[i].ParameterID,
                "Sample01": (Number(rows[i].Sample01) * Math.pow(10, VList[i].Scale)).toString().length >= 10 ? Math.round(Number(rows[i].Sample01) * Math.pow(10, VList[i].Scale)) : Number(rows[i].Sample01) * Math.pow(10, VList[i].Scale),
                "Sample02": (Number(rows[i].Sample02) * Math.pow(10, VList[i].Scale)).toString().length >= 10 ? Math.round(Number(rows[i].Sample02) * Math.pow(10, VList[i].Scale)) : Number(rows[i].Sample02) * Math.pow(10, VList[i].Scale),
                "Sample03": (Number(rows[i].Sample03) * Math.pow(10, VList[i].Scale)).toString().length >= 10 ? Math.round(Number(rows[i].Sample03) * Math.pow(10, VList[i].Scale)) : Number(rows[i].Sample03) * Math.pow(10, VList[i].Scale),
                "Sample04": (Number(rows[i].Sample04) * Math.pow(10, VList[i].Scale)).toString().length >= 10 ? Math.round(Number(rows[i].Sample04) * Math.pow(10, VList[i].Scale)) : Number(rows[i].Sample04) * Math.pow(10, VList[i].Scale),
                "Sample05": (Number(rows[i].Sample05) * Math.pow(10, VList[i].Scale)).toString().length >= 10 ? Math.round(Number(rows[i].Sample05) * Math.pow(10, VList[i].Scale)) : Number(rows[i].Sample05) * Math.pow(10, VList[i].Scale),
                "Sample06": (Number(rows[i].Sample06) * Math.pow(10, VList[i].Scale)).toString().length >= 10 ? Math.round(Number(rows[i].Sample06) * Math.pow(10, VList[i].Scale)) : Number(rows[i].Sample06) * Math.pow(10, VList[i].Scale),
                "Sample07": (Number(rows[i].Sample07) * Math.pow(10, VList[i].Scale)).toString().length >= 10 ? Math.round(Number(rows[i].Sample07) * Math.pow(10, VList[i].Scale)) : Number(rows[i].Sample07) * Math.pow(10, VList[i].Scale),
                "Sample08": (Number(rows[i].Sample08) * Math.pow(10, VList[i].Scale)).toString().length >= 10 ? Math.round(Number(rows[i].Sample08) * Math.pow(10, VList[i].Scale)) : Number(rows[i].Sample08) * Math.pow(10, VList[i].Scale)
            });
        }
    }

    for (var i = 0; i < SaveTable.length; i++) {
        removeByValue(SaveTable[i], "-999999");
    }
    var rowstr = JSON.stringify(SaveTable);
    Ewin.confirm({ message: "您确定要保存数据吗？" }).on(function (e) {
        if (!e) {
            return false;
        }
        $.post('/MESPDC/Serach/SaveFact_ManualInspecting_ForNCD', { QCType: checktype, T102LeafID: ProLine, T107LeafID: process, InspectedQty: 0, ContainerNo: TabID, LotNumber: "", PWONo: PwoNO, MONo: "", data: rowstr }, function (result) {
            if (result.errCode != 0) {
                alert(result.errText);
                return;
            } else {
                alert(result.errText);
                return;
            }

        }, 'json')
        return true;
    });

}

//验证
function TestValidate() {
    var ProLine = $('#ProLine').val();//产线
    var process = $('#process').val();//工序
    $.ajax({
        url: '/MESPDC/Serach/GetList_MethodStandard?timeStamp=' + new Date().getTime(),
        type: 'post',
        data: { T102LeafID: ProLine, T216LeafID: process},
        dataType: "json",
        async: false,
        async: true,
        success: function (data) {
            if (data.errCode != 0) {
                alert(data.errText);
                return;
            } else {
                VList = data.DataList;
                return;
            }
        }
    })
}

