
var common = {
    //检查返回的Ajax结果
    checkResponse: function (_data) {
        if (_data.ResultCode == 1) {
            return true;
        } else {
            alert(_data.Message);
            return false;
        }
    }
};