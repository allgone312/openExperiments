<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="exercise20170703.Information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学生档案管理系统-1505211-18-韩宇-查看</title>
    <link rel="icon" type="image/png" href="assets/i/favicon.png" />
    <link rel="apple-touch-icon-precomposed" href="assets/i/app-icon72x72@2x.png" />
    <link rel="stylesheet" href="assets/css/amazeui.min.css" />
    <link rel="stylesheet" href="assets/css/admin.css" />
    <link rel="stylesheet" href="assets/css/app.css" />
    <link rel="stylesheet" href="assets/css/hanyu.css" />
    <script src="assets/js/jquery.min.js"></script>

    <script type="text/javascript">
        //ajax绑定smajor
        function getmajor(type) {
            //获取选择框对象
            var select = document.getElementById("smajor");
            var cmd='1'//获取全部专业名称

            //ajax传值
            $.post("HandlerInsert.ashx", { data: cmd }, function (result) {
                var state = new Array();
                state = result.split("-");
                for (var i = 0; i < state.length; i++) {
                    select.options.add(new Option(state[i], state[i]))
                }
            });
        }
        $(document).ready(function () {
            getmajor();
            var t1 = document.getElementById("smajor");
            var hidden1 = document.getElementById("HiddenField1");
            for (i = 0; i < t1.length; i++) {//给select赋值  
                if (hidden1.value == t1.options[i].value) {
                    t1.options[i].selected = true;
                }
            }
        });
    </script>
