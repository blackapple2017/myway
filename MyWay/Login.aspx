<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Login.aspx.cs" Theme="LoginHRM2013"
    Inherits="Login" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập hệ thống</title>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                Ext.net.DirectMethods.DirectLogin();
            }
        }
    </script>
    <style type="text/css">
        div#FormPanel1 .x-panel-body
        {
            background: #DFE8F6 !important;
        }
        
        div#ext-gen47, div#ext-gen51, div#ext-gen55, div#ext-gen59
        {
            position: relative !important;
        }
    </style>
    <!--[if lt IE 8]>
    <style type='text/css'>
         #table
         {
            margin:0px auto !important;
         }
        *{
        font-size:19px !important;
         }
    </style>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <%--        <div id="LoginHeader">
            <div id="InsideLoginHeader">
                <a href="#">Đặt làm trang chủ</a>
            </div>
        </div>--%>
        <ext:Window Draggable="false" Title="<%$ Resources:Language, forgot_password%>" Width="350"
            runat="server" Icon="Key" Padding="10" ID="wdResetPassword" Hidden="true" AutoHeight="true"
            Modal="false" Layout="FormLayout">
            <Items>
                <ext:FormPanel ID="FormPanel1" runat="server" BodyPadding="5" ButtonAlign="Right"
                    Layout="FormLayout" Border="false">
                    <Items>
                        <ext:TextField ID="txtResetUsername" AnchorHorizontal="100%" FieldLabel="<%$ Resources:Language, username%>"
                            AllowBlank="false" runat="server" EmptyText="<%$ Resources:Language, enter_username%>" />
                        <ext:TextField ID="txtResetEmail" Regex="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                            AnchorHorizontal="100%" FieldLabel="<%$ Resources:Language, email%>" runat="server"
                            AllowBlank="false" EmptyText="<%$ Resources:Language, enter_email%>" />
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button ID="btnResetPassword" Icon="Accept" runat="server" Text="<%$ Resources:Language, txt_get_password%>">
                    <Listeners>
                        <Click Handler="if (!#{FormPanel1}.getForm().isValid()) {
	                            Ext.Msg.show({icon: Ext.MessageBox.ERROR, title: 'Thông báo', msg: 'Email phải đúng định dạng và tên tài khoản tồn tại trong hệ thống', buttons:Ext.Msg.OK});
                                return false;
                            }" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnResetPassword_Click">
                            <EventMask ShowMask="true" Msg="<%$ Resources:Language, handling%>" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Icon="Decline" Text="<%$ Resources:Language, close%>">
                    <Listeners>
                        <Click Handler="#{wdResetPassword}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <div id="WrapperLogin">
            <div id="LoginBox">
                <div id="logo">
                </div>
                <div id="BoxLogin">
                    <p id="ptitle">
                        Đăng nhập hệ thống
                    </p>
                    <table border="0" id="table" cellpadding="6" cellspacing="6">
                        <tr>
                            <td>
                                <ext:TextField runat="server" LabelAlign="Top" ID="txtUserName" Text="demo" EnableKeyEvents="true"
                                    Width="255" FieldLabel="<%$ Resources:Language, username%>">
                                    <Listeners>
                                        <KeyPress Fn="enterKeyPressHandler" />
                                    </Listeners>
                                </ext:TextField>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ext:TextField runat="server" LabelAlign="Top" InputType="Password" Text="1" EnableKeyEvents="true"
                                    Width="255" ID="txtPassword" FieldLabel="<%$ Resources:Language, txt_password%>">
                                    <ToolTips>
                                        <ext:ToolTip Closable="true" Draggable="true" AutoHide="false" ID="tl" runat="server"
                                            Title="Nhập mật khẩu" Header="true" Frame="true" Html="Vì mật khẩu phân biệt chữ hoa chữ thường nên nếu bạn đang bật phím Caps Lock thì hãy tắt đi">
                                        </ext:ToolTip>
                                    </ToolTips>
                                    <Listeners>
                                        <Blur Handler="tl.hide();" />
                                        <Focus Handler="tl.show();" />
                                    </Listeners>
                                    <Listeners>
                                        <KeyPress Fn="enterKeyPressHandler" />
                                    </Listeners>
                                </ext:TextField>
                            </td>
                        </tr>
                        <%--  <tr>
                            <td>
                                <ext:ComboBox runat="server" LabelAlign="Top" AllowBlank="false" SelectedIndex="0"
                                    ID="cbDonVi" EnableKeyEvents="true" Width="255" Editable="false" FieldLabel="<%$ Resources:Language, choose_argency%>">
                                    <Listeners>
                                        <KeyPress Fn="enterKeyPressHandler" />
                                    </Listeners>
                                </ext:ComboBox>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <ext:ComboBox runat="server" LabelAlign="Top" AllowBlank="false" FieldLabel="<%$ Resources:Language, language%>"
                                    SelectedIndex="0" ID="cbLanguage" EnableKeyEvents="true" Width="255" Editable="false">
                                    <Items>
                                        <ext:ListItem Text="<%$ Resources:Language, vietnamese%>" Value="vi-VN" />
                                        <ext:ListItem Text="<%$ Resources:Language, english%>" Value="en-US" />
                                    </Items>
                                </ext:ComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ext:LinkButton runat="server" ID="aQuenmk" Cls="alink" Text="<%$ Resources:Language, forgot_password%>">
                                    <Listeners>
                                        <Click Handler="#{wdResetPassword}.show();" />
                                    </Listeners>
                                </ext:LinkButton>
                                <ext:Button runat="server" Icon="User" Cls="btnLogin" ID="btnLogin" Text="<%$ Resources:Language, login%>"
                                    Height="25" Width="100">
                                    <DirectEvents>
                                        <Click OnEvent="btnLogin_Click">
                                            <EventMask ShowMask="true" Msg="<%$ Resources:Language, check_account%>" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                            </td>
                        </tr>
                    </table>
                </div>
                
                <%--Dành cho bản demo khách hàng--%>
                <%--<div style="color: #000000; font-family: Tahoma; font-size: 13px;font-weight: normal; right: 40px; " >
                    <br />
                    <br />
                    <p>
                        Tài khoản truy cập phân hệ nhân sự</p>
                    <p>
                        UserName: nhansu</p>
                    <p>
                        Password: 1234567</p>
                    <br />
                    <p>
                        Tài khoản truy cập toàn hệ thống</p>
                    <p>
                        (Phần mềm không demo phần phân quyền)</p>
                    <p>
                        UserName: demo</p>
                    <p>
                        Password: 1234567</p>
                </div>--%>
            </div>
            <h1 id="copyright">
                Được phát triển bởi Công ty Cổ Phần Công Nghệ DTH và Giải Pháp Số</h1>
        </div>
    </div>
    </form>
</body>
</html>
