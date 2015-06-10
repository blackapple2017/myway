var CheckInputDate = function (dateControl, message) {
    if (dateControl.getValue() == '') {
        Ext.Msg.alert('Thông báo', message);
        return false;
    }
    return true;
}