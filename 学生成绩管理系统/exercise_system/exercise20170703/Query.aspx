<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="exercise20170703.Query" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学生档案管理系统-1505211-18-韩宇-查询全部</title>
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
                            <a href="javascript:;" class="nav-link tpl-left-nav-link-list">
                                <i class="am-icon-table"></i>
                                <span>数据管理</span>
                                <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                            </a>
                            <ul class="tpl-left-nav-sub-menu">
                                <li>
                                    <a href="Insert.aspx">
                                        <i class="am-icon-angle-right"></i>
                                        <span>新增学生档案</span>
                                        <i class="tpl-left-nav-content-ico am-fr am-margin-right"></i>
                                    </a>

                                    <a href="Information.aspx">
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
                            <a href="Query.aspx" class="nav-link tpl-left-nav-link-list active">
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
                <li class="am-active">学生档案列表</li>
            </ol>
            <div class="tpl-portlet-components" style="overflow:visible;">
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> 学生档案列表
                    </div>
                </div>
                <div class="tpl-block">
                    <div class="am-g">
                        <div class="am-u-sm-12 am-u-md-3">
                            <div class="am-form-group">
                                <select id="smajor" runat="server" data-am-selected="{maxHeight:300,searchBox: 1}">
                                    <option disabled="disabled">请选择专业</option>
                                </select>
                            </div>
                        </div>
                        <div class="am-u-sm-12 am-u-md-3" style="float:left;margin-left:50px;">
                            <div class="am-input-group am-input-group-sm">
                                <input placeholder="姓名模糊查询" runat="server" id="sname" type="text" class="am-form-field"/>
                                <span class="am-input-group-btn">
                                     <button runat="server" id="btn_sear" onserverclick="btn_sear_ServerClick" class="am-btn  am-btn-default am-btn-success tpl-am-btn-success am-icon-search" type="button"></button>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="am-g">
                        <div class="am-u-sm-12">

                            <asp:GridView ID="GridView1" runat="server" class="am-table am-table-striped am-table-bordered am-table-compact" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="编号" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
                                <Columns>
                                    <asp:CommandField EditText="<div class='am-btn am-icon-pencil-square-o'>修改</div>" HeaderText="基本操作" ShowDeleteButton="True" ShowEditButton="True" DeleteText="&lt;div class='am-btn am-icon-trash-o'&gt;删除&lt;/div&gt;" SelectText="&lt;div class='am-btn am-icon-copy'&gt;查看&lt;/div&gt;" ShowSelectButton="True" />
                                </Columns>
                                <PagerSettings FirstPageText="第一页" LastPageText="最后一页" NextPageText="下页" PreviousPageText="上页" Mode="NextPreviousFirstLast" />

                                <PagerStyle HorizontalAlign="Center" />

                            </asp:GridView>

                        </div>

                    </div>
                </div>
                <div class="tpl-alert"></div>
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
