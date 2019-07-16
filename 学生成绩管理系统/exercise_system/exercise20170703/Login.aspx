<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="exercise20170703.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学生档案管理系统-1505211-18-韩宇-登录</title>
    <link rel="icon" type="image/png" href="assets/i/favicon.png"/>
    <link rel="apple-touch-icon-precomposed" href="assets/i/app-icon72x72@2x.png"/>
    <link rel="stylesheet" href="assets/css/amazeui.min.css" />
    <link rel="stylesheet" href="assets/css/admin.css"/>
    <link rel="stylesheet" href="assets/css/app.css"/>
 　 <script src="assets/js/jquery.min.js"></script>
    <script>
        //登录按钮跳到HOME页
        function toHome() {
            window.location.href = 'Home.aspx';
        }
    </script>
</head>
<body data-type="login">

  <div class="am-g myapp-login">
	<div class="myapp-login-logo-block  tpl-login-max">
		<div class="myapp-login-logo-text">
			<div class="myapp-login-logo-text">
				学生档案管理系统<span> 登录</span> <i class="am-icon-skyatlas"></i>				
			</div>
		</div>

		<div class="am-u-sm-10 login-am-center">
			<form class="am-form" runat="server">
				<fieldset>
					<div class="am-form-group">
						<input type="text" runat="server" class="" id="username" placeholder="请输入账号"/>
					</div>
					<div class="am-form-group">
						<input type="password" maxlength="20" class="" runat="server" id="password" placeholder="请输入密码"/>
					</div>
					<p><button runat="server" id="btn_log" maxlength="20" onserverclick="btn_log_ServerClick" class="am-btn am-btn-default">登录</button></p>
				</fieldset>
			</form>
		</div>
	</div>
</div>

  <script src="assets/js/jquery.min.js"></script>
  <script src="assets/js/amazeui.min.js"></script>
  <script src="assets/js/app.js"></script>
</body>
</html>
