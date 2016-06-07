/*公共方法*/
var gFunc = {
    setCheckBoxStyle: function (target) {
        if (gFunc.isNull(target)) {
            return;
        }
        $(target).iCheck({
            checkboxClass: 'icheckbox_square-blue',
            radioClass: 'iradio_square-blue',
            increaseArea: '20%' // optional
        });
    },
    isNull: function (value) {
        return typeof (value) == 'undefined' || value == null;
    },
    /*
    解析日期：
        ①value为Date，直接返回；
        ②value为字符串，两种格式
            yyyy-MM-dd
            yyyy-MM-dd hh:mm:ss
    */
    getDate: function (value) {
        //console.log("getDate input " + value);
        if (gFunc.isNull(value)) {
            return new Date();
        }
        if (value instanceof Date) {
            return value;
        }
        var tempStrs = value.split(" ");
        var dateStrs = tempStrs[0].split("-");
        var year = parseInt(dateStrs[0], 10);
        var month = parseInt(dateStrs[1], 10) - 1;
        var day = parseInt(dateStrs[2], 10);
        var hour = 0, minute = 0, second = 0;
        if (tempStrs[1]) {
            timeStrs = tempStrs[1].split(":");
            hour = parseInt(timeStrs[0], 10);
            minute = parseInt(timeStrs[1], 10);
            second = parseInt(timeStrs[2], 10);
        }
        var date = new Date(year, month, day, hour, minute, second);
        return date;
    },
    getAge: function (value) {
        var birthDay = gFunc.getDate(value);
        if (!birthDay) {
            return null;
        }
        var dateNow = new Date();
        age = dateNow.getYear() - birthDay.getYear() + 1;
        return age;
    },
    getRootPath: function () {
        //获取当前网址，如： http://localhost:8083/uimcardprj/share/meun.jsp
        var curWwwPath = window.document.location.href;
        //获取主机地址之后的目录，如： uimcardprj/share/meun.jsp
        var pathName = window.document.location.pathname;
        var pos = curWwwPath.indexOf(pathName);
        //获取主机地址，如： http://localhost:8083
        var localhostPaht = curWwwPath.substring(0, pos);
        //获取带"/"的项目名，如：/uimcardprj
        var projectName = pathName.substring(0, pathName.substr(1).indexOf('/') + 1);
        return (localhostPaht + projectName);
    }
};