<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="exercise20170703.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学生档案管理系统-1505211-18-韩宇-主页</title>
    <link rel="icon" type="image/png" href="assets/i/favicon.png" />
    <link rel="apple-touch-icon-precomposed" href="assets/i/app-icon72x72@2x.png" />
    <link rel="stylesheet" href="assets/css/amazeui.min.css" />
    <link rel="stylesheet" href="assets/css/admin.css" />
    <link rel="stylesheet" href="assets/css/app.css" />
    <script src="assets/js/echarts.min.js"></script>
</head>
<body data-type="index">
    <form runat="server" id="form1">
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
                        <a href="Home.aspx" class="nav-link active">
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
                <li><a href="#" class="am-icon-home">首页</a></li>
                <%--<li class="am-active">内容</li>!--%>
            </ol>
            <div class="tpl-content-scope">
                <div class="note note-info">
                    <h3>使用说明
                        <span class="close" data-close="note"></span>
                    </h3>
                    <p>这是一个学生档案管理系统，可以实现学生档案的增删改查功能</p>
                    <p>
                        <span class="label label-danger">提示:</span> 从下面的入口可以进入相应的功能界面
                    </p>
                </div>
            </div>

            <div class="row">
                <div class="am-u-lg-3 am-u-md-6 am-u-sm-12">
                    <div class="dashboard-stat blue">
                        <div class="visual">
                            <i class="am-icon-comments-o"></i>
                        </div>
                        <div class="details">
                            <div class="number">新增 </div>
                            <div class="desc">新增学生档案 </div>
                        </div>
                        <a class="more" href="Insert.aspx">查看更多
                    <i class="m-icon-swapright m-icon-white"></i>
                        </a>
                    </div>
                </div>
                <div class="am-u-lg-3 am-u-md-6 am-u-sm-12">
                    <div class="dashboard-stat red">
                        <div class="visual">
                            <i class="am-icon-bar-chart-o"></i>
                        </div>
                        <div class="details">
                            <div class="number">修改 </div>
                            <div class="desc">修改学生档案 </div>
                        </div>
                        <a class="more" href="Query.aspx">查看更多
                    <i class="m-icon-swapright m-icon-white"></i>
                        </a>
                    </div>
                </div>
                <div class="am-u-lg-3 am-u-md-6 am-u-sm-12">
                    <div class="dashboard-stat green">
                        <div class="visual">
                            <i class="am-icon-apple"></i>
                        </div>
                        <div class="details">
                            <div class="number">查询 </div>
                            <div class="desc">查询学生档案 </div>
                        </div>
                        <a class="more" href="Query.aspx">查看更多
                    <i class="m-icon-swapright m-icon-white"></i>
                        </a>
                    </div>
                </div>
                <div class="am-u-lg-3 am-u-md-6 am-u-sm-12">
                    <div class="dashboard-stat purple">
                        <div class="visual">
                            <i class="am-icon-android"></i>
                        </div>
                        <div class="details">
                            <div class="number">删除 </div>
                            <div class="desc">删除学生档案 </div>
                        </div>
                        <a class="more" href="Query.aspx">查看更多
                    <i class="m-icon-swapright m-icon-white"></i>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/amazeui.min.js"></script>
    <script src="assets/js/iscroll.js"></script>
    <script src="assets/js/app.js"></script>
    </form>
</body>
</html>
