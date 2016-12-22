<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login-form.aspx.aspx.cs" Inherits="login_form_aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>山东商务职业学院学生考勤管理系统</title>
    <style type="text/css">
body{
	background-image:url(images/bg1.jpg);
	background-repeat:no-repeat;
	margin:0 auto;
	font-family: 'Open Sans', sans-serif;}
h1{
	font-family: 'Exo 2', sans-serif;
	  text-align: center;
	  padding-top: 1em;
	  font-weight: 400;
	  color: #2B2B36;
	  font-size: 2em;}
#login-form{
	background: #2b2b36;
	text-align: center;
	width:350px;
	height:469px;
	margin-left:37%;
    margin-top:40px;
	border-radius: 15px;}
#login-head{
	width:350px;
	height:110px;}
#header{
	margin-top:30px;}
.userName{
	width:70%;
	padding: 1em 2em 1em 3em;
	color: #9199aa;
	font-size: 18px;
	outline: none;
	background:url(images/adm.png) no-repeat 10px 15px;
	border: none;
	font-weight: 100;
	border-bottom: 1px solid#484856;
	margin-top: 2em;
	  }
.login-pwd{
	width:70%;
	padding: 1em 2em 1em 3em;
	color: #dd3e3e;
	font-size: 18px;
	outline: none;
	background:url(images/key.png) no-repeat 10px 23px;
	border: none;
	font-weight: 100;
	border-bottom: 1px solid#484856;}
.ya{
	border-bottom: 1px solid#484856;
    height:55px;
	}
.yanbox{
	        border-style: none;
            border-color: inherit;
            border-width: medium;
            width:57px;
	        color: #9199aa;
            border:none;
	        padding: 1em 2em 1em 1em;
	        outline: none;
	        background: no-repeat 10px 23px;
	        font-weight: 100;
	        font-size: 18px;
        }
#Button1{
	width:100%;
	height:100px;
	color:#FFF;
    outline: none;
    border: none;
	background: #3ea751;
	border-bottom-left-radius:15px;
	border-bottom-right-radius:15px;
	cursor: pointer;
	font-size: 30px;}
#Button1:hover{
	background: #ff2775;}
        .code {
            position:relative;
            top:10px;
        }
         #lab {
             width:100%;
             height:3em;
             line-height:3em;
        }
input[type=range] {
    -webkit-appearance: none;
    width: 300px;
    border-radius: 10px; /*这个属性设置使填充进度条时的图形为圆角*/
}
input[type=range]::-webkit-slider-thumb {
    -webkit-appearance: none;
} 
input[type=range]::-webkit-slider-runnable-track {
    height: 15px;
    border-radius: 10px; /*将轨道设为圆角的*/
    box-shadow: 0 1px 1px #def3f8, inset 0 .125em .125em #0d1112; /*轨道内置阴影效果*/
}
input[type=range]:focus {
    outline: none;
}
input[type=range]::-webkit-slider-thumb {
    -webkit-appearance: none;
    height: 25px;
    width: 25px;
    margin-top: -5px; /*使滑块超出轨道部分的偏移量相等*/
    background: #ffffff; 
    border-radius: 50%; /*外观设置为圆形*/
    border: solid 0.125em rgba(205, 224, 230, 0.5); /*设置边框*/
    box-shadow: 0 .125em .125em #3b4547; /*添加底部阴影*/
}
input[type=range]:-moz-range-progress {
    background: linear-gradient(to right, #059CFA, white 100%, white);
    height: 13px;    
    border-radius: 10px;
}
input[type=range] {
    -webkit-appearance: none;
    width: 300px;
    border-radius: 10px;
}

input[type=range]::-ms-track {
    height: 25px;
    border-radius: 10px;
    box-shadow: 0 1px 1px #def3f8, inset 0 .125em .125em #0d1112;
    border-color: transparent; /*去除原有边框*/
    color: transparent; /*去除轨道内的竖线*/
}

input[type=range]::-ms-thumb {
    border: solid 0.125em rgba(205, 224, 230, 0.5);
    height: 25px;
    width: 25px;
    border-radius: 50%;
    background: #ffffff;
    margin-top: -5px;
    box-shadow: 0 .125em .125em #3b4547;
}

input[type=range]::-ms-fill-lower {
    /*进度条已填充的部分*/
    height: 22px;
    border-radius: 10px;
    background: linear-gradient(to right, #059CFA, white 100%, white);
}

input[type=range]::-ms-fill-upper {
    /*进度条未填充的部分*/
    height: 22px;
    border-radius: 10px;
    background: #ffffff;
}

input[type=range]:focus::-ms-fill-lower {
    background: linear-gradient(to right, #059CFA, white 100%, white);
}

input[type=range]:focus::-ms-fill-upper {
    background: #ffffff;
}
</style>
<script type="text/javascript">
    var b=1;
    function a() {
        document.getElementById("body").style.backgroundImage = "url(images/bg"+b+".jpg)";
        b++;
        if (b> 5) { b = 1;}
    }
    setInterval("a()", 10000);
</script>

</head>
<body id="body">
    <embed type="application/x-shockwave-flash" src="flish/f4.swf" aria-hidden="true" hidden="hidden" wmode="transparent" style="z-index:-100; position:absolute; width: 100%; height: 100%;" />
    <form id="form1" runat="server">
    <h1>山东商务职业学院学生考勤系统</h1>
<div id="login-form">
<div id="login-head">
<img src="images/avtar.png" id="header" />
</div>
<div>
<input type="text" id="userBox" runat="server" class="userName" value="用户名" onfocus="this.value='';" onblur="if(this.value==''){this.value='用户名';}" />
</div>
<div>
<input type="password" id="pwdBox" runat="server" class="login-pwd" value="密码" onfocus="
this.value='';" onblur="if(this.value==''){this.value='密码';}" />
</div>
<div class="ya">
<label style="line-height:2em; color:#666;">拖动滑块</label>
    <input type="range" id="yanz" max="100" min="0" value="0" runat="server" style="width:200px" />
    <img src="images/pass.png" title="请滑动滑块到右端" />
</div>
     
    <div id="lab">

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    </div>
<div>
    <asp:Button ID="Button1" runat="server" Text="登陆" OnClick="Button1_Click" />
</div>
</div>
    </form>
</body>

</html>