</head>
<body data-type="index">
    <form id="form1" runat="server">
        <header class="am-topbar am-topbar-inverse admin-header">
            <div class="am-topbar-brand">
                <a href="Home.aspx" class="tpl-logo">
                    <img src="assets/img/logo.png" alt="" />
                </a>
            </div>

            <div class="am-icon-list tpl-header-nav-hover-ico am-fl am-margin-right">
            </div>

            <div class="am-collapse am-topbar-collapse" id="topbar-collapse">
                <ul class="am-nav am-nav-pills am-topbar-nav am-topbar-right admin-header-list tpl-header-list">
                    <li class="am-hide-sm-only">
                        <a href="javascript:;" id="admin-fullscreen" class="tpl-header-list-link">
                            <span class="am-icon-arrows-alt"></span>
                            <span class="admin-fullText">开启全屏</span></a>
                    </li>

                    <li class="am-dropdown" data-am-dropdown data-am-dropdown-toggle>
                        <a class="am-dropdown-toggle tpl-header-list-link" href="javascript:;">
                            <span id="admin_name" runat="server" class="tpl-header-list-user-nick"></span><span class="tpl-header-list-user-ico">
                                <img src="assets/img/user01.png" /></span>
                        </a>
                        <ul class="am-dropdown-content">
                            <li><a href="Login.aspx"><span class="am-icon-power-off"></span>退出</a></li>
                        </ul>
                    </li>
                    <li><a href="Login.aspx" class="tpl-header-list-link"><span class="am-icon-sign-out tpl-header-list-ico-out-size"></span></a></li>
                </ul>
            </div>
        </header>

        <div class="tpl-page-container tpl-page-header-fixed">


            <div class="tpl-left-nav tpl-left-nav-hover">
                <div class="tpl-left-nav-title">
                    功能列表
                </div>
                <div class="tpl-left-nav-list">
                    <ul class="tpl-left-nav-menu">
                        <li class="tpl-left-nav-item">
                            <a href="Home.aspx" class="nav-link">
                                <i class="am-icon-home"></i>
                                <span>首页</span>
                            </a>
                        </li>

                        <li class="tpl-left-nav-item">
                            <a href="javascript:;" class="nav-link tpl-left-nav-link-list  active">
                                <i class="am-icon-table"></i>
                                <span>数据管理</span>
                                <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                            </a>
                            <ul class="tpl-left-nav-sub-menu" style="display:block;">
                                <li>
                                    <a href="Insert.aspx"">
                                        <i class="am-icon-angle-right"></i>
                                        <span>新增学生档案</span>
                                        <i class="tpl-left-nav-content-ico am-fr am-margin-right"></i>
                                    </a>

                                    <a href="Information.aspx" class="active">
                                        <i class="am-icon-angle-right"></i>
                                        <span>查询学生档案</span>
                                        <i class="tpl-left-nav-content-ico am-fr am-margin-right"></i>
                                    </a>

                                    <a href="Update.aspx">
                                        <i class="am-icon-angle-right"></i>
                                        <span>修改学生档案</span>
                                        <i class="tpl-left-nav-content-ico am-fr am-margin-right"></i>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li class="tpl-left-nav-item">
                            <a href="Query.aspx" class="nav-link tpl-left-nav-link-list">
                                <i class="am-icon-table"></i>
                                <span>学生档案列表</span>
                                <i class="tpl-left-nav-more-ico am-fr am-margin-right tpl-left-nav-more-ico-rotate"></i>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="tpl-content-wrapper">
                <ol class="am-breadcrumb">
                    <li><a href="#" class="am-icon-home">数据管理</a></li>
                    <li class="am-active">查询学生档案</li>
                </ol>
                <div class="tpl-content-scope">
                    <div class="note note-info">
                        <p>
                            <span class="label label-danger">提示:</span> 本页面直接打开不会显示任何内容，请从“学生档案列表”页面进入
                        </p>
                    </div>
                </div>
                <div class="tpl-portlet-components">
                    <div class="portlet-title">
                        <div class="caption font-green bold">
                            <span class="am-icon-code"></span>学生信息
                        </div>
                    </div>
                    <div class="tpl-block">
                        <div class="am-g">
                            <div class="tpl-form-body tpl-form-line">
                                <div class="am-form tpl-form-line-form">
                                    <div class="am-form-group">
                                        <label for="user-name" class="am-u-sm-3 am-form-label">
                                            学生姓名 
                                        <span class="tpl-form-line-small-title">Name</span>
                                        </label>
                                        <div class="am-u-sm-9">
                                            <input type="text" runat="server" class="tpl-form-input" maxlength="16" id="sname" placeholder="不超过16个字符" />
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="user-email" class="am-u-sm-3 am-form-label">
                                            入学时间
                                        <span class="tpl-form-line-small-title">Time</span>
                                        </label>
                                        <div class="am-u-sm-9">
                                            <input type="text" runat="server" class="am-form-field tpl-form-no-bg" id="stime" placeholder="单击进行选择" data-am-datepicker="" readonly="readonly" />
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="user-name" class="am-u-sm-3 am-form-label">
                                            班级
                                        <span class="tpl-form-line-small-title">Class</span>
                                        </label>
                                        <div class="am-u-sm-9">
                                            <input type="text" runat="server" class="tpl-form-input" maxlength="16" id="classid" placeholder="不超过16个字符" />
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="user-name" class="am-u-sm-3 am-form-label">
                                            学号
                                        <span class="tpl-form-line-small-title">Name</span>
                                        </label>
                                        <div class="am-u-sm-9">
                                            <input type="text" runat="server" class="tpl-form-input" maxlength="16" id="studid" placeholder="不超过16个字符" />
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="user-phone" class="am-u-sm-3 am-form-label">
                                            性别 
                                        <span class="tpl-form-line-small-title">Sex</span>
                                        </label>
                                        <div class="am-u-sm-9">
                                            <select id="ssex" runat="server" data-am-selected="{searchBox: 1}">
                                                <option disabled="disabled">请选择性别</option>
                                                <option value="男">男</option>
                                                <option value="女">女</option>
                                                <option value="未">未知</option>
                                            </select>
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="user-email" class="am-u-sm-3 am-form-label">
                                            出生年月
                                        <span class="tpl-form-line-small-title">Date of birth</span>
                                        </label>
                                        <div class="am-u-sm-9">
                                            <input type="text" runat="server" id="sbirthdate" class="am-form-field tpl-form-no-bg" placeholder="点击进行选择" data-am-datepicker="" readonly="readonly" />
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label class="am-u-sm-3 am-form-label">
                                            身份证号 
                                        <span class="tpl-form-line-small-title">ID number</span></label>
                                        <div class="am-u-sm-9">
                                            <input type="text" runat="server" id="idnumber" placeholder="请输入18位身份证号" />
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="user-phone" class="am-u-sm-3 am-form-label">
                                            民族
                                        <span class="tpl-form-line-small-title">Nation</span>
                                        </label>
                                        <div class="am-u-sm-9">
                                            <select id="snation" runat="server" data-am-selected="{maxHeight:300,searchBox:1}">
                                                <option disabled="disabled">请选择民族</option>
                                                <option value="汉族">汉族</option>
                                                <option value="蒙古族">蒙古族</option>
                                                <option value="满族">满族</option>
                                                <option value="朝鲜族">朝鲜族</option>
                                                <option value="赫哲族">赫哲族</option>
                                                <option value="达斡尔族">达斡尔族</option>
                                                <option value="鄂温克族">鄂温克族</option>
                                                <option value="回族">回族</option>
                                                <option value="东乡族">东乡族</option>
                                                <option value="土族">土族</option>
                                                <option value="撒拉族">撒拉族</option>
                                                <option value="保安族">保安族</option>
                                                <option value="裕固族">裕固族</option>
                                                <option value="维吾尔族">维吾尔族</option>
                                                <option value="哈萨克">哈萨克族</option>
                                                <option value="柯尔克孜族">柯尔克孜族</option>
                                                <option value="锡伯族">锡伯族</option>
                                                <option value="塔吉克">塔吉克族</option>
                                                <option value="乌孜别克族">乌孜别克族</option>
                                                <option value="俄罗斯族">俄罗斯族</option>
                                                <option value="塔塔尔族">塔塔尔族</option>
                                                <option value="藏族">藏族</option>
                                                <option value="门巴族">门巴族</option>
                                                <option value="珞巴族">珞巴族</option>
                                                <option value="羌族">羌族</option>
                                                <option value="彝族">彝族</option>
                                                <option value="白族">白族</option>
                                                <option value="哈尼族">哈尼族</option>
                                                <option value="傣族">傣族</option>
                                                <option value="傈僳族">傈僳族</option>
                                                <option value="佤">佤族</option>
                                                <option value="拉祜族">拉祜族</option>
                                                <option value="纳西族">纳西族</option>
                                                <option value="景颇族">景颇族</option>
                                                <option value="布朗族">布朗族</option>
                                                <option value="阿昌族">阿昌族</option>
                                                <option value="普米">普米族</option>
                                                <option value="怒族">怒族</option>
                                                <option value="德昂族">德昂族</option>
                                                <option value="独龙族">独龙族</option>
                                                <option value="基诺族">基诺族</option>
                                                <option value="苗">苗族</option>
                                                <option value="布依族">布依族</option>
                                                <option value="侗族">侗族</option>
                                                <option value="水族">水族</option>
                                                <option value="仡佬族">仡佬族</option>
                                                <option value="壮族">壮族</option>
                                                <option value="瑶族">瑶族</option>
                                                <option value="仫佬族">仫佬族</option>
                                                <option value="毛南族">毛南族</option>
                                                <option value="京族">京族</option>
                                                <option value="土家族">土家族</option>
                                                <option value="黎族">黎族</option>
                                                <option value="畲族">畲族</option>
                                                <option value="高山族">高山族</option>
                                            </select>
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="user-weibo" class="am-u-sm-3 am-form-label">
                                            籍贯
                                         <span class="tpl-form-line-small-title">Place of birth</span></label>
                                        <div class="am-u-sm-9">
                                            <input type="text" runat="server" id="sbirthplace" placeholder="格式：省 市/县/乡" />
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="user-phone" class="am-u-sm-3 am-form-label">
                                            所学专业 
                                        <span class="tpl-form-line-small-title">Major</span>
                                        </label>
                                        <div class="am-u-sm-9">
                                            <select id="smajor" runat="server" data-am-selected="{maxHeight:300,searchBox: 1}">
                                                <option disabled="disabled">请选择专业</option>
                                            </select>
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="address" class="am-u-sm-3 am-form-label">
                                            家庭住址
                                         <span class="tpl-form-line-small-title">Address</span></label>
                                        <div class="am-u-sm-9">
                                            <input type="text" runat="server" id="saddress" maxlength="200" placeholder="不超过200字符" />
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label class="am-u-sm-3 am-form-label">
                                            联系电话
                                        <span class="tpl-form-line-small-title">Phone</span></label>
                                        <div class="am-u-sm-9">
                                            <input id="sphone" runat="server" type="text" placeholder="家庭电话/手机号码" />

                                        &nbsp;</div>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="assets/js/echarts.min.js"></script>
        <script src="assets/js/jquery.min.js"></script>
        <script src="assets/js/amazeui.min.js"></script>
        <script src="assets/js/iscroll.js"></script>
        <script src="assets/js/app.js"></script>
    </form>
</body>
</html>

